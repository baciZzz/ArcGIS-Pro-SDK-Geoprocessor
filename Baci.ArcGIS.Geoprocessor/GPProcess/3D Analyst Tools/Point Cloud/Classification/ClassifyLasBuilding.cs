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
	/// <para>Classify LAS Building</para>
	/// <para>Classifies building rooftops and sides in LAS</para>
	/// <para>data.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasBuilding : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to be classified.</para>
		/// </param>
		/// <param name="MinHeight">
		/// <para>Minimum Rooftop Height</para>
		/// <para>The height from the ground that defines the lowest point from which rooftop points will be identified.</para>
		/// </param>
		/// <param name="MinArea">
		/// <para>Minimum Area</para>
		/// <para>The smallest area of the building rooftop.</para>
		/// </param>
		public ClassifyLasBuilding(object InLasDataset, object MinHeight, object MinArea)
		{
			this.InLasDataset = InLasDataset;
			this.MinHeight = MinHeight;
			this.MinArea = MinArea;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify LAS Building</para>
		/// </summary>
		public override string DisplayName => "Classify LAS Building";

		/// <summary>
		/// <para>Tool Name : ClassifyLasBuilding</para>
		/// </summary>
		public override string ToolName => "ClassifyLasBuilding";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasBuilding</para>
		/// </summary>
		public override string ExcuteName => "3d.ClassifyLasBuilding";

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
		public override string[] ValidEnvironments => new string[] { "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, MinHeight, MinArea, ComputeStats, Extent, Boundary, ProcessEntireFiles, DerivedLasDataset, PointSpacing, ReuseBuilding, PhotogrammetricData, Method, ClassifyAboveRoof, AboveRoofHeight, AboveRoofCode, ClassifyBelowRoof, BelowRoofCode, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to be classified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Minimum Rooftop Height</para>
		/// <para>The height from the ground that defines the lowest point from which rooftop points will be identified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinHeight { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>The smallest area of the building rooftop.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPArealUnit()]
		public object MinArea { get; set; }

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
		/// <para>Processing Boundary</para>
		/// <para>A polygon feature that defines the area of interest to be processed.</para>
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
		/// <para>Derived LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>The average spacing of LAS points. This parameter is no longer used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PointSpacing { get; set; }

		/// <summary>
		/// <para>Reuse existing building classified points</para>
		/// <para>Specifies whether the existing building classified points will be reused or reevaluated.</para>
		/// <para>Unchecked—Existing building classified points will be reevaluated to fit the criteria for plane detection, and points that do not fit the specified area and height will be assigned a value of 1. This is the default.</para>
		/// <para>Checked—Existing building classified points will contribute to the plane detection process but will not be reclassified in the event they do not meet the criteria specified in the tool&apos;s execution. Use this option if the existing classification is necessary.</para>
		/// <para><see cref="ReuseBuildingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReuseBuilding { get; set; } = "false";

		/// <summary>
		/// <para>Is photogrammetric data</para>
		/// <para>Specifies whether the points in the .las file were derived using a photogrammetric technique.</para>
		/// <para>Unchecked—The points in the .las file were obtained from a lidar survey, not from a photogrammetric technique for producing point clouds. This is the default.</para>
		/// <para>Checked—The points in the .las file were obtained using a photogrammetric technique for producing point clouds from overlapping imagery.</para>
		/// <para><see cref="PhotogrammetricDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PhotogrammetricData { get; set; } = "false";

		/// <summary>
		/// <para>Classification Method</para>
		/// <para>Specifies the classification method that will be used.</para>
		/// <para>Aggressive—Points that fit the planar rooftop characteristics with a relatively high tolerance for outliers will be detected. Use this method if the points are not well calibrated.</para>
		/// <para>Standard—Points that fit the planar rooftop characteristics with a relatively moderate tolerance for irregular points will be detected. This is the default</para>
		/// <para>Conservative—Points that fit the planar rooftop characteristics with a relatively low tolerance for irregular points will be detected. Use this method if the building points are co-planar with points from objects that are not buildings.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Classify points above the roof</para>
		/// <para>Specifies whether points above the planes detected for the roof will be classified.</para>
		/// <para>Unchecked—Points detected above the planes will not be classified. This is the default.</para>
		/// <para>Checked—Points detected above the planes will be classified.</para>
		/// <para><see cref="ClassifyAboveRoofEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Above-Roof Classification")]
		public object ClassifyAboveRoof { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Height Above Roof</para>
		/// <para>The maximum height of the points above the building rooftop that will be classified to the value designated in the Above Roof Class Code parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Category("Above-Roof Classification")]
		public object AboveRoofHeight { get; set; }

		/// <summary>
		/// <para>Above Roof Class Code</para>
		/// <para>The class code that will be assigned to points above the roof.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Above-Roof Classification")]
		public object AboveRoofCode { get; set; }

		/// <summary>
		/// <para>Classify points below the roof</para>
		/// <para>Specifies whether points between the roof and the ground will be classified.</para>
		/// <para>Unchecked—Points between the roof and the ground will not be classified. This is the default.</para>
		/// <para>Checked—Points between the roof and the ground will be classified.</para>
		/// <para><see cref="ClassifyBelowRoofEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Below-Roof Classification")]
		public object ClassifyBelowRoof { get; set; } = "false";

		/// <summary>
		/// <para>Below Roof Class Code</para>
		/// <para>The class code that will be assigned to points between the ground and the roof.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Below-Roof Classification")]
		public object BelowRoofCode { get; set; }

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
		public ClassifyLasBuilding SetEnviroment(object extent = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

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
		/// <para>Reuse existing building classified points</para>
		/// </summary>
		public enum ReuseBuildingEnum 
		{
			/// <summary>
			/// <para>Checked—Existing building classified points will contribute to the plane detection process but will not be reclassified in the event they do not meet the criteria specified in the tool&apos;s execution. Use this option if the existing classification is necessary.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REUSE_BUILDING")]
			REUSE_BUILDING,

			/// <summary>
			/// <para>Unchecked—Existing building classified points will be reevaluated to fit the criteria for plane detection, and points that do not fit the specified area and height will be assigned a value of 1. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("RECLASSIFY_BUILDING")]
			RECLASSIFY_BUILDING,

		}

		/// <summary>
		/// <para>Is photogrammetric data</para>
		/// </summary>
		public enum PhotogrammetricDataEnum 
		{
			/// <summary>
			/// <para>Checked—The points in the .las file were obtained using a photogrammetric technique for producing point clouds from overlapping imagery.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PHOTOGRAMMETRIC_DATA")]
			PHOTOGRAMMETRIC_DATA,

			/// <summary>
			/// <para>Unchecked—The points in the .las file were obtained from a lidar survey, not from a photogrammetric technique for producing point clouds. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PHOTOGRAMMETRIC_DATA")]
			NOT_PHOTOGRAMMETRIC_DATA,

		}

		/// <summary>
		/// <para>Classification Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Standard—Points that fit the planar rooftop characteristics with a relatively moderate tolerance for irregular points will be detected. This is the default</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard")]
			Standard,

			/// <summary>
			/// <para>Conservative—Points that fit the planar rooftop characteristics with a relatively low tolerance for irregular points will be detected. Use this method if the building points are co-planar with points from objects that are not buildings.</para>
			/// </summary>
			[GPValue("CONSERVATIVE")]
			[Description("Conservative")]
			Conservative,

			/// <summary>
			/// <para>Aggressive—Points that fit the planar rooftop characteristics with a relatively high tolerance for outliers will be detected. Use this method if the points are not well calibrated.</para>
			/// </summary>
			[GPValue("AGGRESSIVE")]
			[Description("Aggressive")]
			Aggressive,

		}

		/// <summary>
		/// <para>Classify points above the roof</para>
		/// </summary>
		public enum ClassifyAboveRoofEnum 
		{
			/// <summary>
			/// <para>Checked—Points detected above the planes will be classified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSIFY_ABOVE_ROOF")]
			CLASSIFY_ABOVE_ROOF,

			/// <summary>
			/// <para>Unchecked—Points detected above the planes will not be classified. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLASSIFY_ABOVE_ROOF")]
			NO_CLASSIFY_ABOVE_ROOF,

		}

		/// <summary>
		/// <para>Classify points below the roof</para>
		/// </summary>
		public enum ClassifyBelowRoofEnum 
		{
			/// <summary>
			/// <para>Checked—Points between the roof and the ground will be classified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSIFY_BELOW_ROOF")]
			CLASSIFY_BELOW_ROOF,

			/// <summary>
			/// <para>Unchecked—Points between the roof and the ground will not be classified. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLASSIFY_BELOW_ROOF")]
			NO_CLASSIFY_BELOW_ROOF,

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
