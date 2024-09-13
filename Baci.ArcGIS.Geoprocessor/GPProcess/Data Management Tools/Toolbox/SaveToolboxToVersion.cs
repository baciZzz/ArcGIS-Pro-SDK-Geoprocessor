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
	/// <para>Save Toolbox To Version</para>
	/// <para>Save Toolbox To Version</para>
	/// <para>Analyzes and saves a toolbox for use with a specific version of ArcGIS software.</para>
	/// </summary>
	public class SaveToolboxToVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InToolbox">
		/// <para>Input Toolbox</para>
		/// <para>The input toolbox (.tbx or .atbx) that will be analyzed and saved. The file will not be modified.</para>
		/// <para>The Python toolbox (.pyt) format is not supported as an input.</para>
		/// </param>
		/// <param name="Version">
		/// <para>Target Version</para>
		/// <para>Specifies the software version that will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version.</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.2—ArcGIS Pro 2.2 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.3—ArcGIS Pro 2.3 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.4—ArcGIS Pro 2.4 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.5—ArcGIS Pro 2.5 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.6—ArcGIS Pro 2.6 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.7—ArcGIS Pro 2.7 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.8—ArcGIS Pro 2.8 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.9—ArcGIS Pro 2.9 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// </param>
		/// <param name="OutToolbox">
		/// <para>Output Toolbox</para>
		/// <para>The toolbox that will be created for use with ArcGIS software of the specified Target Version parameter value.</para>
		/// </param>
		public SaveToolboxToVersion(object InToolbox, object Version, object OutToolbox)
		{
			this.InToolbox = InToolbox;
			this.Version = Version;
			this.OutToolbox = OutToolbox;
		}

		/// <summary>
		/// <para>Tool Display Name : Save Toolbox To Version</para>
		/// </summary>
		public override string DisplayName() => "Save Toolbox To Version";

		/// <summary>
		/// <para>Tool Name : SaveToolboxToVersion</para>
		/// </summary>
		public override string ToolName() => "SaveToolboxToVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.SaveToolboxToVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.SaveToolboxToVersion";

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
		public override object[] Parameters() => new object[] { InToolbox, Version, OutToolbox, MissingTool!, MissingParam!, InvalidParamValue! };

		/// <summary>
		/// <para>Input Toolbox</para>
		/// <para>The input toolbox (.tbx or .atbx) that will be analyzed and saved. The file will not be modified.</para>
		/// <para>The Python toolbox (.pyt) format is not supported as an input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEToolbox()]
		public object InToolbox { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>Specifies the software version that will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version.</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.2—ArcGIS Pro 2.2 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.3—ArcGIS Pro 2.3 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.4—ArcGIS Pro 2.4 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.5—ArcGIS Pro 2.5 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.6—ArcGIS Pro 2.6 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.7—ArcGIS Pro 2.7 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.8—ArcGIS Pro 2.8 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// <para>2.9—ArcGIS Pro 2.9 will be used for toolbox compatibility issue analysis. The output toolbox will be saved to this version..</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Output Toolbox</para>
		/// <para>The toolbox that will be created for use with ArcGIS software of the specified Target Version parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEToolbox()]
		public object OutToolbox { get; set; }

		/// <summary>
		/// <para>Error on missing tool</para>
		/// <para>Specifies whether the operation will produce an error if a tool is encountered that is not present at the target version.</para>
		/// <para>Checked—If a tool is encountered that is not present at the target version, the operation will produce an error and the output toolbox will not be created. This is the default.</para>
		/// <para>Unchecked—If a tool is encountered that is not present at the target version, the operation will produce a warning message and create the output toolbox. For model tools, the problematic tool will be removed from the model, which will require manual editing.</para>
		/// <para><see cref="MissingToolEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MissingTool { get; set; } = "true";

		/// <summary>
		/// <para>Error on missing required parameter</para>
		/// <para>Specifies whether the operation will produce an error if a parameter is encountered that is not present at the target version and that parameter has a value that is not its default value.</para>
		/// <para>Checked—If a parameter is encountered that is not present at the target version and that parameter has a value that is not its default value, the operation will produce an error and the output toolbox will not be created. This is the default.</para>
		/// <para>Unchecked—If a parameter is encountered that is not present at the target version and that parameter has a value that is not its default value, the operation will remove the parameter from the model and the output toolbox will be created.</para>
		/// <para><see cref="MissingParamEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MissingParam { get; set; } = "true";

		/// <summary>
		/// <para>Error on invalid parameter value</para>
		/// <para>Specifies whether the operation will produce an error if a parameter value is encountered that is not present in its parameter filter at the target version.</para>
		/// <para>Checked—If a parameter value is encountered that is not present in its parameter filter at the target version, the operation will produce an error and the output toolbox will not be created. This is the default.</para>
		/// <para>Unchecked—If a parameter value is encountered that is not present in its parameter filter at the target version, the operation will proceed with warnings and the output toolbox will be created. The output toolbox will produce an error if it has a value that is not in domain or is invalid.</para>
		/// <para><see cref="InvalidParamValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InvalidParamValue { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Error on missing tool</para>
		/// </summary>
		public enum MissingToolEnum 
		{
			/// <summary>
			/// <para>Checked—If a tool is encountered that is not present at the target version, the operation will produce an error and the output toolbox will not be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_ON_MISSING_TOOL")]
			ERROR_ON_MISSING_TOOL,

			/// <summary>
			/// <para>Unchecked—If a tool is encountered that is not present at the target version, the operation will produce a warning message and create the output toolbox. For model tools, the problematic tool will be removed from the model, which will require manual editing.</para>
			/// </summary>
			[GPValue("false")]
			[Description("WARN_ON_MISSING_TOOL")]
			WARN_ON_MISSING_TOOL,

		}

		/// <summary>
		/// <para>Error on missing required parameter</para>
		/// </summary>
		public enum MissingParamEnum 
		{
			/// <summary>
			/// <para>Checked—If a parameter is encountered that is not present at the target version and that parameter has a value that is not its default value, the operation will produce an error and the output toolbox will not be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_ON_MISSING_REQUIRED_PARAM")]
			ERROR_ON_MISSING_REQUIRED_PARAM,

			/// <summary>
			/// <para>Unchecked—If a parameter is encountered that is not present at the target version and that parameter has a value that is not its default value, the operation will remove the parameter from the model and the output toolbox will be created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("WARN_ON_MISSING_REQUIRED_PARAM")]
			WARN_ON_MISSING_REQUIRED_PARAM,

		}

		/// <summary>
		/// <para>Error on invalid parameter value</para>
		/// </summary>
		public enum InvalidParamValueEnum 
		{
			/// <summary>
			/// <para>Checked—If a parameter value is encountered that is not present in its parameter filter at the target version, the operation will produce an error and the output toolbox will not be created. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_ON_INVALID_PARAM_VALUE")]
			ERROR_ON_INVALID_PARAM_VALUE,

			/// <summary>
			/// <para>Unchecked—If a parameter value is encountered that is not present in its parameter filter at the target version, the operation will proceed with warnings and the output toolbox will be created. The output toolbox will produce an error if it has a value that is not in domain or is invalid.</para>
			/// </summary>
			[GPValue("false")]
			[Description("WARN_ON_INVALID_PARAM_VALUE")]
			WARN_ON_INVALID_PARAM_VALUE,

		}

#endregion
	}
}
