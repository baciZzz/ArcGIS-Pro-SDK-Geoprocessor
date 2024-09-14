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
	/// <para>计算输入要素和标识要素的几何交集。与标识要素重叠的输入要素或输入要素的一部分将获得这些标识要素的属性。</para>
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
		/// <para>标识要素类或图层。必须是面或与输入要素具有相同的几何类型。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>所创建的要素类，并且结果将写入其中。</para>
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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, IdentityFeatures, OutFeatureClass, JoinAttributes, ClusterTolerance, Relationship };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类或图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Identity Features</para>
		/// <para>标识要素类或图层。必须是面或与输入要素具有相同的几何类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object IdentityFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>所创建的要素类，并且结果将写入其中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>确定哪些属性将传递到输出要素类中。</para>
		/// <para>所有属性—输入要素与标识要素的所有属性（包括 FID）都将传递到输出要素。如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）并且标识要素 FID 将为 -1。这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—输入要素和标识要素中，除 FID 以外的所有属性都将传递到输出要素。如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）。</para>
		/// <para>仅要素 ID—输入要素的所有属性以及标识要素的 FID 属性将传递到输出要素。如果未找到任何交集，则输出中的标识要素 FID 属性值将为 -1。</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>所有要素坐标（节点和折点）之间的最小距离以及坐标可以沿 X 和/或 Y 方向移动的距离。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。建议不要修改此参数。已将其从工具对话框的视图中移除。默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Keep relationships</para>
		/// <para>选择是否要将输入要素和标识要素之间的附加空间关系写入到输出。仅当输入要素为线而标识要素为面时，此选项才适用。</para>
		/// <para>未选中 - 不确定任何附加空间关系。</para>
		/// <para>选中 - 输出线要素会包含两个附加字段 LEFT_poly 和 RIGHT_poly。这些字段用于记录线要素左侧和右侧的标识要素的要素 ID。</para>
		/// <para><see cref="RelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Relationship { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Identity SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object parallelProcessingFactor = null, bool? qualifiedFieldNames = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Attributes To Join</para>
		/// </summary>
		public enum JoinAttributesEnum 
		{
			/// <summary>
			/// <para>除要素 ID 外的所有属性—输入要素和标识要素中，除 FID 以外的所有属性都将传递到输出要素。如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除要素 ID 外的所有属性")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>仅要素 ID—输入要素的所有属性以及标识要素的 FID 属性将传递到输出要素。如果未找到任何交集，则输出中的标识要素 FID 属性值将为 -1。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_feature_IDs,

			/// <summary>
			/// <para>所有属性—输入要素与标识要素的所有属性（包括 FID）都将传递到输出要素。如果未找到任何交集，则标识要素值不会传递到输出（其值将设置为空字符串或 0）并且标识要素 FID 将为 -1。这是默认设置。</para>
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
