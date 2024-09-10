using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Raster to Polyline</para>
	/// <para>Converts a raster dataset to polyline features.</para>
	/// </summary>
	public class RasterToPolyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster must be integer type.</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output polyline features</para>
		/// <para>The output feature class that will contain the converted polylines.</para>
		/// </param>
		public RasterToPolyline(object InRaster, object OutPolylineFeatures)
		{
			this.InRaster = InRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster to Polyline</para>
		/// </summary>
		public override string DisplayName() => "Raster to Polyline";

		/// <summary>
		/// <para>Tool Name : RasterToPolyline</para>
		/// </summary>
		public override string ToolName() => "RasterToPolyline";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToPolyline</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToPolyline";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutPolylineFeatures, BackgroundValue, MinimumDangleLength, Simplify, RasterField };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster must be integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>The output feature class that will contain the converted polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Background value</para>
		/// <para>Specifies the value that will identify the background cells. The raster dataset is viewed as a set of foreground cells and background cells. The linear features are formed from the foreground cells.</para>
		/// <para>Zero—The background is composed of cells of zero or less or NoData. All cells with a value greater than zero are considered a foreground value.</para>
		/// <para>NoData—The background is composed of NoData cells. All cells with valid values belong to the foreground.</para>
		/// <para><see cref="BackgroundValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BackgroundValue { get; set; } = "ZERO";

		/// <summary>
		/// <para>Minimum dangle length</para>
		/// <para>Minimum length of dangling polylines that will be retained. The default is zero.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MinimumDangleLength { get; set; } = "0";

		/// <summary>
		/// <para>Simplify polylines</para>
		/// <para>Simplifies a line by removing small fluctuations or extraneous bends from it while preserving its essential shape.</para>
		/// <para>Checked—The polylines will be simplified into simpler shapes such that each contains a minimum number of segments. This is the default.</para>
		/// <para>Unchecked—The polylines will not be simplified.</para>
		/// <para><see cref="SimplifyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Simplify { get; set; } = "true";

		/// <summary>
		/// <para>Field</para>
		/// <para>The field used to assign values from the cells in the input raster to the polyline features in the output dataset.</para>
		/// <para>It can be an integer or a string field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object RasterField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToPolyline SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , bool? maintainSpatialIndex = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Background value</para>
		/// </summary>
		public enum BackgroundValueEnum 
		{
			/// <summary>
			/// <para>Zero—The background is composed of cells of zero or less or NoData. All cells with a value greater than zero are considered a foreground value.</para>
			/// </summary>
			[GPValue("ZERO")]
			[Description("Zero")]
			Zero,

			/// <summary>
			/// <para>NoData—The background is composed of NoData cells. All cells with valid values belong to the foreground.</para>
			/// </summary>
			[GPValue("NODATA")]
			[Description("NoData")]
			NoData,

		}

		/// <summary>
		/// <para>Simplify polylines</para>
		/// </summary>
		public enum SimplifyEnum 
		{
			/// <summary>
			/// <para>Checked—The polylines will be simplified into simpler shapes such that each contains a minimum number of segments. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SIMPLIFY")]
			SIMPLIFY,

			/// <summary>
			/// <para>Unchecked—The polylines will not be simplified.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SIMPLIFY")]
			NO_SIMPLIFY,

		}

#endregion
	}
}
