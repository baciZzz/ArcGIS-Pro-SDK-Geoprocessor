using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Surface Difference</para>
	/// <para>表面差异</para>
	/// <para>计算两个表面之间的位移来确定哪个表面在上、哪个表面在下或两个表面位置相同。</para>
	/// </summary>
	public class SurfaceDifference : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>从参考表面评估其相对位移的三角化网格面。</para>
		/// </param>
		/// <param name="InReferenceSurface">
		/// <para>Reference Surface</para>
		/// <para>将作为基线用于确定输入表面相对位移的三角化网格面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含了因分类相同而划分为面的连续三角形和三角面部件的输出要素类。每个差异区域包围的体积均列于属性表中。</para>
		/// </param>
		public SurfaceDifference(object InSurface, object InReferenceSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.InReferenceSurface = InReferenceSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 表面差异</para>
		/// </summary>
		public override string DisplayName() => "表面差异";

		/// <summary>
		/// <para>Tool Name : SurfaceDifference</para>
		/// </summary>
		public override string ToolName() => "SurfaceDifference";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceDifference</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceDifference";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InReferenceSurface, OutFeatureClass, PyramidLevelResolution, ReferencePyramidLevelResolution, OutRaster, RasterCellSize, OutTinFolder, OutTinBasename, Method, ReferenceMethod, Extent, Boundary };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>从参考表面评估其相对位移的三角化网格面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Reference Surface</para>
		/// <para>将作为基线用于确定输入表面相对位移的三角化网格面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InReferenceSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含了因分类相同而划分为面的连续三角形和三角面部件的输出要素类。每个差异区域包围的体积均列于属性表中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Analysis Resolution</para>
		/// <para>将用于生成输入表面的分辨率。对于 terrain 数据集，此分辨率与其金字塔等级定义对应，其中默认值 0 表示全分辨率。对于 LAS 数据集，此值表示用于稀疏化 LAS 点回波的方形区域各边的长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Reference Analysis Resolution</para>
		/// <para>将用于生成参考表面的分辨率。对于 terrain 数据集，此分辨率与其金字塔等级定义对应，其中默认值 0 表示全分辨率。对于 LAS 数据集，此值表示用于稀疏化 LAS 点回波的方形区域各边的长度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ReferencePyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>其值代表对参考表面进行归一化的输入表面的输出栅格表面。正值反映输入表面位于参考表面之上的区域，而负值表示输入表面位于参考表面之下的区域。使用线性插值法从 TIN 获取栅格值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Raster Options")]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Raster Cell Size</para>
		/// <para>输出栅格的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 9.9999999999999995e-08)]
		[Category("Raster Options")]
		public object RasterCellSize { get; set; } = "10";

		/// <summary>
		/// <para>Output TIN Folder</para>
		/// <para>存储其值代表输入和参考表面之间差异的一个或多个 TIN 表面的文件夹位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		[Category("TIN Options")]
		public object OutTinFolder { get; set; }

		/// <summary>
		/// <para>Output TIN Base Name</para>
		/// <para>指定给每个输出 TIN 表面的基本名称。如果一个 TIN 数据不足以表示数据，则会创建多个具有相同基本名称的 TIN。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("TIN Options")]
		public object OutTinBasename { get; set; }

		/// <summary>
		/// <para>LAS Thinning Method</para>
		/// <para>在应用某一分析分辨率来稀疏化输入 LAS 数据集表面时，在每个分析窗口中选择 LAS 点所使用的方法。所生成的点将用于构建三角化网格面。</para>
		/// <para>最接近平均值—将使用值最接近分析窗口中所有 LAS 点的平均值的 LAS 点。这是默认设置。</para>
		/// <para>最小值—在分析窗口的所有 LAS 点中 z 值最小的 LAS 点。</para>
		/// <para>最大值—在分析窗口的所有 LAS 点中 z 值最高的 LAS 点。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "CLOSEST_TO_MEAN";

		/// <summary>
		/// <para>Reference LAS Thinning Method</para>
		/// <para>在应用某一分析分辨率来稀疏化输入 LAS 数据集表面时，在每个分析窗口中选择 LAS 点所使用的方法。所生成的点将用于构建三角化网格面。</para>
		/// <para>最接近平均值—将使用值最接近分析窗口中所有 LAS 点的平均值的 LAS 点。这是默认设置。</para>
		/// <para>最小值—在分析窗口的所有 LAS 点中 z 值最小的 LAS 点。</para>
		/// <para>最大值—在分析窗口的所有 LAS 点中 z 值最高的 LAS 点。</para>
		/// <para><see cref="ReferenceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReferenceMethod { get; set; } = "CLOSEST_TO_MEAN";

		/// <summary>
		/// <para>Processing Extent</para>
		/// <para>待评估数据的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Processing Extent")]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>定义将进行处理的感兴趣区域的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceDifference SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>LAS Thinning Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>最小值—在分析窗口的所有 LAS 点中 z 值最小的 LAS 点。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—在分析窗口的所有 LAS 点中 z 值最高的 LAS 点。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>最接近平均值—将使用值最接近分析窗口中所有 LAS 点的平均值的 LAS 点。这是默认设置。</para>
			/// </summary>
			[GPValue("CLOSEST_TO_MEAN")]
			[Description("最接近平均值")]
			Closest_to_mean,

		}

		/// <summary>
		/// <para>Reference LAS Thinning Method</para>
		/// </summary>
		public enum ReferenceMethodEnum 
		{
			/// <summary>
			/// <para>最小值—在分析窗口的所有 LAS 点中 z 值最小的 LAS 点。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—在分析窗口的所有 LAS 点中 z 值最高的 LAS 点。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>最接近平均值—将使用值最接近分析窗口中所有 LAS 点的平均值的 LAS 点。这是默认设置。</para>
			/// </summary>
			[GPValue("CLOSEST_TO_MEAN")]
			[Description("最接近平均值")]
			Closest_to_mean,

		}

#endregion
	}
}
