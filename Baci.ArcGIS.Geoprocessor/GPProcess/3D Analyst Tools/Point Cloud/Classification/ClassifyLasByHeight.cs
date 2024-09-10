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
	/// <para>Classify LAS By Height</para>
	/// <para>Reclassifies lidar points based on their height from the ground surface.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasByHeight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset that will be processed. Only LAS points with class code values of 0 and 1 will be evaluated.</para>
		/// </param>
		/// <param name="GroundSource">
		/// <para>Ground Source</para>
		/// <para>Specifies the source of ground measurements that will be used to determine height above ground.</para>
		/// <para>All Ground Points—LAS points designated with the ground classification code value of 2 and model key code value of 8 will be used.</para>
		/// <para>Model Key Points—Only LAS points designated with the model key classification code value of 8 will be used.</para>
		/// <para><see cref="GroundSourceEnum"/></para>
		/// </param>
		/// <param name="HeightClassification">
		/// <para>Height Classification</para>
		/// <para>The class code and maximum height from ground that will be used to reclassify LAS points. The order of the classes in the table will define the range of z-values that will be used to process the reclassification. The z-range of the first entry will span from the ground surface to the specified Height From Ground value. The z-range of subsequent entries will span from the upper limit of the preceding entry to its own Height From Ground value.</para>
		/// </param>
		public ClassifyLasByHeight(object InLasDataset, object GroundSource, object HeightClassification)
		{
			this.InLasDataset = InLasDataset;
			this.GroundSource = GroundSource;
			this.HeightClassification = HeightClassification;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify LAS By Height</para>
		/// </summary>
		public override string DisplayName() => "Classify LAS By Height";

		/// <summary>
		/// <para>Tool Name : ClassifyLasByHeight</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasByHeight";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasByHeight</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasByHeight";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, GroundSource, HeightClassification, Noise, ComputeStats, Extent, ProcessEntireFiles, Boundary, OutLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset that will be processed. Only LAS points with class code values of 0 and 1 will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Ground Source</para>
		/// <para>Specifies the source of ground measurements that will be used to determine height above ground.</para>
		/// <para>All Ground Points—LAS points designated with the ground classification code value of 2 and model key code value of 8 will be used.</para>
		/// <para>Model Key Points—Only LAS points designated with the model key classification code value of 8 will be used.</para>
		/// <para><see cref="GroundSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GroundSource { get; set; } = "GROUND";

		/// <summary>
		/// <para>Height Classification</para>
		/// <para>The class code and maximum height from ground that will be used to reclassify LAS points. The order of the classes in the table will define the range of z-values that will be used to process the reclassification. The z-range of the first entry will span from the ground surface to the specified Height From Ground value. The z-range of subsequent entries will span from the upper limit of the preceding entry to its own Height From Ground value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object HeightClassification { get; set; } = "3 5;4 25;5 50";

		/// <summary>
		/// <para>Noise Classification</para>
		/// <para>Specifies whether and how points will be reclassified as noise based on their proximity from the ground. Noise artifacts in lidar data can be introduced by sensor errors and the inadvertent interception of aerial obstructions, such as birds, in the path of the lidar pulse.</para>
		/// <para>Low and High Noise—Both low and high noise will be classified.</para>
		/// <para>High Noise—Only points that are above the maximum height in the LAS classification table will be reclassified as high noise.</para>
		/// <para>Low Noise—Only points below the ground surface will be reclassified as noise. This option is only available when all ground points are used to define the ground surface.</para>
		/// <para>None—No points will be reclassified as noise.</para>
		/// <para><see cref="NoiseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Noise { get; set; } = "NONE";

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
		/// <para>Specifies how the processing extent will be applied.</para>
		/// <para>Unchecked—Only LAS points that are within the processing extent will be evaluated. This is the default.</para>
		/// <para>Checked—All points in the .las files that intersect the processing extent will be evaluated.</para>
		/// <para><see cref="ProcessEntireFilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Processing Extent")]
		public object ProcessEntireFiles { get; set; } = "false";

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>A polygon feature that defines the region for which LAS ground points will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
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
		public ClassifyLasByHeight SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ground Source</para>
		/// </summary>
		public enum GroundSourceEnum 
		{
			/// <summary>
			/// <para>All Ground Points—LAS points designated with the ground classification code value of 2 and model key code value of 8 will be used.</para>
			/// </summary>
			[GPValue("GROUND")]
			[Description("All Ground Points")]
			All_Ground_Points,

			/// <summary>
			/// <para>Model Key Points—Only LAS points designated with the model key classification code value of 8 will be used.</para>
			/// </summary>
			[GPValue("MODEL_KEY")]
			[Description("Model Key Points")]
			Model_Key_Points,

		}

		/// <summary>
		/// <para>Noise Classification</para>
		/// </summary>
		public enum NoiseEnum 
		{
			/// <summary>
			/// <para>None—No points will be reclassified as noise.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Low Noise—Only points below the ground surface will be reclassified as noise. This option is only available when all ground points are used to define the ground surface.</para>
			/// </summary>
			[GPValue("LOW_NOISE")]
			[Description("Low Noise")]
			Low_Noise,

			/// <summary>
			/// <para>High Noise—Only points that are above the maximum height in the LAS classification table will be reclassified as high noise.</para>
			/// </summary>
			[GPValue("HIGH_NOISE")]
			[Description("High Noise")]
			High_Noise,

			/// <summary>
			/// <para>Low and High Noise—Both low and high noise will be classified.</para>
			/// </summary>
			[GPValue("ALL_NOISE")]
			[Description("Low and High Noise")]
			Low_and_High_Noise,

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
			/// <para>Checked—All points in the .las files that intersect the processing extent will be evaluated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_ENTIRE_FILES")]
			PROCESS_ENTIRE_FILES,

			/// <summary>
			/// <para>Unchecked—Only LAS points that are within the processing extent will be evaluated. This is the default.</para>
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
