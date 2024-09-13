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
	/// <para>Copy Parcels</para>
	/// <para>Copy Parcels</para>
	/// <para>Copies parcels from an input parcel fabric to a new parcel fabric in a new feature dataset.</para>
	/// </summary>
	public class CopyParcels : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The input parcels that will be copied to a new parcel fabric. The input parcel fabric can be from a file, enterprise, or mobile geodatabase, or from a feature service.</para>
		/// </param>
		/// <param name="TargetDatabase">
		/// <para>Target Database</para>
		/// <para>The geodatabase in which the new parcel fabric will be created. The geodatabase can be a file, enterprise, or mobile geodatabase.</para>
		/// </param>
		public CopyParcels(object InParcelFabric, object TargetDatabase)
		{
			this.InParcelFabric = InParcelFabric;
			this.TargetDatabase = TargetDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Parcels</para>
		/// </summary>
		public override string DisplayName() => "Copy Parcels";

		/// <summary>
		/// <para>Tool Name : CopyParcels</para>
		/// </summary>
		public override string ToolName() => "CopyParcels";

		/// <summary>
		/// <para>Tool Excute Name : parcel.CopyParcels</para>
		/// </summary>
		public override string ExcuteName() => "parcel.CopyParcels";

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
		public override object[] Parameters() => new object[] { InParcelFabric, TargetDatabase, OutDatasetName!, OutFabricName!, OutDataset!, OutParcelFabric! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The input parcels that will be copied to a new parcel fabric. The input parcel fabric can be from a file, enterprise, or mobile geodatabase, or from a feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Target Database</para>
		/// <para>The geodatabase in which the new parcel fabric will be created. The geodatabase can be a file, enterprise, or mobile geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetDatabase { get; set; }

		/// <summary>
		/// <para>Feature Dataset Name</para>
		/// <para>The name of the feature dataset that will be created for the new parcel fabric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutDatasetName { get; set; }

		/// <summary>
		/// <para>Parcel Fabric Name</para>
		/// <para>The name of the new parcel fabric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutFabricName { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Output Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? OutParcelFabric { get; set; }

	}
}
