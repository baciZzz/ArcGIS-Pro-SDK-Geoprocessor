using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Filter</para>
	/// <para>Filter</para>
	/// <para>Performs either a smoothing (Low pass) or edge-enhancing (High pass) filter on a raster.</para>
	/// </summary>
	public class Filter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster on which to perform the filter operation.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output filtered raster.</para>
		/// <para>The output is always floating point.</para>
		/// </param>
		public Filter(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Filter</para>
		/// </summary>
		public override string DisplayName() => "Filter";

		/// <summary>
		/// <para>Tool Name : Filter</para>
		/// </summary>
		public override string ToolName() => "Filter";

		/// <summary>
		/// <para>Tool Excute Name : sa.Filter</para>
		/// </summary>
		public override string ExcuteName() => "sa.Filter";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, FilterType!, IgnoreNodata! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster on which to perform the filter operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output filtered raster.</para>
		/// <para>The output is always floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Filter type</para>
		/// <para>The type of filter operation to perform.</para>
		/// <para>Low pass—Traverses a low pass 3-by-3 filter over the raster. This option smooths the entire input raster and reduces the significance of anomalous cells. This is the default.</para>
		/// <para>High pass—Traverses a high pass 3-by-3 filter over the raster. This option enhances the edges of subdued features in a raster.</para>
		/// <para><see cref="FilterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterType { get; set; } = "LOW";

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// <para>Denotes whether NoData values are ignored by the filter calculation.</para>
		/// <para>Checked—If a NoData value exists within the filter, the NoData value will be ignored. Only cells within the filter that have data values will be used in determining the output. This is the default.</para>
		/// <para>Unchecked—If a NoData value exists within the filter, the output for the processing cell will be NoData. With this option, the presence of a NoData value implies that there is insufficient information to determine the statistic value for the neighborhood.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Filter SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Filter type</para>
		/// </summary>
		public enum FilterTypeEnum 
		{
			/// <summary>
			/// <para>Low pass—Traverses a low pass 3-by-3 filter over the raster. This option smooths the entire input raster and reduces the significance of anomalous cells. This is the default.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low pass")]
			Low_pass,

			/// <summary>
			/// <para>High pass—Traverses a high pass 3-by-3 filter over the raster. This option enhances the edges of subdued features in a raster.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High pass")]
			High_pass,

		}

		/// <summary>
		/// <para>Ignore NoData in calculations</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para>Checked—If a NoData value exists within the filter, the NoData value will be ignored. Only cells within the filter that have data values will be used in determining the output. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—If a NoData value exists within the filter, the output for the processing cell will be NoData. With this option, the presence of a NoData value implies that there is insufficient information to determine the statistic value for the neighborhood.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

#endregion
	}
}
