using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Collect Events</para>
	/// <para>收集事件</para>
	/// <para>将事件数据(如犯罪或疾病事件点)转换为加权点数据。</para>
	/// </summary>
	public class CollectEvents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputIncidentFeatures">
		/// <para>Input Incident Features</para>
		/// <para>表示事件或事件点数据的要素。</para>
		/// </param>
		/// <param name="OutputWeightedPointFeatureClass">
		/// <para>Output Weighted Point Feature Class</para>
		/// <para>包含加权点数据的输出要素类。</para>
		/// </param>
		public CollectEvents(object InputIncidentFeatures, object OutputWeightedPointFeatureClass)
		{
			this.InputIncidentFeatures = InputIncidentFeatures;
			this.OutputWeightedPointFeatureClass = OutputWeightedPointFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 收集事件</para>
		/// </summary>
		public override string DisplayName() => "收集事件";

		/// <summary>
		/// <para>Tool Name : CollectEvents</para>
		/// </summary>
		public override string ToolName() => "CollectEvents";

		/// <summary>
		/// <para>Tool Excute Name : stats.CollectEvents</para>
		/// </summary>
		public override string ExcuteName() => "stats.CollectEvents";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputIncidentFeatures, OutputWeightedPointFeatureClass, ResultsField, ZMaxValue };

		/// <summary>
		/// <para>Input Incident Features</para>
		/// <para>表示事件或事件点数据的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputIncidentFeatures { get; set; }

		/// <summary>
		/// <para>Output Weighted Point Feature Class</para>
		/// <para>包含加权点数据的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputWeightedPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Results Field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object ResultsField { get; set; } = "Count";

		/// <summary>
		/// <para>Z Max Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object ZMaxValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CollectEvents SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
