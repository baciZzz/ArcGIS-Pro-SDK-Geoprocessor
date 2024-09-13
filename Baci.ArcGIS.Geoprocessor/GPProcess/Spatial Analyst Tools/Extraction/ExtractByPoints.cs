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
	/// <para>Extract by Points</para>
	/// <para>按点提取</para>
	/// <para>基于一组坐标点提取栅格的像元。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.ExtractByMask"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.ExtractByMask))]
	public class ExtractByPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>从中提取像元的输入栅格。</para>
		/// </param>
		/// <param name="Points">
		/// <para>Input points</para>
		/// <para>要提取栅格值的点。</para>
		/// <para>指定为 x,y 坐标对的点所使用的地图单位与输入栅格相同。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </param>
		public ExtractByPoints(object InRaster, object Points, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Points = Points;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 按点提取</para>
		/// </summary>
		public override string DisplayName() => "按点提取";

		/// <summary>
		/// <para>Tool Name : ExtractByPoints</para>
		/// </summary>
		public override string ToolName() => "ExtractByPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByPoints</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByPoints";

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
		public override object[] Parameters() => new object[] { InRaster, Points, OutRaster, ExtractionArea! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>从中提取像元的输入栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input points</para>
		/// <para>要提取栅格值的点。</para>
		/// <para>指定为 x,y 坐标对的点所使用的地图单位与输入栅格相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Points { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>标识是基于指定点位置（内部）提取像元还是基于点位置外部（外部）提取像元。</para>
		/// <para>内部—将所选点落入的像元写入输出栅格。 方框区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
		/// <para>外部—应选择输入点外部的像元并将其写入输出栅格。</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByPoints SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extraction area</para>
		/// </summary>
		public enum ExtractionAreaEnum 
		{
			/// <summary>
			/// <para>内部—将所选点落入的像元写入输出栅格。 方框区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—应选择输入点外部的像元并将其写入输出栅格。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

#endregion
	}
}
