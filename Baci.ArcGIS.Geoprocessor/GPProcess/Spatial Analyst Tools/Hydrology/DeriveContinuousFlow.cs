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
	/// <para>Derive Continuous Flow</para>
	/// <para>Derive Continuous Flow</para>
	/// <para>Generates a raster of accumulated flow into each cell from an input surface raster with no prior sink or depression filling required.</para>
	/// </summary>
	public class DeriveContinuousFlow : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input raster representing a continuous surface.</para>
		/// </param>
		/// <param name="OutAccumulationRaster">
		/// <para>Output flow accumulation raster</para>
		/// <para>The output raster representing flow accumulation (number of upstream cells draining to each cell).</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </param>
		public DeriveContinuousFlow(object InSurfaceRaster, object OutAccumulationRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutAccumulationRaster = OutAccumulationRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Derive Continuous Flow</para>
		/// </summary>
		public override string DisplayName() => "Derive Continuous Flow";

		/// <summary>
		/// <para>Tool Name : DeriveContinuousFlow</para>
		/// </summary>
		public override string ToolName() => "DeriveContinuousFlow";

		/// <summary>
		/// <para>Tool Excute Name : sa.DeriveContinuousFlow</para>
		/// </summary>
		public override string ExcuteName() => "sa.DeriveContinuousFlow";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutAccumulationRaster, InDepressionsData!, InWeightRaster!, OutFlowDirectionRaster!, FlowDirectionType!, ForceFlow! };

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
		/// <para>Output flow accumulation raster</para>
		/// <para>The output raster representing flow accumulation (number of upstream cells draining to each cell).</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutAccumulationRaster { get; set; }

		/// <summary>
		/// <para>Input raster or feature depressions data</para>
		/// <para>An optional dataset that defines real depressions.</para>
		/// <para>The depressions can be defined either through a raster or a feature layer.</para>
		/// <para>If input is a raster, the depression cells must take a valid value, including zero, and the areas that are not depressions must be NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InDepressionsData { get; set; }

		/// <summary>
		/// <para>Input accumulation weight raster</para>
		/// <para>An optional input raster dataset that defines the fraction of flow that contributes to flow accumulation at each cell.</para>
		/// <para>The weight is only applied to the accumulation of flow.</para>
		/// <para>If no accumulation weight raster is specified, a default weight of 1 will be applied to each cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InWeightRaster { get; set; }

		/// <summary>
		/// <para>Output flow direction raster</para>
		/// <para>The output raster that shows the direction of flow at each cell using the D8 or Multiple Flow Direction (MFD) method.</para>
		/// <para>The output is of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Flow direction type</para>
		/// <para>Specifies the type of flow method that will be used when computing flow directions.</para>
		/// <para>D8—Flow direction will be determined by the D8 method. This method assigns flow direction to the steepest downslope neighbor. This is the default.</para>
		/// <para>MFD—Flow direction will be based on the MFD flow method. Flow direction will be partitioned across downslope neighbors according to an adaptive partition exponent.</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlowDirectionType { get; set; } = "D8";

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// <para>Specifies whether edge cells will always flow outward or follow normal flow rules.</para>
		/// <para>Unchecked—If the maximum drop on the inside of an edge cell is greater than zero, the flow direction will be determined as usual; otherwise, the flow direction will be toward the edge. Cells that should flow from the edge of the surface raster inward will do so. This is the default.</para>
		/// <para>Checked—All cells at the edge of the surface raster will flow outward from the surface raster.</para>
		/// <para><see cref="ForceFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ForceFlow { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeriveContinuousFlow SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>D8—Flow direction will be determined by the D8 method. This method assigns flow direction to the steepest downslope neighbor. This is the default.</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—Flow direction will be based on the MFD flow method. Flow direction will be partitioned across downslope neighbors according to an adaptive partition exponent.</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

		}

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// </summary>
		public enum ForceFlowEnum 
		{
			/// <summary>
			/// <para>Unchecked—If the maximum drop on the inside of an edge cell is greater than zero, the flow direction will be determined as usual; otherwise, the flow direction will be toward the edge. Cells that should flow from the edge of the surface raster inward will do so. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NORMAL")]
			NORMAL,

			/// <summary>
			/// <para>Checked—All cells at the edge of the surface raster will flow outward from the surface raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE")]
			FORCE,

		}

#endregion
	}
}
