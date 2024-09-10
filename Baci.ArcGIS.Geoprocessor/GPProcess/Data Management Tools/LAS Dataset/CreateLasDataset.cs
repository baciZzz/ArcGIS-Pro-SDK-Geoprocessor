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
	/// <para>Create LAS Dataset</para>
	/// <para>Creates a LAS dataset referencing one or more LAS files and optional surface constraint features.</para>
	/// </summary>
	public class CreateLasDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input Files</para>
		/// <para>The LAS files and folders containing LAS files that will be referenced by the LAS dataset.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </param>
		/// <param name="OutLasDataset">
		/// <para>Output LAS Dataset</para>
		/// <para>The LAS dataset that will be created.</para>
		/// </param>
		public CreateLasDataset(object Input, object OutLasDataset)
		{
			this.Input = Input;
			this.OutLasDataset = OutLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LAS Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create LAS Dataset";

		/// <summary>
		/// <para>Tool Name : CreateLasDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLasDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateLasDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateLasDataset";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, OutLasDataset, FolderRecursion, InSurfaceConstraints, SpatialReference, ComputeStats, RelativePaths, CreateLasPrj };

		/// <summary>
		/// <para>Input Files</para>
		/// <para>The LAS files and folders containing LAS files that will be referenced by the LAS dataset.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>The LAS dataset that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Include subfolders</para>
		/// <para>Specifies whether .las files residing in the subdirectories of an input folder will be referenced by the LAS dataset.</para>
		/// <para>Unchecked—Only .las files residing in an input folder will be added to the LAS dataset. This is the default.</para>
		/// <para>Checked—All .las files residing in the subdirectories of an input folder will be added to the LAS dataset.</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Surface Constraints</para>
		/// <para>The features that will contribute to the definition of the triangulated surface generated from the LAS dataset.</para>
		/// <para>Input Features—The features with geometry that will be incorporated into the LAS dataset&apos;s triangulated surface.</para>
		/// <para>Height Field—The feature&apos;s elevation source can be derived from any numeric field in the feature&apos;s attribute table or the geometry by selecting Shape.Z. If no height is necessary, specify the keyword &lt;None&gt; to create z-less features with elevation that will be interpolated from the surface.</para>
		/// <para>Type—Defines the feature&apos;s role in the triangulated surface generated from the LAS dataset. Options with hard or soft designation refer to whether the feature edges represent distinct breaks in slope or a gradual change.</para>
		/// <para>Surface Feature Type—The surface feature type that defines how the feature geometry will be incorporated into the triangulation for the surface. Options with hard or soft designation refer to whether the feature edges represent distinct breaks in slope or a gradual change.</para>
		/// <para>anchorpoints—Elevation points that will not be thinned away. This option is only available for single-point feature geometry.</para>
		/// <para>hardline or softline—Breaklines that enforce a height value.</para>
		/// <para>hardclip or softclip—Polygon dataset that defines the boundary of the LAS dataset.</para>
		/// <para>harderase or softerase—Polygon dataset that defines holes in the LAS dataset.</para>
		/// <para>hardreplace or softreplace—Polygon dataset that defines areas of constant height.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InSurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the LAS dataset. If no spatial reference is explicitly assigned, the LAS dataset will use the coordinate system of the first input LAS file. If the input files do not contain any spatial reference information and the Input Coordinate System is not set, then the LAS dataset's coordinate system will be listed as unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>Specifies whether statistics for the LAS files will be computed and a spatial index generated for the LAS dataset. The presence of statistics allows the LAS dataset layer&apos;s filtering and symbology options to only show LAS attribute values that exist in the LAS files. A .lasx auxiliary file is created for each LAS file.</para>
		/// <para>Unchecked—Statistics will not be computed. This is the default.</para>
		/// <para>Checked—Statistics will be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Store Relative Paths</para>
		/// <para>Specifies whether lidar files and surface constraint features will be referenced by the LAS dataset through relative or absolute paths. Using relative paths may be convenient for cases where the LAS dataset and its associated data will be relocated in the file system using the same relative location to one another.</para>
		/// <para>Unchecked—Absolute paths will be used for the data referenced by the LAS dataset. This is the default.</para>
		/// <para>Checked—Relative paths will be used for the data referenced by the LAS dataset.</para>
		/// <para><see cref="RelativePathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RelativePaths { get; set; } = "false";

		/// <summary>
		/// <para>Create PRJ For LAS Files</para>
		/// <para>Specifies whether .prj files will be created for the LAS files referenced by the LAS dataset.</para>
		/// <para>No LAS Files—No files will have a PRJ file created. This is the default.</para>
		/// <para>Files with Missing Spatial References—Only LAS files without a spatial reference will have a corresponding PRJ file.</para>
		/// <para>All LAS Files—All LAS files will have a corresponding PRJ file.</para>
		/// <para><see cref="CreateLasPrjEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CreateLasPrj { get; set; } = "NO_FILES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLasDataset SetEnviroment(object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include subfolders</para>
		/// </summary>
		public enum FolderRecursionEnum 
		{
			/// <summary>
			/// <para>Checked—All .las files residing in the subdirectories of an input folder will be added to the LAS dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSION")]
			RECURSION,

			/// <summary>
			/// <para>Unchecked—Only .las files residing in an input folder will be added to the LAS dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECURSION")]
			NO_RECURSION,

		}

		/// <summary>
		/// <para>Compute Statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be computed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be computed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Store Relative Paths</para>
		/// </summary>
		public enum RelativePathsEnum 
		{
			/// <summary>
			/// <para>Checked—Relative paths will be used for the data referenced by the LAS dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RELATIVE_PATHS")]
			RELATIVE_PATHS,

			/// <summary>
			/// <para>Unchecked—Absolute paths will be used for the data referenced by the LAS dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE_PATHS")]
			ABSOLUTE_PATHS,

		}

		/// <summary>
		/// <para>Create PRJ For LAS Files</para>
		/// </summary>
		public enum CreateLasPrjEnum 
		{
			/// <summary>
			/// <para>No LAS Files—No files will have a PRJ file created. This is the default.</para>
			/// </summary>
			[GPValue("NO_FILES")]
			[Description("No LAS Files")]
			No_LAS_Files,

			/// <summary>
			/// <para>Files with Missing Spatial References—Only LAS files without a spatial reference will have a corresponding PRJ file.</para>
			/// </summary>
			[GPValue("FILES_MISSING_PROJECTION")]
			[Description("Files with Missing Spatial References")]
			Files_with_Missing_Spatial_References,

			/// <summary>
			/// <para>All LAS Files—All LAS files will have a corresponding PRJ file.</para>
			/// </summary>
			[GPValue("ALL_FILES")]
			[Description("All LAS Files")]
			All_LAS_Files,

		}

#endregion
	}
}
