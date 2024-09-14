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
	/// <para>Validate Join</para>
	/// <para>验证连接</para>
	/// <para>验证两个图层或表之间的连接，以确定图层或表是否具有有效的字段名称和对象 ID 字段，但前提是该连接生成匹配记录，是一对一或一对多连接，以及其他连接属性。</para>
	/// </summary>
	public class ValidateJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Layer or Table View</para>
		/// <para>具有与将要验证的连接表之间的连接的图层或表视图。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>连接基于的输入图层或表视图中的字段。</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>具有与输入图层或表视图的连接的图表或表视图。</para>
		/// </param>
		/// <param name="JoinField">
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，包含连接将基于的值。</para>
		/// </param>
		public ValidateJoin(object InLayerOrView, object InField, object JoinTable, object JoinField)
		{
			this.InLayerOrView = InLayerOrView;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.JoinField = JoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : 验证连接</para>
		/// </summary>
		public override string DisplayName() => "验证连接";

		/// <summary>
		/// <para>Tool Name : ValidateJoin</para>
		/// </summary>
		public override string ToolName() => "ValidateJoin";

		/// <summary>
		/// <para>Tool Excute Name : management.ValidateJoin</para>
		/// </summary>
		public override string ExcuteName() => "management.ValidateJoin";

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
		public override object[] Parameters() => new object[] { InLayerOrView, InField, JoinTable, JoinField, OutputMsg, MatchCount, RowCount };

		/// <summary>
		/// <para>Input Layer or Table View</para>
		/// <para>具有与将要验证的连接表之间的连接的图层或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>连接基于的输入图层或表视图中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Join Table</para>
		/// <para>具有与输入图层或表视图的连接的图表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JoinTable { get; set; }

		/// <summary>
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，包含连接将基于的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object JoinField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>以表格形式包含验证消息的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputMsg { get; set; }

		/// <summary>
		/// <para>Match Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object MatchCount { get; set; } = "0";

		/// <summary>
		/// <para>Row Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object RowCount { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ValidateJoin SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
