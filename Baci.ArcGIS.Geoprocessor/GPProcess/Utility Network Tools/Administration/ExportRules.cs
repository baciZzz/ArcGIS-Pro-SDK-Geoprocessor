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
	/// <para>Export Rules</para>
	/// <para>Export Rules</para>
	/// <para>Exports connectivity, structural attachment, and containment rules from a utility network into a comma-separated values file.</para>
	/// </summary>
	public class ExportRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network to export the rules from.</para>
		/// </param>
		/// <param name="RuleType">
		/// <para>Rule Type</para>
		/// <para>The type of rule to export.</para>
		/// <para>All—All the rules in the utility network will be exported.</para>
		/// <para>Junction-junction connectivity—Junction-junction connectivity association rules will be exported.</para>
		/// <para>Junction-edge connectivity—Junction-edge connectivity rules will be exported.</para>
		/// <para>Containment—Containment association rules will be exported.</para>
		/// <para>Structural attachment—Structural attachment association rules will be exported.</para>
		/// <para>Edge-junction-edge connectivity—Edge-junction-edge connectivity association rules will be exported.</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output File</para>
		/// <para>The folder location and name of the .csv file to be created.</para>
		/// </param>
		public ExportRules(object InUtilityNetwork, object RuleType, object OutCsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.RuleType = RuleType;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Rules</para>
		/// </summary>
		public override string DisplayName() => "Export Rules";

		/// <summary>
		/// <para>Tool Name : ExportRules</para>
		/// </summary>
		public override string ToolName() => "ExportRules";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportRules</para>
		/// </summary>
		public override string ExcuteName() => "un.ExportRules";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, RuleType, OutCsvFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network to export the rules from.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Rule Type</para>
		/// <para>The type of rule to export.</para>
		/// <para>All—All the rules in the utility network will be exported.</para>
		/// <para>Junction-junction connectivity—Junction-junction connectivity association rules will be exported.</para>
		/// <para>Junction-edge connectivity—Junction-edge connectivity rules will be exported.</para>
		/// <para>Containment—Containment association rules will be exported.</para>
		/// <para>Structural attachment—Structural attachment association rules will be exported.</para>
		/// <para>Edge-junction-edge connectivity—Edge-junction-edge connectivity association rules will be exported.</para>
		/// <para><see cref="RuleTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleType { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The folder location and name of the .csv file to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Rule Type</para>
		/// </summary>
		public enum RuleTypeEnum 
		{
			/// <summary>
			/// <para>All—All the rules in the utility network will be exported.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Junction-junction connectivity—Junction-junction connectivity association rules will be exported.</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("Junction-junction connectivity")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity—Junction-edge connectivity rules will be exported.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Junction-edge connectivity")]
			JUNCTION_EDGE_CONNECTIVITY,

			/// <summary>
			/// <para>Containment—Containment association rules will be exported.</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("Containment")]
			Containment,

			/// <summary>
			/// <para>Structural attachment—Structural attachment association rules will be exported.</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("Structural attachment")]
			Structural_attachment,

			/// <summary>
			/// <para>Edge-junction-edge connectivity—Edge-junction-edge connectivity association rules will be exported.</para>
			/// </summary>
			[GPValue("EDGE_JUNCTION_EDGE_CONNECTIVITY")]
			[Description("Edge-junction-edge connectivity")]
			EDGE_JUNCTION_EDGE_CONNECTIVITY,

		}

#endregion
	}
}
