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
	/// <para>Remove Parcel Type</para>
	/// <para>移除宗地类型</para>
	/// <para>将宗地类型从宗地结构中移除。</para>
	/// </summary>
	public class RemoveParcelType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将从中移除宗地类型的宗地结构。宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>宗地类型的名称。</para>
		/// </param>
		public RemoveParcelType(object InParcelFabric, object Name)
		{
			this.InParcelFabric = InParcelFabric;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除宗地类型</para>
		/// </summary>
		public override string DisplayName() => "移除宗地类型";

		/// <summary>
		/// <para>Tool Name : RemoveParcelType</para>
		/// </summary>
		public override string ToolName() => "RemoveParcelType";

		/// <summary>
		/// <para>Tool Excute Name : parcel.RemoveParcelType</para>
		/// </summary>
		public override string ExcuteName() => "parcel.RemoveParcelType";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, Name, UpdatedParcelFabric, OutPolygonFc, OutLineFc };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将从中移除宗地类型的宗地结构。宗地结构可来自文件地理数据库或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>宗地类型的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPolygonFc { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutLineFc { get; set; }

	}
}
