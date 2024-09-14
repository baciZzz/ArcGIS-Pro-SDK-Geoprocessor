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
	/// <para>栅格转面</para>
	/// <para>将栅格数据集转换为面要素。</para>
	/// </summary>
	public class RasterToPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入栅格数据集。</para>
		/// <para>栅格数据必须是整型。</para>
		/// </param>
		/// <param name="OutPolygonFeatures">
		/// <para>Output polygon features</para>
		/// <para>包含已转换面的输出要素类。</para>
		/// </param>
		public RasterToPolygon(object InRaster, object OutPolygonFeatures)
		{
			this.InRaster = InRaster;
			this.OutPolygonFeatures = OutPolygonFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转面</para>
		/// </summary>
		public override string DisplayName() => "栅格转面";

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
		public override object[] Parameters() => new object[] { InRaster, OutPolygonFeatures, Simplify, RasterField, CreateMultipartFeatures, MaxVerticesPerFeature };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入栅格数据集。</para>
		/// <para>栅格数据必须是整型。</para>
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
		/// <para>包含已转换面的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Simplify polygons</para>
		/// <para>用于确定输出的面将平滑为简单的形状还是与输入栅格的像元边缘保持一致。</para>
		/// <para>选中 - 面将平滑处理为简单的形状。面拥有最少线段数，同时尽可能接近原始栅格像元边缘，这就是平滑的实现方式。这是默认设置。</para>
		/// <para>未选中 - 面的边将与输入栅格的像元边缘完全保持一致。使用此选项将面要素类转换回栅格，将产生与原始栅格相同的栅格。</para>
		/// <para><see cref="SimplifyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Simplify { get; set; } = "true";

		/// <summary>
		/// <para>Field</para>
		/// <para>此字段用于将输入栅格中像元值指定给输出数据集中的面。</para>
		/// <para>栅格字段可为整型或字符串型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(GUID = "{4B6CA858-5716-4AC3-A2EE-70EE2D29C1BD}", UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object RasterField { get; set; }

		/// <summary>
		/// <para>Create multipart features</para>
		/// <para>指定输出面是由单部分要素还是多部分要素组成。</para>
		/// <para>选中 - 指定将根据具有相同值的面创建多部分要素。</para>
		/// <para>未选中 - 指定将为每个面创建单个要素。这是默认设置。</para>
		/// <para><see cref="CreateMultipartFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateMultipartFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Maximum vertices per polygon feature</para>
		/// <para>用于将面细分为更小的面的折点限制。此参数产生的输出与切分工具创建的输出类似。</para>
		/// <para>如果留空，则输出面不会被分割。默认值为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 4)]
		[High(Allow = true, Value = 2147483646)]
		public object MaxVerticesPerFeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToPolygon SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, bool? maintainSpatialIndex = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SIMPLIFY")]
			SIMPLIFY,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_OUTER_PART")]
			SINGLE_OUTER_PART,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPLE_OUTER_PART")]
			MULTIPLE_OUTER_PART,

		}

#endregion
	}
}
