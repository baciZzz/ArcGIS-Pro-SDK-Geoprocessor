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
	/// <para>Enable Editor Tracking</para>
	/// <para>启用编辑者追踪</para>
	/// <para>用于在地理数据库中对要素类、表、要素数据集或关系类启用编辑者追踪。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EnableEditorTracking : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要启用编辑者追踪的要素类、表、要素数据集、 或关系类。</para>
		/// </param>
		public EnableEditorTracking(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 启用编辑者追踪</para>
		/// </summary>
		public override string DisplayName() => "启用编辑者追踪";

		/// <summary>
		/// <para>Tool Name : EnableEditorTracking</para>
		/// </summary>
		public override string ToolName() => "EnableEditorTracking";

		/// <summary>
		/// <para>Tool Excute Name : management.EnableEditorTracking</para>
		/// </summary>
		public override string ExcuteName() => "management.EnableEditorTracking";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, CreatorField, CreationDateField, LastEditorField, LastEditDateField, AddFields, RecordDatesIn, OutDataset };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要启用编辑者追踪的要素类、表、要素数据集、 或关系类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Creator Field</para>
		/// <para>字段的名称，该字段将存储创建要素或记录的用户的名称。如果此字段已存在，它必须为字符串型的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CreatorField { get; set; }

		/// <summary>
		/// <para>Creation Date Field</para>
		/// <para>字段的名称，该字段将存储创建要素或记录的日期。如果此字段已存在，它必须为日期型的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CreationDateField { get; set; }

		/// <summary>
		/// <para>Last Editor Field</para>
		/// <para>字段的名称，该字段将存储上次编辑要素或记录的用户的名称。如果此字段已存在，它必须为字符串型的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object LastEditorField { get; set; }

		/// <summary>
		/// <para>Last Edit Date Field</para>
		/// <para>字段的名称，该字段将存储上次编辑要素或记录的日期。如果此字段已存在，它必须为日期型的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object LastEditDateField { get; set; }

		/// <summary>
		/// <para>Add fields</para>
		/// <para>指定如果字段不存在是否添加字段。</para>
		/// <para>未选中 - 不添加字段。指定的字段必须在输入数据集中已存在。这是默认设置。</para>
		/// <para>选中 - 如果字段不存在，则添加字段。您必须指定要在以下参数中添加的字段名称：创建者字段、创建日期字段、上一个编辑者字段和最后一次编辑日期字段。</para>
		/// <para><see cref="AddFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddFields { get; set; } = "false";

		/// <summary>
		/// <para>Record Dates in</para>
		/// <para>记录创建日期和最后一次编辑日期采取的时间格式。默认值为 UTC。</para>
		/// <para>UTC（协调世界时间）—日期将以 UTC 进行记录。这是默认设置。</para>
		/// <para>数据库的时区—日期将以数据库所在的时区进行记录。</para>
		/// <para><see cref="RecordDatesInEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RecordDatesIn { get; set; } = "UTC";

		/// <summary>
		/// <para>Modified Input Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEDatasetType()]
		public object OutDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Add fields</para>
		/// </summary>
		public enum AddFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_FIELDS")]
			ADD_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ADD_FIELDS")]
			NO_ADD_FIELDS,

		}

		/// <summary>
		/// <para>Record Dates in</para>
		/// </summary>
		public enum RecordDatesInEnum 
		{
			/// <summary>
			/// <para>UTC（协调世界时间）—日期将以 UTC 进行记录。这是默认设置。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC（协调世界时间）")]
			UTC,

			/// <summary>
			/// <para>数据库的时区—日期将以数据库所在的时区进行记录。</para>
			/// </summary>
			[GPValue("DATABASE_TIME")]
			[Description("数据库的时区")]
			Time_zone_of_database,

		}

#endregion
	}
}
