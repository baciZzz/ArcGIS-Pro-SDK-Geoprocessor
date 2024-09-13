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
	/// <para>Intersect</para>
	/// <para>相交</para>
	/// <para>计算输入要素的几何交集。所有图层或要素类中相叠置的要素或要素的各部分将被写入到输出要素类。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseIntersect"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseIntersect))]
	public class Intersect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入要素类或图层列表。要素间距小于聚类容差时，等级较低的要素将捕捉到等级较高的要素。最高等级为 1。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </param>
		public Intersect(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 相交</para>
		/// </summary>
		public override string DisplayName() => "相交";

		/// <summary>
		/// <para>Tool Name : 相交</para>
		/// </summary>
		public override string ToolName() => "相交";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Intersect</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Intersect";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, JoinAttributes, ClusterTolerance, OutputType };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入要素类或图层列表。要素间距小于聚类容差时，等级较低的要素将捕捉到等级较高的要素。最高等级为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attributes To Join</para>
		/// <para>指定将输入要素的哪些属性传递到输出要素类。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—除 FID 外，将输入要素的其余所有属性都传递到输出要素类。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。</para>
		/// <para><see cref="JoinAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object JoinAttributes { get; set; } = "ALL";

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>所有要素坐标（节点和折点）之间的最小距离以及坐标可以沿 x 和/或 y 方向移动的距离。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。建议不要修改此参数。已将其从工具对话框的视图中移除。默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定要返回的相交类型。</para>
		/// <para>与输入相同—所返回的相交要素的几何类型与具有最低维度几何的输入要素的几何类型相同。如果所有输入都是面，则输出要素类将包含面。如果一个或多个输入是线但不包含点，则输出是线。如果一个或多个输入是点，则输出要素类将包含点。这是默认设置。</para>
		/// <para>线—返回的交集为线。仅当输入中不包含点时，此选项才有效。</para>
		/// <para>点—返回的交集为点。如果输入是线或面，则输出将是多点要素类。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "INPUT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , bool? qualifiedFieldNames = null )
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
			/// <para>所有属性—输入要素的所有属性都将传递到输出要素类。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_attributes,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>与输入相同—所返回的相交要素的几何类型与具有最低维度几何的输入要素的几何类型相同。如果所有输入都是面，则输出要素类将包含面。如果一个或多个输入是线但不包含点，则输出是线。如果一个或多个输入是点，则输出要素类将包含点。这是默认设置。</para>
			/// </summary>
			[GPValue("INPUT")]
			[Description("与输入相同")]
			Same_as_input,

			/// <summary>
			/// <para>线—返回的交集为线。仅当输入中不包含点时，此选项才有效。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线")]
			Line,

			/// <summary>
			/// <para>点—返回的交集为点。如果输入是线或面，则输出将是多点要素类。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

		}

#endregion
	}
}
