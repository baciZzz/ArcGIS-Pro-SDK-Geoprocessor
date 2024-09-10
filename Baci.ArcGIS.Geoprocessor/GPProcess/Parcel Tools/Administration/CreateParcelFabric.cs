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
	/// <para>Create Parcel Fabric</para>
	/// <para>Creates a parcel fabric and its associated datasets. The parcel fabric is created  in a feature dataset that resides in a file or an enterprise geodatabase.</para>
	/// </summary>
	public class CreateParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset in which the parcel fabric and related schema will be created. The feature dataset can reside in a file or an enterprise geodatabase.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>The name of the parcel fabric that will be created. Associated datasets will be prefixed with the parcel fabric name.</para>
		/// </param>
		public CreateParcelFabric(object TargetDataset, object Name)
		{
			this.TargetDataset = TargetDataset;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Parcel Fabric</para>
		/// </summary>
		public override string DisplayName() => "Create Parcel Fabric";

		/// <summary>
		/// <para>Tool Name : CreateParcelFabric</para>
		/// </summary>
		public override string ToolName() => "CreateParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.CreateParcelFabric</para>
		/// </summary>
		public override string ExcuteName() => "parcel.CreateParcelFabric";

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
		public override object[] Parameters() => new object[] { TargetDataset, Name, OutParcelFabric };

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>The feature dataset in which the parcel fabric and related schema will be created. The feature dataset can reside in a file or an enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetDataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the parcel fabric that will be created. Associated datasets will be prefixed with the parcel fabric name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Output Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object OutParcelFabric { get; set; }

	}
}
