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
	/// <para>Build Seamlines</para>
	/// <para>构建接缝线</para>
	/// <para>为镶嵌数据集生成或更新接缝线。接缝线用于排序重叠影像并生成更平滑的镶嵌。</para>
	/// </summary>
	public class BuildSeamlines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>选择用来构建接缝线的镶嵌数据集。</para>
		/// </param>
		public BuildSeamlines(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建接缝线</para>
		/// </summary>
		public override string DisplayName() => "构建接缝线";

		/// <summary>
		/// <para>Tool Name : BuildSeamlines</para>
		/// </summary>
		public override string ToolName() => "BuildSeamlines";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildSeamlines</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildSeamlines";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, CellSize!, SortMethod!, SortOrder!, OrderByAttribute!, OrderByBaseValue!, ViewPoint!, ComputationMethod!, BlendWidth!, BlendType!, RequestSize!, RequestSizeType!, BlendWidthUnits!, AreaOfInterest!, WhereClause!, UpdateExisting!, OutMosaicDataset!, MinRegionSize!, MinThinnessRatio!, MaxSliverSize! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>选择用来构建接缝线的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>为之后的空间分辨率范围内的栅格数据集生成接缝线。</para>
		/// <para>您可以将此参数留空，这样该工具将在适当的级别自动创建接缝线。</para>
		/// <para>此参数的单位与输入镶嵌数据集的空间参照单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Advanced Options")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Sort Method</para>
		/// <para>设置规则以确定影像重叠时用来生成接缝线的栅格。</para>
		/// <para>西北— 选择中心点与边界西北角最为接近的栅格数据集。这是默认设置。</para>
		/// <para>最接近视点— 使用“视点”工具根据用户定义的位置和栅格数据集的像底点位置选择栅格数据集。</para>
		/// <para>按属性— 根据轮廓属性表中的属性选择栅格数据集。常用属性包括采集日期、云覆盖或视角。</para>
		/// <para><see cref="SortMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SortMethod { get; set; } = "NORTH_WEST";

		/// <summary>
		/// <para>Sort Ascending</para>
		/// <para>按升序或降序排列栅格数据集。</para>
		/// <para>选中 - 按升序排列栅格。这是默认设置。</para>
		/// <para>未选中 - 按降序排列栅格。</para>
		/// <para><see cref="SortOrderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SortOrder { get; set; } = "true";

		/// <summary>
		/// <para>Sort Attribute</para>
		/// <para>使用按属性排序方法时，根据该字段对栅格数据集进行排序。默认属性为 ObjectID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Date", "OID")]
		public object? OrderByAttribute { get; set; }

		/// <summary>
		/// <para>Sort Base Value</para>
		/// <para>按该值与排序属性参数中栅格值的差值对栅格进行排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPVariant()]
		public object? OrderByBaseValue { get; set; }

		/// <summary>
		/// <para>View Point</para>
		/// <para>设置排序方法为最接近视点时所使用的坐标位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object? ViewPoint { get; set; }

		/// <summary>
		/// <para>Computation Method</para>
		/// <para>选择接缝线的构建方法。</para>
		/// <para>Geometry—根据轮廓的交集为重叠区域生成接缝线。没有重叠影像的区域将合并轮廓。这是默认设置。</para>
		/// <para>辐射测量—根据影像中要素的光谱图生成接缝线。</para>
		/// <para>复制轮廓—根据轮廓直接生成接缝线。</para>
		/// <para>复制到同级—应用来自其他镶嵌数据集的接缝线。镶嵌数据集必须位于同一组中。例如，全色波段的范围并不总是与多光谱波段的范围匹配。此方法可确保它们共享相同的接缝线。</para>
		/// <para>边缘检测—根据感兴趣区域中要素的边生成区域之间的接缝线。</para>
		/// <para>Voronoi—使用区域 Voronoi 图生成接缝线。</para>
		/// <para>差异—根据立体像对的差异图像生成接缝线。该方法可避免接缝线穿过建筑物。</para>
		/// <para>排序方法参数适用于各种计算方法。</para>
		/// <para><see cref="ComputationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComputationMethod { get; set; } = "RADIOMETRY";

		/// <summary>
		/// <para>Blend Width</para>
		/// <para>混合（羽化）发生在接缝线上有重叠栅格的像素之间。混合宽度定义要混合的像素数目。</para>
		/// <para>如果“混合宽度”值为 10，且使用全部作为混合类型，则将在接缝线的内部和外部分别混合 5 个像素。如果该值为 10，且混合类型为内部，则将在接缝线的内部混合 10 个像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Processing")]
		public object? BlendWidth { get; set; }

		/// <summary>
		/// <para>Blend Type</para>
		/// <para>确定跨接缝线混合影像的方式。可在接缝线的内部混合，在接缝线的外部混合，或分别在内部和外部混合。</para>
		/// <para>两者— 使用接缝线的任意一侧上的像素混合。例如，如果混合宽度为 10 像素，则将在接缝线的内部和外部分别混合 5 个像素。这是默认设置。</para>
		/// <para>内部—在接缝线的内部混合。</para>
		/// <para>外部—在接缝线的外部混合。</para>
		/// <para><see cref="BlendTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Processing")]
		public object? BlendType { get; set; } = "BOTH";

		/// <summary>
		/// <para>Request Size</para>
		/// <para>指定用于重采样的列数和行数。最大值为 5000。基于栅格数据的复杂程度增大或减小该值。图像分辨率越高，提供的栅格数据集信息越详细，但同时也增加了处理时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 25000000)]
		[Category("Processing")]
		public object? RequestSize { get; set; } = "1000";

		/// <summary>
		/// <para>Request Size Type</para>
		/// <para>设置请求大小的单位。</para>
		/// <para>像素—根据像素大小修改请求大小。这是默认选项，将根据栅格像素大小对最接近图像进行重采样。</para>
		/// <para>像素比例因子—通过指定比例因子修改请求大小。此选项通过将像元大小等级表中的栅格像素大小与像素大小因子相乘对最接近图像进行重采样。</para>
		/// <para><see cref="RequestSizeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Processing")]
		public object? RequestSizeType { get; set; } = "PIXELS";

		/// <summary>
		/// <para>Blend Width Units</para>
		/// <para>指定混合宽度的测量单位。</para>
		/// <para>像素—使用像素数量进行测量 这是默认设置。</para>
		/// <para>地面单位—使用与镶嵌数据集相同的单位进行测量。</para>
		/// <para><see cref="BlendWidthUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Processing")]
		public object? BlendWidthUnits { get; set; } = "PIXELS";

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>为所有与此面相交的栅格构建接缝线。要指定感兴趣区域，请浏览至要素类或创建显示的面图形。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中为特定栅格数据集构建接缝线的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Update Existing Seamlines</para>
		/// <para>更新受镶嵌数据集项目增减影响的接缝线。仅在之前已生成接缝线的情况下启用该选项，该选项使用现有排序方法和排序顺序生成接缝线。</para>
		/// <para>未选中 - 为所有项目重新生成接缝线并忽略可能存在的现有接缝线。这是默认设置。</para>
		/// <para>选中 - 仅更新没有接缝线的项目。如果新项目与之前创建的接缝线重叠，则可能影响现有接缝线。</para>
		/// <para>接缝线不存在时，将禁用该参数。</para>
		/// <para><see cref="UpdateExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateExisting { get; set; } = "false";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Minimum Region Size</para>
		/// <para>以像素为单位指定最小区域的大小。将在接缝线结果中移除小于该指定阈值的任何面。默认值为 100 像素。</para>
		/// <para>此参数值应小于定义为 (最大狭长大小) * (最大狭长大小) 的狭长面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		[Category("Advanced Options")]
		public object? MinRegionSize { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Thinness Ratio</para>
		/// <para>定义一个面要薄到怎样的程度才能被视为狭长面。它基于 0 到 1.0 之间的比例，0.0 值代表几乎为直线的面，1.0 值代表为圆的面。</para>
		/// <para>构建接缝线时将移除狭长面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Sliver Removal Options")]
		public object? MinThinnessRatio { get; set; } = "0.05";

		/// <summary>
		/// <para>Maximum Sliver Size</para>
		/// <para>指定面仍被视为狭长面时可达到的最大大小。该参数以像素为单位指定，基于请求大小而不是源栅格的空间分辨率。小于该值平方的任何面都将被视为狭长面。小于（最大狭长大小）2的任何区域将被视为狭长面。</para>
		/// <para>构建接缝线时将移除狭长面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Sliver Removal Options")]
		public object? MaxSliverSize { get; set; } = "20";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildSeamlines SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sort Method</para>
		/// </summary>
		public enum SortMethodEnum 
		{
			/// <summary>
			/// <para>西北— 选择中心点与边界西北角最为接近的栅格数据集。这是默认设置。</para>
			/// </summary>
			[GPValue("NORTH_WEST")]
			[Description("西北")]
			Northwest,

			/// <summary>
			/// <para>最接近视点— 使用“视点”工具根据用户定义的位置和栅格数据集的像底点位置选择栅格数据集。</para>
			/// </summary>
			[GPValue("CLOSEST_TO_VIEWPOINT")]
			[Description("最接近视点")]
			Closest_to_viewpoint,

			/// <summary>
			/// <para>按属性— 根据轮廓属性表中的属性选择栅格数据集。常用属性包括采集日期、云覆盖或视角。</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("按属性")]
			By_attribute,

		}

		/// <summary>
		/// <para>Sort Ascending</para>
		/// </summary>
		public enum SortOrderEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ASCENDING")]
			ASCENDING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DESCENDING")]
			DESCENDING,

		}

		/// <summary>
		/// <para>Computation Method</para>
		/// </summary>
		public enum ComputationMethodEnum 
		{
			/// <summary>
			/// <para>Geometry—根据轮廓的交集为重叠区域生成接缝线。没有重叠影像的区域将合并轮廓。这是默认设置。</para>
			/// </summary>
			[GPValue("GEOMETRY")]
			[Description("Geometry")]
			Geometry,

			/// <summary>
			/// <para>辐射测量—根据影像中要素的光谱图生成接缝线。</para>
			/// </summary>
			[GPValue("RADIOMETRY")]
			[Description("辐射测量")]
			Radiometry,

			/// <summary>
			/// <para>复制轮廓—根据轮廓直接生成接缝线。</para>
			/// </summary>
			[GPValue("COPY_FOOTPRINT")]
			[Description("复制轮廓")]
			Copy_footprint,

			/// <summary>
			/// <para>复制到同级—应用来自其他镶嵌数据集的接缝线。镶嵌数据集必须位于同一组中。例如，全色波段的范围并不总是与多光谱波段的范围匹配。此方法可确保它们共享相同的接缝线。</para>
			/// </summary>
			[GPValue("COPY_TO_SIBLING")]
			[Description("复制到同级")]
			Copy_to_sibling,

			/// <summary>
			/// <para>边缘检测—根据感兴趣区域中要素的边生成区域之间的接缝线。</para>
			/// </summary>
			[GPValue("EDGE_DETECTION")]
			[Description("边缘检测")]
			Edge_detection,

			/// <summary>
			/// <para>Voronoi—使用区域 Voronoi 图生成接缝线。</para>
			/// </summary>
			[GPValue("VORONOI")]
			[Description("Voronoi")]
			Voronoi,

			/// <summary>
			/// <para>差异—根据立体像对的差异图像生成接缝线。该方法可避免接缝线穿过建筑物。</para>
			/// </summary>
			[GPValue("DISPARITY")]
			[Description("差异")]
			Disparity,

		}

		/// <summary>
		/// <para>Blend Type</para>
		/// </summary>
		public enum BlendTypeEnum 
		{
			/// <summary>
			/// <para>两者— 使用接缝线的任意一侧上的像素混合。例如，如果混合宽度为 10 像素，则将在接缝线的内部和外部分别混合 5 个像素。这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("两者")]
			Both,

			/// <summary>
			/// <para>内部—在接缝线的内部混合。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—在接缝线的外部混合。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

		/// <summary>
		/// <para>Request Size Type</para>
		/// </summary>
		public enum RequestSizeTypeEnum 
		{
			/// <summary>
			/// <para>像素—根据像素大小修改请求大小。这是默认选项，将根据栅格像素大小对最接近图像进行重采样。</para>
			/// </summary>
			[GPValue("PIXELS")]
			[Description("像素")]
			Pixels,

			/// <summary>
			/// <para>像素比例因子—通过指定比例因子修改请求大小。此选项通过将像元大小等级表中的栅格像素大小与像素大小因子相乘对最接近图像进行重采样。</para>
			/// </summary>
			[GPValue("PIXELSIZE_FACTOR")]
			[Description("像素比例因子")]
			Pixel_scaling_factor,

		}

		/// <summary>
		/// <para>Blend Width Units</para>
		/// </summary>
		public enum BlendWidthUnitsEnum 
		{
			/// <summary>
			/// <para>像素—使用像素数量进行测量 这是默认设置。</para>
			/// </summary>
			[GPValue("PIXELS")]
			[Description("像素")]
			Pixels,

			/// <summary>
			/// <para>地面单位—使用与镶嵌数据集相同的单位进行测量。</para>
			/// </summary>
			[GPValue("GROUND_UNITS")]
			[Description("地面单位")]
			Ground_units,

		}

		/// <summary>
		/// <para>Update Existing Seamlines</para>
		/// </summary>
		public enum UpdateExistingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_EXISTING")]
			UPDATE_EXISTING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_EXISTING")]
			IGNORE_EXISTING,

		}

#endregion
	}
}
