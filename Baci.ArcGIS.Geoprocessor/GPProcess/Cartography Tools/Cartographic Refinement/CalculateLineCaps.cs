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
	/// <para>Calculate Line Caps</para>
	/// <para>计算线端头</para>
	/// <para>在输入图层的线符号中修改笔划符号图层的端头类型。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateLineCaps : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含线符号的输入要素图层。 笔划符号图层的端头类型属性必须连接到未应用表达式的单个特性字段。 可通过此工具更新该字段中的值。</para>
		/// </param>
		public CalculateLineCaps(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算线端头</para>
		/// </summary>
		public override string DisplayName() => "计算线端头";

		/// <summary>
		/// <para>Tool Name : CalculateLineCaps</para>
		/// </summary>
		public override string ToolName() => "CalculateLineCaps";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateLineCaps</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateLineCaps";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, CapType!, DangleOption!, OutRepresentations! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含线符号的输入要素图层。 笔划符号图层的端头类型属性必须连接到未应用表达式的单个特性字段。 可通过此工具更新该字段中的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Cap Type</para>
		/// <para>指定笔划符号图层末端的绘制方式。 笔划的默认端头类型是圆形，即符号末端是半径等于笔划宽度且在线端点居中的半圆。</para>
		/// <para>平端头类型—笔划符号恰好在线几何结束位置处终止。 这是默认设置。</para>
		/// <para>方形端头类型—用沿线端点向外延伸半个符号宽度的闭合式方形端头终止笔划符号。</para>
		/// <para><see cref="CapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CapType { get; set; } = "BUTT";

		/// <summary>
		/// <para>Dangle Option</para>
		/// <para>指定为共用一个端点但使用不同符号系统绘制的邻接线要素计算线端头的方式。</para>
		/// <para>实线悬挂—修改悬挂线（端点未与其他线相连的线）的端头样式以及下述线的端头样式：实线符号与单笔划图层线符号的端点相连的线。 这是默认设置。</para>
		/// <para>实际悬挂—仅修改未与其他要素相连的端点的端头样式。</para>
		/// <para><see cref="DangleOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DangleOption { get; set; } = "CASED_LINE_DANGLE";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? OutRepresentations { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Cap Type</para>
		/// </summary>
		public enum CapTypeEnum 
		{
			/// <summary>
			/// <para>平端头类型—笔划符号恰好在线几何结束位置处终止。 这是默认设置。</para>
			/// </summary>
			[GPValue("BUTT")]
			[Description("平端头类型")]
			Butt__cap_type,

			/// <summary>
			/// <para>方形端头类型—用沿线端点向外延伸半个符号宽度的闭合式方形端头终止笔划符号。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("方形端头类型")]
			Square_cap_type,

		}

		/// <summary>
		/// <para>Dangle Option</para>
		/// </summary>
		public enum DangleOptionEnum 
		{
			/// <summary>
			/// <para>实线悬挂—修改悬挂线（端点未与其他线相连的线）的端头样式以及下述线的端头样式：实线符号与单笔划图层线符号的端点相连的线。 这是默认设置。</para>
			/// </summary>
			[GPValue("CASED_LINE_DANGLE")]
			[Description("实线悬挂")]
			Cased_line_dangle,

			/// <summary>
			/// <para>实际悬挂—仅修改未与其他要素相连的端点的端头样式。</para>
			/// </summary>
			[GPValue("TRUE_DANGLE")]
			[Description("实际悬挂")]
			True_dangle,

		}

#endregion
	}
}
