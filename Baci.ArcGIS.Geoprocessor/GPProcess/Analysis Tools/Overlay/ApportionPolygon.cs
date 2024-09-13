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
	/// <para>Apportion Polygon</para>
	/// <para>分配面</para>
	/// <para>基于目标面图层的空间叠加来汇总输入面图层的属性，并将汇总的属性分配给目标面。 目标面具有从每个目标重叠的输入面派生的求和数值属性。 此过程通常称为分配。</para>
	/// </summary>
	public class ApportionPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Polygons</para>
		/// <para>具有将汇总到目标面几何中的 数值属性的面要素。</para>
		/// </param>
		/// <param name="ApportionFields">
		/// <para>Fields to Apportion</para>
		/// <para>输入面中的数值字段，按每个目标面汇总并记录在输出要素类中。</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Polygons</para>
		/// <para>将复制到输出要素类的面要素及其分配的字段。</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Feature Class</para>
		/// <para>包含目标面的属性和几何以及输入面中的指定分配字段的输出要素类。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Apportion Method</para>
		/// <para>指定用于将字段从输入面分配到目标面的方法。</para>
		/// <para>面积—每个输入面对每个目标要素的汇总值的贡献量将取决于两个要素之间的重叠面积。 如果输入要素与两个目标要素的重叠面积相同，则分配的字段将一分为二，并且对两个目标要素贡献总值的一半。 这是默认设置。</para>
		/// <para>长度—输入要素中的属性将基于每个目标要素中线所占百分比的情况进行划分。 计算中仅会包括与输入要素相交的线。 输入要素外部的线将被排除在外。 例如，如果一个目标要素覆盖一条线的 750 米，而另一个目标要素覆盖一条线的 250 米，则输入要素属性值的 75% (750/1000) 将被聚合到第一个目标要素，而输入要素属性值的 25% (250/1000) 将被聚合到第二个目标要素。</para>
		/// <para>点—来自输入要素的属性将基于与输入要素重叠的每个目标要素内的点数进行划分。 输入要素外部的点将被排除在外。 您可以有选择地指定权重字段，以便将每个目标要素中所有点的总权重用于确定如何划分输入要素的属性值。 例如，如果两个目标要素与一个输入要素重叠，并且第一个目标要素内有两个点，第二个目标要素内有八个点，则输入要素属性值的 20% (2/10) 将被聚合到第一个目标要素，且输入要素属性值的 80% (8/10) 将被聚合到第二个目标要素。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public ApportionPolygon(object InFeatures, object ApportionFields, object TargetFeatures, object OutFeatures, object Method)
		{
			this.InFeatures = InFeatures;
			this.ApportionFields = ApportionFields;
			this.TargetFeatures = TargetFeatures;
			this.OutFeatures = OutFeatures;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : 分配面</para>
		/// </summary>
		public override string DisplayName() => "分配面";

		/// <summary>
		/// <para>Tool Name : ApportionPolygon</para>
		/// </summary>
		public override string ToolName() => "ApportionPolygon";

		/// <summary>
		/// <para>Tool Excute Name : analysis.ApportionPolygon</para>
		/// </summary>
		public override string ExcuteName() => "analysis.ApportionPolygon";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ApportionFields, TargetFeatures, OutFeatures, Method, EstimationFeatures, WeightField, MaintainGeometries };

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>具有将汇总到目标面几何中的 数值属性的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Apportion</para>
		/// <para>输入面中的数值字段，按每个目标面汇总并记录在输出要素类中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ApportionFields { get; set; }

		/// <summary>
		/// <para>Target Polygons</para>
		/// <para>将复制到输出要素类的面要素及其分配的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含目标面的属性和几何以及输入面中的指定分配字段的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Apportion Method</para>
		/// <para>指定用于将字段从输入面分配到目标面的方法。</para>
		/// <para>面积—每个输入面对每个目标要素的汇总值的贡献量将取决于两个要素之间的重叠面积。 如果输入要素与两个目标要素的重叠面积相同，则分配的字段将一分为二，并且对两个目标要素贡献总值的一半。 这是默认设置。</para>
		/// <para>长度—输入要素中的属性将基于每个目标要素中线所占百分比的情况进行划分。 计算中仅会包括与输入要素相交的线。 输入要素外部的线将被排除在外。 例如，如果一个目标要素覆盖一条线的 750 米，而另一个目标要素覆盖一条线的 250 米，则输入要素属性值的 75% (750/1000) 将被聚合到第一个目标要素，而输入要素属性值的 25% (250/1000) 将被聚合到第二个目标要素。</para>
		/// <para>点—来自输入要素的属性将基于与输入要素重叠的每个目标要素内的点数进行划分。 输入要素外部的点将被排除在外。 您可以有选择地指定权重字段，以便将每个目标要素中所有点的总权重用于确定如何划分输入要素的属性值。 例如，如果两个目标要素与一个输入要素重叠，并且第一个目标要素内有两个点，第二个目标要素内有八个点，则输入要素属性值的 20% (2/10) 将被聚合到第一个目标要素，且输入要素属性值的 80% (8/10) 将被聚合到第二个目标要素。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "AREA";

		/// <summary>
		/// <para>Estimation Features</para>
		/// <para>输入点或折线要素，将用于估计要分配给目标面的输入面分配字段的百分比。 此为交集内将除以输入要素内的数量以得出百分比的点或线的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Multipoint")]
		public object EstimationFeatures { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>目标面图层中的数值字段，将用于调整接收输入面的要分配字段中的较大分配值的目标面。 向权重较高的目标分配的字段值比例较高。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Maintain target geometry</para>
		/// <para>指定输出要素类是否将保留目标面图层的原始几何。</para>
		/// <para>选中 - 输出要素类将保留目标面图层的原始几何。 这是默认设置。</para>
		/// <para>未选中 - 输出要素类将为目标面和输入面的几何交集。 仅在输出中包含目标面中与输入面重叠的区域。</para>
		/// <para><see cref="MaintainGeometriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MaintainGeometries { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApportionPolygon SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Apportion Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>面积—每个输入面对每个目标要素的汇总值的贡献量将取决于两个要素之间的重叠面积。 如果输入要素与两个目标要素的重叠面积相同，则分配的字段将一分为二，并且对两个目标要素贡献总值的一半。 这是默认设置。</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("面积")]
			Area,

			/// <summary>
			/// <para>长度—输入要素中的属性将基于每个目标要素中线所占百分比的情况进行划分。 计算中仅会包括与输入要素相交的线。 输入要素外部的线将被排除在外。 例如，如果一个目标要素覆盖一条线的 750 米，而另一个目标要素覆盖一条线的 250 米，则输入要素属性值的 75% (750/1000) 将被聚合到第一个目标要素，而输入要素属性值的 25% (250/1000) 将被聚合到第二个目标要素。</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("长度")]
			Length,

			/// <summary>
			/// <para>点—来自输入要素的属性将基于与输入要素重叠的每个目标要素内的点数进行划分。 输入要素外部的点将被排除在外。 您可以有选择地指定权重字段，以便将每个目标要素中所有点的总权重用于确定如何划分输入要素的属性值。 例如，如果两个目标要素与一个输入要素重叠，并且第一个目标要素内有两个点，第二个目标要素内有八个点，则输入要素属性值的 20% (2/10) 将被聚合到第一个目标要素，且输入要素属性值的 80% (8/10) 将被聚合到第二个目标要素。</para>
			/// </summary>
			[GPValue("POINTS")]
			[Description("点")]
			Points,

		}

		/// <summary>
		/// <para>Maintain target geometry</para>
		/// </summary>
		public enum MaintainGeometriesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_GEOMETRIES")]
			MAINTAIN_GEOMETRIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERSECT_GEOMETRIES")]
			INTERSECT_GEOMETRIES,

		}

#endregion
	}
}
