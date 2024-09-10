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
	/// <para>Snaps pour points to the cell of highest flow accumulation within a specified distance.</para>
	/// </summary>
	public class SnapPourPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPourPointData">
		/// <para>Input raster or feature pour point data</para>
		/// <para>The input pour point locations that are to be snapped.</para>
		/// <para>For a raster input, all cells that are not NoData (that is, have a value) will be considered pour points and will be snapped.</para>
		/// <para>For a point feature input, this specifies the locations of cells that will be snapped.</para>
		/// </param>
		/// <param name="InAccumulationRaster">
		/// <para>Input accumulation raster</para>
		/// <para>The input flow accumulation raster.</para>
		/// <para>This can be created with the Flow Accumulation tool.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output pour point raster where the original pour point locations have been snapped to locations of higher accumulated flow.</para>
		/// <para>This output is of integer type.</para>
		/// </param>
		/// <param name="SnapDistance">
		/// <para>Snap distance</para>
		/// <para>Maximum distance, in map units, to search for a cell of higher accumulated flow.</para>
		/// </param>
		public SnapPourPoint(object InPourPointData, object InAccumulationRaster, object OutRaster, object SnapDistance)
		{
			this.InPourPointData = InPourPointData;
			this.InAccumulationRaster = InAccumulationRaster;
			this.OutRaster = OutRaster;
			this.SnapDistance = SnapDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Snap Pour Point</para>
		/// </summary>
		public override string DisplayName() => "Snap Pour Point";

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
		public override object[] Parameters() => new object[] { InPourPointData, InAccumulationRaster, OutRaster, SnapDistance, PourPointField };

		/// <summary>
		/// <para>Input raster or feature pour point data</para>
		/// <para>The input pour point locations that are to be snapped.</para>
		/// <para>For a raster input, all cells that are not NoData (that is, have a value) will be considered pour points and will be snapped.</para>
		/// <para>For a point feature input, this specifies the locations of cells that will be snapped.</para>
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
		/// <para>The input flow accumulation raster.</para>
		/// <para>This can be created with the Flow Accumulation tool.</para>
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
		/// <para>The output pour point raster where the original pour point locations have been snapped to locations of higher accumulated flow.</para>
		/// <para>This output is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Snap distance</para>
		/// <para>Maximum distance, in map units, to search for a cell of higher accumulated flow.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object SnapDistance { get; set; } = "0";

		/// <summary>
		/// <para>Pour point field</para>
		/// <para>The field used to assign values to the pour point locations.</para>
		/// <para>If the pour point dataset is a raster, use Value.</para>
		/// <para>If the pour point dataset is a feature, use a numeric field. If the field contains floating-point values, they will be truncated into integers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain(UseRasterFields = true)]
		[FieldType("Short", "Long", "Float", "Double")]
		public object PourPointField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SnapPourPoint SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
