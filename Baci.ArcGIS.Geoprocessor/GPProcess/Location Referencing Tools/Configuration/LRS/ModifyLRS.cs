using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Modify LRS</para>
	/// <para>修改 LRS</para>
	/// <para>修改指定工作空间中的现有线性参考系统 (LRS)。</para>
	/// </summary>
	public class ModifyLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>LRS 工作空间。</para>
		/// </param>
		/// <param name="CurrentLrsName">
		/// <para>Current LRS Name</para>
		/// <para>当前 LRS 名称。</para>
		/// </param>
		public ModifyLRS(object InWorkspace, object CurrentLrsName)
		{
			this.InWorkspace = InWorkspace;
			this.CurrentLrsName = CurrentLrsName;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改 LRS</para>
		/// </summary>
		public override string DisplayName() => "修改 LRS";

		/// <summary>
		/// <para>Tool Name : ModifyLRS</para>
		/// </summary>
		public override string ToolName() => "ModifyLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRS";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, CurrentLrsName, NewLrsName!, CenterlineFeatureClass!, CenterlineCenterlineIdField!, CenterlineSequenceTable!, CenterlineSequenceCenterlineIdField!, CenterlineSequenceRouteIdField!, CenterlineSequenceFromDateField!, CenterlineSequenceToDateField!, CenterlineSequenceNetworkIdField!, CalibrationPointFeatureClass!, CalibrationPointMeasureField!, CalibrationPointFromDateField!, CalibrationPointToDateField!, CalibrationPointRouteIdField!, CalibrationPointNetworkIdField!, RedlineFeatureClass!, RedlineFromMeasureField!, RedlineToMeasureField!, RedlineRouteIdField!, RedlineRouteNameField!, RedlineEffectiveDateField!, RedlineActivityTypeField!, RedlineNetworkIdField!, OutWorkspace!, ConflictPrevention!, MoveToFeatureDataset! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>LRS 工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Current LRS Name</para>
		/// <para>当前 LRS 名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CurrentLrsName { get; set; }

		/// <summary>
		/// <para>New LRS Name</para>
		/// <para>当前 LRS 的新名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NewLrsName { get; set; }

		/// <summary>
		/// <para>Centerline - Feature Class</para>
		/// <para>最小模式的现有中心线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Centerline")]
		public object? CenterlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Centerline - Centerline ID Field</para>
		/// <para>中心线 - 要素类参数值中的中心线 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline")]
		public object? CenterlineCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Table</para>
		/// <para>最小模式的现有中心线序列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		[Category("Centerline Sequence")]
		public object? CenterlineSequenceTable { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Centerline ID Field</para>
		/// <para>中心线序列 - 表参数值中的中心线 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline Sequence")]
		public object? CenterlineSequenceCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Route ID Field</para>
		/// <para>中心线序列 - 表参数值中的路径 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Centerline Sequence")]
		public object? CenterlineSequenceRouteIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - From Date Field</para>
		/// <para>中心线序列 - 表参数值中的开始日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object? CenterlineSequenceFromDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - To Date Field</para>
		/// <para>中心线序列 - 表参数值中的结束日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object? CenterlineSequenceToDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Network ID Field</para>
		/// <para>中心线序列 - 表参数值中的网络 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Centerline Sequence")]
		public object? CenterlineSequenceNetworkIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Feature Class</para>
		/// <para>最小模式的现有校准点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[Category("Calibration Point")]
		public object? CalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibration Point - Measure Field</para>
		/// <para>校准点 - 要素类参数值的测量字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Calibration Point")]
		public object? CalibrationPointMeasureField { get; set; }

		/// <summary>
		/// <para>Calibration Point - From Date Field</para>
		/// <para>校准点 - 要素类参数值的开始日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object? CalibrationPointFromDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - To Date Field</para>
		/// <para>校准点 - 要素类参数值的结束日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object? CalibrationPointToDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Route ID Field</para>
		/// <para>校准点 - 要素类参数值中的路径 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Calibration Point")]
		public object? CalibrationPointRouteIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Network ID Field</para>
		/// <para>校准点 - 要素类参数值中的网络 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Calibration Point")]
		public object? CalibrationPointNetworkIdField { get; set; }

		/// <summary>
		/// <para>Redline - Feature Class</para>
		/// <para>最小模式的现有红线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Redline")]
		public object? RedlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Redline - From Measure Field</para>
		/// <para>红线 - 要素类参数值的测量始于字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object? RedlineFromMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - To  Measure Field</para>
		/// <para>红线 - 要素类参数值的测量止于字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object? RedlineToMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - Route ID Field</para>
		/// <para>红线 - 要素类参数值的路径 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Redline")]
		public object? RedlineRouteIdField { get; set; }

		/// <summary>
		/// <para>Redline - Route Name Field</para>
		/// <para>红线 - 要素类参数值的路径名称字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[Category("Redline")]
		public object? RedlineRouteNameField { get; set; }

		/// <summary>
		/// <para>Redline - Effective Date Field</para>
		/// <para>红线 - 要素类参数值的生效日期字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Redline")]
		public object? RedlineEffectiveDateField { get; set; }

		/// <summary>
		/// <para>Redline - Activity Type Field</para>
		/// <para>红线 - 要素类参数值的活动类型字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object? RedlineActivityTypeField { get; set; }

		/// <summary>
		/// <para>Redline - Network ID Field</para>
		/// <para>红线 - 要素类参数值的网络 ID 字段的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object? RedlineNetworkIdField { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Conflict Prevention</para>
		/// <para>指定是否将为输入 LRS 启用冲突预防。 冲突预防仅在对作为要素服务发布的分支版本化数据进行编辑或执行地理处理时可用。</para>
		/// <para>原样—将使用当前的冲突预防设置。 这是默认设置。</para>
		/// <para>启用—将为输入 LRS 启用冲突预防。</para>
		/// <para>禁用—将为输入 LRS 禁用冲突预防。</para>
		/// <para><see cref="ConflictPreventionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictPrevention { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Move required feature classes to feature dataset</para>
		/// <para>指定是否将要素类移动到所需的 LRS 要素数据集。</para>
		/// <para>选中 - 将要素类移动到所需的 LRS 要素数据集。</para>
		/// <para>未选中 - 不将要素类移动到所需的 LRS 要素数据集。 这是默认设置。</para>
		/// <para><see cref="MoveToFeatureDatasetEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MoveToFeatureDataset { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyLRS SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conflict Prevention</para>
		/// </summary>
		public enum ConflictPreventionEnum 
		{
			/// <summary>
			/// <para>原样—将使用当前的冲突预防设置。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("原样")]
			As_is,

			/// <summary>
			/// <para>启用—将为输入 LRS 启用冲突预防。</para>
			/// </summary>
			[GPValue("ENABLE")]
			[Description("启用")]
			Enable,

			/// <summary>
			/// <para>禁用—将为输入 LRS 禁用冲突预防。</para>
			/// </summary>
			[GPValue("DISABLE")]
			[Description("禁用")]
			Disable,

		}

		/// <summary>
		/// <para>Move required feature classes to feature dataset</para>
		/// </summary>
		public enum MoveToFeatureDatasetEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MOVE")]
			MOVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_MOVE")]
			DO_NOT_MOVE,

		}

#endregion
	}
}
