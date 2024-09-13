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
	/// <para>Raster to Polygon</para>
	/// <para>Raster to Polygon</para>
	/// <para>Converts a raster dataset to polygon features.</para>
	/// </summary>
	public class RasterToPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster must be integer type.</para>
		/// </param>
		/// <param name="OutPolygonFeatures">
		/// <para>Output polygon features</para>
		/// <para>The output feature class that will contain the converted polygons.</para>
		/// </param>
		public RasterToPolygon(object InRaster, object OutPolygonFeatures)
		{
			this.InRaster = InRaster;
			this.OutPolygonFeatures = OutPolygonFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster to Polygon</para>
		/// </summary>
		public override string DisplayName() => "Raster to Polygon";

		/// <summary>
		/// <para>Tool Name : RasterToPolygon</para>
		/// </summary>
		public override string ToolName() => "RasterToPolygon";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToPolygon</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToPolygon";

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
		public override object[] Parameters() => new object[] { InRaster, OutPolygonFeatures, Simplify!, RasterField!, CreateMultipartFeatures!, MaxVerticesPerFeature! };

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
		/// <para>Output polygon features</para>
		/// <para>The output feature class that will contain the converted polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Simplify polygons</para>
		/// <para>Determines if the output polygons will be smoothed into simpler shapes or conform to the input raster&apos;s cell edges.</para>
		/// <para>Checked—The polygons will be smoothed into simpler shapes. The smoothing is done in such a way that the polygons contain a minimum number of segments while remaining as close as possible to the original raster cell edges. This is the default.</para>
		/// <para>Unchecked—The edge of the polygons will conform exactly to the input raster&apos;s cell edges. With this option, converting the resulting polygon feature class back to a raster would produce a raster the same as the original.</para>
		/// <para><see cref="SimplifyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Simplify { get; set; } = "true";

		/// <summary>
		/// <para>Field</para>
		/// <para>The field used to assign values from the cells in the input raster to the polygons in the output dataset.</para>
		/// <para>It can be an integer or a string field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object? RasterField { get; set; }

		/// <summary>
		/// <para>Create multipart features</para>
		/// <para>Specifies whether the output polygons will consist of single-part or multipart features.</para>
		/// <para>Checked—Specifies that multipart features will be created based on polygons that have the same value.</para>
		/// <para>Unchecked—Specifies that individual features will be created for each polygon. This is the default.</para>
		/// <para><see cref="CreateMultipartFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateMultipartFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Maximum vertices per polygon feature</para>
		/// <para>The vertex limit used to subdivide a polygon into smaller polygons. This parameter produces similar output as created by the Dice tool.</para>
		/// <para>If left empty, the output polygons will not be split. The default is empty.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 4)]
		[High(Allow = true, Value = 2147483646)]
		public object? MaxVerticesPerFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToPolygon SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Simplify polygons</para>
		/// </summary>
		public enum SimplifyEnum 
		{
			/// <summary>
			/// <para>Checked—The polygons will be smoothed into simpler shapes. The smoothing is done in such a way that the polygons contain a minimum number of segments while remaining as close as possible to the original raster cell edges. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SIMPLIFY")]
			SIMPLIFY,

			/// <summary>
			/// <para>Unchecked—The edge of the polygons will conform exactly to the input raster&apos;s cell edges. With this option, converting the resulting polygon feature class back to a raster would produce a raster the same as the original.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SIMPLIFY")]
			NO_SIMPLIFY,

		}

		/// <summary>
		/// <para>Create multipart features</para>
		/// </summary>
		public enum CreateMultipartFeaturesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Specifies that individual features will be created for each polygon. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_OUTER_PART")]
			SINGLE_OUTER_PART,

			/// <summary>
			/// <para>Checked—Specifies that multipart features will be created based on polygons that have the same value.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPLE_OUTER_PART")]
			MULTIPLE_OUTER_PART,

		}

#endregion
	}
}
