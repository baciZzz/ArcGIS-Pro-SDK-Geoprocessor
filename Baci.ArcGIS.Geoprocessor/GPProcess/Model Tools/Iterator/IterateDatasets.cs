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
	/// <para>Iterate Datasets</para>
	/// <para>迭代数据集</para>
	/// <para>迭代工作空间中不同类型的数据集。</para>
	/// </summary>
	public class IterateDatasets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace or Feature Dataset</para>
		/// <para>存储要迭代的数据集的工作空间或要素数据集。</para>
		/// </param>
		public IterateDatasets(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代数据集</para>
		/// </summary>
		public override string DisplayName() => "迭代数据集";

		/// <summary>
		/// <para>Tool Name : IterateDatasets</para>
		/// </summary>
		public override string ToolName() => "IterateDatasets";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateDatasets</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateDatasets";

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
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard!, DatasetType!, Recursive!, Dataset!, Name! };

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>存储要迭代的数据集的工作空间或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。 星号相当于指定全部。 如果未指定通配符，将返回所有输入。 例如，可将其用于将输入名称迭代限制为从某一字符或词语开始（例如，A*、Ari* 或 Land* 等）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Wildcard { get; set; }

		/// <summary>
		/// <para>Dataset Type</para>
		/// <para>要迭代的数据集类型。</para>
		/// <para>计算机辅助设计 (CAD)—输出将为 CAD 数据集。</para>
		/// <para>要素—输出将为要素数据集。</para>
		/// <para>几何网络—输出将为几何网络数据集。</para>
		/// <para>镶嵌—输出将为镶嵌数据集。</para>
		/// <para>网络—输出将为网络数据集。</para>
		/// <para>ArcMap 的宗地结构—输出将为 ArcMap 宗地结构数据集。</para>
		/// <para>宗地结构—输出将为宗地结构数据集。</para>
		/// <para>栅格—输出将为栅格数据集。</para>
		/// <para>地形—输出将为 terrain 数据集。</para>
		/// <para>不规则三角网 (TIN)—输出将为 TIN 数据集。</para>
		/// <para>拓扑—输出将为拓扑数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DatasetType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>指定是否将递归迭代输入工作空间中的子文件夹。</para>
		/// <para>选中 - 将递归迭代子文件夹。</para>
		/// <para>未选中 - 将不会递归迭代子文件夹。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object? Dataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? Name { get; set; }

		#region InnerClass

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
