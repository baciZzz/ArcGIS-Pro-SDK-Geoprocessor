using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Pairwise Clip</para>
	/// <para>成对裁剪</para>
	/// <para>提取与裁剪要素相重叠的输入要素。</para>
	/// </summary>
	public class PairwiseClip : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要裁剪的要素。</para>
		/// </param>
		/// <param name="ClipFeatures">
		/// <para>Clip Features</para>
		/// <para>用于裁剪输入要素的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>待创建的要素类。</para>
		/// </param>
		public PairwiseClip(object InFeatures, object ClipFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ClipFeatures = ClipFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 成对裁剪</para>
		/// </summary>
		public override string DisplayName() => "成对裁剪";

		/// <summary>
		/// <para>Tool Name : PairwiseClip</para>
		/// </summary>
		public override string ToolName() => "PairwiseClip";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseClip</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseClip";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "maintainCurveSegments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "transferGDBAttributeProperties" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ClipFeatures, OutFeatureClass, ClusterTolerance! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要裁剪的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>用于裁剪输入要素的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object ClipFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>待创建的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>所有要素坐标（节点和折点）之间的最小距离以及坐标可以沿 x 和/或 y 方向移动的距离。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。 建议不要修改此参数。 已将其从工具对话框的视图中移除。 默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseClip SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? configKeyword = null , object? extent = null , bool? maintainCurveSegments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , bool? transferGDBAttributeProperties = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, maintainCurveSegments: maintainCurveSegments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, transferGDBAttributeProperties: transferGDBAttributeProperties);
			return this;
		}

	}
}
