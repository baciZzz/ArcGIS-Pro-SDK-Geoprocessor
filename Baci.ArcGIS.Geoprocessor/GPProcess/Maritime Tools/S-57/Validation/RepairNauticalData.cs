using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Repair Nautical Data</para>
	/// <para>Repairs selected data processes on a database with the Nautical schema. Processes include repairing noncollocated structure-equipment features, deleting detached FREL and COLLECTIONS records, and resolving blank or duplicate  LNAM attribute values.</para>
	/// </summary>
	public class RepairNauticalData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The file or enterprise geodatabase to be repaired.</para>
		/// </param>
		/// <param name="RepairOperations">
		/// <para>Repair Operations</para>
		/// <para>Specifies the repair process to be executed.</para>
		/// <para>Fix LNAM—Records with a blank LNAM attribute will be resolved by populating the records with a valid LNAM value, and duplicate LNAM attribute conflicts will be resolved with a new LNAM value provided to one of the records.</para>
		/// <para>Remove Orphan Relationships—Detached structure or equipment and collections records will be removed from the PLTS_FREL and PLTS_COLLECTIONS tables.</para>
		/// <para>Move Equipment Features—Point equipment features that are not coincident with point structure features will be identified and moved to the location of the structure.</para>
		/// <para><see cref="RepairOperationsEnum"/></para>
		/// </param>
		public RepairNauticalData(object InWorkspace, object RepairOperations)
		{
			this.InWorkspace = InWorkspace;
			this.RepairOperations = RepairOperations;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Nautical Data</para>
		/// </summary>
		public override string DisplayName => "Repair Nautical Data";

		/// <summary>
		/// <para>Tool Name : RepairNauticalData</para>
		/// </summary>
		public override string ToolName => "RepairNauticalData";

		/// <summary>
		/// <para>Tool Excute Name : maritime.RepairNauticalData</para>
		/// </summary>
		public override string ExcuteName => "maritime.RepairNauticalData";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, RepairOperations, UpdatedWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The file or enterprise geodatabase to be repaired.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Repair Operations</para>
		/// <para>Specifies the repair process to be executed.</para>
		/// <para>Fix LNAM—Records with a blank LNAM attribute will be resolved by populating the records with a valid LNAM value, and duplicate LNAM attribute conflicts will be resolved with a new LNAM value provided to one of the records.</para>
		/// <para>Remove Orphan Relationships—Detached structure or equipment and collections records will be removed from the PLTS_FREL and PLTS_COLLECTIONS tables.</para>
		/// <para>Move Equipment Features—Point equipment features that are not coincident with point structure features will be identified and moved to the location of the structure.</para>
		/// <para><see cref="RepairOperationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object RepairOperations { get; set; }

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairNauticalData SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Repair Operations</para>
		/// </summary>
		public enum RepairOperationsEnum 
		{
			/// <summary>
			/// <para>Fix LNAM—Records with a blank LNAM attribute will be resolved by populating the records with a valid LNAM value, and duplicate LNAM attribute conflicts will be resolved with a new LNAM value provided to one of the records.</para>
			/// </summary>
			[GPValue("FIX_LNAM")]
			[Description("Fix LNAM")]
			Fix_LNAM,

			/// <summary>
			/// <para>Remove Orphan Relationships—Detached structure or equipment and collections records will be removed from the PLTS_FREL and PLTS_COLLECTIONS tables.</para>
			/// </summary>
			[GPValue("REMOVE_ORPHAN_RELATIONSHIPS")]
			[Description("Remove Orphan Relationships")]
			Remove_Orphan_Relationships,

			/// <summary>
			/// <para>Move Equipment Features—Point equipment features that are not coincident with point structure features will be identified and moved to the location of the structure.</para>
			/// </summary>
			[GPValue("MOVE_EQUIPMENT_FEATURES")]
			[Description("Move Equipment Features")]
			Move_Equipment_Features,

		}

#endregion
	}
}
