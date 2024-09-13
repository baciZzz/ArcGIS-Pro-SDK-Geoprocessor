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
	/// <para>Create LRS</para>
	/// <para>创建 LRS</para>
	/// <para>在指定工作空间中创建 ArcGIS Location Referencing 线性参考系统 (LRS) 和最小模式项目。</para>
	/// </summary>
	public class CreateLRS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Location</para>
		/// <para>将在其中创建 LRS 和最小模式的文件或多用途地理数据库。</para>
		/// </param>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>输出 LRS 的名称。</para>
		/// </param>
		/// <param name="CenterlineFeatureClassName">
		/// <para>Centerline Feature Class Name</para>
		/// <para>输出中心线要素类的名称。</para>
		/// </param>
		/// <param name="CalibrationPointFeatureClassName">
		/// <para>Calibration Point Feature Class Name</para>
		/// <para>输出校准点要素类的名称。</para>
		/// </param>
		/// <param name="RedlineFeatureClassName">
		/// <para>Redline Feature Class Name</para>
		/// <para>输出红线要素类的名称。</para>
		/// </param>
		/// <param name="CenterlineSequenceTableName">
		/// <para>Centerline Sequence Table Name</para>
		/// <para>输出中心线序列表的名称。</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Spatial Reference</para>
		/// <para>输出要素类的空间参考。 使用 Python 脚本时，可以将熟知 ID (WKID) 用作空间参考。</para>
		/// </param>
		public CreateLRS(object InWorkspace, object LrsName, object CenterlineFeatureClassName, object CalibrationPointFeatureClassName, object RedlineFeatureClassName, object CenterlineSequenceTableName, object SpatialReference)
		{
			this.InWorkspace = InWorkspace;
			this.LrsName = LrsName;
			this.CenterlineFeatureClassName = CenterlineFeatureClassName;
			this.CalibrationPointFeatureClassName = CalibrationPointFeatureClassName;
			this.RedlineFeatureClassName = RedlineFeatureClassName;
			this.CenterlineSequenceTableName = CenterlineSequenceTableName;
			this.SpatialReference = SpatialReference;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 LRS</para>
		/// </summary>
		public override string DisplayName() => "创建 LRS";

		/// <summary>
		/// <para>Tool Name : CreateLRS</para>
		/// </summary>
		public override string ToolName() => "CreateLRS";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRS</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRS";

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
		public override object[] Parameters() => new object[] { InWorkspace, LrsName, CenterlineFeatureClassName, CalibrationPointFeatureClassName, RedlineFeatureClassName, CenterlineSequenceTableName, SpatialReference, XyTolerance!, ZTolerance!, XyResolution!, ZResolution!, OutWorkspace!, OutCenterlineFeatureClass!, OutCalibrationPointFeatureClass!, OutRedlineFeatureClass!, OutCenterlineSequenceTable! };

		/// <summary>
		/// <para>Input Location</para>
		/// <para>将在其中创建 LRS 和最小模式的文件或多用途地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>输出 LRS 的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>Centerline Feature Class Name</para>
		/// <para>输出中心线要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CenterlineFeatureClassName { get; set; } = "Centerline";

		/// <summary>
		/// <para>Calibration Point Feature Class Name</para>
		/// <para>输出校准点要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CalibrationPointFeatureClassName { get; set; } = "Calibration_Point";

		/// <summary>
		/// <para>Redline Feature Class Name</para>
		/// <para>输出红线要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RedlineFeatureClassName { get; set; } = "Redline";

		/// <summary>
		/// <para>Centerline Sequence Table Name</para>
		/// <para>输出中心线序列表的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CenterlineSequenceTableName { get; set; } = "Centerline_Sequence";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出要素类的空间参考。 使用 Python 脚本时，可以将熟知 ID (WKID) 用作空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>输出要素类的 x,y 容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>输出要素类的 z 容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ZTolerance { get; set; }

		/// <summary>
		/// <para>XY Resolution</para>
		/// <para>输出要素类的 x、y 分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyResolution { get; set; }

		/// <summary>
		/// <para>Z Resolution</para>
		/// <para>输出要素类的 z 分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ZResolution { get; set; }

		/// <summary>
		/// <para>Updated Input Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Output Centerline Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutCenterlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Calibration Point Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutCalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Redline Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutRedlineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Centerline Sequence Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutCenterlineSequenceTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRS SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
