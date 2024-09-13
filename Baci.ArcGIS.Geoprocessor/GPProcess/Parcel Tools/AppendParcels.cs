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
	/// <para>Append Parcels</para>
	/// <para>追加宗地</para>
	/// <para>将宗地从输入宗地结构追加到目标宗地结构。 如果输入宗地结构为包含所选面的宗地结构图层，则系统将追加相应的宗地要素。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AppendParcels : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将被追加到目标宗地结构的输入宗地。 输入宗地结构可来自文件地理数据库、企业级地理数据库或要素服务。</para>
		/// </param>
		/// <param name="TargetParcelFabric">
		/// <para>Target Parcel Fabric</para>
		/// <para>宗地将被追加到的目标宗地结构。 目标宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </param>
		public AppendParcels(object InParcelFabric, object TargetParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
			this.TargetParcelFabric = TargetParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加宗地</para>
		/// </summary>
		public override string DisplayName() => "追加宗地";

		/// <summary>
		/// <para>Tool Name : AppendParcels</para>
		/// </summary>
		public override string ToolName() => "AppendParcels";

		/// <summary>
		/// <para>Tool Excute Name : parcel.AppendParcels</para>
		/// </summary>
		public override string ExcuteName() => "parcel.AppendParcels";

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
		public override object[] Parameters() => new object[] { InParcelFabric, TargetParcelFabric, UpdatedParcelFabric };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将被追加到目标宗地结构的输入宗地。 输入宗地结构可来自文件地理数据库、企业级地理数据库或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Target Parcel Fabric</para>
		/// <para>宗地将被追加到的目标宗地结构。 目标宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object TargetParcelFabric { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPParcelLayer()]
		public object UpdatedParcelFabric { get; set; }

	}
}
