using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Create Location File From Text File</para>
	/// <para>从文本文件创建位置文件</para>
	/// <para>从 GeoNames、国家地理空间情报局 Geonet 名称服务器或美国地质勘探局地理名称信息服务的文本文件创建位置文件，以用于 ArcGIS LocateXT。</para>
	/// </summary>
	public class CreateLocationFileFromTextFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPlacenamesFile">
		/// <para>Input Placenames File</para>
		/// <para>从 GeoNames、NGA GNS 或 USGS GNIS 获得的地名文本文件。</para>
		/// </param>
		/// <param name="DataSource">
		/// <para>Data Source</para>
		/// <para>指定用于创建输入的数据源。</para>
		/// <para>GeoNames—输入文件来自 GeoNames.org。</para>
		/// <para>NGA GNS—输入文件来自 NGA GNS。</para>
		/// <para>USGS GNIS—输入文件来自 USGS GNIS。</para>
		/// <para>USGS 南极名称—输入文件来自 USGS GNIS 南极名称。</para>
		/// <para><see cref="DataSourceEnum"/></para>
		/// </param>
		/// <param name="OutLocationFile">
		/// <para>Output Location File</para>
		/// <para>输出位置文件。</para>
		/// </param>
		public CreateLocationFileFromTextFile(object InPlacenamesFile, object DataSource, object OutLocationFile)
		{
			this.InPlacenamesFile = InPlacenamesFile;
			this.DataSource = DataSource;
			this.OutLocationFile = OutLocationFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 从文本文件创建位置文件</para>
		/// </summary>
		public override string DisplayName() => "从文本文件创建位置文件";

		/// <summary>
		/// <para>Tool Name : CreateLocationFileFromTextFile</para>
		/// </summary>
		public override string ToolName() => "CreateLocationFileFromTextFile";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.CreateLocationFileFromTextFile</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.CreateLocationFileFromTextFile";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPlacenamesFile, DataSource, OutLocationFile, IncludeFeatures, InRois };

		/// <summary>
		/// <para>Input Placenames File</para>
		/// <para>从 GeoNames、NGA GNS 或 USGS GNIS 获得的地名文本文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InPlacenamesFile { get; set; }

		/// <summary>
		/// <para>Data Source</para>
		/// <para>指定用于创建输入的数据源。</para>
		/// <para>GeoNames—输入文件来自 GeoNames.org。</para>
		/// <para>NGA GNS—输入文件来自 NGA GNS。</para>
		/// <para>USGS GNIS—输入文件来自 USGS GNIS。</para>
		/// <para>USGS 南极名称—输入文件来自 USGS GNIS 南极名称。</para>
		/// <para><see cref="DataSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataSource { get; set; } = "GEONAMES";

		/// <summary>
		/// <para>Output Location File</para>
		/// <para>输出位置文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutLocationFile { get; set; }

		/// <summary>
		/// <para>Include Features</para>
		/// <para>指定来自输入数据源的要素类类型，这些类型将包含在输出中。</para>
		/// <para>行政要素—将包括如行政边界、城镇、州、部落、国家边界等行政要素。</para>
		/// <para>水文要素—将包括如河流、湖泊、池塘和其他水体等要素。</para>
		/// <para>地点要素—将包括如建筑物、教堂、医院和其他人造感兴趣点等要素。</para>
		/// <para>居民区—将包括如城镇、城市、村庄和其他人员聚集区域等已命名地点的位置。</para>
		/// <para>交通运输要素—将包括如道路、路径、铁路和机场等要素。</para>
		/// <para>点要素—将包括如山峰和其他自然感兴趣点等测高要素。</para>
		/// <para>地形要素—将包括如山脉、丘陵、悬崖、火山口和山脊等要素。</para>
		/// <para>植被要素—将包括如森林、原始林区、灌木丛林地和其他统一植被区域等要素。</para>
		/// <para>海底要素—将包括如礁石、障碍、沉船等要素。</para>
		/// <para><see cref="IncludeFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object IncludeFeatures { get; set; }

		/// <summary>
		/// <para>Input Regions Of Interest</para>
		/// <para>将用于创建输入地名文件子集的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object InRois { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Data Source</para>
		/// </summary>
		public enum DataSourceEnum 
		{
			/// <summary>
			/// <para>GeoNames—输入文件来自 GeoNames.org。</para>
			/// </summary>
			[GPValue("GEONAMES")]
			[Description("GeoNames")]
			GeoNames,

			/// <summary>
			/// <para>NGA GNS—输入文件来自 NGA GNS。</para>
			/// </summary>
			[GPValue("NGA_GNS")]
			[Description("NGA GNS")]
			NGA_GNS,

			/// <summary>
			/// <para>USGS GNIS—输入文件来自 USGS GNIS。</para>
			/// </summary>
			[GPValue("USGS_GNIS")]
			[Description("USGS GNIS")]
			USGS_GNIS,

			/// <summary>
			/// <para>USGS 南极名称—输入文件来自 USGS GNIS 南极名称。</para>
			/// </summary>
			[GPValue("USGS_ANTARCTIC_NAMES")]
			[Description("USGS 南极名称")]
			USGS_Antarctic_Names,

		}

		/// <summary>
		/// <para>Include Features</para>
		/// </summary>
		public enum IncludeFeaturesEnum 
		{
			/// <summary>
			/// <para>行政要素—将包括如行政边界、城镇、州、部落、国家边界等行政要素。</para>
			/// </summary>
			[GPValue("ADMINISTRATIVE_FEATURES")]
			[Description("行政要素")]
			Administrative_Features,

			/// <summary>
			/// <para>水文要素—将包括如河流、湖泊、池塘和其他水体等要素。</para>
			/// </summary>
			[GPValue("HYDROLOGICAL_FEATURES")]
			[Description("水文要素")]
			Hydrological_Features,

			/// <summary>
			/// <para>地点要素—将包括如建筑物、教堂、医院和其他人造感兴趣点等要素。</para>
			/// </summary>
			[GPValue("LOCALITY_FEATURES")]
			[Description("地点要素")]
			Locality_Features,

			/// <summary>
			/// <para>居民区—将包括如城镇、城市、村庄和其他人员聚集区域等已命名地点的位置。</para>
			/// </summary>
			[GPValue("POPULATED_PLACES")]
			[Description("居民区")]
			Populated_Places,

			/// <summary>
			/// <para>交通运输要素—将包括如道路、路径、铁路和机场等要素。</para>
			/// </summary>
			[GPValue("TRANSPORTATION_FEATURES")]
			[Description("交通运输要素")]
			Transportation_Features,

			/// <summary>
			/// <para>点要素—将包括如山峰和其他自然感兴趣点等测高要素。</para>
			/// </summary>
			[GPValue("SPOT_FEATURES")]
			[Description("点要素")]
			Spot_Features,

			/// <summary>
			/// <para>地形要素—将包括如山脉、丘陵、悬崖、火山口和山脊等要素。</para>
			/// </summary>
			[GPValue("TERRAIN_FEATURES")]
			[Description("地形要素")]
			Terrain_Features,

			/// <summary>
			/// <para>海底要素—将包括如礁石、障碍、沉船等要素。</para>
			/// </summary>
			[GPValue("UNDERSEA_FEATURES")]
			[Description("海底要素")]
			Undersea_Features,

			/// <summary>
			/// <para>植被要素—将包括如森林、原始林区、灌木丛林地和其他统一植被区域等要素。</para>
			/// </summary>
			[GPValue("VEGETATION_FEATURES")]
			[Description("植被要素")]
			Vegetation_Features,

		}

#endregion
	}
}
