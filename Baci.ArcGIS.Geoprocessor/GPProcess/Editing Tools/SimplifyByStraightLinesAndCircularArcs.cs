using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Simplify By Straight Lines And Circular Arcs</para>
	/// <para>通过直线和圆弧进行简化</para>
	/// <para>通过使用较少线段或边替换连续线段或边的方式来简化面和线要素。线段和面的边将根据指定的最大允许偏移量进行简化。此外，可以从连续线段或面的边创建圆弧。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SimplifyByStraightLinesAndCircularArcs : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要进行简化的要素。要素可以是线或面。如果使用多个输入，则要素必须具有相同的空间参考。</para>
		/// </param>
		/// <param name="MaxOffset">
		/// <para>Maximum Allowable Offset</para>
		/// <para>输出要素边从输入要素形状偏移的最大距离。针对拟合类型参数选择了拟合折点选项时，会测量输入折点与输出要素边之间的距离。选中拟合线段选项时，会测量输入要素边和输出要素边之间的距离。</para>
		/// </param>
		public SimplifyByStraightLinesAndCircularArcs(object InFeatures, object MaxOffset)
		{
			this.InFeatures = InFeatures;
			this.MaxOffset = MaxOffset;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过直线和圆弧进行简化</para>
		/// </summary>
		public override string DisplayName() => "通过直线和圆弧进行简化";

		/// <summary>
		/// <para>Tool Name : SimplifyByStraightLinesAndCircularArcs</para>
		/// </summary>
		public override string ToolName() => "SimplifyByStraightLinesAndCircularArcs";

		/// <summary>
		/// <para>Tool Excute Name : edit.SimplifyByStraightLinesAndCircularArcs</para>
		/// </summary>
		public override string ExcuteName() => "edit.SimplifyByStraightLinesAndCircularArcs";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MaxOffset, FittingType, CircularArcs, MaxArcAngleStep, MinVertexCount, MinRadius, MaxRadius, MinArcAngle, ClosedEnds, OutFeatureClass, AnchorPoints, OutFeatureLayers };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行简化的要素。要素可以是线或面。如果使用多个输入，则要素必须具有相同的空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Allowable Offset</para>
		/// <para>输出要素边从输入要素形状偏移的最大距离。针对拟合类型参数选择了拟合折点选项时，会测量输入折点与输出要素边之间的距离。选中拟合线段选项时，会测量输入要素边和输出要素边之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MaxOffset { get; set; }

		/// <summary>
		/// <para>Fitting Type</para>
		/// <para>指定输出要素边和圆弧如何拟合输入要素形状。</para>
		/// <para>如果选中拟合线段，则最大弧度步长和最小折点数参数不可用。</para>
		/// <para>拟合折点—输出要素边与输入要素折点之间的偏移间隙将被最小化。输出要素边与曲线将近似拟合到输入要素折点位置。这是默认设置。</para>
		/// <para>拟合线段—输出要素边与输入要素边之间的偏移间隙将被最小化。输出边和曲线将近似拟合到输入要素形状的位置。</para>
		/// <para><see cref="FittingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FittingType { get; set; } = "FIT_TO_VERTICES";

		/// <summary>
		/// <para>Create circular arcs</para>
		/// <para>指定是否会创建圆弧。</para>
		/// <para>选中 - 将创建圆弧。这是默认设置。</para>
		/// <para>不选中 - 不会创建圆弧。</para>
		/// <para><see cref="CircularArcsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CircularArcs { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Arc Angle Step (decimal degrees)</para>
		/// <para>用于构造圆弧的最大弧度步长（十进制度）。弧度定义了在定位折点来构建圆曲线时，每个步长的视野宽度。弧度是候选曲线（正在构建的曲线）的圆心角。如果在每个最大弧度步长中都存在折点，则会构建一个圆弧。例如，如果折点和边很稀疏，则应使用较大的弧度步长。有效值范围是从 2 到 95（十进制度）。默认值为 20（十进制度）。如果针对拟合类型参数选择了拟合线段选项，则该参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 2)]
		[High(Allow = true, Value = 95)]
		public object MaxArcAngleStep { get; set; } = "20";

		/// <summary>
		/// <para>Minimum Number Of Vertices</para>
		/// <para>创建圆弧所需的最小折点数。该值必须大于 3。默认值为 4。如果针对拟合类型参数选择了拟合线段选项，则该参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = 3)]
		public object MinVertexCount { get; set; } = "4";

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>输出圆弧的最小允许半径。该值必须大于 0 且小于指定的最大半径值。如果未指定值，则不会选中输出圆弧的半径（默认）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinRadius { get; set; }

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>输出圆弧的最大允许半径。该值必须大于指定的最小半径值。如果未指定值，则不会选中输出圆弧的半径（默认）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxRadius { get; set; }

		/// <summary>
		/// <para>Minimum Arc Angle (decimal degrees)</para>
		/// <para>用于构造圆弧的最小弧度（十进制度）。最小弧度是输出圆弧允许的最小圆心角。如果输出圆弧的圆心角小于此值，则不会创建圆弧。有效值范围是从 2 到 360（十进制度）。默认值为 2（十进制度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 360)]
		public object MinArcAngle { get; set; } = "2";

		/// <summary>
		/// <para>Preserve endpoints for closed line</para>
		/// <para>指定是否保留闭合线的端点。闭合线是具有重合端点（循环）的线。</para>
		/// <para>已选中 - 将保留闭合线的端点。这是默认设置。</para>
		/// <para>未选中 - 不保留闭合线的端点，端点可能会被移动或删除。</para>
		/// <para><see cref="ClosedEndsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClosedEnds { get; set; } = "true";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Anchor Points</para>
		/// <para>包含锚点的要素类的路径和名称。锚点将叠加输入要素上的折点，并指示在简化过程中不应对其进行移动或删除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object AnchorPoints { get; set; }

		/// <summary>
		/// <para>Output Layer Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutFeatureLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyByStraightLinesAndCircularArcs SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fitting Type</para>
		/// </summary>
		public enum FittingTypeEnum 
		{
			/// <summary>
			/// <para>拟合折点—输出要素边与输入要素折点之间的偏移间隙将被最小化。输出要素边与曲线将近似拟合到输入要素折点位置。这是默认设置。</para>
			/// </summary>
			[GPValue("FIT_TO_VERTICES")]
			[Description("拟合折点")]
			Fit_to_vertices,

			/// <summary>
			/// <para>拟合线段—输出要素边与输入要素边之间的偏移间隙将被最小化。输出边和曲线将近似拟合到输入要素形状的位置。</para>
			/// </summary>
			[GPValue("FIT_TO_SEGMENTS")]
			[Description("拟合线段")]
			Fit_to_segments,

		}

		/// <summary>
		/// <para>Create circular arcs</para>
		/// </summary>
		public enum CircularArcsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE")]
			CREATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_CREATE")]
			NOT_CREATE,

		}

		/// <summary>
		/// <para>Preserve endpoints for closed line</para>
		/// </summary>
		public enum ClosedEndsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE")]
			PRESERVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PRESERVE")]
			NOT_PRESERVE,

		}

#endregion
	}
}
