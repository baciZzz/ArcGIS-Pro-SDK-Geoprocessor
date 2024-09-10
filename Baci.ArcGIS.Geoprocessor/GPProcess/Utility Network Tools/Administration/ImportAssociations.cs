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
	/// <para>Import Associations</para>
	/// <para>Imports associations from a comma-separated values file (.csv) into an existing utility network. This tool can be used in conjunction with the Export Associations tool.</para>
	/// </summary>
	public class ImportAssociations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network to which the associations will be imported.</para>
		/// </param>
		/// <param name="AssociationType">
		/// <para>Association Type</para>
		/// <para>Specifies the type of association that will be imported.</para>
		/// <para>All—All association types will be imported.</para>
		/// <para>Junction-junction connectivity—The junction-junction connectivity association type will be imported.</para>
		/// <para>Containment—The containment association type will be imported.</para>
		/// <para>Attachment—The structural attachment association type will be imported.</para>
		/// <para>Junction-edge connectivity (from side of edge)—The junction-edge connectivity (from side of edge) association type will be imported.</para>
		/// <para>Junction-edge connectivity (midspan)—The junction-edge connectivity (midspan) association type will be imported.</para>
		/// <para>Junction-edge connectivity (to side of edge)—The junction-edge connectivity (to side of edge) association type will be imported.</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </param>
		/// <param name="CsvFile">
		/// <para>Input File</para>
		/// <para>The .csv file from which the associations will be imported.</para>
		/// </param>
		public ImportAssociations(object InUtilityNetwork, object AssociationType, object CsvFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.AssociationType = AssociationType;
			this.CsvFile = CsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Associations</para>
		/// </summary>
		public override string DisplayName() => "Import Associations";

		/// <summary>
		/// <para>Tool Name : ImportAssociations</para>
		/// </summary>
		public override string ToolName() => "ImportAssociations";

		/// <summary>
		/// <para>Tool Excute Name : un.ImportAssociations</para>
		/// </summary>
		public override string ExcuteName() => "un.ImportAssociations";

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
		public override object[] Parameters() => new object[] { InUtilityNetwork, AssociationType, CsvFile, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network to which the associations will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Association Type</para>
		/// <para>Specifies the type of association that will be imported.</para>
		/// <para>All—All association types will be imported.</para>
		/// <para>Junction-junction connectivity—The junction-junction connectivity association type will be imported.</para>
		/// <para>Containment—The containment association type will be imported.</para>
		/// <para>Attachment—The structural attachment association type will be imported.</para>
		/// <para>Junction-edge connectivity (from side of edge)—The junction-edge connectivity (from side of edge) association type will be imported.</para>
		/// <para>Junction-edge connectivity (midspan)—The junction-edge connectivity (midspan) association type will be imported.</para>
		/// <para>Junction-edge connectivity (to side of edge)—The junction-edge connectivity (to side of edge) association type will be imported.</para>
		/// <para><see cref="AssociationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AssociationType { get; set; }

		/// <summary>
		/// <para>Input File</para>
		/// <para>The .csv file from which the associations will be imported.</para>
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
		public ImportAssociations SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Association Type</para>
		/// </summary>
		public enum AssociationTypeEnum 
		{
			/// <summary>
			/// <para>All—All association types will be imported.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Junction-junction connectivity—The junction-junction connectivity association type will be imported.</para>
			/// </summary>
			[GPValue("JUNCTION_JUNCTION_CONNECTIVITY")]
			[Description("Junction-junction connectivity")]
			JUNCTION_JUNCTION_CONNECTIVITY,

			/// <summary>
			/// <para>Containment—The containment association type will be imported.</para>
			/// </summary>
			[GPValue("CONTAINMENT")]
			[Description("Containment")]
			Containment,

			/// <summary>
			/// <para>Attachment—The structural attachment association type will be imported.</para>
			/// </summary>
			[GPValue("STRUCTURAL_ATTACHMENT")]
			[Description("Attachment")]
			Attachment,

			/// <summary>
			/// <para>Junction-edge connectivity (from side of edge)—The junction-edge connectivity (from side of edge) association type will be imported.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_FROM_CONNECTIVITY")]
			[Description("Junction-edge connectivity (from side of edge)")]
			JUNCTION_EDGE_FROM_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity (midspan)—The junction-edge connectivity (midspan) association type will be imported.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_MIDSPAN_CONNECTIVITY")]
			[Description("Junction-edge connectivity (midspan)")]
			JUNCTION_EDGE_MIDSPAN_CONNECTIVITY,

			/// <summary>
			/// <para>Junction-edge connectivity (to side of edge)—The junction-edge connectivity (to side of edge) association type will be imported.</para>
			/// </summary>
			[GPValue("JUNCTION_EDGE_TO_CONNECTIVITY")]
			[Description("Junction-edge connectivity (to side of edge)")]
			JUNCTION_EDGE_TO_CONNECTIVITY,

		}

#endregion
	}
}
