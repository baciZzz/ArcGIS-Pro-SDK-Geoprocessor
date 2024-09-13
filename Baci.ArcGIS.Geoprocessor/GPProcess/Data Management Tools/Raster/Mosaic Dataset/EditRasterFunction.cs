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
	/// <para>Edit Raster Function</para>
	/// <para>编辑栅格函数</para>
	/// <para>在镶嵌数据集或包含栅格函数的栅格图层中添加、替换或移除函数链。</para>
	/// </summary>
	public class EditRasterFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Raster</para>
		/// <para>镶嵌数据集或栅格图层。如果使用栅格图层，则其必须应用函数。</para>
		/// </param>
		public EditRasterFunction(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 编辑栅格函数</para>
		/// </summary>
		public override string DisplayName() => "编辑栅格函数";

		/// <summary>
		/// <para>Tool Name : EditRasterFunction</para>
		/// </summary>
		public override string ToolName() => "EditRasterFunction";

		/// <summary>
		/// <para>Tool Excute Name : management.EditRasterFunction</para>
		/// </summary>
		public override string ExcuteName() => "management.EditRasterFunction";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, EditMosaicDatasetItem, EditOptions, FunctionChainDefinition, LocationFunctionName, OutRaster };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>镶嵌数据集或栅格图层。如果使用栅格图层，则其必须应用函数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset Items</para>
		/// <para>将函数链逐个应用到镶嵌数据集中的每个项目或应用到整个镶嵌数据集。</para>
		/// <para>未选中 - 编辑将影响与镶嵌数据集相关联的函数。这是默认设置。</para>
		/// <para>选中 - 编辑将影响与镶嵌数据集内所有项目相关联的函数。</para>
		/// <para><see cref="EditMosaicDatasetItemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EditMosaicDatasetItem { get; set; } = "false";

		/// <summary>
		/// <para>Edit Options</para>
		/// <para>插入、替换或移除函数链。</para>
		/// <para>插入—在现有链的函数名称上方插入函数链。在函数名称参数下指定函数链。这是默认设置。</para>
		/// <para>替换—使用该工具中指定的函数链替换现有函数链。在函数名称参数下指定函数链。</para>
		/// <para>移除— 移除从 函数名称 参数中指定函数开始的函数链。</para>
		/// <para><see cref="EditOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EditOptions { get; set; } = "INSERT";

		/// <summary>
		/// <para>Raster Function Template</para>
		/// <para>选择想要插入或替换的函数链（rft.xml 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rft.xml", "rft.json", "rft", "xml", "json")]
		public object FunctionChainDefinition { get; set; }

		/// <summary>
		/// <para>Function Name</para>
		/// <para>选择要在现有函数链中插入、替换或移除函数链的位置。</para>
		/// <para>如果插入函数，则将在函数名称参数中指定的函数上方进行插入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object LocationFunctionName { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EditRasterFunction SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mosaic Dataset Items</para>
		/// </summary>
		public enum EditMosaicDatasetItemEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EDIT_MOSAIC_DATASET_ITEM")]
			EDIT_MOSAIC_DATASET_ITEM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EDIT_MOSAIC_DATASET")]
			EDIT_MOSAIC_DATASET,

		}

		/// <summary>
		/// <para>Edit Options</para>
		/// </summary>
		public enum EditOptionsEnum 
		{
			/// <summary>
			/// <para>插入、替换或移除函数链。</para>
			/// </summary>
			[GPValue("INSERT")]
			[Description("插入")]
			Insert,

			/// <summary>
			/// <para>替换—使用该工具中指定的函数链替换现有函数链。在函数名称参数下指定函数链。</para>
			/// </summary>
			[GPValue("REPLACE")]
			[Description("替换")]
			Replace,

			/// <summary>
			/// <para>移除— 移除从 函数名称 参数中指定函数开始的函数链。</para>
			/// </summary>
			[GPValue("REMOVE")]
			[Description("移除")]
			Remove,

		}

#endregion
	}
}
