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
	/// <para>Pairwise Erase</para>
	/// <para>成对擦除</para>
	/// <para>计算输入和擦除要素的成对交集。 只将输入要素处于擦除要素之外的部分复制到输出要素类。</para>
	/// </summary>
	public class PairwiseErase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。</para>
		/// </param>
		/// <param name="EraseFeatures">
		/// <para>Erase Features</para>
		/// <para>用于擦除重叠输入要素的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </param>
		public PairwiseErase(object InFeatures, object EraseFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.EraseFeatures = EraseFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 成对擦除</para>
		/// </summary>
		public override string DisplayName() => "成对擦除";

		/// <summary>
		/// <para>Tool Name : PairwiseErase</para>
		/// </summary>
		public override string ToolName() => "PairwiseErase";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseErase</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseErase";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "maintainCurveSegments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames", "transferGDBAttributeProperties" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, EraseFeatures, OutFeatureClass, ClusterTolerance! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Erase Features</para>
		/// <para>用于擦除重叠输入要素的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object EraseFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
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
		public PairwiseErase SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , bool? maintainCurveSegments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , bool? qualifiedFieldNames = null , bool? transferGDBAttributeProperties = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, maintainCurveSegments: maintainCurveSegments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, transferGDBAttributeProperties: transferGDBAttributeProperties);
			return this;
		}

	}
}
