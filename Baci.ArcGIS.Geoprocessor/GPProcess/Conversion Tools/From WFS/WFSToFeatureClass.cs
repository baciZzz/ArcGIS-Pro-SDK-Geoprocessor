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
	/// <para>WFS To Feature Class</para>
	/// <para>WFS 转要素类</para>
	/// <para>将要素类型从网络要素服务 (WFS) 导入至地理数据库中的要素类。</para>
	/// </summary>
	public class WFSToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputWFSServer">
		/// <para>WFS Server</para>
		/// <para>源 WFS 服务的 URL（例如 http://sampleserver6.arcgisonline.com/arcgis/services/SampleWorldCities/MapServer/WFSServer?）。 如果输入为复杂的 WFS 服务（已选中复杂的 WFS 服务），那么这也可以是 .xml 文件的路径。</para>
		/// </param>
		/// <param name="WFSFeatureType">
		/// <para>Select Feature Type to Extract</para>
		/// <para>从输入 WFS 服务中提取的 WFS 图层的名称。</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>输出要素类或地理数据库的位置。</para>
		/// <para>如果输入是简单的 WFS，则输出位置可以是地理数据库或地理数据库内的要素数据集。 若输出位置为要素数据集，则坐标系将从源坐标系转换为要素数据集坐标系。</para>
		/// <para>如果输入是复杂的 WFS 服务，则输出位置必须是文件夹。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Name</para>
		/// <para>输出要素类或地理数据库的名称。</para>
		/// <para>如果输入是简单的 WFS 服务，则该名称将用于在输出位置内创建要素类。 如果该地理数据库中已存在该要素类名称，则将自动递增该命名值。 默认情况下，将使用要素类型名称。</para>
		/// <para>如果输入是复杂的 WFS 服务，则该名称将用于在输出位置内创建地理数据库。</para>
		/// </param>
		public WFSToFeatureClass(object InputWFSServer, object WFSFeatureType, object OutPath, object OutName)
		{
			this.InputWFSServer = InputWFSServer;
			this.WFSFeatureType = WFSFeatureType;
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : WFS 转要素类</para>
		/// </summary>
		public override string DisplayName() => "WFS 转要素类";

		/// <summary>
		/// <para>Tool Name : WFSToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "WFSToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : conversion.WFSToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "conversion.WFSToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputWFSServer, WFSFeatureType, OutPath, OutName, OutFeatureClass!, IsComplex!, OutGdb!, MaxFeatures!, ExposeMetadata!, SwapXy!, PageSize! };

		/// <summary>
		/// <para>WFS Server</para>
		/// <para>源 WFS 服务的 URL（例如 http://sampleserver6.arcgisonline.com/arcgis/services/SampleWorldCities/MapServer/WFSServer?）。 如果输入为复杂的 WFS 服务（已选中复杂的 WFS 服务），那么这也可以是 .xml 文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputWFSServer { get; set; }

		/// <summary>
		/// <para>Select Feature Type to Extract</para>
		/// <para>从输入 WFS 服务中提取的 WFS 图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object WFSFeatureType { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>输出要素类或地理数据库的位置。</para>
		/// <para>如果输入是简单的 WFS，则输出位置可以是地理数据库或地理数据库内的要素数据集。 若输出位置为要素数据集，则坐标系将从源坐标系转换为要素数据集坐标系。</para>
		/// <para>如果输入是复杂的 WFS 服务，则输出位置必须是文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>输出要素类或地理数据库的名称。</para>
		/// <para>如果输入是简单的 WFS 服务，则该名称将用于在输出位置内创建要素类。 如果该地理数据库中已存在该要素类名称，则将自动递增该命名值。 默认情况下，将使用要素类型名称。</para>
		/// <para>如果输入是复杂的 WFS 服务，则该名称将用于在输出位置内创建地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Complex WFS service</para>
		/// <para>指定 WFS 服务器参数值是否为复杂的 WFS 服务。</para>
		/// <para>选中 - WFS 服务为复杂的 WFS 服务。</para>
		/// <para>未选中 - WFS 服务不是复杂的服务。 这是默认设置。</para>
		/// <para><see cref="IsComplexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IsComplex { get; set; } = "false";

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutGdb { get; set; }

		/// <summary>
		/// <para>Max Features</para>
		/// <para>可返回的最大要素数量。 默认值为 1000。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxFeatures { get; set; } = "1000";

		/// <summary>
		/// <para>Expose Metadata</para>
		/// <para>指定是否将根据服务创建带有元数据的表。 这仅适用于复杂的 WFS 服务。</para>
		/// <para>选中 - 将在输出地理数据库中创建元数据表。</para>
		/// <para>未选中 - 将不在输出地理数据库中创建元数据表。 这是默认设置。</para>
		/// <para><see cref="ExposeMetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExposeMetadata { get; set; } = "false";

		/// <summary>
		/// <para>Swap XY Axis Order</para>
		/// <para>指定是否将交换输出要素类的 x,y 轴顺序。 某些 WFS 服务可能在服务器端交换了 x,y 坐标的顺序，从而导致要素类显示不正确。</para>
		/// <para>选中 - 将交换 x,y 轴顺序。</para>
		/// <para>未选中 - 将不会交换 x,y 轴顺序。 这是默认设置。</para>
		/// <para><see cref="SwapXyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SwapXy { get; set; } = "false";

		/// <summary>
		/// <para>Page Size</para>
		/// <para>从 WFS 服务下载要素时将使用的页面大小。 默认值为 100。</para>
		/// <para>某些服务器会限制单次请求的要素数量，或者如果单次请求中包含大量要素，服务器性能会下降。 使用此参数可在多个页面中请求较少数量的要素，以避免服务器超时或超出最多要素限值。</para>
		/// <para>此参数仅适用于支持 startIndex 和 count WFS 参数的 WFS 2.0 服务。 对于较旧版本的 WFS（1.1.0、1.0.0），将忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? PageSize { get; set; } = "100";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WFSToFeatureClass SetEnviroment(object? configKeyword = null , object? extent = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Complex WFS service</para>
		/// </summary>
		public enum IsComplexEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPLEX")]
			COMPLEX,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_COMPLEX")]
			NOT_COMPLEX,

		}

		/// <summary>
		/// <para>Expose Metadata</para>
		/// </summary>
		public enum ExposeMetadataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPOSE_METADATA")]
			EXPOSE_METADATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EXPOSE")]
			DO_NOT_EXPOSE,

		}

		/// <summary>
		/// <para>Swap XY Axis Order</para>
		/// </summary>
		public enum SwapXyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SWAP_XY")]
			SWAP_XY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SWAP_XY")]
			DO_NOT_SWAP_XY,

		}

#endregion
	}
}
