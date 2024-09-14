using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Export AIXM 5.1 Message</para>
	/// <para>Export AIXM 5.1 Message</para>
	/// <para>Exports aeronautical data to an AIXM 5.1 message.</para>
	/// </summary>
	public class ExportAIXM51Message : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAviationWorkspace">
		/// <para>Input Aviation Workspace</para>
		/// <para>The AIS schema workspace.</para>
		/// </param>
		/// <param name="OutMessageFile">
		/// <para>Output Message File</para>
		/// <para>The exported AIXM 5.1 message as an .xml file.</para>
		/// </param>
		/// <param name="ExportType">
		/// <para>Export Type</para>
		/// <para>Specifies the AIXM temporality type the message represents.</para>
		/// <para>Baseline— The message contains all features in a given message.</para>
		/// <para>Snapshot—The message contains all features at a specific point in time.</para>
		/// <para>Permanent Delta—The message contains updates in a given time slice in features as a result of a baseline update.</para>
		/// <para>Temporary Delta—The message contains changes for some features in a given time slice representing a temporary event.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </param>
		public ExportAIXM51Message(object InAviationWorkspace, object OutMessageFile, object ExportType)
		{
			this.InAviationWorkspace = InAviationWorkspace;
			this.OutMessageFile = OutMessageFile;
			this.ExportType = ExportType;
		}

		/// <summary>
		/// <para>Tool Display Name : Export AIXM 5.1 Message</para>
		/// </summary>
		public override string DisplayName() => "Export AIXM 5.1 Message";

		/// <summary>
		/// <para>Tool Name : ExportAIXM51Message</para>
		/// </summary>
		public override string ToolName() => "ExportAIXM51Message";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ExportAIXM51Message</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ExportAIXM51Message";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAviationWorkspace, OutMessageFile, ExportType, LastModifiedTime!, InFilterLayers!, FromTime!, ToTime!, ValidateOutput!, OutValidationLog! };

		/// <summary>
		/// <para>Input Aviation Workspace</para>
		/// <para>The AIS schema workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InAviationWorkspace { get; set; }

		/// <summary>
		/// <para>Output Message File</para>
		/// <para>The exported AIXM 5.1 message as an .xml file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutMessageFile { get; set; }

		/// <summary>
		/// <para>Export Type</para>
		/// <para>Specifies the AIXM temporality type the message represents.</para>
		/// <para>Baseline— The message contains all features in a given message.</para>
		/// <para>Snapshot—The message contains all features at a specific point in time.</para>
		/// <para>Permanent Delta—The message contains updates in a given time slice in features as a result of a baseline update.</para>
		/// <para>Temporary Delta—The message contains changes for some features in a given time slice representing a temporary event.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportType { get; set; }

		/// <summary>
		/// <para>Last Modified Time</para>
		/// <para>The date that will be used to filter the output to only features modified after that date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? LastModifiedTime { get; set; }

		/// <summary>
		/// <para>Input Filter Layers</para>
		/// <para>The layers that will filter output to a smaller spatial subset. The input layers should be AIXM 5.1 feature types. This value should be in the same AIS geodatabase as the Input Aviation Workspace parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InFilterLayers { get; set; }

		/// <summary>
		/// <para>From Time</para>
		/// <para>The starting time that will be applied to the validTime\beginPosition and featureLifetime\beginPosition fields in the output message types for any missing ValidFrom_Date or FeatureFrom_Date field values in the features to export. The value will be converted to UTC. If a value is not specified, the current system date and time in UTC will be applied to the missing field values in the output message.</para>
		/// <para>This parameter will be used differently depending on the Export Type parameter value.</para>
		/// <para>Baseline—The parameter will be honored only when the actual database record does not have the FromFeature_Date or ValidFrom_Date attributes populated.</para>
		/// <para>Snapshot—The parameter value provided will be exported regardless of the FromFeature_Date and ValidFrom_Date attributes in the database.</para>
		/// <para>Permanent Delta—The parameter will be honored only when the actual database record does not have the FromFeature_Date or ValidFrom_Date attributes populated.</para>
		/// <para>Temporary Delta—The parameter will be honored only when the actual database record does not have the FromFeature_Date or the ValidFrom_Date attributes populated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? FromTime { get; set; }

		/// <summary>
		/// <para>To Time</para>
		/// <para>The ending time that will be applied to the validTime\endPosition and featureLifetime\endPosition fields in the output message types for any missing ValidTo_Date or FeatureTo_Date field values in the features to export. The value will be converted to UTC. If a value is not specified, the current system date and time in UTC will be applied to the missing field values in the output message.</para>
		/// <para>This parameter is only valid when the Export Type parameter is set to Temporary Delta.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ToTime { get; set; }

		/// <summary>
		/// <para>Validate Output</para>
		/// <para>Specifies whether XML validation will be performed on the exported message.</para>
		/// <para>Checked—XML validation will be performed on the exported message.</para>
		/// <para>Unchecked—XML validation will not be performed on the exported message. This is the default.</para>
		/// <para><see cref="ValidateOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ValidateOutput { get; set; } = "false";

		/// <summary>
		/// <para>Output Validation Log</para>
		/// <para>The output XML validation log file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object? OutValidationLog { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Export Type</para>
		/// </summary>
		public enum ExportTypeEnum 
		{
			/// <summary>
			/// <para>Baseline— The message contains all features in a given message.</para>
			/// </summary>
			[GPValue("BASELINE")]
			[Description("Baseline")]
			Baseline,

			/// <summary>
			/// <para>Snapshot—The message contains all features at a specific point in time.</para>
			/// </summary>
			[GPValue("SNAPSHOT")]
			[Description("Snapshot")]
			Snapshot,

			/// <summary>
			/// <para>Permanent Delta—The message contains updates in a given time slice in features as a result of a baseline update.</para>
			/// </summary>
			[GPValue("PERM_DELTA")]
			[Description("Permanent Delta")]
			Permanent_Delta,

			/// <summary>
			/// <para>Temporary Delta—The message contains changes for some features in a given time slice representing a temporary event.</para>
			/// </summary>
			[GPValue("TEMP_DELTA")]
			[Description("Temporary Delta")]
			Temporary_Delta,

		}

		/// <summary>
		/// <para>Validate Output</para>
		/// </summary>
		public enum ValidateOutputEnum 
		{
			/// <summary>
			/// <para>Checked—XML validation will be performed on the exported message.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE")]
			VALIDATE,

			/// <summary>
			/// <para>Unchecked—XML validation will not be performed on the exported message. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VALIDATE")]
			NO_VALIDATE,

		}

#endregion
	}
}
