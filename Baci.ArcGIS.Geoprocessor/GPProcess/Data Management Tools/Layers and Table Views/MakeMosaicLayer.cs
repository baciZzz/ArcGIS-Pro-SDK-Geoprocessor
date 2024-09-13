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
	/// <para>Make Mosaic Layer</para>
	/// <para>创建镶嵌图层</para>
	/// <para>根据镶嵌数据集或图层文件创建镶嵌图层。该工具创建的图层是临时图层，如果不将此图层另存为图层文件或保存地图，该图层在会话结束后将不会继续存在。</para>
	/// </summary>
	public class MakeMosaicLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>输入镶嵌数据集的路径和名称。</para>
		/// </param>
		/// <param name="OutMosaicLayer">
		/// <para>Output Mosaic Layer</para>
		/// <para>输出镶嵌图层的名称。</para>
		/// </param>
		public MakeMosaicLayer(object InMosaicDataset, object OutMosaicLayer)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutMosaicLayer = OutMosaicLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建镶嵌图层</para>
		/// </summary>
		public override string DisplayName() => "创建镶嵌图层";

		/// <summary>
		/// <para>Tool Name : MakeMosaicLayer</para>
		/// </summary>
		public override string ToolName() => "MakeMosaicLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeMosaicLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeMosaicLayer";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, OutMosaicLayer, WhereClause, Template, BandIndex, MosaicMethod, OrderField, OrderBaseValue, LockRasterid, SortOrder, MosaicOperator, CellSize, ProcessingTemplate };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>输入镶嵌数据集的路径和名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Mosaic Layer</para>
		/// <para>输出镶嵌图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object OutMosaicLayer { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>可以使用 SQL 定义查询，或者使用查询构建器构建查询。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Template Extent</para>
		/// <para>指定输出范围的方法可以是定义四个坐标，也可以是使用现有图层的范围。</para>
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
		/// <para>选择镶嵌方法。镶嵌方法定义了如何使用镶嵌数据集中的不同栅格数据来创建图层。</para>
		/// <para>最接近中心—根据栅格中心与视图中心的距离对栅格数据进行排序，与视图中心距离越近，栅格数据的次序越靠前。</para>
		/// <para>西北—根据栅格中心与西北方向的距离对栅格数据进行排序，与西北方向距离越近，栅格数据的次序越靠前。</para>
		/// <para>锁定栅格—允许用户根据 ID 或名称锁定单个或多个栅格数据的显示。选择此选项后，需要指定锁定栅格的 ID。</para>
		/// <para>按属性—根据属性字段及其与基础值的差异对栅格数据进行排序。选择此选项后，还需要设置排序字段和排序基础值参数。</para>
		/// <para>最接近像底点—根据像底点与视图中心的距离对栅格数据进行排序，像底点与视图中心的距离越近，栅格数据的次序越靠前。像底点可以不同于中心点，尤其是在倾斜的影像数据中。</para>
		/// <para>最接近视点—根据像底点与用户定义的视点之间的距离对栅格数据进行排序，像底点与视点距离越近，栅格数据的次序越靠前。</para>
		/// <para>接缝线—使用预定义的接缝线形状分割栅格，并且可以选择是否沿接边使用羽化功能。在生成接缝线的过程中对排序进行预定义。使用此镶嵌方法时，镶嵌运算符 LAST 无效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object MosaicMethod { get; set; }

		/// <summary>
		/// <para>Order Field</para>
		/// <para>选择排序字段。如果镶嵌方法为按属性，则需要设置排序栅格时所要使用的默认字段。根据服务表中类型为元数据的字段来定义字段列表。</para>
		/// <para>选择排序字段。如果镶嵌方法为 BY_ATTRIBUTE，则需要设置排序栅格时所要使用的默认字段。根据服务表中类型为元数据的字段来定义字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object OrderField { get; set; }

		/// <summary>
		/// <para>Order Base Value</para>
		/// <para>排序基础值。根据此值与指定字段中的属性值之间的差异对影像（栅格数据）进行排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object OrderBaseValue { get; set; }

		/// <summary>
		/// <para>Lock Raster ID</para>
		/// <para>应将服务锁定至的栅格 ID 或栅格名称，以便只显示指定的栅格。如果未定义，将遵循系统默认设置。可使用分号分隔的列表定义多个 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Mosaic Properties")]
		public object LockRasterid { get; set; }

		/// <summary>
		/// <para>Sort Order</para>
		/// <para>选择排序顺序是升序还是降序。</para>
		/// <para>升序—排序顺序将为升序。这是默认设置。</para>
		/// <para>降序—排序顺序将为降序。</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object SortOrder { get; set; } = "ASCENDING";

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>选择要使用的镶嵌运算符。如果两个或更多栅格具有相同的排序优先级，则可使用此参数来进一步细化排序顺序。</para>
		/// <para>First—列表中第一个栅格的次序将最为靠前。这是默认设置。</para>
		/// <para>Last—列表中最后一个栅格的次序将最为靠前。</para>
		/// <para>Minimum—值越低的栅格次序越靠前。</para>
		/// <para>Maximum—值越高的栅格次序越靠前。</para>
		/// <para>Mean—平均像素值的次序将最为靠前。</para>
		/// <para>Blend—通过对值进行融合来获得输出像元值；该融合结果依据算法得出，该算法基于权重且与重叠区域内各像素到边缘的距离相关。</para>
		/// <para>Sum—输出像元值将为所有重叠像元的聚合。</para>
		/// <para><see cref="MosaicOperatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Mosaic Properties")]
		public object MosaicOperator { get; set; } = "FIRST";

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>输出镶嵌图层的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Processing Template</para>
		/// <para>可应用于输出镶嵌图层的栅格函数处理模板。</para>
		/// <para>无—无处理模板。</para>
		/// <para><see cref="ProcessingTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ProcessingTemplate { get; set; } = "None";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeMosaicLayer SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort Order</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para>升序—排序顺序将为升序。这是默认设置。</para>
			/// </summary>
			[GPValue("ASCENDING")]
			[Description("升序")]
			Ascending,

			/// <summary>
			/// <para>降序—排序顺序将为降序。</para>
			/// </summary>
			[GPValue("DESCENDING")]
			[Description("降序")]
			Descending,

		}

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// </summary>
		public enum MosaicOperatorEnum 
		{
			/// <summary>
			/// <para>First—列表中第一个栅格的次序将最为靠前。这是默认设置。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—列表中最后一个栅格的次序将最为靠前。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Minimum—值越低的栅格次序越靠前。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—值越高的栅格次序越靠前。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Mean—平均像素值的次序将最为靠前。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Blend—通过对值进行融合来获得输出像元值；该融合结果依据算法得出，该算法基于权重且与重叠区域内各像素到边缘的距离相关。</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("Blend")]
			Blend,

			/// <summary>
			/// <para>Sum—输出像元值将为所有重叠像元的聚合。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

		}

		/// <summary>
		/// <para>Processing Template</para>
		/// </summary>
		public enum ProcessingTemplateEnum 
		{
			/// <summary>
			/// <para>无—无处理模板。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

		}

#endregion
	}
}
