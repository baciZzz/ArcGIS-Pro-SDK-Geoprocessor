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
	/// <para>Propagate Displacement</para>
	/// <para>传递位移</para>
	/// <para>将解决道路冲突工具和合并分开的道路工具中的道路校正所产生的位移传递到相邻要素，以重新建立空间关系。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class PropagateDisplacement : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含可能存在冲突的要素的输入要素图层。所包含的要素可以是点、线或面。</para>
		/// </param>
		/// <param name="DisplacementFeatures">
		/// <para>Displacement Features</para>
		/// <para>由解决道路冲突工具或合并分开的道路工具创建的位移面要素，其中包含发生的道路位移的程度和方向。将通过这些面确定要传递到输入要素的位移量。</para>
		/// </param>
		/// <param name="AdjustmentStyle">
		/// <para>Adjustment Style</para>
		/// <para>定义移动输入要素时所要使用的校正类型。</para>
		/// <para>自动—此工具将确定各输入要素是适合 SOLID 校正还是适合 ELASTIC 校正。通常，具有正交形状的要素将应用 SOLID 校正，而有机形状的要素将应用 ELASTIC 校正。这是默认设置。</para>
		/// <para>实线—要素将被转换。所有折点将向同一方向移动相同的距离。可能会产生拓扑错误。当输入要素有着规则几何形状时，此选项最有用。</para>
		/// <para>弹性—可单独移动要素的各折点以使要素最大程度地适应道路网。可能会略微修改要素的形状。不太可能产生拓扑错误。此选项仅应用于线和面输入要素。此选项对有机形状的输入要素最有用。</para>
		/// <para><see cref="AdjustmentStyleEnum"/></para>
		/// </param>
		public PropagateDisplacement(object InFeatures, object DisplacementFeatures, object AdjustmentStyle)
		{
			this.InFeatures = InFeatures;
			this.DisplacementFeatures = DisplacementFeatures;
			this.AdjustmentStyle = AdjustmentStyle;
		}

		/// <summary>
		/// <para>Tool Display Name : 传递位移</para>
		/// </summary>
		public override string DisplayName() => "传递位移";

		/// <summary>
		/// <para>Tool Name : PropagateDisplacement</para>
		/// </summary>
		public override string ToolName() => "PropagateDisplacement";

		/// <summary>
		/// <para>Tool Excute Name : cartography.PropagateDisplacement</para>
		/// </summary>
		public override string ExcuteName() => "cartography.PropagateDisplacement";

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
		public override object[] Parameters() => new object[] { InFeatures, DisplacementFeatures, AdjustmentStyle, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含可能存在冲突的要素的输入要素图层。所包含的要素可以是点、线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Displacement Features</para>
		/// <para>由解决道路冲突工具或合并分开的道路工具创建的位移面要素，其中包含发生的道路位移的程度和方向。将通过这些面确定要传递到输入要素的位移量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object DisplacementFeatures { get; set; }

		/// <summary>
		/// <para>Adjustment Style</para>
		/// <para>定义移动输入要素时所要使用的校正类型。</para>
		/// <para>自动—此工具将确定各输入要素是适合 SOLID 校正还是适合 ELASTIC 校正。通常，具有正交形状的要素将应用 SOLID 校正，而有机形状的要素将应用 ELASTIC 校正。这是默认设置。</para>
		/// <para>实线—要素将被转换。所有折点将向同一方向移动相同的距离。可能会产生拓扑错误。当输入要素有着规则几何形状时，此选项最有用。</para>
		/// <para>弹性—可单独移动要素的各折点以使要素最大程度地适应道路网。可能会略微修改要素的形状。不太可能产生拓扑错误。此选项仅应用于线和面输入要素。此选项对有机形状的输入要素最有用。</para>
		/// <para><see cref="AdjustmentStyleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AdjustmentStyle { get; set; } = "AUTO";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Adjustment Style</para>
		/// </summary>
		public enum AdjustmentStyleEnum 
		{
			/// <summary>
			/// <para>自动—此工具将确定各输入要素是适合 SOLID 校正还是适合 ELASTIC 校正。通常，具有正交形状的要素将应用 SOLID 校正，而有机形状的要素将应用 ELASTIC 校正。这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("自动")]
			Automatic,

			/// <summary>
			/// <para>实线—要素将被转换。所有折点将向同一方向移动相同的距离。可能会产生拓扑错误。当输入要素有着规则几何形状时，此选项最有用。</para>
			/// </summary>
			[GPValue("SOLID")]
			[Description("实线")]
			Solid,

			/// <summary>
			/// <para>弹性—可单独移动要素的各折点以使要素最大程度地适应道路网。可能会略微修改要素的形状。不太可能产生拓扑错误。此选项仅应用于线和面输入要素。此选项对有机形状的输入要素最有用。</para>
			/// </summary>
			[GPValue("ELASTIC")]
			[Description("弹性")]
			Elastic,

		}

#endregion
	}
}
