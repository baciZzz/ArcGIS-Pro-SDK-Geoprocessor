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
	/// <para>Merge Divided Roads</para>
	/// <para>合并分开的道路</para>
	/// <para>生成单线道路要素来代替匹配的两条分开的道路车道。</para>
	/// </summary>
	public class MergeDividedRoads : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入线状道路要素，包含多对将合并为单个输出线要素的分开的道路车道。</para>
		/// </param>
		/// <param name="MergeField">
		/// <para>Merge Field</para>
		/// <para>包含道路分类信息的字段。 将只合并平行且接近的相同类型道路。 值 0（零）将锁定要素以阻止其参与合并。</para>
		/// </param>
		/// <param name="MergeDistance">
		/// <para>Merge Distance</para>
		/// <para>要合并的相互平行的同类道路要素的最小距离间隔（使用指定的单位）。 此距离必须大于零。 如果单位是磅、毫米、厘米或英寸，则值被视为使用页面单位，还会将参考比例考虑在内。</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类，包含表示已合并道路要素的单线以及所有未合并的道路要素。</para>
		/// </param>
		public MergeDividedRoads(object InFeatures, object MergeField, object MergeDistance, object OutFeatures)
		{
			this.InFeatures = InFeatures;
			this.MergeField = MergeField;
			this.MergeDistance = MergeDistance;
			this.OutFeatures = OutFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并分开的道路</para>
		/// </summary>
		public override string DisplayName() => "合并分开的道路";

		/// <summary>
		/// <para>Tool Name : MergeDividedRoads</para>
		/// </summary>
		public override string ToolName() => "MergeDividedRoads";

		/// <summary>
		/// <para>Tool Excute Name : cartography.MergeDividedRoads</para>
		/// </summary>
		public override string ExcuteName() => "cartography.MergeDividedRoads";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MergeField, MergeDistance, OutFeatures, OutDisplacementFeatures!, CharacterField!, OutTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入线状道路要素，包含多对将合并为单个输出线要素的分开的道路车道。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Merge Field</para>
		/// <para>包含道路分类信息的字段。 将只合并平行且接近的相同类型道路。 值 0（零）将锁定要素以阻止其参与合并。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object MergeField { get; set; }

		/// <summary>
		/// <para>Merge Distance</para>
		/// <para>要合并的相互平行的同类道路要素的最小距离间隔（使用指定的单位）。 此距离必须大于零。 如果单位是磅、毫米、厘米或英寸，则值被视为使用页面单位，还会将参考比例考虑在内。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MergeDistance { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类，包含表示已合并道路要素的单线以及所有未合并的道路要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Output Displacement Feature Class</para>
		/// <para>输出面要素包含道路位移的程度和方向。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? OutDisplacementFeatures { get; set; }

		/// <summary>
		/// <para>Road Character Field</para>
		/// <para>指定一个用于表示路段特征的数字字段，不需要考虑道路的分类。 这些值有助于工具对要进行合并的候选要素对的评估进行优化。 在异常或复杂的道路网中使用此参数可提高输出质量。 如果此参数为空值（或未指定此参数），则道路特征（和合并候选项）将仅基于要素的形状和排列。 使用值 999 可以锁定要素以阻止其参与合并。</para>
		/// <para>字段值评估如下：</para>
		/// <para>0 - 交通环岛或环状交叉路</para>
		/// <para>1 - 马路、大道、双车道高速公路或其他平行走向的道路</para>
		/// <para>2 - 上坡或下坡，高速公路交叉点连接符</para>
		/// <para>999 - 不会合并的要素</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? CharacterField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>一个将合并后的道路要素与其源要素进行链接的多对多关系表。 该表包含两个字段：OUTPUT_FID 和 INPUT_FID，分别用于存储合并后的要素 ID 和其源要素 ID。 使用此表根据源要素派生输出要素的必要属性。 当该参数留空时，不创建任何表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeDividedRoads SetEnviroment(object? cartographicCoordinateSystem = null , object? cartographicPartitions = null , double? referenceScale = null , object? workspace = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale, workspace: workspace);
			return this;
		}

	}
}
