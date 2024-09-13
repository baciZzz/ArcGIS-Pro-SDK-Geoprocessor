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
	/// <para>Register As Versioned</para>
	/// <para>Registers an enterprise geodatabase dataset as versioned.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RegisterAsVersioned : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The dataset to be registered as versioned.</para>
		/// </param>
		public RegisterAsVersioned(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Register As Versioned</para>
		/// </summary>
		public override string DisplayName() => "Register As Versioned";

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
		public override object[] Parameters() => new object[] { InDataset, EditToBase!, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The dataset to be registered as versioned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Register the selected objects with the option to move edits to base</para>
		/// <para>Specifies whether edits made to the default version will be moved to the base tables.</para>
		/// <para>Checked—The dataset will be versioned with the option of moving edits to base.</para>
		/// <para>Unchecked—The dataset will be versioned without the option of moving edits to base. This is the default.</para>
		/// <para><see cref="EditToBaseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EditToBase { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegisterAsVersioned SetEnviroment(object? workspace = null )
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
			/// <para>Checked—The dataset will be versioned with the option of moving edits to base.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EDITS_TO_BASE")]
			EDITS_TO_BASE,

			/// <summary>
			/// <para>Unchecked—The dataset will be versioned without the option of moving edits to base. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EDITS_TO_BASE")]
			NO_EDITS_TO_BASE,

		}

#endregion
	}
}
