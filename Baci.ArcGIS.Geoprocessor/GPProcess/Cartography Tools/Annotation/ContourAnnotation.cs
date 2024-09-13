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
	/// <para>Contour Annotation</para>
	/// <para>等值线注记</para>
	/// <para>创建等值线要素的注记。</para>
	/// </summary>
	public class ContourAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要创建注记的等值线要素类。</para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>用来保存输出要素类的工作空间。 此工作空间可以是现有地理数据库或现有要素数据集。</para>
		/// </param>
		/// <param name="ContourLabelField">
		/// <para>Contour Label Field</para>
		/// <para>注记文本基于的输入图层属性表中的字段。</para>
		/// </param>
		/// <param name="ReferenceScaleValue">
		/// <para>Reference Scale</para>
		/// <para>将用作注记参考的比例。 注记中的所有符号及文本的大小都会参照此处设置的参考比例。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer Name</para>
		/// <para>将包含等值线图层、注记和掩膜图层的图层组。 在目录窗格中工作时，可使用保存至图层文件工具将输出图层组写入图层文件中。 使用 ArcGIS Pro 时，如果将输出数据集添加至打开的地图选项在选项对话框的地理处理选项卡中为选中状态，则该工具会将组图层添加到显示中。 所创建的图层组是临时性的，如果不保存文档，该图层组将在会话结束后消失。</para>
		/// </param>
		/// <param name="ContourColor">
		/// <para>Contour and Label Color</para>
		/// <para>指定输出等值线图层和注记要素的颜色。</para>
		/// <para>黑色—输出等值线图层和注记要素将以黑色绘制。 这是默认设置。</para>
		/// <para>褐色—输出等值线图层和注记要素将以褐色绘制。</para>
		/// <para>蓝色—输出等值线图层和注记要素将以蓝色绘制。</para>
		/// <para><see cref="ContourColorEnum"/></para>
		/// </param>
		public ContourAnnotation(object InFeatures, object OutGeodatabase, object ContourLabelField, object ReferenceScaleValue, object OutLayer, object ContourColor)
		{
			this.InFeatures = InFeatures;
			this.OutGeodatabase = OutGeodatabase;
			this.ContourLabelField = ContourLabelField;
			this.ReferenceScaleValue = ReferenceScaleValue;
			this.OutLayer = OutLayer;
			this.ContourColor = ContourColor;
		}

		/// <summary>
		/// <para>Tool Display Name : 等值线注记</para>
		/// </summary>
		public override string DisplayName() => "等值线注记";

		/// <summary>
		/// <para>Tool Name : ContourAnnotation</para>
		/// </summary>
		public override string ToolName() => "ContourAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ContourAnnotation</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ContourAnnotation";

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
		public override string[] ValidEnvironments() => new string[] { "annotationTextStringFieldLength", "outputCoordinateSystem", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutGeodatabase, ContourLabelField, ReferenceScaleValue, OutLayer, ContourColor, ContourTypeField, ContourAlignment, EnableLaddering, OutGeodatabase2 };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要创建注记的等值线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>用来保存输出要素类的工作空间。 此工作空间可以是现有地理数据库或现有要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Contour Label Field</para>
		/// <para>注记文本基于的输入图层属性表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object ContourLabelField { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>将用作注记参考的比例。 注记中的所有符号及文本的大小都会参照此处设置的参考比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScaleValue { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>将包含等值线图层、注记和掩膜图层的图层组。 在目录窗格中工作时，可使用保存至图层文件工具将输出图层组写入图层文件中。 使用 ArcGIS Pro 时，如果将输出数据集添加至打开的地图选项在选项对话框的地理处理选项卡中为选中状态，则该工具会将组图层添加到显示中。 所创建的图层组是临时性的，如果不保存文档，该图层组将在会话结束后消失。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutLayer { get; set; } = "Contours";

		/// <summary>
		/// <para>Contour and Label Color</para>
		/// <para>指定输出等值线图层和注记要素的颜色。</para>
		/// <para>黑色—输出等值线图层和注记要素将以黑色绘制。 这是默认设置。</para>
		/// <para>褐色—输出等值线图层和注记要素将以褐色绘制。</para>
		/// <para>蓝色—输出等值线图层和注记要素将以蓝色绘制。</para>
		/// <para><see cref="ContourColorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourColor { get; set; } = "BLACK";

		/// <summary>
		/// <para>Contour Type Field</para>
		/// <para>包含等值线要素类型值的输入图层属性表中的字段。 将为各类型值创建注记类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ContourTypeField { get; set; }

		/// <summary>
		/// <para>Contour Alignment</para>
		/// <para>指定注记将与等值线高程对齐的方法。 注记可以与等值线高程对齐，从而使文本的顶部始终朝上或朝下。 上述选项允许注记倒置。 等值线注记还可与页面对齐，从而确保文本不会倒置。</para>
		/// <para>将文本顶部对齐到页面顶部—等值线注记将与页面对齐，从而确保文本不会倒置。 这是默认设置。</para>
		/// <para>将文本顶部朝上对齐—等值线注记将与等值线高程对齐，从而使文本的顶部始终朝上。 该选项允许注记倒置。</para>
		/// <para>将文本顶部朝下对齐—等值线注记将与等值线高程对齐，从而使文本的顶部始终朝下。 该选项允许注记倒置。</para>
		/// <para><see cref="ContourAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ContourAlignment { get; set; } = "PAGE";

		/// <summary>
		/// <para>Enable Laddering</para>
		/// <para>指定是否以阶梯方式放置注记。 以阶梯方式放置注记将会使文本看起来像是沿着等值线的值递增或递减的方向排成一条笔直的线。 这些阶梯将按从山顶到山脚的形式排列、彼此不会交叉、同属于一个坡度且不会与任何其他坡度交叉。</para>
		/// <para>选中 - 注记将会沿着等值线的值递增或递减的方向排成一条笔直的线。</para>
		/// <para>未选中 - 注记将不会沿着等值线的值递增或递减的方向排成一条笔直的线。 这是默认设置。</para>
		/// <para><see cref="EnableLadderingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableLaddering { get; set; } = "false";

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutGeodatabase2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ContourAnnotation SetEnviroment(object outputCoordinateSystem = null , object referenceScale = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contour and Label Color</para>
		/// </summary>
		public enum ContourColorEnum 
		{
			/// <summary>
			/// <para>黑色—输出等值线图层和注记要素将以黑色绘制。 这是默认设置。</para>
			/// </summary>
			[GPValue("BLACK")]
			[Description("黑色")]
			Black,

			/// <summary>
			/// <para>褐色—输出等值线图层和注记要素将以褐色绘制。</para>
			/// </summary>
			[GPValue("BROWN")]
			[Description("褐色")]
			Brown,

			/// <summary>
			/// <para>蓝色—输出等值线图层和注记要素将以蓝色绘制。</para>
			/// </summary>
			[GPValue("BLUE")]
			[Description("蓝色")]
			Blue,

		}

		/// <summary>
		/// <para>Contour Alignment</para>
		/// </summary>
		public enum ContourAlignmentEnum 
		{
			/// <summary>
			/// <para>将文本顶部对齐到页面顶部—等值线注记将与页面对齐，从而确保文本不会倒置。 这是默认设置。</para>
			/// </summary>
			[GPValue("PAGE")]
			[Description("将文本顶部对齐到页面顶部")]
			Align_top_of_text__to_top_of_page,

			/// <summary>
			/// <para>将文本顶部朝上对齐—等值线注记将与等值线高程对齐，从而使文本的顶部始终朝上。 该选项允许注记倒置。</para>
			/// </summary>
			[GPValue("UPHILL")]
			[Description("将文本顶部朝上对齐")]
			Align_top_of_text_uphill,

			/// <summary>
			/// <para>将文本顶部朝下对齐—等值线注记将与等值线高程对齐，从而使文本的顶部始终朝下。 该选项允许注记倒置。</para>
			/// </summary>
			[GPValue("DOWNHILL")]
			[Description("将文本顶部朝下对齐")]
			Align_top_of_text_downhill,

		}

		/// <summary>
		/// <para>Enable Laddering</para>
		/// </summary>
		public enum EnableLadderingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_LADDERING")]
			ENABLE_LADDERING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_ENABLE_LADDERING")]
			NOT_ENABLE_LADDERING,

		}

#endregion
	}
}
