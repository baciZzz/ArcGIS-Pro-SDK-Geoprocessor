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
	/// <para>Snap Pour Point</para>
	/// <para>捕捉倾泻点</para>
	/// <para>将倾泻点捕捉到指定距离内累积流量最大的像元。</para>
	/// </summary>
	public class SnapPourPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPourPointData">
		/// <para>Input raster or feature pour point data</para>
		/// <para>将要捕捉的输入倾泻点位置。</para>
		/// <para>对于栅格数据输入，所有不是 NoData（即，具有值）的像元都将被视为倾泻点，并会被捕捉。</para>
		/// <para>对于点要素输入，这指定了将被捕捉的像元的位置。</para>
		/// </param>
		/// <param name="InAccumulationRaster">
		/// <para>Input accumulation raster</para>
		/// <para>输入流量累积栅格。</para>
		/// <para>这可使用流量工具进行创建。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>在将原始倾泻点位置捕捉到累积流量更大的位置后产生的输出倾泻点栅格。</para>
		/// <para>输出为整型。</para>
		/// </param>
		/// <param name="SnapDistance">
		/// <para>Snap distance</para>
		/// <para>搜索累积流量更大的像元时所使用的最大距离范围（以地图单位表示）。</para>
		/// </param>
		public SnapPourPoint(object InPourPointData, object InAccumulationRaster, object OutRaster, object SnapDistance)
		{
			this.InPourPointData = InPourPointData;
			this.InAccumulationRaster = InAccumulationRaster;
			this.OutRaster = OutRaster;
			this.SnapDistance = SnapDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 捕捉倾泻点</para>
		/// </summary>
		public override string DisplayName() => "捕捉倾泻点";

		/// <summary>
		/// <para>Tool Name : SnapPourPoint</para>
		/// </summary>
		public override string ToolName() => "SnapPourPoint";

		/// <summary>
		/// <para>Tool Excute Name : sa.SnapPourPoint</para>
		/// </summary>
		public override string ExcuteName() => "sa.SnapPourPoint";

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
		public override object[] Parameters() => new object[] { InPourPointData, InAccumulationRaster, OutRaster, SnapDistance, PourPointField! };

		/// <summary>
		/// <para>Input raster or feature pour point data</para>
		/// <para>将要捕捉的输入倾泻点位置。</para>
		/// <para>对于栅格数据输入，所有不是 NoData（即，具有值）的像元都将被视为倾泻点，并会被捕捉。</para>
		/// <para>对于点要素输入，这指定了将被捕捉的像元的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InPourPointData { get; set; }

		/// <summary>
		/// <para>Input accumulation raster</para>
		/// <para>输入流量累积栅格。</para>
		/// <para>这可使用流量工具进行创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>在将原始倾泻点位置捕捉到累积流量更大的位置后产生的输出倾泻点栅格。</para>
		/// <para>输出为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Snap distance</para>
		/// <para>搜索累积流量更大的像元时所使用的最大距离范围（以地图单位表示）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object SnapDistance { get; set; } = "0";

		/// <summary>
		/// <para>Pour point field</para>
		/// <para>用于为倾泻点位置赋值的字段。</para>
		/// <para>如果倾泻点数据集为栅格，则使用 Value。</para>
		/// <para>如果倾泻点数据集为要素，则使用数值字段。 如果字段包含浮点型值，它们将被截断为整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? PourPointField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SnapPourPoint SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
