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
	/// <para>Calculate Geometry Attributes</para>
	/// <para>计算几何属性</para>
	/// <para>向要素的属性字段（表示各要素的空间或几何特性以及位置）添加信息，例如长度或面积以及 x、y、z 和 m 坐标。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateGeometryAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将使用几何计算进行更新的带有字段的要素图层。</para>
		/// </param>
		/// <param name="GeometryProperty">
		/// <para>Geometry Attributes</para>
		/// <para>指定将在其中计算所选几何属性的字段。</para>
		/// <para>您可以选择现有字段或提供新的字段名称。 如果指定了新的字段名称，则字段类型将由写入该字段的值的类型确定。</para>
		/// <para>计数属性将写入长整数字段。</para>
		/// <para>面积、长度以及 x、y、z 和 m 坐标属性将写入双精度字段。</para>
		/// <para>坐标记法（例如度分秒或 MGRS）将写入文本字段。</para>
		/// <para>AREA—各个面要素的面积。</para>
		/// <para>AREA_GEODESIC—各个面要素的形状不变的测地线面积。</para>
		/// <para>CENTROID_X—各个要素的质心 x 坐标。</para>
		/// <para>CENTROID_Y—各个要素的质心 y 坐标。</para>
		/// <para>CENTROID_Z—各个要素的质心 z 坐标。</para>
		/// <para>CENTROID_M—各个要素的质心 m 坐标。</para>
		/// <para>INSIDE_X—各个要素内或各个要素上中心点的 x 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>INSIDE_Y—各个要素内或各个要素上中心点的 y 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>INSIDE_Z—各个要素内或各个要素上中心点的 z 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>INSIDE_M—各个要素内或各个要素上中心点的 m 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>CURVE_COUNT—各个要素中的曲线数量。 曲线包括椭圆弧、圆弧和贝塞尔曲线。</para>
		/// <para>HOLE_COUNT—各个面要素内的内部孔洞数量。</para>
		/// <para>EXTENT_MIN_X—各个要素范围的最小 x 坐标。</para>
		/// <para>EXTENT_MIN_Y—各个要素范围的最小 y 坐标。</para>
		/// <para>EXTENT_MIN_Z—各个要素范围的最小 z 坐标。</para>
		/// <para>EXTENT_MAX_X—各个要素范围的最大 x 坐标。</para>
		/// <para>EXTENT_MAX_Y—各个要素范围的最大 y 坐标。</para>
		/// <para>EXTENT_MAX_Z—各个要素范围的最大 z 坐标。</para>
		/// <para>LENGTH—各个线要素的长度。</para>
		/// <para>LENGTH_GEODESIC—各个线要素的形状不变的测地线长度。</para>
		/// <para>LENGTH_3D—各个线要素的 3D 长度。</para>
		/// <para>LINE_BEARING—各个线要素的起始-结束方位角。 值范围介于 0 至 360 之间，其中 0 表示北，90 表示东，180 表示南，270 表示西，以此类推。</para>
		/// <para>LINE_START_X—各个线要素起点的 x 坐标。</para>
		/// <para>LINE_START_Y—各个线要素起点的 y 坐标。</para>
		/// <para>LINE_START_Z—各个线要素起点的 z 坐标。</para>
		/// <para>LINE_START_M—各个线要素起点的 m 坐标。</para>
		/// <para>LINE_END_X—各个线要素终点的 x 坐标。</para>
		/// <para>LINE_END_Y—各个线要素终点的 y 坐标。</para>
		/// <para>LINE_END_Z—各个线要素终点的 z 坐标。</para>
		/// <para>LINE_END_M—各个线要素终点的 m 坐标。</para>
		/// <para>PART_COUNT—构成各个要素的部分数量。</para>
		/// <para>PERIMETER_LENGTH—各个面要素周长或边界长度。</para>
		/// <para>PERIMETER_LENGTH_GEODESIC—各个面要素周长或边界的形状不变的测地线长度。</para>
		/// <para>POINT_COUNT—构成各个要素的点或折点数量。</para>
		/// <para>POINT_X—各个点要素的 x 坐标。</para>
		/// <para>POINT_Y—各个点要素的 y 坐标。</para>
		/// <para>POINT_Z—各个点要素的 z 坐标。</para>
		/// <para>POINT_M—各个点要素的 m 坐标。</para>
		/// <para>POINT_COORD_NOTATION—格式化为指定坐标符号的各个点要素的 x 坐标和 y 坐标。</para>
		/// </param>
		public CalculateGeometryAttributes(object InFeatures, object GeometryProperty)
		{
			this.InFeatures = InFeatures;
			this.GeometryProperty = GeometryProperty;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算几何属性</para>
		/// </summary>
		public override string DisplayName() => "计算几何属性";

		/// <summary>
		/// <para>Tool Name : CalculateGeometryAttributes</para>
		/// </summary>
		public override string ToolName() => "CalculateGeometryAttributes";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateGeometryAttributes</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateGeometryAttributes";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, GeometryProperty, LengthUnit, AreaUnit, CoordinateSystem, UpdatedFeatures, CoordinateFormat };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将使用几何计算进行更新的带有字段的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Multipoint", "Point", "Polyline", "MultiPatch")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Geometry Attributes</para>
		/// <para>指定将在其中计算所选几何属性的字段。</para>
		/// <para>您可以选择现有字段或提供新的字段名称。 如果指定了新的字段名称，则字段类型将由写入该字段的值的类型确定。</para>
		/// <para>计数属性将写入长整数字段。</para>
		/// <para>面积、长度以及 x、y、z 和 m 坐标属性将写入双精度字段。</para>
		/// <para>坐标记法（例如度分秒或 MGRS）将写入文本字段。</para>
		/// <para>AREA—各个面要素的面积。</para>
		/// <para>AREA_GEODESIC—各个面要素的形状不变的测地线面积。</para>
		/// <para>CENTROID_X—各个要素的质心 x 坐标。</para>
		/// <para>CENTROID_Y—各个要素的质心 y 坐标。</para>
		/// <para>CENTROID_Z—各个要素的质心 z 坐标。</para>
		/// <para>CENTROID_M—各个要素的质心 m 坐标。</para>
		/// <para>INSIDE_X—各个要素内或各个要素上中心点的 x 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>INSIDE_Y—各个要素内或各个要素上中心点的 y 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>INSIDE_Z—各个要素内或各个要素上中心点的 z 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>INSIDE_M—各个要素内或各个要素上中心点的 m 坐标。 如果质心位于要素内，则此点与质心相同，否则，此点为内标记点。</para>
		/// <para>CURVE_COUNT—各个要素中的曲线数量。 曲线包括椭圆弧、圆弧和贝塞尔曲线。</para>
		/// <para>HOLE_COUNT—各个面要素内的内部孔洞数量。</para>
		/// <para>EXTENT_MIN_X—各个要素范围的最小 x 坐标。</para>
		/// <para>EXTENT_MIN_Y—各个要素范围的最小 y 坐标。</para>
		/// <para>EXTENT_MIN_Z—各个要素范围的最小 z 坐标。</para>
		/// <para>EXTENT_MAX_X—各个要素范围的最大 x 坐标。</para>
		/// <para>EXTENT_MAX_Y—各个要素范围的最大 y 坐标。</para>
		/// <para>EXTENT_MAX_Z—各个要素范围的最大 z 坐标。</para>
		/// <para>LENGTH—各个线要素的长度。</para>
		/// <para>LENGTH_GEODESIC—各个线要素的形状不变的测地线长度。</para>
		/// <para>LENGTH_3D—各个线要素的 3D 长度。</para>
		/// <para>LINE_BEARING—各个线要素的起始-结束方位角。 值范围介于 0 至 360 之间，其中 0 表示北，90 表示东，180 表示南，270 表示西，以此类推。</para>
		/// <para>LINE_START_X—各个线要素起点的 x 坐标。</para>
		/// <para>LINE_START_Y—各个线要素起点的 y 坐标。</para>
		/// <para>LINE_START_Z—各个线要素起点的 z 坐标。</para>
		/// <para>LINE_START_M—各个线要素起点的 m 坐标。</para>
		/// <para>LINE_END_X—各个线要素终点的 x 坐标。</para>
		/// <para>LINE_END_Y—各个线要素终点的 y 坐标。</para>
		/// <para>LINE_END_Z—各个线要素终点的 z 坐标。</para>
		/// <para>LINE_END_M—各个线要素终点的 m 坐标。</para>
		/// <para>PART_COUNT—构成各个要素的部分数量。</para>
		/// <para>PERIMETER_LENGTH—各个面要素周长或边界长度。</para>
		/// <para>PERIMETER_LENGTH_GEODESIC—各个面要素周长或边界的形状不变的测地线长度。</para>
		/// <para>POINT_COUNT—构成各个要素的点或折点数量。</para>
		/// <para>POINT_X—各个点要素的 x 坐标。</para>
		/// <para>POINT_Y—各个点要素的 y 坐标。</para>
		/// <para>POINT_Z—各个点要素的 z 坐标。</para>
		/// <para>POINT_M—各个点要素的 m 坐标。</para>
		/// <para>POINT_COORD_NOTATION—格式化为指定坐标符号的各个点要素的 x 坐标和 y 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object GeometryProperty { get; set; }

		/// <summary>
		/// <para>Length Unit</para>
		/// <para>指定将用于计算长度的单位。</para>
		/// <para>英尺（美国）—长度单位将为英尺（美国）。</para>
		/// <para>米—长度单位将为米。</para>
		/// <para>千米—长度单位将为千米。</para>
		/// <para>英里（美国）—长度单位将为英里（美国）。</para>
		/// <para>海里（美国）—长度单位将为海里（美国）。</para>
		/// <para>码（美国）—长度单位将为码（美国）。</para>
		/// <para><see cref="LengthUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LengthUnit { get; set; }

		/// <summary>
		/// <para>Area Unit</para>
		/// <para>指定将用于计算面积的单位。</para>
		/// <para>英亩—面积单位将为英亩。</para>
		/// <para>公顷—面积单位将为公顷。</para>
		/// <para>平方英里（美国）—面积单位将为平方英里（美国）。</para>
		/// <para>平方千米—面积单位将为平方千米。</para>
		/// <para>平方米—面积单位将为平方米。</para>
		/// <para>平方英尺（美国）—面积单位将为平方英尺（美国）。</para>
		/// <para>平方码（美国）—面积单位将为平方码（美国）。</para>
		/// <para>平方海里（美国）—面积单位将为平方海里（美国）。</para>
		/// <para><see cref="AreaUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnit { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>用于计算坐标、长度和面积的坐标系。 默认使用输入要素的坐标系。</para>
		/// <para>对于基于坐标的几何属性，仅当坐标格式与输入相同时才应用坐标系；否则，将使用地理坐标系 WGS84。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Coordinate Format</para>
		/// <para>指定将用于计算 x 和 y 坐标的坐标格式。 默认情况下，将使用与输入要素的空间参考单位匹配的坐标格式。</para>
		/// <para>包括“度分秒”、“十进制度分”等在内的多种坐标格式需要在文本字段中执行计算。</para>
		/// <para>与输入相同—输入要素的空间参考单位将用于坐标格式化。 这是默认设置。</para>
		/// <para>十进制度—十进制度。</para>
		/// <para>度分秒 (DDD° MM&apos; SSS.ss&quot; &lt;N|S|E|W&gt;)—末尾带有主方向分量的度分秒 (DDD° MM&apos; SSS.ss&quot; &lt;N|S|E|W&gt;)。</para>
		/// <para>度分秒 (&lt;N|S|E|W&gt; DDD° MM&apos; SSS.ss&quot;)—开头带有主方向分量的度分秒 (&lt;N|S|E|W&gt; DDD° MM&apos; SSS.ss&quot;)。</para>
		/// <para>度分秒 (&lt;+|-&gt; DDD° MM&apos; SSS.ss&quot;)—开头带有正或负方向分量的度分秒 (&lt;+|-&gt; DDD° MM&apos; SSS.ss&quot;)。</para>
		/// <para>度分秒 (&lt;+|-&gt; DDD.MMSSSss)—被打包成单个值的、开头带有正或负方向分量的度分秒 (&lt;+|-&gt; DDD.MMSSSss)。</para>
		/// <para>十进制度分 (DDD° MM.mmm&apos; &lt;N|S|E|W&gt;)—末尾带有主方向分量的十进制度分 (DDD° MM.mmm&apos; &lt;N|S|E|W&gt;)。</para>
		/// <para>十进制度分 (&lt;N|S|E|W&gt; DDD° MM.mmm&apos;)—开头带有主方向分量的十进制度分 (&lt;N|S|E|W&gt; DDD° MM.mmm&apos;)。</para>
		/// <para>十进制度分 (&lt;+|-&gt; DDD° MM.mmm&apos;)—开头带有正或负方向分量的十进制度分 (&lt;+|-&gt; DDD° MM.mmm&apos;)。</para>
		/// <para>GARS（全球区域参考系）—全球区域参考系基于纬度和经度，将世界划分和细分为多个像元。</para>
		/// <para>GEOREF（世界地理参考系）—世界地理参考系基于由纬度和经度构成的地理系统，并且使用了一种更为简单、灵活的符号。</para>
		/// <para>MGRS（军事格网参考系）—军事格网参考系。</para>
		/// <para>USNG（美国国家格网）—美国国家格网。</para>
		/// <para>UTM（通用横轴墨卡托）—通用横轴墨卡托投影。</para>
		/// <para>没有空格的 UTM—没有空格的通用横轴墨卡托。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CoordinateFormat { get; set; } = "SAME_AS_INPUT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateGeometryAttributes SetEnviroment(object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Length Unit</para>
		/// </summary>
		public enum LengthUnitEnum 
		{
			/// <summary>
			/// <para>英尺（美国）—长度单位将为英尺（美国）。</para>
			/// </summary>
			[GPValue("FEET_US")]
			[Description("英尺（美国）")]
			FEET_US,

			/// <summary>
			/// <para>米—长度单位将为米。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>码（美国）—长度单位将为码（美国）。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码（美国）")]
			YARDS,

			/// <summary>
			/// <para>千米—长度单位将为千米。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英里（美国）—长度单位将为英里（美国）。</para>
			/// </summary>
			[GPValue("MILES_US")]
			[Description("英里（美国）")]
			MILES_US,

			/// <summary>
			/// <para>海里（美国）—长度单位将为海里（美国）。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("海里（美国）")]
			NAUTICAL_MILES,

		}

		/// <summary>
		/// <para>Area Unit</para>
		/// </summary>
		public enum AreaUnitEnum 
		{
			/// <summary>
			/// <para>英亩—面积单位将为英亩。</para>
			/// </summary>
			[GPValue("ACRES")]
			[Description("英亩")]
			Acres,

			/// <summary>
			/// <para>公顷—面积单位将为公顷。</para>
			/// </summary>
			[GPValue("HECTARES")]
			[Description("公顷")]
			Hectares,

			/// <summary>
			/// <para>平方英里（美国）—面积单位将为平方英里（美国）。</para>
			/// </summary>
			[GPValue("SQUARE_MILES_US")]
			[Description("平方英里（美国）")]
			SQUARE_MILES_US,

			/// <summary>
			/// <para>平方千米—面积单位将为平方千米。</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("平方千米")]
			Square_kilometers,

			/// <summary>
			/// <para>平方米—面积单位将为平方米。</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_meters,

			/// <summary>
			/// <para>平方英尺（美国）—面积单位将为平方英尺（美国）。</para>
			/// </summary>
			[GPValue("SQUARE_FEET_US")]
			[Description("平方英尺（美国）")]
			SQUARE_FEET_US,

			/// <summary>
			/// <para>平方码（美国）—面积单位将为平方码（美国）。</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("平方码（美国）")]
			SQUARE_YARDS,

			/// <summary>
			/// <para>平方海里（美国）—面积单位将为平方海里（美国）。</para>
			/// </summary>
			[GPValue("SQUARE_NAUTICAL_MILES")]
			[Description("平方海里（美国）")]
			SQUARE_NAUTICAL_MILES,

		}

#endregion
	}
}
