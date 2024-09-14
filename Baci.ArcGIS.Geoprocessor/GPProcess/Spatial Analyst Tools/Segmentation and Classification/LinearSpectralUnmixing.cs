using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Linear Spectral Unmixing</para>
	/// <para>线性光谱分离</para>
	/// <para>用于执行亚像素分类和计算单个像素的不同土地覆被类型的分数丰度。</para>
	/// </summary>
	public class LinearSpectralUnmixing : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入栅格数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>输出多波段栅格数据集。</para>
		/// </param>
		/// <param name="InSpectralProfileFile">
		/// <para>Input Training Features or Spectral Profile</para>
		/// <para>不同土地覆被类的光谱信息。</para>
		/// <para>可通过以下形式提供该信息：面要素、由训练样本管理器生成的训练样本要素类、生成自训练最大似然法分类器工具的分类器定义文件 (.ecd) 或包含类光谱图的 JSON 文件 (.json)。</para>
		/// </param>
		public LinearSpectralUnmixing(object InRaster, object OutRaster, object InSpectralProfileFile)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.InSpectralProfileFile = InSpectralProfileFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 线性光谱分离</para>
		/// </summary>
		public override string DisplayName() => "线性光谱分离";

		/// <summary>
		/// <para>Tool Name : LinearSpectralUnmixing</para>
		/// </summary>
		public override string ToolName() => "LinearSpectralUnmixing";

		/// <summary>
		/// <para>Tool Excute Name : sa.LinearSpectralUnmixing</para>
		/// </summary>
		public override string ExcuteName() => "sa.LinearSpectralUnmixing";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, InSpectralProfileFile, ValueOption! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>输出多波段栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Input Training Features or Spectral Profile</para>
		/// <para>不同土地覆被类的光谱信息。</para>
		/// <para>可通过以下形式提供该信息：面要素、由训练样本管理器生成的训练样本要素类、生成自训练最大似然法分类器工具的分类器定义文件 (.ecd) 或包含类光谱图的 JSON 文件 (.json)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSpectralProfileFile { get; set; }

		/// <summary>
		/// <para>Output Value Option</para>
		/// <para>指定将如何定义输出像素值。</para>
		/// <para>总和为一—每个像素的类值都将以十进制格式提供，且所有类的总和等于 1。 例如，类 1 = 0.16；类 2 = 0.24；类 3 = 0.60。</para>
		/// <para>非负数—不会存在负输出值。</para>
		/// <para><see cref="ValueOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ValueOption { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LinearSpectralUnmixing SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Value Option</para>
		/// </summary>
		public enum ValueOptionEnum 
		{
			/// <summary>
			/// <para>总和为一—每个像素的类值都将以十进制格式提供，且所有类的总和等于 1。 例如，类 1 = 0.16；类 2 = 0.24；类 3 = 0.60。</para>
			/// </summary>
			[GPValue("SUM_TO_ONE")]
			[Description("总和为一")]
			Sum_to_one,

			/// <summary>
			/// <para>非负数—不会存在负输出值。</para>
			/// </summary>
			[GPValue("NON_NEGATIVE")]
			[Description("非负数")]
			NON_NEGATIVE,

		}

#endregion
	}
}
