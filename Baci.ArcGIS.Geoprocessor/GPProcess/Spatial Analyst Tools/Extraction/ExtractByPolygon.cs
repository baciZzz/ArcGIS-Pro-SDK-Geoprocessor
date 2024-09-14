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
	/// <para>Extract by Polygon</para>
	/// <para>按多边形提取</para>
	/// <para>通过指定多边形顶点，基于多边形提取栅格像元。</para>
	/// </summary>
	public class ExtractByPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>提取像元的输入栅格。</para>
		/// </param>
		/// <param name="Polygon">
		/// <para>Polygon</para>
		/// <para>由一系列折点（x,y 点坐标）定义的一个或多个多边形，用于标识要提取的输入栅格区域。一个多边形部分的最后一个坐标应与第一个坐标相同，从而使多边形闭合。</para>
		/// <para>指定多个多边形时，这些多边形必须是连续的。逐一输入各个多边形的坐标。通过定义最后一个坐标与第一个坐标相同来确保每个部分保持闭合。</para>
		/// <para>点所使用的地图单位与输入栅格相同。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </param>
		public ExtractByPolygon(object InRaster, object Polygon, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Polygon = Polygon;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 按多边形提取</para>
		/// </summary>
		public override string DisplayName() => "按多边形提取";

		/// <summary>
		/// <para>Tool Name : ExtractByPolygon</para>
		/// </summary>
		public override string ToolName() => "ExtractByPolygon";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByPolygon</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByPolygon";

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
		public override object[] Parameters() => new object[] { InRaster, Polygon, OutRaster, ExtractionArea };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>提取像元的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Polygon</para>
		/// <para>由一系列折点（x,y 点坐标）定义的一个或多个多边形，用于标识要提取的输入栅格区域。一个多边形部分的最后一个坐标应与第一个坐标相同，从而使多边形闭合。</para>
		/// <para>指定多个多边形时，这些多边形必须是连续的。逐一输入各个多边形的坐标。通过定义最后一个坐标与第一个坐标相同来确保每个部分保持闭合。</para>
		/// <para>点所使用的地图单位与输入栅格相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Polygon { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>标识要提取输入多边形内部还是输入多边形外部的像元。</para>
		/// <para>内部—指定只选择输入多边形内部的像元并将其写入输出栅格的关键字。多边形区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
		/// <para>外部—指定应选择输入多边形外部的像元并将其写入输出栅格的关键字。多边形内部的所有像元均会获得 NoData。</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByPolygon SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extraction area</para>
		/// </summary>
		public enum ExtractionAreaEnum 
		{
			/// <summary>
			/// <para>内部—指定只选择输入多边形内部的像元并将其写入输出栅格的关键字。多边形区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—指定应选择输入多边形外部的像元并将其写入输出栅格的关键字。多边形内部的所有像元均会获得 NoData。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

#endregion
	}
}
