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
	/// <para>Thin Road Network</para>
	/// <para>稀疏化道路网</para>
	/// <para>可生成保留连通性和一般字符的简化道路网，从而实现以较小比例显示道路。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ThinRoadNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Road Features</para>
		/// <para>为创建简化集合以便以较小比例显示而进行稀疏化的输入线状道路。</para>
		/// </param>
		/// <param name="MinimumLength">
		/// <para>Minimum Length</para>
		/// <para>指明在输出比例下需要清晰显示的最短路段。 该参数可用于控制生成道路集合的分辨率或密度。 如果单位是磅、毫米、厘米或英寸，则值被视为使用页面单位，还会将参考比例考虑在内。</para>
		/// </param>
		/// <param name="InvisibilityField">
		/// <para>Invisibility Field</para>
		/// <para>该字段用于存储工具的生成结果。 位于所生成简化道路集合中的要素值设为 0（零）。 无关要素的值设为 1。 您可使用图层定义查询显示生成的道路集合。 对于各输入要素类，该字段必须存在并且指定为相同的值。</para>
		/// </param>
		/// <param name="HierarchyField">
		/// <para>Hierarchy Field</para>
		/// <para>该字段包含要素重要性的等级级别，其中 1 表示非常重要，重要性随整数值的增大而递减。 如果值设为 0，则要素在输出集合中必须维持可见状态。 对于各输入要素类，该字段必须存在并且指定为相同的值。 等于“空”的等级值将不被接受，并且会引发错误。</para>
		/// </param>
		public ThinRoadNetwork(object InFeatures, object MinimumLength, object InvisibilityField, object HierarchyField)
		{
			this.InFeatures = InFeatures;
			this.MinimumLength = MinimumLength;
			this.InvisibilityField = InvisibilityField;
			this.HierarchyField = HierarchyField;
		}

		/// <summary>
		/// <para>Tool Display Name : 稀疏化道路网</para>
		/// </summary>
		public override string DisplayName() => "稀疏化道路网";

		/// <summary>
		/// <para>Tool Name : ThinRoadNetwork</para>
		/// </summary>
		public override string ToolName() => "ThinRoadNetwork";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ThinRoadNetwork</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ThinRoadNetwork";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MinimumLength, InvisibilityField, HierarchyField, OutFeatures };

		/// <summary>
		/// <para>Input Road Features</para>
		/// <para>为创建简化集合以便以较小比例显示而进行稀疏化的输入线状道路。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>指明在输出比例下需要清晰显示的最短路段。 该参数可用于控制生成道路集合的分辨率或密度。 如果单位是磅、毫米、厘米或英寸，则值被视为使用页面单位，还会将参考比例考虑在内。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumLength { get; set; }

		/// <summary>
		/// <para>Invisibility Field</para>
		/// <para>该字段用于存储工具的生成结果。 位于所生成简化道路集合中的要素值设为 0（零）。 无关要素的值设为 1。 您可使用图层定义查询显示生成的道路集合。 对于各输入要素类，该字段必须存在并且指定为相同的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InvisibilityField { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>该字段包含要素重要性的等级级别，其中 1 表示非常重要，重要性随整数值的增大而递减。 如果值设为 0，则要素在输出集合中必须维持可见状态。 对于各输入要素类，该字段必须存在并且指定为相同的值。 等于“空”的等级值将不被接受，并且会引发错误。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object HierarchyField { get; set; }

		/// <summary>
		/// <para>Updated Input Road Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ThinRoadNetwork SetEnviroment(object cartographicCoordinateSystem = null , object cartographicPartitions = null , object referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
