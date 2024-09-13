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
	/// <para>Create LRS From Existing Dataset</para>
	/// <para>基于现有数据集创建 LRS</para>
	/// <para>使用现有数据集在指定工作空间中创建线性参考系统 (LRS)。</para>
	/// </summary>
	public class CreateLRSFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>要创建的 LRS 的名称。 该名称不能已存在于地理数据库中。</para>
		/// </param>
		/// <param name="CenterlineFeatureClass">
		/// <para>Centerline - Feature Class</para>
		/// <para>在 LRS 中用作中心线的要素类。</para>
		/// </param>
		/// <param name="CenterlineCenterlineIdField">
		/// <para>Centerline - Centerline ID Field</para>
		/// <para>包含中心线 ID 的 GUID 字段。 字段类型必须与中心线序列表中的 centerlineID 字段类型匹配。</para>
		/// </param>
		/// <param name="CenterlineSequenceTable">
		/// <para>Centerline Sequence - Table</para>
		/// <para>在 LRS 中用作中心线序列的表。</para>
		/// </param>
		/// <param name="CenterlineSequenceCenterlineIdField">
		/// <para>Centerline Sequence - Centerline ID Field</para>
		/// <para>包含中心线序列 ID 的 GUID 字段。 字段类型必须与中心线要素类中的 centerlineID 字段类型和长度匹配。</para>
		/// </param>
		/// <param name="CenterlineSequenceRouteIdField">
		/// <para>Centerline Sequence - Route ID Field</para>
		/// <para>包含中心线序列路径 ID 的 GUID 或文本字段。 字段类型必须与校准点和红线要素类中的 routeID 字段类型和长度匹配。</para>
		/// </param>
		/// <param name="CenterlineSequenceFromDateField">
		/// <para>Centerline Sequence - From Date Field</para>
		/// <para>包含中心线序列开始日期的日期字段。</para>
		/// </param>
		/// <param name="CenterlineSequenceToDateField">
		/// <para>Centerline Sequence - To Date Field</para>
		/// <para>包含中心线序列结束日期的日期字段。</para>
		/// </param>
		/// <param name="CenterlineSequenceNetworkIdField">
		/// <para>Centerline Sequence - Network ID Field</para>
		/// <para>包含中心线序列网络 ID 的字段。 支持短整型字段类型。</para>
		/// </param>
		/// <param name="CalibrationPointFeatureClass">
		/// <para>Calibration Point - Feature Class</para>
		/// <para>在 LRS 中用作校准点的要素类。</para>
		/// </param>
		/// <param name="CalibrationPointMeasureField">
		/// <para>Calibration Point - Measure Field</para>
		/// <para>包含校准点测量值的字段。 支持双精度字段类型。</para>
		/// </param>
		/// <param name="CalibrationPointFromDateField">
		/// <para>Calibration Point - From Date Field</para>
		/// <para>包含校准点开始日期的日期字段。</para>
		/// </param>
		/// <param name="CalibrationPointToDateField">
		/// <para>Calibration Point - To Date Field</para>
		/// <para>包含校准点结束日期的日期字段。</para>
		/// </param>
		/// <param name="CalibrationPointRouteIdField">
		/// <para>Calibration Point - Route ID Field</para>
		/// <para>包含校准点路径 ID 的字段。 支持 GUID 和文本字段类型。 字段类型必须与中心线序列表和红线要素类中的 routeID 字段类型和长度匹配。</para>
		/// </param>
		/// <param name="CalibrationPointNetworkIdField">
		/// <para>Calibration Point - Network ID Field</para>
		/// <para>包含校准点网络 ID 的字段。 支持短整型字段类型。</para>
		/// </param>
		/// <param name="RedlineFeatureClass">
		/// <para>Redline - Feature Class</para>
		/// <para>在 LRS 中用作红线的要素类。</para>
		/// </param>
		/// <param name="RedlineFromMeasureField">
		/// <para>Redline - From Measure Field</para>
		/// <para>包含红线测量始于的字段。 支持双精度字段类型。</para>
		/// </param>
		/// <param name="RedlineToMeasureField">
		/// <para>Redline - To Measure Field</para>
		/// <para>包含红线测量止于的字段。 支持双精度字段类型。</para>
		/// </param>
		/// <param name="RedlineRouteIdField">
		/// <para>Redline - Route ID Field</para>
		/// <para>包含红线路径 ID 的字段。 支持 GUID 和文本字段类型。 字段类型必须与校准点要素类和中心线序列表中的 routeID 字段类型和长度匹配。</para>
		/// </param>
		/// <param name="RedlineRouteNameField">
		/// <para>Redline - Route Name Field</para>
		/// <para>包含红线路径名称的文本字段。</para>
		/// </param>
		/// <param name="RedlineEffectiveDateField">
		/// <para>Redline - Effective Date Field</para>
		/// <para>包含红线生效日期的日期字段。</para>
		/// </param>
		/// <param name="RedlineActivityTypeField">
		/// <para>Redline - Activity Type Field</para>
		/// <para>包含红线活动类型的字段。 支持短整型字段类型。</para>
		/// </param>
		/// <param name="RedlineNetworkIdField">
		/// <para>Redline - Network ID Field</para>
		/// <para>包含红线网络 ID 的字段。 支持短整型字段类型。</para>
		/// </param>
		public CreateLRSFromExistingDataset(object LrsName, object CenterlineFeatureClass, object CenterlineCenterlineIdField, object CenterlineSequenceTable, object CenterlineSequenceCenterlineIdField, object CenterlineSequenceRouteIdField, object CenterlineSequenceFromDateField, object CenterlineSequenceToDateField, object CenterlineSequenceNetworkIdField, object CalibrationPointFeatureClass, object CalibrationPointMeasureField, object CalibrationPointFromDateField, object CalibrationPointToDateField, object CalibrationPointRouteIdField, object CalibrationPointNetworkIdField, object RedlineFeatureClass, object RedlineFromMeasureField, object RedlineToMeasureField, object RedlineRouteIdField, object RedlineRouteNameField, object RedlineEffectiveDateField, object RedlineActivityTypeField, object RedlineNetworkIdField)
		{
			this.LrsName = LrsName;
			this.CenterlineFeatureClass = CenterlineFeatureClass;
			this.CenterlineCenterlineIdField = CenterlineCenterlineIdField;
			this.CenterlineSequenceTable = CenterlineSequenceTable;
			this.CenterlineSequenceCenterlineIdField = CenterlineSequenceCenterlineIdField;
			this.CenterlineSequenceRouteIdField = CenterlineSequenceRouteIdField;
			this.CenterlineSequenceFromDateField = CenterlineSequenceFromDateField;
			this.CenterlineSequenceToDateField = CenterlineSequenceToDateField;
			this.CenterlineSequenceNetworkIdField = CenterlineSequenceNetworkIdField;
			this.CalibrationPointFeatureClass = CalibrationPointFeatureClass;
			this.CalibrationPointMeasureField = CalibrationPointMeasureField;
			this.CalibrationPointFromDateField = CalibrationPointFromDateField;
			this.CalibrationPointToDateField = CalibrationPointToDateField;
			this.CalibrationPointRouteIdField = CalibrationPointRouteIdField;
			this.CalibrationPointNetworkIdField = CalibrationPointNetworkIdField;
			this.RedlineFeatureClass = RedlineFeatureClass;
			this.RedlineFromMeasureField = RedlineFromMeasureField;
			this.RedlineToMeasureField = RedlineToMeasureField;
			this.RedlineRouteIdField = RedlineRouteIdField;
			this.RedlineRouteNameField = RedlineRouteNameField;
			this.RedlineEffectiveDateField = RedlineEffectiveDateField;
			this.RedlineActivityTypeField = RedlineActivityTypeField;
			this.RedlineNetworkIdField = RedlineNetworkIdField;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于现有数据集创建 LRS</para>
		/// </summary>
		public override string DisplayName() => "基于现有数据集创建 LRS";

		/// <summary>
		/// <para>Tool Name : CreateLRSFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSFromExistingDataset";

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
		public override object[] Parameters() => new object[] { LrsName, CenterlineFeatureClass, CenterlineCenterlineIdField, CenterlineSequenceTable, CenterlineSequenceCenterlineIdField, CenterlineSequenceRouteIdField, CenterlineSequenceFromDateField, CenterlineSequenceToDateField, CenterlineSequenceNetworkIdField, CalibrationPointFeatureClass, CalibrationPointMeasureField, CalibrationPointFromDateField, CalibrationPointToDateField, CalibrationPointRouteIdField, CalibrationPointNetworkIdField, RedlineFeatureClass, RedlineFromMeasureField, RedlineToMeasureField, RedlineRouteIdField, RedlineRouteNameField, RedlineEffectiveDateField, RedlineActivityTypeField, RedlineNetworkIdField, OutPath! };

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>要创建的 LRS 的名称。 该名称不能已存在于地理数据库中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>Centerline - Feature Class</para>
		/// <para>在 LRS 中用作中心线的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Centerline")]
		public object CenterlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Centerline - Centerline ID Field</para>
		/// <para>包含中心线 ID 的 GUID 字段。 字段类型必须与中心线序列表中的 centerlineID 字段类型匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline")]
		public object CenterlineCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Table</para>
		/// <para>在 LRS 中用作中心线序列的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceTable { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Centerline ID Field</para>
		/// <para>包含中心线序列 ID 的 GUID 字段。 字段类型必须与中心线要素类中的 centerlineID 字段类型和长度匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("GUID", "Text")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceCenterlineIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Route ID Field</para>
		/// <para>包含中心线序列路径 ID 的 GUID 或文本字段。 字段类型必须与校准点和红线要素类中的 routeID 字段类型和长度匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceRouteIdField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - From Date Field</para>
		/// <para>包含中心线序列开始日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceFromDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - To Date Field</para>
		/// <para>包含中心线序列结束日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceToDateField { get; set; }

		/// <summary>
		/// <para>Centerline Sequence - Network ID Field</para>
		/// <para>包含中心线序列网络 ID 的字段。 支持短整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Centerline Sequence")]
		public object CenterlineSequenceNetworkIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Feature Class</para>
		/// <para>在 LRS 中用作校准点的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[Category("Calibration Point")]
		public object CalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibration Point - Measure Field</para>
		/// <para>包含校准点测量值的字段。 支持双精度字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Calibration Point")]
		public object CalibrationPointMeasureField { get; set; }

		/// <summary>
		/// <para>Calibration Point - From Date Field</para>
		/// <para>包含校准点开始日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object CalibrationPointFromDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - To Date Field</para>
		/// <para>包含校准点结束日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Calibration Point")]
		public object CalibrationPointToDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Route ID Field</para>
		/// <para>包含校准点路径 ID 的字段。 支持 GUID 和文本字段类型。 字段类型必须与中心线序列表和红线要素类中的 routeID 字段类型和长度匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Calibration Point")]
		public object CalibrationPointRouteIdField { get; set; }

		/// <summary>
		/// <para>Calibration Point - Network ID Field</para>
		/// <para>包含校准点网络 ID 的字段。 支持短整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Calibration Point")]
		public object CalibrationPointNetworkIdField { get; set; }

		/// <summary>
		/// <para>Redline - Feature Class</para>
		/// <para>在 LRS 中用作红线的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Redline")]
		public object RedlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Redline - From Measure Field</para>
		/// <para>包含红线测量始于的字段。 支持双精度字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object RedlineFromMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - To Measure Field</para>
		/// <para>包含红线测量止于的字段。 支持双精度字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		[Category("Redline")]
		public object RedlineToMeasureField { get; set; }

		/// <summary>
		/// <para>Redline - Route ID Field</para>
		/// <para>包含红线路径 ID 的字段。 支持 GUID 和文本字段类型。 字段类型必须与校准点要素类和中心线序列表中的 routeID 字段类型和长度匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GUID")]
		[Category("Redline")]
		public object RedlineRouteIdField { get; set; }

		/// <summary>
		/// <para>Redline - Route Name Field</para>
		/// <para>包含红线路径名称的文本字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		[Category("Redline")]
		public object RedlineRouteNameField { get; set; }

		/// <summary>
		/// <para>Redline - Effective Date Field</para>
		/// <para>包含红线生效日期的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		[Category("Redline")]
		public object RedlineEffectiveDateField { get; set; }

		/// <summary>
		/// <para>Redline - Activity Type Field</para>
		/// <para>包含红线活动类型的字段。 支持短整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object RedlineActivityTypeField { get; set; }

		/// <summary>
		/// <para>Redline - Network ID Field</para>
		/// <para>包含红线网络 ID 的字段。 支持短整型字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short")]
		[Category("Redline")]
		public object RedlineNetworkIdField { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutPath { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRSFromExistingDataset SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
