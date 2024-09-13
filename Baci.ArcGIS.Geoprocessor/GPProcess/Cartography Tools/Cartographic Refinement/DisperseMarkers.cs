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
	/// <para>Disperse Markers</para>
	/// <para>分散标记</para>
	/// <para>查找基于参考比例符号系统的叠置或距离太近的点符号，并根据最小间距和分散模式将其分散。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisperseMarkers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>要分散的输入点要素图层。</para>
		/// </param>
		/// <param name="MinimumSpacing">
		/// <para>Minimum Spacing</para>
		/// <para>各点符号间的最小间距（页面单位）。 必须指定大于或等于零的搜索距离。 指定正值时，将按该值分离标记；指定零值时，点符号将互相接触。 默认页面单位是“磅”。</para>
		/// </param>
		public DisperseMarkers(object InPointFeatures, object MinimumSpacing)
		{
			this.InPointFeatures = InPointFeatures;
			this.MinimumSpacing = MinimumSpacing;
		}

		/// <summary>
		/// <para>Tool Display Name : 分散标记</para>
		/// </summary>
		public override string DisplayName() => "分散标记";

		/// <summary>
		/// <para>Tool Name : DisperseMarkers</para>
		/// </summary>
		public override string ToolName() => "DisperseMarkers";

		/// <summary>
		/// <para>Tool Excute Name : cartography.DisperseMarkers</para>
		/// </summary>
		public override string ExcuteName() => "cartography.DisperseMarkers";

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
		public override object[] Parameters() => new object[] { InPointFeatures, MinimumSpacing, DispersalPattern, OutRepresentations };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>要分散的输入点要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Spacing</para>
		/// <para>各点符号间的最小间距（页面单位）。 必须指定大于或等于零的搜索距离。 指定正值时，将按该值分离标记；指定零值时，点符号将互相接触。 默认页面单位是“磅”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MinimumSpacing { get; set; }

		/// <summary>
		/// <para>Dispersal Pattern</para>
		/// <para>指定点符号的分散模式。 一组点符号将会有一个根据该组中所有点位置派生出来的质心。 将质心用作分散模式围绕其运行的锚点。</para>
		/// <para>已展开—点符号分散开时，会保留其常规模式。 恰巧重合的点将分散到质心周围的圆上。 这是默认设置。</para>
		/// <para>随机—点符号以随机分散的模式分布在质心的周围，但是要考虑最小间距。</para>
		/// <para>方形—点符号分布在质心周围的多个方形环中，并使所有点按最小间距参数的容许值尽量紧密分布在一起。</para>
		/// <para>环—点符号分布在质心周围的多个圆形环中，并使所有点按最小间距参数的容许值尽量紧密分布在一起。</para>
		/// <para>方形—点符号以单一方形模式均匀分布在质心周围。</para>
		/// <para>环—点符号以单一圆形模式均匀分布在质心周围。</para>
		/// <para>十字形—点符号均匀分布在质心为原点的水平和垂直轴上。</para>
		/// <para>X 型交叉—点符号均匀分布在质心为原点的成 45° 的两个轴上。</para>
		/// <para><see cref="DispersalPatternEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DispersalPattern { get; set; } = "EXPANDED";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DisperseMarkers SetEnviroment(object cartographicCoordinateSystem = null , object referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dispersal Pattern</para>
		/// </summary>
		public enum DispersalPatternEnum 
		{
			/// <summary>
			/// <para>已展开—点符号分散开时，会保留其常规模式。 恰巧重合的点将分散到质心周围的圆上。 这是默认设置。</para>
			/// </summary>
			[GPValue("EXPANDED")]
			[Description("已展开")]
			Expanded,

			/// <summary>
			/// <para>随机—点符号以随机分散的模式分布在质心的周围，但是要考虑最小间距。</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("随机")]
			Random,

			/// <summary>
			/// <para>方形—点符号分布在质心周围的多个方形环中，并使所有点按最小间距参数的容许值尽量紧密分布在一起。</para>
			/// </summary>
			[GPValue("SQUARES")]
			[Description("方形")]
			Squares,

			/// <summary>
			/// <para>环—点符号分布在质心周围的多个圆形环中，并使所有点按最小间距参数的容许值尽量紧密分布在一起。</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("环")]
			Rings,

			/// <summary>
			/// <para>方形—点符号分布在质心周围的多个方形环中，并使所有点按最小间距参数的容许值尽量紧密分布在一起。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("方形")]
			Square,

			/// <summary>
			/// <para>环—点符号分布在质心周围的多个圆形环中，并使所有点按最小间距参数的容许值尽量紧密分布在一起。</para>
			/// </summary>
			[GPValue("RING")]
			[Description("环")]
			Ring,

			/// <summary>
			/// <para>十字形—点符号均匀分布在质心为原点的水平和垂直轴上。</para>
			/// </summary>
			[GPValue("CROSS")]
			[Description("十字形")]
			Cross,

			/// <summary>
			/// <para>X 型交叉—点符号均匀分布在质心为原点的成 45° 的两个轴上。</para>
			/// </summary>
			[GPValue("X_CROSS")]
			[Description("X 型交叉")]
			X_CROSS,

		}

#endregion
	}
}
