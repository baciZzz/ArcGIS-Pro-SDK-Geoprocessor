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
	/// <para>Create Random Raster</para>
	/// <para>创建随机栅格</para>
	/// <para>使用您定义的分布创建随机值的栅格数据集。</para>
	/// </summary>
	public class CreateRandomRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>存储输出栅格数据集的文件夹以及地理数据库。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>要创建的栅格数据集的名称和格式。</para>
		/// <para>要将输出存储为地理数据库中的栅格数据集，请勿在栅格数据集名称中添加文件扩展名。</para>
		/// <para>对于基于文件的栅格，使用相应扩展名来指定要创建的格式，如下所示：</para>
		/// <para>.tif - TIFF 栅格</para>
		/// <para>.img - ERDAS IMAGINE 栅格</para>
		/// <para>.crf - CRF 栅格</para>
		/// <para>Esri Grid 无扩展名</para>
		/// </param>
		public CreateRandomRaster(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建随机栅格</para>
		/// </summary>
		public override string DisplayName() => "创建随机栅格";

		/// <summary>
		/// <para>Tool Name : CreateRandomRaster</para>
		/// </summary>
		public override string ToolName() => "CreateRandomRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRandomRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRandomRaster";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "pyramid" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutPath, OutName, Distribution, RasterExtent, Cellsize, OutRasterDataset, BuildRat };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>存储输出栅格数据集的文件夹以及地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Raster Dataset Name with Extension</para>
		/// <para>要创建的栅格数据集的名称和格式。</para>
		/// <para>要将输出存储为地理数据库中的栅格数据集，请勿在栅格数据集名称中添加文件扩展名。</para>
		/// <para>对于基于文件的栅格，使用相应扩展名来指定要创建的格式，如下所示：</para>
		/// <para>.tif - TIFF 栅格</para>
		/// <para>.img - ERDAS IMAGINE 栅格</para>
		/// <para>.crf - CRF 栅格</para>
		/// <para>Esri Grid 无扩展名</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Distribution</para>
		/// <para>指定要使用的随机值分布方法。</para>
		/// <para>每种类型都有一个或两个设置来控制分布。</para>
		/// <para>均匀 - 最小和最大值之间已定义范围的均匀分布。最小值的默认值为 0.0，最大值的默认值为 1.0。这是默认设置。</para>
		/// <para>整数 - 最小和最大值之间已定义范围的整数分布。最小值的默认值为 1，最大值的默认值为 10。</para>
		/// <para>正态 - 已定义平均值和标准差值的正态分布。平均值的默认值为 0.0，标准差的默认值为 1.0。</para>
		/// <para>指数 - 已定义平均值的指数分布。默认值为 1.0。</para>
		/// <para>泊松 - 已定义平均值的泊松分布。默认值为 1.0。</para>
		/// <para>Gamma - 已定义 Alpha 和 Beta 值的 Gamma 分布。Alpha 和 Beta 的默认值都是 1.0。</para>
		/// <para>二项 - 已定义 N 和概率值的二项分布。N 的默认值为 10，概率的默认值为 0.5。</para>
		/// <para>几何 - 已定义概率值的几何分布。默认值为 0.5。</para>
		/// <para>负二项 - 已定义 r 和概率值的帕斯卡分布。r 的默认值为 10.0，概率的默认值为 0.5。</para>
		/// <para>要编辑默认值，请单击表中的值，然后输入新值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Distribution { get; set; } = "UNIFORM 0.0 1.0";

		/// <summary>
		/// <para>Output extent</para>
		/// <para>输出栅格数据集的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object RasterExtent { get; set; }

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>输出栅格数据集的空间分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Cellsize { get; set; }

		/// <summary>
		/// <para>Output raster dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// <para>指定该工具是否将无条件地为输出栅格构建栅格属性表，其中所选分布将生成整数输出栅格。</para>
		/// <para>如果输出栅格为浮点，则此参数无效。</para>
		/// <para>选中 - 将为整数输出栅格无条件构建栅格属性表。这是默认设置。</para>
		/// <para>未选中 - 如果唯一值数量大于或等于 65535，则不会为整数输出栅格构建栅格属性表。如果唯一值数量小于 65535，则将构建栅格属性表。</para>
		/// <para><see cref="BuildRatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildRat { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRandomRaster SetEnviroment(object extent = null, object outputCoordinateSystem = null, object pyramid = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// </summary>
		public enum BuildRatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD")]
			BUILD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD")]
			DO_NOT_BUILD,

		}

#endregion
	}
}
