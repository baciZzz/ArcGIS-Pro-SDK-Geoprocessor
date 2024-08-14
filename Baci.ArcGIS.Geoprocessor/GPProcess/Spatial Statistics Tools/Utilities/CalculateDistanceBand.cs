using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Calculate Distance Band from Neighbor Count</para>
	/// <para>Returns the minimum, the maximum, and the average distance to the specified Nth nearest neighbor (N is an input parameter) for a set of features.  Results are written as tool execution messages.</para>
	/// </summary>
	public class CalculateDistanceBand : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or layer used to calculate distance statistics.</para>
		/// </param>
		/// <param name="Neighbors">
		/// <para>Neighbors</para>
		/// <para>The number of neighbors (N) to consider for each feature. This number should be any integer between one and the total number of features in the feature class. A list of distances between each feature and its Nth neighbor is compiled, and the maximum, minimum, and average distances are output to the Results window.</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		public CalculateDistanceBand(object InputFeatures, object Neighbors, object DistanceMethod)
		{
			this.InputFeatures = InputFeatures;
			this.Neighbors = Neighbors;
			this.DistanceMethod = DistanceMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Distance Band from Neighbor Count</para>
		/// </summary>
		public override string DisplayName => "Calculate Distance Band from Neighbor Count";

		/// <summary>
		/// <para>Tool Name : CalculateDistanceBand</para>
		/// </summary>
		public override string ToolName => "CalculateDistanceBand";

		/// <summary>
		/// <para>Tool Excute Name : stats.CalculateDistanceBand</para>
		/// </summary>
		public override string ExcuteName => "stats.CalculateDistanceBand";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, Neighbors, DistanceMethod, MinimumDistance, AverageDistance, MaximumDistance };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or layer used to calculate distance statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Neighbors</para>
		/// <para>The number of neighbors (N) to consider for each feature. This number should be any integer between one and the total number of features in the feature class. A list of distances between each feature and its Nth neighbor is compiled, and the maximum, minimum, and average distances are output to the Results window.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain()]
		public object Neighbors { get; set; } = "1";

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Minimum Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MinimumDistance { get; set; }

		/// <summary>
		/// <para>Average Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object AverageDistance { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDistanceBand SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
			/// </summary>
			[GPValue("EUCLIDEAN_DISTANCE")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
			/// </summary>
			[GPValue("MANHATTAN_DISTANCE")]
			[Description("Manhattan")]
			Manhattan,

		}

#endregion
	}
}
