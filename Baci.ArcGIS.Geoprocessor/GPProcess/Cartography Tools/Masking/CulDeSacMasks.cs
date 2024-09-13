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
	/// <para>Cul-De-Sac Masks</para>
	/// <para>死胡同掩膜</para>
	/// <para>由符号化的输入线图层创建一个面掩膜要素类。</para>
	/// </summary>
	public class CulDeSacMasks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>创建掩膜所使用的输入线图层。</para>
		/// </param>
		/// <param name="OutputFc">
		/// <para>Output Feature Class</para>
		/// <para>含有掩膜要素的要素类。</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference Scale</para>
		/// <para>用于在使用页面单位指定掩膜时计算掩膜几何的参考比例。该比例通常是地图的参考比例。</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Calculation coordinate system</para>
		/// <para>将创建掩膜面的地图的空间参考。该空间参考不是要分配给输出要素类的空间参考。它是地图的空间参考；由于投影要素时，符号系统的位置可能发生变化，所以在该空间参考内将使用掩膜面。</para>
		/// </param>
		/// <param name="Margin">
		/// <para>Margin</para>
		/// <para>在用于创建掩膜面的符号化输入要素周围的间距（使用页面单位）。通常，创建掩膜面时，在符号的周围留有小边距，以提高显示效果。边距值可使用页面单位或地图单位指定。通常，您需要使用页面单位来指定边距值。</para>
		/// <para>边距值不能为负。</para>
		/// </param>
		/// <param name="Attributes">
		/// <para>Transfer Attributes</para>
		/// <para>指定将从输入要素传递到输出要素的属性。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素。这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—输入要素中，除 FID 以外的所有属性都将传递到输出要素。</para>
		/// <para>所有属性—输入要素的所有属性都将传递到输出要素。</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </param>
		public CulDeSacMasks(object InputLayer, object OutputFc, object ReferenceScale, object SpatialReference, object Margin, object Attributes)
		{
			this.InputLayer = InputLayer;
			this.OutputFc = OutputFc;
			this.ReferenceScale = ReferenceScale;
			this.SpatialReference = SpatialReference;
			this.Margin = Margin;
			this.Attributes = Attributes;
		}

		/// <summary>
		/// <para>Tool Display Name : 死胡同掩膜</para>
		/// </summary>
		public override string DisplayName() => "死胡同掩膜";

		/// <summary>
		/// <para>Tool Name : CulDeSacMasks</para>
		/// </summary>
		public override string ToolName() => "CulDeSacMasks";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CulDeSacMasks</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CulDeSacMasks";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputFc, ReferenceScale, SpatialReference, Margin, Attributes };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>创建掩膜所使用的输入线图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>含有掩膜要素的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFc { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>用于在使用页面单位指定掩膜时计算掩膜几何的参考比例。该比例通常是地图的参考比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Calculation coordinate system</para>
		/// <para>将创建掩膜面的地图的空间参考。该空间参考不是要分配给输出要素类的空间参考。它是地图的空间参考；由于投影要素时，符号系统的位置可能发生变化，所以在该空间参考内将使用掩膜面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Margin</para>
		/// <para>在用于创建掩膜面的符号化输入要素周围的间距（使用页面单位）。通常，创建掩膜面时，在符号的周围留有小边距，以提高显示效果。边距值可使用页面单位或地图单位指定。通常，您需要使用页面单位来指定边距值。</para>
		/// <para>边距值不能为负。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Margin { get; set; } = "0 Points";

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// <para>指定将从输入要素传递到输出要素的属性。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素。这是默认设置。</para>
		/// <para>除要素 ID 外的所有属性—输入要素中，除 FID 以外的所有属性都将传递到输出要素。</para>
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
		public CulDeSacMasks SetEnviroment(object cartographicCoordinateSystem = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>除要素 ID 外的所有属性—输入要素中，除 FID 以外的所有属性都将传递到输出要素。</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("除要素 ID 外的所有属性")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素。这是默认设置。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_feature_IDs,

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
