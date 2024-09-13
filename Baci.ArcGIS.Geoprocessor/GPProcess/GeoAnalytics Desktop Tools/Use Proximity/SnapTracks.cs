using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Snap Tracks</para>
	/// <para>捕捉轨迹</para>
	/// <para>用于将输入轨迹点捕捉到线。 启用时间的点数据必须包含表示时刻的要素。 分析需要具有指示起始节点和终止节点的字段的可遍历线。</para>
	/// </summary>
	public class SnapTracks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPoints">
		/// <para>Input Point Layer</para>
		/// <para>将与线匹配的点。 输入必须为启用时间的点图层，用于表示时刻；并且必须包含至少一个用于标识唯一轨迹的字段。</para>
		/// </param>
		/// <param name="InputLines">
		/// <para>Input Line Layer</para>
		/// <para>点将匹配到的线。 输入必须包含其值用于指示线的起始节点和终止节点的字段。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含匹配点的要素类。</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>点与任何被视为匹配的线之间所允许存在的最大距离。 建议您使用小于或等于 75 米的值。 距离较大将导致处理时间较长且结果不够精确。</para>
		/// </param>
		/// <param name="ConnectivityFieldMatching">
		/// <para>Connectivity Field Matching</para>
		/// <para>将用于定义输入线要素的连通性的线图层字段。</para>
		/// <para>唯一 ID - 包含每个线要素的唯一 ID 值的线图层字段</para>
		/// <para>起始节点 - 包含起始节点值的线图层字段</para>
		/// <para>终止节点 - 包含终止节点值的线图层字段</para>
		/// </param>
		public SnapTracks(object InputPoints, object InputLines, object OutFeatureClass, object TrackFields, object SearchDistance, object ConnectivityFieldMatching)
		{
			this.InputPoints = InputPoints;
			this.InputLines = InputLines;
			this.OutFeatureClass = OutFeatureClass;
			this.TrackFields = TrackFields;
			this.SearchDistance = SearchDistance;
			this.ConnectivityFieldMatching = ConnectivityFieldMatching;
		}

		/// <summary>
		/// <para>Tool Display Name : 捕捉轨迹</para>
		/// </summary>
		public override string DisplayName() => "捕捉轨迹";

		/// <summary>
		/// <para>Tool Name : SnapTracks</para>
		/// </summary>
		public override string ToolName() => "SnapTracks";

		/// <summary>
		/// <para>Tool Excute Name : gapro.SnapTracks</para>
		/// </summary>
		public override string ExcuteName() => "gapro.SnapTracks";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPoints, InputLines, OutFeatureClass, TrackFields, SearchDistance, ConnectivityFieldMatching, LineFieldsToInclude!, DistanceMethod!, DirectionValueMatching!, OutputMode! };

		/// <summary>
		/// <para>Input Point Layer</para>
		/// <para>将与线匹配的点。 输入必须为启用时间的点图层，用于表示时刻；并且必须包含至少一个用于标识唯一轨迹的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPoints { get; set; }

		/// <summary>
		/// <para>Input Line Layer</para>
		/// <para>点将匹配到的线。 输入必须包含其值用于指示线的起始节点和终止节点的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InputLines { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含匹配点的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>点与任何被视为匹配的线之间所允许存在的最大距离。 建议您使用小于或等于 75 米的值。 距离较大将导致处理时间较长且结果不够精确。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Connectivity Field Matching</para>
		/// <para>将用于定义输入线要素的连通性的线图层字段。</para>
		/// <para>唯一 ID - 包含每个线要素的唯一 ID 值的线图层字段</para>
		/// <para>起始节点 - 包含起始节点值的线图层字段</para>
		/// <para>终止节点 - 包含终止节点值的线图层字段</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ConnectivityFieldMatching { get; set; }

		/// <summary>
		/// <para>Line Fields To Include</para>
		/// <para>输入线图层中将包括在输出结果中的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? LineFieldsToInclude { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>用于指定将用来计算点和线之间距离的方法。</para>
		/// <para>测地线—系统将计算测地线距离。 这是默认设置。</para>
		/// <para>平面—系统将计算平面距离。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceMethod { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Direction Value Matching</para>
		/// <para>将用于定义输入线要素的方向的线图层字段和属性值。 例如，某线图层具有一个名为 direction 的字段，其值为 T（向后）、F（向前）、B（双向）和 &quot;&quot;（无）。 如果未指定任何值，则应假定该线为双向线。</para>
		/// <para>方向字段 - 线图层中用于描述行进方向的字段。</para>
		/// <para>向前值 - 方向字段中用于指示所支持的行进方向为沿线前进的值。</para>
		/// <para>向后值 - 方向字段中用于指示所支持的行进方向为沿线后退的值。</para>
		/// <para>双向值 - 方向字段中用于指示系统同时支持沿线前进和沿线后退的行进方向的值。</para>
		/// <para>无值 - 方向字段中用于指示沿线不存在受支持的行进方向的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? DirectionValueMatching { get; set; }

		/// <summary>
		/// <para>Output Mode</para>
		/// <para>用于指定是返回所有输入要素还是仅返回与线要素匹配的输入要素。</para>
		/// <para>所有要素—系统将返回所有输入点要素，无论它们是否与线要素匹配。 这是默认设置。</para>
		/// <para>匹配要素—系统仅会返回与线要素匹配的输入点要素。</para>
		/// <para><see cref="OutputModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputMode { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SnapTracks SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>测地线—系统将计算测地线距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

			/// <summary>
			/// <para>平面—系统将计算平面距离。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

		}

		/// <summary>
		/// <para>Output Mode</para>
		/// </summary>
		public enum OutputModeEnum 
		{
			/// <summary>
			/// <para>所有要素—系统将返回所有输入点要素，无论它们是否与线要素匹配。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("所有要素")]
			All_Features,

			/// <summary>
			/// <para>匹配要素—系统仅会返回与线要素匹配的输入点要素。</para>
			/// </summary>
			[GPValue("MATCHED_FEATURES")]
			[Description("匹配要素")]
			Matched_Features,

		}

#endregion
	}
}
