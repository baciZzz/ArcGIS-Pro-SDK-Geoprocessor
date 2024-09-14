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
	/// <para>Manage Tile Cache</para>
	/// <para>管理切片缓存</para>
	/// <para>创建切片缓存或在现有的切片缓存中更新切片。 此工具用于创建切片、替换缺失切片、覆盖过时切片以及删除切片。</para>
	/// </summary>
	public class ManageTileCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCacheLocation">
		/// <para>Cache Location</para>
		/// <para>创建缓存数据集所在的文件夹、栅格图层或现有切片缓存的路径。</para>
		/// </param>
		/// <param name="ManageMode">
		/// <para>Manage Mode</para>
		/// <para>指定将用于管理缓存的模式。</para>
		/// <para>重新创建所有切片—如果范围发生改变或将图层添加到多图层缓存，则需要更换现有切片并添加新切片。</para>
		/// <para>重新创建空切片—只对空的切片重新创建。 现有切片将保持不变。</para>
		/// <para>删除切片—将从缓存中删除切片。 缓存文件夹结构不会删除。</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </param>
		public ManageTileCache(object InCacheLocation, object ManageMode)
		{
			this.InCacheLocation = InCacheLocation;
			this.ManageMode = ManageMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理切片缓存</para>
		/// </summary>
		public override string DisplayName() => "管理切片缓存";

		/// <summary>
		/// <para>Tool Name : ManageTileCache</para>
		/// </summary>
		public override string ToolName() => "ManageTileCache";

		/// <summary>
		/// <para>Tool Excute Name : management.ManageTileCache</para>
		/// </summary>
		public override string ExcuteName() => "management.ManageTileCache";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCacheLocation, ManageMode, InCacheName!, InDatasource!, TilingScheme!, ImportTilingScheme!, Scales!, AreaOfInterest!, MaxCellSize!, MinCachedScale!, MaxCachedScale!, OutCacheLocation! };

		/// <summary>
		/// <para>Cache Location</para>
		/// <para>创建缓存数据集所在的文件夹、栅格图层或现有切片缓存的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InCacheLocation { get; set; }

		/// <summary>
		/// <para>Manage Mode</para>
		/// <para>指定将用于管理缓存的模式。</para>
		/// <para>重新创建所有切片—如果范围发生改变或将图层添加到多图层缓存，则需要更换现有切片并添加新切片。</para>
		/// <para>重新创建空切片—只对空的切片重新创建。 现有切片将保持不变。</para>
		/// <para>删除切片—将从缓存中删除切片。 缓存文件夹结构不会删除。</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ManageMode { get; set; } = "RECREATE_ALL_TILES";

		/// <summary>
		/// <para>Cache Name</para>
		/// <para>在缓存位置中待创建的缓存数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? InCacheName { get; set; }

		/// <summary>
		/// <para>Input Data Source</para>
		/// <para>栅格数据集、镶嵌数据集或地图文件。</para>
		/// <para>如果已将管理模式参数设置为删除切片，则不需要此参数。</para>
		/// <para>地图文件 (.mapx) 不能包含地图服务或图像服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InDatasource { get; set; }

		/// <summary>
		/// <para>Input Tiling Scheme</para>
		/// <para>指定将使用的切片方案。</para>
		/// <para>ArcGIS Online 方案—将使用默认 ArcGIS Online 切片方案。</para>
		/// <para>导入方案—将导入并使用现有的切片方案。</para>
		/// <para>高程切片方案—将使用高程服务切片方案。</para>
		/// <para>WGS84　版本　2　切片方案—将使用 WGS84　版本　2　切片方案。</para>
		/// <para>WGS84　版本　2　高程切片方案—将使用 WGS84 版本 2 切片方案来构建高程数据的切片缓存。</para>
		/// <para><see cref="TilingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TilingScheme { get; set; } = "ARCGISONLINE_SCHEME";

		/// <summary>
		/// <para>Import Tiling Scheme</para>
		/// <para>现有方案文件 (.xml) 的路径或从现有影像服务或地图服务中导入的切片方案。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ImportTilingScheme { get; set; }

		/// <summary>
		/// <para>Scales [Pixel Size] (Estimated Disk Space)</para>
		/// <para>一系列比例级别，将在这些比例级别上创建或删除切片，具体取决于管理模式参数的值。 像素大小将基于切片方案的空间参考。</para>
		/// <para>默认情况下，仅使用最小缓存比例和最大缓存比例的值。</para>
		/// <para>更改最小缓存比例或最大缓存比例参数的值将选中或取消选中相应的比例值。</para>
		/// <para>生成缓存时将忽略选中的比例以及不在最小缓存比例或最大缓存比例参数值范围之内的比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Scales { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>定义感兴趣区以对将创建或删除的切片进行约束。</para>
		/// <para>它可能是一个要素类，也可能是以交互方式定义的要素集。</para>
		/// <para>该参数用于为形状不规则的区域管理切片。 当您要对某些区域进行预缓存或让较少访问的区域保持未缓存的状态时，这也同样有用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Maximum Source Cell Size</para>
		/// <para>用于定义生成了缓存的数据源的可见性的值。 默认情况下，该值为空。</para>
		/// <para>如果该值为空，则以下适用：</para>
		/// <para>对于数据源可见性范围内的缓存级别，缓存是由数据源生成的。</para>
		/// <para>对于超出数据源可见性范围的缓存级别，缓存是由前一级缓存生成的。</para>
		/// <para>如果该值大于零，则以下适用：</para>
		/// <para>对于像元大小小于等于最大源像元大小 (max_cell_size) 的级别，缓存是由数据源生成的。</para>
		/// <para>对于源像元大小大于最大源像元大小 (max_cell_size) 的级别，缓存是由前一级缓存生成的。</para>
		/// <para>最大源像元大小值的单位应与源数据集的像元大小单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxCellSize { get; set; }

		/// <summary>
		/// <para>Minimum Cached Scale</para>
		/// <para>创建切片的最小比例。 这不必是切片方案中的最小比例。 由最小缓存比例确定生成缓存时将使用哪个比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object? MinCachedScale { get; set; }

		/// <summary>
		/// <para>Maximum Cached Scale</para>
		/// <para>创建切片的最大比例。 这不必是切片方案中的最大比例。 由最大缓存比例确定生成缓存时将使用哪个比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object? MaxCachedScale { get; set; }

		/// <summary>
		/// <para>Cache Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutCacheLocation { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageTileCache SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Manage Mode</para>
		/// </summary>
		public enum ManageModeEnum 
		{
			/// <summary>
			/// <para>重新创建所有切片—如果范围发生改变或将图层添加到多图层缓存，则需要更换现有切片并添加新切片。</para>
			/// </summary>
			[GPValue("RECREATE_ALL_TILES")]
			[Description("重新创建所有切片")]
			Recreate_all_tiles,

			/// <summary>
			/// <para>重新创建空切片—只对空的切片重新创建。 现有切片将保持不变。</para>
			/// </summary>
			[GPValue("RECREATE_EMPTY_TILES")]
			[Description("重新创建空切片")]
			Recreate_empty_tiles,

			/// <summary>
			/// <para>删除切片—将从缓存中删除切片。 缓存文件夹结构不会删除。</para>
			/// </summary>
			[GPValue("DELETE_TILES")]
			[Description("删除切片")]
			Delete_tiles,

		}

		/// <summary>
		/// <para>Input Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeEnum 
		{
			/// <summary>
			/// <para>ArcGIS Online 方案—将使用默认 ArcGIS Online 切片方案。</para>
			/// </summary>
			[GPValue("ARCGISONLINE_SCHEME")]
			[Description("ArcGIS Online 方案")]
			ArcGIS_Online_scheme,

			/// <summary>
			/// <para>高程切片方案—将使用高程服务切片方案。</para>
			/// </summary>
			[GPValue("ARCGISONLINE_ELEVATION_SCHEME")]
			[Description("高程切片方案")]
			Elevation_tiling_scheme,

			/// <summary>
			/// <para>WGS84　版本　2　切片方案—将使用 WGS84　版本　2　切片方案。</para>
			/// </summary>
			[GPValue("WGS84_V2_SCHEME")]
			[Description("WGS84　版本　2　切片方案")]
			WGS84_Version_2_tiling_scheme,

			/// <summary>
			/// <para>WGS84　版本　2　高程切片方案—将使用 WGS84 版本 2 切片方案来构建高程数据的切片缓存。</para>
			/// </summary>
			[GPValue("WGS84_V2_ELEVATION_SCHEME")]
			[Description("WGS84　版本　2　高程切片方案")]
			WGS84_Version_2_elevation_tiling_scheme,

			/// <summary>
			/// <para>导入方案—将导入并使用现有的切片方案。</para>
			/// </summary>
			[GPValue("IMPORT_SCHEME")]
			[Description("导入方案")]
			Import_scheme,

		}

#endregion
	}
}
