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
	/// <para>Add Files To LAS Dataset</para>
	/// <para>将文件添加到 LAS 数据集</para>
	/// <para>将一个或多个 LAS 文件和表面约束要素的引用添加到 LAS 数据集。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFilesToLasDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		public AddFilesToLasDataset(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 将文件添加到 LAS 数据集</para>
		/// </summary>
		public override string DisplayName() => "将文件添加到 LAS 数据集";

		/// <summary>
		/// <para>Tool Name : AddFilesToLasDataset</para>
		/// </summary>
		public override string ToolName() => "AddFilesToLasDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFilesToLasDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFilesToLasDataset";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFiles!, FolderRecursion!, InSurfaceConstraints!, DerivedLasDataset! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>LAS Files or Folders</para>
		/// <para>输入文件可引用包含 LAS 数据的各个 LAS 文件和文件夹的任意组合。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object? InFiles { get; set; }

		/// <summary>
		/// <para>Include subfolders</para>
		/// <para>指定 LAS 数据集是否引用位于输入文件夹子目录中的 .las 文件。</para>
		/// <para>未选中 - 仅位于输入文件夹中的 .las 文件会添加到 LAS 数据集。 这是默认设置。</para>
		/// <para>选中 - 位于输入文件夹子目录中的所有 .las 文件都将被添加到 LAS 数据集。</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>将构成由 LAS 数据集生成的三角化网格面定义的要素。</para>
		/// <para>输入要素 - 其几何将整合到 LAS 数据集的三角化网格面的要素。</para>
		/// <para>高度字段 - 通过选择 Shape.Z，可以从要素属性表或几何中的任何数值字段获取要素的高程源。 如果无需高度，则指定关键字 &lt;None&gt; 来创建 z-less 要素，其高程由表面内插得到。</para>
		/// <para>类型 - 定义由 LAS 数据集生成的三角化网格面中的要素角色。 具有硬或软标识的选项表示要素边是否表示坡度的明显中断或平缓变化。</para>
		/// <para>表面要素类型 - 定义如何将要素几何加入到表面的三角网中的表面要素类型。 具有硬或软标识的选项表示要素边是否表示坡度的明显中断或平缓变化。</para>
		/// <para>锚点 - 不会被细化掉的高程点。 此选项仅可用于单点要素几何。</para>
		/// <para>硬断线或软断线 - 强制高度值的隔断线。</para>
		/// <para>硬裁剪或软裁剪 - 定义 LAS 数据集边界的面数据集。</para>
		/// <para>硬擦除或软擦除 - 定义 LAS 数据集中的孔的面数据集。</para>
		/// <para>硬替换或软替换 - 定义高度恒定的区域的面数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? InSurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFilesToLasDataset SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include subfolders</para>
		/// </summary>
		public enum FolderRecursionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSION")]
			RECURSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECURSION")]
			NO_RECURSION,

		}

#endregion
	}
}
