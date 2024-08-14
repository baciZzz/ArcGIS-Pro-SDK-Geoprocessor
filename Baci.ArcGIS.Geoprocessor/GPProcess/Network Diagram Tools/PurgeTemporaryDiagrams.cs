using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Purge Temporary Diagrams</para>
	/// <para>Purges temporary network diagrams related to a given utility network or trace network.</para>
	/// </summary>
	public class PurgeTemporaryDiagrams : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network data element with the temporary diagrams to be purged.</para>
		/// </param>
		public PurgeTemporaryDiagrams(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Purge Temporary Diagrams</para>
		/// </summary>
		public override string DisplayName => "Purge Temporary Diagrams";

		/// <summary>
		/// <para>Tool Name : PurgeTemporaryDiagrams</para>
		/// </summary>
		public override string ToolName => "PurgeTemporaryDiagrams";

		/// <summary>
		/// <para>Tool Excute Name : nd.PurgeTemporaryDiagrams</para>
		/// </summary>
		public override string ExcuteName => "nd.PurgeTemporaryDiagrams";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, CreatedBefore!, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network data element with the temporary diagrams to be purged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Created Before</para>
		/// <para>The cutoff date for temporary network diagrams to be purged. All temporary network diagrams created before this date will be purged.</para>
		/// <para>By default, the date in this dialog box is the current date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? CreatedBefore { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

	}
}
