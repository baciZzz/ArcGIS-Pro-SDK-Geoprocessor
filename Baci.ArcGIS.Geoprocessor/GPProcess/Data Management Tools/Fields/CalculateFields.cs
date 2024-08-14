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
	/// <para>Calculate Fields (multiple)</para>
	/// <para>Calculates the values of two or more fields for a feature class, feature layer, or raster.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the fields that will be updated with the new calculations.</para>
		/// </param>
		/// <param name="ExpressionType">
		/// <para>Expression Type</para>
		/// <para>Specifies the type of expression that will be used.</para>
		/// <para>Python 3—The Python expression type will be used. This is the default.</para>
		/// <para>Arcade—The Arcade expression type will be used.</para>
		/// <para>SQL—The SQL expression type will be used.</para>
		/// <para>To learn more about Python expressions, see Calculate Field Python examples.</para>
		/// <para>To learn more about Arcade expressions, see the ArcGIS Arcade guide.</para>
		/// <para>To learn more about SQL expressions, see Calculate field values.</para>
		/// <para><see cref="ExpressionTypeEnum"/></para>
		/// </param>
		/// <param name="Fields">
		/// <para>Fields</para>
		/// <para>The fields that will be calculated and their expressions.</para>
		/// </param>
		public CalculateFields(object InTable, object ExpressionType, object Fields)
		{
			this.InTable = InTable;
			this.ExpressionType = ExpressionType;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Fields (multiple)</para>
		/// </summary>
		public override string DisplayName => "Calculate Fields (multiple)";

		/// <summary>
		/// <para>Tool Name : CalculateFields</para>
		/// </summary>
		public override string ToolName => "CalculateFields";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateFields</para>
		/// </summary>
		public override string ExcuteName => "management.CalculateFields";

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
		public override object[] Parameters => new object[] { InTable, ExpressionType, Fields, CodeBlock, OutTable, EnforceDomains };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the fields that will be updated with the new calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Expression Type</para>
		/// <para>Specifies the type of expression that will be used.</para>
		/// <para>Python 3—The Python expression type will be used. This is the default.</para>
		/// <para>Arcade—The Arcade expression type will be used.</para>
		/// <para>SQL—The SQL expression type will be used.</para>
		/// <para>To learn more about Python expressions, see Calculate Field Python examples.</para>
		/// <para>To learn more about Arcade expressions, see the ArcGIS Arcade guide.</para>
		/// <para>To learn more about SQL expressions, see Calculate field values.</para>
		/// <para><see cref="ExpressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExpressionType { get; set; } = "PYTHON3";

		/// <summary>
		/// <para>Fields</para>
		/// <para>The fields that will be calculated and their expressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Code Block</para>
		/// <para>A block of code that will be used for complex expressions.</para>
		/// <para>A function cannot be used to return multiple values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CodeBlock { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Enforce Domains</para>
		/// <para>Specifies whether field domain rules will be enforced.</para>
		/// <para>Checked—Field domain rules will be enforced. If a field cannot be updated, the field value will remain unchanged, and the tool messages will include a warning message.</para>
		/// <para>Unchecked—Field domain rules will not be enforced. This is the default</para>
		/// <para><see cref="EnforceDomainsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnforceDomains { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateFields SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Expression Type</para>
		/// </summary>
		public enum ExpressionTypeEnum 
		{
			/// <summary>
			/// <para>Python 3—The Python expression type will be used. This is the default.</para>
			/// </summary>
			[GPValue("PYTHON3")]
			[Description("Python 3")]
			Python_3,

			/// <summary>
			/// <para>Arcade—The Arcade expression type will be used.</para>
			/// </summary>
			[GPValue("ARCADE")]
			[Description("Arcade")]
			Arcade,

			/// <summary>
			/// <para>SQL—The SQL expression type will be used.</para>
			/// </summary>
			[GPValue("SQL")]
			[Description("SQL")]
			SQL,

		}

		/// <summary>
		/// <para>Enforce Domains</para>
		/// </summary>
		public enum EnforceDomainsEnum 
		{
			/// <summary>
			/// <para>Checked—Field domain rules will be enforced. If a field cannot be updated, the field value will remain unchanged, and the tool messages will include a warning message.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENFORCE_DOMAINS")]
			ENFORCE_DOMAINS,

			/// <summary>
			/// <para>Unchecked—Field domain rules will not be enforced. This is the default</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ENFORCE_DOMAINS")]
			NO_ENFORCE_DOMAINS,

		}

#endregion
	}
}
