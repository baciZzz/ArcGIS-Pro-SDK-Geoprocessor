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
	/// <para>Create LAS Dataset</para>
	/// <para>创建 LAS 数据集</para>
	/// <para>创建引用一个或多个 .las 文件和可选表面约束要素的 LAS 数据集。</para>
	/// </summary>
	public class CreateLasDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input Files</para>
		/// <para>.las 文件和包含将被 LAS 数据集引用的 .las 文件的文件夹。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </param>
		/// <param name="OutLasDataset">
		/// <para>Output LAS Dataset</para>
		/// <para>将创建的 LAS 数据集。</para>
		/// </param>
		public CreateLasDataset(object Input, object OutLasDataset)
		{
			this.Input = Input;
			this.OutLasDataset = OutLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 LAS 数据集</para>
		/// </summary>
		public override string DisplayName() => "创建 LAS 数据集";

		/// <summary>
		/// <para>Tool Name : CreateLasDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLasDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateLasDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateLasDataset";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, OutLasDataset, FolderRecursion!, InSurfaceConstraints!, SpatialReference!, ComputeStats!, RelativePaths!, CreateLasPrj!, Extent!, Boundary!, AddOnlyContainedFiles! };

		/// <summary>
		/// <para>Input Files</para>
		/// <para>.las 文件和包含将被 LAS 数据集引用的 .las 文件的文件夹。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>将创建的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

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
		/// <para>Coordinate System</para>
		/// <para>LAS 数据集的空间参考。 如果没有明确指定空间参考，则 LAS 数据集将使用第一个输入 .las 文件的坐标系。 如果输入文件不包含任何空间参考信息且未设置坐标系，则 LAS 数据集的坐标系将列为未知。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>指定是否计算 .las 文件的统计数据以及是否为 LAS 数据集生成空间索引。 统计数据的存在允许 LAS 数据集图层使用过滤和符号系统选项，以便仅显示 .las 文件中存在的 LAS 属性值。 将为每个 .las 文件创建 .lasx 辅助文件。</para>
		/// <para>未选中 - 不计算统计数据。 这是默认设置。</para>
		/// <para>选中 - 将计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Store Relative Paths</para>
		/// <para>指定 LAS 数据集是通过相对路径还是绝对路径来引用激光雷达文件和表面约束要素。 在文件系统中使用同一相对位置将 LAS 数据集及其关联的数据重新定位到其他位置时，使用相对路径会比较方便。</para>
		/// <para>未选中 - LAS 数据集引用数据时使用绝对路径。 这是默认设置。</para>
		/// <para>选中 - LAS 数据集引用数据时使用相对路径。</para>
		/// <para><see cref="RelativePathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RelativePaths { get; set; } = "false";

		/// <summary>
		/// <para>Create PRJ For LAS Files</para>
		/// <para>指定是否会为 LAS 数据集引用的 .las 文件创建 .prj 文件。</para>
		/// <para>无 LAS 文件—不会创建 .prj 文件。 这是默认设置。</para>
		/// <para>缺失空间参考的文件—将为没有空间参考的 .las 文件创建对应的 .prj 文件。</para>
		/// <para>所有 LAS 文件—将为所有 .las 文件创建对应的 .prj 文件。</para>
		/// <para><see cref="CreateLasPrjEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CreateLasPrj { get; set; } = "NO_FILES";

		/// <summary>
		/// <para>Processing Extent</para>
		/// <para>处理范围将用于从输入文件参数值中的文件和文件夹列表中选择 .las 文件的子集。 完全位于此范围之外的任何 .las 文件都将从生成的 LAS 数据集中排除。 此外，如果选中了仅添加完全包含的文件参数，则部分位于范围之外的 .las 文件将被排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Processing Extent")]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>这一面要素的边界将用于从输入文件参数中的文件和文件夹列表中选择 .las 文件的子集。 完全位于面之外的任何 .las 文件都将从生成的 LAS 数据集中排除。 此外，如果选中了仅添加完全包含的文件参数，则部分位于面之外的 .las 文件将被排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object? Boundary { get; set; }

		/// <summary>
		/// <para>Add only entirely contained files</para>
		/// <para>指定将添加到 LAS 数据集的 .las 文件是否必须完全或部分包含在处理范围、处理边界面或两者的交集中。</para>
		/// <para>未选中 - 与处理范围、处理边界或两者的交集相交所有文件都将添加到 LAS 数据集中。 这是默认设置。</para>
		/// <para>选中 - 仅完全包含在处理范围、处理边界或两者的交集中的文件才会添加到 LAS 数据集。</para>
		/// <para><see cref="AddOnlyContainedFilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Processing Extent")]
		public object? AddOnlyContainedFiles { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLasDataset SetEnviroment(object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
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

		/// <summary>
		/// <para>Compute Statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Store Relative Paths</para>
		/// </summary>
		public enum RelativePathsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATIVE_PATHS")]
			RELATIVE_PATHS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE_PATHS")]
			ABSOLUTE_PATHS,

		}

		/// <summary>
		/// <para>Create PRJ For LAS Files</para>
		/// </summary>
		public enum CreateLasPrjEnum 
		{
			/// <summary>
			/// <para>无 LAS 文件—不会创建 .prj 文件。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_FILES")]
			[Description("无 LAS 文件")]
			No_LAS_Files,

			/// <summary>
			/// <para>缺失空间参考的文件—将为没有空间参考的 .las 文件创建对应的 .prj 文件。</para>
			/// </summary>
			[GPValue("FILES_MISSING_PROJECTION")]
			[Description("缺失空间参考的文件")]
			Files_with_Missing_Spatial_References,

			/// <summary>
			/// <para>所有 LAS 文件—将为所有 .las 文件创建对应的 .prj 文件。</para>
			/// </summary>
			[GPValue("ALL_FILES")]
			[Description("所有 LAS 文件")]
			All_LAS_Files,

		}

		/// <summary>
		/// <para>Add only entirely contained files</para>
		/// </summary>
		public enum AddOnlyContainedFilesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTAINED_FILES")]
			CONTAINED_FILES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERSECTED_FILES")]
			INTERSECTED_FILES,

		}

#endregion
	}
}
