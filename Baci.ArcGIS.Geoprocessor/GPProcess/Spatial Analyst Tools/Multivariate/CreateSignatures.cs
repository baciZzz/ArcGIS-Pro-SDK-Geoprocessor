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
	/// <para>Create Signatures</para>
	/// <para>创建特征文件</para>
	/// <para>创建由输入样本数据和一组栅格波段定义的类的 ASCII 特征文件。</para>
	/// </summary>
	public class CreateSignatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>要创建特征文件的输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="InSampleData">
		/// <para>Input raster or feature sample data</para>
		/// <para>描绘类样本集的输入。</para>
		/// <para>该输入可以是整型栅格，或要素数据集。</para>
		/// </param>
		/// <param name="OutSignatureFile">
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </param>
		public CreateSignatures(object InRasterBands, object InSampleData, object OutSignatureFile)
		{
			this.InRasterBands = InRasterBands;
			this.InSampleData = InSampleData;
			this.OutSignatureFile = OutSignatureFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建特征文件</para>
		/// </summary>
		public override string DisplayName() => "创建特征文件";

		/// <summary>
		/// <para>Tool Name : CreateSignatures</para>
		/// </summary>
		public override string ToolName() => "CreateSignatures";

		/// <summary>
		/// <para>Tool Excute Name : sa.CreateSignatures</para>
		/// </summary>
		public override string ExcuteName() => "sa.CreateSignatures";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, InSampleData, OutSignatureFile, ComputeCovariance!, SampleField! };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>要创建特征文件的输入栅格波段。</para>
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
		/// <para>Input raster or feature sample data</para>
		/// <para>描绘类样本集的输入。</para>
		/// <para>该输入可以是整型栅格，或要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSampleData { get; set; }

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object OutSignatureFile { get; set; }

		/// <summary>
		/// <para>Compute covariance matrices</para>
		/// <para>指定除计算平均值以外是否还要计算协方差矩阵。</para>
		/// <para>选中 - 将为输入样本数据的所有类计算协方差矩阵和平均值。这是默认设置。</para>
		/// <para>未选中 - 只计算输入样本数据的所有类的平均值。</para>
		/// <para><see cref="ComputeCovarianceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ComputeCovariance { get; set; } = "true";

		/// <summary>
		/// <para>Sample field</para>
		/// <para>用来向采样位置（类）分配值的输入栅格或要素样本数据的字段。</para>
		/// <para>只有整型或字符串字段是有效字段。指定的数字或字符串将在输出特征文件中用作类名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "OID", "Text")]
		public object? SampleField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSignatures SetEnviroment(object? cellSize = null, object? cellSizeProjectionMethod = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute covariance matrices</para>
		/// </summary>
		public enum ComputeCovarianceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COVARIANCE")]
			COVARIANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MEAN_ONLY")]
			MEAN_ONLY,

		}

#endregion
	}
}
