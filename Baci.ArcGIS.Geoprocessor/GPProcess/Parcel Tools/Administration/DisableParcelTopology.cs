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
	/// <para>Disable Parcel Topology</para>
	/// <para>禁用宗地拓扑</para>
	/// <para>在宗地结构上禁用地理数据库拓扑。 将从拓扑中移除系统定义的拓扑规则以及宗地结构要素类。</para>
	/// </summary>
	public class DisableParcelTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将禁用拓扑的宗地结构。 输入宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </param>
		public DisableParcelTopology(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : 禁用宗地拓扑</para>
		/// </summary>
		public override string DisplayName() => "禁用宗地拓扑";

		/// <summary>
		/// <para>Tool Name : DisableParcelTopology</para>
		/// </summary>
		public override string ToolName() => "DisableParcelTopology";

		/// <summary>
		/// <para>Tool Excute Name : parcel.DisableParcelTopology</para>
		/// </summary>
		public override string ExcuteName() => "parcel.DisableParcelTopology";

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
		public override object[] Parameters() => new object[] { InParcelFabric, UpdatedParcelFabric };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将禁用拓扑的宗地结构。 输入宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

	}
}
