using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Multidimensional Principal Components</para>
	/// <para>多维主成分分析</para>
	/// <para>将多维栅格转换为其主成分、负载和特征值。 该工具可将数据转换为可解释数据方差的数量减少的成分，以便轻松识别空间和时间模式。</para>
	/// </summary>
	public class MultidimensionalPrincipalComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格。</para>
		/// <para>该工具沿维度处理数据，例如时间序列栅格或由非时间维度 [X, Y, Z] 定义的数据立方体。 如果输入变量包含多个维度（例如深度和时间），则默认使用第一个维度值。</para>
		/// <para>您可以根据需要使用创建多维栅格图层工具或子集多维栅格工具重新定义多维数据，例如将多维数据配置为一维数据集。</para>
		/// </param>
		/// <param name="Mode">
		/// <para>Mode</para>
		/// <para>指定将用于执行主成分分析的方法。</para>
		/// <para>降维—输入时间序列数据将被视为一组图像。 将计算随时间提取流行模式的主成分。 这是默认设置。</para>
		/// <para>空间缩减—输入时间序列数据将被视为一组像素。 随着时间的推移提取流行模式和位置的主成分将被计算为存储在表中的一组一维数组。</para>
		/// <para><see cref="ModeEnum"/></para>
		/// </param>
		/// <param name="Dimension">
		/// <para>Dimension</para>
		/// <para>用于处理主成分的维度名称。</para>
		/// </param>
		/// <param name="OutPc">
		/// <para>Output Principal Components</para>
		/// <para>输出栅格数据集的名称。</para>
		/// <para>当模式参数指定为降维时，将输出一个组件为波段的多波段栅格。 第一个波段是具有最大特征值的第一个主成分，第二个波段是具有第二大特征值的主成分，以此类推。 输出为 CRF 文件格式 (.crf)，其中维护了多维信息。</para>
		/// <para>当模式参数指定为空间缩减时，将输出一个包含一组表示主成分的时间序列数据的表。</para>
		/// </param>
		/// <param name="OutLoadings">
		/// <para>Output Loadings</para>
		/// <para>输出将加载构成主成分的数据。</para>
		/// <para>当模式参数指定为降维时，将输出一个包含构成主成分的每个输入栅格权重的表。 这些权重定义了输入数据和输出主成分的相关性。 使用 .csv 文件扩展名将负载输出为逗号分隔值文件。</para>
		/// <para>当模式参数指定为空间缩减时，将输出的栅格中的像素值是构成主成分的权重。 像素值越高，与主成分相关性越高。 由于应用了随机重新投影以降低计算复杂度，因此输出的像元大小可能比输入栅格更大。</para>
		/// <para>输出将加载构成主成分的数据。</para>
		/// <para>当 mode 参数指定为 DIMENSION_REDUCTION 时，将输出一个包含构成主成分的每个输入栅格权重的表。 这些权重定义了输入数据和输出主成分的相关性。 使用 .csv 文件扩展名将负载输出为逗号分隔值文件。</para>
		/// <para>当 mode 参数指定为 SPATIAL_REDUCTION 时，将输出的栅格中的像素值是构成主成分的权重。 像素值越高，与主成分相关性越高。 由于应用了随机重新投影以降低计算复杂度，因此输出的像元大小可能比输入栅格更大。</para>
		/// </param>
		public MultidimensionalPrincipalComponents(object InMultidimensionalRaster, object Mode, object Dimension, object OutPc, object OutLoadings)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.Mode = Mode;
			this.Dimension = Dimension;
			this.OutPc = OutPc;
			this.OutLoadings = OutLoadings;
		}

		/// <summary>
		/// <para>Tool Display Name : 多维主成分分析</para>
		/// </summary>
		public override string DisplayName() => "多维主成分分析";

		/// <summary>
		/// <para>Tool Name : MultidimensionalPrincipalComponents</para>
		/// </summary>
		public override string ToolName() => "MultidimensionalPrincipalComponents";

		/// <summary>
		/// <para>Tool Excute Name : ia.MultidimensionalPrincipalComponents</para>
		/// </summary>
		public override string ExcuteName() => "ia.MultidimensionalPrincipalComponents";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, Mode, Dimension, OutPc, OutLoadings, OutEigenvalues!, Variable!, NumberOfPc! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格。</para>
		/// <para>该工具沿维度处理数据，例如时间序列栅格或由非时间维度 [X, Y, Z] 定义的数据立方体。 如果输入变量包含多个维度（例如深度和时间），则默认使用第一个维度值。</para>
		/// <para>您可以根据需要使用创建多维栅格图层工具或子集多维栅格工具重新定义多维数据，例如将多维数据配置为一维数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Mode</para>
		/// <para>指定将用于执行主成分分析的方法。</para>
		/// <para>降维—输入时间序列数据将被视为一组图像。 将计算随时间提取流行模式的主成分。 这是默认设置。</para>
		/// <para>空间缩减—输入时间序列数据将被视为一组像素。 随着时间的推移提取流行模式和位置的主成分将被计算为存储在表中的一组一维数组。</para>
		/// <para><see cref="ModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Mode { get; set; } = "DIMENSION_REDUCTION";

		/// <summary>
		/// <para>Dimension</para>
		/// <para>用于处理主成分的维度名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Output Principal Components</para>
		/// <para>输出栅格数据集的名称。</para>
		/// <para>当模式参数指定为降维时，将输出一个组件为波段的多波段栅格。 第一个波段是具有最大特征值的第一个主成分，第二个波段是具有第二大特征值的主成分，以此类推。 输出为 CRF 文件格式 (.crf)，其中维护了多维信息。</para>
		/// <para>当模式参数指定为空间缩减时，将输出一个包含一组表示主成分的时间序列数据的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPc { get; set; }

		/// <summary>
		/// <para>Output Loadings</para>
		/// <para>输出将加载构成主成分的数据。</para>
		/// <para>当模式参数指定为降维时，将输出一个包含构成主成分的每个输入栅格权重的表。 这些权重定义了输入数据和输出主成分的相关性。 使用 .csv 文件扩展名将负载输出为逗号分隔值文件。</para>
		/// <para>当模式参数指定为空间缩减时，将输出的栅格中的像素值是构成主成分的权重。 像素值越高，与主成分相关性越高。 由于应用了随机重新投影以降低计算复杂度，因此输出的像元大小可能比输入栅格更大。</para>
		/// <para>输出将加载构成主成分的数据。</para>
		/// <para>当 mode 参数指定为 DIMENSION_REDUCTION 时，将输出一个包含构成主成分的每个输入栅格权重的表。 这些权重定义了输入数据和输出主成分的相关性。 使用 .csv 文件扩展名将负载输出为逗号分隔值文件。</para>
		/// <para>当 mode 参数指定为 SPATIAL_REDUCTION 时，将输出的栅格中的像素值是构成主成分的权重。 像素值越高，与主成分相关性越高。 由于应用了随机重新投影以降低计算复杂度，因此输出的像元大小可能比输入栅格更大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutLoadings { get; set; }

		/// <summary>
		/// <para>Output Eigenvalues</para>
		/// <para>输出特征值表。 特征值表示每个成分的方差百分比。 特征值可帮助您定义表示数据集所需的主成分数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutEigenvalues { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>计算中使用的输入多维栅格的变量。 如果输入栅格为多维栅格且未指定变量，则默认情况下只会分析第一个变量。</para>
		/// <para>例如，要查找温度值最高的年份，请将温度指定为要分析的变量。 如果您没有指定任何变量，并且您同时拥有温度和降水量变量，则将分析这两个变量，并且输出多维栅格将包含两个变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Variable { get; set; }

		/// <summary>
		/// <para>Number of Principal Components</para>
		/// <para>要计算的主成分数，该值通常小于输入栅格数。</para>
		/// <para>此参数也采用百分比 (%) 形式。 例如，90% 值表示将计算可以解释 90% 数据方差的成分数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NumberOfPc { get; set; } = "95%";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultidimensionalPrincipalComponents SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mode</para>
		/// </summary>
		public enum ModeEnum 
		{
			/// <summary>
			/// <para>降维—输入时间序列数据将被视为一组图像。 将计算随时间提取流行模式的主成分。 这是默认设置。</para>
			/// </summary>
			[GPValue("DIMENSION_REDUCTION")]
			[Description("降维")]
			Dimension_Reduction,

			/// <summary>
			/// <para>空间缩减—输入时间序列数据将被视为一组像素。 随着时间的推移提取流行模式和位置的主成分将被计算为存储在表中的一组一维数组。</para>
			/// </summary>
			[GPValue("SPATIAL_REDUCTION")]
			[Description("空间缩减")]
			Spatial_Reduction,

		}

#endregion
	}
}
