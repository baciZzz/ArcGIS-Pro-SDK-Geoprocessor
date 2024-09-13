using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Populate Alternate ID Fields</para>
	/// <para>Populate Alternate ID Fields</para>
	/// <para>Creates and populates additional fields on the turn feature classes that reference the edges by alternate IDs. The alternate IDs allow for another set of IDs that can help maintain the integrity of the turn features in case the source edges are being edited.</para>
	/// </summary>
	public class PopulateAlternateIDFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset whose turn feature classes are to receive alternate ID fields. The fields will be created on all of the turn feature classes added as a turn source to the network dataset.</para>
		/// </param>
		/// <param name="AlternateIDFieldName">
		/// <para>Alternate ID Field Name</para>
		/// <para>The name of the alternate ID field on the edge feature sources of the network dataset. All edge feature sources referenced by turns must have the same name for the alternate ID field.</para>
		/// </param>
		public PopulateAlternateIDFields(object InNetworkDataset, object AlternateIDFieldName)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.AlternateIDFieldName = AlternateIDFieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : Populate Alternate ID Fields</para>
		/// </summary>
		public override string DisplayName() => "Populate Alternate ID Fields";

		/// <summary>
		/// <para>Tool Name : PopulateAlternateIDFields</para>
		/// </summary>
		public override string ToolName() => "PopulateAlternateIDFields";

		/// <summary>
		/// <para>Tool Excute Name : na.PopulateAlternateIDFields</para>
		/// </summary>
		public override string ExcuteName() => "na.PopulateAlternateIDFields";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDataset, AlternateIDFieldName, OutNetworkDataset! };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset whose turn feature classes are to receive alternate ID fields. The fields will be created on all of the turn feature classes added as a turn source to the network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Alternate ID Field Name</para>
		/// <para>The name of the alternate ID field on the edge feature sources of the network dataset. All edge feature sources referenced by turns must have the same name for the alternate ID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AlternateIDFieldName { get; set; }

		/// <summary>
		/// <para>Updated Input Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNetworkDatasetLayer()]
		public object? OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PopulateAlternateIDFields SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
