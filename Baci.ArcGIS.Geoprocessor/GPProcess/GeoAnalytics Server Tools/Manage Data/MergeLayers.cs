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
	/// <para>Merge Layers</para>
	/// <para>合并图层</para>
	/// <para>合并要素图层以创建单个输出图层。</para>
	/// </summary>
	public class MergeLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将与合并图层进行合并的点、线或面要素或者表格。</para>
		/// </param>
		/// <param name="MergeLayer">
		/// <para>Merge Layer</para>
		/// <para>将与输入图层进行合并的点、线或面要素或者表格。合并图层必须包含与输入图层相同的要素类型和时间类型。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		public MergeLayers(object InputLayer, object MergeLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.MergeLayer = MergeLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并图层</para>
		/// </summary>
		public override string DisplayName() => "合并图层";

		/// <summary>
		/// <para>Tool Name : MergeLayers</para>
		/// </summary>
		public override string ToolName() => "MergeLayers";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.MergeLayers</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.MergeLayers";

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
		public override object[] Parameters() => new object[] { InputLayer, MergeLayer, OutputName, MergingAttributes, Output, DataStore };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将与合并图层进行合并的点、线或面要素或者表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Merge Layer</para>
		/// <para>将与输入图层进行合并的点、线或面要素或者表格。合并图层必须包含与输入图层相同的要素类型和时间类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object MergeLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Merging Attributes</para>
		/// <para>用于描述如何修改合并图层中的字段并将其与输入图层中的字段相匹配的值列表。可以将输入图层中的所有字段写入输出图层。如果未定义合并属性，则会将合并图层中的所有字段写入输出图层。</para>
		/// <para>如果某个字段存在于一个图层中但不存在于另一个图层中，则输出图层将仍包含这两个字段。对于不含该字段的输入要素，输出字段中将包含空值。例如，如果输入图层中含有名为 TYPE 的字段，但合并图层中不含有 TYPE，则输出图层中将含有 TYPE，但从合并图层复制的所有要素的 TYPE 值均将为空。</para>
		/// <para>可以使用以下合并类型来控制将合并图层中的字段写入输出图层的方式：</para>
		/// <para>移除 - 合并图层字段将从输出图层中移除。</para>
		/// <para>重命名 - 合并图层字段将在输出中重命名。您无法将合并图层中的字段重命名为输入图层中的字段。要使字段名保持不变，请使用匹配选项。</para>
		/// <para>匹配 - 系统将重命名合并图层字段并将其与输入图层中的字段匹配。例如，输入图层中具有名为 CODE 的字段，同时合并图层中具有名为 STATUS 的字段。可将 STATUS 与 CODE 进行匹配，随后输出中将包含 CODE 字段，其中含有从合并图层复制的要素所用的 STATUS 字段值。数值支持类型转换。不支持将数值字段与字符串字段进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object MergingAttributes { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeLayers SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
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
