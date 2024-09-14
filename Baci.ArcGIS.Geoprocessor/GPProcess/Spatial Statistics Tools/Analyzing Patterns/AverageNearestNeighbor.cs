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
	/// <para>Average Nearest Neighbor</para>
	/// <para>Average Nearest Neighbor</para>
	/// <para>Calculates a nearest neighbor index based on the average distance from each feature to its nearest neighboring feature.</para>
	/// </summary>
	public class AverageNearestNeighbor : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class, typically a point feature class, for which the average nearest neighbor distance will be calculated.</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		public AverageNearestNeighbor(object InputFeatureClass, object DistanceMethod)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.DistanceMethod = DistanceMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Average Nearest Neighbor</para>
		/// </summary>
		public override string DisplayName() => "Average Nearest Neighbor";

		/// <summary>
		/// <para>Tool Name : AverageNearestNeighbor</para>
		/// </summary>
		public override string ToolName() => "AverageNearestNeighbor";

		/// <summary>
		/// <para>Tool Excute Name : stats.AverageNearestNeighbor</para>
		/// </summary>
		public override string ExcuteName() => "stats.AverageNearestNeighbor";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, DistanceMethod, GenerateReport, Area, Nnratio, Nnzscore, Pvalue, Nnexpected, Nnobserved, ReportFile };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class, typically a point feature class, for which the average nearest neighbor distance will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

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
		/// <para>Generate Report</para>
		/// <para>Specifies whether the tool will create a graphical summary of results.</para>
		/// <para>Checked—A graphical summary will be created as an HTML file.</para>
		/// <para>Unchecked—No graphical summary will be created. This is the default.</para>
		/// <para><see cref="GenerateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateReport { get; set; } = "false";

		/// <summary>
		/// <para>Area</para>
		/// <para>A numeric value representing the study area size. The default value is the area of the minimum enclosing rectangle that would encompass all features (or all selected features). Units should match those for the Output Coordinate System.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999999999)]
		public object Area { get; set; }

		/// <summary>
		/// <para>Nearest Neighbor Index</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnratio { get; set; } = "0";

		/// <summary>
		/// <para>z-score</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnzscore { get; set; } = "0";

		/// <summary>
		/// <para>p-value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Pvalue { get; set; } = "0";

		/// <summary>
		/// <para>Expected Mean Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnexpected { get; set; } = "0";

		/// <summary>
		/// <para>Observed Mean Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object Nnobserved { get; set; } = "0";

		/// <summary>
		/// <para>Report File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object ReportFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AverageNearestNeighbor SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
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

		/// <summary>
		/// <para>Generate Report</para>
		/// </summary>
		public enum GenerateReportEnum 
		{
			/// <summary>
			/// <para>Checked—A graphical summary will be created as an HTML file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_REPORT")]
			GENERATE_REPORT,

			/// <summary>
			/// <para>Unchecked—No graphical summary will be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REPORT")]
			NO_REPORT,

		}

#endregion
	}
}
