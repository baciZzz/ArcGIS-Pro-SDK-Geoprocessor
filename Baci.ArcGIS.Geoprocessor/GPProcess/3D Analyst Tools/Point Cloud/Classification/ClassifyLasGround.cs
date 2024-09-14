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
	/// <para>Classify LAS Ground</para>
	/// <para>Classify LAS Ground</para>
	/// <para>Classifies ground points from LAS data.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasGround : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process. Only the last return of LAS points with class code values of 0, 1, and 2 will be evaluated.</para>
		/// </param>
		public ClassifyLasGround(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify LAS Ground</para>
		/// </summary>
		public override string DisplayName() => "Classify LAS Ground";

		/// <summary>
		/// <para>Tool Name : ClassifyLasGround</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasGround";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasGround</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasGround";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, Method!, ReuseGround!, DemResolution!, ComputeStats!, Extent!, Boundary!, ProcessEntireFiles!, OutLasDataset!, UpdatePyramid! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process. Only the last return of LAS points with class code values of 0, 1, and 2 will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Ground Detection Method</para>
		/// <para>Specifies the method that will be used to detect ground points.</para>
		/// <para>Standard Classification—This method has a tolerance for slope variation that allows it to capture gradual undulations in the ground&apos;s topography that would typically be missed by the conservative option but not capture the type of sharp reliefs that would be captured by the aggressive option. This is the default.</para>
		/// <para>Conservative Classification— When compared to other options, this method uses a tighter restriction on the variation of the ground&apos;s slope that allows it to differentiate the ground from low-lying vegetation such as grass and shrubbery. It is best suited for topography with minimal curvature.</para>
		/// <para>Aggressive Classification— This method detects ground areas with sharper reliefs, such as ridges and hill tops, that may be ignored by the Standard Classification method. This method is best used in a second iteration of this tool with the Reuse existing ground parameter checked. Avoid using this method in urban areas or flat, rural areas, as it may result in the misclassification of taller objects—such as utility towers, vegetation, and portions of buildings—as ground.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Reuse existing ground</para>
		/// <para>Specifies whether existing ground points will be reclassified or reused.</para>
		/// <para>Unchecked—Existing ground points will be reclassified. Points that are not found to be a part of the ground will be reassigned a class code value of 1, which represents unclassified points. This is the default.</para>
		/// <para>Checked—Existing ground points will be accepted and reused without scrutiny and contribute to the determination of unclassified points.</para>
		/// <para><see cref="ReuseGroundEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReuseGround { get; set; } = "false";

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>A distance that will result in only a subset of points being evaluated for classification as ground, thereby making the process faster. Consider using this parameter when a faster method for generating a DEM surface is needed. The minimum distance is 0.3 meters, but the specified distance must be at least 1.5 times the average point spacing of the lidar data for this process to take effect.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? DemResolution { get; set; }

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>Specifies whether statistics will be computed for the .las files referenced by the LAS dataset. Computing statistics provides a spatial index for each .las file, which improves analysis and display performance. Statistics also enhance the filtering and symbology experience by limiting the display of LAS attributes, such as classification codes and return information, to values that are present in the .las file.</para>
		/// <para>Checked—Statistics will be computed. This is the default.</para>
		/// <para>Unchecked—Statistics will not be computed.</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ComputeStats { get; set; } = "true";

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
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>A polygon feature that defines the area of interest to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object? Boundary { get; set; }

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
		public object? ProcessEntireFiles { get; set; } = "false";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object? OutLasDataset { get; set; }

		/// <summary>
		/// <para>Update pyramid</para>
		/// <para>Specifies whether the LAS dataset pyramid will be updated after the class codes are modified.</para>
		/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
		/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyLasGround SetEnviroment(object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ground Detection Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Standard Classification—This method has a tolerance for slope variation that allows it to capture gradual undulations in the ground&apos;s topography that would typically be missed by the conservative option but not capture the type of sharp reliefs that would be captured by the aggressive option. This is the default.</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard Classification")]
			Standard_Classification,

			/// <summary>
			/// <para>Conservative Classification— When compared to other options, this method uses a tighter restriction on the variation of the ground&apos;s slope that allows it to differentiate the ground from low-lying vegetation such as grass and shrubbery. It is best suited for topography with minimal curvature.</para>
			/// </summary>
			[GPValue("CONSERVATIVE")]
			[Description("Conservative Classification")]
			Conservative_Classification,

			/// <summary>
			/// <para>Aggressive Classification— This method detects ground areas with sharper reliefs, such as ridges and hill tops, that may be ignored by the Standard Classification method. This method is best used in a second iteration of this tool with the Reuse existing ground parameter checked. Avoid using this method in urban areas or flat, rural areas, as it may result in the misclassification of taller objects—such as utility towers, vegetation, and portions of buildings—as ground.</para>
			/// </summary>
			[GPValue("AGGRESSIVE")]
			[Description("Aggressive Classification")]
			Aggressive_Classification,

		}

		/// <summary>
		/// <para>Reuse existing ground</para>
		/// </summary>
		public enum ReuseGroundEnum 
		{
			/// <summary>
			/// <para>Checked—Existing ground points will be accepted and reused without scrutiny and contribute to the determination of unclassified points.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REUSE_GROUND")]
			REUSE_GROUND,

			/// <summary>
			/// <para>Unchecked—Existing ground points will be reclassified. Points that are not found to be a part of the ground will be reassigned a class code value of 1, which represents unclassified points. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RECLASSIFY_GROUND")]
			RECLASSIFY_GROUND,

		}

		/// <summary>
		/// <para>Compute statistics</para>
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
		/// <para>Update pyramid</para>
		/// </summary>
		public enum UpdatePyramidEnum 
		{
			/// <summary>
			/// <para>Checked—The LAS dataset pyramid will be updated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para>Unchecked—The LAS dataset pyramid will not be updated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
