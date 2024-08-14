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
	/// <para>Add Relate</para>
	/// <para>Relates a layer to another layer or table based on a field value. Feature layers, table views, and raster layers with a raster attribute table are supported.</para>
	/// </summary>
	public class AddRelate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>The layer or table view to which the relate table will be related.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Relate Field</para>
		/// <para>The field in the input layer or table view on which the relate will be based.</para>
		/// </param>
		/// <param name="RelateTable">
		/// <para>Relate Table</para>
		/// <para>The table or table view to be related to the input layer or table view.</para>
		/// </param>
		/// <param name="RelateField">
		/// <para>Output Relate Field</para>
		/// <para>The field in the relate table that contains the values on which the relate will be based.</para>
		/// </param>
		/// <param name="RelateName">
		/// <para>Relate Name</para>
		/// <para>The unique name given to a relate.</para>
		/// </param>
		public AddRelate(object InLayerOrView, object InField, object RelateTable, object RelateField, object RelateName)
		{
			this.InLayerOrView = InLayerOrView;
			this.InField = InField;
			this.RelateTable = RelateTable;
			this.RelateField = RelateField;
			this.RelateName = RelateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Relate</para>
		/// </summary>
		public override string DisplayName => "Add Relate";

		/// <summary>
		/// <para>Tool Name : AddRelate</para>
		/// </summary>
		public override string ToolName => "AddRelate";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRelate</para>
		/// </summary>
		public override string ExcuteName => "management.AddRelate";

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
		public override object[] Parameters => new object[] { InLayerOrView, InField, RelateTable, RelateField, RelateName, Cardinality, OutLayerOrView };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>The layer or table view to which the relate table will be related.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Input Relate Field</para>
		/// <para>The field in the input layer or table view on which the relate will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InField { get; set; }

		/// <summary>
		/// <para>Relate Table</para>
		/// <para>The table or table view to be related to the input layer or table view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object RelateTable { get; set; }

		/// <summary>
		/// <para>Output Relate Field</para>
		/// <para>The field in the relate table that contains the values on which the relate will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object RelateField { get; set; }

		/// <summary>
		/// <para>Relate Name</para>
		/// <para>The unique name given to a relate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RelateName { get; set; }

		/// <summary>
		/// <para>Cardinality</para>
		/// <para>The cardinality of the relationship.</para>
		/// <para>One to one—Specifies that the relationship between the input table and related table is one to one. For example, one record in the input table will only have one matching record in the related table.</para>
		/// <para>One to many—Specifies that the relationship between the input table and related table is one to many. For example, one record in the input table can have multiple matching records in the related table. This is the default.</para>
		/// <para>Many to many—Specifies that the relationship between the input table and related table is many to many. For example, many records with the same value in the input table can have multiple matching records in the related table.</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Cardinality { get; set; } = "ONE_TO_MANY";

		/// <summary>
		/// <para>Updated Input Layer or Table View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRelate SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cardinality</para>
		/// </summary>
		public enum CardinalityEnum 
		{
			/// <summary>
			/// <para>One to one—Specifies that the relationship between the input table and related table is one to one. For example, one record in the input table will only have one matching record in the related table.</para>
			/// </summary>
			[GPValue("ONE_TO_ONE")]
			[Description("One to one")]
			One_to_one,

			/// <summary>
			/// <para>One to many—Specifies that the relationship between the input table and related table is one to many. For example, one record in the input table can have multiple matching records in the related table. This is the default.</para>
			/// </summary>
			[GPValue("ONE_TO_MANY")]
			[Description("One to many")]
			One_to_many,

			/// <summary>
			/// <para>Many to many—Specifies that the relationship between the input table and related table is many to many. For example, many records with the same value in the input table can have multiple matching records in the related table.</para>
			/// </summary>
			[GPValue("MANY_TO_MANY")]
			[Description("Many to many")]
			Many_to_many,

		}

#endregion
	}
}
