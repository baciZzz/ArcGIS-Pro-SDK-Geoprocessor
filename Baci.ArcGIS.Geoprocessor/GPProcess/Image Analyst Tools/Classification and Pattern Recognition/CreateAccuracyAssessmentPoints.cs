using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Create Accuracy Assessment Points</para>
	/// <para>创建精度评估点</para>
	/// <para>创建用于分类后精度评估的随机采样点。</para>
	/// </summary>
	public class CreateAccuracyAssessmentPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InClassData">
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>输入分类影像或其他专题 GIS 参考数据。 输入可以是栅格或要素类。</para>
		/// <para>典型数据是单波段、整型数据类型的分类影像。</para>
		/// <para>如果使用面作为输出，则仅使用未用作训练样本的面。 还可以是 shapefile 或要素类格式的 GIS 土地覆被数据。</para>
		/// </param>
		/// <param name="OutPoints">
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>包含要用于精度评估的随机点的输出点 shapefile 或要素类。</para>
		/// </param>
		public CreateAccuracyAssessmentPoints(object InClassData, object OutPoints)
		{
			this.InClassData = InClassData;
			this.OutPoints = OutPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建精度评估点</para>
		/// </summary>
		public override string DisplayName() => "创建精度评估点";

		/// <summary>
		/// <para>Tool Name : CreateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ToolName() => "CreateAccuracyAssessmentPoints";

		/// <summary>
		/// <para>Tool Excute Name : ia.CreateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ExcuteName() => "ia.CreateAccuracyAssessmentPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InClassData, OutPoints, TargetField!, NumRandomPoints!, Sampling!, PolygonDimensionField! };

		/// <summary>
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>输入分类影像或其他专题 GIS 参考数据。 输入可以是栅格或要素类。</para>
		/// <para>典型数据是单波段、整型数据类型的分类影像。</para>
		/// <para>如果使用面作为输出，则仅使用未用作训练样本的面。 还可以是 shapefile 或要素类格式的 GIS 土地覆被数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>包含要用于精度评估的随机点的输出点 shapefile 或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPoints { get; set; }

		/// <summary>
		/// <para>Target Field</para>
		/// <para>指定输入数据是分类影像还是实际地表数据。</para>
		/// <para>分类—输入为分类影像。 这是默认设置。</para>
		/// <para>实际地表—输入为参考数据。</para>
		/// <para><see cref="TargetFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TargetField { get; set; } = "CLASSIFIED";

		/// <summary>
		/// <para>Number of Random Points</para>
		/// <para>将生成的随机点总数。</para>
		/// <para>根据采样策略和类数，实际数量可能会超出此数量但绝不会低于此数量。 默认随机生成的点数为 500。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumRandomPoints { get; set; } = "500";

		/// <summary>
		/// <para>Sampling Strategy</para>
		/// <para>指定将使用的采样方案。</para>
		/// <para>分层随机—将在每个类中创建随机分布的点，其中每个类中包含的点数与其相对面积成正比。 这是默认设置</para>
		/// <para>均衡化分层随机—将在每个类中创建随机分布的点，其中每个类具有相同数量的点。</para>
		/// <para>随机—将在整个图像中创建随机分布的点。</para>
		/// <para><see cref="SamplingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Sampling { get; set; } = "STRATIFIED_RANDOM";

		/// <summary>
		/// <para>Dimension Field for Feature Class</para>
		/// <para>用于定义要素维度（时间）的字段。 仅当分类结果为多维栅格并且需要从要素类（例如多年的土地分类面）生成评估点时，才使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? PolygonDimensionField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateAccuracyAssessmentPoints SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Target Field</para>
		/// </summary>
		public enum TargetFieldEnum 
		{
			/// <summary>
			/// <para>分类—输入为分类影像。 这是默认设置。</para>
			/// </summary>
			[GPValue("CLASSIFIED")]
			[Description("分类")]
			Classified,

			/// <summary>
			/// <para>实际地表—输入为参考数据。</para>
			/// </summary>
			[GPValue("GROUND_TRUTH")]
			[Description("实际地表")]
			Ground_truth,

		}

		/// <summary>
		/// <para>Sampling Strategy</para>
		/// </summary>
		public enum SamplingEnum 
		{
			/// <summary>
			/// <para>分层随机—将在每个类中创建随机分布的点，其中每个类中包含的点数与其相对面积成正比。 这是默认设置</para>
			/// </summary>
			[GPValue("STRATIFIED_RANDOM")]
			[Description("分层随机")]
			Stratified_random,

			/// <summary>
			/// <para>均衡化分层随机—将在每个类中创建随机分布的点，其中每个类具有相同数量的点。</para>
			/// </summary>
			[GPValue("EQUALIZED_STRATIFIED_RANDOM")]
			[Description("均衡化分层随机")]
			Equalized_stratified_random,

			/// <summary>
			/// <para>随机—将在整个图像中创建随机分布的点。</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("随机")]
			Random,

		}

#endregion
	}
}
