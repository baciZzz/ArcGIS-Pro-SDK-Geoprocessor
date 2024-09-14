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
	/// <para>Import Rules</para>
	/// <para>Import Rules</para>
	/// <para>Import connectivity, structural attachment, and containment rules from a comma-separated values file into an existing utility network.</para>
	/// </summary>
	public class ImportRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>Specifies the utility network to import the rules to.</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>Specifies the type of rules to import.</para>
		/// <para>All—One or more types of rules</para>
		/// <para>Junction-junction connectivity—Junction-junction connectivity association rules</para>
		/// <para>Junction-edge connectivity—Junction-edge connectivity rules</para>
		/// <para>Containment—Containment association rules</para>
		/// <para>Structural attachment—Structural attachment association rules</para>
		/// <para>Edge-junction-edge connectivity— Edge-junction-edge association rules</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		/// <param name="CsvFile">
		/// <para>Input  File</para>
		/// <para>Specifies the .csv file containing the rules to import.</para>
		/// </param>
		public ImportRules(object InUtilityNetwork, object RuleType, object CsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
			this.CsvFile = CsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Rules</para>
		/// </summary>
		public override string DisplayName() => "Import Rules";

		/// <summary>
		/// <para>Tool Name : ImportRules</para>
		/// </summary>
		public override string ToolName() => "ImportRules";

		/// <summary>
		/// <para>Tool Excute Name : un.ImportRules</para>
		/// </summary>
		public override string ExcuteName() => "un.ImportRules";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, CsvFile, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>Specifies the utility network to import the rules to.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>Specifies the type of rules to import.</para>
		/// <para>All—One or more types of rules</para>
		/// <para>Junction-junction connectivity—Junction-junction connectivity association rules</para>
		/// <para>Junction-edge connectivity—Junction-edge connectivity rules</para>
		/// <para>Containment—Containment association rules</para>
		/// <para>Structural attachment—Structural attachment association rules</para>
		/// <para>Edge-junction-edge connectivity— Edge-junction-edge association rules</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>Input  File</para>
		/// <para>Specifies the .csv file containing the rules to import.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object CsvFile { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportRules SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>All—One or more types of rules</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Junction-junction connectivity—Junction-junction connectivity association rules</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("Junction-junction connectivity")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity—Junction-edge connectivity rules</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Junction-edge connectivity")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>Containment—Containment association rules</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("Containment")]
			Containment,

			/// <summary>
			/// <para>Structural attachment—Structural attachment association rules</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("Structural attachment")]
			Structural_attachment,

			/// <summary>
			/// <para>Edge-junction-edge connectivity— Edge-junction-edge association rules</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Edge-junction-edge connectivity")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
