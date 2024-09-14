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
	/// <para>添加属性索引</para>
	/// <para>将属性索引添加到现有表、要素类、shapefile 或属性关系类中。</para>
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
		/// <para>包含要建立索引的字段的表。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Fields to Index</para>
		/// <para>要加入到索引中的字段的列表。可指定任意数量的字段。</para>
		/// </param>
		public AddIndex(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加属性索引</para>
		/// </summary>
		public override string DisplayName() => "添加属性索引";

		/// <summary>
		/// <para>Tool Name : AddIndex</para>
		/// </summary>
		public override string ToolName() => "AddIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.AddIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.AddIndex";

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
		public override object[] Parameters() => new object[] { InTable, Fields, IndexName, Unique, Ascending, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要建立索引的字段的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Fields to Index</para>
		/// <para>要加入到索引中的字段的列表。可指定任意数量的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "GUID", "GlobalID")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Index Name</para>
		/// <para>新索引的名称。向地理数据库要素类和表添加索引时，必须指定索引名称。对于其他类型输入，可以忽略名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object IndexName { get; set; }

		/// <summary>
		/// <para>Unique</para>
		/// <para>指定索引中的值是否唯一。</para>
		/// <para>未选中 - 索引中的所有值并不都唯一。这是默认设置。</para>
		/// <para>选中 - 索引中的所有值都唯一。</para>
		/// <para><see cref="UniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Unique { get; set; } = "false";

		/// <summary>
		/// <para>Ascending</para>
		/// <para>指定是否按升序建立索引。</para>
		/// <para>未选中 - 不按升序建立值的索引。这是默认设置。</para>
		/// <para>选中 - 按升序建立索引。</para>
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
		public AddIndex SetEnviroment(object workspace = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UNIQUE")]
			UNIQUE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ASCENDING")]
			ASCENDING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ASCENDING")]
			NON_ASCENDING,

		}

#endregion
	}
}
