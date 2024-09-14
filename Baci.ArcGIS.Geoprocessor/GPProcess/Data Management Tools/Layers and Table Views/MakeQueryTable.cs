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
	/// <para>Make Query Table</para>
	/// <para>Make Query Table</para>
	/// <para>Applies an SQL query to a database, and the results are represented in either a layer or table view. The query can be used to join several tables or return a subset of fields or rows from the original data in the database.</para>
	/// </summary>
	public class MakeQueryTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Tables</para>
		/// <para>The name of the table or tables to be used in the query. If several tables are listed, the Expression parameter can be used to define how they will be joined.</para>
		/// <para>The input table can be from a geodatabase or a database connection.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Table Name</para>
		/// <para>The name of the layer or table view that will be created.</para>
		/// </param>
		/// <param name="InKeyFieldOption">
		/// <para>Key Field Options</para>
		/// <para>Specifies how an ObjectID field will be generated (if at all) for the query. Layers and table views in ArcGIS require an ObjectID field. An ObjectID field is an integer field that uniquely identifies rows in the data being used. The default is Use key fields (USE_KEY_FIELDS in Python).</para>
		/// <para>Use key fields—Specified fields in the Key Fields parameter will be used to uniquely identify a row in the output table. This can be a single field or multiple fields, which, when combined, uniquely identify a row in the output table. If no fields are specified in the key fields list, the Generate a key field option (ADD VIRTUAL_KEY_FIELD in Python) is automatically applied.</para>
		/// <para>Generate a key field—If no key fields have been specified, an ObjectID that uniquely identifies each row in the output table will be generated.</para>
		/// <para>No key field—No ObjectID field will be generated. Selections will not be supported for the table view.If there is already a field of type ObjectID in the fields list, it will be used as the ObjectID even if this option is chosen.</para>
		/// <para><see cref="InKeyFieldOptionEnum"/></para>
		/// </param>
		public MakeQueryTable(object InTable, object OutTable, object InKeyFieldOption)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.InKeyFieldOption = InKeyFieldOption;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Query Table</para>
		/// </summary>
		public override string DisplayName() => "Make Query Table";

		/// <summary>
		/// <para>Tool Name : MakeQueryTable</para>
		/// </summary>
		public override string ToolName() => "MakeQueryTable";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeQueryTable</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeQueryTable";

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
		public override object[] Parameters() => new object[] { InTable, OutTable, InKeyFieldOption, InKeyField!, InField!, WhereClause! };

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>The name of the table or tables to be used in the query. If several tables are listed, the Expression parameter can be used to define how they will be joined.</para>
		/// <para>The input table can be from a geodatabase or a database connection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[xmlserialize(Xml = "<GPVirtualTableDomain xsi:type='typens:GPVirtualTableDomain' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:typens='http://www.esri.com/schemas/ArcGIS/3.0.0'></GPVirtualTableDomain>")]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Table Name</para>
		/// <para>The name of the layer or table view that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Key Field Options</para>
		/// <para>Specifies how an ObjectID field will be generated (if at all) for the query. Layers and table views in ArcGIS require an ObjectID field. An ObjectID field is an integer field that uniquely identifies rows in the data being used. The default is Use key fields (USE_KEY_FIELDS in Python).</para>
		/// <para>Use key fields—Specified fields in the Key Fields parameter will be used to uniquely identify a row in the output table. This can be a single field or multiple fields, which, when combined, uniquely identify a row in the output table. If no fields are specified in the key fields list, the Generate a key field option (ADD VIRTUAL_KEY_FIELD in Python) is automatically applied.</para>
		/// <para>Generate a key field—If no key fields have been specified, an ObjectID that uniquely identifies each row in the output table will be generated.</para>
		/// <para>No key field—No ObjectID field will be generated. Selections will not be supported for the table view.If there is already a field of type ObjectID in the fields list, it will be used as the ObjectID even if this option is chosen.</para>
		/// <para><see cref="InKeyFieldOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InKeyFieldOption { get; set; } = "USE_KEY_FIELDS";

		/// <summary>
		/// <para>Key Fields</para>
		/// <para>A field or combination of fields that will be used to uniquely identify a row in the query. This parameter is used only when the Key Field Options parameter is set to Use Key Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain(GUID = "{74F6B060-5EB6-4851-8FFD-8B188A845F37}")]
		public object? InKeyField { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>The fields to include in the layer or table view. If an alias is set for a field, this is the name that appears. If no fields are specified, all fields from all tables are included. If a Shape field is added to the field list, the result is a layer; otherwise it is a table view.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? InField { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeQueryTable SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Key Field Options</para>
		/// </summary>
		public enum InKeyFieldOptionEnum 
		{
			/// <summary>
			/// <para>Use key fields—Specified fields in the Key Fields parameter will be used to uniquely identify a row in the output table. This can be a single field or multiple fields, which, when combined, uniquely identify a row in the output table. If no fields are specified in the key fields list, the Generate a key field option (ADD VIRTUAL_KEY_FIELD in Python) is automatically applied.</para>
			/// </summary>
			[GPValue("USE_KEY_FIELDS")]
			[Description("Use key fields")]
			Use_key_fields,

			/// <summary>
			/// <para>Generate a key field—If no key fields have been specified, an ObjectID that uniquely identifies each row in the output table will be generated.</para>
			/// </summary>
			[GPValue("ADD_VIRTUAL_KEY_FIELD")]
			[Description("Generate a key field")]
			Generate_a_key_field,

			/// <summary>
			/// <para>No key field—No ObjectID field will be generated. Selections will not be supported for the table view.If there is already a field of type ObjectID in the fields list, it will be used as the ObjectID even if this option is chosen.</para>
			/// </summary>
			[GPValue("NO_KEY_FIELD")]
			[Description("No key field")]
			No_key_field,

		}

#endregion
	}
}
