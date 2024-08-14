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
	/// <para>Update by Alternate ID Fields</para>
	/// <para>Updates all the edge references in turn feature classes using an alternate ID field. This tool should be used after making edits to the input line features that are referenced by the turn features to synchronize the turn features based on the alternate ID fields.</para>
	/// </summary>
	public class UpdateByAlternateIDFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset whose turn feature classes are being updated by their alternate ID fields.</para>
		/// </param>
		/// <param name="AlternateIDFieldName">
		/// <para>Alternate ID Field Name</para>
		/// <para>The name of the alternate ID field on the edge feature sources of the network dataset. All edge feature sources referenced by turns must have the same name for the alternate ID field.</para>
		/// </param>
		public UpdateByAlternateIDFields(object InNetworkDataset, object AlternateIDFieldName)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.AlternateIDFieldName = AlternateIDFieldName;
		}

		/// <summary>
		/// <para>Tool Display Name : Update by Alternate ID Fields</para>
		/// </summary>
		public override string DisplayName => "Update by Alternate ID Fields";

		/// <summary>
		/// <para>Tool Name : UpdateByAlternateIDFields</para>
		/// </summary>
		public override string ToolName => "UpdateByAlternateIDFields";

		/// <summary>
		/// <para>Tool Excute Name : na.UpdateByAlternateIDFields</para>
		/// </summary>
		public override string ExcuteName => "na.UpdateByAlternateIDFields";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkDataset, AlternateIDFieldName, OutNetworkDataset };

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>The network dataset whose turn feature classes are being updated by their alternate ID fields.</para>
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
		public object OutNetworkDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateByAlternateIDFields SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
