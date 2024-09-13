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
	/// <para>Class Probability</para>
	/// <para>类别概率</para>
	/// <para>创建概率波段的多波段栅格，并为输入特征文件中所表示的每个类对应创建一个波段。</para>
	/// </summary>
	public class ClassProbability : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>其类特征可用于生成先验概率波段的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </param>
		/// <param name="OutMultibandRaster">
		/// <para>Output multiband raster</para>
		/// <para>输出多波段栅格数据集。</para>
		/// <para>将为整型。</para>
		/// <para>如果输出是 Esri Grid，则文件名不能超过 9 个字符。</para>
		/// </param>
		public ClassProbability(object InRasterBands, object InSignatureFile, object OutMultibandRaster)
		{
			this.InRasterBands = InRasterBands;
			this.InSignatureFile = InSignatureFile;
			this.OutMultibandRaster = OutMultibandRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 类别概率</para>
		/// </summary>
		public override string DisplayName() => "类别概率";

		/// <summary>
		/// <para>Tool Name : ClassProbability</para>
		/// </summary>
		public override string ToolName() => "ClassProbability";

		/// <summary>
		/// <para>Tool Excute Name : sa.ClassProbability</para>
		/// </summary>
		public override string ExcuteName() => "sa.ClassProbability";

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
		public override object[] Parameters() => new object[] { InRasterBands, InSignatureFile, OutMultibandRaster, MaximumOutputValue, APrioriProbabilities, InAPrioriFile };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
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
		/// <para>其类特征可用于生成先验概率波段的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Output multiband raster</para>
		/// <para>输出多波段栅格数据集。</para>
		/// <para>将为整型。</para>
		/// <para>如果输出是 Esri Grid，则文件名不能超过 9 个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultibandRaster { get; set; }

		/// <summary>
		/// <para>Maximum output value</para>
		/// <para>用于调整输出概率波段中的值范围的因子。</para>
		/// <para>默认情况下，值范围从 0 到 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MaximumOutputValue { get; set; } = "100";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassProbability SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
