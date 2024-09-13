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
	/// <para>Make Image Server Layer</para>
	/// <para>创建影像服务器图层</para>
	/// <para>根据影像服务创建临时栅格图层。如果不保存文档，所创建的图层将在会话结束后消失。</para>
	/// </summary>
	public class MakeImageServerLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InImageService">
		/// <para>Input Image Service</para>
		/// <para>输入影像服务的名称或引用影像服务的 SOAP URL。浏览至某输入影像服务或键入所需的输入影像服务。此工具还支持使用引用影像服务的 SOAP URL。</para>
		/// <para>使用名为 ProjectX 的影像服务名称的示例是：C:\MyProject\ServerConnection.ags\ProjectX.ImageServer。</para>
		/// <para>下面是一个 URL 示例：http://AGSServer:8399/arcgis/services/ISName/ImageServer。</para>
		/// </param>
		/// <param name="OutImageserverLayer">
		/// <para>Output Image Server Layer</para>
		/// <para>输出影像图层的名称。</para>
		/// </param>
		public MakeImageServerLayer(object InImageService, object OutImageserverLayer)
		{
			this.InImageService = InImageService;
			this.OutImageserverLayer = OutImageserverLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建影像服务器图层</para>
		/// </summary>
		public override string DisplayName() => "创建影像服务器图层";

		/// <summary>
		/// <para>Tool Name : MakeImageServerLayer</para>
		/// </summary>
		public override string ToolName() => "MakeImageServerLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeImageServerLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeImageServerLayer";

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
		public override object[] Parameters() => new object[] { InImageService, OutImageserverLayer, Template, BandIndex, MosaicMethod, OrderField, OrderBaseValue, LockRasterid, CellSize, WhereClause, ProcessingTemplate };

		/// <summary>
		/// <para>Input Image Service</para>
		/// <para>输入影像服务的名称或引用影像服务的 SOAP URL。浏览至某输入影像服务或键入所需的输入影像服务。此工具还支持使用引用影像服务的 SOAP URL。</para>
		/// <para>使用名为 ProjectX 的影像服务名称的示例是：C:\MyProject\ServerConnection.ags\ProjectX.ImageServer。</para>
		/// <para>下面是一个 URL 示例：http://AGSServer:8399/arcgis/services/ISName/ImageServer。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InImageService { get; set; }

		/// <summary>
		/// <para>Output Image Server Layer</para>
		/// <para>输出影像图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutImageserverLayer { get; set; }

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>影像图层的输出范围。</para>
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
		/// <para>Mosaic Method</para>
		/// <para>镶嵌方法定义了如何使用不同的栅格数据来创建镶嵌数据集。</para>
		/// <para>接缝线—使用接缝线在影像间进行平滑过渡。</para>
		/// <para>西北—显示距离镶嵌数据集边界西北角最近的影像。</para>
		/// <para>中心—显示距离屏幕中心最近的影像。</para>
		/// <para>锁定栅格—选择要显示的特定栅格数据集。</para>
		/// <para>按属性—基于属性表中的字段显示影像并设置影像优先级。</para>
		/// <para>像底点—通过最接近零视角的视角范围来显示栅格。</para>
		/// <para>视点—显示距离所选视角最近的影像。</para>
		/// <para>无—根据镶嵌数据集属性表中的 ObjectID 对栅格进行排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object MosaicMethod { get; set; }

		/// <summary>
		/// <para>Order Field</para>
		/// <para>将镶嵌方法设为 By_Attribute 时用于栅格排序的默认字段。根据服务表中类型为元数据和整型的字段来定义字段列表（例如，值可以是日期或云覆盖比例）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object OrderField { get; set; }

		/// <summary>
		/// <para>Order Base Value</para>
		/// <para>根据此输入值与指定字段中的属性值之间的差异对影像进行排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object OrderBaseValue { get; set; }

		/// <summary>
		/// <para>Lock Raster ID</para>
		/// <para>将服务锁定到哪个栅格 ID 或栅格名称，以便只显示指定的栅格。如果置空（未定义），将遵循系统默认设置。可使用分号分隔的列表定义多个 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object LockRasterid { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>输出影像服务图层的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>可以使用 SQL 定义查询，或者使用查询构建器构建查询。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Processing Template</para>
		/// <para>可应用于输出影像服务图层的栅格函数处理模板。</para>
		/// <para>无—无处理模板。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ProcessingTemplate { get; set; } = "None";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeImageServerLayer SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
