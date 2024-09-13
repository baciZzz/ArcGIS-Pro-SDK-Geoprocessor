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
	/// <para>取消注册版本</para>
	/// <para>将企业级地理数据库数据集取消注册版本。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UnregisterAsVersioned : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要取消注册版本的数据集的名称。</para>
		/// </param>
		public UnregisterAsVersioned(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 取消注册版本</para>
		/// </summary>
		public override string DisplayName() => "取消注册版本";

		/// <summary>
		/// <para>Tool Name : UnregisterAsVersioned</para>
		/// </summary>
		public override string ToolName() => "UnregisterAsVersioned";

		/// <summary>
		/// <para>Tool Excute Name : management.UnregisterAsVersioned</para>
		/// </summary>
		public override string ExcuteName() => "management.UnregisterAsVersioned";

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
		public override object[] Parameters() => new object[] { InDataset, KeepEdit!, CompressDefault!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要取消注册版本的数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Do not run if there are versions with edits</para>
		/// <para>指定是否将保留对版本化数据所做的编辑。</para>
		/// <para>选中 - 如果增量表中已存在编辑，则工具会失败并显示错误消息。如果您想在将“默认”版本中的所有编辑内容压缩到基表中参数中压缩“默认”版本的编辑内容，请不要使用此选项。这是默认设置。</para>
		/// <para>未选中 - 如果增量表中已存在编辑，则该工具可删除这些编辑。如果您想在将“默认”版本中的所有编辑内容压缩到基表中参数中压缩“默认”版本的编辑内容，请使用此选项。</para>
		/// <para><see cref="KeepEditEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepEdit { get; set; } = "true";

		/// <summary>
		/// <para>Compress all edits in the Default version into the base table</para>
		/// <para>指定是否要压缩编辑内容以及是否要移除未使用的数据。如果已选中如果版本中已存在编辑，则请勿运行，则将忽略此选项。</para>
		/// <para>选中 -“默认”版本中的编辑内容将被压缩到基表中。</para>
		/// <para>未选中 - 保留在增量表中的所有编辑内容不会被压缩。这是默认设置。</para>
		/// <para><see cref="CompressDefaultEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompressDefault { get; set; } = "false";

		/// <summary>
		/// <para>Unregistered Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UnregisterAsVersioned SetEnviroment(object? workspace = null )
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_EDIT")]
			KEEP_EDIT,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPRESS_DEFAULT")]
			COMPRESS_DEFAULT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPRESS_DEFAULT")]
			NO_COMPRESS_DEFAULT,

		}

#endregion
	}
}
