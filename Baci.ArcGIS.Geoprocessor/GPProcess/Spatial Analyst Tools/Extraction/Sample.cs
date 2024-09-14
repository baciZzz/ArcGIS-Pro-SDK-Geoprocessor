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
	/// <para>Sample</para>
	/// <para>采样</para>
	/// <para>创建一个表或点要素类，其中显示从一个栅格或一组栅格提取的已定义位置的像元值。该位置由栅格像元、点、折线或面进行定义。</para>
	/// </summary>
	public class Sample : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>将根据输入位置数据对栅格值进行采样。</para>
		/// <para>仅当输入为单个多维栅格时，以多维方式处理参数才可用。</para>
		/// </param>
		/// <param name="InLocationData">
		/// <para>Input location raster or features</para>
		/// <para>标识将要进行采样的位置的数据。</para>
		/// <para>输入可以是栅格或要素类。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table or feature class</para>
		/// <para>包含采样像元值的输出表或要素类。</para>
		/// <para>输出格式由输出位置和路径确定。默认情况下，输出将是地理数据库工作空间中的地理数据库表或地理数据库要素类，或者文件夹工作空间中的 dBASE 表或 shapefile 要素类。</para>
		/// <para>生成表或要素类的输出数据类型由 生成要素类参数控制。</para>
		/// </param>
		public Sample(object InRasters, object InLocationData, object OutTable)
		{
			this.InRasters = InRasters;
			this.InLocationData = InLocationData;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 采样</para>
		/// </summary>
		public override string DisplayName() => "采样";

		/// <summary>
		/// <para>Tool Name : 采样</para>
		/// </summary>
		public override string ToolName() => "采样";

		/// <summary>
		/// <para>Tool Excute Name : sa.Sample</para>
		/// </summary>
		public override string ExcuteName() => "sa.Sample";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, InLocationData, OutTable, ResamplingType, UniqueIdField, ProcessAsMultidimensional, AcquisitionDefinition, StatisticsType, PercentileValue, BufferDistance, Layout, GenerateFeatureClass };

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>将根据输入位置数据对栅格值进行采样。</para>
		/// <para>仅当输入为单个多维栅格时，以多维方式处理参数才可用。</para>
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
		/// <para>标识将要进行采样的位置的数据。</para>
		/// <para>输入可以是栅格或要素类。</para>
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
		/// <para>包含采样像元值的输出表或要素类。</para>
		/// <para>输出格式由输出位置和路径确定。默认情况下，输出将是地理数据库工作空间中的地理数据库表或地理数据库要素类，或者文件夹工作空间中的 dBASE 表或 shapefile 要素类。</para>
		/// <para>生成表或要素类的输出数据类型由 生成要素类参数控制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Resampling technique</para>
		/// <para>此重采样算法将用于对栅格进行采样，以确定如何从栅格中获取值。</para>
		/// <para>最邻近—将使用最邻近分配法。这是默认设置。</para>
		/// <para>双线性法—将使用双线性插值法。</para>
		/// <para>三次—将使用三次卷积插值法。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Unique ID field</para>
		/// <para>包含输入位置栅格或要素中每个位置或要素不同值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "OID")]
		public object UniqueIdField { get; set; }

		/// <summary>
		/// <para>Process as multidimensional</para>
		/// <para>指定如何处理输入栅格。</para>
		/// <para>仅当输入为单个多维栅格时，该参数才可用。</para>
		/// <para>未选中 - 将处理来自多维数据集的当前剖切片的样本。这是默认设置。</para>
		/// <para>选中 - 将处理来自多维数据集的所有维度（如时间或深度）的样本。</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Acquisition information of location data</para>
		/// <para>指定与位置要素关联的时间、深度或其他采集数据。</para>
		/// <para>仅支持以下组合：</para>
		/// <para>维度 + 开始字段或值</para>
		/// <para>维度 + 开始字段或值 + 结束字段或值</para>
		/// <para>维度 + 开始字段或值 + 相对值或之前的天数 + 相对值或之后的天数</para>
		/// <para>相对值或之前的天数和相对值或之后的天数仅支持非负值。</para>
		/// <para>将使用统计类型参数计算该维度范围内变量的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object AcquisitionDefinition { get; set; }

		/// <summary>
		/// <para>Statistics type</para>
		/// <para>指定要计算的统计数据类型。</para>
		/// <para>最小值—将计算指定范围内的最小值。</para>
		/// <para>最大值—将计算指定范围内的最大值。</para>
		/// <para>中值—将计算指定范围内的中值。</para>
		/// <para>平均值—将计算指定范围的平均值。</para>
		/// <para>总和—将计算指定范围内变量的总值。</para>
		/// <para>众数—将计算出现次数最多的值。</para>
		/// <para>少数—将计算出现次数最少的值。</para>
		/// <para>标准差—将计算标准差。</para>
		/// <para>百分比数—将计算指定范围内定义的百分比。</para>
		/// <para><see cref="StatisticsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StatisticsType { get; set; }

		/// <summary>
		/// <para>Percentile value</para>
		/// <para>该值范围可以介于 0 到 100 之间。默认值为 90。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100)]
		public object PercentileValue { get; set; }

		/// <summary>
		/// <para>Buffer distance field or value</para>
		/// <para>位置数据要素周围的距离。缓冲距离以位置要素空间参考的线性单位指定。如果要素使用地理参考，则单位将为度。</para>
		/// <para>将在此缓冲区区域内计算统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistance { get; set; }

		/// <summary>
		/// <para>Column-wise layout</para>
		/// <para>指定采样值将在输出表中以行还是以列显示。</para>
		/// <para>未选中 - 采样值将在输出表中以单独行显示。这是默认设置。</para>
		/// <para>选中 - 采样值将在输出表中以单独列显示。仅当输入多维栅格包含一个变量和一个维度并且每个剖切为单波段栅格时，此选项才有效。</para>
		/// <para><see cref="LayoutEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Layout { get; set; } = "false";

		/// <summary>
		/// <para>Generate feature class</para>
		/// <para>指定将生成在其属性表中具有采样值的点要素类，还是仅会生成具有采样值的表。</para>
		/// <para>未选中 - 将生成具有采样值的表。这是默认设置。</para>
		/// <para>选中 - 将生成在其属性表中具有采样值的点要素类。</para>
		/// <para><see cref="GenerateFeatureClassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateFeatureClass { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Sample SetEnviroment(int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
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
			/// <para>最邻近—将使用最邻近分配法。这是默认设置。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>双线性法—将使用双线性插值法。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性法")]
			Bilinear,

			/// <summary>
			/// <para>三次—将使用三次卷积插值法。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

		}

		/// <summary>
		/// <para>Process as multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

			/// <summary>
			/// <para></para>
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
			/// <para>最小值—将计算指定范围内的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—将计算指定范围内的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>中值—将计算指定范围内的中值。</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("中值")]
			Median,

			/// <summary>
			/// <para>平均值—将计算指定范围的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>总和—将计算指定范围内变量的总值。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

			/// <summary>
			/// <para>众数—将计算出现次数最多的值。</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("众数")]
			Majority,

			/// <summary>
			/// <para>少数—将计算出现次数最少的值。</para>
			/// </summary>
			[GPValue("MINORITY")]
			[Description("少数")]
			Minority,

			/// <summary>
			/// <para>标准差—将计算标准差。</para>
			/// </summary>
			[GPValue("STD")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>百分比数—将计算指定范围内定义的百分比。</para>
			/// </summary>
			[GPValue("PERCENTILE")]
			[Description("百分比数")]
			Percentile,

		}

		/// <summary>
		/// <para>Column-wise layout</para>
		/// </summary>
		public enum LayoutEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ROW_WISE")]
			ROW_WISE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("TABLE")]
			TABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FEATURE_CLASS")]
			FEATURE_CLASS,

		}

#endregion
	}
}
