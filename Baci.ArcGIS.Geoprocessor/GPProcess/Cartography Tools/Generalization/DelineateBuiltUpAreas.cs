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
	/// <para>Delineate Built-Up Areas</para>
	/// <para>描绘构建区</para>
	/// <para>通过在小比例地图上描绘紧密排列的建筑物来创建面表示构建区。</para>
	/// </summary>
	public class DelineateBuiltUpAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBuildings">
		/// <para>Input Building Layers</para>
		/// <para>包含其密度和排列用于定义合适的输出构建面的建筑物的图层。 可同时评估多个建筑物图层。 建筑物要素可以是点或面。</para>
		/// </param>
		/// <param name="GroupingDistance">
		/// <para>Grouping Distance</para>
		/// <para>小于分组距离的建筑物将全部被视为可使用输出构建区面表示的候选项。 该距离从面建筑物的边和点建筑物的中心开始测量。</para>
		/// </param>
		/// <param name="MinimumDetailSize">
		/// <para>Minimum Detail Size</para>
		/// <para>输出构建区面的相对细节层次。 这与构建区面中的孔或洞允许的最小直径相近。 面中孔和洞的实际大小和形状还由输入建筑物的排列、分组距离和边要素的存在来确定（如果使用它们）。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含表示紧密排列的输入建筑物的构建区面的输出要素类。</para>
		/// </param>
		public DelineateBuiltUpAreas(object InBuildings, object GroupingDistance, object MinimumDetailSize, object OutFeatureClass)
		{
			this.InBuildings = InBuildings;
			this.GroupingDistance = GroupingDistance;
			this.MinimumDetailSize = MinimumDetailSize;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 描绘构建区</para>
		/// </summary>
		public override string DisplayName() => "描绘构建区";

		/// <summary>
		/// <para>Tool Name : DelineateBuiltUpAreas</para>
		/// </summary>
		public override string ToolName() => "DelineateBuiltUpAreas";

		/// <summary>
		/// <para>Tool Excute Name : cartography.DelineateBuiltUpAreas</para>
		/// </summary>
		public override string ExcuteName() => "cartography.DelineateBuiltUpAreas";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBuildings, IdentifierField, EdgeFeatures, GroupingDistance, MinimumDetailSize, OutFeatureClass, MinimumBuildingCount };

		/// <summary>
		/// <para>Input Building Layers</para>
		/// <para>包含其密度和排列用于定义合适的输出构建面的建筑物的图层。 可同时评估多个建筑物图层。 建筑物要素可以是点或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		public object InBuildings { get; set; }

		/// <summary>
		/// <para>Identifier Field</para>
		/// <para>输入要素类中的字段，保存指示输入要素是否为生成的构建区的一部分的状态码。 该字段必须是短整型或长整型，并且在所有输入图层中通用（如果使用多个输入图层）。</para>
		/// <para>0 - 建筑物不使用输出构建区面表示。</para>
		/// <para>1 - 建筑物使用输出构建区面表示且位于生成的面要素之内。</para>
		/// <para>2 - 建筑物使用输出构建区面表示且位于生成的面要素之外。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IdentifierField { get; set; }

		/// <summary>
		/// <para>Edge Features</para>
		/// <para>将用来定义构建区面的边的图层。 通常为道路，其他一些常见示例有：河流、海岸线和行政区。 如果构建区面与面的边的趋势大致对齐且在分组距离之内，则构建区面会捕捉到边要素。 边要素可以是线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		public object EdgeFeatures { get; set; }

		/// <summary>
		/// <para>Grouping Distance</para>
		/// <para>小于分组距离的建筑物将全部被视为可使用输出构建区面表示的候选项。 该距离从面建筑物的边和点建筑物的中心开始测量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object GroupingDistance { get; set; }

		/// <summary>
		/// <para>Minimum Detail Size</para>
		/// <para>输出构建区面的相对细节层次。 这与构建区面中的孔或洞允许的最小直径相近。 面中孔和洞的实际大小和形状还由输入建筑物的排列、分组距离和边要素的存在来确定（如果使用它们）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumDetailSize { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含表示紧密排列的输入建筑物的构建区面的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Building Count</para>
		/// <para>必须共同代表输出构建区面的建筑物的最小数量。 默认值为 4。 最小建筑物计数必须大于或等于 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MinimumBuildingCount { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DelineateBuiltUpAreas SetEnviroment(object cartographicPartitions = null, object referenceScale = null)
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
