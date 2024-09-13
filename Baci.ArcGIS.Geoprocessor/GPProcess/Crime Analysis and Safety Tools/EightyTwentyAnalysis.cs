using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>80-20 Analysis</para>
	/// <para>80-20 分析</para>
	/// <para>执行要素的 80/20 分析，并根据关联事件点的数量创建点聚类、线或面。 此工具将计算一个累积的百分比字段，用于标识事件不成比例发生的位置。</para>
	/// </summary>
	public class EightyTwentyAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Point Features</para>
		/// <para>将用于创建聚类、线或面的输入点要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// <para>当将聚合方法参数设置为聚类时，输出将为点要素类。</para>
		/// <para>当将聚合方法参数设置为最近要素时，输出的几何类型将与输入比较要素参数值相同。</para>
		/// </param>
		public EightyTwentyAnalysis(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 80-20 分析</para>
		/// </summary>
		public override string DisplayName() => "80-20 分析";

		/// <summary>
		/// <para>Tool Name : EightyTwentyAnalysis</para>
		/// </summary>
		public override string ToolName() => "EightyTwentyAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : ca.EightyTwentyAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "ca.EightyTwentyAnalysis";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, ClusterTolerance!, OutFields!, AggregationMethod!, InComparisonFeatures! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>将用于创建聚类、线或面的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// <para>当将聚合方法参数设置为聚类时，输出将为点要素类。</para>
		/// <para>当将聚合方法参数设置为最近要素时，输出的几何类型将与输入比较要素参数值相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Cluster Tolerance</para>
		/// <para>用于分隔点的最大距离，该距离内的点将视为相同聚类的一部分。</para>
		/// <para>如果未指定聚类容差，则该工具将创建点要素重叠的聚类。</para>
		/// <para>当将聚合方法参数设置为聚类时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>输入要素的字段将传递到输出中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Text", "Float", "Double", "Short", "Long", "Date")]
		public object? OutFields { get; set; }

		/// <summary>
		/// <para>Aggregation Method</para>
		/// <para>指定输入点要素的聚合方式。</para>
		/// <para>聚类—将聚类输入点要素。 这是默认设置。</para>
		/// <para>最近的要素—输入点要素将聚合到最近的比较面或线要素。</para>
		/// <para><see cref="AggregationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AggregationMethod { get; set; } = "POINT_CLUSTER";

		/// <summary>
		/// <para>Input Comparison Features</para>
		/// <para>聚合输入点要素参数值所依据的比较输入面或线要素类。</para>
		/// <para>当将聚合方法参数设置为最近要素时，此参数处于活动状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object? InComparisonFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EightyTwentyAnalysis SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainAttachments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Aggregation Method</para>
		/// </summary>
		public enum AggregationMethodEnum 
		{
			/// <summary>
			/// <para>聚类—将聚类输入点要素。 这是默认设置。</para>
			/// </summary>
			[GPValue("POINT_CLUSTER")]
			[Description("聚类")]
			Cluster,

			/// <summary>
			/// <para>最近的要素—输入点要素将聚合到最近的比较面或线要素。</para>
			/// </summary>
			[GPValue("CLOSEST_FEATURE")]
			[Description("最近的要素")]
			Closest_Feature,

		}

#endregion
	}
}
