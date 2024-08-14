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
	/// <para>Add Attribute Index</para>
	/// <para>Adds an attribute index to an existing table, feature class, shapefile, or attributed relationship class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the fields to be indexed.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Fields to Index</para>
		/// <para>The list of fields that will participate in the index. Any number of fields can be specified.</para>
		/// </param>
		public AddIndex(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Attribute Index</para>
		/// </summary>
		public override string DisplayName => "Add Attribute Index";

		/// <summary>
		/// <para>Tool Name : AddIndex</para>
		/// </summary>
		public override string ToolName => "AddIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.AddIndex</para>
		/// </summary>
		public override string ExcuteName => "management.AddIndex";

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
		public override object[] Parameters => new object[] { InTable, Fields, IndexName, Unique, Ascending, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the fields to be indexed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Fields to Index</para>
		/// <para>The list of fields that will participate in the index. Any number of fields can be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Index Name</para>
		/// <para>The name of the new index. An index name is necessary when adding an index to geodatabase feature classes and tables. For other types of input, the name is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object IndexName { get; set; }

		/// <summary>
		/// <para>Unique</para>
		/// <para>Specifies whether the values in the index are unique.</para>
		/// <para>Unchecked—All values in the index are not unique. This is the default.</para>
		/// <para>Checked—All values in the index are unique.</para>
		/// <para><see cref="UniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Unique { get; set; } = "false";

		/// <summary>
		/// <para>Ascending</para>
		/// <para>Specifies whether values are indexed in ascending order.</para>
		/// <para>Unchecked—Values are not indexed in ascending order. This is the default.</para>
		/// <para>Checked—Values are indexed in ascending order.</para>
		/// <para><see cref="AscendingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Ascending { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddIndex SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Unique</para>
		/// </summary>
		public enum UniqueEnum 
		{
			/// <summary>
			/// <para>Checked—All values in the index are unique.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UNIQUE")]
			UNIQUE,

			/// <summary>
			/// <para>Unchecked—All values in the index are not unique. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_UNIQUE")]
			NON_UNIQUE,

		}

		/// <summary>
		/// <para>Ascending</para>
		/// </summary>
		public enum AscendingEnum 
		{
			/// <summary>
			/// <para>Checked—Values are indexed in ascending order.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ASCENDING")]
			ASCENDING,

			/// <summary>
			/// <para>Unchecked—Values are not indexed in ascending order. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ASCENDING")]
			NON_ASCENDING,

		}

#endregion
	}
}
