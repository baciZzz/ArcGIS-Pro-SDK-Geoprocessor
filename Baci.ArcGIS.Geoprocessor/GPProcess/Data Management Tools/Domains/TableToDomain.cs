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
	/// <para>Table To Domain</para>
	/// <para>表转属性域</para>
	/// <para>通过表中的值创建或更新编码值属性域。</para>
	/// </summary>
	public class TableToDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>用于从中派生属性域值的数据库表。</para>
		/// </param>
		/// <param name="CodeField">
		/// <para>Code Field</para>
		/// <para>用于从中派生域编码值的数据库表中的字段。</para>
		/// </param>
		/// <param name="DescriptionField">
		/// <para>Description Field</para>
		/// <para>用于从中派生属性域描述值的数据库表中的字段。</para>
		/// </param>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>要创建或要更新的属性域所在的工作空间。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>要创建或要更新的属性域的名称。</para>
		/// </param>
		public TableToDomain(object InTable, object CodeField, object DescriptionField, object InWorkspace, object DomainName)
		{
			this.InTable = InTable;
			this.CodeField = CodeField;
			this.DescriptionField = DescriptionField;
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转属性域</para>
		/// </summary>
		public override string DisplayName() => "表转属性域";

		/// <summary>
		/// <para>Tool Name : TableToDomain</para>
		/// </summary>
		public override string ToolName() => "TableToDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.TableToDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.TableToDomain";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, CodeField, DescriptionField, InWorkspace, DomainName, DomainDescription, UpdateOption, OutWorkspace };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>用于从中派生属性域值的数据库表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Code Field</para>
		/// <para>用于从中派生域编码值的数据库表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object CodeField { get; set; }

		/// <summary>
		/// <para>Description Field</para>
		/// <para>用于从中派生属性域描述值的数据库表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object DescriptionField { get; set; }

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>要创建或要更新的属性域所在的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>要创建或要更新的属性域的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Domain Description</para>
		/// <para>要创建或要更新的属性域的描述。不会更新现有属性域的属性域描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DomainDescription { get; set; }

		/// <summary>
		/// <para>Update Option</para>
		/// <para>如果属性域已经存在，请指定如何更新属性域。</para>
		/// <para>追加这些值—从数据库表追加到属性域值。</para>
		/// <para>替换这些值—用数据库表中的值替换属性域中的值。</para>
		/// <para><see cref="UpdateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateOption { get; set; } = "APPEND";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToDomain SetEnviroment(int? autoCommit = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Option</para>
		/// </summary>
		public enum UpdateOptionEnum 
		{
			/// <summary>
			/// <para>追加这些值—从数据库表追加到属性域值。</para>
			/// </summary>
			[GPValue("APPEND")]
			[Description("追加这些值")]
			Append_the_values,

			/// <summary>
			/// <para>替换这些值—用数据库表中的值替换属性域中的值。</para>
			/// </summary>
			[GPValue("REPLACE")]
			[Description("替换这些值")]
			Replace_the_values,

		}

#endregion
	}
}
