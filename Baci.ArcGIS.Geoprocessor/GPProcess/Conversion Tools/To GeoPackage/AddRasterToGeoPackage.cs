using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Add Raster to GeoPackage</para>
	/// <para>向 GeoPackage 添加栅格</para>
	/// <para>将栅格数据集加载到 OGC GeoPackage 栅格金字塔中。</para>
	/// </summary>
	public class AddRasterToGeoPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Raster</para>
		/// <para>要加载到 OGC GeoPackage 栅格金字塔中的栅格数据集。</para>
		/// </param>
		/// <param name="TargetGeopackage">
		/// <para>Target GeoPackage</para>
		/// <para>要加载栅格数据集的 GeoPackage。</para>
		/// </param>
		/// <param name="RasterName">
		/// <para>Raster Name</para>
		/// <para>输出 GeoPackage 栅格金字塔的名称。</para>
		/// </param>
		public AddRasterToGeoPackage(object InDataset, object TargetGeopackage, object RasterName)
		{
			this.InDataset = InDataset;
			this.TargetGeopackage = TargetGeopackage;
			this.RasterName = RasterName;
		}

		/// <summary>
		/// <para>Tool Display Name : 向 GeoPackage 添加栅格</para>
		/// </summary>
		public override string DisplayName() => "向 GeoPackage 添加栅格";

		/// <summary>
		/// <para>Tool Name : AddRasterToGeoPackage</para>
		/// </summary>
		public override string ToolName() => "AddRasterToGeoPackage";

		/// <summary>
		/// <para>Tool Excute Name : conversion.AddRasterToGeoPackage</para>
		/// </summary>
		public override string ExcuteName() => "conversion.AddRasterToGeoPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "pyramid" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, TargetGeopackage, RasterName, TilingScheme, TilingSchemeFile, OutGeopackageRaster, AreaOfInterest };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要加载到 OGC GeoPackage 栅格金字塔中的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Target GeoPackage</para>
		/// <para>要加载栅格数据集的 GeoPackage。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_folders", "esri_browseDialogFilters_sqlite")]
		public object TargetGeopackage { get; set; }

		/// <summary>
		/// <para>Raster Name</para>
		/// <para>输出 GeoPackage 栅格金字塔的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RasterName { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para>指定切片方案。</para>
		/// <para>切片—系统将保留输入栅格的空间参考，且将按照 GeoPackage 标准生成切片。这是默认设置。</para>
		/// <para>ArcGIS Online— 栅格切片将在 Web Mercator 坐标参考中生成（与针对 Army Geospatial Center 制定的方案相同）。</para>
		/// <para>NSG Profile 可缩放的横轴墨卡托—将使用可缩放的横轴墨卡托。</para>
		/// <para>NSG Profile WGS84 地理坐标系—将使用 WGS84 地理坐标系。</para>
		/// <para>Google Earth Web Mercator—将使用Web Mercator 坐标参考中的参数来创建栅格切片。</para>
		/// <para>自定义切片方案文件—将使用文件中的自定义切片方案（该文件使用通过 生成切片缓存切片方案工具创建的 XML 方案定义）。</para>
		/// <para><see cref="TilingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingScheme { get; set; } = "TILED";

		/// <summary>
		/// <para>Tiling Scheme File</para>
		/// <para>当切片方案设置为自定义切片方案文件时需要的自定义切片方案文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object TilingSchemeFile { get; set; }

		/// <summary>
		/// <para>Output GeoPackage</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutGeopackageRaster { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>感兴趣区域，用于限制要加载的栅格区域，而非整个数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddRasterToGeoPackage SetEnviroment(object compression = null , object pyramid = null )
		{
			base.SetEnv(compression: compression, pyramid: pyramid);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeEnum 
		{
			/// <summary>
			/// <para>切片—系统将保留输入栅格的空间参考，且将按照 GeoPackage 标准生成切片。这是默认设置。</para>
			/// </summary>
			[GPValue("TILED")]
			[Description("切片")]
			Tiled,

			/// <summary>
			/// <para>ArcGIS Online— 栅格切片将在 Web Mercator 坐标参考中生成（与针对 Army Geospatial Center 制定的方案相同）。</para>
			/// </summary>
			[GPValue("ARCGISONLINE_SCHEME")]
			[Description("ArcGIS Online")]
			ArcGIS_Online,

			/// <summary>
			/// <para>Google Earth Web Mercator—将使用Web Mercator 坐标参考中的参数来创建栅格切片。</para>
			/// </summary>
			[GPValue("GOOGLE_EARTH_WEB_MERCATOR")]
			[Description("Google Earth Web Mercator")]
			Google_Earth_Web_Mercator,

			/// <summary>
			/// <para>NSG Profile 可缩放的横轴墨卡托—将使用可缩放的横轴墨卡托。</para>
			/// </summary>
			[GPValue("NSGPROFILE_SCALED_TRANSVERSE_MERCATOR")]
			[Description("NSG Profile 可缩放的横轴墨卡托")]
			NSG_Profile_Scaled_Transverse_Mercator,

			/// <summary>
			/// <para>NSG Profile WGS84 地理坐标系—将使用 WGS84 地理坐标系。</para>
			/// </summary>
			[GPValue("NSGPROFILE_WGS84_GEOGRAPHIC")]
			[Description("NSG Profile WGS84 地理坐标系")]
			NSG_Profile_WGS84_Geographic,

			/// <summary>
			/// <para>自定义切片方案文件—将使用文件中的自定义切片方案（该文件使用通过 生成切片缓存切片方案工具创建的 XML 方案定义）。</para>
			/// </summary>
			[GPValue("FROM_FILE")]
			[Description("自定义切片方案文件")]
			Custom_tiling_scheme_file,

		}

#endregion
	}
}
