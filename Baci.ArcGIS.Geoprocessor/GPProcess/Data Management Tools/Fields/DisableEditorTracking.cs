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
	/// <para>Disable Editor Tracking</para>
	/// <para>禁用编辑者追踪</para>
	/// <para>用于对要素类、表、要素数据集或镶嵌数据集禁用编辑者追踪。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisableEditorTracking : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>将禁用编辑者追踪的要素类、表、要素数据集或镶嵌数据集。</para>
		/// </param>
		public DisableEditorTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用编辑者追踪</para>
		/// </summary>
		public override string DisplayName() => "禁用编辑者追踪";

		/// <summary>
		/// <para>Tool Name : DisableEditorTracking</para>
		/// </summary>
		public override string ToolName() => "DisableEditorTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableEditorTracking</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableEditorTracking";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, Creator!, CreationDate!, LastEditor!, LastEditDate!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>将禁用编辑者追踪的要素类、表、要素数据集或镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Disable Creator Tracking</para>
		/// <para>指定是否禁用创建者字段的编辑者追踪。</para>
		/// <para>选中 - 禁用创建者字段的编辑者追踪。这是默认设置。</para>
		/// <para>未选中 - 不禁用创建者字段的编辑者追踪。</para>
		/// <para><see cref="CreatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Creator { get; set; } = "true";

		/// <summary>
		/// <para>Disable Creation Date Tracking</para>
		/// <para>指定是否禁用创建日期字段的编辑者追踪。</para>
		/// <para>选中 - 禁用创建日期字段的编辑者追踪。这是默认设置。</para>
		/// <para>未选中 - 不禁用创建日期字段的编辑者追踪。</para>
		/// <para><see cref="CreationDateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreationDate { get; set; } = "true";

		/// <summary>
		/// <para>Disable Last Editor Tracking</para>
		/// <para>指定是否禁用上一个编辑者字段的编辑者追踪。</para>
		/// <para>选中 - 禁用上一个编辑者字段的编辑者追踪。这是默认设置。</para>
		/// <para>未选中 - 不禁用上一个编辑者字段的编辑者追踪。</para>
		/// <para><see cref="LastEditorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? LastEditor { get; set; } = "true";

		/// <summary>
		/// <para>Disable Last Edit Date Tracking</para>
		/// <para>指定是否禁用最后一次编辑日期字段的编辑者追踪。</para>
		/// <para>选中 - 禁用最后一次编辑日期字段的编辑者追踪。这是默认设置。</para>
		/// <para>未选中 - 不禁用最后一次编辑日期字段的编辑者追踪。</para>
		/// <para><see cref="LastEditDateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? LastEditDate { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object? OutDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Disable Creator Tracking</para>
		/// </summary>
		public enum CreatorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_CREATOR")]
			DISABLE_CREATOR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISABLE_CREATOR")]
			NO_DISABLE_CREATOR,

		}

		/// <summary>
		/// <para>Disable Creation Date Tracking</para>
		/// </summary>
		public enum CreationDateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_CREATION_DATE")]
			DISABLE_CREATION_DATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISABLE_CREATION_DATE")]
			NO_DISABLE_CREATION_DATE,

		}

		/// <summary>
		/// <para>Disable Last Editor Tracking</para>
		/// </summary>
		public enum LastEditorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_LAST_EDITOR")]
			DISABLE_LAST_EDITOR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISABLE_LAST_EDITOR")]
			NO_DISABLE_LAST_EDITOR,

		}

		/// <summary>
		/// <para>Disable Last Edit Date Tracking</para>
		/// </summary>
		public enum LastEditDateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_LAST_EDIT_DATE")]
			DISABLE_LAST_EDIT_DATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISABLE_LAST_EDIT_DATE")]
			NO_DISABLE_LAST_EDIT_DATE,

		}

#endregion
	}
}
