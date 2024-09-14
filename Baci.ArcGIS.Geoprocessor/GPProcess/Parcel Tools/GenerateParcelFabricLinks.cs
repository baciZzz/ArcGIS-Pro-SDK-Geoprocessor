using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Generate Parcel Fabric Links</para>
	/// <para>生成宗地结构链接</para>
	/// <para>为在指定时间段内更改位置的宗地结构点生成位移链接。</para>
	/// </summary>
	public class GenerateParcelFabricLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将用于生成链接的宗地结构。必须将宗地结构发布为要素服务，且将使用默认版本生成链接。</para>
		/// </param>
		/// <param name="OutLinksFeatureClass">
		/// <para>Output Links Feature Class</para>
		/// <para>将存储所生成链接的输出线要素类。</para>
		/// </param>
		/// <param name="OutAnchorPointsFeatureClass">
		/// <para>Output Anchor Points Feature Class</para>
		/// <para>将存储锚点的输出点要素类。</para>
		/// </param>
		/// <param name="FromDate">
		/// <para>From Date</para>
		/// <para>在宗地结构中搜索已更改位置的点的日期。系统将仅针对该日期或该日期之后的点生成链接和锚点。</para>
		/// </param>
		public GenerateParcelFabricLinks(object TargetParcelFabric, object OutLinksFeatureClass, object OutAnchorPointsFeatureClass, object FromDate)
		{
			this.TargetParcelFabric = TargetParcelFabric;
			this.OutLinksFeatureClass = OutLinksFeatureClass;
			this.OutAnchorPointsFeatureClass = OutAnchorPointsFeatureClass;
			this.FromDate = FromDate;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成宗地结构链接</para>
		/// </summary>
		public override string DisplayName() => "生成宗地结构链接";

		/// <summary>
		/// <para>Tool Name : GenerateParcelFabricLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateParcelFabricLinks";

		/// <summary>
		/// <para>Tool Excute Name : parcel.GenerateParcelFabricLinks</para>
		/// </summary>
		public override string ExcuteName() => "parcel.GenerateParcelFabricLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetParcelFabric, OutLinksFeatureClass, OutAnchorPointsFeatureClass, FromDate, ToDate, MinLinkLength, Extent };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将用于生成链接的宗地结构。必须将宗地结构发布为要素服务，且将使用默认版本生成链接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object TargetParcelFabric { get; set; }

		/// <summary>
		/// <para>Output Links Feature Class</para>
		/// <para>将存储所生成链接的输出线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Line")]
		public object OutLinksFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Anchor Points Feature Class</para>
		/// <para>将存储锚点的输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object OutAnchorPointsFeatureClass { get; set; }

		/// <summary>
		/// <para>From Date</para>
		/// <para>在宗地结构中搜索已更改位置的点的日期。系统将仅针对该日期或该日期之后的点生成链接和锚点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object FromDate { get; set; }

		/// <summary>
		/// <para>To Date</para>
		/// <para>在宗地结构中搜索已更改位置的点的时间段的结束日期。系统将仅针对该日期或该日期之前的点生成链接和锚点。如果未指定“结束日期”，则系统将为指定开始日期或该日期之后的所有点生成链接和锚点。如果将结束日期指定为某个未来的日期，则系统将在开始日期与当前日期和时间之间的时间段内生成链接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ToDate { get; set; }

		/// <summary>
		/// <para>Minimum Link Length</para>
		/// <para>所生成链接的最小长度。如果当前点与其原始位置之间的链接长度小于指定的值，则系统会为该点的原始位置创建锚点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinLinkLength { get; set; } = "0.01 Meters";

		/// <summary>
		/// <para>Extent</para>
		/// <para>要处理的数据集的范围。仅会处理指定范围内的要素。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

	}
}
