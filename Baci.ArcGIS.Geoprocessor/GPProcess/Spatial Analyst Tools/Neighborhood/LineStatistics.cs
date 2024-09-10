using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Line Statistics</para>
	/// <para>Calculates a statistic on the attributes of lines in a circular neighborhood around each output cell.</para>
	/// </summary>
	public class LineStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolylineFeatures">
		/// <para>Input polyline features</para>
		/// <para>The input polyline features for which to calculate the statistics in a neighbourhood around each output cell.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>The field that the specified statistic will be calculated for. It can be any numeric field of the input features.</para>
		/// <para>When the statistics type is set to Length, the Field parameter can be set to None.</para>
		/// <para>It can be the Shape field if the input features contain z-values.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output line statistics raster.</para>
		/// </param>
		public LineStatistics(object InPolylineFeatures, object Field, object OutRaster)
		{
			this.InPolylineFeatures = InPolylineFeatures;
			this.Field = Field;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Line Statistics</para>
		/// </summary>
		public override string DisplayName() => "Line Statistics";

		/// <summary>
		/// <para>Tool Name : LineStatistics</para>
		/// </summary>
		public override string ToolName() => "LineStatistics";

		/// <summary>
		/// <para>Tool Excute Name : sa.LineStatistics</para>
		/// </summary>
		public override string ExcuteName() => "sa.LineStatistics";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolylineFeatures, Field, OutRaster, CellSize, SearchRadius, StatisticsType };

		/// <summary>
		/// <para>Input polyline features</para>
		/// <para>The input polyline features for which to calculate the statistics in a neighbourhood around each output cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Polyline")]
		public object InPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>The field that the specified statistic will be calculated for. It can be any numeric field of the input features.</para>
		/// <para>When the statistics type is set to Length, the Field parameter can be set to None.</para>
		/// <para>It can be the Shape field if the input features contain z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output line statistics raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Search radius</para>
		/// <para>Search radius to calculate the desired statistic within, in map units.</para>
		/// <para>The default radius is five times the output cell size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>Statistics are calculated on the value of the specified field for all lines within the neighborhood.</para>
		/// <para>Mean—Calculates the average field value in each neighborhood, weighted by the length.The form of the calculation is:Only the part of the length that falls within the neighborhood is used.</para>
		/// <para>Mean = (sum of (length * field_value)) / (sum_of_length)</para>
		/// <para>Majority—Determines the value having the greatest length of line in the neighborhood.</para>
		/// <para>Maximum—Determines the largest value in the neighborhood.</para>
		/// <para>Median—Determines the median value, weighted by the length.Conceptually, all line segments in the neighborhood are sorted by value and placed end-to-end in a straight line. The value of the segment at the midpoint of the straight line is the median.</para>
		/// <para>Minimum—Calculates smallest value in each neighborhood.</para>
		/// <para>Minority—The value having the least length of line in the neighborhood.</para>
		/// <para>Range—The range of values (maximum–minimum).</para>
		/// <para>Variety—The number of unique values.</para>
		/// <para>Length—The total line length in the neighborhood. If the value of the field is other than 1, the lengths are multiplied by the item value before adding them together. This option can be used when the field parameter is set to None.</para>
		/// <para>When the specified field is integer, the available statistic choices are Mean, Majority, Maximum, Median, Minimum, Minority, Range, and Variety. When the field is floating point, the only allowed statistics are Mean, Maximum, Minimum, and Range.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LineStatistics SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Mean—Calculates the average field value in each neighborhood, weighted by the length.The form of the calculation is:Only the part of the length that falls within the neighborhood is used.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Majority—Determines the value having the greatest length of line in the neighborhood.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

			/// <summary>
			/// <para>Maximum—Determines the largest value in the neighborhood.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Median—Determines the median value, weighted by the length.Conceptually, all line segments in the neighborhood are sorted by value and placed end-to-end in a straight line. The value of the segment at the midpoint of the straight line is the median.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Minimum—Calculates smallest value in each neighborhood.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Minority—The value having the least length of line in the neighborhood.</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("Minority")]
			Minority,

			/// <summary>
			/// <para>Range—The range of values (maximum–minimum).</para>
			/// </summary>
			[GPValue("RANGE")]
			[Description("Range")]
			Range,

			/// <summary>
			/// <para>Variety—The number of unique values.</para>
			/// </summary>
			[GPValue("VARIETY")]
			[Description("Variety")]
			Variety,

			/// <summary>
			/// <para>Length—The total line length in the neighborhood. If the value of the field is other than 1, the lengths are multiplied by the item value before adding them together. This option can be used when the field parameter is set to None.</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("Length")]
			Length,

		}

#endregion
	}
}
