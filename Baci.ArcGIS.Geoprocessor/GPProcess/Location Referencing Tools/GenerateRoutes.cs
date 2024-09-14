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
	/// <para>Generate Routes</para>
	/// <para>生成路径</para>
	/// <para>为 LRS 网络中的路径要素重新创建形状并应用校准更改。</para>
	/// </summary>
	public class GenerateRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRouteFeatures">
		/// <para>Input Route Features</para>
		/// <para>将为其重新生成路径形状并应用校准更改的 LRS 网络。</para>
		/// </param>
		public GenerateRoutes(object InRouteFeatures)
		{
			this.InRouteFeatures = InRouteFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成路径</para>
		/// </summary>
		public override string DisplayName() => "生成路径";

		/// <summary>
		/// <para>Tool Name : GenerateRoutes</para>
		/// </summary>
		public override string ToolName() => "GenerateRoutes";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateRoutes</para>
		/// </summary>
		public override string ExcuteName() => "locref.GenerateRoutes";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRouteFeatures, RecordCalibrationChanges!, OutRouteFeatures!, OutDerivedRouteFeatures!, OutDetailsFile! };

		/// <summary>
		/// <para>Input Route Features</para>
		/// <para>将为其重新生成路径形状并应用校准更改的 LRS 网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRouteFeatures { get; set; }

		/// <summary>
		/// <para>Record calibration changes for event location updates</para>
		/// <para>指定是否会应用事件行为。</para>
		/// <para>选中 - 在 Location Referencing 工具之外创建、修改或删除的任何校准点都将应用于网络中的路径，并且事件行为将在下次运行应用事件行为时应用。</para>
		/// <para>未选中 - 校准更改将应用于 LRS 网络中的路径，但不会应用任何事件行为。 这是默认设置。</para>
		/// <para><see cref="RecordCalibrationChangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RecordCalibrationChanges { get; set; } = "false";

		/// <summary>
		/// <para>Output Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Derived Route Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutDerivedRouteFeatures { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRoutes SetEnviroment(object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Record calibration changes for event location updates</para>
		/// </summary>
		public enum RecordCalibrationChangesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECORD_CALIBRATION_CHANGES")]
			RECORD_CALIBRATION_CHANGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECORD_CALIBRATION_CHANGES")]
			NO_RECORD_CALIBRATION_CHANGES,

		}

#endregion
	}
}
