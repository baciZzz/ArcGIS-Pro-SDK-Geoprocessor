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
	/// <para>Generate Hachures For Defined Slopes</para>
	/// <para>为定义的坡度生成影线</para>
	/// <para>用于在表示坡度的上部和下部的线之间创建表示坡度的多部分线或面。</para>
	/// </summary>
	public class GenerateHachuresForDefinedSlopes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="UpperLines">
		/// <para>Upper Line Features</para>
		/// <para>表示斜坡顶部的线要素。</para>
		/// </param>
		/// <param name="LowerLines">
		/// <para>Lower Line Features</para>
		/// <para>表示斜坡底部的线要素。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>此输出要素类包含表示坡度区域的多部分线或面影线。</para>
		/// </param>
		public GenerateHachuresForDefinedSlopes(object UpperLines, object LowerLines, object OutputFeatureClass)
		{
			this.UpperLines = UpperLines;
			this.LowerLines = LowerLines;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 为定义的坡度生成影线</para>
		/// </summary>
		public override string DisplayName() => "为定义的坡度生成影线";

		/// <summary>
		/// <para>Tool Name : GenerateHachuresForDefinedSlopes</para>
		/// </summary>
		public override string ToolName() => "GenerateHachuresForDefinedSlopes";

		/// <summary>
		/// <para>Tool Excute Name : cartography.GenerateHachuresForDefinedSlopes</para>
		/// </summary>
		public override string ExcuteName() => "cartography.GenerateHachuresForDefinedSlopes";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "ZDomain", "extent", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { UpperLines, LowerLines, OutputFeatureClass, OutputType!, FullyConnected!, SearchDistance!, Interval!, MinimumLength!, AlternateHachures!, Perpendicular!, PolygonBaseWidth! };

		/// <summary>
		/// <para>Upper Line Features</para>
		/// <para>表示斜坡顶部的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object UpperLines { get; set; }

		/// <summary>
		/// <para>Lower Line Features</para>
		/// <para>表示斜坡底部的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object LowerLines { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>此输出要素类包含表示坡度区域的多部分线或面影线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Type</para>
		/// <para>指定是否将创建面三角形或刻度线来表示坡度。</para>
		/// <para>面三角形—将创建多部分面要素，可在其中为每个影线创建三角形面（具有沿着上线的基线）。 这是默认设置。</para>
		/// <para>线刻度—系统将创建多部分线要素，可在其中为每个影线创建线性刻度。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputType { get; set; } = "POLYGON_TRIANGLES";

		/// <summary>
		/// <para>Fully connected</para>
		/// <para>指定输入数据中的上下线是否来自完全连接的区域。 如果上下线未完全连接，请取消选中此参数，以在通过连接上下要素的端点而派生的区域内创建影线。 如果上下线已完全连接，请选中此参数以在完全封闭的区域内创建影线。</para>
		/// <para>未选中 - 输入数据中的上下要素未完全链接。 将派生上下部要素之间的新连接。 这是默认设置。</para>
		/// <para>选中 - 输入数据中的上下要素将完全链接。 不会派生部要素之间的新连接。</para>
		/// <para><see cref="FullyConnectedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FullyConnected { get; set; } = "false";

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>获取上部要素和下部要素之间的连接时使用的距离。 当上部和下部要素的端点位于此距离内时，要素之间的区域将用于创建影线。 默认值是 20 米。 选中完全连接参数时，此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; } = "20 Meters";

		/// <summary>
		/// <para>Hachure Interval</para>
		/// <para>坡度区域内影线刻度或三角形之间的距离。 默认值是 10 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Interval { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>必须创建影线刻度或三角形的长度。 短于此长度的影线将不会被创建。 默认值是 0 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumLength { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Alternate length of every other hachure</para>
		/// <para>指定所有其他三角形或刻度的长度是否会不同。</para>
		/// <para>未选中 - 所有影线的长度（即，上下坡度线之间的距离）均等。 这是默认设置。</para>
		/// <para>选中 - 所有其他影线都将是上下坡度线之间距离的一半。</para>
		/// <para><see cref="AlternateHachuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AlternateHachures { get; set; } = "false";

		/// <summary>
		/// <para>Perpendicular to upper line</para>
		/// <para>指定影线刻度或三角形是否将垂直于上坡线。</para>
		/// <para>未选中 - 将对影线定向以获得均匀的间距。 这是默认设置。</para>
		/// <para>选中 - 将垂直于上线对影线进行定向。</para>
		/// <para><see cref="PerpendicularEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Perpendicular { get; set; } = "false";

		/// <summary>
		/// <para>Polygon Base Width</para>
		/// <para>三角形面影线底部的宽度。 仅当输出要素类型参数设置为面三角形时，此参数才会处于活动状态。 默认值是 5 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? PolygonBaseWidth { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateHachuresForDefinedSlopes SetEnviroment(object? MDomain = null , object? ZDomain = null , object? extent = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(MDomain: MDomain, ZDomain: ZDomain, extent: extent, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>面三角形—将创建多部分面要素，可在其中为每个影线创建三角形面（具有沿着上线的基线）。 这是默认设置。</para>
			/// </summary>
			[GPValue("POLYGON_TRIANGLES")]
			[Description("面三角形")]
			Polygon_triangles,

			/// <summary>
			/// <para>线刻度—系统将创建多部分线要素，可在其中为每个影线创建线性刻度。</para>
			/// </summary>
			[GPValue("LINE_TICKS")]
			[Description("线刻度")]
			Line_ticks,

		}

		/// <summary>
		/// <para>Fully connected</para>
		/// </summary>
		public enum FullyConnectedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FULLY_CONNECTED")]
			FULLY_CONNECTED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_CONNECTED")]
			NOT_CONNECTED,

		}

		/// <summary>
		/// <para>Alternate length of every other hachure</para>
		/// </summary>
		public enum AlternateHachuresEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALTERNATE_HACHURES")]
			ALTERNATE_HACHURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("UNIFORM_HACHURES")]
			UNIFORM_HACHURES,

		}

		/// <summary>
		/// <para>Perpendicular to upper line</para>
		/// </summary>
		public enum PerpendicularEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PERPENDICULAR")]
			PERPENDICULAR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PERPENDICULAR")]
			NOT_PERPENDICULAR,

		}

#endregion
	}
}
