using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Extract LAS</para>
	/// <para>Creates new LAS files from point cloud data in a LAS dataset or point cloud scene layer.</para>
	/// </summary>
	public class ExtractLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input Point Cloud</para>
		/// <para>The LAS dataset or point cloud scene layer to process.</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </param>
		public ExtractLas(object InLasDataset, object TargetFolder)
		{
			this.InLasDataset = InLasDataset;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract LAS</para>
		/// </summary>
		public override string DisplayName => "Extract LAS";

		/// <summary>
		/// <para>Tool Name : ExtractLas</para>
		/// </summary>
		public override string ToolName => "ExtractLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ExtractLas</para>
		/// </summary>
		public override string ExcuteName => "3d.ExtractLas";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, TargetFolder, Extent, Boundary, ProcessEntireFiles, NameSuffix, RemoveVlr, RearrangePoints, ComputeStats, OutLasDataset, OutFolder, Compression };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>The LAS dataset or point cloud scene layer to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The existing folder to which the output .las files will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Processing Extent</para>
		/// <para>The extent of the data that will be evaluated.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Processing Extent")]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Extraction Boundary</para>
		/// <para>A polygon boundary that defines the area of the .las files that will be clipped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[Category("Processing Extent")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Process entire LAS files that intersect extent</para>
		/// <para>Specifies how the area of interest will be used in determining how .las files will be processed. The area of interest is defined by the Processing Extent parameter value, the Processing Boundary parameter value, or a combination of both.</para>
		/// <para>Unchecked—Only LAS points that intersect the area of interest will be processed. This is the default.</para>
		/// <para>Checked—If any portion of a .las file intersects the area of interest, all the points in that .las file, including those outside the area of interest, will be processed.</para>
		/// <para><see cref="ProcessEntireFilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Processing Extent")]
		public object ProcessEntireFiles { get; set; } = "false";

		/// <summary>
		/// <para>Output File Name Suffix</para>
		/// <para>The text that will be appended to the name of each output .las file. Each file will inherit its base name from its source file, followed by the suffix specified in this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("LAS File Options")]
		public object NameSuffix { get; set; }

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// <para>Specifies whether variable length records (VLRs) will be removed. Each .las file may potentially contain a set of VLRs that were added by the software that produced it. The meaning of these records is typically only known by the originating software. Unless the output LAS data will be processed by an application that understands this information, retaining the VLRs may not provide any value-added functionality. Removing the VLRs can potentially save significant disk space depending on their total size and the number of files containing them.</para>
		/// <para>Unchecked—The variable length records in the input .las files will not be removed and will remain in the output .las files. This is the default.</para>
		/// <para>Checked—The variable length records in the input .las files will be removed from the output .las files.</para>
		/// <para><see cref="RemoveVlrEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RemoveVlr { get; set; } = "false";

		/// <summary>
		/// <para>Rearrange points</para>
		/// <para>Specifies whether points in the .las files will be rearranged.</para>
		/// <para>Unchecked—The order of the points in the .las files will not be rearranged.</para>
		/// <para>Checked—The points in the .las files will be rearranged. This is the default.</para>
		/// <para><see cref="RearrangePointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RearrangePoints { get; set; } = "true";

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>Specifies whether statistics will be computed for the .las files referenced by the LAS dataset. Computing statistics provides a spatial index for each .las file, which improves analysis and display performance. Statistics also enhance the filtering and symbology experience by limiting the display of LAS attributes, such as classification codes and return information, to values that are present in the .las file.</para>
		/// <para>Checked—Statistics will be computed. This is the default.</para>
		/// <para>Unchecked—Statistics will not be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>The output LAS dataset referencing the newly created .las files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>Specifies whether the output .las file will be in a compressed format or the standard LAS format.</para>
		/// <para>Same As Input—The compression will be the same as the input. This option is only available when the input is a LAS dataset It is the default in that case.</para>
		/// <para>No Compression—The output will be in the standard LAS format (*.las). This is the default when the input is a point cloud scene layer.</para>
		/// <para>zLAS Compression—Output .las files will be compressed in the zLAS format.</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object Compression { get; set; } = "SAME_AS_INPUT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractLas SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Process entire LAS files that intersect extent</para>
		/// </summary>
		public enum ProcessEntireFilesEnum 
		{
			/// <summary>
			/// <para>Checked—If any portion of a .las file intersects the area of interest, all the points in that .las file, including those outside the area of interest, will be processed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_ENTIRE_FILES")]
			PROCESS_ENTIRE_FILES,

			/// <summary>
			/// <para>Unchecked—Only LAS points that intersect the area of interest will be processed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PROCESS_EXTENT")]
			PROCESS_EXTENT,

		}

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// </summary>
		public enum RemoveVlrEnum 
		{
			/// <summary>
			/// <para>Checked—The variable length records in the input .las files will be removed from the output .las files.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_VLR")]
			REMOVE_VLR,

			/// <summary>
			/// <para>Unchecked—The variable length records in the input .las files will not be removed and will remain in the output .las files. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_VLR")]
			MAINTAIN_VLR,

		}

		/// <summary>
		/// <para>Rearrange points</para>
		/// </summary>
		public enum RearrangePointsEnum 
		{
			/// <summary>
			/// <para>Checked—The points in the .las files will be rearranged. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REARRANGE_POINTS")]
			REARRANGE_POINTS,

			/// <summary>
			/// <para>Unchecked—The order of the points in the .las files will not be rearranged.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_POINTS")]
			MAINTAIN_POINTS,

		}

		/// <summary>
		/// <para>Compute Statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be computed. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be computed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum CompressionEnum 
		{
			/// <summary>
			/// <para>Same As Input—The compression will be the same as the input. This option is only available when the input is a LAS dataset It is the default in that case.</para>
			/// </summary>
			[GPValue("SAME_AS_INPUT")]
			[Description("Same As Input")]
			Same_As_Input,

			/// <summary>
			/// <para>No Compression—The output will be in the standard LAS format (*.las). This is the default when the input is a point cloud scene layer.</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("No Compression")]
			No_Compression,

			/// <summary>
			/// <para>zLAS Compression—Output .las files will be compressed in the zLAS format.</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS Compression")]
			zLAS_Compression,

		}

#endregion
	}
}
