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
	/// <para>LAS 高度度量</para>
	/// <para>计算有关 LAS 数据中捕获的植被点高程测量分布的统计数据。</para>
	/// </summary>
	public class LasHeightMetrics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>存放输出栅格数据集的文件夹以及地理数据库。一旦输出位置为文件夹，则生成的栅格数据集将采用 TIFF 格式。</para>
		/// </param>
		public LasHeightMetrics(object InLasDataset, object OutLocation)
		{
			this.InLasDataset = InLasDataset;
			this.OutLocation = OutLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS 高度度量</para>
		/// </summary>
		public override string DisplayName() => "LAS 高度度量";

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
		public override object[] Parameters() => new object[] { InLasDataset, OutLocation, BaseName, Statistics, HeightPercentiles, MinHeight, MinPoints, CellSize, DerivedOutLocation, OutputRasters, RasterFormat };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>存放输出栅格数据集的文件夹以及地理数据库。一旦输出位置为文件夹，则生成的栅格数据集将采用 TIFF 格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>输出栅格数据集的基本名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BaseName { get; set; } = "height_";

		/// <summary>
		/// <para>Statistics Options</para>
		/// <para>指定针对输出栅格中每个像元区域内的未分类点和地面上的植被点所计算的统计数据。</para>
		/// <para>平均值—LAS 点的高度平均值。</para>
		/// <para>峰度—LAS 点高度变化的剧烈程度。</para>
		/// <para>偏度—LAS 点标称高度的偏差方向，用于指示不对称的级别和方向。</para>
		/// <para>标准差—点高度的变化。</para>
		/// <para>中位数绝对差—中等高度偏差的中值。</para>
		/// <para><see cref="StatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Statistics { get; set; }

		/// <summary>
		/// <para>Height Percentiles</para>
		/// <para>像元中指定百分比的点所低于的高度。例如，此值为 95 意味着生成的像元值表明出现了 95％ 的点高于地面的高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object HeightPercentiles { get; set; }

		/// <summary>
		/// <para>Minimum Height</para>
		/// <para>将评估的点的地面上最小高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object MinHeight { get; set; } = "2 Meters";

		/// <summary>
		/// <para>Minimum Number of Points</para>
		/// <para>必须存在于给定像元中，以计算高度度量的点的最小数量。点数小于指定最小数量的像元在输出中将没有数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MinPoints { get; set; } = "4";

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>输出栅格数据集的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object CellSize { get; set; } = "20 Meters";

		/// <summary>
		/// <para>Output Location</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object DerivedOutLocation { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutputRasters { get; set; }

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>指定当输出位置为文件夹时将创建的栅格格式。</para>
		/// <para>GeoTiff—输出将以 GeoTIFF 格式创建。这是默认设置。</para>
		/// <para>Erdas Imagine (IMG)—输出将以 ERDAS IMAGINE 格式创建。</para>
		/// <para>Esri Grid—输出将以 Esri Grid 格式创建。</para>
		/// <para><see cref="RasterFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RasterFormat { get; set; } = "TIFF";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasHeightMetrics SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
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
			/// <para>平均值—LAS 点的高度平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>标准差—点高度的变化。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("标准差")]
			Standard_Deviation,

			/// <summary>
			/// <para>偏度—LAS 点标称高度的偏差方向，用于指示不对称的级别和方向。</para>
			/// </summary>
			[GPValue("SKEWNESS")]
			[Description("偏度")]
			Skewness,

			/// <summary>
			/// <para>峰度—LAS 点高度变化的剧烈程度。</para>
			/// </summary>
			[GPValue("KURTOSIS")]
			[Description("峰度")]
			Kurtosis,

			/// <summary>
			/// <para>中位数绝对差—中等高度偏差的中值。</para>
			/// </summary>
			[GPValue("MEDIAN_ABSOLUTE_DEVIATION")]
			[Description("中位数绝对差")]
			Median_Absolute_Deviation,

		}

		/// <summary>
		/// <para>Raster Format</para>
		/// </summary>
		public enum RasterFormatEnum 
		{
			/// <summary>
			/// <para>GeoTiff—输出将以 GeoTIFF 格式创建。这是默认设置。</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("GeoTiff")]
			GeoTiff,

			/// <summary>
			/// <para>Erdas Imagine (IMG)—输出将以 ERDAS IMAGINE 格式创建。</para>
			/// </summary>
			[GPValue("IMG")]
			[Description("Erdas Imagine (IMG)")]
			IMG,

			/// <summary>
			/// <para>Esri Grid—输出将以 Esri Grid 格式创建。</para>
			/// </summary>
			[GPValue("ESRI_GRID")]
			[Description("Esri Grid")]
			Esri_Grid,

		}

#endregion
	}
}
