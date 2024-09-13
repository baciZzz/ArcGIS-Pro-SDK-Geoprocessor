using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Create Space Time Cube From Multidimensional Raster Layer</para>
	/// <para>通过多维栅格图层创建时空立方体</para>
	/// <para>根据多维栅格图层创建时空立方体，并将数据构造为时空立方图格，以进行有效的空间-时间分析和可视化。</para>
	/// </summary>
	public class CreateSpaceTimeCubeMDRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMdRaster">
		/// <para>Input Multidimensional Raster Layer</para>
		/// <para>将转换为时空立方体的输入多维栅格图层。</para>
		/// </param>
		/// <param name="OutputCube">
		/// <para>Output Space Time Cube</para>
		/// <para>将创建的输出 netCDF 数据立方体。</para>
		/// </param>
		public CreateSpaceTimeCubeMDRasterLayer(object InMdRaster, object OutputCube)
		{
			this.InMdRaster = InMdRaster;
			this.OutputCube = OutputCube;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过多维栅格图层创建时空立方体</para>
		/// </summary>
		public override string DisplayName() => "通过多维栅格图层创建时空立方体";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCubeMDRasterLayer</para>
		/// </summary>
		public override string ToolName() => "CreateSpaceTimeCubeMDRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CreateSpaceTimeCubeMDRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "stpm.CreateSpaceTimeCubeMDRasterLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMdRaster, OutputCube, FillEmptyBins };

		/// <summary>
		/// <para>Input Multidimensional Raster Layer</para>
		/// <para>将转换为时空立方体的输入多维栅格图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InMdRaster { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>将创建的输出 netCDF 数据立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Fill Empty Bins Method</para>
		/// <para>指定如何填充输出时空立方体中的缺失值。输出中的每个时空立方图格必须具有一个值，因此必须选择使用 NoData 值填充栅格像元的值的方式。</para>
		/// <para>零—空立方图格将使用零进行填充。这是默认设置。</para>
		/// <para>空间相邻要素—空立方图格将使用空间相邻要素的平均值进行填充。</para>
		/// <para>时空相邻要素—空立方图格将使用时空相邻要素的平均值进行填充。</para>
		/// <para>时间趋势—空立方图格将使用一元样条插值算法进行填充。</para>
		/// <para><see cref="FillEmptyBinsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FillEmptyBins { get; set; } = "ZEROS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCubeMDRasterLayer SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fill Empty Bins Method</para>
		/// </summary>
		public enum FillEmptyBinsEnum 
		{
			/// <summary>
			/// <para>零—空立方图格将使用零进行填充。这是默认设置。</para>
			/// </summary>
			[GPValue("ZEROS")]
			[Description("零")]
			Zeros,

			/// <summary>
			/// <para>空间相邻要素—空立方图格将使用空间相邻要素的平均值进行填充。</para>
			/// </summary>
			[GPValue("SPATIAL_NEIGHBORS")]
			[Description("空间相邻要素")]
			Spatial_neighbors,

			/// <summary>
			/// <para>时空相邻要素—空立方图格将使用时空相邻要素的平均值进行填充。</para>
			/// </summary>
			[GPValue("SPACE_TIME_NEIGHBORS")]
			[Description("时空相邻要素")]
			SPACE_TIME_NEIGHBORS,

			/// <summary>
			/// <para>时间趋势—空立方图格将使用一元样条插值算法进行填充。</para>
			/// </summary>
			[GPValue("TEMPORAL_TREND")]
			[Description("时间趋势")]
			Temporal_trend,

		}

#endregion
	}
}
