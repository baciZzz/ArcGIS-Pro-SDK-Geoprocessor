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
	/// <para>LAS Height Metrics</para>
	/// <para>LAS Height Metrics</para>
	/// <para>Calculates statistics about the distribution of elevation measurements of vegetation points captured in LAS data.</para>
	/// </summary>
	public class LasHeightMetrics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase where the output raster datasets will reside. When the output location is a folder, the resulting raster datasets will be in the TIFF format.</para>
		/// </param>
		public LasHeightMetrics(object InLasDataset, object OutLocation)
		{
			this.InLasDataset = InLasDataset;
			this.OutLocation = OutLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Height Metrics</para>
		/// </summary>
		public override string DisplayName() => "LAS Height Metrics";

		/// <summary>
		/// <para>Tool Name : LasHeightMetrics</para>
		/// </summary>
		public override string ToolName() => "LasHeightMetrics";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasHeightMetrics</para>
		/// </summary>
		public override string ExcuteName() => "3d.LasHeightMetrics";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutLocation, BaseName!, Statistics!, HeightPercentiles!, MinHeight!, MinPoints!, CellSize!, DerivedOutLocation!, OutputRasters!, RasterFormat! };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase where the output raster datasets will reside. When the output location is a folder, the resulting raster datasets will be in the TIFF format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>The base name for the output raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BaseName { get; set; } = "height_";

		/// <summary>
		/// <para>Statistics Options</para>
		/// <para>Specifies the statistics calculated for the unclassified and vegetation points above the ground that are within the area of each cell in the output raster.</para>
		/// <para>Mean—The average height of the LAS points.</para>
		/// <para>Kurtosis—The sharpness of the change in the height of the LAS points.</para>
		/// <para>Skewness—The direction of deviation from the nominal height of the LAS points, which indicates the level and direction of asymmetry.</para>
		/// <para>Standard Deviation—The variation of the height of the points.</para>
		/// <para>Median Absolute Deviation—The median value of the deviation from the median height.</para>
		/// <para><see cref="StatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Statistics { get; set; }

		/// <summary>
		/// <para>Height Percentiles</para>
		/// <para>The height at which the specified percentage of points in the cell fall below. For example, a value of 95 means the resulting cell values indicate the height at which 95 percent of points above the ground occur.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? HeightPercentiles { get; set; }

		/// <summary>
		/// <para>Minimum Height</para>
		/// <para>The minimum height above ground for points that will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object? MinHeight { get; set; } = "2 Meters";

		/// <summary>
		/// <para>Minimum Number of Points</para>
		/// <para>The minimum number of points that must be present in a given cell to calculate height metrics. Cells with fewer points than the specified minimum will have no data in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? MinPoints { get; set; } = "4";

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The cell size of the output raster datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object? CellSize { get; set; } = "20 Meters";

		/// <summary>
		/// <para>Output Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? DerivedOutLocation { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutputRasters { get; set; }

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>Specifies the raster format that will be created when the output location is a folder.</para>
		/// <para>GeoTiff—Output will be created in the GeoTIFF format. This is the default.</para>
		/// <para>Erdas Imagine (IMG)—Output will be created in the ERDAS IMAGINE format.</para>
		/// <para>Esri Grid—Output will be created in the Esri Grid format.</para>
		/// <para><see cref="RasterFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RasterFormat { get; set; } = "TIFF";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasHeightMetrics SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Statistics Options</para>
		/// </summary>
		public enum StatisticsEnum 
		{
			/// <summary>
			/// <para>Mean—The average height of the LAS points.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Standard Deviation—The variation of the height of the points.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard Deviation")]
			Standard_Deviation,

			/// <summary>
			/// <para>Skewness—The direction of deviation from the nominal height of the LAS points, which indicates the level and direction of asymmetry.</para>
			/// </summary>
			[GPValue("SKEWNESS")]
			[Description("Skewness")]
			Skewness,

			/// <summary>
			/// <para>Kurtosis—The sharpness of the change in the height of the LAS points.</para>
			/// </summary>
			[GPValue("KURTOSIS")]
			[Description("Kurtosis")]
			Kurtosis,

			/// <summary>
			/// <para>Median Absolute Deviation—The median value of the deviation from the median height.</para>
			/// </summary>
			[GPValue("MEDIAN_ABSOLUTE_DEVIATION")]
			[Description("Median Absolute Deviation")]
			Median_Absolute_Deviation,

		}

		/// <summary>
		/// <para>Raster Format</para>
		/// </summary>
		public enum RasterFormatEnum 
		{
			/// <summary>
			/// <para>GeoTiff—Output will be created in the GeoTIFF format. This is the default.</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("GeoTiff")]
			GeoTiff,

			/// <summary>
			/// <para>Erdas Imagine (IMG)—Output will be created in the ERDAS IMAGINE format.</para>
			/// </summary>
			[GPValue("IMG")]
			[Description("Erdas Imagine (IMG)")]
			IMG,

			/// <summary>
			/// <para>Esri Grid—Output will be created in the Esri Grid format.</para>
			/// </summary>
			[GPValue("ESRI_GRID")]
			[Description("Esri Grid")]
			Esri_Grid,

		}

#endregion
	}
}
