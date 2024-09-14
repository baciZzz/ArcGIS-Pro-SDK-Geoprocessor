using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Align Marker To Stroke Or Fill</para>
	/// <para>对齐标记</para>
	/// <para>将点要素类的标记符号图层与指定搜索距离内某个线或面要素类中最近的笔划或填充符号图层对齐。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlignMarkerToStrokeOrFill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>包含要与邻近线或面对齐的点符号的输入点要素图层。 通过在标记符号图层的已连接到角度属性的特性中存储角度来对齐符号。 必须连接到未应用表达式的单个字段。</para>
		/// </param>
		/// <param name="InLineOrPolygonFeatures">
		/// <para>Input Line or Polygon Features</para>
		/// <para>将要与输入点符号对齐的输入线或面要素图层。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>图形标记边到图形笔划或填充边之间的搜索距离。 必须指定大于或等于零的搜索距离。</para>
		/// </param>
		public AlignMarkerToStrokeOrFill(object InPointFeatures, object InLineOrPolygonFeatures, object SearchDistance)
		{
			this.InPointFeatures = InPointFeatures;
			this.InLineOrPolygonFeatures = InLineOrPolygonFeatures;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 对齐标记</para>
		/// </summary>
		public override string DisplayName() => "对齐标记";

		/// <summary>
		/// <para>Tool Name : AlignMarkerToStrokeOrFill</para>
		/// </summary>
		public override string ToolName() => "AlignMarkerToStrokeOrFill";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AlignMarkerToStrokeOrFill</para>
		/// </summary>
		public override string ExcuteName() => "cartography.AlignMarkerToStrokeOrFill";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, InLineOrPolygonFeatures, SearchDistance, MarkerOrientation!, OutRepresentations! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>包含要与邻近线或面对齐的点符号的输入点要素图层。 通过在标记符号图层的已连接到角度属性的特性中存储角度来对齐符号。 必须连接到未应用表达式的单个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Line or Polygon Features</para>
		/// <para>将要与输入点符号对齐的输入线或面要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InLineOrPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>图形标记边到图形笔划或填充边之间的搜索距离。 必须指定大于或等于零的搜索距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Marker Orientation</para>
		/// <para>指定如何相对于笔划或填充符号图层的边来定向标记符号图层。</para>
		/// <para>垂直—标记符号图层将与笔划或填充边垂直对齐。 这是默认设置。</para>
		/// <para>平行—标记符号图层将与笔划或填充边平行对齐。</para>
		/// <para><see cref="MarkerOrientationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MarkerOrientation { get; set; } = "PERPENDICULAR";

		/// <summary>
		/// <para>Updated Input Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlignMarkerToStrokeOrFill SetEnviroment(object? cartographicCoordinateSystem = null, object? cartographicPartitions = null, double? referenceScale = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Marker Orientation</para>
		/// </summary>
		public enum MarkerOrientationEnum 
		{
			/// <summary>
			/// <para>垂直—标记符号图层将与笔划或填充边垂直对齐。 这是默认设置。</para>
			/// </summary>
			[GPValue("PERPENDICULAR")]
			[Description("垂直")]
			Perpendicular,

			/// <summary>
			/// <para>平行—标记符号图层将与笔划或填充边平行对齐。</para>
			/// </summary>
			[GPValue("PARALLEL")]
			[Description("平行")]
			Parallel,

		}

#endregion
	}
}
