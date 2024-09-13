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
	/// <para>Update Accuracy Assessment Points</para>
	/// <para>更新精度评估点</para>
	/// <para>更新属性表中的 Target 字段，将参考点与分类的影像进行比较。</para>
	/// </summary>
	public class UpdateAccuracyAssessmentPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InClassData">
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>输入分类影像或其他专题 GIS 参考数据。 输入可以是栅格或要素类。</para>
		/// <para>典型数据是单波段、整型数据类型的分类影像。</para>
		/// <para>如果使用面作为输出，则仅使用未用作训练样本的面。 还可以用 shapefile 或要素类格式的土地覆被数据。</para>
		/// </param>
		/// <param name="InPoints">
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>该点要素类提供了要更新的精度评估点。</para>
		/// <para>此输入中的所有点都将复制到更新的输出要素类中，同时会通过输入栅格或要素类数据更新目标字段参数值。</para>
		/// </param>
		/// <param name="OutPoints">
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>包含用于精度评估的更新随机点字段的输出点要素类。</para>
		/// </param>
		public UpdateAccuracyAssessmentPoints(object InClassData, object InPoints, object OutPoints)
		{
			this.InClassData = InClassData;
			this.InPoints = InPoints;
			this.OutPoints = OutPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新精度评估点</para>
		/// </summary>
		public override string DisplayName() => "更新精度评估点";

		/// <summary>
		/// <para>Tool Name : UpdateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ToolName() => "UpdateAccuracyAssessmentPoints";

		/// <summary>
		/// <para>Tool Excute Name : ia.UpdateAccuracyAssessmentPoints</para>
		/// </summary>
		public override string ExcuteName() => "ia.UpdateAccuracyAssessmentPoints";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InClassData, InPoints, OutPoints, TargetField!, PolygonDimensionField!, PointDimensionField! };

		/// <summary>
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>输入分类影像或其他专题 GIS 参考数据。 输入可以是栅格或要素类。</para>
		/// <para>典型数据是单波段、整型数据类型的分类影像。</para>
		/// <para>如果使用面作为输出，则仅使用未用作训练样本的面。 还可以用 shapefile 或要素类格式的土地覆被数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>该点要素类提供了要更新的精度评估点。</para>
		/// <para>此输入中的所有点都将复制到更新的输出要素类中，同时会通过输入栅格或要素类数据更新目标字段参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InPoints { get; set; }

		/// <summary>
		/// <para>Output Accuracy Assessment Points</para>
		/// <para>包含用于精度评估的更新随机点字段的输出点要素类。</para>
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
		/// <para>Dimension Field for Feature Class</para>
		/// <para>输入精度评估点参数值的维度字段。 评估点将根据与此字段匹配的维度值进行更新。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? PolygonDimensionField { get; set; }

		/// <summary>
		/// <para>Dimension Field for Test Points</para>
		/// <para>输入精度评估点参数值的维度字段。 具有相同维度值的输入数据将用于更新相应的点。</para>
		/// <para>当输入栅格或要素类数据参数值为多维栅格时，将使用维度值与测试点中的维度字段匹配的栅格进行更新。 多维栅格应具有一个时间维度 (StdTime)。 否则，将使用第一个维度来匹配测试点的维度字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? PointDimensionField { get; set; }

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

#endregion
	}
}
