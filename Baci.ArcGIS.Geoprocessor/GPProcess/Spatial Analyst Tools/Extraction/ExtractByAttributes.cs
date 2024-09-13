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
	/// <para>Extract by Attributes</para>
	/// <para>Extract by Attributes</para>
	/// <para>Extracts the cells of a raster based on a logical query.</para>
	/// </summary>
	public class ExtractByAttributes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster from which cells will be extracted.</para>
		/// </param>
		/// <param name="WhereClause">
		/// <para>Where clause</para>
		/// <para>A logical expression that selects a subset of raster cells.</para>
		/// <para>The Where clause follows the general form of an SQL expression. It can be entered directly, for example, VALUE &gt; 100, if you click the Edit SQL mode button . If in the Edit Clause Mode , you can begin constructing the expression by clicking on the Add Clause Mode button.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </param>
		public ExtractByAttributes(object InRaster, object WhereClause, object OutRaster)
		{
			this.InRaster = InRaster;
			this.WhereClause = WhereClause;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract by Attributes</para>
		/// </summary>
		public override string DisplayName() => "Extract by Attributes";

		/// <summary>
		/// <para>Tool Name : ExtractByAttributes</para>
		/// </summary>
		public override string ToolName() => "ExtractByAttributes";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractByAttributes</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractByAttributes";

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
		public override object[] Parameters() => new object[] { InRaster, WhereClause, OutRaster };

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
		/// <para>Where clause</para>
		/// <para>A logical expression that selects a subset of raster cells.</para>
		/// <para>The Where clause follows the general form of an SQL expression. It can be entered directly, for example, VALUE &gt; 100, if you click the Edit SQL mode button . If in the Edit Clause Mode , you can begin constructing the expression by clicking on the Add Clause Mode button.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster containing the cell values extracted from the input raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractByAttributes SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
