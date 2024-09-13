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
	/// <para>添加关联</para>
	/// <para>基于字段值将图层关联到另一图层或表。支持带有栅格属性表的要素图层、表视图和栅格图层。</para>
	/// </summary>
	public class AddRelate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Layer Name or Table View</para>
		/// <para>关联表将关联的图层或表视图。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Relate Field</para>
		/// <para>关联基于的输入图层或表视图中的字段。</para>
		/// </param>
		/// <param name="RelateTable">
		/// <para>Relate Table</para>
		/// <para>将关联到输入图层或表视图的表或表视图。</para>
		/// </param>
		/// <param name="RelateField">
		/// <para>Output Relate Field</para>
		/// <para>关联表中的字段，包含关联将基于的值。</para>
		/// </param>
		/// <param name="RelateName">
		/// <para>Relate Name</para>
		/// <para>指定给关联的唯一名称。</para>
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
		/// <para>Tool Display Name : 添加关联</para>
		/// </summary>
		public override string DisplayName() => "添加关联";

		/// <summary>
		/// <para>Tool Name : AddRelate</para>
		/// </summary>
		public override string ToolName() => "AddRelate";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRelate</para>
		/// </summary>
		public override string ExcuteName() => "management.AddRelate";

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
		public override object[] Parameters() => new object[] { InLayerOrView, InField, RelateTable, RelateField, RelateName, Cardinality!, OutLayerOrView! };

		/// <summary>
		/// <para>Layer Name or Table View</para>
		/// <para>关联表将关联的图层或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Input Relate Field</para>
		/// <para>关联基于的输入图层或表视图中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Relate Table</para>
		/// <para>将关联到输入图层或表视图的表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object RelateTable { get; set; }

		/// <summary>
		/// <para>Output Relate Field</para>
		/// <para>关联表中的字段，包含关联将基于的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object RelateField { get; set; }

		/// <summary>
		/// <para>Relate Name</para>
		/// <para>指定给关联的唯一名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RelateName { get; set; }

		/// <summary>
		/// <para>Cardinality</para>
		/// <para>关系的基数。</para>
		/// <para>一对一—指定输入表和关联表间是一对一的关系。例如，输入表中的一个记录在关联表中只有一个匹配记录。</para>
		/// <para>一对多—指定输入表和关联表间是一对多的关系。例如，输入表中的一个记录在关联表中有多个匹配记录。这是默认设置。</para>
		/// <para>多对多—指定输入表和关联表间是多对多的关系。例如，输入表中相同值的多个记录在关联表中有多个匹配记录。</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Cardinality { get; set; } = "ONE_TO_MANY";

		/// <summary>
		/// <para>Updated Input Layer or Table View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRelate SetEnviroment(object? workspace = null )
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
			/// <para>一对一—指定输入表和关联表间是一对一的关系。例如，输入表中的一个记录在关联表中只有一个匹配记录。</para>
			/// </summary>
			[GPValue("ONE_TO_ONE")]
			[Description("一对一")]
			One_to_one,

			/// <summary>
			/// <para>一对多—指定输入表和关联表间是一对多的关系。例如，输入表中的一个记录在关联表中有多个匹配记录。这是默认设置。</para>
			/// </summary>
			[GPValue("ONE_TO_MANY")]
			[Description("一对多")]
			One_to_many,

			/// <summary>
			/// <para>多对多—指定输入表和关联表间是多对多的关系。例如，输入表中相同值的多个记录在关联表中有多个匹配记录。</para>
			/// </summary>
			[GPValue("MANY_TO_MANY")]
			[Description("多对多")]
			Many_to_many,

		}

#endregion
	}
}
