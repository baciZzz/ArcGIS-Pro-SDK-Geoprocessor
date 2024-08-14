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
	/// <para>Create Constant Raster</para>
	/// <para>Creates a raster of a constant value within the extent and cell size of the analysis window.</para>
	/// </summary>
	public class CreateConstantRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster for which each cell will have the specified constant value.</para>
		/// </param>
		/// <param name="ConstantValue">
		/// <para>Constant value</para>
		/// <para>The constant value with which to populate all the cells in the output raster.</para>
		/// </param>
		public CreateConstantRaster(object OutRaster, object ConstantValue)
		{
			this.OutRaster = OutRaster;
			this.ConstantValue = ConstantValue;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Constant Raster</para>
		/// </summary>
		public override string DisplayName => "Create Constant Raster";

		/// <summary>
		/// <para>Tool Name : CreateConstantRaster</para>
		/// </summary>
		public override string ToolName => "CreateConstantRaster";

		/// <summary>
		/// <para>Tool Excute Name : sa.CreateConstantRaster</para>
		/// </summary>
		public override string ExcuteName => "sa.CreateConstantRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutRaster, ConstantValue, DataType, CellSize, Extent };

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster for which each cell will have the specified constant value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Constant value</para>
		/// <para>The constant value with which to populate all the cells in the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConstantValue { get; set; }

		/// <summary>
		/// <para>Output data type</para>
		/// <para>Data type of the output raster dataset.</para>
		/// <para>Integer—An integer raster will be created.</para>
		/// <para>Float—A floating-point raster will be created.</para>
		/// <para>If the specified data type is Float, the values of the cells in the output raster will only be accurate to the constant value of 7 decimal places, regardless of the output format.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "INTEGER";

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
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
		public CreateConstantRaster SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Integer—An integer raster will be created.</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("Integer")]
			Integer,

			/// <summary>
			/// <para>Float—A floating-point raster will be created.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float")]
			Float,

		}

#endregion
	}
}
