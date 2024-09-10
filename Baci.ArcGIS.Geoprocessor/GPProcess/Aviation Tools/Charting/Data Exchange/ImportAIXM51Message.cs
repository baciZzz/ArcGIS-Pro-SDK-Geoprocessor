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
	/// <para>Import AIXM 5.1 Message</para>
	/// <para>Imports Aeronautical Information Exchange Model (AIXM) version 5.1 data into an aviation geodatabase.</para>
	/// </summary>
	public class ImportAIXM51Message : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMessageFile">
		/// <para>Input AIXM 5.1 Message File</para>
		/// <para>The input AIXM 5.1 message.</para>
		/// </param>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The ArcGIS Aviation Charting schema workspace to import into.</para>
		/// </param>
		public ImportAIXM51Message(object InMessageFile, object TargetGdb)
		{
			this.InMessageFile = InMessageFile;
			this.TargetGdb = TargetGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : Import AIXM 5.1 Message</para>
		/// </summary>
		public override string DisplayName() => "Import AIXM 5.1 Message";

		/// <summary>
		/// <para>Tool Name : ImportAIXM51Message</para>
		/// </summary>
		public override string ToolName() => "ImportAIXM51Message";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ImportAIXM51Message</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ImportAIXM51Message";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMessageFile, TargetGdb, InTables, UpdateExistingFeatures, UpdatedGdb };

		/// <summary>
		/// <para>Input AIXM 5.1 Message File</para>
		/// <para>The input AIXM 5.1 message.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object InMessageFile { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The ArcGIS Aviation Charting schema workspace to import into.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>The names of tables used to restrict the feature types that will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPDatasetDomain()]
		public object InTables { get; set; }

		/// <summary>
		/// <para>Update Existing Features</para>
		/// <para>Specifies whether existing features will be updated if they exist or new features will be inserted.</para>
		/// <para>Checked—Existing features will be updated.</para>
		/// <para>Unchecked—New features will be inserted. This is default.</para>
		/// <para><see cref="UpdateExistingFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateExistingFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedGdb { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Update Existing Features</para>
		/// </summary>
		public enum UpdateExistingFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—Existing features will be updated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_EXISTING")]
			UPDATE_EXISTING,

			/// <summary>
			/// <para>Unchecked—New features will be inserted. This is default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CREATE_NEW")]
			CREATE_NEW,

		}

#endregion
	}
}
