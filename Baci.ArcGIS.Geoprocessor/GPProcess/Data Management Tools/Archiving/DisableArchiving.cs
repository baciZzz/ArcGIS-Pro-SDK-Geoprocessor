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
	/// <para>Disable Archiving</para>
	/// <para>Disable Archiving</para>
	/// <para>Disables archiving on a geodatabase feature class, table, or feature dataset.</para>
	/// </summary>
	public class DisableArchiving : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The geodatabase feature class, table, or feature dataset for which archiving will be disabled.</para>
		/// </param>
		public DisableArchiving(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable Archiving</para>
		/// </summary>
		public override string DisplayName() => "Disable Archiving";

		/// <summary>
		/// <para>Tool Name : DisableArchiving</para>
		/// </summary>
		public override string ToolName() => "DisableArchiving";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableArchiving</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableArchiving";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, PreserveHistory, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The geodatabase feature class, table, or feature dataset for which archiving will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Preserve History Table</para>
		/// <para>Specifies whether records that are not from the current moment will be preserved. If the table or feature class is versioned, the history table will become available. For nonversioned data, a table or feature class will be created with an appended _h that contains the history information.</para>
		/// <para>Checked—Records that are not from the current moment will be preserved. This is the default.</para>
		/// <para>Unchecked—Records that are not from the current moment will not be preserved; they will be deleted.</para>
		/// <para><see cref="PreserveHistoryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveHistory { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DisableArchiving SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve History Table</para>
		/// </summary>
		public enum PreserveHistoryEnum 
		{
			/// <summary>
			/// <para>Checked—Records that are not from the current moment will be preserved. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE")]
			PRESERVE,

			/// <summary>
			/// <para>Unchecked—Records that are not from the current moment will not be preserved; they will be deleted.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DELETE")]
			DELETE,

		}

#endregion
	}
}
