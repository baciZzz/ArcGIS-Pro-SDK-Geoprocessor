using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Interpolate Points</para>
	/// <para>点插值</para>
	/// <para>根据一组点的测量结果来预测新位置上的值。该工具将各点处具有数值的点数据用作输入，并根据预测值对区域进行分类。</para>
	/// </summary>
	public class InterpolatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Features</para>
		/// <para>要被插值到连续表面图层上的点要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public InterpolatePoints(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 点插值</para>
		/// </summary>
		public override string DisplayName() => "点插值";

		/// <summary>
		/// <para>Tool Name : InterpolatePoints</para>
		/// </summary>
		public override string ToolName() => "InterpolatePoints";

		/// <summary>
		/// <para>Tool Excute Name : sfa.InterpolatePoints</para>
		/// </summary>
		public override string ExcuteName() => "sfa.InterpolatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Outputname, Field!, Interpolateoption!, Outputpredictionerror!, Classificationtype!, Numclasses!, Classbreaks!, Boundingpolygonlayer!, Predictatpointlayer!, Outputlayer!, Outputpredictionerrorlayer!, Outputpredictedpointslayer! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要被插值到连续表面图层上的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Interpolation Field</para>
		/// <para>包含要用于插值的值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Interpolate Option</para>
		/// <para>根据您的偏好控制“快速”或“精确”，可从“最快”调至“最精确”。预测结果越精确，所花费的计算时间就越长。</para>
		/// <para>速度—速度。</para>
		/// <para>平衡—平衡。这是默认设置。</para>
		/// <para>精度—精度。</para>
		/// <para><see cref="InterpolateoptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Interpolateoption { get; set; } = "5";

		/// <summary>
		/// <para>Output prediction error</para>
		/// <para>选中后，将为插值预测输出一个包含标准误差的面图层。</para>
		/// <para>标准误差可提供有关预测值的可信度的信息，因此非常有用。一般来说，有 95% 的真值会落在两个预测值标准误差之间。例如，假设一个新地区的预测值是 50，标准误差是 5。这意味着通过此任务预测出此地区的真值是 50，但不排除真值低至 40 或高至 60 的可能。为计算合理值的范围，可先用标准误差乘以 2，然后将得出的值加上预测值来获得范围上限，再用预测值减去乘以 2 后得出的值来获得范围下限。</para>
		/// <para>未选中 - 不创建预测误差输出图层。这是默认设置。</para>
		/// <para>选中 - 创建预测误差输出图层。</para>
		/// <para><see cref="OutputpredictionerrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Outputpredictionerror { get; set; } = "false";

		/// <summary>
		/// <para>Classification Type</para>
		/// <para>确定将预测值划分到面的方法。</para>
		/// <para>相等间隔— 将以每个区域的密度值范围相等的方式创建面。</para>
		/// <para>几何间隔— 面基于具有几何系列的分类间隔。此方法可确保每个类范围与每个类中所拥有的值的数量大致相同，且间隔之间的变化一致。这是默认设置。</para>
		/// <para>相等面积— 将以各个区域大小相等的方式创建面。例如，如果结果的高密度值多于低密度值，则会为高密度创建更多面。</para>
		/// <para>手动输入分类间隔—自定义区域值的范围。将按照分类间隔输入这些值。</para>
		/// <para><see cref="ClassificationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Classificationtype { get; set; } = "GEOMETRICINTERVAL";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>该值用于将预测值范围划分为不同的类。每个类中值的范围由分类类型决定。每个类定义结果面的边界。</para>
		/// <para>默认值为 10，最大值为 32。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 32)]
		[Category("Additional Options")]
		public object? Numclasses { get; set; } = "10";

		/// <summary>
		/// <para>Class Breaks</para>
		/// <para>要进行手动分类，请提供所需的分类间隔值。这些值用于定义每个分类的上限，所以分类数量等于所输入值的数量。如果某位置的预测值大于所输入的最大间隔值，则不会为该位置创建区域。必须输入至少两个不大于 32 的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Additional Options")]
		public object? Classbreaks { get; set; }

		/// <summary>
		/// <para>Bounding Polygons</para>
		/// <para>用于指定要对值执行插值操作的面的图层。例如，如果您要对湖中鱼的密度进行插值，则可以使用此参数中湖的边界，使输出结果仅包含湖边界内的面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Additional Options")]
		public object? Boundingpolygonlayer { get; set; }

		/// <summary>
		/// <para>Predict At Point Layer</para>
		/// <para>用于指定计算预测值点位置的可选图层。这样可以对感兴趣的特定位置进行预测。例如，如果输入图层表示污染级别的测量结果，则可以使用此参数来预测学校或医院等高危人群聚集区域的污染级别。然后便可以利用此信息来向这些地区的卫生部门提出建议。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Additional Options")]
		public object? Predictatpointlayer { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputlayer { get; set; }

		/// <summary>
		/// <para>Output Prediction Error Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputpredictionerrorlayer { get; set; }

		/// <summary>
		/// <para>Output Predicted Points Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Outputpredictedpointslayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolatePoints SetEnviroment(object? extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolate Option</para>
		/// </summary>
		public enum InterpolateoptionEnum 
		{
			/// <summary>
			/// <para>速度—速度。</para>
			/// </summary>
			[GPValue("1")]
			[Description("速度")]
			Speed,

			/// <summary>
			/// <para>平衡—平衡。这是默认设置。</para>
			/// </summary>
			[GPValue("5")]
			[Description("平衡")]
			Balanced,

			/// <summary>
			/// <para>精度—精度。</para>
			/// </summary>
			[GPValue("9")]
			[Description("精度")]
			Accuracy,

		}

		/// <summary>
		/// <para>Output prediction error</para>
		/// </summary>
		public enum OutputpredictionerrorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_ERROR")]
			OUTPUT_ERROR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ERROR")]
			NO_ERROR,

		}

		/// <summary>
		/// <para>Classification Type</para>
		/// </summary>
		public enum ClassificationtypeEnum 
		{
			/// <summary>
			/// <para>相等面积— 将以各个区域大小相等的方式创建面。例如，如果结果的高密度值多于低密度值，则会为高密度创建更多面。</para>
			/// </summary>
			[GPValue("EQUALAREA")]
			[Description("相等面积")]
			Equal_area,

			/// <summary>
			/// <para>相等间隔— 将以每个区域的密度值范围相等的方式创建面。</para>
			/// </summary>
			[GPValue("EQUALINTERVAL")]
			[Description("相等间隔")]
			Equal_interval,

			/// <summary>
			/// <para>几何间隔— 面基于具有几何系列的分类间隔。此方法可确保每个类范围与每个类中所拥有的值的数量大致相同，且间隔之间的变化一致。这是默认设置。</para>
			/// </summary>
			[GPValue("GEOMETRICINTERVAL")]
			[Description("几何间隔")]
			Geometric_interval,

			/// <summary>
			/// <para>手动输入分类间隔—自定义区域值的范围。将按照分类间隔输入这些值。</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("手动输入分类间隔")]
			Enter_class_breaks_manually,

		}

#endregion
	}
}
