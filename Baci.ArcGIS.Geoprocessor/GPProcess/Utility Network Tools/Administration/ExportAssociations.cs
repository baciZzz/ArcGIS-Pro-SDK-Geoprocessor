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
	/// <para>Export Associations</para>
	/// <para>Exports associations from a utility network to a comma-separated-values file (.csv). </para>
	/// <para>This tool can be used in conjunction with the Import Associations tool.</para>
	/// </summary>
	public class ExportAssociations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network containing the associations to export.</para>
		/// </param>
		/// <param name="AssociationType">
		/// <para>Association Type</para>
		/// <para>Specifies the type of association to export.</para>
		/// <para>All—All association types in the utility network will be exported to a .csv file.</para>
		/// <para>Junction-junction connectivity—Connectivity associations allowing two junction subtypes to connect via a connectivity association (features are offset geometrically) will be exported to a .csv file.</para>
		/// <para>Containment—The containment association type will be exported to a .csv file.</para>
		/// <para>Attachment—The structural attachment association type will be exported to a .csv file.</para>
		/// <para>Junction-edge connectivity (from side of edge)—The junction-edge (from side of edge) connectivity association type will be exported to a .csv file.</para>
		/// <para>Junction-edge connectivity (midspan)—The junction-edge (midspan) connectivity association type will be exported to a .csv file.</para>
		/// <para>Junction-edge connectivity (to side of edge)—The junction-edge (to side of edge) connectivity association type will be exported to a .csv file.</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output  File</para>
		/// <para>The name and location of the .csv file that will be generated.</para>
		/// </param>
		public ExportAssociations(object InUtilityNetwork, object AssociationType, object OutCsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.AssociationType = AssociationType;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Associations</para>
		/// </summary>
		public override string DisplayName => "Export Associations";

		/// <summary>
		/// <para>Tool Name : ExportAssociations</para>
		/// </summary>
		public override string ToolName => "ExportAssociations";

		/// <summary>
		/// <para>Tool Excute Name : un.ExportAssociations</para>
		/// </summary>
		public override string ExcuteName => "un.ExportAssociations";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, AssociationType, OutCsvFile };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network containing the associations to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Association Type</para>
		/// <para>Specifies the type of association to export.</para>
		/// <para>All—All association types in the utility network will be exported to a .csv file.</para>
		/// <para>Junction-junction connectivity—Connectivity associations allowing two junction subtypes to connect via a connectivity association (features are offset geometrically) will be exported to a .csv file.</para>
		/// <para>Containment—The containment association type will be exported to a .csv file.</para>
		/// <para>Attachment—The structural attachment association type will be exported to a .csv file.</para>
		/// <para>Junction-edge connectivity (from side of edge)—The junction-edge (from side of edge) connectivity association type will be exported to a .csv file.</para>
		/// <para>Junction-edge connectivity (midspan)—The junction-edge (midspan) connectivity association type will be exported to a .csv file.</para>
		/// <para>Junction-edge connectivity (to side of edge)—The junction-edge (to side of edge) connectivity association type will be exported to a .csv file.</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationType { get; set; }

		/// <summary>
		/// <para>Output  File</para>
		/// <para>The name and location of the .csv file that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Association Type</para>
		/// </summary>
		public enum AssociationTypeEnum 
		{
			/// <summary>
			/// <para>All—All association types in the utility network will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Junction-junction connectivity—Connectivity associations allowing two junction subtypes to connect via a connectivity association (features are offset geometrically) will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("Junction-junction connectivity")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>Containment—The containment association type will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("Containment")]
			Containment,

			/// <summary>
			/// <para>Attachment—The structural attachment association type will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("Attachment")]
			Attachment,

			/// <summary>
			/// <para>Junction-edge connectivity (from side of edge)—The junction-edge (from side of edge) connectivity association type will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_FROM_CONNECTIVITY")]
			[Description("Junction-edge connectivity (from side of edge)")]
			JUNCTION_EDGE_FROM_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity (midspan)—The junction-edge (midspan) connectivity association type will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_MIDSPAN_CONNECTIVITY")]
			[Description("Junction-edge connectivity (midspan)")]
			JUNCTION_EDGE_MIDSPAN_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity (to side of edge)—The junction-edge (to side of edge) connectivity association type will be exported to a .csv file.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_TO_CONNECTIVITY")]
			[Description("Junction-edge connectivity (to side of edge)")]
			JUNCTION_EDGE_TO_CONNECTIVITY,

		}

#endregion
	}
}
