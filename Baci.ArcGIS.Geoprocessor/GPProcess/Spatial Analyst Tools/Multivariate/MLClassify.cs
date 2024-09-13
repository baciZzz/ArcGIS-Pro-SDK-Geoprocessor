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
	/// <para>Maximum Likelihood Classification</para>
	/// <para>最大似然法分类</para>
	/// <para>对一组栅格波段执行最大似然法分类并创建分类的输出栅格数据。</para>
	/// </summary>
	public class MLClassify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>虽然波段可以是整数也可以是浮点类型，但特征文件只能是整数类值。</para>
		/// </param>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>最大似然法分类器使用的特征类所属的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </param>
		/// <param name="OutClassifiedRaster">
		/// <para>Output classified raster</para>
		/// <para>输出分类的栅格。</para>
		/// <para>将为整型。</para>
		/// </param>
		public MLClassify(object InRasterBands, object InSignatureFile, object OutClassifiedRaster)
		{
			this.InRasterBands = InRasterBands;
			this.InSignatureFile = InSignatureFile;
			this.OutClassifiedRaster = OutClassifiedRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 最大似然法分类</para>
		/// </summary>
		public override string DisplayName() => "最大似然法分类";

		/// <summary>
		/// <para>Tool Name : MLClassify</para>
		/// </summary>
		public override string ToolName() => "MLClassify";

		/// <summary>
		/// <para>Tool Excute Name : sa.MLClassify</para>
		/// </summary>
		public override string ExcuteName() => "sa.MLClassify";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, InSignatureFile, OutClassifiedRaster, RejectFraction, APrioriProbabilities, InAPrioriFile, OutConfidenceRaster };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>虽然波段可以是整数也可以是浮点类型，但特征文件只能是整数类值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Input signature file</para>
		/// <para>最大似然法分类器使用的特征类所属的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Output classified raster</para>
		/// <para>输出分类的栅格。</para>
		/// <para>将为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutClassifiedRaster { get; set; }

		/// <summary>
		/// <para>Reject fraction</para>
		/// <para>选择剔除分数，该值可确定是否基于正确分配给其中一个类的像元相似度对其进行分类。在输出分类栅格中，对于正确分配给任意类的相似度低于剔除分数的像元，将为其指定 NoData 值。</para>
		/// <para>默认值为 0.0，表示将对每个像元进行分类。</para>
		/// <para>有效输入包括：</para>
		/// <para>0.0</para>
		/// <para>0.005</para>
		/// <para>0.01</para>
		/// <para>0.025</para>
		/// <para>0.05</para>
		/// <para>0.1</para>
		/// <para>0.25</para>
		/// <para>0.5</para>
		/// <para>0.75</para>
		/// <para>0.9</para>
		/// <para>0.95</para>
		/// <para>0.975</para>
		/// <para>0.99</para>
		/// <para>0.995</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RejectFraction { get; set; } = "0.0";

		/// <summary>
		/// <para>A priori probability weighting</para>
		/// <para>指定将如何确定先验概率。</para>
		/// <para>等于— 所有类将具有相同的先验概率。</para>
		/// <para>采样— 先验概率将与特征文件内所有类中采样像元总数的相关的各类的像元数成比例。</para>
		/// <para>文件—先验概率将会分配给输入 ASCII 先验概率文件中的各个类。</para>
		/// <para><see cref="APrioriProbabilitiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object APrioriProbabilities { get; set; } = "EQUAL";

		/// <summary>
		/// <para>Input a priori probability file</para>
		/// <para>包含用于输入特征类的先验概率的文本文件。</para>
		/// <para>只有在使用 File 选项时才需要先验概率文件的输入。</para>
		/// <para>先验文件的扩展名可以是 .txt 或 .asc。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object InAPrioriFile { get; set; }

		/// <summary>
		/// <para>Output confidence raster</para>
		/// <para>以 14 个置信度显示分类确定性的输出置信栅格数据集，其中，最低值表示可靠性最高。如果未在特定置信度对像元进行分类，则输出置信栅格中将不显示此置信度。</para>
		/// <para>将为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutConfidenceRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MLClassify SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>A priori probability weighting</para>
		/// </summary>
		public enum APrioriProbabilitiesEnum 
		{
			/// <summary>
			/// <para>等于— 所有类将具有相同的先验概率。</para>
			/// </summary>
			[GPValue("EQUAL")]
			[Description("等于")]
			Equal,

			/// <summary>
			/// <para>采样— 先验概率将与特征文件内所有类中采样像元总数的相关的各类的像元数成比例。</para>
			/// </summary>
			[GPValue("SAMPLE")]
			[Description("采样")]
			Sample,

			/// <summary>
			/// <para>文件—先验概率将会分配给输入 ASCII 先验概率文件中的各个类。</para>
			/// </summary>
			[GPValue("FILE")]
			[Description("文件")]
			File,

		}

#endregion
	}
}
