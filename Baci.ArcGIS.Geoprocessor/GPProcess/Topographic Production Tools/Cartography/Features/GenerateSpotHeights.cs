using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Spot Heights</para>
	/// <para>Creates elevation point features based on contour tops and depressions. Elevation points are created in each top and depression. Point height values are populated based on a digital elevation model.</para>
	/// </summary>
	public class GenerateSpotHeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InContourFeatures">
		/// <para>Input Contours</para>
		/// <para>Contours from which spot heights are computed.</para>
		/// </param>
		/// <param name="InRaster">
		/// <para>Input Raster(s)</para>
		/// <para>Rasters used to derive the highest or lowest elevations in contour tops or depressions.</para>
		/// </param>
		/// <param name="TargetSpotFeatures">
		/// <para>Target Spot Features</para>
		/// <para>An existing point feature layer or feature class in which spot heights are created.</para>
		/// </param>
		/// <param name="ContourHeightField">
		/// <para>Contour Height Field</para>
		/// <para>The field in the input contours that contains elevation values. The field type must be numeric.</para>
		/// </param>
		/// <param name="SpotHeightField">
		/// <para>Spot Height Field</para>
		/// <para>The field in the output spot heights to which elevation values are written.</para>
		/// </param>
		public GenerateSpotHeights(object InContourFeatures, object InRaster, object TargetSpotFeatures, object ContourHeightField, object SpotHeightField)
		{
			this.InContourFeatures = InContourFeatures;
			this.InRaster = InRaster;
			this.TargetSpotFeatures = TargetSpotFeatures;
			this.ContourHeightField = ContourHeightField;
			this.SpotHeightField = SpotHeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Spot Heights</para>
		/// </summary>
		public override string DisplayName => "Generate Spot Heights";

		/// <summary>
		/// <para>Tool Name : GenerateSpotHeights</para>
		/// </summary>
		public override string ToolName => "GenerateSpotHeights";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateSpotHeights</para>
		/// </summary>
		public override string ExcuteName => "topographic.GenerateSpotHeights";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InContourFeatures, InRaster, TargetSpotFeatures, ContourHeightField, SpotHeightField, SpotHeightSubtype, AreaOfInterest, UpdatedSpotFeatures };

		/// <summary>
		/// <para>Input Contours</para>
		/// <para>Contours from which spot heights are computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InContourFeatures { get; set; }

		/// <summary>
		/// <para>Input Raster(s)</para>
		/// <para>Rasters used to derive the highest or lowest elevations in contour tops or depressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Target Spot Features</para>
		/// <para>An existing point feature layer or feature class in which spot heights are created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetSpotFeatures { get; set; }

		/// <summary>
		/// <para>Contour Height Field</para>
		/// <para>The field in the input contours that contains elevation values. The field type must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object ContourHeightField { get; set; }

		/// <summary>
		/// <para>Spot Height Field</para>
		/// <para>The field in the output spot heights to which elevation values are written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object SpotHeightField { get; set; }

		/// <summary>
		/// <para>Spot Height Subtype</para>
		/// <para>Spot height subtype value assigned to new spot height features that are created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SpotHeightSubtype { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The extent where spot heights will be created. The area of interest (AOI) is the outer extent of all selected polygons in the feature layer. If none are selected, the extent of the raster will be used. This parameter does not accept point layers as valid input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Updated Spot Heights</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedSpotFeatures { get; set; }

	}
}
