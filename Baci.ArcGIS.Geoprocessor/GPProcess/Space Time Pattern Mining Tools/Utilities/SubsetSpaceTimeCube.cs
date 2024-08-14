using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Subset Space Time Cube</para>
	/// <para>Subsets a space-time cube by space or time.</para>
	/// </summary>
	public class SubsetSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The space-time cube to be subset. Space-time cubes have an .nc file extension and are created using various tools in the Space Time Pattern Mining toolbox.</para>
		/// </param>
		/// <param name="OutCube">
		/// <para>Output Space Time Cube</para>
		/// <para>The subset of the input space-time cube that meets the spatial and temporal criteria specified by the Spatial Subset Method and Temporal Subset Method parameters. The analysis variables stored in the input space-time cube will be excluded from the output space-time cube.</para>
		/// </param>
		/// <param name="SpatialSubsetMethod">
		/// <para>Spatial Subset Method</para>
		/// <para>Specifies the method that will be used to spatially subset the input space-time cube. Any location in the input space-time cube that satisfies this spatial subset criteria will be included in the output space-time cube.</para>
		/// <para>Features—A feature class with polygons, points, or lines will be used to subset the input space-time cube. The Spatial Relationship parameter specifies how the feature layer will subset the space-time cube.</para>
		/// <para>Extent—The extent specified by the Extent parameter will be used to subset the input space-time cube. The output space-time cube will include all the locations in the input space-time cube that intersect the extent.</para>
		/// <para>Space Time Cube—The location of the space-time cube specified by the Input Spatial Subset Cube parameter will be used to subset a space-time cube. The Spatial Relationship parameter specifies how this space-time cube will subset the input space-time cube.</para>
		/// <para>None—A spatial subset will not be applied to the input space-time cube.</para>
		/// <para><see cref="SpatialSubsetMethodEnum"/></para>
		/// </param>
		/// <param name="TemporalSubsetMethod">
		/// <para>Temporal Subset Method</para>
		/// <para>Specifies the method that will be used to temporally subset a space-time cube. Any time step in the input space-time cube that satisfies the temporal subset criteria will be included in the output space-time cube.</para>
		/// <para>User defined—The temporal range specified by the Start Time or End Time values in the Time Span of Subset parameter will be used to temporally subset the input space-time cube.</para>
		/// <para>Number of time steps—A number of time steps from the start and the end of the input space-time cube will be used to temporally subset the space-time cube. The number of time steps to remove is specified by the From the Start or From the End values in the Number of Time Steps to Remove parameter.</para>
		/// <para>Space time cube—The temporal extent of the space-time cube specified by the Input Temporal Subset Cube parameter will be used to temporally subset the input space-time cube.</para>
		/// <para>None—A temporal subset will not be applied to the input space-time cube.</para>
		/// <para><see cref="TemporalSubsetMethodEnum"/></para>
		/// </param>
		public SubsetSpaceTimeCube(object InCube, object OutCube, object SpatialSubsetMethod, object TemporalSubsetMethod)
		{
			this.InCube = InCube;
			this.OutCube = OutCube;
			this.SpatialSubsetMethod = SpatialSubsetMethod;
			this.TemporalSubsetMethod = TemporalSubsetMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Subset Space Time Cube</para>
		/// </summary>
		public override string DisplayName => "Subset Space Time Cube";

		/// <summary>
		/// <para>Tool Name : SubsetSpaceTimeCube</para>
		/// </summary>
		public override string ToolName => "SubsetSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : stpm.SubsetSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName => "stpm.SubsetSpaceTimeCube";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InCube, OutCube, SpatialSubsetMethod, TemporalSubsetMethod, InSubsetFeatures!, SpatialRelationship!, SpatialExtent!, InSpatialCube!, TimeSpanSubset!, RemoveTimeSteps!, InTemporalCube };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The space-time cube to be subset. Space-time cubes have an .nc file extension and are created using various tools in the Space Time Pattern Mining toolbox.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>The subset of the input space-time cube that meets the spatial and temporal criteria specified by the Spatial Subset Method and Temporal Subset Method parameters. The analysis variables stored in the input space-time cube will be excluded from the output space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutCube { get; set; }

		/// <summary>
		/// <para>Spatial Subset Method</para>
		/// <para>Specifies the method that will be used to spatially subset the input space-time cube. Any location in the input space-time cube that satisfies this spatial subset criteria will be included in the output space-time cube.</para>
		/// <para>Features—A feature class with polygons, points, or lines will be used to subset the input space-time cube. The Spatial Relationship parameter specifies how the feature layer will subset the space-time cube.</para>
		/// <para>Extent—The extent specified by the Extent parameter will be used to subset the input space-time cube. The output space-time cube will include all the locations in the input space-time cube that intersect the extent.</para>
		/// <para>Space Time Cube—The location of the space-time cube specified by the Input Spatial Subset Cube parameter will be used to subset a space-time cube. The Spatial Relationship parameter specifies how this space-time cube will subset the input space-time cube.</para>
		/// <para>None—A spatial subset will not be applied to the input space-time cube.</para>
		/// <para><see cref="SpatialSubsetMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialSubsetMethod { get; set; }

		/// <summary>
		/// <para>Temporal Subset Method</para>
		/// <para>Specifies the method that will be used to temporally subset a space-time cube. Any time step in the input space-time cube that satisfies the temporal subset criteria will be included in the output space-time cube.</para>
		/// <para>User defined—The temporal range specified by the Start Time or End Time values in the Time Span of Subset parameter will be used to temporally subset the input space-time cube.</para>
		/// <para>Number of time steps—A number of time steps from the start and the end of the input space-time cube will be used to temporally subset the space-time cube. The number of time steps to remove is specified by the From the Start or From the End values in the Number of Time Steps to Remove parameter.</para>
		/// <para>Space time cube—The temporal extent of the space-time cube specified by the Input Temporal Subset Cube parameter will be used to temporally subset the input space-time cube.</para>
		/// <para>None—A temporal subset will not be applied to the input space-time cube.</para>
		/// <para><see cref="TemporalSubsetMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TemporalSubsetMethod { get; set; }

		/// <summary>
		/// <para>Input Subset Features</para>
		/// <para>A feature class that contains polygons, points, or lines to subset a space-time cube. The spatial relationship between the input subset features and the space-time cube is specified by the Spatial Relationship parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InSubsetFeatures { get; set; }

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>Specifies the spatial relationship that will be applied between the Input Subset Features or Input Spatial Subset Cube parameter value and the input space-time cube to spatially subset the space-time cube. The available spatial relationship options will depend on the geometry of the input space-time cube and the input subset features or the input spatial subset cube.</para>
		/// <para>Intersect—The output space-time cube will include the locations in the input space-time cube that intersect the Input Subset Features or Input Spatial Subset Cube parameter value. This is the default.</para>
		/// <para>Contains—The output space-time cube will include the locations in the input space-time cube that contain the Input Subset Features or Input Spatial Subset Cube parameter value.</para>
		/// <para>Within—The output space-time cube will include the locations in the input space-time cube that are within the Input Subset Features or Input Spatial Subset Cube parameter value.</para>
		/// <para>Have their center in—The output space-time cube will include the locations in the input space-time cube that have their center in the Input Subset Features or Input Spatial Subset Cube parameter value.</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialRelationship { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Extent</para>
		/// <para>The spatial extent that will spatially subset the input space-time cube. The output space-time cube will include the locations in the input space-time cube that intersect the extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? SpatialExtent { get; set; }

		/// <summary>
		/// <para>Input Spatial Subset Cube</para>
		/// <para>A space-time cube that will spatially subset the input space-time cube. The spatial relationship between the input spatial subset cube and the space-time cube is specified by the Spatial Relationship parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InSpatialCube { get; set; }

		/// <summary>
		/// <para>Time Span of Subset</para>
		/// <para>The time interval to temporally subset the input space-time cube. Any time step that is within this time interval or that contains the Start time or End time column values will be included in the output space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? TimeSpanSubset { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Remove</para>
		/// <para>The number of time steps from the start and the end of the input space-time cube that will be removed from the output space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? RemoveTimeSteps { get; set; }

		/// <summary>
		/// <para>Input Temporal Subset Cube</para>
		/// <para>A space-time cube that will temporally subset the input space-time cube. The temporal extent of the temporal subset cube defines the temporal extent of the output space-time cube. Any time step that is within the temporal extent of the input temporal subset cube or that contains the start time or end time of the temporal subset cube will be included in the output space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InTemporalCube { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubsetSpaceTimeCube SetEnviroment(object? outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Subset Method</para>
		/// </summary>
		public enum SpatialSubsetMethodEnum 
		{
			/// <summary>
			/// <para>Features—A feature class with polygons, points, or lines will be used to subset the input space-time cube. The Spatial Relationship parameter specifies how the feature layer will subset the space-time cube.</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("Features")]
			Features,

			/// <summary>
			/// <para>Extent—The extent specified by the Extent parameter will be used to subset the input space-time cube. The output space-time cube will include all the locations in the input space-time cube that intersect the extent.</para>
			/// </summary>
			[GPValue("EXTENT")]
			[Description("Extent")]
			Extent,

			/// <summary>
			/// <para>Space Time Cube—The location of the space-time cube specified by the Input Spatial Subset Cube parameter will be used to subset a space-time cube. The Spatial Relationship parameter specifies how this space-time cube will subset the input space-time cube.</para>
			/// </summary>
			[GPValue("SPACE_TIME_CUBE")]
			[Description("Space Time Cube")]
			Space_Time_Cube,

			/// <summary>
			/// <para>None—A spatial subset will not be applied to the input space-time cube.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Temporal Subset Method</para>
		/// </summary>
		public enum TemporalSubsetMethodEnum 
		{
			/// <summary>
			/// <para>User defined—The temporal range specified by the Start Time or End Time values in the Time Span of Subset parameter will be used to temporally subset the input space-time cube.</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("User defined")]
			User_defined,

			/// <summary>
			/// <para>Number of time steps—A number of time steps from the start and the end of the input space-time cube will be used to temporally subset the space-time cube. The number of time steps to remove is specified by the From the Start or From the End values in the Number of Time Steps to Remove parameter.</para>
			/// </summary>
			[GPValue("NUMBER_OF_TIME_STEPS")]
			[Description("Number of time steps")]
			Number_of_time_steps,

			/// <summary>
			/// <para>Space time cube—The temporal extent of the space-time cube specified by the Input Temporal Subset Cube parameter will be used to temporally subset the input space-time cube.</para>
			/// </summary>
			[GPValue("SPACE_TIME_CUBE")]
			[Description("Space time cube")]
			Space_time_cube,

			/// <summary>
			/// <para>None—A temporal subset will not be applied to the input space-time cube.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>Intersect—The output space-time cube will include the locations in the input space-time cube that intersect the Input Subset Features or Input Spatial Subset Cube parameter value. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Contains—The output space-time cube will include the locations in the input space-time cube that contain the Input Subset Features or Input Spatial Subset Cube parameter value.</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("Contains")]
			Contains,

			/// <summary>
			/// <para>Within—The output space-time cube will include the locations in the input space-time cube that are within the Input Subset Features or Input Spatial Subset Cube parameter value.</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("Within")]
			Within,

			/// <summary>
			/// <para>Have their center in—The output space-time cube will include the locations in the input space-time cube that have their center in the Input Subset Features or Input Spatial Subset Cube parameter value.</para>
			/// </summary>
			[GPValue("HAVE_THEIR_CENTER_IN")]
			[Description("Have their center in")]
			Have_their_center_in,

		}

#endregion
	}
}
