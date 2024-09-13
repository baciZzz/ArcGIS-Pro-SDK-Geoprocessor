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
	/// <para>Append Parcels</para>
	/// <para>Appends parcels from an input parcel fabric to a target parcel fabric. If the input parcel fabric is a parcel fabric layer with selected polygons, the corresponding parcel features will be appended.</para>
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
		/// <para>The input parcels that will be appended to the target parcel fabric. The input parcel fabric can be from a file, enterprise, or mobile geodatabase, or a feature service.</para>
		/// </param>
		/// <param name="TargetParcelFabric">
		/// <para>Target Parcel Fabric</para>
		/// <para>The target parcel fabric to which the parcels will be appended. The target parcel fabric can be from a file, enterprise, or mobile geodatabase.</para>
		/// </param>
		public AppendParcels(object InParcelFabric, object TargetParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
			this.TargetParcelFabric = TargetParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Parcels</para>
		/// </summary>
		public override string DisplayName() => "Append Parcels";

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
		public override object[] Parameters() => new object[] { InParcelFabric, TargetParcelFabric, UpdatedParcelFabric! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The input parcels that will be appended to the target parcel fabric. The input parcel fabric can be from a file, enterprise, or mobile geodatabase, or a feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Target Parcel Fabric</para>
		/// <para>The target parcel fabric to which the parcels will be appended. The target parcel fabric can be from a file, enterprise, or mobile geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object TargetParcelFabric { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPParcelLayer()]
		public object? UpdatedParcelFabric { get; set; }

	}
}
