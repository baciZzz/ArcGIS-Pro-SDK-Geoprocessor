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
	/// <para>Delete Attribute Rule</para>
	/// <para>Deletes one or more attribute rules from a dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteAttributeRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table or feature class containing the attribute rule to delete.</para>
		/// </param>
		/// <param name="Names">
		/// <para>Rule Names</para>
		/// <para>The names of the rules to delete from the dataset.</para>
		/// </param>
		public DeleteAttributeRule(object InTable, object Names)
		{
			this.InTable = InTable;
			this.Names = Names;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Attribute Rule</para>
		/// </summary>
		public override string DisplayName() => "Delete Attribute Rule";

		/// <summary>
		/// <para>Tool Name : DeleteAttributeRule</para>
		/// </summary>
		public override string ToolName() => "DeleteAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteAttributeRule";

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
		public override object[] Parameters() => new object[] { InTable, Names, Type, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table or feature class containing the attribute rule to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Rule Names</para>
		/// <para>The names of the rules to delete from the dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Names { get; set; }

		/// <summary>
		/// <para>Type</para>
		/// <para>Specifies the type of attribute rules to delete.</para>
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
		/// <para>Attribute Rules Deleted</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteAttributeRule SetEnviroment(object workspace = null )
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
