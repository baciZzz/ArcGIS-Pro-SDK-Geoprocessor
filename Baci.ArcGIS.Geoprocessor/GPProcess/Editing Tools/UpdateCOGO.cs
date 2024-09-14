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
	/// <para>Update COGO</para>
	/// <para>更新 COGO</para>
	/// <para>更新启用 COGO 的线要素的 COGO 属性以匹配其线形几何。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateCOGO : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>将更新的启用 COGO 的线要素。</para>
		/// </param>
		public UpdateCOGO(object InLineFeatures)
		{
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新 COGO</para>
		/// </summary>
		public override string DisplayName() => "更新 COGO";

		/// <summary>
		/// <para>Tool Name : UpdateCOGO</para>
		/// </summary>
		public override string ToolName() => "UpdateCOGO";

		/// <summary>
		/// <para>Tool Excute Name : edit.UpdateCOGO</para>
		/// </summary>
		public override string ExcuteName() => "edit.UpdateCOGO";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, DistancesType!, DistanceTolerance!, DirectionType!, MinimumDirectionDifference!, MinimumDirectionLateralOffset!, CombinedScaleFactor!, DirectionOffset!, UpdatedLineFeatures! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>将更新的启用 COGO 的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Update Distance, Radius, and Arc Length</para>
		/// <para>指定更新输入线的 Distance、Radius 和 Arc Length COGO 属性的方式。</para>
		/// <para>覆盖所有值—所有值（包括 NULL 值）都将更新以匹配形状长度。 这是默认设置。</para>
		/// <para>使用最小差异更新值—将更新与形状长度相差超过指定容差的值以匹配形状长度。</para>
		/// <para>不更新任何值—值不会更新。</para>
		/// <para><see cref="DistancesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistancesType { get; set; } = "OVERWRITE";

		/// <summary>
		/// <para>Minimum Distance Difference</para>
		/// <para>线形长度与 Distance、Radius 和 Arc Length 字段值之间的最小距离差。 如果距离差大于指定的容差，则将更新Distance、Radius 或 Arc Length 字段中的属性值以匹配线形长度。 默认值是 0 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? DistanceTolerance { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Update Directions</para>
		/// <para>指定更新输入的 Direction COGO 属性的方式。</para>
		/// <para>覆盖所有值—所有值（包括 NULL 值）都将更新以匹配形状方向。 这是默认设置。</para>
		/// <para>使用最小差异更新值—将更新与形状方向相差超过指定容差的值以匹配形状方向。</para>
		/// <para>不更新任何值—值不会更新。</para>
		/// <para><see cref="DirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DirectionType { get; set; } = "OVERWRITE";

		/// <summary>
		/// <para>Minimum Direction Difference (seconds)</para>
		/// <para>线形方向与 Direction 字段值之间的最小方向差（以秒为单位）。 如果方向差大于指定的容差，则将更新 Direction 字段中的属性值以匹配线形方向。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumDirectionDifference { get; set; }

		/// <summary>
		/// <para>Minimum Direction Lateral Offset</para>
		/// <para>线形端点与使用 Direction 字段值绘制的线的端点之间允许的最小距离。 横向偏移容差可用于非常长的线，其中方向的微小变化会导致线端点的较大差异。 默认值是 0 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumDirectionLateralOffset { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Combined Scale Factor</para>
		/// <para>基于地面到格网校正的比例因子，将应用于线形长度。 比例因子可以作为数字提供，也可以派生自使用线属性字段的 Arcade 表达式。 在 Distance、Radius 和 Arc Length 字段中填充的更新距离是形状长度乘以比例因子的结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? CombinedScaleFactor { get; set; } = "1.0";

		/// <summary>
		/// <para>Direction Offset (seconds)</para>
		/// <para>基于地面到格网校正的旋转，将应用于线形方向。 方向偏移可以作为以秒为单位的数字提供，也可以派生自使用线属性字段的 Arcade 表达式。 在线 Direction 字段中填充的更新方向是按指定方向偏移旋转的线形方向。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? DirectionOffset { get; set; } = "0.0";

		/// <summary>
		/// <para>Updated Line Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedLineFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Update Distance, Radius, and Arc Length</para>
		/// </summary>
		public enum DistancesTypeEnum 
		{
			/// <summary>
			/// <para>覆盖所有值—所有值（包括 NULL 值）都将更新以匹配形状长度。 这是默认设置。</para>
			/// </summary>
			[GPValue("OVERWRITE")]
			[Description("覆盖所有值")]
			Overwrite_all_values,

			/// <summary>
			/// <para>使用最小差异更新值—将更新与形状长度相差超过指定容差的值以匹配形状长度。</para>
			/// </summary>
			[GPValue("USE_MINIMUM_DIFFERENCE")]
			[Description("使用最小差异更新值")]
			Update_values_using_a_minimum_difference,

			/// <summary>
			/// <para>不更新任何值—值不会更新。</para>
			/// </summary>
			[GPValue("DO_NOT_UPDATE")]
			[Description("不更新任何值")]
			Do_not_update_any_values,

		}

		/// <summary>
		/// <para>Update Directions</para>
		/// </summary>
		public enum DirectionTypeEnum 
		{
			/// <summary>
			/// <para>覆盖所有值—所有值（包括 NULL 值）都将更新以匹配形状方向。 这是默认设置。</para>
			/// </summary>
			[GPValue("OVERWRITE")]
			[Description("覆盖所有值")]
			Overwrite_all_values,

			/// <summary>
			/// <para>使用最小差异更新值—将更新与形状方向相差超过指定容差的值以匹配形状方向。</para>
			/// </summary>
			[GPValue("USE_MINIMUM_DIFFERENCE")]
			[Description("使用最小差异更新值")]
			Update_values_using_a_minimum_difference,

			/// <summary>
			/// <para>不更新任何值—值不会更新。</para>
			/// </summary>
			[GPValue("DO_NOT_UPDATE")]
			[Description("不更新任何值")]
			Do_not_update_any_values,

		}

#endregion
	}
}
