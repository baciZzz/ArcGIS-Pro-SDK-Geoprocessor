using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Generate Subset Polygons</para>
	/// <para>Generate Subset Polygons</para>
	/// <para>Generates nonoverlapping subset polygon features from a set of input points. The goal is to divide the points into compact, nonoverlapping subsets, and create polygon regions around each subset of points. The minimum and maximum number of points in each subset can be controlled.</para>
	/// </summary>
	public class GenerateSubsetPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The points that will be grouped into subsets.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>The polygons defining the region of each subset. All points within a single polygon feature are considered part of the same subset. The polygon feature class will contain a field named PointCount that will store the number of points contained in each polygon subset.</para>
		/// </param>
		public GenerateSubsetPolygons(object InPointFeatures, object OutFeatureClass)
		{
			this.InPointFeatures = InPointFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Subset Polygons</para>
		/// </summary>
		public override string DisplayName() => "Generate Subset Polygons";

		/// <summary>
		/// <para>Tool Name : GenerateSubsetPolygons</para>
		/// </summary>
		public override string ToolName() => "GenerateSubsetPolygons";

		/// <summary>
		/// <para>Tool Excute Name : ga.GenerateSubsetPolygons</para>
		/// </summary>
		public override string ExcuteName() => "ga.GenerateSubsetPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, OutFeatureClass, MinPointsPerSubset!, MaxPointsPerSubset!, CoincidentPoints! };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The points that will be grouped into subsets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>The polygons defining the region of each subset. All points within a single polygon feature are considered part of the same subset. The polygon feature class will contain a field named PointCount that will store the number of points contained in each polygon subset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum number of points per subset</para>
		/// <para>The minimum number of points that can be grouped into a subset. All subset polygons will contain at least this many points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 2147483647)]
		public object? MinPointsPerSubset { get; set; } = "20";

		/// <summary>
		/// <para>Maximum number of points per subset</para>
		/// <para>The maximum number of points that can be grouped into a subset.</para>
		/// <para>Each subset will always contain fewer than two times the Minimum number of points per subset regardless of the maximum number provided. This is because if a subset contains at least twice the minimum number of points, it will always be subdivided into two or more new subsets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 2147483647)]
		public object? MaxPointsPerSubset { get; set; }

		/// <summary>
		/// <para>Treat coincident points as a single point</para>
		/// <para>Specifies whether coincident points (points that are at the same location) are treated like a single point or as multiple individual points.</para>
		/// <para>If you intend to use the subset polygons as Subset polygon features in EBK Regression Prediction, you should maintain consistency between this parameter and the Coincident points environment in EBK Regression Prediction.</para>
		/// <para>If this parameter is unchecked, your Output feature class polygons may overlap.</para>
		/// <para>Checked—Coincident points will be treated as a single point in the subset. This is the default.</para>
		/// <para>Unchecked—Coincident points will be treated as multiple individual points in the subset.</para>
		/// <para><see cref="CoincidentPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CoincidentPoints { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSubsetPolygons SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Treat coincident points as a single point</para>
		/// </summary>
		public enum CoincidentPointsEnum 
		{
			/// <summary>
			/// <para>Checked—Coincident points will be treated as a single point in the subset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COINCIDENT_SINGLE")]
			COINCIDENT_SINGLE,

			/// <summary>
			/// <para>Unchecked—Coincident points will be treated as multiple individual points in the subset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("COINCIDENT_ALL")]
			COINCIDENT_ALL,

		}

#endregion
	}
}
