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
	/// <para>Update</para>
	/// <para>更新</para>
	/// <para>计算输入要素和更新要素的几何交集。 输入要素的属性和几何根据输出要素类中的更新要素来进行更新。</para>
	/// </summary>
	public class Update : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。 该几何类型必须为面。</para>
		/// </param>
		/// <param name="UpdateFeatures">
		/// <para>Update Features</para>
		/// <para>更新输入要素时使用的要素。 该几何类型必须为面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含结果的要素类。</para>
		/// </param>
		public Update(object InFeatures, object UpdateFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.UpdateFeatures = UpdateFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新</para>
		/// </summary>
		public override string DisplayName() => "更新";

		/// <summary>
		/// <para>Tool Name : 更新</para>
		/// </summary>
		public override string ToolName() => "更新";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Update</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Update";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames", "transferGDBAttributeProperties" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, UpdateFeatures, OutFeatureClass, KeepBorders!, ClusterTolerance! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。 该几何类型必须为面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Update Features</para>
		/// <para>更新输入要素时使用的要素。 该几何类型必须为面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object UpdateFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含结果的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Borders</para>
		/// <para>指定是否保留更新面要素的边界。</para>
		/// <para>选中 - 更新要素参数值的外边界将保留在输出要素类参数值中。 这是默认设置。</para>
		/// <para>未选中 - 更新要素参数值的外边界在插入输入要素参数值之后将不会保留。 更新要素的项目值优先于输入要素参数值属性。</para>
		/// <para><see cref="KeepBordersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepBorders { get; set; } = "true";

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
		public Update SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , bool? qualifiedFieldNames = null , bool? transferGDBAttributeProperties = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, transferGDBAttributeProperties: transferGDBAttributeProperties);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Borders</para>
		/// </summary>
		public enum KeepBordersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BORDERS")]
			BORDERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BORDERS")]
			NO_BORDERS,

		}

#endregion
	}
}
