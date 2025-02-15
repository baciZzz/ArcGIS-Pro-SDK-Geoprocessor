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
	/// <para>Disable Attribute Rules</para>
	/// <para>Disable Attribute Rules</para>
	/// <para>Disables one or more attribute rules for a dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisableAttributeRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table or feature class that contains the attribute rule to be disabled.</para>
		/// </param>
		/// <param name="Names">
		/// <para>Rule Names</para>
		/// <para>The names of the rules to disable for the dataset.</para>
		/// </param>
		public DisableAttributeRules(object InTable, object Names)
		{
			this.InTable = InTable;
			this.Names = Names;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable Attribute Rules</para>
		/// </summary>
		public override string DisplayName() => "Disable Attribute Rules";

		/// <summary>
		/// <para>Tool Name : DisableAttributeRules</para>
		/// </summary>
		public override string ToolName() => "DisableAttributeRules";

		/// <summary>
		/// <para>Tool Excute Name : management.DisableAttributeRules</para>
		/// </summary>
		public override string ExcuteName() => "management.DisableAttributeRules";

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
		public override object[] Parameters() => new object[] { InTable, Names, Type!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table or feature class that contains the attribute rule to be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Rule Names</para>
		/// <para>The names of the rules to disable for the dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Names { get; set; }

		/// <summary>
		/// <para>Type</para>
		/// <para>Specifies the type of attribute rules to disable.</para>
		/// <para>Calculation—Filters the Rule Names parameter to display only calculation type rules.</para>
		/// <para>Constraint—Filters the Rule Names parameter to display only constraint type rules.</para>
		/// <para>Validation—Filters the Rule Names parameter to display only validation type rules.</para>
		/// <para><see cref="TypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Type { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DisableAttributeRules SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type</para>
		/// </summary>
		public enum TypeEnum 
		{
			/// <summary>
			/// <para>Calculation—Filters the Rule Names parameter to display only calculation type rules.</para>
			/// </summary>
			[GPValue("CALCULATION")]
			[Description("Calculation")]
			Calculation,

			/// <summary>
			/// <para>Constraint—Filters the Rule Names parameter to display only constraint type rules.</para>
			/// </summary>
			[GPValue("CONSTRAINT")]
			[Description("Constraint")]
			Constraint,

			/// <summary>
			/// <para>Validation—Filters the Rule Names parameter to display only validation type rules.</para>
			/// </summary>
			[GPValue("VALIDATION")]
			[Description("Validation")]
			Validation,

		}

#endregion
	}
}
