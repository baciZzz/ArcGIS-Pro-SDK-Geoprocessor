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
	/// <para>Calculate End Time</para>
	/// <para>计算结束时间</para>
	/// <para>根据存储在另一个字段中的时间值计算要素的结束时间。</para>
	/// </summary>
	public class CalculateEndTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>根据指定的开始时间字段计算结束时间字段的要素类或表。</para>
		/// </param>
		/// <param name="StartField">
		/// <para>Start Time Field</para>
		/// <para>包含的值要用来计算结束时间字段值的字段。开始时间字段和结束时间字段的类型必须相同。例如，如果开始时间字段的类型为 LONG，则结束时间字段的类型也应该为 LONG。</para>
		/// </param>
		/// <param name="EndField">
		/// <para>End Time Field</para>
		/// <para>将使用基于指定的开始时间字段的值进行填充的字段。开始时间字段和结束时间字段的格式必须相同。</para>
		/// </param>
		public CalculateEndTime(object InTable, object StartField, object EndField)
		{
			this.InTable = InTable;
			this.StartField = StartField;
			this.EndField = EndField;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算结束时间</para>
		/// </summary>
		public override string DisplayName() => "计算结束时间";

		/// <summary>
		/// <para>Tool Name : CalculateEndTime</para>
		/// </summary>
		public override string ToolName() => "CalculateEndTime";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateEndTime</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateEndTime";

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
		public override object[] Parameters() => new object[] { InTable, StartField, EndField, Fields!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>根据指定的开始时间字段计算结束时间字段的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>包含的值要用来计算结束时间字段值的字段。开始时间字段和结束时间字段的类型必须相同。例如，如果开始时间字段的类型为 LONG，则结束时间字段的类型也应该为 LONG。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object StartField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>将使用基于指定的开始时间字段的值进行填充的字段。开始时间字段和结束时间字段的格式必须相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object EndField { get; set; }

		/// <summary>
		/// <para>ID Fields</para>
		/// <para>可用于唯一识别空间实体的一个或多个字段的名称。如果存在多个实体，则首先根据实体类型对这些字段进行排序。例如，某个要素类表示各个州随时间变化的人口值，则州名称可作为唯一值字段（实体）。如果人口图是按县绘制的，则需要将县名称和州名称设置为唯一值字段，因为不同州的某些县名称是相同的。如果只有一个实体，则可忽略该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateEndTime SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
