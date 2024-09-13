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
	/// <para>Identity</para>
	/// <para>标识</para>
	/// <para>计算输入要素和标识要素的几何交集。 输入要素或其与标识要素重叠的部分将获得这些标识要素的属性。</para>
	/// </summary>
	public class Identity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。</para>
		/// </param>
		/// <param name="IdentityFeatures">
		/// <para>Identity Features</para>
		/// <para>标识要素类或图层。 必须是面或具有与输入要素相同的几何类型。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将要创建并在其中写入结果的要素类。</para>
		/// </param>
		public Identity(object InFeatures, object IdentityFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.IdentityFeatures = IdentityFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 标识</para>
		/// </summary>
		public override string DisplayName() => "标识";

		/// <summary>
		/// <para>Tool Name : 标识</para>
		/// </summary>
		public override string ToolName() => "标识";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Identity</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Identity";

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
		public override object[] Parameters() => new object[] { InFeatures, IdentityFeatures, OutFeatureClass, JoinAttributes!, ClusterTolerance!, Relationship! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Identity Features</para>
		/// <para>标识要素类或图层。 必须是面或具有与输入要素相同的几何类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object IdentityFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将要创建并在其中写入结果的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>指定如何将属性传递到输出要素类。</para>
		/// <para>所有属性—输入要素与标识要素的所有属性（包括 FID）都将传递到输出要素。 如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）并且标识要素 FID 将为 -1。 这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—输入要素和标识要素中，除 FID 以外的所有属性都将传递到输出要素。 如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）。</para>
		/// <para>仅要素 ID—输入要素的所有属性和标识要素的 FID 属性将传递到输出要素。 如果未找到交集，则输出中标识要素的 FID 属性值将为 -1。</para>
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
		/// <para>Keep relationships</para>
		/// <para>指定是否将输入要素和标识要素参数值之间的附加空间关系写入输出。 这仅适用于输入要素参数值的几何类型为线且标识要素参数值的几何类型为面时。</para>
		/// <para>未选中 - 不会将附加空间关系写入输出。</para>
		/// <para>选中 - 输出线要素会包含两个附加字段，LEFT_poly 和 RIGHT_poly。 这些字段用于记录线要素左侧和右侧的标识要素参数值的要素 ID。</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Relationship { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Identity SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , bool? qualifiedFieldNames = null , bool? transferGDBAttributeProperties = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, transferGDBAttributeProperties: transferGDBAttributeProperties);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>除要素 ID 外的所有属性—输入要素和标识要素中，除 FID 以外的所有属性都将传递到输出要素。 如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除要素 ID 外的所有属性")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>仅要素 ID—输入要素的所有属性和标识要素的 FID 属性将传递到输出要素。 如果未找到交集，则输出中标识要素的 FID 属性值将为 -1。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_feature_IDs,

			/// <summary>
			/// <para>所有属性—输入要素与标识要素的所有属性（包括 FID）都将传递到输出要素。 如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）并且标识要素 FID 将为 -1。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_attributes,

		}

		/// <summary>
		/// <para>Keep relationships</para>
		/// </summary>
		public enum RelationshipEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_RELATIONSHIPS")]
			KEEP_RELATIONSHIPS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RELATIONSHIPS")]
			NO_RELATIONSHIPS,

		}

#endregion
	}
}
