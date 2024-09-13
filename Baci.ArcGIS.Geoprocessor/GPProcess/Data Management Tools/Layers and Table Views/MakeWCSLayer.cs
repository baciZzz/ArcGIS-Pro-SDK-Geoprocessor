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
	/// <para>Make WCS Layer</para>
	/// <para>创建 WCS 图层</para>
	/// <para>利用 WCS 服务创建临时栅格图层。</para>
	/// </summary>
	public class MakeWCSLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWcsCoverage">
		/// <para>Input WCS Coverage</para>
		/// <para>浏览至输入 WCS 服务。此工具还支持使用引用 WCS 服务的 URL。</para>
		/// <para>如果使用 WCS 服务器 URL，URL 应包含 coverage 名称和版本信息。如果仅输入 URL，则该工具将自动采用第一个 coverage 并使用默认版本 (1.0.0) 创建 WCS 图层。</para>
		/// <para>以下为包含 coverage 名称和版本的 URL 示例：http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?coverage=rasterDRGs&amp;version=1.1.1。</para>
		/// <para>在此例中，http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer? 为 URL。指定的 coverage 为 coverage=rasterDRGs，版本为 &amp;version=1.1.1。</para>
		/// <para>要获取 WCS 服务器上的 coverage 名称，可使用 WCS GetCapabilities 请求。下面是一个 WCS 请求示例：http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?request=getcapabilities&amp;service=wcs。</para>
		/// </param>
		/// <param name="OutWcsLayer">
		/// <para>Output WCS Layer</para>
		/// <para>输出 WCS 图层的名称。</para>
		/// </param>
		public MakeWCSLayer(object InWcsCoverage, object OutWcsLayer)
		{
			this.InWcsCoverage = InWcsCoverage;
			this.OutWcsLayer = OutWcsLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 WCS 图层</para>
		/// </summary>
		public override string DisplayName() => "创建 WCS 图层";

		/// <summary>
		/// <para>Tool Name : MakeWCSLayer</para>
		/// </summary>
		public override string ToolName() => "MakeWCSLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeWCSLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeWCSLayer";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWcsCoverage, OutWcsLayer, Template, BandIndex };

		/// <summary>
		/// <para>Input WCS Coverage</para>
		/// <para>浏览至输入 WCS 服务。此工具还支持使用引用 WCS 服务的 URL。</para>
		/// <para>如果使用 WCS 服务器 URL，URL 应包含 coverage 名称和版本信息。如果仅输入 URL，则该工具将自动采用第一个 coverage 并使用默认版本 (1.0.0) 创建 WCS 图层。</para>
		/// <para>以下为包含 coverage 名称和版本的 URL 示例：http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?coverage=rasterDRGs&amp;version=1.1.1。</para>
		/// <para>在此例中，http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer? 为 URL。指定的 coverage 为 coverage=rasterDRGs，版本为 &amp;version=1.1.1。</para>
		/// <para>要获取 WCS 服务器上的 coverage 名称，可使用 WCS GetCapabilities 请求。下面是一个 WCS 请求示例：http://ServerName/arcgis/services/serviceName/ImageServer/WCSServer?request=getcapabilities&amp;service=wcs。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWcsCoverage { get; set; }

		/// <summary>
		/// <para>Output WCS Layer</para>
		/// <para>输出 WCS 图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutWcsLayer { get; set; }

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>WCS 图层的输出范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Bands</para>
		/// <para>选择要为图层输出哪些波段。 如果未指定波段，则输出中将使用所有波段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object BandIndex { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeWCSLayer SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
