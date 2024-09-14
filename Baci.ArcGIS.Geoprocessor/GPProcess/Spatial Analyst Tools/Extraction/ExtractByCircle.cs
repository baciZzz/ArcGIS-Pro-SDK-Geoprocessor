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
	/// <para>Extract by Circle</para>
	/// <para>按圆提取</para>
	/// <para>通过指定圆心和半径，基于圆提取栅格像元。</para>
	/// </summary>
	public class ExtractByCircle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>从中提取像元的输入栅格。</para>
		/// </param>
		/// <param name="CenterPoint">
		/// <para>Center point</para>
		/// <para>用于定义提取区域的圆的中心坐标 (x,y)。</para>
		/// <para>将指定坐标使用与输入栅格相同的地图单位。</para>
		/// </param>
		/// <param name="Radius">
		/// <para>Radius</para>
		/// <para>用于定义提取区域的圆半径。</para>
		/// <para>将以地图单位指定半径，并且与输入栅格的单位相同。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </param>
		public ExtractByCircle(object InRaster, object CenterPoint, object Radius, object OutRaster)
		{
			this.InRaster = InRaster;
			this.CenterPoint = CenterPoint;
			this.Radius = Radius;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 按圆提取</para>
		/// </summary>
		public override string DisplayName() => "按圆提取";

		/// <summary>
		/// <para>Tool Name : ExtractByCircle</para>
		/// </summary>
		public override string ToolName() => "ExtractByCircle";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByCircle</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByCircle";

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
		public override object[] Parameters() => new object[] { InRaster, CenterPoint, Radius, OutRaster, ExtractionArea! };

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
		/// <para>Center point</para>
		/// <para>用于定义提取区域的圆的中心坐标 (x,y)。</para>
		/// <para>将指定坐标使用与输入栅格相同的地图单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object CenterPoint { get; set; }

		/// <summary>
		/// <para>Radius</para>
		/// <para>用于定义提取区域的圆半径。</para>
		/// <para>将以地图单位指定半径，并且与输入栅格的单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object Radius { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>包含从输入栅格中提取的像元值的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>指定是选择输入圆内部还是外部的像元并将其写入输出栅格。</para>
		/// <para>内部—将选择输入圆内部的像元并将其写入输出栅格。 圆形区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
		/// <para>外部—将选择输入圆外部的像元并将其写入输出栅格。 圆形区域内部的所有像元都将在输出栅格中获得 NoData 值。</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByCircle SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
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
			/// <para>内部—将选择输入圆内部的像元并将其写入输出栅格。 圆形区域外部的所有像元都将在输出栅格中获得 NoData 值。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—将选择输入圆外部的像元并将其写入输出栅格。 圆形区域内部的所有像元都将在输出栅格中获得 NoData 值。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

#endregion
	}
}
