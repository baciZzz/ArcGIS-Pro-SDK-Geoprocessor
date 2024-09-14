using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Overlay Layers</para>
	/// <para>叠加图层</para>
	/// <para>将多个图层中的几何叠加到一个图层中。 叠加可用于合并、擦除、修改或更新空间要素。</para>
	/// </summary>
	public class OverlayLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将与叠加图层重叠的点、线或面要素。</para>
		/// </param>
		/// <param name="OverlayLayer">
		/// <para>Overlay Layer</para>
		/// <para>将与输入图层要素重叠的要素。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="OverlayType">
		/// <para>Overlay Type</para>
		/// <para>指定要执行的叠加的类型。</para>
		/// <para>相交—将计算输入图层的几何交集。 输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。 这是默认设置。</para>
		/// <para>擦除—仅会将输入图层中与叠加图层中的要素不重叠的要素或要素的各部分写入输出。</para>
		/// <para>联合—将计算输入图层和叠加图层的几何并集。 将所有要素及其属性都写入图层。</para>
		/// <para>标识—将计算输入要素和标识要素的几何交集。 输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。</para>
		/// <para>交集取反—输入图层和叠加图层中不叠置的要素或要素的各部分将被写入到输出图层。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </param>
		public OverlayLayers(object InputLayer, object OverlayLayer, object OutputName, object OverlayType)
		{
			this.InputLayer = InputLayer;
			this.OverlayLayer = OverlayLayer;
			this.OutputName = OutputName;
			this.OverlayType = OverlayType;
		}

		/// <summary>
		/// <para>Tool Display Name : 叠加图层</para>
		/// </summary>
		public override string DisplayName() => "叠加图层";

		/// <summary>
		/// <para>Tool Name : OverlayLayers</para>
		/// </summary>
		public override string ToolName() => "OverlayLayers";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.OverlayLayers</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.OverlayLayers";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OverlayLayer, OutputName, OverlayType, IncludeOverlaps!, DataStore!, Output! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将与叠加图层重叠的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Overlay Layer</para>
		/// <para>将与输入图层要素重叠的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object OverlayLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Overlay Type</para>
		/// <para>指定要执行的叠加的类型。</para>
		/// <para>相交—将计算输入图层的几何交集。 输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。 这是默认设置。</para>
		/// <para>擦除—仅会将输入图层中与叠加图层中的要素不重叠的要素或要素的各部分写入输出。</para>
		/// <para>联合—将计算输入图层和叠加图层的几何并集。 将所有要素及其属性都写入图层。</para>
		/// <para>标识—将计算输入要素和标识要素的几何交集。 输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。</para>
		/// <para>交集取反—输入图层和叠加图层中不叠置的要素或要素的各部分将被写入到输出图层。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Include Overlapping Input Layers</para>
		/// <para>用于指定是一个还是两个输入图层具有重叠要素。 仅 ArcGIS Enterprise 10.6.1 支持此参数。</para>
		/// <para>选中 - 一个或两个图层具有重叠要素。 这是默认设置。</para>
		/// <para>未选中 - 两个图层都没有重叠要素。</para>
		/// <para><see cref="IncludeOverlapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? IncludeOverlaps { get; set; } = "true";

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。 默认设置为时空大数据存储。 在时空大数据存储中存储的所有结果都将存储在 WGS84 中。 在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayLayers SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay Type</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>相交—将计算输入图层的几何交集。 输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("相交")]
			Intersect,

			/// <summary>
			/// <para>擦除—仅会将输入图层中与叠加图层中的要素不重叠的要素或要素的各部分写入输出。</para>
			/// </summary>
			[GPValue("ERASE")]
			[Description("擦除")]
			Erase,

			/// <summary>
			/// <para>标识—将计算输入要素和标识要素的几何交集。 输入图层和叠加图层中相叠置的要素或要素的各部分将被写入到输出图层中。</para>
			/// </summary>
			[GPValue("IDENTITY")]
			[Description("标识")]
			Identity,

			/// <summary>
			/// <para>联合—将计算输入图层和叠加图层的几何并集。 将所有要素及其属性都写入图层。</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("联合")]
			Union,

			/// <summary>
			/// <para>交集取反—输入图层和叠加图层中不叠置的要素或要素的各部分将被写入到输出图层。</para>
			/// </summary>
			[GPValue("SYMMETRICAL_DIFFERENCE")]
			[Description("交集取反")]
			Symmetrical_Difference,

		}

		/// <summary>
		/// <para>Include Overlapping Input Layers</para>
		/// </summary>
		public enum IncludeOverlapsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERLAPPING")]
			OVERLAPPING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_OVERLAPPING")]
			NOT_OVERLAPPING,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
