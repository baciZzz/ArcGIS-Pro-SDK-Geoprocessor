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
	/// <para>Calculate Kernel Density Ratio</para>
	/// <para>Calculates a spatial relative risk surface using two input feature datasets. The numerator in the ratio represents cases, such as number of crimes or number of patients, and the denominator represents the control, such as the total population.</para>
	/// </summary>
	public class CalculateKernelDensityRatio : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeaturesNumerator">
		/// <para>Input point or polyline features as numerator</para>
		/// <para>The input features (point or line) of the cases for which density will be calculated.</para>
		/// </param>
		/// <param name="InFeaturesDenominator">
		/// <para>Input point or polyline features as denominator</para>
		/// <para>The input features (point or line) of the control for which density will be calculated.</para>
		/// </param>
		/// <param name="PopulationFieldNumerator">
		/// <para>Population field of numerator</para>
		/// <para>The field denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
		/// <para>Use OID or FID if no item or special value will be used and each feature will be counted once.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>You can use the Shape field if input features contain Z-values.</para>
		/// </param>
		/// <param name="PopulationFieldDenominator">
		/// <para>Population field of denominator</para>
		/// <para>The field denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
		/// <para>Use OID or FID if no item or special value will be used and each feature will be counted once.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>You can use the Shape field if input features contain Z-values.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output kernel density raster.</para>
		/// <para>It is always a floating point raster.</para>
		/// </param>
		public CalculateKernelDensityRatio(object InFeaturesNumerator, object InFeaturesDenominator, object PopulationFieldNumerator, object PopulationFieldDenominator, object OutRaster)
		{
			this.InFeaturesNumerator = InFeaturesNumerator;
			this.InFeaturesDenominator = InFeaturesDenominator;
			this.PopulationFieldNumerator = PopulationFieldNumerator;
			this.PopulationFieldDenominator = PopulationFieldDenominator;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Kernel Density Ratio</para>
		/// </summary>
		public override string DisplayName => "Calculate Kernel Density Ratio";

		/// <summary>
		/// <para>Tool Name : CalculateKernelDensityRatio</para>
		/// </summary>
		public override string ToolName => "CalculateKernelDensityRatio";

		/// <summary>
		/// <para>Tool Excute Name : sa.CalculateKernelDensityRatio</para>
		/// </summary>
		public override string ExcuteName => "sa.CalculateKernelDensityRatio";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeaturesNumerator, InFeaturesDenominator, PopulationFieldNumerator, PopulationFieldDenominator, OutRaster, CellSize!, SearchRadiusNumerator!, SearchRadiusDenominator!, OutCellValues!, Method!, InBarriersNumerator!, InBarriersDenominator! };

		/// <summary>
		/// <para>Input point or polyline features as numerator</para>
		/// <para>The input features (point or line) of the cases for which density will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeaturesNumerator { get; set; }

		/// <summary>
		/// <para>Input point or polyline features as denominator</para>
		/// <para>The input features (point or line) of the control for which density will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeaturesDenominator { get; set; }

		/// <summary>
		/// <para>Population field of numerator</para>
		/// <para>The field denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
		/// <para>Use OID or FID if no item or special value will be used and each feature will be counted once.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>You can use the Shape field if input features contain Z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object PopulationFieldNumerator { get; set; }

		/// <summary>
		/// <para>Population field of denominator</para>
		/// <para>The field denoting population values for each feature. The population field is the count or quantity to be spread across the landscape to create a continuous surface.</para>
		/// <para>Use OID or FID if no item or special value will be used and each feature will be counted once.</para>
		/// <para>Values in the population field can be integer or floating point.</para>
		/// <para>You can use the Shape field if input features contain Z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object PopulationFieldDenominator { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output kernel density raster.</para>
		/// <para>It is always a floating point raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output raster that will be created.</para>
		/// <para>This parameter can be defined by a numeric value or obtained from an existing raster dataset. If the cell size hasn&apos;t been explicitly specified as the parameter value, the environment cell size value will be used if specified; otherwise, additional rules will be used to calculate it from the other inputs. See the usage section for more detail.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Search radius of numerator</para>
		/// <para>The search radius within which density will be calculated. Units are based on the linear unit of the projection of the output spatial reference.</para>
		/// <para>For example, if the units are meters—to include all features within a one-mile neighborhood—set the search radius equal to 1609.344 (1 mile = 1609.344 meters).</para>
		/// <para>The default search radius is computed specifically for the input dataset using a spatial variant of Silverman&apos;s Rule of Thumb (Silverman, 1986) that is robust enough for spatial outliers (points that are far away from the rest of the points). See the usage tips for a description of the algorithm.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchRadiusNumerator { get; set; }

		/// <summary>
		/// <para>Search radius of denominator</para>
		/// <para>The search radius within which density will be calculated. Units are based on the linear unit of the projection of the output spatial reference.</para>
		/// <para>For example, if the units are meters—to include all features within a one-mile neighborhood—set the search radius equal to 1609.344 (1 mile = 1609.344 meters).</para>
		/// <para>The default search radius is computed specifically for the input dataset using a spatial variant of Silverman&apos;s Rule of Thumb (Silverman, 1986) that is robust enough for spatial outliers (points that are far away from the rest of the points). See the usage tips for a description of the algorithm.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchRadiusDenominator { get; set; }

		/// <summary>
		/// <para>Output cell values</para>
		/// <para>Specifies what the values in the output raster represent.</para>
		/// <para>Densities—The output values represent the calculated density value per unit area for each cell. This is the default.</para>
		/// <para>Expected counts—The output values represent the calculated density value per cell area.</para>
		/// <para>Since the cell value is linked to the specified cell size, the resulting raster cannot be resampled to a different cell size.</para>
		/// <para><see cref="OutCellValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutCellValues { get; set; } = "DENSITIES";

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies whether the flat earth (planar) or the shortest path on a spheroid (geodesic) distance will be used.</para>
		/// <para>Planar—The planar distance between features will be used. This is the default.</para>
		/// <para>Geodesic—The geodesic distance between features will be used.</para>
		/// <para>The geodesic method only supports points as input features.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Input barrier features for numerator</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be a feature layer of polyline or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InBarriersNumerator { get; set; }

		/// <summary>
		/// <para>Input barrier features for denominator</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be a feature layer of polyline or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InBarriersDenominator { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateKernelDensityRatio SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output cell values</para>
		/// </summary>
		public enum OutCellValuesEnum 
		{
			/// <summary>
			/// <para>Densities—The output values represent the calculated density value per unit area for each cell. This is the default.</para>
			/// </summary>
			[GPValue("DENSITIES")]
			[Description("Densities")]
			Densities,

			/// <summary>
			/// <para>Expected counts—The output values represent the calculated density value per cell area.</para>
			/// </summary>
			[GPValue("EXPECTED_COUNTS")]
			[Description("Expected counts")]
			Expected_counts,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Planar—The planar distance between features will be used. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The geodesic distance between features will be used.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
