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
	/// <para>Enable Attribute Rules</para>
	/// <para>Enables one or more attribute rules in a dataset</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableAttributeRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table or feature class that contains the attribute rule to be enabled.</para>
		/// </param>
		/// <param name="Names">
		/// <para>Rule Names</para>
		/// <para>The names of the rules to enable for the dataset.</para>
		/// </param>
		public EnableAttributeRules(object InTable, object Names)
		{
			this.InTable = InTable;
			this.Names = Names;
		}

		/// <summary>
		/// <para>Tool Display Name : Enable Attribute Rules</para>
		/// </summary>
		public override string DisplayName => "Enable Attribute Rules";

		/// <summary>
		/// <para>Tool Name : EnableAttributeRules</para>
		/// </summary>
		public override string ToolName => "EnableAttributeRules";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableAttributeRules</para>
		/// </summary>
		public override string ExcuteName => "management.EnableAttributeRules";

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
		public override object[] Parameters => new object[] { InTable, Names, Type, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table or feature class that contains the attribute rule to be enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Rule Names</para>
		/// <para>The names of the rules to enable for the dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Names { get; set; }

		/// <summary>
		/// <para>Type</para>
		/// <para>Specifies the type of attribute rules to enable.</para>
		/// <para>Calculation—Filters the Rule Names parameter to display only calculation type rules.</para>
		/// <para>Constraint—Filters the Rule Names parameter to display only constraint type rules.</para>
		/// <para>Validation—Filters the Rule Names parameter to display only validation type rules.</para>
		/// <para><see cref="TypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Type { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EnableAttributeRules SetEnviroment(object workspace = null )
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
