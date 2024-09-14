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
	/// <para>Join Field</para>
	/// <para>连接字段</para>
	/// <para>基于公用属性字段将一个表的内容永久连接到另一个表。 输入表将被更新，从而包含连接表中的字段。 您可以选择连接表中的哪些字段将添加到输入表。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class JoinField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Table</para>
		/// <para>连接表将要连接到的表或要素类。</para>
		/// </param>
		/// <param name="InField">
		/// <para>Input Join Field</para>
		/// <para>连接将基于的输入表中的字段。</para>
		/// </param>
		/// <param name="JoinTable">
		/// <para>Join Table</para>
		/// <para>要连接到输入表的表。</para>
		/// </param>
		/// <param name="Join_Field">
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，其中包含连接所依据的值。</para>
		/// </param>
		public JoinField(object InData, object InField, object JoinTable, object Join_Field)
		{
			this.InData = InData;
			this.InField = InField;
			this.JoinTable = JoinTable;
			this.Join_Field = Join_Field;
		}

		/// <summary>
		/// <para>Tool Display Name : 连接字段</para>
		/// </summary>
		public override string DisplayName() => "连接字段";

		/// <summary>
		/// <para>Tool Name : JoinField</para>
		/// </summary>
		public override string ToolName() => "JoinField";

		/// <summary>
		/// <para>Tool Excute Name : management.JoinField</para>
		/// </summary>
		public override string ExcuteName() => "management.JoinField";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, InField, JoinTable, Join_Field, Fields!, OutLayerOrView!, FmOption!, FieldMapping! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>连接表将要连接到的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>连接将基于的输入表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Join Table</para>
		/// <para>要连接到输入表的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object JoinTable { get; set; }

		/// <summary>
		/// <para>Join Table Field</para>
		/// <para>连接表中的字段，其中包含连接所依据的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID", "GlobalID")]
		public object Join_Field { get; set; }

		/// <summary>
		/// <para>Transfer Fields</para>
		/// <para>来自连接表的、将基于输入表和连接表之间的连接传输至输入表的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "GUID")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Transfer Method</para>
		/// <para>指定如何将连接字段和字段类型传输到输出。</para>
		/// <para>NOT_USE_FM—连接表中的字段和字段类型将传输到输出。 这是默认设置。</para>
		/// <para>USE_FM—从连接表到输出的字段和字段类型的传输将由字段映射参数控制。</para>
		/// <para>指定如何将连接字段和字段类型传输到输出。</para>
		/// <para>NOT_USE_FM—连接表中的字段和字段类型将传输到输出。 这是默认设置。</para>
		/// <para>USE_FM—从连接表到输出的字段和字段类型的传输将由 field_mapping 参数控制。</para>
		/// <para><see cref="FmOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FmOption { get; set; } = "NOT_USE_FM";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>输出中将包括的具有相应字段属性和源字段的属性字段。 默认情况下，将包括输入的所有字段。</para>
		/// <para>可以添加、删除、重命名和重新排序字段，且可以更改其属性。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。 有多种合并规则可用于确定如何用值填充输出字段。</para>
		/// <para>First - 使用输入字段的第一个值。</para>
		/// <para>Last - 使用输入字段的最后一个值。</para>
		/// <para>Join - 串连（连接）输入字段的值。</para>
		/// <para>Sum - 计算输入字段值的总和。</para>
		/// <para>Mean - 计算输入字段值的平均值。</para>
		/// <para>Median - 计算输入字段值的中值。</para>
		/// <para>Mode - 使用具有最高频率的值。</para>
		/// <para>Min - 使用所有输入字段值中的最小值。</para>
		/// <para>Max - 使用所有输入字段值中的最大值。</para>
		/// <para>Standard deviation - 对所有输入字段值使用标准差分类方法。</para>
		/// <para>Count - 查找计算中所包含的记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JoinField SetEnviroment(int? autoCommit = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transfer Method</para>
		/// </summary>
		public enum FmOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NOT_USE_FM")]
			[Description("选择传输字段")]
			Select_transfer_fields,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("USE_FM")]
			[Description("使用字段映射")]
			Use_field_mapping,

		}

#endregion
	}
}
