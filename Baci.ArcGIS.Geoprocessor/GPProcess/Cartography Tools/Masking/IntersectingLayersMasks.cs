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
	/// <para>Intersecting Layers Masks</para>
	/// <para>交叉图层掩膜</para>
	/// <para>在两个符号化输入图层（“掩膜”图层和“被掩膜”的图层）的相交处按照指定的形状和大小创建掩膜面。</para>
	/// </summary>
	public class IntersectingLayersMasks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="MaskingLayer">
		/// <para>Masking Layer</para>
		/// <para>将与被掩膜的图层相交以创建掩膜面的符号化输入图层。 这就是对被掩膜的图层应用掩膜时将突出显示的图层。</para>
		/// </param>
		/// <param name="MaskedLayer">
		/// <para>Masked Layer</para>
		/// <para>要掩膜的符号化输入图层。 这就是将被掩膜面遮挡的图层。</para>
		/// </param>
		/// <param name="OutputFc">
		/// <para>Output Feature Class</para>
		/// <para>含有掩膜要素的要素类。</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference Scale</para>
		/// <para>用于在使用页面单位指定掩膜时计算掩膜几何的参考比例。 该比例通常是地图的参考比例。</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Calculation coordinate system</para>
		/// <para>将创建掩膜面的地图的空间参考。 该空间参考不是要分配给输出要素类的空间参考。 它是地图的空间参考；由于投影要素时，符号系统的位置可能发生变化，所以在该空间参考内将使用掩膜面。</para>
		/// </param>
		/// <param name="Margin">
		/// <para>Margin</para>
		/// <para>在用于创建掩膜面的符号化输入要素周围的间距（使用页面单位）。 通常，创建掩膜面时，在符号的周围留有小边距，以提高显示效果。 边距值可使用页面单位或地图单位指定。 通常，您需要使用页面单位来指定边距值。</para>
		/// <para>边距值不能为负。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Mask Kind</para>
		/// <para>指定所创建的掩膜几何的类型。</para>
		/// <para>箱形图—表示符号化要素的范围的面。</para>
		/// <para>凸包—要素的符号化几何的凸包。 这是默认设置。</para>
		/// <para>精确简化—表示符号化要素的确切形状的概化面。 与使用 EXACT 方法创建的面相比，使用该方法创建的面的折点数将显著降低。</para>
		/// <para>精确—表示符号化要素的确切形状的面。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="MaskForNonPlacedAnno">
		/// <para>Create masks for unplaced annotation</para>
		/// <para>指定是否为未放置的注记创建掩膜。 该选项仅在对地理数据库注记图层执行掩膜操作时使用。</para>
		/// <para>所有注记要素—为所有的注记要素创建掩膜。</para>
		/// <para>仅放置的注记要素—仅为状态为已放置的要素创建掩膜。</para>
		/// <para><see cref="MaskForNonPlacedAnnoEnum"/></para>
		/// </param>
		/// <param name="Attributes">
		/// <para>Transfer Attributes</para>
		/// <para>指定将从输入要素传递到输出要素的属性。</para>
		/// <para>仅 FID 字段—仅输入要素的 FID 字段将传递到输出要素。 这是默认设置。</para>
		/// <para>除 FID 字段以外的所有属性—输入要素中，除 FID 以外的所有属性都将传递到输出要素。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </param>
		public IntersectingLayersMasks(object MaskingLayer, object MaskedLayer, object OutputFc, object ReferenceScale, object SpatialReference, object Margin, object Method, object MaskForNonPlacedAnno, object Attributes)
		{
			this.MaskingLayer = MaskingLayer;
			this.MaskedLayer = MaskedLayer;
			this.OutputFc = OutputFc;
			this.ReferenceScale = ReferenceScale;
			this.SpatialReference = SpatialReference;
			this.Margin = Margin;
			this.Method = Method;
			this.MaskForNonPlacedAnno = MaskForNonPlacedAnno;
			this.Attributes = Attributes;
		}

		/// <summary>
		/// <para>Tool Display Name : 交叉图层掩膜</para>
		/// </summary>
		public override string DisplayName() => "交叉图层掩膜";

		/// <summary>
		/// <para>Tool Name : IntersectingLayersMasks</para>
		/// </summary>
		public override string ToolName() => "IntersectingLayersMasks";

		/// <summary>
		/// <para>Tool Excute Name : cartography.IntersectingLayersMasks</para>
		/// </summary>
		public override string ExcuteName() => "cartography.IntersectingLayersMasks";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { MaskingLayer, MaskedLayer, OutputFc, ReferenceScale, SpatialReference, Margin, Method, MaskForNonPlacedAnno, Attributes };

		/// <summary>
		/// <para>Masking Layer</para>
		/// <para>将与被掩膜的图层相交以创建掩膜面的符号化输入图层。 这就是对被掩膜的图层应用掩膜时将突出显示的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple", "Annotation")]
		public object MaskingLayer { get; set; }

		/// <summary>
		/// <para>Masked Layer</para>
		/// <para>要掩膜的符号化输入图层。 这就是将被掩膜面遮挡的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple", "Annotation")]
		public object MaskedLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>含有掩膜要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFc { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>用于在使用页面单位指定掩膜时计算掩膜几何的参考比例。 该比例通常是地图的参考比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Calculation coordinate system</para>
		/// <para>将创建掩膜面的地图的空间参考。 该空间参考不是要分配给输出要素类的空间参考。 它是地图的空间参考；由于投影要素时，符号系统的位置可能发生变化，所以在该空间参考内将使用掩膜面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Margin</para>
		/// <para>在用于创建掩膜面的符号化输入要素周围的间距（使用页面单位）。 通常，创建掩膜面时，在符号的周围留有小边距，以提高显示效果。 边距值可使用页面单位或地图单位指定。 通常，您需要使用页面单位来指定边距值。</para>
		/// <para>边距值不能为负。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Margin { get; set; } = "0 Points";

		/// <summary>
		/// <para>Mask Kind</para>
		/// <para>指定所创建的掩膜几何的类型。</para>
		/// <para>箱形图—表示符号化要素的范围的面。</para>
		/// <para>凸包—要素的符号化几何的凸包。 这是默认设置。</para>
		/// <para>精确简化—表示符号化要素的确切形状的概化面。 与使用 EXACT 方法创建的面相比，使用该方法创建的面的折点数将显著降低。</para>
		/// <para>精确—表示符号化要素的确切形状的面。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "CONVEX_HULL";

		/// <summary>
		/// <para>Create masks for unplaced annotation</para>
		/// <para>指定是否为未放置的注记创建掩膜。 该选项仅在对地理数据库注记图层执行掩膜操作时使用。</para>
		/// <para>所有注记要素—为所有的注记要素创建掩膜。</para>
		/// <para>仅放置的注记要素—仅为状态为已放置的要素创建掩膜。</para>
		/// <para><see cref="MaskForNonPlacedAnnoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MaskForNonPlacedAnno { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// <para>指定将从输入要素传递到输出要素的属性。</para>
		/// <para>仅 FID 字段—仅输入要素的 FID 字段将传递到输出要素。 这是默认设置。</para>
		/// <para>除 FID 字段以外的所有属性—输入要素中，除 FID 以外的所有属性都将传递到输出要素。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Attributes { get; set; } = "ONLY_FID";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IntersectingLayersMasks SetEnviroment(object cartographicCoordinateSystem = null , object cartographicPartitions = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mask Kind</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>箱形图—表示符号化要素的范围的面。</para>
			/// </summary>
			[GPValue("BOX")]
			[Description("箱形图")]
			Box,

			/// <summary>
			/// <para>凸包—要素的符号化几何的凸包。 这是默认设置。</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("凸包")]
			Convex_hull,

			/// <summary>
			/// <para>精确简化—表示符号化要素的确切形状的概化面。 与使用 EXACT 方法创建的面相比，使用该方法创建的面的折点数将显著降低。</para>
			/// </summary>
			[GPValue("EXACT_SIMPLIFIED")]
			[Description("精确简化")]
			Exact_simplified,

			/// <summary>
			/// <para>精确简化—表示符号化要素的确切形状的概化面。 与使用 EXACT 方法创建的面相比，使用该方法创建的面的折点数将显著降低。</para>
			/// </summary>
			[GPValue("EXACT")]
			[Description("精确")]
			Exact,

		}

		/// <summary>
		/// <para>Create masks for unplaced annotation</para>
		/// </summary>
		public enum MaskForNonPlacedAnnoEnum 
		{
			/// <summary>
			/// <para>所有注记要素—为所有的注记要素创建掩膜。</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("所有注记要素")]
			All_annotation_features,

			/// <summary>
			/// <para>仅放置的注记要素—仅为状态为已放置的要素创建掩膜。</para>
			/// </summary>
			[GPValue("ONLY_PLACED")]
			[Description("仅放置的注记要素")]
			Only_placed_annotation_features,

		}

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>除 FID 字段以外的所有属性—输入要素中，除 FID 以外的所有属性都将传递到输出要素。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除 FID 字段以外的所有属性")]
			All_attributes_except_the_FID_field,

			/// <summary>
			/// <para>仅 FID 字段—仅输入要素的 FID 字段将传递到输出要素。 这是默认设置。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅 FID 字段")]
			Only_the_FID_field,

			/// <summary>
			/// <para>所有属性—输入要素的所有属性都将传递到输出要素。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有属性")]
			All_attributes,

		}

#endregion
	}
}
