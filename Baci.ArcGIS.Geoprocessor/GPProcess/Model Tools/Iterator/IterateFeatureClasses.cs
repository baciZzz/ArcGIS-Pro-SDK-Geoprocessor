using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Feature Classes</para>
	/// <para>迭代要素类</para>
	/// <para>迭代工作空间或要素数据集中的所有要素类。</para>
	/// </summary>
	public class IterateFeatureClasses : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace or Feature Dataset</para>
		/// <para>要迭代的要素类所在的工作空间或要素数据集。如果将地理数据库定义为输入工作空间，将只迭代直接位于地理数据库下的要素类（独立要素类）。要迭代输入地理数据库中的数据集内的所有要素类，请选中递归选项。</para>
		/// </param>
		public IterateFeatureClasses(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代要素类</para>
		/// </summary>
		public override string DisplayName() => "迭代要素类";

		/// <summary>
		/// <para>Tool Name : IterateFeatureClasses</para>
		/// </summary>
		public override string ToolName() => "IterateFeatureClasses";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFeatureClasses</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateFeatureClasses";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard, FeatureType, Recursive, Features, Name };

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>要迭代的要素类所在的工作空间或要素数据集。如果将地理数据库定义为输入工作空间，将只迭代直接位于地理数据库下的要素类（独立要素类）。要迭代输入地理数据库中的数据集内的所有要素类，请选中递归选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。星号表示允许使用任意字符。如果未指定通配符，则将返回所有输入。例如，可使用通配符来限制对以某个字符或词语（例如 A*、Ari* 或 Land* 等）开头的输入名称进行迭代。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Wildcard { get; set; }

		/// <summary>
		/// <para>Feature Type</para>
		/// <para>要用作过滤器的要素类型。仅输出指定类型的要素。如果不指定要素类型，将输出所有要素。</para>
		/// <para>注记—仅输出注记要素类。</para>
		/// <para>维度—仅输出尺寸注记要素类。</para>
		/// <para>边—仅输出边要素类。</para>
		/// <para>交汇点—仅输出交汇点要素类。</para>
		/// <para>线— 仅输出线要素类。</para>
		/// <para>点—仅输出点要素类。</para>
		/// <para>面—仅输出面要素类。</para>
		/// <para>多面体—仅输出多面体要素类。</para>
		/// <para><see cref="FeatureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>确定迭代器是否迭代主工作空间中的所有子文件夹。</para>
		/// <para>选中 - 将递归迭代所有子文件夹。</para>
		/// <para>未选中 - 将不会递归迭代所有子文件。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object Features { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Feature Type</para>
		/// </summary>
		public enum FeatureTypeEnum 
		{
			/// <summary>
			/// <para>注记—仅输出注记要素类。</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("注记")]
			Annotation,

			/// <summary>
			/// <para>维度—仅输出尺寸注记要素类。</para>
			/// </summary>
			[GPValue("DIMENSION")]
			[Description("维度")]
			Dimension,

			/// <summary>
			/// <para>边—仅输出边要素类。</para>
			/// </summary>
			[GPValue("EDGE")]
			[Description("边")]
			Edge,

			/// <summary>
			/// <para>交汇点—仅输出交汇点要素类。</para>
			/// </summary>
			[GPValue("JUNCTION")]
			[Description("交汇点")]
			Junction,

			/// <summary>
			/// <para>线— 仅输出线要素类。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

			/// <summary>
			/// <para>点—仅输出点要素类。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>面—仅输出面要素类。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>多面体—仅输出多面体要素类。</para>
			/// </summary>
			[GPValue("MULTIPATCH")]
			[Description("多面体")]
			Multipatch,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
