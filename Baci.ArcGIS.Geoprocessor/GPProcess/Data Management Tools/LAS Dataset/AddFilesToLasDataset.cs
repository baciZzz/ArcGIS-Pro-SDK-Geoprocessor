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
	/// <para>Add Files To LAS Dataset</para>
	/// <para>Add Files To LAS Dataset</para>
	/// <para>Adds references for one or more LAS files and  surface constraint features to a LAS dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFilesToLasDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		public AddFilesToLasDataset(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Files To LAS Dataset</para>
		/// </summary>
		public override string DisplayName() => "Add Files To LAS Dataset";

		/// <summary>
		/// <para>Tool Name : AddFilesToLasDataset</para>
		/// </summary>
		public override string ToolName() => "AddFilesToLasDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFilesToLasDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFilesToLasDataset";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFiles!, FolderRecursion!, InSurfaceConstraints!, DerivedLasDataset! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>LAS Files or Folders</para>
		/// <para>Input files can reference any combination of individual LAS files and folders containing LAS data.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object? InFiles { get; set; }

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
		public object? FolderRecursion { get; set; } = "false";

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
		public object? InSurfaceConstraints { get; set; }

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFilesToLasDataset SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
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

#endregion
	}
}
