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
	/// <para>Validates a  join between two layers or tables to determine if the layers or tables have valid field names and Object ID fields, if the join produces matching records, is a one-to-one or one-to-many join, and other properties of the join.</para>
	/// </summary>
	public class ValidateJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Layer or Table View</para>
		/// <para>The layer or table view with the join to the join table that will be validated.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>The field in the input layer or table view on which the join will be based.</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>The table or table view with the join to the input layer or table view that will be validated.</para>
		/// </param>
		/// <param name="JoinField">
		/// <para>Join Table Field</para>
		/// <para>The field in the join table that contains the values on which the join will be based.</para>
		/// </param>
		public ValidateJoin(object InLayerOrView, object InField, object JoinTable, object JoinField)
		{
			this.InLayerOrView = InLayerOrView;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.JoinField = JoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : Validate Join</para>
		/// </summary>
		public override string DisplayName => "Validate Join";

		/// <summary>
		/// <para>Tool Name : ValidateJoin</para>
		/// </summary>
		public override string ToolName => "ValidateJoin";

		/// <summary>
		/// <para>Tool Excute Name : management.ValidateJoin</para>
		/// </summary>
		public override string ExcuteName => "management.ValidateJoin";

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
		public override object[] Parameters => new object[] { InLayerOrView, InField, JoinTable, JoinField, OutputMsg, MatchCount, RowCount };

		/// <summary>
		/// <para>Input Layer or Table View</para>
		/// <para>The layer or table view with the join to the join table that will be validated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>The field in the input layer or table view on which the join will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InField { get; set; }

		/// <summary>
		/// <para>Join Table</para>
		/// <para>The table or table view with the join to the input layer or table view that will be validated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JoinTable { get; set; }

		/// <summary>
		/// <para>Join Table Field</para>
		/// <para>The field in the join table that contains the values on which the join will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object JoinField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the validation messages in a tabular form.</para>
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
		public ValidateJoin SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
