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
	/// <para>启用属性规则</para>
	/// <para>用于启用数据集中的一个或多个属性规则。</para>
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
		/// <para>包含要启用的属性规则的表或要素类。</para>
		/// </param>
		/// <param name="Names">
		/// <para>Rule Names</para>
		/// <para>要启用的数据集规则的名称。</para>
		/// </param>
		public EnableAttributeRules(object InTable, object Names)
		{
			this.InTable = InTable;
			this.Names = Names;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用属性规则</para>
		/// </summary>
		public override string DisplayName() => "启用属性规则";

		/// <summary>
		/// <para>Tool Name : EnableAttributeRules</para>
		/// </summary>
		public override string ToolName() => "EnableAttributeRules";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableAttributeRules</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableAttributeRules";

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
		/// <para>包含要启用的属性规则的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Rule Names</para>
		/// <para>要启用的数据集规则的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Names { get; set; }

		/// <summary>
		/// <para>Type</para>
		/// <para>指定要启用的属性规则的类型。</para>
		/// <para>计算 - 过滤规则名称参数以仅显示计算类型规则。</para>
		/// <para>约束 - 过滤规则名称参数以仅显示约束类型规则。</para>
		/// <para>验证 - 过滤规则名称参数以仅显示验证类型规则。</para>
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
		public EnableAttributeRules SetEnviroment(object? workspace = null)
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
			/// <para>计算 - 过滤规则名称参数以仅显示计算类型规则。</para>
			/// </summary>
			[GPValue("CALCULATION")]
			[Description("计算")]
			Calculation,

			/// <summary>
			/// <para>约束 - 过滤规则名称参数以仅显示约束类型规则。</para>
			/// </summary>
			[GPValue("CONSTRAINT")]
			[Description("约束")]
			Constraint,

			/// <summary>
			/// <para>验证 - 过滤规则名称参数以仅显示验证类型规则。</para>
			/// </summary>
			[GPValue("VALIDATION")]
			[Description("验证")]
			Validation,

		}

#endregion
	}
}
