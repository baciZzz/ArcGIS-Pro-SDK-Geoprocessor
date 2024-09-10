using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Sample</para>
	/// <para>Creates a table or a point feature class that shows the values of cells from a raster, or a set of rasters, for defined locations. The locations are defined by raster cells, points, polylines, or polygons.</para>
	/// </summary>
	public class Sample : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>The rasters with values that will be sampled based on the input location data.</para>
		/// <para>The Process as multidimensional parameter is only available when the input is a single, multidimensional raster.</para>
		/// </param>
		/// <param name="InLocationData">
		/// <para>Input location raster or features</para>
		/// <para>The data identifying positions where a sample will be taken.</para>
		/// <para>The input can be a raster or a feature class.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table or feature class</para>
		/// <para>The output table or feature class containing the sampled cell values.</para>
		/// <para>The output format is determined by the output location and path. By default, the output will be a geodatabase table or a geodatabase feature class in a geodatabase workspace or a dBASE table or a shapefile feature class in a folder workspace.</para>
		/// <para>The output data type to generate a table or a feature class is controlled by the Generate feature class parameter.</para>
		/// </param>
		public Sample(object InRasters, object InLocationData, object OutTable)
		{
			this.InRasters = InRasters;
			this.InLocationData = InLocationData;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Sample</para>
		/// </summary>
		public override string DisplayName() => "Sample";

		/// <summary>
		/// <para>Tool Name : Sample</para>
		/// </summary>
		public override string ToolName() => "Sample";

		/// <summary>
		/// <para>Tool Excute Name : ia.Sample</para>
		/// </summary>
		public override string ExcuteName() => "ia.Sample";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, InLocationData, OutTable, ResamplingType, UniqueIdField, ProcessAsMultidimensional, AcquisitionDefinition, StatisticsType, PercentileValue, BufferDistance, Layout, GenerateFeatureClass };

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>The rasters with values that will be sampled based on the input location data.</para>
		/// <para>The Process as multidimensional parameter is only available when the input is a single, multidimensional raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Input location raster or features</para>
		/// <para>The data identifying positions where a sample will be taken.</para>
		/// <para>The input can be a raster or a feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DEMosaicDataset", "GPMosaicLayer", "DEImageServer")]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		[GeometryType("Point")]
		public object InLocationData { get; set; }

		/// <summary>
		/// <para>Output table or feature class</para>
		/// <para>The output table or feature class containing the sampled cell values.</para>
		/// <para>The output format is determined by the output location and path. By default, the output will be a geodatabase table or a geodatabase feature class in a geodatabase workspace or a dBASE table or a shapefile feature class in a folder workspace.</para>
		/// <para>The output data type to generate a table or a feature class is controlled by the Generate feature class parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Resampling technique</para>
		/// <para>The resampling algorithm that will be used to sample a raster to determine how the values will be obtained from the raster.</para>
		/// <para>Nearest—Nearest neighbor assignment will be used. This is the default.</para>
		/// <para>Bilinear—Bilinear interpolation will be used.</para>
		/// <para>Cubic—Cubic convolution will be used.</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Unique ID field</para>
		/// <para>A field containing a different value for every location or feature in the input location raster or features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "OID")]
		public object UniqueIdField { get; set; }

		/// <summary>
		/// <para>Process as multidimensional</para>
		/// <para>Specifies how the input rasters will be processed.</para>
		/// <para>This parameter is only available when the input is a single, multidimensional raster.</para>
		/// <para>Unchecked—Samples will be processed from the current slice of a multidimensional dataset. This is the default.</para>
		/// <para>Checked—Samples will be processed for all dimensions (such as time or depth) of a multidimensional dataset.</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Acquisition information of location data</para>
		/// <para>Specifies the time, depth, or other acquisition data associated with the location features.</para>
		/// <para>Only the following combinations are supported:</para>
		/// <para>Dimension + Start field or value</para>
		/// <para>Dimension + Start field or value + End field or value</para>
		/// <para>Dimension + Start field or value + Relative value or days before + Relative value or days after</para>
		/// <para>Relative value or days before and Relative value or days after only support nonnegative values.</para>
		/// <para>Statistics will be calculated using the Statistics type parameter for variables within this dimension range.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object AcquisitionDefinition { get; set; }

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>Specifies the statistic type to be calculated.</para>
		/// <para>Minimum—The minimum value within the specified range will be calculated.</para>
		/// <para>Maximum—The maximum value within the specified range will be calculated.</para>
		/// <para>Median—The median value within the specified range will be calculated.</para>
		/// <para>Mean—The average for the specified range will be calculated.</para>
		/// <para>Sum—The total value of the variables within the specified range will be calculated.</para>
		/// <para>Majority—The value that occurs most frequently will be calculated.</para>
		/// <para>Minority—The value that occurs least frequently will be calculated.</para>
		/// <para>Standard deviation—The standard deviation will be calculated.</para>
		/// <para>Percentile—A defined percentile within the specified range will be calculated.</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; }

		/// <summary>
		/// <para>Percentile value</para>
		/// <para>This value can range from 0 to 100. The default is 90.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100)]
		public object PercentileValue { get; set; }

		/// <summary>
		/// <para>Buffer distance field or value</para>
		/// <para>The distance around the location data features. The buffer distance is specified in the linear unit of the location feature&apos;s spatial reference. If the feature uses a geographic reference, the unit will be degrees.</para>
		/// <para>Statistics will be calculated within this buffer area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistance { get; set; }

		/// <summary>
		/// <para>Column-wise layout</para>
		/// <para>Specifies whether sampled values will appear in rows or columns in the output table.</para>
		/// <para>Unchecked—Sampled values will appear in separate rows in the output table. This is the default.</para>
		/// <para>Checked—Sampled values will appear in separate columns in the output table. This option is only valid when the input multidimensional raster contains one variable and one dimension, and each slice is a single-band raster.</para>
		/// <para><see cref="LayoutEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Layout { get; set; } = "false";

		/// <summary>
		/// <para>Generate feature class</para>
		/// <para>Specifies whether a point feature class with sampled values in its attribute table or a table with sampled values will be generated.</para>
		/// <para>Unchecked—A table with sampled values will be generated. This is the default.</para>
		/// <para>Checked—A point feature class with sampled values in its attribute table will be generated.</para>
		/// <para><see cref="GenerateFeatureClassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateFeatureClass { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Sample SetEnviroment(int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Resampling technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>Nearest—Nearest neighbor assignment will be used. This is the default.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Bilinear—Bilinear interpolation will be used.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic—Cubic convolution will be used.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

		}

		/// <summary>
		/// <para>Process as multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para>Unchecked—Samples will be processed from the current slice of a multidimensional dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

			/// <summary>
			/// <para>Checked—Samples will be processed for all dimensions (such as time or depth) of a multidimensional dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

		}

		/// <summary>
		/// <para>Statistics type</para>
		/// </summary>
		public enum StatisticsTypeEnum 
		{
			/// <summary>
			/// <para>Minimum—The minimum value within the specified range will be calculated.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The maximum value within the specified range will be calculated.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Median—The median value within the specified range will be calculated.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Mean—The average for the specified range will be calculated.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Sum—The total value of the variables within the specified range will be calculated.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

			/// <summary>
			/// <para>Majority—The value that occurs most frequently will be calculated.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

			/// <summary>
			/// <para>Minority—The value that occurs least frequently will be calculated.</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("Minority")]
			Minority,

			/// <summary>
			/// <para>Standard deviation—The standard deviation will be calculated.</para>
			/// </summary>
			[GPValue("STD")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Percentile—A defined percentile within the specified range will be calculated.</para>
			/// </summary>
			[GPValue("PERCENTILE")]
			[Description("Percentile")]
			Percentile,

		}

		/// <summary>
		/// <para>Column-wise layout</para>
		/// </summary>
		public enum LayoutEnum 
		{
			/// <summary>
			/// <para>Unchecked—Sampled values will appear in separate rows in the output table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ROW_WISE")]
			ROW_WISE,

			/// <summary>
			/// <para>Checked—Sampled values will appear in separate columns in the output table. This option is only valid when the input multidimensional raster contains one variable and one dimension, and each slice is a single-band raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COLUMN_WISE")]
			COLUMN_WISE,

		}

		/// <summary>
		/// <para>Generate feature class</para>
		/// </summary>
		public enum GenerateFeatureClassEnum 
		{
			/// <summary>
			/// <para>Unchecked—A table with sampled values will be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("TABLE")]
			TABLE,

			/// <summary>
			/// <para>Checked—A point feature class with sampled values in its attribute table will be generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FEATURE_CLASS")]
			FEATURE_CLASS,

		}

#endregion
	}
}
