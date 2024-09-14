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
	/// <para>Stream Order</para>
	/// <para>河网分级</para>
	/// <para>为表示线状网络分支的栅格线段指定数值顺序。</para>
	/// </summary>
	public class StreamOrder : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStreamRaster">
		/// <para>Input stream raster</para>
		/// <para>表示线性河流网络的输入栅格。</para>
		/// <para>在 NoData 的背景上，输入河流栅格数据线状网络应表示为大于或等于一的值。</para>
		/// </param>
		/// <param name="InFlowDirectionRaster">
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以在流向工具中，运行使用默认流向类型 D8 创建流向栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出河网分级栅格数据。</para>
		/// <para>输出为整型。</para>
		/// </param>
		public StreamOrder(object InStreamRaster, object InFlowDirectionRaster, object OutRaster)
		{
			this.InStreamRaster = InStreamRaster;
			this.InFlowDirectionRaster = InFlowDirectionRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 河网分级</para>
		/// </summary>
		public override string DisplayName() => "河网分级";

		/// <summary>
		/// <para>Tool Name : StreamOrder</para>
		/// </summary>
		public override string ToolName() => "StreamOrder";

		/// <summary>
		/// <para>Tool Excute Name : sa.StreamOrder</para>
		/// </summary>
		public override string ExcuteName() => "sa.StreamOrder";

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
		public override object[] Parameters() => new object[] { InStreamRaster, InFlowDirectionRaster, OutRaster, OrderMethod };

		/// <summary>
		/// <para>Input stream raster</para>
		/// <para>表示线性河流网络的输入栅格。</para>
		/// <para>在 NoData 的背景上，输入河流栅格数据线状网络应表示为大于或等于一的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InStreamRaster { get; set; }

		/// <summary>
		/// <para>Input flow direction raster</para>
		/// <para>根据每个像元来显示流向的输入栅格。</para>
		/// <para>可以在流向工具中，运行使用默认流向类型 D8 创建流向栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出河网分级栅格数据。</para>
		/// <para>输出为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Method of stream ordering</para>
		/// <para>用于指定河网分级的方法。</para>
		/// <para>放射状/发射状—此河网分级方法由 Strahler 于 1952 年提出。仅当级别相同的河流交汇时，河网分级才会升高。因此，一级连接线与二级连接线相交会保留二级连接线，而不会创建三级连接线。这是默认设置。</para>
		/// <para>Shreve—此按量级的河网分级方法由 Shreve 于 1967 年提出。所有没有支流的连接线的量级（分级）将被指定为一。量级是指可相加的河流下坡坡度。当两个连接线相交时，将它们的量级相加，然后将其指定为下坡连接线。</para>
		/// <para><see cref="OrderMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OrderMethod { get; set; } = "STRAHLER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StreamOrder SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method of stream ordering</para>
		/// </summary>
		public enum OrderMethodEnum 
		{
			/// <summary>
			/// <para>放射状/发射状—此河网分级方法由 Strahler 于 1952 年提出。仅当级别相同的河流交汇时，河网分级才会升高。因此，一级连接线与二级连接线相交会保留二级连接线，而不会创建三级连接线。这是默认设置。</para>
			/// </summary>
			[GPValue("STRAHLER")]
			[Description("放射状/发射状")]
			Strahler,

			/// <summary>
			/// <para>Shreve—此按量级的河网分级方法由 Shreve 于 1967 年提出。所有没有支流的连接线的量级（分级）将被指定为一。量级是指可相加的河流下坡坡度。当两个连接线相交时，将它们的量级相加，然后将其指定为下坡连接线。</para>
			/// </summary>
			[GPValue("SHREVE")]
			[Description("Shreve")]
			Shreve,

		}

#endregion
	}
}
