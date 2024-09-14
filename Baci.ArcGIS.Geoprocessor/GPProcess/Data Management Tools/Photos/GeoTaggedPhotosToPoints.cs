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
	/// <para>GeoTagged Photos To Points</para>
	/// <para>GeoTagged Photos To Points</para>
	/// <para>Creates points from the x-, y-, and z-coordinates stored in geotagged photos. Optionally adds photo files to features in the output feature class as geodatabase attachments.</para>
	/// </summary>
	public class GeoTaggedPhotosToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFolder">
		/// <para>Input Folder</para>
		/// <para>The folder where photo files are located. This folder is scanned recursively for photo files; any photos in the base level of the folder, as well as in any subfolders, will be added to the output.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class.</para>
		/// </param>
		public GeoTaggedPhotosToPoints(object InputFolder, object OutputFeatureClass)
		{
			this.InputFolder = InputFolder;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GeoTagged Photos To Points</para>
		/// </summary>
		public override string DisplayName() => "GeoTagged Photos To Points";

		/// <summary>
		/// <para>Tool Name : GeoTaggedPhotosToPoints</para>
		/// </summary>
		public override string ToolName() => "GeoTaggedPhotosToPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.GeoTaggedPhotosToPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.GeoTaggedPhotosToPoints";

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
		public override string[] ValidEnvironments() => new string[] { "outputZFlag", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFolder, OutputFeatureClass, InvalidPhotosTable, IncludeNonGeotaggedPhotos, AddPhotosAsAttachments };

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>The folder where photo files are located. This folder is scanned recursively for photo files; any photos in the base level of the folder, as well as in any subfolders, will be added to the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InputFolder { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Invalid Photos Table</para>
		/// <para>The optional output table that will list any photo files in the input folder with invalid Exif metadata or empty or invalid coordinates.</para>
		/// <para>If no path is specified, this table will not be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object InvalidPhotosTable { get; set; }

		/// <summary>
		/// <para>Include Non-GeoTagged Photos</para>
		/// <para>Specifies if all photo files will be included in the output feature class or only those with valid coordinates.</para>
		/// <para>Checked—All photos will be added as records to the output feature class. If a photo file does not have coordinate information, it will be added as a feature with null geometry. This is the default.</para>
		/// <para>Unchecked—Only photos with valid coordinate information will be included in the output feature class.</para>
		/// <para><see cref="IncludeNonGeotaggedPhotosEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeNonGeotaggedPhotos { get; set; } = "true";

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// <para>Specifies if the input photos will be added to the output as geodatabase attachments.</para>
		/// <para>Adding attachments requires an ArcGIS Desktop Standard or higher license, and the output feature class must be in a version 10 or higher geodatabase.</para>
		/// <para>Checked—Photos will be added to the output features as geodatabase attachments copied internally to the geodatabase. This is the default.</para>
		/// <para>Unchecked—Photos will not be added to the output features as geodatabase attachments.</para>
		/// <para><see cref="AddPhotosAsAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddPhotosAsAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeoTaggedPhotosToPoints SetEnviroment(object outputZFlag = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(outputZFlag: outputZFlag, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Non-GeoTagged Photos</para>
		/// </summary>
		public enum IncludeNonGeotaggedPhotosEnum 
		{
			/// <summary>
			/// <para>Checked—All photos will be added as records to the output feature class. If a photo file does not have coordinate information, it will be added as a feature with null geometry. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_PHOTOS")]
			ALL_PHOTOS,

			/// <summary>
			/// <para>Unchecked—Only photos with valid coordinate information will be included in the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_GEOTAGGED")]
			ONLY_GEOTAGGED,

		}

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// </summary>
		public enum AddPhotosAsAttachmentsEnum 
		{
			/// <summary>
			/// <para>Checked—Photos will be added to the output features as geodatabase attachments copied internally to the geodatabase. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_ATTACHMENTS")]
			ADD_ATTACHMENTS,

			/// <summary>
			/// <para>Unchecked—Photos will not be added to the output features as geodatabase attachments.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTACHMENTS")]
			NO_ATTACHMENTS,

		}

#endregion
	}
}
