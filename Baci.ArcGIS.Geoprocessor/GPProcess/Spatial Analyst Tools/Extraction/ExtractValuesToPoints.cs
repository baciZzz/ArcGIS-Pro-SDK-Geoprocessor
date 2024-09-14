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
	/// <para>值提取至点</para>
	/// <para>根据一组点要素提取栅格的像元值，并将值记录在输出要素类的属性表中。</para>
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
		/// <para>输入点要素可定义要提取栅格像元值的位置。</para>
		/// </param>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>要提取其值的栅格数据集。</para>
		/// <para>其栅格类型可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutPointFeatures">
		/// <para>Output point features</para>
		/// <para>包含已提取的栅格值的输出点要素数据集。</para>
		/// </param>
		public ExtractValuesToPoints(object InPointFeatures, object InRaster, object OutPointFeatures)
		{
			this.InPointFeatures = InPointFeatures;
			this.InRaster = InRaster;
			this.OutPointFeatures = OutPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 值提取至点</para>
		/// </summary>
		public override string DisplayName() => "值提取至点";

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
		public override object[] Parameters() => new object[] { InPointFeatures, InRaster, OutPointFeatures, InterpolateValues!, AddAttributes! };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>输入点要素可定义要提取栅格像元值的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input raster</para>
		/// <para>要提取其值的栅格数据集。</para>
		/// <para>其栅格类型可为整型或浮点型。</para>
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
		/// <para>包含已提取的栅格值的输出点要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPointFeatures { get; set; }

		/// <summary>
		/// <para>Interpolate values at the point locations</para>
		/// <para>指定是否使用插值。</para>
		/// <para>未选中 - 不应用任何插值法；将使用像元中心值。 这是默认设置。</para>
		/// <para>选中 - 将使用双线性插值法根据相邻像元的有效值计算像元值。 将在插值中忽略 NoData 值，除非所有相邻像元均为 NoData。</para>
		/// <para><see cref="InterpolateValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InterpolateValues { get; set; } = "false";

		/// <summary>
		/// <para>Append all the input raster attributes to the output point features</para>
		/// <para>确定栅格属性是否写入输出点要素数据集。</para>
		/// <para>未选中 - 仅将输入栅格的值添加到点属性。 这是默认设置。</para>
		/// <para>选中 - 输入栅格的所有字段（Count 除外）都将添加到点属性。</para>
		/// <para><see cref="AddAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddAttributes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractValuesToPoints SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, bool? maintainSpatialIndex = null, object? mask = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, bool? transferDomains = null, object? workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("VALUE_ONLY")]
			VALUE_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL")]
			ALL,

		}

#endregion
	}
}
