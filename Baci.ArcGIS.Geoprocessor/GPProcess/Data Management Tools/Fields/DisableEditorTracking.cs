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
	/// <para>Disables editor tracking on a feature class, table, feature dataset, or mosaic dataset.</para>
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
		/// <para>The feature class, table, feature dataset, or mosaic dataset in which editor tracking will be disabled.</para>
		/// </param>
		public DisableEditorTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable Editor Tracking</para>
		/// </summary>
		public override string DisplayName => "Disable Editor Tracking";

		/// <summary>
		/// <para>Tool Name : DisableEditorTracking</para>
		/// </summary>
		public override string ToolName => "DisableEditorTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableEditorTracking</para>
		/// </summary>
		public override string ExcuteName => "management.DisableEditorTracking";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, Creator!, CreationDate!, LastEditor!, LastEditDate!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The feature class, table, feature dataset, or mosaic dataset in which editor tracking will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Disable Creator Tracking</para>
		/// <para>Specifies whether editor tracking for the creator field will be disabled.</para>
		/// <para>Checked—Editor tracking for the creator field will be disabled. This is the default.</para>
		/// <para>Unchecked—Editor tracking for the creator field will not be disabled.</para>
		/// <para><see cref="CreatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Creator { get; set; } = "true";

		/// <summary>
		/// <para>Disable Creation Date Tracking</para>
		/// <para>Specifies whether editor tracking for the creation date field will be disabled.</para>
		/// <para>Checked—Editor tracking for the creation date field will be disabled. This is the default.</para>
		/// <para>Unchecked—Editor tracking for the creation date field will not be disabled.</para>
		/// <para><see cref="CreationDateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreationDate { get; set; } = "true";

		/// <summary>
		/// <para>Disable Last Editor Tracking</para>
		/// <para>Specifies whether editor tracking for the last editor field will be disabled.</para>
		/// <para>Checked—Editor tracking for the last editor field will be disabled. This is the default.</para>
		/// <para>Unchecked—Editor tracking for the last editor field will not be disabled.</para>
		/// <para><see cref="LastEditorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? LastEditor { get; set; } = "true";

		/// <summary>
		/// <para>Disable Last Edit Date Tracking</para>
		/// <para>Specifies whether editor tracking for the last edit date field will be disabled.</para>
		/// <para>Checked—Editor tracking for the last edit date field will be disabled. This is the default.</para>
		/// <para>Unchecked—Editor tracking for the last edit date field will not be disabled.</para>
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
			/// <para>Checked—Editor tracking for the creator field will be disabled. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_CREATOR")]
			DISABLE_CREATOR,

			/// <summary>
			/// <para>Unchecked—Editor tracking for the creator field will not be disabled.</para>
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
			/// <para>Checked—Editor tracking for the creation date field will be disabled. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_CREATION_DATE")]
			DISABLE_CREATION_DATE,

			/// <summary>
			/// <para>Unchecked—Editor tracking for the creation date field will not be disabled.</para>
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
			/// <para>Checked—Editor tracking for the last editor field will be disabled. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_LAST_EDITOR")]
			DISABLE_LAST_EDITOR,

			/// <summary>
			/// <para>Unchecked—Editor tracking for the last editor field will not be disabled.</para>
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
			/// <para>Checked—Editor tracking for the last edit date field will be disabled. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE_LAST_EDIT_DATE")]
			DISABLE_LAST_EDIT_DATE,

			/// <summary>
			/// <para>Unchecked—Editor tracking for the last edit date field will not be disabled.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISABLE_LAST_EDIT_DATE")]
			NO_DISABLE_LAST_EDIT_DATE,

		}

#endregion
	}
}
