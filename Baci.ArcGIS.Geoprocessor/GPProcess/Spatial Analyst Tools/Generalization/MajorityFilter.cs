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
	/// <para>Majority Filter</para>
	/// <para>Majority Filter</para>
	/// <para>Replaces cells in a raster based on the majority of their contiguous neighboring cells.</para>
	/// </summary>
	public class MajorityFilter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input raster to be filtered based on the majority of contiguous neighboring cells.</para>
		/// <para>It must be of integer type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output filtered raster.</para>
		/// <para>The output is always of integer type.</para>
		/// </param>
		public MajorityFilter(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Majority Filter</para>
		/// </summary>
		public override string DisplayName() => "Majority Filter";

		/// <summary>
		/// <para>Tool Name : MajorityFilter</para>
		/// </summary>
		public override string ToolName() => "MajorityFilter";

		/// <summary>
		/// <para>Tool Excute Name : sa.MajorityFilter</para>
		/// </summary>
		public override string ExcuteName() => "sa.MajorityFilter";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, NumberNeighbors, MajorityDefinition };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input raster to be filtered based on the majority of contiguous neighboring cells.</para>
		/// <para>It must be of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output filtered raster.</para>
		/// <para>The output is always of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// <para>Determines the number of neighboring cells to use in the kernel of the filter.</para>
		/// <para>Four— The kernel of the filter will be the four direct (orthogonal) neighbors to the present cell. This is the default.</para>
		/// <para>Eight— The kernel of the filter will be the eight nearest neighbors (a three-by-three window) to the present cell.</para>
		/// <para><see cref="NumberNeighborsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NumberNeighbors { get; set; } = "FOUR";

		/// <summary>
		/// <para>Replacement threshold</para>
		/// <para>Specifies the number of contiguous (spatially connected) cells that must be of the same value before a replacement will occur.</para>
		/// <para>Majority— A majority of cells must have the same value and be contiguous. Three out of four or five out of eight connected cells must have the same value.</para>
		/// <para>Half— Half of the cells must have the same value and be contiguous. Two out of four or four out of eight connected cells must have the same value. This option will have a more smoothing effect than the other.</para>
		/// <para><see cref="MajorityDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MajorityDefinition { get; set; } = "MAJORITY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MajorityFilter SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of neighbors to use</para>
		/// </summary>
		public enum NumberNeighborsEnum 
		{
			/// <summary>
			/// <para>Four— The kernel of the filter will be the four direct (orthogonal) neighbors to the present cell. This is the default.</para>
			/// </summary>
			[GPValue("FOUR")]
			[Description("Four")]
			Four,

			/// <summary>
			/// <para>Eight— The kernel of the filter will be the eight nearest neighbors (a three-by-three window) to the present cell.</para>
			/// </summary>
			[GPValue("EIGHT")]
			[Description("Eight")]
			Eight,

		}

		/// <summary>
		/// <para>Replacement threshold</para>
		/// </summary>
		public enum MajorityDefinitionEnum 
		{
			/// <summary>
			/// <para>Majority— A majority of cells must have the same value and be contiguous. Three out of four or five out of eight connected cells must have the same value.</para>
			/// </summary>
			[GPValue("MAJORITY")]
			[Description("Majority")]
			Majority,

			/// <summary>
			/// <para>Half— Half of the cells must have the same value and be contiguous. Two out of four or four out of eight connected cells must have the same value. This option will have a more smoothing effect than the other.</para>
			/// </summary>
			[GPValue("HALF")]
			[Description("Half")]
			Half,

		}

#endregion
	}
}
