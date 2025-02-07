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
	/// <para>Raster to Point</para>
	/// <para>Raster to Point</para>
	/// <para>Converts a raster dataset to point features.</para>
	/// </summary>
	public class RasterToPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster can be integer or floating-point type.</para>
		/// </param>
		/// <param name="OutPointFeatures">
		/// <para>Output point features</para>
		/// <para>The output feature class that will contain the converted points.</para>
		/// </param>
		public RasterToPoint(object InRaster, object OutPointFeatures)
		{
			this.InRaster = InRaster;
			this.OutPointFeatures = OutPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster to Point</para>
		/// </summary>
		public override string DisplayName() => "Raster to Point";

		/// <summary>
		/// <para>Tool Name : RasterToPoint</para>
		/// </summary>
		public override string ToolName() => "RasterToPoint";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToPoint</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToPoint";

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
		public override object[] Parameters() => new object[] { InRaster, OutPointFeatures, RasterField! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster dataset.</para>
		/// <para>The raster can be integer or floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output point features</para>
		/// <para>The output feature class that will contain the converted points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPointFeatures { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>The field to assign values from the cells in the input raster to the points in the output dataset.</para>
		/// <para>It can be an integer, floating point, or string field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object? RasterField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToPoint SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, bool? maintainSpatialIndex = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
