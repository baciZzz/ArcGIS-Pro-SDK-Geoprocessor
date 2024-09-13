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
	/// <para>Create Vector Tile Index</para>
	/// <para>创建矢量切片索引</para>
	/// <para>创建矢量切片包的同时创建多比例面格网，可将该格网用作索引面。</para>
	/// </summary>
	public class CreateVectorTileIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>输入地图的要素分布和折点密度指定输出面的大小和排列。 输入地图是随后使用创建矢量切片包工具创建矢量切片时需要用到的典型地图。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Tile Feature Class</para>
		/// <para>每个细节层次的索引切片的输出面要素类。 每个切片包括的输入折点数量应易于管理，该数量不超过最大折点计数参数指定的数量。</para>
		/// </param>
		/// <param name="ServiceType">
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>指定是从现有地图服务还是为 ArcGIS Online、Bing Maps 和 Google Maps 生成切片方案。</para>
		/// <para>选中 - 将使用 ArcGIS Online/Bing Maps/Google Maps 的切片方案。 ArcGIS Online/Bing Maps/Google Maps 切片方案可用于将您的缓存切片与这些在线地图服务的切片进行叠加。 加载切片方案时，ArcGIS Pro 以内置选项形式包括此切片方案。 如果选中此参数，源地图的数据框必须使用 WGS 1984 Web 墨卡托（辅助球体）投影坐标系。 这是默认设置。</para>
		/// <para>取消选中 - 将使用现有矢量切片服务的切片方案。 仅支持不同等级间的比例逐渐加倍且有 512 × 512 切片尺寸的切片方案。 必须在切片方案参数中指定矢量切片服务或切片方案文件。</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </param>
		public CreateVectorTileIndex(object InMap, object OutFeatureclass, object ServiceType)
		{
			this.InMap = InMap;
			this.OutFeatureclass = OutFeatureclass;
			this.ServiceType = ServiceType;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建矢量切片索引</para>
		/// </summary>
		public override string DisplayName() => "创建矢量切片索引";

		/// <summary>
		/// <para>Tool Name : CreateVectorTileIndex</para>
		/// </summary>
		public override string ToolName() => "CreateVectorTileIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVectorTileIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateVectorTileIndex";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutFeatureclass, ServiceType, TilingScheme!, VertexCount! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>输入地图的要素分布和折点密度指定输出面的大小和排列。 输入地图是随后使用创建矢量切片包工具创建矢量切片时需要用到的典型地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output Tile Feature Class</para>
		/// <para>每个细节层次的索引切片的输出面要素类。 每个切片包括的输入折点数量应易于管理，该数量不超过最大折点计数参数指定的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>指定是从现有地图服务还是为 ArcGIS Online、Bing Maps 和 Google Maps 生成切片方案。</para>
		/// <para>选中 - 将使用 ArcGIS Online/Bing Maps/Google Maps 的切片方案。 ArcGIS Online/Bing Maps/Google Maps 切片方案可用于将您的缓存切片与这些在线地图服务的切片进行叠加。 加载切片方案时，ArcGIS Pro 以内置选项形式包括此切片方案。 如果选中此参数，源地图的数据框必须使用 WGS 1984 Web 墨卡托（辅助球体）投影坐标系。 这是默认设置。</para>
		/// <para>取消选中 - 将使用现有矢量切片服务的切片方案。 仅支持不同等级间的比例逐渐加倍且有 512 × 512 切片尺寸的切片方案。 必须在切片方案参数中指定矢量切片服务或切片方案文件。</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ServiceType { get; set; } = "true";

		/// <summary>
		/// <para>Tiling scheme</para>
		/// <para>当未选中适用于 ArcGIS Online、Bing Maps 或 Google Maps 的包参数时，要使用的矢量切片服务或切片方案文件。 切片方案尺寸必须为 512 × 512 并具有 2 倍比率的连续缩放。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? TilingScheme { get; set; }

		/// <summary>
		/// <para>Maximum Vertex Count</para>
		/// <para>输出要素类中每个面包括的理想折点数（来自所有可见图层）。 默认值为推荐的 10,000 折点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? VertexCount { get; set; } = "10000";

		#region InnerClass

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// </summary>
		public enum ServiceTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLINE")]
			ONLINE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXISTING")]
			EXISTING,

		}

#endregion
	}
}
