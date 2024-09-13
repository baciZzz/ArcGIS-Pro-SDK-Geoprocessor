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
	/// <para>Symmetrical Difference</para>
	/// <para>交集取反</para>
	/// <para>用于计算输入要素和更新要素的几何交集并返回未重叠的输入要素和更新要素。 输入要素和更新要素中不叠置的要素或要素的各部分将被写入到输出要素类。</para>
	/// </summary>
	public class SymDiff : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。</para>
		/// </param>
		/// <param name="UpdateFeatures">
		/// <para>Update Features</para>
		/// <para>更新要素类或图层。 其几何类型必须与输入要素类或图层的几何类型相同。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将要写入结果的要素类。</para>
		/// </param>
		public SymDiff(object InFeatures, object UpdateFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.UpdateFeatures = UpdateFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 交集取反</para>
		/// </summary>
		public override string DisplayName() => "交集取反";

		/// <summary>
		/// <para>Tool Name : SymDiff</para>
		/// </summary>
		public override string ToolName() => "SymDiff";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SymDiff</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SymDiff";

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
		public override object[] Parameters() => new object[] { InFeatures, UpdateFeatures, OutFeatureClass, JoinAttributes!, ClusterTolerance! };

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
		/// <para>Update Features</para>
		/// <para>更新要素类或图层。 其几何类型必须与输入要素类或图层的几何类型相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object UpdateFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将要写入结果的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes to Join</para>
		/// <para>指定要传递到输出要素类的属性。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。 这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—除 FID 外，将输入要素的其余所有属性都传递到输出要素类。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinAttributes { get; set; } = "ALL";

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
		public SymDiff SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , bool? qualifiedFieldNames = null , bool? transferGDBAttributeProperties = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, transferGDBAttributeProperties: transferGDBAttributeProperties);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes to Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>除要素 ID 外的所有属性—除 FID 外，将输入要素的其余所有属性都传递到输出要素类。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除要素 ID 外的所有属性")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_feature_IDs,

			/// <summary>
			/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_attributes,

		}

#endregion
	}
}
