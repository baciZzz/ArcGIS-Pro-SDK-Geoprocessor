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
	/// <para>Flow Length</para>
	/// <para>水流长度</para>
	/// <para>计算沿每个像元的流路径的上游(或下游)距离或加权距离。</para>
	/// </summary>
	public class FlowLength : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以使用流向 工具创建流向栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>显示每个像元的沿流路径的上游或下游距离的输出栅格。</para>
		/// </param>
		public FlowLength(object InFlowDirectionRaster, object OutRaster)
		{
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 水流长度</para>
		/// </summary>
		public override string DisplayName() => "水流长度";

		/// <summary>
		/// <para>Tool Name : FlowLength</para>
		/// </summary>
		public override string ToolName() => "FlowLength";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowLength</para>
		/// </summary>
		public override string ExcuteName() => "sa.FlowLength";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFlowDirectionRaster, OutRaster, DirectionMeasurement, InWeightRaster };

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以使用流向 工具创建流向栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>显示每个像元的沿流路径的上游或下游距离的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Direction of measurement</para>
		/// <para>沿流路径的度量方向。</para>
		/// <para>下游—计算沿流路径从每个像元到栅格边上的汇点或出水口的下坡距离。</para>
		/// <para>上游—计算沿流路径从每个像元到分水岭顶部的最长上坡距离。</para>
		/// <para><see cref="DirectionMeasurementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DirectionMeasurement { get; set; } = "DOWNSTREAM";

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>对每一像元应用权重的可选输入栅格。</para>
		/// <para>如果未指定权重栅格，则将默认的权重值 1 应用于每个像元。对于输出栅格中的每个像元，结果为流入其中的像元数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowLength SetEnviroment(int? autoCommit = null, object cellSize = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Direction of measurement</para>
		/// </summary>
		public enum DirectionMeasurementEnum 
		{
			/// <summary>
			/// <para>下游—计算沿流路径从每个像元到栅格边上的汇点或出水口的下坡距离。</para>
			/// </summary>
			[GPValue("DOWNSTREAM")]
			[Description("下游")]
			Downstream,

			/// <summary>
			/// <para>上游—计算沿流路径从每个像元到分水岭顶部的最长上坡距离。</para>
			/// </summary>
			[GPValue("UPSTREAM")]
			[Description("上游")]
			Upstream,

		}

#endregion
	}
}
