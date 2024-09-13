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
	/// <para>Thin LAS</para>
	/// <para>稀疏化 LAS</para>
	/// <para>创建新的 LAS 文件，其中包含来自输入 LAS 数据集的 LAS 点的子集。</para>
	/// </summary>
	public class ThinLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>输出 .las 文件将要写入的现有文件夹。</para>
		/// </param>
		/// <param name="ThinningDimension">
		/// <para>Thinning Dimension</para>
		/// <para>待执行稀疏化操作的类型。</para>
		/// <para>2D—稀疏化将发生在沿 x,y 轴定义的块中。</para>
		/// <para>3D—稀疏化将发生在沿 x,y 轴的块及沿 z 轴的高度梯度所定义的空间体积中。这是默认设置。</para>
		/// <para><see cref="ThinningDimensionEnum"/></para>
		/// </param>
		/// <param name="XyResolution">
		/// <para>Target XY Resolution</para>
		/// <para>沿 x,y 轴的稀疏化块的每一边的大小。</para>
		/// </param>
		public ThinLas(object InLasDataset, object TargetFolder, object ThinningDimension, object XyResolution)
		{
			this.InLasDataset = InLasDataset;
			this.TargetFolder = TargetFolder;
			this.ThinningDimension = ThinningDimension;
			this.XyResolution = XyResolution;
		}

		/// <summary>
		/// <para>Tool Display Name : 稀疏化 LAS</para>
		/// </summary>
		public override string DisplayName() => "稀疏化 LAS";

		/// <summary>
		/// <para>Tool Name : ThinLas</para>
		/// </summary>
		public override string ToolName() => "ThinLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ThinLas</para>
		/// </summary>
		public override string ExcuteName() => "3d.ThinLas";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, TargetFolder, ThinningDimension, XyResolution, ZResolution, PointSelectionMethod, ClassCodesWeights, NameSuffix, OutLasDataset, PreservedClassCodes, PreservedFlags, PreservedReturns, ExcludedClassCodes, ExcludedFlags, ExcludedReturns, Compression, RemoveVlr, RearrangePoints, ComputeStats, OutputFolder };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>输出 .las 文件将要写入的现有文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Thinning Dimension</para>
		/// <para>待执行稀疏化操作的类型。</para>
		/// <para>2D—稀疏化将发生在沿 x,y 轴定义的块中。</para>
		/// <para>3D—稀疏化将发生在沿 x,y 轴的块及沿 z 轴的高度梯度所定义的空间体积中。这是默认设置。</para>
		/// <para><see cref="ThinningDimensionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThinningDimension { get; set; } = "3D";

		/// <summary>
		/// <para>Target XY Resolution</para>
		/// <para>沿 x,y 轴的稀疏化块的每一边的大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object XyResolution { get; set; }

		/// <summary>
		/// <para>Target Z Resolution</para>
		/// <para>使用 3D 稀疏化方法时，每个稀疏化区域的高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ZResolution { get; set; }

		/// <summary>
		/// <para>Point Selection Method</para>
		/// <para>用于确定在每个稀疏化区域保留哪些点的方法。</para>
		/// <para>最接近中心—最接近所稀疏化区域中心的 LAS 点。这是默认设置。</para>
		/// <para>类代码权重—具有被分配最大权重的类代码的 LAS 点。</para>
		/// <para>最常见类代码—具有稀疏化区域中最常见类代码值的 LAS 点。</para>
		/// <para>最低点—所稀疏化区域中的最低 LAS 点。</para>
		/// <para>最高点—所稀疏化区域中的最高 LAS 点。</para>
		/// <para>最低点和最高点—所稀疏化区域中的最高和最低 LAS 点。</para>
		/// <para>最接近平均高度—高度最接近所稀疏化区域中所有点平均高度的 LAS 点。</para>
		/// <para>最低强度—所稀疏化区域所有点中强度值最低的 LAS 点。</para>
		/// <para>最高强度—所稀疏化区域所有点中强度值最高的 LAS 点。</para>
		/// <para>最低强度和最高强度—所稀疏化区域所有点中强度值最高和最低的两个 LAS 点。</para>
		/// <para>最接近平均强度—强度值最接近所稀疏化区域中所有点平均强度值的 LAS 点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointSelectionMethod { get; set; } = "CLOSEST_TO_CENTER";

		/// <summary>
		/// <para>Input Class Codes and Weights</para>
		/// <para>赋予每个类代码的权重，用于确定在每个稀疏化区域保留哪些点。仅当在点选择方法参数中指定了类代码权重选项时才会启用该参数。具有最高权重的类代码将保留在稀疏化区域中。如果给定稀疏化区域中存在两个具有相同权重的类代码，则将保留具有最小点源 ID 的类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object ClassCodesWeights { get; set; }

		/// <summary>
		/// <para>Output File Name Suffix</para>
		/// <para>添加到每个输出文件中的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NameSuffix { get; set; } = "thinned";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>参考新创建的 .las 文件的输出 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Preserved Classes</para>
		/// <para>不会在输出 LAS 文件中对具有指定类代码值的输入 LAS 点进行稀疏化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 255)]
		[Category("Points To Preserve")]
		public object PreservedClassCodes { get; set; }

		/// <summary>
		/// <para>Preserved Flags</para>
		/// <para>具有指定类标记标识的输入 LAS 点将保留在输出 LAS 文件中。</para>
		/// <para>模型关键点—具有模型关键类标记的点将被保留。</para>
		/// <para>重叠—具有叠加类标记的点将被保留。</para>
		/// <para>合成—具有合成类标记的点将被保留。</para>
		/// <para>保留—具有保留类标记的点将被保留。</para>
		/// <para><see cref="PreservedFlagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Preserve")]
		public object PreservedFlags { get; set; }

		/// <summary>
		/// <para>Preserved Returns</para>
		/// <para>具有指定返回值的输入 LAS 点将保留在输出 LAS 文件中。</para>
		/// <para>单一回波—将包含所有单一返回点。</para>
		/// <para>最后回波—将包含所有单一回波和最后回波。</para>
		/// <para>第一个多重回波—将包含多个回波中的所有第一个返回点。</para>
		/// <para>最后一个多重回波—将包含多个回波中的所有最后一个返回点。</para>
		/// <para><see cref="PreservedReturnsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Preserve")]
		public object PreservedReturns { get; set; }

		/// <summary>
		/// <para>Excluded Classes</para>
		/// <para>具有指定类代码值的输入 LAS 点将从输出 LAS 文件中排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 255)]
		[Category("Points To Exclude")]
		public object ExcludedClassCodes { get; set; }

		/// <summary>
		/// <para>Excluded Flags</para>
		/// <para>具有指定类标记标识的输入 LAS 点将从输出 LAS 文件中排除。</para>
		/// <para>模型关键点—具有模型关键类标记的点将被排除。</para>
		/// <para>重叠—具有叠加类标记的点将被排除。</para>
		/// <para>合成—具有合成类标记的点将被排除。</para>
		/// <para>保留—具有保留类标记的点将被排除。</para>
		/// <para><see cref="ExcludedFlagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Exclude")]
		public object ExcludedFlags { get; set; }

		/// <summary>
		/// <para>Excluded Returns</para>
		/// <para>具有指定返回值的输入 LAS 点将从输出 LAS 文件中排除。</para>
		/// <para>单一回波—将排除所有单一返回点。</para>
		/// <para>最后回波—将排除所有单一回波和最后回波。</para>
		/// <para>第一个多重回波—将排除多个回波中的所有第一个返回点。</para>
		/// <para>最后一个多重回波—将排除多个回波中的所有最后一个返回点。</para>
		/// <para><see cref="ExcludedReturnsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Points To Exclude")]
		public object ExcludedReturns { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定输出 .las 文件为压缩格式还是标准 LAS 格式。</para>
		/// <para>不压缩—输出将为标准 LAS 格式（*.las 文件）。 这是默认设置。</para>
		/// <para>zLAS 压缩—输出 .las 文件将以 zLAS 格式压缩。</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object Compression { get; set; } = "NO_COMPRESSION";

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// <para>指示存储于输入 LAS 点中的可变长度记录是保留在输出 LAS 数据中，还是从中消除。</para>
		/// <para>未选中 - 可变长度记录将保留在输出 LAS 点中。这是默认设置。</para>
		/// <para>选中 - 可变长度记录将从输出 LAS 点中移除。</para>
		/// <para><see cref="RemoveVlrEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RemoveVlr { get; set; } = "false";

		/// <summary>
		/// <para>Rearrange LAS Points</para>
		/// <para>指示 LAS 点是否将存储在以空间方式组织的聚类中。</para>
		/// <para>未选中 - LAS 文件中点的顺序将保持不变。</para>
		/// <para>选中 - 将重新排列 LAS 文件中的点。这是默认设置。</para>
		/// <para><see cref="RearrangePointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RearrangePoints { get; set; } = "true";

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ThinLas SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Thinning Dimension</para>
		/// </summary>
		public enum ThinningDimensionEnum 
		{
			/// <summary>
			/// <para>2D—稀疏化将发生在沿 x,y 轴定义的块中。</para>
			/// </summary>
			[GPValue("2D")]
			[Description("2D")]
			_2D,

			/// <summary>
			/// <para>3D—稀疏化将发生在沿 x,y 轴的块及沿 z 轴的高度梯度所定义的空间体积中。这是默认设置。</para>
			/// </summary>
			[GPValue("3D")]
			[Description("3D")]
			_3D,

		}

		/// <summary>
		/// <para>Preserved Flags</para>
		/// </summary>
		public enum PreservedFlagsEnum 
		{
			/// <summary>
			/// <para>模型关键点—具有模型关键类标记的点将被保留。</para>
			/// </summary>
			[GPValue("MODEL_KEY")]
			[Description("模型关键点")]
			Model_Key,

			/// <summary>
			/// <para>重叠—具有叠加类标记的点将被保留。</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("重叠")]
			Overlap,

			/// <summary>
			/// <para>合成—具有合成类标记的点将被保留。</para>
			/// </summary>
			[GPValue("SYNTHETIC")]
			[Description("合成")]
			Synthetic,

			/// <summary>
			/// <para>保留—具有保留类标记的点将被保留。</para>
			/// </summary>
			[GPValue("WITHHELD")]
			[Description("保留")]
			Withheld,

		}

		/// <summary>
		/// <para>Preserved Returns</para>
		/// </summary>
		public enum PreservedReturnsEnum 
		{
			/// <summary>
			/// <para>单一回波—将包含所有单一返回点。</para>
			/// </summary>
			[GPValue("SINGLE")]
			[Description("单一回波")]
			Single_returns,

			/// <summary>
			/// <para>最后回波—将包含所有单一回波和最后回波。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后回波")]
			Last_returns,

			/// <summary>
			/// <para>第一个多重回波—将包含多个回波中的所有第一个返回点。</para>
			/// </summary>
			[GPValue("FIRST_OF_MANY")]
			[Description("第一个多重回波")]
			First_of_many_returns,

			/// <summary>
			/// <para>最后一个多重回波—将包含多个回波中的所有最后一个返回点。</para>
			/// </summary>
			[GPValue("LAST_OF_MANY")]
			[Description("最后一个多重回波")]
			Last_of_many_returns,

		}

		/// <summary>
		/// <para>Excluded Flags</para>
		/// </summary>
		public enum ExcludedFlagsEnum 
		{
			/// <summary>
			/// <para>模型关键点—具有模型关键类标记的点将被排除。</para>
			/// </summary>
			[GPValue("MODEL_KEY")]
			[Description("模型关键点")]
			Model_Key,

			/// <summary>
			/// <para>重叠—具有叠加类标记的点将被排除。</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("重叠")]
			Overlap,

			/// <summary>
			/// <para>合成—具有合成类标记的点将被排除。</para>
			/// </summary>
			[GPValue("SYNTHETIC")]
			[Description("合成")]
			Synthetic,

			/// <summary>
			/// <para>保留—具有保留类标记的点将被排除。</para>
			/// </summary>
			[GPValue("WITHHELD")]
			[Description("保留")]
			Withheld,

		}

		/// <summary>
		/// <para>Excluded Returns</para>
		/// </summary>
		public enum ExcludedReturnsEnum 
		{
			/// <summary>
			/// <para>单一回波—将排除所有单一返回点。</para>
			/// </summary>
			[GPValue("SINGLE")]
			[Description("单一回波")]
			Single_returns,

			/// <summary>
			/// <para>最后回波—将排除所有单一回波和最后回波。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后回波")]
			Last_returns,

			/// <summary>
			/// <para>第一个多重回波—将排除多个回波中的所有第一个返回点。</para>
			/// </summary>
			[GPValue("FIRST_OF_MANY")]
			[Description("第一个多重回波")]
			First_of_many_returns,

			/// <summary>
			/// <para>最后一个多重回波—将排除多个回波中的所有最后一个返回点。</para>
			/// </summary>
			[GPValue("LAST_OF_MANY")]
			[Description("最后一个多重回波")]
			Last_of_many_returns,

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum CompressionEnum 
		{
			/// <summary>
			/// <para>不压缩—输出将为标准 LAS 格式（*.las 文件）。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("不压缩")]
			No_Compression,

			/// <summary>
			/// <para>zLAS 压缩—输出 .las 文件将以 zLAS 格式压缩。</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS 压缩")]
			zLAS_Compression,

		}

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// </summary>
		public enum RemoveVlrEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_VLR")]
			REMOVE_VLR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_VLR")]
			MAINTAIN_VLR,

		}

		/// <summary>
		/// <para>Rearrange LAS Points</para>
		/// </summary>
		public enum RearrangePointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REARRANGE_POINTS")]
			REARRANGE_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_POINTS")]
			MAINTAIN_POINTS,

		}

		/// <summary>
		/// <para>Compute Statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

#endregion
	}
}
