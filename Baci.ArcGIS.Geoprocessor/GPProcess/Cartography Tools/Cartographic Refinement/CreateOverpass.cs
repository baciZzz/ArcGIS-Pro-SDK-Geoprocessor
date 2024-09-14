using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Create Overpass</para>
	/// <para>创建天桥</para>
	/// <para>在两线交点处创建桥护栏和面掩膜来指示天桥。</para>
	/// </summary>
	public class CreateOverpass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAboveFeatures">
		/// <para>Input Above Features</para>
		/// <para>输入线要素图层。该图层所包含的线与输入下层要素参数中的线相交，并被符号化为上层要素。</para>
		/// </param>
		/// <param name="InBelowFeatures">
		/// <para>Input Below Features</para>
		/// <para>输入线要素图层会与输入上层要素参数中的线相交，并被符号化为下层要素。 这些要素将被输出天桥要素类参数中创建的面掩膜。</para>
		/// </param>
		/// <param name="MarginAlong">
		/// <para>Margin Along</para>
		/// <para>设置沿输入上层要素参数的掩膜面的长度，方法是以页面单位指定掩膜应超出输入下层要素参数笔划符号宽度的距离。 必须指定延伸边距参数，而且其必须大于或等于零。 为边距选择页面单位（磅、毫米等）；默认单位是磅。</para>
		/// </param>
		/// <param name="MarginAcross">
		/// <para>Margin Across</para>
		/// <para>设置穿过输入上层要素参数的掩膜面的宽度，方法是以页面单位指定掩膜应超出输入下层要素参数笔划符号宽度的距离。 必须指定覆盖边距参数，而且其必须大于或等于零。 为边距选择页面单位（磅、毫米等）；默认单位是磅。</para>
		/// </param>
		/// <param name="OutOverpassFeatureClass">
		/// <para>Output Overpass Feature Class</para>
		/// <para>为存储掩膜输入下层要素参数的面而创建的输出要素类。</para>
		/// </param>
		/// <param name="OutMaskRelationshipClass">
		/// <para>Output Mask Relationship Class</para>
		/// <para>为存储天桥掩膜面和输入下层要素参数的线之间的连接而创建的输出关系类。</para>
		/// </param>
		public CreateOverpass(object InAboveFeatures, object InBelowFeatures, object MarginAlong, object MarginAcross, object OutOverpassFeatureClass, object OutMaskRelationshipClass)
		{
			this.InAboveFeatures = InAboveFeatures;
			this.InBelowFeatures = InBelowFeatures;
			this.MarginAlong = MarginAlong;
			this.MarginAcross = MarginAcross;
			this.OutOverpassFeatureClass = OutOverpassFeatureClass;
			this.OutMaskRelationshipClass = OutMaskRelationshipClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建天桥</para>
		/// </summary>
		public override string DisplayName() => "创建天桥";

		/// <summary>
		/// <para>Tool Name : CreateOverpass</para>
		/// </summary>
		public override string ToolName() => "CreateOverpass";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CreateOverpass</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CreateOverpass";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAboveFeatures, InBelowFeatures, MarginAlong, MarginAcross, OutOverpassFeatureClass, OutMaskRelationshipClass, WhereClause, OutDecorationFeatureClass, WingType, WingTickLength };

		/// <summary>
		/// <para>Input Above Features</para>
		/// <para>输入线要素图层。该图层所包含的线与输入下层要素参数中的线相交，并被符号化为上层要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InAboveFeatures { get; set; }

		/// <summary>
		/// <para>Input Below Features</para>
		/// <para>输入线要素图层会与输入上层要素参数中的线相交，并被符号化为下层要素。 这些要素将被输出天桥要素类参数中创建的面掩膜。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InBelowFeatures { get; set; }

		/// <summary>
		/// <para>Margin Along</para>
		/// <para>设置沿输入上层要素参数的掩膜面的长度，方法是以页面单位指定掩膜应超出输入下层要素参数笔划符号宽度的距离。 必须指定延伸边距参数，而且其必须大于或等于零。 为边距选择页面单位（磅、毫米等）；默认单位是磅。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MarginAlong { get; set; }

		/// <summary>
		/// <para>Margin Across</para>
		/// <para>设置穿过输入上层要素参数的掩膜面的宽度，方法是以页面单位指定掩膜应超出输入下层要素参数笔划符号宽度的距离。 必须指定覆盖边距参数，而且其必须大于或等于零。 为边距选择页面单位（磅、毫米等）；默认单位是磅。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MarginAcross { get; set; }

		/// <summary>
		/// <para>Output Overpass Feature Class</para>
		/// <para>为存储掩膜输入下层要素参数的面而创建的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutOverpassFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Mask Relationship Class</para>
		/// <para>为存储天桥掩膜面和输入下层要素参数的线之间的连接而创建的输出关系类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object OutMaskRelationshipClass { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>此 SQL 表达式用于选择输入上层要素参数中的要素子集。</para>
		/// <para>使用引号（例如“MY_FIELD”），或者如果要查询个人地理数据库，需将字段用方括号括起（例如 [MY_FIELD]）。</para>
		/// <para>有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output Decoration Feature Class</para>
		/// <para>为存储护栏要素而创建的输出线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutDecorationFeatureClass { get; set; }

		/// <summary>
		/// <para>Wing Type</para>
		/// <para>指定护栏要素的翼类型。</para>
		/// <para>翼梢在上层和下层要素之间成角度—护栏翼梢将在输入上层要素参数和输入下层要素参数之间成角度。 这是默认设置。</para>
		/// <para>翼梢平行于下层要素—指定天桥翼的翼梢将与输入下层要素参数平行。</para>
		/// <para>未创建翼梢—将不在护栏上创建翼梢。</para>
		/// <para><see cref="WingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WingType { get; set; } = "ANGLED";

		/// <summary>
		/// <para>Wing Tick Length</para>
		/// <para>护栏翼长度（页面单位）。 其长度必须大于或等于零；默认长度为 1。 为长度选择页面单位（磅、毫米等）；默认单位是磅。 此参数不适用于 NONE 翼类型值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object WingTickLength { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateOverpass SetEnviroment(object cartographicCoordinateSystem = null, object referenceScale = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Wing Type</para>
		/// </summary>
		public enum WingTypeEnum 
		{
			/// <summary>
			/// <para>翼梢在上层和下层要素之间成角度—护栏翼梢将在输入上层要素参数和输入下层要素参数之间成角度。 这是默认设置。</para>
			/// </summary>
			[GPValue("ANGLED")]
			[Description("翼梢在上层和下层要素之间成角度")]
			Wing_ticks_angled_between_above_and_below_features,

			/// <summary>
			/// <para>翼梢平行于下层要素—指定天桥翼的翼梢将与输入下层要素参数平行。</para>
			/// </summary>
			[GPValue("PARALLEL")]
			[Description("翼梢平行于下层要素")]
			Wing_ticks_parallel_to_below_features,

			/// <summary>
			/// <para>未创建翼梢—将不在护栏上创建翼梢。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("未创建翼梢")]
			No_wing_ticks_created,

		}

#endregion
	}
}
