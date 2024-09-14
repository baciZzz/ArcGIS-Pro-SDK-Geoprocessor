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
	/// <para>Classify LAS Noise</para>
	/// <para>Classify LAS Noise</para>
	/// <para>Classifies LAS points with anomalous spatial characteristics as noise.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasNoise : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		public ClassifyLasNoise(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify LAS Noise</para>
		/// </summary>
		public override string DisplayName() => "Classify LAS Noise";

		/// <summary>
		/// <para>Tool Name : ClassifyLasNoise</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasNoise";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasNoise</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasNoise";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, Method, EditLas, Withheld, ComputeStats, Ground, LowZ, HighZ, MaxNeighbors, StepWidth, StepHeight, Extent, ProcessEntireFiles, OutFeatureClass, OutLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the noise detection method that will be used.</para>
		/// <para>Isolation—The spatial proximity of LAS points will be analyzed in tiled volumes to determine noise measurements along with height-based noise detection. This is the default.</para>
		/// <para>Relative Height from Ground—All points below the specified minimum height from the ground surface and above the maximum height from the ground surface will be identified as noise.</para>
		/// <para>Absolute Height—All points below the specified minimum height and above the maximum height in relation to mean sea level will be identified as noise.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "ISOLATION";

		/// <summary>
		/// <para>Edit Classification</para>
		/// <para>Specifies whether LAS points that are identified as noise will be reclassified.</para>
		/// <para>Checked—Noise points will be reclassified. This is the default.</para>
		/// <para>Unchecked—Noise points will not be classified.</para>
		/// <para><see cref="EditLasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EditLas { get; set; } = "true";

		/// <summary>
		/// <para>Assign Withheld Flag</para>
		/// <para>Specifies whether the withheld classification flag will be assigned to noise points. This option is only enforced if the Edit Classification parameter is checked.</para>
		/// <para>Checked—The withheld classification flag will be assigned to noise points.</para>
		/// <para>Unchecked—The withheld classification flag will not be assigned to noise points. This is the default.</para>
		/// <para><see cref="WithheldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Withheld { get; set; } = "false";

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
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Ground</para>
		/// <para>The ground surface that will be used to define relative height.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Height Detection")]
		public object Ground { get; set; }

		/// <summary>
		/// <para>Minimum Height</para>
		/// <para>The height that will define the lowest z-value threshold for identifying noise points. Any point that is lower than the specified value will be classified as noise. If a ground surface is specified, this threshold will be based on an offset from the ground such that a value of -3 feet means any points that are 3 feet below the ground surface will be classified as noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Detection")]
		public object LowZ { get; set; }

		/// <summary>
		/// <para>Maximum Height</para>
		/// <para>The height that will define the highest z-value threshold for identifying noise points. Any point that is higher than the specified value will be classified as noise. If a ground surface is provided, this threshold will be based on an offset from the ground such that a value of 250 meters means any points that are higher than 250 meters above the ground surface will be classified as noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Detection")]
		public object HighZ { get; set; }

		/// <summary>
		/// <para>Neighborhood Point Limit</para>
		/// <para>The maximum number of points in the analysis volume that can be qualified as noise when using the Isolation method. If the analysis volume contains any number of LAS points that are equal to or less than this value, those points will be classified as noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Isolation Detection")]
		public object MaxNeighbors { get; set; }

		/// <summary>
		/// <para>Neighborhood Width</para>
		/// <para>The size of each dimension in the XY space of the analysis volume when using the Isolation method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Isolation Detection")]
		public object StepWidth { get; set; }

		/// <summary>
		/// <para>Neighborhood Height</para>
		/// <para>The height of the analysis volume when using the Isolation method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Isolation Detection")]
		public object StepHeight { get; set; }

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
		/// <para>Output Noise Points</para>
		/// <para>The output point features that represent the LAS points identified as noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object OutLasDataset { get; set; }

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
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyLasNoise SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Isolation—The spatial proximity of LAS points will be analyzed in tiled volumes to determine noise measurements along with height-based noise detection. This is the default.</para>
			/// </summary>
			[GPValue("ISOLATION")]
			[Description("Isolation")]
			Isolation,

			/// <summary>
			/// <para>Relative Height from Ground—All points below the specified minimum height from the ground surface and above the maximum height from the ground surface will be identified as noise.</para>
			/// </summary>
			[GPValue("RELATIVE_HEIGHT")]
			[Description("Relative Height from Ground")]
			Relative_Height_from_Ground,

			/// <summary>
			/// <para>Absolute Height—All points below the specified minimum height and above the maximum height in relation to mean sea level will be identified as noise.</para>
			/// </summary>
			[GPValue("ABSOLUTE_HEIGHT")]
			[Description("Absolute Height")]
			Absolute_Height,

		}

		/// <summary>
		/// <para>Edit Classification</para>
		/// </summary>
		public enum EditLasEnum 
		{
			/// <summary>
			/// <para>Checked—Noise points will be reclassified. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSIFY")]
			CLASSIFY,

			/// <summary>
			/// <para>Unchecked—Noise points will not be classified.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLASSIFY")]
			NO_CLASSIFY,

		}

		/// <summary>
		/// <para>Assign Withheld Flag</para>
		/// </summary>
		public enum WithheldEnum 
		{
			/// <summary>
			/// <para>Checked—The withheld classification flag will be assigned to noise points.</para>
			/// </summary>
			[GPValue("true")]
			[Description("WITHHELD")]
			WITHHELD,

			/// <summary>
			/// <para>Unchecked—The withheld classification flag will not be assigned to noise points. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_WITHHELD")]
			NO_WITHHELD,

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
