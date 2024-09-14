using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Convert Raster To Feature</para>
	/// <para>栅格转要素</para>
	/// <para>将栅格转换为点、线或面的要素数据集。</para>
	/// </summary>
	public class ConvertRasterToFeature : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster Layer</para>
		/// <para>输入栅格图层。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>包含已转换点、线或面的输出要素类。</para>
		/// </param>
		public ConvertRasterToFeature(object Inputraster, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转要素</para>
		/// </summary>
		public override string DisplayName() => "栅格转要素";

		/// <summary>
		/// <para>Tool Name : ConvertRasterToFeature</para>
		/// </summary>
		public override string ToolName() => "ConvertRasterToFeature";

		/// <summary>
		/// <para>Tool Excute Name : ra.ConvertRasterToFeature</para>
		/// </summary>
		public override string ExcuteName() => "ra.ConvertRasterToFeature";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputraster, Field, Outputtype, Simplifylinesorpolygons, Outputname, Outputfeatures, Createmultipartfeatures, Maxverticesperfeature };

		/// <summary>
		/// <para>Input Raster Layer</para>
		/// <para>输入栅格图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>用于指定转换值的字段。</para>
		/// <para>该值可以是整数值或文本值。</para>
		/// <para>包含浮点值的字段仅限向点数据集输出时使用。</para>
		/// <para>默认为 Value 字段，其中包含每个栅格像元中的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Field { get; set; } = "Value";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定输出类型。</para>
		/// <para>点—栅格将转换为点数据集。这是默认设置。</para>
		/// <para>线—栅格将转换为线要素数据集。</para>
		/// <para>面—栅格将转换为面要素数据集。</para>
		/// <para>如果输出类型为线或面，则将显示一个附加参数，用于简化线或面。</para>
		/// <para><see cref="OutputtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Outputtype { get; set; } = "POINT";

		/// <summary>
		/// <para>Simplify Lines or Polygons</para>
		/// <para>指定是否将简化（平滑）线或面。使线拥有最少线段数，同时尽可能接近原始栅格像元边，这就是平滑的实现方式。</para>
		/// <para>选中 - 将对线或面要素进行平滑处理，以生成更为概化的结果。这是默认设置。</para>
		/// <para>取消选中 - 线或面要素将不会进行平滑处理，并且将遵循栅格数据集的像元边界。</para>
		/// <para><see cref="SimplifylinesorpolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Simplifylinesorpolygons { get; set; } = "true";

		/// <summary>
		/// <para>Output Name</para>
		/// <para>包含已转换点、线或面的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Output Feature</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object Outputfeatures { get; set; }

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// <para>指定输出面是由单部分要素还是多部分要素组成。</para>
		/// <para>选中 - 将根据具有相同值的面创建多部分要素。</para>
		/// <para>取消选中 - 将为每个面创建单个（单部分）要素。这是默认设置。</para>
		/// <para><see cref="CreatemultipartfeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Createmultipartfeatures { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Vertices Per Polygon Feature</para>
		/// <para>用于将面细分为更小的面的折点限制。此参数将产生的输出与数据管理工具箱中的切分工具创建的输出类似。</para>
		/// <para>如果留空，则输出面不会被分割。这是默认设置。</para>
		/// <para>仅当输出类型为面时，才支持此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Maxverticesperfeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertRasterToFeature SetEnviroment(object extent = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputtypeEnum 
		{
			/// <summary>
			/// <para>点—栅格将转换为点数据集。这是默认设置。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>线—栅格将转换为线要素数据集。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

			/// <summary>
			/// <para>面—栅格将转换为面要素数据集。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

		}

		/// <summary>
		/// <para>Simplify Lines or Polygons</para>
		/// </summary>
		public enum SimplifylinesorpolygonsEnum 
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
		/// <para>Create Multipart Features</para>
		/// </summary>
		public enum CreatemultipartfeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPLE_OUTER_PART")]
			MULTIPLE_OUTER_PART,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_OUTER_PART")]
			SINGLE_OUTER_PART,

		}

#endregion
	}
}
