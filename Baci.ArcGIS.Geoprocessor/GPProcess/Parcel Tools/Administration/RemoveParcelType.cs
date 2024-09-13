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
	/// <para>Remove Parcel Type</para>
	/// <para>Removes  a parcel type from a parcel fabric.</para>
	/// </summary>
	public class RemoveParcelType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric from which the parcel type will be removed. The parcel fabric can be from a file, enterprise, or mobile geodatabase.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>The name of the parcel type.</para>
		/// </param>
		public RemoveParcelType(object InParcelFabric, object Name)
		{
			this.InParcelFabric = InParcelFabric;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Parcel Type</para>
		/// </summary>
		public override string DisplayName() => "Remove Parcel Type";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, Name, UpdatedParcelFabric!, OutPolygonFc!, OutLineFc! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric from which the parcel type will be removed. The parcel fabric can be from a file, enterprise, or mobile geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the parcel type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Output Polygon Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutPolygonFc { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutLineFc { get; set; }

	}
}
