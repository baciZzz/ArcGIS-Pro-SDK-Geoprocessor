using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Spatial Association Between Zones</para>
	/// <para>Measures the degree of spatial association between two regionalizations of the same study area in which each regionalization is composed of a set of categories, called zones.  The association between the regionalizations is determined by the area overlap between zones of each regionalization. The association is highest when each zone of one regionalization closely corresponds to a zone of the other regionalization.  Similarly, spatial association is lowest when the zones of one regionalization have large overlap with many different zones of the other regionalization.   The primary output of the tool is a global measure of spatial association between the categorical variables: a single number ranging from 0 (no correspondence) to 1 (perfect spatial alignment of zones). Optionally, this global association can be calculated and visualized for specific zones of either regionalization or for specific combinations of zones between regionalizations.</para>
	/// </summary>
	public class SpatialAssociationBetweenZones : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureOrRaster">
		/// <para>Input Polygon Feature or Raster Zones</para>
		/// <para>The dataset representing the zones of the first regionalization. The zones can be defined using polygon features or a raster.</para>
		/// </param>
		/// <param name="CategoricalZoneField">
		/// <para>Categorical Zone Field</para>
		/// <para>The field representing the zone category of the input zones. Each unique value of this field defines an individual zone. For features, the field must be integer or text. For rasters, the VALUE field is also supported.</para>
		/// </param>
		/// <param name="OverlayFeatureOrRaster">
		/// <para>Overlay Polygon Feature or Raster Zones</para>
		/// <para>The dataset representing the zones of the second regionalization. The zones can be polygon features or a raster.</para>
		/// </param>
		/// <param name="CategoricalOverlayZoneField">
		/// <para>Categorical Overlay Zone Field</para>
		/// <para>The field representing the zone category of the overlay zones. Each unique value of this field defines an individual zone. For features, the field must be integer or text. For rasters, the VALUE field is also supported.</para>
		/// </param>
		public SpatialAssociationBetweenZones(object InputFeatureOrRaster, object CategoricalZoneField, object OverlayFeatureOrRaster, object CategoricalOverlayZoneField)
		{
			this.InputFeatureOrRaster = InputFeatureOrRaster;
			this.CategoricalZoneField = CategoricalZoneField;
			this.OverlayFeatureOrRaster = OverlayFeatureOrRaster;
			this.CategoricalOverlayZoneField = CategoricalOverlayZoneField;
		}

		/// <summary>
		/// <para>Tool Display Name : Spatial Association Between Zones</para>
		/// </summary>
		public override string DisplayName() => "Spatial Association Between Zones";

		/// <summary>
		/// <para>Tool Name : SpatialAssociationBetweenZones</para>
		/// </summary>
		public override string ToolName() => "SpatialAssociationBetweenZones";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatialAssociationBetweenZones</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatialAssociationBetweenZones";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureOrRaster, CategoricalZoneField, OverlayFeatureOrRaster, CategoricalOverlayZoneField, OutputFeatures, OutputRaster, CorrespondenceOverlayToInput, CorrespondenceInputToOverlay, GlobalMeasureOfSpatialAssociation, GlobalCorrespondenceInputToOverlay, GlobalCorrespondenceOverlayToInput };

		/// <summary>
		/// <para>Input Polygon Feature or Raster Zones</para>
		/// <para>The dataset representing the zones of the first regionalization. The zones can be defined using polygon features or a raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InputFeatureOrRaster { get; set; }

		/// <summary>
		/// <para>Categorical Zone Field</para>
		/// <para>The field representing the zone category of the input zones. Each unique value of this field defines an individual zone. For features, the field must be integer or text. For rasters, the VALUE field is also supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object CategoricalZoneField { get; set; }

		/// <summary>
		/// <para>Overlay Polygon Feature or Raster Zones</para>
		/// <para>The dataset representing the zones of the second regionalization. The zones can be polygon features or a raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OverlayFeatureOrRaster { get; set; }

		/// <summary>
		/// <para>Categorical Overlay Zone Field</para>
		/// <para>The field representing the zone category of the overlay zones. Each unique value of this field defines an individual zone. For features, the field must be integer or text. For rasters, the VALUE field is also supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object CategoricalOverlayZoneField { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output polygon features containing spatial association measures at all intersections of the input and overlay zones.</para>
		/// <para>The output features can be used to measure the association between specific combinations of input and overlay zones, such as the association between areas of corn production (crop type) and areas of well-drained soil (soil drainage class). This parameter is only enabled if the input and overlay zones are both polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output raster containing spatial association measures between the input and overlay zones.</para>
		/// <para>The output raster will have three fields to indicate the spatial association measures for intersections of the input and overlay zones, correspondence of overlay zones within input zones, and correspondence of input zones within overlay zones. This parameter is only enabled if at least one of the input and overlay zones is a raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Correspondence of Overlay Zones within Input Zones</para>
		/// <para>The output polygon features containing the correspondence measures of the overlay zones within the input zones.</para>
		/// <para>This output will have the same geometry as the input zones and can be used to identify which input zones closely correspond overall to the overlay zones. Specific zone combinations can then be investigated with the output features. This parameter is only enabled if the input and overlay zones are both polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object CorrespondenceOverlayToInput { get; set; }

		/// <summary>
		/// <para>Correspondence of Input Zones within Overlay Zones</para>
		/// <para>The output polygon features containing the correspondence measures of the input zones within the overlay zones.</para>
		/// <para>This output will have the same geometry as the overlay zones and can be used to identify which overlay zones closely correspond overall to the input zones. Specific zone combinations can then be investigated with the output features. This parameter is only enabled if the input and overlay zones are both polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object CorrespondenceInputToOverlay { get; set; }

		/// <summary>
		/// <para>Global Measure of Spatial Association</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object GlobalMeasureOfSpatialAssociation { get; set; }

		/// <summary>
		/// <para>Global Correspondence of Input Zones within Overlay Zones</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object GlobalCorrespondenceInputToOverlay { get; set; }

		/// <summary>
		/// <para>Global Correspondence of Overlay Zones within Input Zones</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object GlobalCorrespondenceOverlayToInput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialAssociationBetweenZones SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

	}
}
