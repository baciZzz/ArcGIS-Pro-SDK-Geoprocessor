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
	/// <para>Package Result</para>
	/// <para>Packages one or more geoprocessing results, including all tools and</para>
	/// <para>input and output datasets, into a single compressed file (.gpkx).</para>
	/// </summary>
	public class PackageResult : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InResult">
		/// <para>Result</para>
		/// <para>The result that will be packaged.</para>
		/// <para>The input can be either a result from the history of the current project or a Result object&apos;s resultID property when the tool is being used in a Python script.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The name and location of the output package file (.gpkx).</para>
		/// </param>
		public PackageResult(object InResult, object OutputFile)
		{
			this.InResult = InResult;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Package Result</para>
		/// </summary>
		public override string DisplayName => "Package Result";

		/// <summary>
		/// <para>Tool Name : PackageResult</para>
		/// </summary>
		public override string ToolName => "PackageResult";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageResult</para>
		/// </summary>
		public override string ExcuteName => "management.PackageResult";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InResult, OutputFile, ConvertData!, ConvertArcsdeData!, Extent!, ApplyExtentToArcsde!, SchemaOnly!, Arcgisruntime!, AdditionalFiles!, Summary!, Tags!, Version!, SelectRelatedRows! };

		/// <summary>
		/// <para>Result</para>
		/// <para>The result that will be packaged.</para>
		/// <para>The input can be either a result from the history of the current project or a Result object&apos;s resultID property when the tool is being used in a Python script.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InResult { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The name and location of the output package file (.gpkx).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// <para>Specifies whether input layers will be converted to a file geodatabase or preserved in their original format.</para>
		/// <para>Checked—All data will be converted to a file geodatabase. This option does not apply to enterprise geodatabase data sources. To include enterprise geodatabase data, check the Include Enterprise geodatabase data instead of referencing the data parameter.</para>
		/// <para>Unchecked—Data formats will be preserved when possible. This is the default.</para>
		/// <para><see cref="ConvertDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConvertData { get; set; } = "false";

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// <para>Specifies whether input enterprise geodatabase layers will be converted to a file geodatabase or preserved in their original format.</para>
		/// <para>Checked—All enterprise geodatabase data sources will be converted to a file geodatabase. This is the default.</para>
		/// <para>Unchecked—All enterprise geodatabase data sources will be preserved and will be referenced in the resulting package.</para>
		/// <para><see cref="ConvertArcsdeDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConvertArcsdeData { get; set; } = "true";

		/// <summary>
		/// <para>Extent</para>
		/// <para>Specifies the extent that will be used to select or clip features.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// <para>Specifies whether the specified extent will be applied to all layers or to enterprise geodatabase layers only.</para>
		/// <para>Unchecked—The extent will be applied to all layers. This is the default.</para>
		/// <para>Checked—The extent will be applied to enterprise geodatabase layers only.</para>
		/// <para><see cref="ApplyExtentToArcsdeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ApplyExtentToArcsde { get; set; } = "false";

		/// <summary>
		/// <para>Schema only</para>
		/// <para>Specifies whether all features and records for input and output datasets or only the schema of input and output datasets will be consolidated or packaged.</para>
		/// <para>Unchecked—All features and records for input and output datasets will be included in the consolidated folder or package. This is the default.</para>
		/// <para>Checked—Only the schema of input and output datasets will be consolidated or packaged. No features or records will be consolidated or packaged in the output folder.</para>
		/// <para><see cref="SchemaOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SchemaOnly { get; set; } = "false";

		/// <summary>
		/// <para>Support ArcGIS Runtime</para>
		/// <para>Specifies whether the package will support ArcGIS Runtime. To support ArcGIS Runtime, all data sources will be converted to a file geodatabase, and a server compatible tool will be created in the package.</para>
		/// <para>Unchecked—The output package will not support ArcGIS Runtime. This is the default.</para>
		/// <para>Checked—The output package will support ArcGIS Runtime.</para>
		/// <para><see cref="ArcgisruntimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Arcgisruntime { get; set; } = "false";

		/// <summary>
		/// <para>Additional Files</para>
		/// <para>Adds files to a package. Additional files, such as .doc, .txt, .pdf, and so on, are used to provide more information about the contents and purpose of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? AdditionalFiles { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Adds summary information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Adds tag information to the properties of the package. Multiple tags can be added or separated by a comma or semicolon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Package version</para>
		/// <para>Specifies the version of the geodatabases that will be created in the resulting package. Specifying a version allows packages to be shared with earlier versions of ArcGIS and supports backward compatibility.A package saved to an earlier version may lose properties that are only available in the later version.</para>
		/// <para>All versions— The package will contain geodatabases and maps compatible with all versions (ArcGIS Pro 2.1 and later).</para>
		/// <para>Current version— The package will contain geodatabases and maps compatible with the version of the current release.</para>
		/// <para>2.2— The package will contain geodatabases and maps compatible with version 2.2.</para>
		/// <para>2.3—The package will contain geodatabases and maps compatible with version 2.3.</para>
		/// <para>2.4—The package will contain geodatabases and maps compatible with version 2.4.</para>
		/// <para>2.5—The package will contain geodatabases and maps compatible with version 2.5.</para>
		/// <para>2.6—The package will contain geodatabases and maps compatible with version 2.6.</para>
		/// <para>2.7—The package will contain geodatabases and maps compatible with version 2.7.</para>
		/// <para>2.8—The package will contain geodatabases and maps compatible with version 2.8.</para>
		/// <para>2.9—The package will contain geodatabases and maps compatible with version 2.9.</para>
		/// <para>3.0—The package will contain geodatabases and maps compatible with version 3.0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Version { get; set; } = "ALL";

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>Specifies whether the specified extent will be applied to related data sources.</para>
		/// <para>Unchecked—Related data sources will be consolidated in their entirety. This is the default.</para>
		/// <para>Checked—Only related data corresponding to records within the specified extent will be consolidated.</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SelectRelatedRows { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// </summary>
		public enum ConvertDataEnum 
		{
			/// <summary>
			/// <para>Checked—All data will be converted to a file geodatabase. This option does not apply to enterprise geodatabase data sources. To include enterprise geodatabase data, check the Include Enterprise geodatabase data instead of referencing the data parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT")]
			CONVERT,

			/// <summary>
			/// <para>Unchecked—Data formats will be preserved when possible. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE")]
			PRESERVE,

		}

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// </summary>
		public enum ConvertArcsdeDataEnum 
		{
			/// <summary>
			/// <para>Checked—All enterprise geodatabase data sources will be converted to a file geodatabase. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT_ARCSDE")]
			CONVERT_ARCSDE,

			/// <summary>
			/// <para>Unchecked—All enterprise geodatabase data sources will be preserved and will be referenced in the resulting package.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_ARCSDE")]
			PRESERVE_ARCSDE,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToArcsdeEnum 
		{
			/// <summary>
			/// <para>Checked—The extent will be applied to enterprise geodatabase layers only.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ARCSDE_ONLY")]
			ARCSDE_ONLY,

			/// <summary>
			/// <para>Unchecked—The extent will be applied to all layers. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Schema only</para>
		/// </summary>
		public enum SchemaOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Only the schema of input and output datasets will be consolidated or packaged. No features or records will be consolidated or packaged in the output folder.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SCHEMA_ONLY")]
			SCHEMA_ONLY,

			/// <summary>
			/// <para>Unchecked—All features and records for input and output datasets will be included in the consolidated folder or package. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Support ArcGIS Runtime</para>
		/// </summary>
		public enum ArcgisruntimeEnum 
		{
			/// <summary>
			/// <para>Checked—The output package will support ArcGIS Runtime.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RUNTIME")]
			RUNTIME,

			/// <summary>
			/// <para>Unchecked—The output package will not support ArcGIS Runtime. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DESKTOP")]
			DESKTOP,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para>Checked—Only related data corresponding to records within the specified extent will be consolidated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para>Unchecked—Related data sources will be consolidated in their entirety. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

#endregion
	}
}
