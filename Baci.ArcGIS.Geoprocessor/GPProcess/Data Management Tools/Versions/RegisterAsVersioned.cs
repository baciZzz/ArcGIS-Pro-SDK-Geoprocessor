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
	/// <para>Register As Versioned</para>
	/// <para>注册版本</para>
	/// <para>将企业级地理数据库数据集注册为版本化。</para>
	/// </summary>
	public class RegisterAsVersioned : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要注册为版本的数据集。</para>
		/// </param>
		public RegisterAsVersioned(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 注册版本</para>
		/// </summary>
		public override string DisplayName() => "注册版本";

		/// <summary>
		/// <para>Tool Name : RegisterAsVersioned</para>
		/// </summary>
		public override string ToolName() => "RegisterAsVersioned";

		/// <summary>
		/// <para>Tool Excute Name : management.RegisterAsVersioned</para>
		/// </summary>
		public override string ExcuteName() => "management.RegisterAsVersioned";

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
		public override object[] Parameters() => new object[] { InDataset, EditToBase, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要注册为版本的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Register the selected objects with the option to move edits to base</para>
		/// <para>指定是否将对默认版本进行的编辑移动到基表。</para>
		/// <para>选中 - 对数据集进行版本化时使用“将编辑内容移动至基表”选项。</para>
		/// <para>未选中 - 对数据集进行版本化时不使用“将编辑内容移动至基表”选项。这是默认设置。</para>
		/// <para><see cref="EditToBaseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EditToBase { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegisterAsVersioned SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Register the selected objects with the option to move edits to base</para>
		/// </summary>
		public enum EditToBaseEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EDITS_TO_BASE")]
			EDITS_TO_BASE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EDITS_TO_BASE")]
			NO_EDITS_TO_BASE,

		}

#endregion
	}
}
