using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Test</para>
	/// <para>Performs a Boolean evaluation of the input raster using a logical expression.</para>
	/// </summary>
	public class Test : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster on which the Boolean evaluation is performed, based on a logical expression.</para>
		/// </param>
		/// <param name="WhereClause">
		/// <para>Where clause</para>
		/// <para>The logical expression that will determine which input cells will return a value of true (1) and which will be false (0).</para>
		/// <para>The Where clause follows the general form of an SQL expression. It can be entered directly, for example, VALUE &gt; 100, if you click the Edit SQL mode button . If in the Edit Clause Mode , you can begin constructing the expression by clicking on the Add Clause Mode button.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output cell values will be either 0 or 1.</para>
		/// </param>
		public Test(object InRaster, object WhereClause, object OutRaster)
		{
			this.InRaster = InRaster;
			this.WhereClause = WhereClause;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Test</para>
		/// </summary>
		public override string DisplayName() => "Test";

		/// <summary>
		/// <para>Tool Name : Test</para>
		/// </summary>
		public override string ToolName() => "Test";

		/// <summary>
		/// <para>Tool Excute Name : ia.Test</para>
		/// </summary>
		public override string ExcuteName() => "ia.Test";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

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
		/// <para>The input raster on which the Boolean evaluation is performed, based on a logical expression.</para>
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
		/// <para>The logical expression that will determine which input cells will return a value of true (1) and which will be false (0).</para>
		/// <para>The Where clause follows the general form of an SQL expression. It can be entered directly, for example, VALUE &gt; 100, if you click the Edit SQL mode button . If in the Edit Clause Mode , you can begin constructing the expression by clicking on the Add Clause Mode button.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster.</para>
		/// <para>The output cell values will be either 0 or 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Test SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
