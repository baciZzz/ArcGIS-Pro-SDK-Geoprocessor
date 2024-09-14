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
	/// <para>迭代工作空间或要素数据集中的所有数据集。</para>
	/// </summary>
	public class IterateDatasets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Workspace or Feature Dataset</para>
		/// <para>要迭代的数据集所在的工作空间或要素数据集。</para>
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
		public override object[] Parameters() => new object[] { InWorkspace, Wildcard, DatasetType, Recursive, Dataset, Name };

		/// <summary>
		/// <para>Workspace or Feature Dataset</para>
		/// <para>要迭代的数据集所在的工作空间或要素数据集。</para>
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
		/// <para>Dataset Type</para>
		/// <para>要迭代的数据集类型。</para>
		/// <para>计算机辅助设计 (CAD)—将仅输出 CAD 数据集。</para>
		/// <para>要素—将仅输出要素数据集。</para>
		/// <para>几何网络—将仅输出几何网络数据集。</para>
		/// <para>镶嵌—将仅输出镶嵌数据集。</para>
		/// <para>网络—将仅输出网络数据集。</para>
		/// <para>宗地结构—将仅输出宗地结构数据集。</para>
		/// <para>栅格—将仅输出栅格数据集。</para>
		/// <para>Terrain—将仅输出 Terrain 数据集。</para>
		/// <para>不规则三角网 (TIN)—将仅输出 TIN 数据集。</para>
		/// <para>拓扑—将仅输出拓扑数据集。</para>
		/// <para><see cref="DatasetTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DatasetType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>确定是否递归迭代输入工作空间中的子文件夹。</para>
		/// <para>选中 - 将递归迭代所有子文件夹。</para>
		/// <para>未选中 - 将不会递归迭代所有子文件。</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object Dataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Dataset Type</para>
		/// </summary>
		public enum DatasetTypeEnum 
		{
			/// <summary>
			/// <para>计算机辅助设计 (CAD)—将仅输出 CAD 数据集。</para>
			/// </summary>
			[GPValue("CAD")]
			[Description("计算机辅助设计 (CAD)")]
			CAD,

			/// <summary>
			/// <para>要素—将仅输出要素数据集。</para>
			/// </summary>
			[GPValue("FEATURE")]
			[Description("要素")]
			Feature,

			/// <summary>
			/// <para>几何网络—将仅输出几何网络数据集。</para>
			/// </summary>
			[GPValue("GEOMETRICNETWORK")]
			[Description("几何网络")]
			Geometric_Network,

			/// <summary>
			/// <para>镶嵌—将仅输出镶嵌数据集。</para>
			/// </summary>
			[GPValue("MOSAIC")]
			[Description("镶嵌")]
			Mosaic,

			/// <summary>
			/// <para>网络—将仅输出网络数据集。</para>
			/// </summary>
			[GPValue("NETWORK")]
			[Description("网络")]
			Network,

			/// <summary>
			/// <para>宗地结构—将仅输出宗地结构数据集。</para>
			/// </summary>
			[GPValue("PARCELFABRIC")]
			[Description("宗地结构")]
			Parcel_Fabric,

			/// <summary>
			/// <para>栅格—将仅输出栅格数据集。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格")]
			Raster,

			/// <summary>
			/// <para>Terrain—将仅输出 Terrain 数据集。</para>
			/// </summary>
			[GPValue("TERRAIN")]
			[Description("Terrain")]
			Terrain,

			/// <summary>
			/// <para>不规则三角网 (TIN)—将仅输出 TIN 数据集。</para>
			/// </summary>
			[GPValue("TIN")]
			[Description("不规则三角网 (TIN)")]
			TIN,

			/// <summary>
			/// <para>拓扑—将仅输出拓扑数据集。</para>
			/// </summary>
			[GPValue("TOPOLOGY")]
			[Description("拓扑")]
			Topology,

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
