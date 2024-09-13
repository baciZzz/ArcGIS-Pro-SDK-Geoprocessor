using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Validate Parcel Fabric</para>
	/// <para>验证宗地结构</para>
	/// <para>依据预定义的一组地理数据库拓扑规则以及您为组织添加的任何其他拓扑规则来验证宗地结构。</para>
	/// </summary>
	public class ValidateParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>要验证的宗地结构。 宗地结构可来自文件地理数据库或要素服务。</para>
		/// </param>
		public ValidateParcelFabric(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : 验证宗地结构</para>
		/// </summary>
		public override string DisplayName() => "验证宗地结构";

		/// <summary>
		/// <para>Tool Name : ValidateParcelFabric</para>
		/// </summary>
		public override string ToolName() => "ValidateParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.ValidateParcelFabric</para>
		/// </summary>
		public override string ExcuteName() => "parcel.ValidateParcelFabric";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, Extent, UpdatedParcelFabric };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>要验证的宗地结构。 宗地结构可来自文件地理数据库或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>要处理的数据集的范围。 仅会处理指定范围内的要素。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

	}
}
