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
	/// <para>Disables geodatabase topology on a parcel fabric.  System-defined  topology rules and parcel fabric feature classes will be removed from the topology.</para>
	/// </summary>
	public class DisableParcelTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric for which the topology will be disabled. The input parcel fabric can be from a file, enterprise, or mobile geodatabase.</para>
		/// </param>
		public DisableParcelTopology(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : Disable Parcel Topology</para>
		/// </summary>
		public override string DisplayName => "Disable Parcel Topology";

		/// <summary>
		/// <para>Tool Name : DisableParcelTopology</para>
		/// </summary>
		public override string ToolName => "DisableParcelTopology";

		/// <summary>
		/// <para>Tool Excute Name : parcel.DisableParcelTopology</para>
		/// </summary>
		public override string ExcuteName => "parcel.DisableParcelTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InParcelFabric, UpdatedParcelFabric! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>The parcel fabric for which the topology will be disabled. The input parcel fabric can be from a file, enterprise, or mobile geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? UpdatedParcelFabric { get; set; }

	}
}
