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
	/// <para>Create Random Raster</para>
	/// <para>Create Random Raster</para>
	/// <para>Creates a raster of random floating-point values between 0.0 and 1.0 within the extent and cell size of the analysis window.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.CreateRandomRaster"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.CreateRandomRaster))]
	public class CreateRandomRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster of randomly distributed values with a range of 0.0 to 1.0</para>
		/// </param>
		public CreateRandomRaster(object OutRaster)
		{
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Random Raster</para>
		/// </summary>
		public override string DisplayName() => "Create Random Raster";

		/// <summary>
		/// <para>Tool Name : CreateRandomRaster</para>
		/// </summary>
		public override string ToolName() => "CreateRandomRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.CreateRandomRaster</para>
		/// </summary>
		public override string ExcuteName() => "sa.CreateRandomRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutRaster, SeedValue, CellSize, Extent };

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster of randomly distributed values with a range of 0.0 to 1.0</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Seed value</para>
		/// <para>A value to be used to reseed the random number generator.</para>
		/// <para>This may be an integer or floating-point number. Rasters are not permitted as input.</para>
		/// <para>The random number generator is automatically seeded with the current value of the system clock (seconds since January 1, 1970). The range of permissible values for the seed value is -231+1 to 231 (or -2,147,483,647 to 2,147,483,648).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = -2147483647)]
		[High(Allow = true, Value = 2147483648)]
		public object SeedValue { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Output extent</para>
		/// <para>The extent for the output raster dataset.</para>
		/// <para>The extent will be the value in the environment if specifically set. If not specifically set, the default is 0, 0, 250, 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRandomRaster SetEnviroment(int? autoCommit = null, object cellSize = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
