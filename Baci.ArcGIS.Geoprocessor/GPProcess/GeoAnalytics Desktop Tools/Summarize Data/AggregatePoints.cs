using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Aggregate Points</para>
	/// <para>Aggregate Points</para>
	/// <para>Aggregates points into polygon features or bins. A polygon is returned with a count of points as well as optional statistics at all locations where points exist.</para>
	/// </summary>
	public class AggregatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>The point features to be aggregated into polygons or bins.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with the aggregated polygon results.</para>
		/// </param>
		/// <param name="PolygonOrBin">
		/// <para>Polygon or Bin</para>
		/// <para>Specifies how the Point Layer will be aggregated.</para>
		/// <para>Polygon—The point layer will be aggregated into a polygon dataset.</para>
		/// <para>Bin—The point layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </param>
		public AggregatePoints(object PointLayer, object OutFeatureClass, object PolygonOrBin)
		{
			this.PointLayer = PointLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.PolygonOrBin = PolygonOrBin;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate Points</para>
		/// </summary>
		public override string DisplayName() => "Aggregate Points";

		/// <summary>
		/// <para>Tool Name : AggregatePoints</para>
		/// </summary>
		public override string ToolName() => "AggregatePoints";

		/// <summary>
		/// <para>Tool Excute Name : gapro.AggregatePoints</para>
		/// </summary>
		public override string ExcuteName() => "gapro.AggregatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { PointLayer, OutFeatureClass, PolygonOrBin, PolygonLayer!, BinType!, BinSize!, TimeStepInterval!, TimeStepRepeat!, TimeStepReference!, SummaryFields! };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>The point features to be aggregated into polygons or bins.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with the aggregated polygon results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// <para>Specifies how the Point Layer will be aggregated.</para>
		/// <para>Polygon—The point layer will be aggregated into a polygon dataset.</para>
		/// <para>Bin—The point layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PolygonOrBin { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Polygon Layer</para>
		/// <para>The polygon features into which the input points will be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? PolygonLayer { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>Specifies the bin shape that will be generated to hold the aggregated points.</para>
		/// <para>Square—Square bins will be generated, in which Bin Size represents the height of a square. This is the default.</para>
		/// <para>Hexagon—Hexagonal bins will be generated, in which Bin Size represents the height between two parallel sides.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; }

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>The distance interval that represents the bin size and units into which the Point Layer will be aggregated. The distance interval must be a linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? BinSize { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>A value that specifies the duration of the time step. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// <para>Time stepping can only be applied if time is enabled on the input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// <para>A value that specifies how often the time-step interval occurs. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>A date that specifies the reference time with which to align the time steps. The default is January 1, 1970, at 12:00 a.m. This parameter is only available if the input points are time enabled and represent an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeStepReference { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePoints SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// </summary>
		public enum PolygonOrBinEnum 
		{
			/// <summary>
			/// <para>Polygon or Bin</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Bin—The point layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
			/// </summary>
			[GPValue("BIN")]
			[Description("Bin")]
			Bin,

		}

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>Square—Square bins will be generated, in which Bin Size represents the height of a square. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Hexagon—Hexagonal bins will be generated, in which Bin Size represents the height between two parallel sides.</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

		}

#endregion
	}
}
