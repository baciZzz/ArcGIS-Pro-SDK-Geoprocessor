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
	/// <para>Extract Values to Points</para>
	/// <para>Extract Values to Points</para>
	/// <para>Extracts the cell values of a raster based on a set of point features and records the values in the attribute table of an output feature class.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.ExtractMultiValuesToPoints"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.ExtractMultiValuesToPoints))]
	public class ExtractValuesToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The input point features defining the locations from which you want to extract the raster cell values.</para>
		/// </param>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The raster dataset whose values will be extracted.</para>
		/// <para>It can be an integer or floating-point type raster.</para>
		/// </param>
		/// <param name="OutPointFeatures">
		/// <para>Output point features</para>
		/// <para>The output point feature dataset containing the extracted raster values.</para>
		/// </param>
		public ExtractValuesToPoints(object InPointFeatures, object InRaster, object OutPointFeatures)
		{
			this.InPointFeatures = InPointFeatures;
			this.InRaster = InRaster;
			this.OutPointFeatures = OutPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Values to Points</para>
		/// </summary>
		public override string DisplayName() => "Extract Values to Points";

		/// <summary>
		/// <para>Tool Name : ExtractValuesToPoints</para>
		/// </summary>
		public override string ToolName() => "ExtractValuesToPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractValuesToPoints</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractValuesToPoints";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, InRaster, OutPointFeatures, InterpolateValues, AddAttributes };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The input point features defining the locations from which you want to extract the raster cell values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The raster dataset whose values will be extracted.</para>
		/// <para>It can be an integer or floating-point type raster.</para>
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
		/// <para>The output point feature dataset containing the extracted raster values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPointFeatures { get; set; }

		/// <summary>
		/// <para>Interpolate values at the point locations</para>
		/// <para>Specifies whether interpolation will be used.</para>
		/// <para>Unchecked—No interpolation will be applied; the value of the cell center will be used. This is the default.</para>
		/// <para>Checked—The value of the cell will be calculated from the adjacent cells with valid values using bilinear interpolation. NoData values will be ignored in the interpolation unless all adjacent cells are NoData.</para>
		/// <para><see cref="InterpolateValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InterpolateValues { get; set; } = "false";

		/// <summary>
		/// <para>Append all the input raster attributes to the output point features</para>
		/// <para>Determines if the raster attributes are written to the output point feature dataset.</para>
		/// <para>Unchecked—Only the value of the input raster is added to the point attributes. This is the default.</para>
		/// <para>Checked—All the fields from the input raster (except Count) will be added to the point attributes.</para>
		/// <para><see cref="AddAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddAttributes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractValuesToPoints SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, bool? maintainSpatialIndex = null, object mask = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, bool? transferDomains = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolate values at the point locations</para>
		/// </summary>
		public enum InterpolateValuesEnum 
		{
			/// <summary>
			/// <para>Unchecked—No interpolation will be applied; the value of the cell center will be used. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

			/// <summary>
			/// <para>Checked—The value of the cell will be calculated from the adjacent cells with valid values using bilinear interpolation. NoData values will be ignored in the interpolation unless all adjacent cells are NoData.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INTERPOLATE")]
			INTERPOLATE,

		}

		/// <summary>
		/// <para>Append all the input raster attributes to the output point features</para>
		/// </summary>
		public enum AddAttributesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Only the value of the input raster is added to the point attributes. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("VALUE_ONLY")]
			VALUE_ONLY,

			/// <summary>
			/// <para>Checked—All the fields from the input raster (except Count) will be added to the point attributes.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL")]
			ALL,

		}

#endregion
	}
}
