using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Generate Raster Collection</para>
	/// <para>生成栅格集合</para>
	/// <para>用于对镶嵌数据集中包含的影像集合执行批量分析或处理。可以单独或以组的形式处理输入镶嵌数据集中的影像。</para>
	/// </summary>
	public class GenerateRasterCollection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutRasterCollection">
		/// <para>Output Raster Collection</para>
		/// <para>要创建的镶嵌数据集的完整路径。镶嵌数据集必须存储在地理数据库中。</para>
		/// </param>
		/// <param name="CollectionBuilder">
		/// <para>Collection Builder</para>
		/// <para>输入影像集合。可将其视为一个模板，其中包含诸如源镶嵌数据集路径、用于从输入数据源中提取子集的过滤器等参数。</para>
		/// <para>目前，此工具仅支持简单集合，可用于定义单个数据源以及数据源的查询过滤器。</para>
		/// <para>简单集合—可用于定义数据源和查询过滤器。</para>
		/// <para><see cref="CollectionBuilderEnum"/></para>
		/// </param>
		/// <param name="CollectionBuilderArguments">
		/// <para>Collection Builder Arguments</para>
		/// <para>用于创建镶嵌数据集的子集集合的参数。</para>
		/// <para>此工具仅支持数据源以及用于查询镶嵌数据集子集的过滤器。数据源和 Where 子句值必须完整，否则无法执行此工具。</para>
		/// <para>数据源—数据源的路径。</para>
		/// <para>Where 子句—用于查询镶嵌数据集子集的过滤器。</para>
		/// </param>
		public GenerateRasterCollection(object OutRasterCollection, object CollectionBuilder, object CollectionBuilderArguments)
		{
			this.OutRasterCollection = OutRasterCollection;
			this.CollectionBuilder = CollectionBuilder;
			this.CollectionBuilderArguments = CollectionBuilderArguments;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成栅格集合</para>
		/// </summary>
		public override string DisplayName() => "生成栅格集合";

		/// <summary>
		/// <para>Tool Name : GenerateRasterCollection</para>
		/// </summary>
		public override string ToolName() => "GenerateRasterCollection";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateRasterCollection</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateRasterCollection";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "pyramid", "rasterStatistics" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutRasterCollection, CollectionBuilder, CollectionBuilderArguments, RasterFunction!, RasterFunctionArguments!, CollectionProperties!, GenerateRasters!, OutWorkspace!, Format!, OutBaseName! };

		/// <summary>
		/// <para>Output Raster Collection</para>
		/// <para>要创建的镶嵌数据集的完整路径。镶嵌数据集必须存储在地理数据库中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEMosaicDataset()]
		public object OutRasterCollection { get; set; }

		/// <summary>
		/// <para>Collection Builder</para>
		/// <para>输入影像集合。可将其视为一个模板，其中包含诸如源镶嵌数据集路径、用于从输入数据源中提取子集的过滤器等参数。</para>
		/// <para>目前，此工具仅支持简单集合，可用于定义单个数据源以及数据源的查询过滤器。</para>
		/// <para>简单集合—可用于定义数据源和查询过滤器。</para>
		/// <para><see cref="CollectionBuilderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CollectionBuilder { get; set; }

		/// <summary>
		/// <para>Collection Builder Arguments</para>
		/// <para>用于创建镶嵌数据集的子集集合的参数。</para>
		/// <para>此工具仅支持数据源以及用于查询镶嵌数据集子集的过滤器。数据源和 Where 子句值必须完整，否则无法执行此工具。</para>
		/// <para>数据源—数据源的路径。</para>
		/// <para>Where 子句—用于查询镶嵌数据集子集的过滤器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object CollectionBuilderArguments { get; set; }

		/// <summary>
		/// <para>Input Raster Function</para>
		/// <para>栅格函数模板文件（.rft.xml 或 .rft.json）的路径。栅格函数模板将应用于输入镶嵌数据集中的每个项目。函数编辑器可用于创建模板。如果未定义 RFT，则此工具将基于集合构建器参数参数创建输出镶嵌。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? RasterFunction { get; set; }

		/// <summary>
		/// <para>Raster Function Arguments</para>
		/// <para>参数与函数链相关联。</para>
		/// <para>例如，如果函数链应用 NDVI 函数，则设置可见红外 ID。RFT 的栅格变量名应为输入数据源中的 Tag 字段值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? RasterFunctionArguments { get; set; }

		/// <summary>
		/// <para>Raster Collection Properties</para>
		/// <para>输出镶嵌数据集关键属性。</para>
		/// <para>可用关键元数据属性基于捕获影像的传感器类型。关键元数据属性的部分示例如下：</para>
		/// <para>SensorName</para>
		/// <para>ProductName</para>
		/// <para>AcquisitionDate</para>
		/// <para>CloudCover</para>
		/// <para>SunAzimuth</para>
		/// <para>SunElevation</para>
		/// <para>SensorAzimuth</para>
		/// <para>SensorElevation</para>
		/// <para>Off-nadirAngle</para>
		/// <para>BandName</para>
		/// <para>MinimumWavelength</para>
		/// <para>MaximumWavelength</para>
		/// <para>RadianceGain</para>
		/// <para>RadianceBias</para>
		/// <para>SolarIrradiance</para>
		/// <para>ReflectanceGain</para>
		/// <para>ReflectanceBias</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Output Collection Options")]
		public object? CollectionProperties { get; set; }

		/// <summary>
		/// <para>Generate Rasters</para>
		/// <para>应用 RFT 后，生成镶嵌数据集项目的栅格数据集文件。</para>
		/// <para>未选中 - 由栅格函数模板定义的处理将追加到输入数据源中的影像项目，以在输出镶嵌数据集中生成影像项目。这是默认设置。</para>
		/// <para>选中 - 在磁盘上创建栅格数据集。您还需要指定输出栅格工作空间和格式。</para>
		/// <para><see cref="GenerateRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output Collection Options")]
		public object? GenerateRasters { get; set; } = "false";

		/// <summary>
		/// <para>Output Raster Workspace</para>
		/// <para>如果选中生成栅格参数，则需要定义永久栅格数据集的输出位置。</para>
		/// <para>输出栅格文件的命名约定为 oid_&lt;oid#&gt;_&lt;Unique_GUID&gt;。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Output Collection Options")]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>要生成的栅格的格式类型。</para>
		/// <para>Tiff—标记图像文件格式 (TIFF)</para>
		/// <para>ERDAS IMAGINE—ERDAS IMAGINE 文件</para>
		/// <para>CRF—云栅格格式。这是默认设置。</para>
		/// <para>MRF—元栅格格式</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Collection Options")]
		public object? Format { get; set; } = "CRF";

		/// <summary>
		/// <para>Output Base Name</para>
		/// <para>如果选中生成栅格参数，则需要定义永久栅格数据集的输出基本名称。多个栅格数据集输出将在其基本名称后附加数字别名。</para>
		/// <para>生成的镶嵌数据集将直接引用 CRF，而无需维护栅格函数链。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output Collection Options")]
		public object? OutBaseName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRasterCollection SetEnviroment(object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Collection Builder</para>
		/// </summary>
		public enum CollectionBuilderEnum 
		{
			/// <summary>
			/// <para>简单集合—可用于定义数据源和查询过滤器。</para>
			/// </summary>
			[GPValue("SIMPLE_COLLECTION")]
			[Description("简单集合")]
			Simple_collection,

		}

		/// <summary>
		/// <para>Generate Rasters</para>
		/// </summary>
		public enum GenerateRastersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_RASTERS")]
			GENERATE_RASTERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_RASTERS")]
			NO_GENERATE_RASTERS,

		}

		/// <summary>
		/// <para>Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>Tiff—标记图像文件格式 (TIFF)</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("Tiff")]
			Tiff,

			/// <summary>
			/// <para>ERDAS IMAGINE—ERDAS IMAGINE 文件</para>
			/// </summary>
			[GPValue("IMAGINE Image")]
			[Description("ERDAS IMAGINE")]
			ERDAS_IMAGINE,

			/// <summary>
			/// <para>CRF—云栅格格式。这是默认设置。</para>
			/// </summary>
			[GPValue("CRF")]
			[Description("CRF")]
			CRF,

			/// <summary>
			/// <para>MRF—元栅格格式</para>
			/// </summary>
			[GPValue("MRF")]
			[Description("MRF")]
			MRF,

		}

#endregion
	}
}
