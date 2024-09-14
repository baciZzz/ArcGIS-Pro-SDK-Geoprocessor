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
	/// <para>Fill</para>
	/// <para>Fill</para>
	/// <para>Fills sinks in a surface raster to remove small imperfections in the data.</para>
	/// </summary>
	public class Fill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="OutSurfaceRaster">
		/// <para>Output surface raster</para>
		/// <para>The output surface raster after the sinks have been filled.</para>
		/// <para>If the surface raster is integer, the output filled raster will be integer type. If the input is floating point, the output raster will be floating point.</para>
		/// </param>
		public Fill(object InSurfaceRaster, object OutSurfaceRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutSurfaceRaster = OutSurfaceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Fill</para>
		/// </summary>
		public override string DisplayName() => "Fill";

		/// <summary>
		/// <para>Tool Name : Fill</para>
		/// </summary>
		public override string ToolName() => "Fill";

		/// <summary>
		/// <para>Tool Excute Name : sa.Fill</para>
		/// </summary>
		public override string ExcuteName() => "sa.Fill";

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
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutSurfaceRaster, ZLimit! };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output surface raster</para>
		/// <para>The output surface raster after the sinks have been filled.</para>
		/// <para>If the surface raster is integer, the output filled raster will be integer type. If the input is floating point, the output raster will be floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Z limit</para>
		/// <para>Maximum elevation difference between a sink and its pour point to be filled.</para>
		/// <para>If the difference in z-values between a sink and its pour point is greater than the z_limit, that sink will not be filled.</para>
		/// <para>The value for z-limit must be greater than zero.</para>
		/// <para>Unless a value is specified for this parameter, all sinks will be filled, regardless of depth.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ZLimit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Fill SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
