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
	/// <para>Consolidate Toolbox</para>
	/// <para>Consolidates one or more toolboxes (a .tbx or .pyt file) to a specified output folder.</para>
	/// </summary>
	public class ConsolidateToolbox : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InToolbox">
		/// <para>Toolbox</para>
		/// <para>The toolboxes to be consolidated.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated toolbox.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </param>
		public ConsolidateToolbox(object InToolbox, object OutputFolder)
		{
			this.InToolbox = InToolbox;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Consolidate Toolbox</para>
		/// </summary>
		public override string DisplayName() => "Consolidate Toolbox";

		/// <summary>
		/// <para>Tool Name : ConsolidateToolbox</para>
		/// </summary>
		public override string ToolName() => "ConsolidateToolbox";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateToolbox</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateToolbox";

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
		public override object[] Parameters() => new object[] { InToolbox, OutputFolder, Version };

		/// <summary>
		/// <para>Toolbox</para>
		/// <para>The toolboxes to be consolidated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InToolbox { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated toolbox.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Version</para>
		/// <para>Specifies the version of the consolidated toolbox. Specifying a version allows toolboxes to be shared with previous versions of ArcGIS and supports backward compatibility.</para>
		/// <para>Current version—The consolidated folder will contain tools compatible with the version of the current release. This is the default.</para>
		/// <para>2.1—The consolidated folder will contain tools compatible with version 2.1.</para>
		/// <para>2.2— The consolidated folder will contain tools compatible with version 2.2.</para>
		/// <para>2.3—The consolidated folder will contain tools compatible with version 2.3.</para>
		/// <para>2.4—The consolidated folder will contain tools compatible with version 2.4.</para>
		/// <para>2.5—The consolidated folder will contain tools compatible with version 2.5.</para>
		/// <para>2.6—The consolidated folder will contain tools compatible with version 2.6.</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

		#region InnerClass

		/// <summary>
		/// <para>Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>Current version—The consolidated folder will contain tools compatible with the version of the current release. This is the default.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current version")]
			Current_version,

			/// <summary>
			/// <para>2.1—The consolidated folder will contain tools compatible with version 2.1.</para>
			/// </summary>
			[GPValue("2.1")]
			[Description("2.1")]
			_21,

			/// <summary>
			/// <para>2.2— The consolidated folder will contain tools compatible with version 2.2.</para>
			/// </summary>
			[GPValue("2.2")]
			[Description("2.2")]
			_22,

			/// <summary>
			/// <para>2.3—The consolidated folder will contain tools compatible with version 2.3.</para>
			/// </summary>
			[GPValue("2.3")]
			[Description("2.3")]
			_23,

			/// <summary>
			/// <para>2.4—The consolidated folder will contain tools compatible with version 2.4.</para>
			/// </summary>
			[GPValue("2.4")]
			[Description("2.4")]
			_24,

			/// <summary>
			/// <para>2.5—The consolidated folder will contain tools compatible with version 2.5.</para>
			/// </summary>
			[GPValue("2.5")]
			[Description("2.5")]
			_25,

			/// <summary>
			/// <para>2.6—The consolidated folder will contain tools compatible with version 2.6.</para>
			/// </summary>
			[GPValue("2.6")]
			[Description("2.6")]
			_26,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2.7")]
			[Description("2.7")]
			_27,

		}

#endregion
	}
}
