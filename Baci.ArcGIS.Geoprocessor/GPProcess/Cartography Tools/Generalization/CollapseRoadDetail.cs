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
	/// <para>Collapse Road Detail</para>
	/// <para>折叠道路详细信息</para>
	/// <para>折叠那些阻断道路网大趋势的路段小的开放构造（例如交通环岛），并将它们替换为简化的说明。</para>
	/// </summary>
	public class CollapseRoadDetail : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要折叠的包含小的封闭道路详细信息的输入要素（如交通环岛）。</para>
		/// </param>
		/// <param name="CollapseDistance">
		/// <para>Collapse Distance</para>
		/// <para>折叠时使用的道路详细信息直径或跨越道路详细信息的距离。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含折叠要素（根据折叠设置进行修改的要素）和所有未受影响要素的输出要素类。</para>
		/// </param>
		public CollapseRoadDetail(object InFeatures, object CollapseDistance, object OutputFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.CollapseDistance = CollapseDistance;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 折叠道路详细信息</para>
		/// </summary>
		public override string DisplayName() => "折叠道路详细信息";

		/// <summary>
		/// <para>Tool Name : CollapseRoadDetail</para>
		/// </summary>
		public override string ToolName() => "CollapseRoadDetail";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CollapseRoadDetail</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CollapseRoadDetail";

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
		public override object[] Parameters() => new object[] { InFeatures, CollapseDistance, OutputFeatureClass, LockingField! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要折叠的包含小的封闭道路详细信息的输入要素（如交通环岛）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Collapse Distance</para>
		/// <para>折叠时使用的道路详细信息直径或跨越道路详细信息的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object CollapseDistance { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含折叠要素（根据折叠设置进行修改的要素）和所有未受影响要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Locking Field</para>
		/// <para>包含要素锁定信息的字段。 值 1 表示不会折叠要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? LockingField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CollapseRoadDetail SetEnviroment(object? cartographicPartitions = null , double? referenceScale = null )
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

	}
}
