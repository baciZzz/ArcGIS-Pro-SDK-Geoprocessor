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
	/// <para>Flow Accumulation</para>
	/// <para>流量</para>
	/// <para>创建每个像元累积流量的栅格。 可选择性应用权重系数。</para>
	/// </summary>
	public class FlowAccumulation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以使用流向工具创建流向栅格。</para>
		/// <para>可使用 D8、多流向 (MFD) 或 D-Infinity 方法创建流向栅格。 可以使用输入流向类型参数来指定创建流向栅格时所使用的方法。</para>
		/// </param>
		/// <param name="OutAccumulationRaster">
		/// <para>Output accumulation raster</para>
		/// <para>显示每个像元累积流量的输出栅格。</para>
		/// </param>
		public FlowAccumulation(object InFlowDirectionRaster, object OutAccumulationRaster)
		{
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutAccumulationRaster = OutAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 流量</para>
		/// </summary>
		public override string DisplayName() => "流量";

		/// <summary>
		/// <para>Tool Name : FlowAccumulation</para>
		/// </summary>
		public override string ToolName() => "FlowAccumulation";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowAccumulation</para>
		/// </summary>
		public override string ExcuteName() => "sa.FlowAccumulation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFlowDirectionRaster, OutAccumulationRaster, InWeightRaster!, DataType!, FlowDirectionType! };

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以使用流向工具创建流向栅格。</para>
		/// <para>可使用 D8、多流向 (MFD) 或 D-Infinity 方法创建流向栅格。 可以使用输入流向类型参数来指定创建流向栅格时所使用的方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output accumulation raster</para>
		/// <para>显示每个像元累积流量的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>对每一像元应用权重的可选输入栅格。</para>
		/// <para>如果未指定权重栅格，则将默认的权重值 1 应用于每个像元。 对于输出栅格中的每个像元，结果将是流入其中的像元数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InWeightRaster { get; set; }

		/// <summary>
		/// <para>Output data type</para>
		/// <para>输出累积栅格可以是整型、浮点型或双精度型。</para>
		/// <para>浮点型—输出栅格将为浮点型。这是默认设置。</para>
		/// <para>整型—输出栅格将为整型。</para>
		/// <para>双精度型—输出栅格将为双精度型。</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "FLOAT";

		/// <summary>
		/// <para>Input flow direction type</para>
		/// <para>指定输入流向栅格类型。</para>
		/// <para>D8—输入流向栅格为 D8 类型。 这是默认设置。</para>
		/// <para>MFD—输入流向栅格为多流向 (MFD) 类型。</para>
		/// <para>DINF—输入流向栅格为 D-Infinity (DINF) 类型。</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlowDirectionType { get; set; } = "D8";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowAccumulation SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>浮点型—输出栅格将为浮点型。这是默认设置。</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("浮点型")]
			Float,

			/// <summary>
			/// <para>整型—输出栅格将为整型。</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("整型")]
			Integer,

			/// <summary>
			/// <para>双精度型—输出栅格将为双精度型。</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度型")]
			Double,

		}

		/// <summary>
		/// <para>Input flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>D8—输入流向栅格为 D8 类型。 这是默认设置。</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>DINF—输入流向栅格为 D-Infinity (DINF) 类型。</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

#endregion
	}
}
