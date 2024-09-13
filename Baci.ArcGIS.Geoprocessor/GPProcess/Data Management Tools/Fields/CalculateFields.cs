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
	/// <para>计算字段（多个）</para>
	/// <para>为要素类、要素图层或栅格计算两个或更多个字段的值。</para>
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
		/// <para>包含将通过新的计算进行更新的字段的表。</para>
		/// </param>
		/// <param name="ExpressionType">
		/// <para>Expression Type</para>
		/// <para>指定要使用的表达式类型。</para>
		/// <para>Python 3—将使用 Python 表达式类型。 这是默认设置。</para>
		/// <para>Arcade—将使用 Arcade 表达式类型。</para>
		/// <para>SQL—将使用 SQL 表达式类型。</para>
		/// <para>要了解有关 Python 表达式的详细信息，请参阅计算 Python 字段示例。</para>
		/// <para>要了解有关 Arcade 表达式的详细信息，请参阅 ArcGIS Arcade 指南。</para>
		/// <para>要了解有关 SQL 表达式的详细信息，请参阅计算字段值。</para>
		/// <para><see cref="ExpressionTypeEnum"/></para>
		/// </param>
		/// <param name="Fields">
		/// <para>Fields</para>
		/// <para>要计算的字段及其表达式。</para>
		/// </param>
		public CalculateFields(object InTable, object ExpressionType, object Fields)
		{
			this.InTable = InTable;
			this.ExpressionType = ExpressionType;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算字段（多个）</para>
		/// </summary>
		public override string DisplayName() => "计算字段（多个）";

		/// <summary>
		/// <para>Tool Name : CalculateFields</para>
		/// </summary>
		public override string ToolName() => "CalculateFields";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateFields</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateFields";

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
		public override object[] Parameters() => new object[] { InTable, ExpressionType, Fields, CodeBlock, OutTable, EnforceDomains };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含将通过新的计算进行更新的字段的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Expression Type</para>
		/// <para>指定要使用的表达式类型。</para>
		/// <para>Python 3—将使用 Python 表达式类型。 这是默认设置。</para>
		/// <para>Arcade—将使用 Arcade 表达式类型。</para>
		/// <para>SQL—将使用 SQL 表达式类型。</para>
		/// <para>要了解有关 Python 表达式的详细信息，请参阅计算 Python 字段示例。</para>
		/// <para>要了解有关 Arcade 表达式的详细信息，请参阅 ArcGIS Arcade 指南。</para>
		/// <para>要了解有关 SQL 表达式的详细信息，请参阅计算字段值。</para>
		/// <para><see cref="ExpressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExpressionType { get; set; } = "PYTHON3";

		/// <summary>
		/// <para>Fields</para>
		/// <para>要计算的字段及其表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Code Block</para>
		/// <para>将用于复杂表达式的代码块。</para>
		/// <para>此函数不能用于返回多个值。</para>
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
		/// <para>指定是否强制执行字段属性域规则。</para>
		/// <para>选中 - 将强制执行字段属性域规则。 如果无法更新字段，则字段值将保持不变，并且工具消息中将包含警告消息。</para>
		/// <para>未选中 - 不强制执行字段属性域规则。 这是默认设置</para>
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
			/// <para>Python 3—将使用 Python 表达式类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("PYTHON3")]
			[Description("Python 3")]
			Python_3,

			/// <summary>
			/// <para>Arcade—将使用 Arcade 表达式类型。</para>
			/// </summary>
			[GPValue("ARCADE")]
			[Description("Arcade")]
			Arcade,

			/// <summary>
			/// <para>SQL—将使用 SQL 表达式类型。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENFORCE_DOMAINS")]
			ENFORCE_DOMAINS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ENFORCE_DOMAINS")]
			NO_ENFORCE_DOMAINS,

		}

#endregion
	}
}
