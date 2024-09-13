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
	/// <para>Delete Field</para>
	/// <para>删除字段</para>
	/// <para>可从表、要素类、要素图层或栅格数据集中删除一个或多个字段。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要删除字段的表。 将修改现有输入字段。</para>
		/// </param>
		/// <param name="DropField">
		/// <para>Field(s)</para>
		/// <para>按照方法参数指定的方式从输入表中删除或保留的字段。 仅可删除非必填字段。</para>
		/// </param>
		public DeleteField(object InTable, object DropField)
		{
			this.InTable = InTable;
			this.DropField = DropField;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除字段</para>
		/// </summary>
		public override string DisplayName() => "删除字段";

		/// <summary>
		/// <para>Tool Name : DeleteField</para>
		/// </summary>
		public override string ToolName() => "DeleteField";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteField</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteField";

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
		public override object[] Parameters() => new object[] { InTable, DropField, OutTable!, Method! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要删除字段的表。 将修改现有输入字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPTablesDomain()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>按照方法参数指定的方式从输入表中删除或保留的字段。 仅可删除非必填字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object DropField { get; set; }

		/// <summary>
		/// <para>Update Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定由字段参数指定的字段将被删除或保留。</para>
		/// <para>删除字段—由字段参数指定的字段将被删除。 这是默认设置。</para>
		/// <para>保留字段—由字段参数指定的字段将被保留；所有其他字段将被删除。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "DELETE_FIELDS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteField SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>删除字段—由字段参数指定的字段将被删除。 这是默认设置。</para>
			/// </summary>
			[GPValue("DELETE_FIELDS")]
			[Description("删除字段")]
			Delete_Fields,

			/// <summary>
			/// <para>保留字段—由字段参数指定的字段将被保留；所有其他字段将被删除。</para>
			/// </summary>
			[GPValue("KEEP_FIELDS")]
			[Description("保留字段")]
			Keep_Fields,

		}

#endregion
	}
}
