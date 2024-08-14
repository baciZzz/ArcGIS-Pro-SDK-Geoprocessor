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
	/// <para>Add Join</para>
	/// <para>Joins a layer to another layer or table based on a common field. Feature layers, table views, and raster layers with a raster attribute table are supported.</para>
	/// </summary>
	public class AddJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Table</para>
		/// <para>The layer or table view to which the join table will be joined.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>The field in the input layer or table view on which the join will be based.</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>The table or table view to be joined to the input layer or table view.</para>
		/// </param>
		/// <param name="JoinField">
		/// <para>Join Table Field</para>
		/// <para>The field in the join table that contains the values on which the join will be based.</para>
		/// </param>
		public AddJoin(object InLayerOrView, object InField, object JoinTable, object JoinField)
		{
			this.InLayerOrView = InLayerOrView;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.JoinField = JoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Join</para>
		/// </summary>
		public override string DisplayName => "Add Join";

		/// <summary>
		/// <para>Tool Name : AddJoin</para>
		/// </summary>
		public override string ToolName => "AddJoin";

		/// <summary>
		/// <para>Tool Excute Name : management.AddJoin</para>
		/// </summary>
		public override string ExcuteName => "management.AddJoin";

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
		public override object[] Parameters => new object[] { InLayerOrView, InField, JoinTable, JoinField, JoinType!, OutLayerOrView!, IndexJoinFields! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The layer or table view to which the join table will be joined.</para>
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
		/// <para>The table or table view to be joined to the input layer or table view.</para>
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
		/// <para>Keep All Target Features</para>
		/// <para>Specifies whether only records in the input that match a record in the join table will be included in the output.</para>
		/// <para>Checked—All records in the input layer or table view will be included in the output. This is also known as an outer join. This is the default.</para>
		/// <para>Unchecked—Only those records in the input that match a row in the join table will be included in the output. This is also known as an inner join.</para>
		/// <para><see cref="JoinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? JoinType { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Layer or Table View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Index Joined Fields</para>
		/// <para>Specifies whether table attribute indexes will be added to both joining fields.</para>
		/// <para>Checked—Both join fields will be indexed. If the table already has an index, a new index will not be added.</para>
		/// <para>Unchecked—Indexes will not be added. This is the default.</para>
		/// <para><see cref="IndexJoinFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IndexJoinFields { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddJoin SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// </summary>
		public enum JoinTypeEnum 
		{
			/// <summary>
			/// <para>Checked—All records in the input layer or table view will be included in the output. This is also known as an outer join. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para>Unchecked—Only those records in the input that match a row in the join table will be included in the output. This is also known as an inner join.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_COMMON")]
			KEEP_COMMON,

		}

		/// <summary>
		/// <para>Index Joined Fields</para>
		/// </summary>
		public enum IndexJoinFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Both join fields will be indexed. If the table already has an index, a new index will not be added.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INDEX_JOIN_FIELDS")]
			INDEX_JOIN_FIELDS,

			/// <summary>
			/// <para>Unchecked—Indexes will not be added. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INDEX_JOIN_FIELDS")]
			NO_INDEX_JOIN_FIELDS,

		}

#endregion
	}
}
