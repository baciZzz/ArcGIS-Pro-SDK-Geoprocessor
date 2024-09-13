using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Create Utility Network</para>
	/// <para>Create Utility Network</para>
	/// <para>Creates a utility network in an enterprise, file, or mobile  geodatabase feature dataset.</para>
	/// </summary>
	public class CreateUtilityNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>The geodatabase feature dataset in which the utility network and schema will be created.</para>
		/// </param>
		/// <param name="InUtilityNetworkName">
		/// <para>Utility Network Name</para>
		/// <para>The name of the utility network that will be created.</para>
		/// </param>
		/// <param name="ServiceTerritoryFeatureClass">
		/// <para>Service Territory Feature Class</para>
		/// <para>The existing polygon feature class that will be used to create the utility network&apos;s geographical extent. Utility network features cannot be created outside of this extent.</para>
		/// <para>The feature class must be z- and m-enabled.</para>
		/// </param>
		public CreateUtilityNetwork(object InFeatureDataset, object InUtilityNetworkName, object ServiceTerritoryFeatureClass)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.InUtilityNetworkName = InUtilityNetworkName;
			this.ServiceTerritoryFeatureClass = ServiceTerritoryFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Utility Network</para>
		/// </summary>
		public override string DisplayName() => "Create Utility Network";

		/// <summary>
		/// <para>Tool Name : CreateUtilityNetwork</para>
		/// </summary>
		public override string ToolName() => "CreateUtilityNetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.CreateUtilityNetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.CreateUtilityNetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureDataset, InUtilityNetworkName, ServiceTerritoryFeatureClass, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>The geodatabase feature dataset in which the utility network and schema will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		[GPDatasetDomain()]
		[DataSetType("FeatureDataset")]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Utility Network Name</para>
		/// <para>The name of the utility network that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InUtilityNetworkName { get; set; }

		/// <summary>
		/// <para>Service Territory Feature Class</para>
		/// <para>The existing polygon feature class that will be used to create the utility network&apos;s geographical extent. Utility network features cannot be created outside of this extent.</para>
		/// <para>The feature class must be z- and m-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object ServiceTerritoryFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateUtilityNetwork SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
