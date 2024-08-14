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
	/// <para>Unregister As Versioned</para>
	/// <para>Unregisters an enterprise geodatabase dataset as versioned.</para>
	/// </summary>
	public class UnregisterAsVersioned : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The name of the dataset to be unregistered as versioned.</para>
		/// </param>
		public UnregisterAsVersioned(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Unregister As Versioned</para>
		/// </summary>
		public override string DisplayName => "Unregister As Versioned";

		/// <summary>
		/// <para>Tool Name : UnregisterAsVersioned</para>
		/// </summary>
		public override string ToolName => "UnregisterAsVersioned";

		/// <summary>
		/// <para>Tool Excute Name : management.UnregisterAsVersioned</para>
		/// </summary>
		public override string ExcuteName => "management.UnregisterAsVersioned";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, KeepEdit, CompressDefault, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The name of the dataset to be unregistered as versioned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Do not run if there are versions with edits</para>
		/// <para>Specifies whether edits made to the versioned data will be maintained.</para>
		/// <para>Checked—If there are existing edits in the delta tables, the tool will fail with an error message. Do not use this option if you intend to compress your edits from the Default version in the Compress all edits in the Default version into the base table parameter. This is the default.</para>
		/// <para>Unchecked—If there are existing edits in the delta tables, the tool will allow deletion of these edits. Use this option if you intend to compress your edits from the Default version in the Compress all edits in the Default version into the base table parameter.</para>
		/// <para><see cref="KeepEditEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object KeepEdit { get; set; } = "true";

		/// <summary>
		/// <para>Compress all edits in the Default version into the base table</para>
		/// <para>Specifies whether edits will be compressed and unused data will be removed. This option is ignored if the Do not run if there are versions with edits parameter is checked.</para>
		/// <para>Checked—Edits in the Default version will be compressed to the base table.</para>
		/// <para>Unchecked—Any edits remaining in the delta tables will not be compressed. This is the default.</para>
		/// <para><see cref="CompressDefaultEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompressDefault { get; set; } = "false";

		/// <summary>
		/// <para>Unregistered Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UnregisterAsVersioned SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Do not run if there are versions with edits</para>
		/// </summary>
		public enum KeepEditEnum 
		{
			/// <summary>
			/// <para>Checked—If there are existing edits in the delta tables, the tool will fail with an error message. Do not use this option if you intend to compress your edits from the Default version in the Compress all edits in the Default version into the base table parameter. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_EDIT")]
			KEEP_EDIT,

			/// <summary>
			/// <para>Unchecked—If there are existing edits in the delta tables, the tool will allow deletion of these edits. Use this option if you intend to compress your edits from the Default version in the Compress all edits in the Default version into the base table parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP_EDIT")]
			NO_KEEP_EDIT,

		}

		/// <summary>
		/// <para>Compress all edits in the Default version into the base table</para>
		/// </summary>
		public enum CompressDefaultEnum 
		{
			/// <summary>
			/// <para>Checked—Edits in the Default version will be compressed to the base table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPRESS_DEFAULT")]
			COMPRESS_DEFAULT,

			/// <summary>
			/// <para>Unchecked—Any edits remaining in the delta tables will not be compressed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPRESS_DEFAULT")]
			NO_COMPRESS_DEFAULT,

		}

#endregion
	}
}
