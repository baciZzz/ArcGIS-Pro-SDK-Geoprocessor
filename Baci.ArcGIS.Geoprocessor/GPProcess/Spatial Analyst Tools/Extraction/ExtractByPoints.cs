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
	/// <para>Extracts the cells of a raster based on a set of coordinate points.</para>
	/// </summary>
	public class ExtractByPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </param>
		/// <param name="Points">
		/// <para>Input points</para>
		/// <para>The points where values will be extracted from the raster.</para>
		/// <para>The points are specified as x,y coordinate pairs in the same map units as the input raster.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </param>
		public ExtractByPoints(object InRaster, object Points, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Points = Points;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract by Points</para>
		/// </summary>
		public override string DisplayName() => "Extract by Points";

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
		public override object[] Parameters() => new object[] { InRaster, Points, OutRaster, ExtractionArea };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
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
		/// <para>The points where values will be extracted from the raster.</para>
		/// <para>The points are specified as x,y coordinate pairs in the same map units as the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Points { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Extraction area</para>
		/// <para>Identifies whether to extract cells based on the specified point locations (inside) or outside the point locations (outside) .</para>
		/// <para>Inside—A keyword specifying that the cell in which the selected point falls will be written to the output raster. All cells outside the box will receive NoData on the output raster.</para>
		/// <para>Outside—A keyword specifying that the cells outside the input points should be selected and written to the output raster.</para>
		/// <para><see cref="ExtractionAreaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExtractionArea { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByPoints SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
			/// <para>Inside—A keyword specifying that the cell in which the selected point falls will be written to the output raster. All cells outside the box will receive NoData on the output raster.</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("Inside")]
			Inside,

			/// <summary>
			/// <para>Outside—A keyword specifying that the cells outside the input points should be selected and written to the output raster.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

#endregion
	}
}
