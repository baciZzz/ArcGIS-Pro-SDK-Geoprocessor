using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Import Message</para>
	/// <para>Imports changes from a delta file into a replica geodatabase.</para>
	/// </summary>
	[Obsolete()]
	public class ImportMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Import To Replica Geodatabase</para>
		/// </param>
		/// <param name="SourceDeltaFile">
		/// <para>Import from Delta file</para>
		/// </param>
		public ImportMessage(object InGeodatabase, object SourceDeltaFile)
		{
			this.InGeodatabase = InGeodatabase;
			this.SourceDeltaFile = SourceDeltaFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Message</para>
		/// </summary>
		public override string DisplayName() => "Import Message";

		/// <summary>
		/// <para>Tool Name : ImportMessage</para>
		/// </summary>
		public override string ToolName() => "ImportMessage";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportMessage</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportMessage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodatabase, SourceDeltaFile, OutputAcknowledgementFile, ConflictPolicy, ConflictDefinition, ReconcileWithParentVersion, OutGeodatabase };

		/// <summary>
		/// <para>Import To Replica Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Import from Delta file</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object SourceDeltaFile { get; set; }

		/// <summary>
		/// <para>Output Acknowledgement File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutputAcknowledgementFile { get; set; }

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictPolicy { get; set; } = "MANUAL";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Reconcile with the Parent Version (Check-out replicas)</para>
		/// <para><see cref="ReconcileWithParentVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReconcileWithParentVersion { get; set; } = "false";

		/// <summary>
		/// <para>Output Replica Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutGeodatabase { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// </summary>
		public enum ConflictPolicyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("MANUAL")]
			MANUAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_IMPORTED_CHANGES")]
			[Description("IN_FAVOR_OF_IMPORTED_CHANGES")]
			IN_FAVOR_OF_IMPORTED_CHANGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_DATABASE")]
			[Description("IN_FAVOR_OF_DATABASE")]
			IN_FAVOR_OF_DATABASE,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("BY_OBJECT")]
			BY_OBJECT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("BY_ATTRIBUTE")]
			BY_ATTRIBUTE,

		}

		/// <summary>
		/// <para>Reconcile with the Parent Version (Check-out replicas)</para>
		/// </summary>
		public enum ReconcileWithParentVersionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE ")]
			RECONCILE_,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RECONCILE")]
			DO_NOT_RECONCILE,

		}

#endregion
	}
}
