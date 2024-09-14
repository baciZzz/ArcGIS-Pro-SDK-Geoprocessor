using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Apply Symbology From Layer</para>
	/// <para>应用图层的符号设置</para>
	/// <para>用于将指定图层或图层文件中的符号系统应用于输入。此工具可应用于要素、栅格、网络分析、TIN 以及地理统计图层。</para>
	/// </summary>
	public class ApplySymbologyFromLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>将应用符号系统的图层。</para>
		/// </param>
		/// <param name="InSymbologyLayer">
		/// <para>Symbology Layer</para>
		/// <para>此图层的符号系统将应用于输入图层。支持 .lyrx 和 .lyr 文件。</para>
		/// </param>
		public ApplySymbologyFromLayer(object InLayer, object InSymbologyLayer)
		{
			this.InLayer = InLayer;
			this.InSymbologyLayer = InSymbologyLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用图层的符号设置</para>
		/// </summary>
		public override string DisplayName() => "应用图层的符号设置";

		/// <summary>
		/// <para>Tool Name : ApplySymbologyFromLayer</para>
		/// </summary>
		public override string ToolName() => "ApplySymbologyFromLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.ApplySymbologyFromLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.ApplySymbologyFromLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, InSymbologyLayer, SymbologyFields, OutLayer, UpdateSymbology };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将应用符号系统的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Symbology Layer</para>
		/// <para>此图层的符号系统将应用于输入图层。支持 .lyrx 和 .lyr 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		public object InSymbologyLayer { get; set; }

		/// <summary>
		/// <para>Symbology Fields</para>
		/// <para>与符号系统图层中使用的符号系统字段相匹配的输入图层中的字段。符号系统字段包含以下三个属性：</para>
		/// <para>字段类型 - 指定字段类型：符号系统值、归一化或其他类型。</para>
		/// <para>源字段 - 符号系统图层中使用的符号系统字段。如果不知道源字段并要使用默认值，请使用空白值或 &quot;#&quot;。</para>
		/// <para>目标字段 - 应用符号系统时要使用的输入图层中的字段。</para>
		/// <para>支持的字段类型如下：</para>
		/// <para>值字段 - 用于对值进行符号化的主要字段</para>
		/// <para>归一化字段 - 用于对定量值进行归一化的字段</para>
		/// <para>排除子句字段 - 用于符号系统排除子句的字段</para>
		/// <para>图表渲染器饼图大小字段 - 用于设置饼图符号大小的字段</para>
		/// <para>旋转 X 表达式字段 - 用于设置 x 轴上符号旋转的字段</para>
		/// <para>旋转 Y 表达式字段 - 用于设置 y 轴上符号旋转的字段</para>
		/// <para>旋转 Z 表达式字段 - 用于设置 z 轴上符号旋转的字段</para>
		/// <para>透明度表达式字段 - 用于设置符号透明度的字段</para>
		/// <para>透明度归一化字段 - 用于归一化透明度值的字段</para>
		/// <para>大小表达式字段 - 用于设置符号大小或宽度的字段</para>
		/// <para>颜色表达式字段 - 用于设置符号颜色的字段</para>
		/// <para>原始覆盖表达式字段 - 用于设置单个符号图层上各种属性的字段</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SymbologyFields { get; set; }

		/// <summary>
		/// <para>Updated Input Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Update Symbology Ranges by Data</para>
		/// <para>指定是否将更新符号系统范围。</para>
		/// <para>默认—除了以下情形之外，将对符号系统范围进行更新：当输入图层为空时；当符号系统图层使用分类间隔（例如，分级色彩或分级符号），并且分类方法为手动间隔或定义间隔时；或者，当符号系统图层使用唯一值，并且选中显示所有其他值选项时。</para>
		/// <para>更新范围—符号系统范围将更新。</para>
		/// <para>维护范围—符号系统范围将不会更新；这些范围将保留不变。</para>
		/// <para><see cref="UpdateSymbologyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateSymbology { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApplySymbologyFromLayer SetEnviroment(int? autoCommit = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Symbology Ranges by Data</para>
		/// </summary>
		public enum UpdateSymbologyEnum 
		{
			/// <summary>
			/// <para>默认—除了以下情形之外，将对符号系统范围进行更新：当输入图层为空时；当符号系统图层使用分类间隔（例如，分级色彩或分级符号），并且分类方法为手动间隔或定义间隔时；或者，当符号系统图层使用唯一值，并且选中显示所有其他值选项时。</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("默认")]
			Default,

			/// <summary>
			/// <para>更新范围—符号系统范围将更新。</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("更新范围")]
			Update_ranges,

			/// <summary>
			/// <para>维护范围—符号系统范围将不会更新；这些范围将保留不变。</para>
			/// </summary>
			[GPValue("MAINTAIN")]
			[Description("维护范围")]
			Maintain_ranges,

		}

#endregion
	}
}
