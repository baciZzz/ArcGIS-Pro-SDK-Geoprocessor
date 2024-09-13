using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Create Parcel Records</para>
	/// <para>创建宗地记录</para>
	/// <para>使用记录名称字段或表达式为输入宗地结构要素创建宗地记录。</para>
	/// </summary>
	public class CreateParcelRecords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFeatures">
		/// <para>Parcel Features</para>
		/// <para>用于创建宗地记录的输入宗地要素。输入宗地要素可以来自文件地理数据库或企业级地理数据库中的宗地结构。</para>
		/// </param>
		public CreateParcelRecords(object InParcelFeatures)
		{
			this.InParcelFeatures = InParcelFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建宗地记录</para>
		/// </summary>
		public override string DisplayName() => "创建宗地记录";

		/// <summary>
		/// <para>Tool Name : CreateParcelRecords</para>
		/// </summary>
		public override string ToolName() => "CreateParcelRecords";

		/// <summary>
		/// <para>Tool Excute Name : parcel.CreateParcelRecords</para>
		/// </summary>
		public override string ExcuteName() => "parcel.CreateParcelRecords";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFeatures, RecordField, OutRecordFeatureClass, UpdatedParcelFabric, RecordExpression, RecordNameMethod };

		/// <summary>
		/// <para>Parcel Features</para>
		/// <para>用于创建宗地记录的输入宗地要素。输入宗地要素可以来自文件地理数据库或企业级地理数据库中的宗地结构。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InParcelFeatures { get; set; }

		/// <summary>
		/// <para>Record Field</para>
		/// <para>包含记录名称的属性字段。属性字段必须是文本字段，并且必须包含与其关联的宗地要素相对应的宗地记录名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RecordField { get; set; }

		/// <summary>
		/// <para>Output Records Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutRecordFeatureClass { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Record Expression</para>
		/// <para>此 Arcade 表达式使用字段、字符串运算符和数学运算符表示记录名称。例如，表达式 Left($feature.Name,4) 从宗地结构面要素类的宗地名称字段中提取前四个字符来创建记录名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object RecordExpression { get; set; }

		/// <summary>
		/// <para>Record Name Method</para>
		/// <para>指定用于创建宗地记录的方法。</para>
		/// <para>字段—将使用输入宗地要素上文本字段中的记录名称创建宗地记录。这是默认设置。</para>
		/// <para>表达式—将使用 Arcade 表达式创建宗地记录。</para>
		/// <para><see cref="RecordNameMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RecordNameMethod { get; set; } = "FIELD";

		#region InnerClass

		/// <summary>
		/// <para>Record Name Method</para>
		/// </summary>
		public enum RecordNameMethodEnum 
		{
			/// <summary>
			/// <para>字段—将使用输入宗地要素上文本字段中的记录名称创建宗地记录。这是默认设置。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

			/// <summary>
			/// <para>表达式—将使用 Arcade 表达式创建宗地记录。</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("表达式")]
			Expression,

		}

#endregion
	}
}
