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
	/// <para>Package Project</para>
	/// <para>打包工程</para>
	/// <para>将引用地图和数据的工程文件 (.aprx) 合并并打包到已打包的工程文件 (.ppkx) 中。</para>
	/// </summary>
	public class PackageProject : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProject">
		/// <para>Input Project</para>
		/// <para>要打包的工程（.aprx 文件）。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出工程包（.ppkx 文件）。</para>
		/// </param>
		public PackageProject(object InProject, object OutputFile)
		{
			this.InProject = InProject;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 打包工程</para>
		/// </summary>
		public override string DisplayName() => "打包工程";

		/// <summary>
		/// <para>Tool Name : PackageProject</para>
		/// </summary>
		public override string ToolName() => "PackageProject";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageProject</para>
		/// </summary>
		public override string ExcuteName() => "management.PackageProject";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InProject, OutputFile, SharingInternal!, PackageAsTemplate!, Extent!, ApplyExtentToArcsde!, AdditionalFiles!, Summary!, Tags!, Version!, IncludeToolboxes!, IncludeHistoryItems!, ReadOnly!, SelectRelatedRows!, PreserveSqlite! };

		/// <summary>
		/// <para>Input Project</para>
		/// <para>要打包的工程（.aprx 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("aprx")]
		public object InProject { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出工程包（.ppkx 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ppkx", "aptx")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Share outside of organization</para>
		/// <para>指定是针对内部环境合并工程，还是移动所有数据元素以便在外部共享工程。如果工程通过本地路径（例如 c:\gisdata\landrecords.gdb\）引用数据和地图，则将对这些数据和地图进行合并和打包（不考虑该参数设置）。</para>
		/// <para>未选中 - 企业数据源（例如企业级地理数据库和 UNC 路径中的数据）将不会复制到本地文件夹。 这是默认设置。</para>
		/// <para>选中 - 将复制和保留数据格式（如有可能）。</para>
		/// <para><see cref="SharingInternalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SharingInternal { get; set; } = "false";

		/// <summary>
		/// <para>Package as template</para>
		/// <para>指定将创建工程模板还是工程包。 工程模板可以包含地图、布局、数据库和服务器的连接等。 使用工程模板，可以标准化不同工程的一系列地图并可确保正确的图层可供所有人直接用于他们的地图中。</para>
		/// <para>未选中 - 将创建工程包。 这是默认设置。</para>
		/// <para>选中 - 将创建工程模板。</para>
		/// <para><see cref="PackageAsTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PackageAsTemplate { get; set; } = "false";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定用于选择或裁剪要素的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// <para>指定是将指定范围应用到所有图层，还是仅应用到企业级地理数据库图层。</para>
		/// <para>未选中 - 范围将应用到所有图层。 这是默认设置。</para>
		/// <para>选中 - 范围将仅应用到企业级地理数据库图层。</para>
		/// <para><see cref="ApplyExtentToArcsdeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ApplyExtentToArcsde { get; set; } = "false";

		/// <summary>
		/// <para>Additional Files</para>
		/// <para>将文件添加到包中。 诸如 .doc、.txt、.pdf 等附加文件可用于提供有关打包内容和目的的详细信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? AdditionalFiles { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将摘要信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到包的属性中。 可以添加多个标签，用逗号或分号分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Package version</para>
		/// <para>指定将在结果包中创建的地理数据库版本。 指定版本可实现与较早版本的 ArcGIS 共享包，并可支持向后兼容。保存为较早版本的包可能会丢失仅适用于较新版本的属性。</para>
		/// <para>所有版本—包中将包含与所有版本（ArcGIS Pro 2.1 和更高版本）均兼容的地理数据库和地图。</para>
		/// <para>当前版本—包中包含与当前版本兼容的地理数据库和地图。</para>
		/// <para>2.2—包中将包含与版本 2.2 兼容的地理数据库和地图。</para>
		/// <para>2.3—包中将包含与版本 2.3 兼容的地理数据库和地图。</para>
		/// <para>2.4—包中将包含与版本 2.4 兼容的地理数据库和地图。</para>
		/// <para>2.5—包中将包含与版本 2.5 兼容的地理数据库和地图。</para>
		/// <para>2.6—包中将包含与版本 2.6 兼容的地理数据库和地图。</para>
		/// <para>2.7—包中将包含与版本 2.7 兼容的地理数据库和地图。</para>
		/// <para>2.8—包中将包含与版本 2.8 兼容的地理数据库和地图。</para>
		/// <para>2.9—此包中将包含与版本 2.9 兼容的地理数据库和地图。</para>
		/// <para>3.0—此包中将包含与版本 3.0 兼容的地理数据库和地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Version { get; set; } = "ALL";

		/// <summary>
		/// <para>Include Toolboxes</para>
		/// <para>指定是否合并工程工具箱以及工程工具箱中的工具所引用的数据并将其包括在输出包中。 所有工程都需要默认工具箱，因此无论如何设置，默认工具箱都将包括在内。 连接文件夹中的工具箱不会被视为工程工具箱，且不受此设置的影响。</para>
		/// <para>已选中 - 工程工具箱将包括在输出包中。 这是默认设置。</para>
		/// <para>未选中 - 工程工具箱不会包括在输出包中。</para>
		/// <para><see cref="IncludeToolboxesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeToolboxes { get; set; } = "true";

		/// <summary>
		/// <para>Include History Items</para>
		/// <para>指定是否合并地理处理历史项目并将其包括在输出包中。 包括的历史项目将合并重新处理历史项目所需的数据。</para>
		/// <para>将包括历史项目—历史项目将包括在输出包中。 这是默认设置。</para>
		/// <para>不会包括历史项目—历史项目不会包括在输出包中。</para>
		/// <para>将仅包括有效的历史项目—输出包中将仅包括有效的历史项目。 如果找不到任何原始输入图层或工具，则历史项目无效。</para>
		/// <para><see cref="IncludeHistoryItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IncludeHistoryItems { get; set; } = "HISTORY_ITEMS";

		/// <summary>
		/// <para>Read Only Package</para>
		/// <para>指定工程是否为只读状态。 无法修改或保存只读工程。</para>
		/// <para>选中 - 工程将为只读状态。</para>
		/// <para>未选中 - 工程将为可写状态。 这是默认设置。</para>
		/// <para><see cref="ReadOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReadOnly { get; set; } = "false";

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>指定是否将指定的范围应用至相关数据源。</para>
		/// <para>未选中 - 相关的数据源将全部合并。 这是默认设置。</para>
		/// <para>选中 - 仅合并指定范围内与记录对应的相关数据。</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SelectRelatedRows { get; set; } = "false";

		/// <summary>
		/// <para>Preserve Mobile Geodatabase</para>
		/// <para>指定输入移动地理数据库数据是保留在输出中还是写入文件地理数据库格式。 当输入数据为移动地理数据库时，此参数将覆盖将数据转换为文件地理数据库参数。 如果输入数据是移动地理数据库网络数据集，则输出将始终为移动地理数据库。</para>
		/// <para>未选中 - 移动地理数据库数据将被转换为文件地理数据库格式。 这是默认设置。</para>
		/// <para>选中 - 移动地理数据库数据将作为移动地理数据库保留在工程包中。</para>
		/// <para><see cref="PreserveSqliteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PreserveSqlite { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PackageProject SetEnviroment(object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share outside of organization</para>
		/// </summary>
		public enum SharingInternalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTERNAL")]
			EXTERNAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERNAL")]
			INTERNAL,

		}

		/// <summary>
		/// <para>Package as template</para>
		/// </summary>
		public enum PackageAsTemplateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_TEMPLATE")]
			PROJECT_TEMPLATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PROJECT_PACKAGE")]
			PROJECT_PACKAGE,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToArcsdeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENTERPRISE_ONLY")]
			ENTERPRISE_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Include Toolboxes</para>
		/// </summary>
		public enum IncludeToolboxesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TOOLBOXES")]
			TOOLBOXES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TOOLBOXES")]
			NO_TOOLBOXES,

		}

		/// <summary>
		/// <para>Include History Items</para>
		/// </summary>
		public enum IncludeHistoryItemsEnum 
		{
			/// <summary>
			/// <para>将包括历史项目—历史项目将包括在输出包中。 这是默认设置。</para>
			/// </summary>
			[GPValue("HISTORY_ITEMS")]
			[Description("将包括历史项目")]
			History_items_will_be_included,

			/// <summary>
			/// <para>不会包括历史项目—历史项目不会包括在输出包中。</para>
			/// </summary>
			[GPValue("NO_HISTORY_ITEMS")]
			[Description("不会包括历史项目")]
			History_items_will_not_be_included,

			/// <summary>
			/// <para>将仅包括有效的历史项目—输出包中将仅包括有效的历史项目。 如果找不到任何原始输入图层或工具，则历史项目无效。</para>
			/// </summary>
			[GPValue("VALID_HISTORY_ITEMS_ONLY")]
			[Description("将仅包括有效的历史项目")]
			Only_valid_history_items_will_be_included,

		}

		/// <summary>
		/// <para>Read Only Package</para>
		/// </summary>
		public enum ReadOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("READ_ONLY")]
			READ_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("READ_WRITE")]
			READ_WRITE,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

		/// <summary>
		/// <para>Preserve Mobile Geodatabase</para>
		/// </summary>
		public enum PreserveSqliteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SQLITE")]
			PRESERVE_SQLITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_SQLITE")]
			CONVERT_SQLITE,

		}

#endregion
	}
}
