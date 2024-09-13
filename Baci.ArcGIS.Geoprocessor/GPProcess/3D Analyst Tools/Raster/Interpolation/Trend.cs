using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Trend</para>
	/// <para>Trend</para>
	/// <para>Interpolates a raster surface from points using a trend technique.</para>
	/// </summary>
	public class Trend : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>The input point features containing the z-values to be interpolated into a surface raster.</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>The field that holds a height or magnitude value for each point.</para>
		/// <para>This can be a numeric field or the Shape field if the input point features contain z-values.</para>
		/// <para>If the regression type is Logistic, the values in the field can only be 0 or 1.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
		/// </param>
		public Trend(object InPointFeatures, object ZField, object OutRaster)
		{
			this.InPointFeatures = InPointFeatures;
			this.ZField = ZField;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Trend</para>
		/// </summary>
		public override string DisplayName() => "Trend";

		/// <summary>
		/// <para>Tool Name : Trend</para>
		/// </summary>
		public override string ToolName() => "Trend";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Trend</para>
		/// </summary>
		public override string ExcuteName() => "3d.Trend";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, ZField, OutRaster, CellSize!, Order!, RegressionType!, OutRmsFile! };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>The input point features containing the z-values to be interpolated into a surface raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>The field that holds a height or magnitude value for each point.</para>
		/// <para>This can be a numeric field or the Shape field if the input point features contain z-values.</para>
		/// <para>If the regression type is Logistic, the values in the field can only be 0 or 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output interpolated surface raster.</para>
		/// <para>It is always a floating-point raster.</para>
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
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Polynomial order</para>
		/// <para>The order of the polynomial.</para>
		/// <para>This must be an integer between 1 and 12. A value of 1 will fit a flat plane to the points, and a higher value will fit a more complex surface. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 12)]
		public object? Order { get; set; } = "1";

		/// <summary>
		/// <para>Type of regression</para>
		/// <para>The type of regression to be performed.</para>
		/// <para>Linear—Polynomial regression is performed to fit a least-squares surface to the set of input points. This is applicable for continuous types of data.</para>
		/// <para>Logistic—Logistic trend surface analysis is performed. It generates a continuous probability surface for binary, or dichotomous, types of data.</para>
		/// <para><see cref="RegressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RegressionType { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Output RMS file</para>
		/// <para>File name for the output text file that contains information about the RMS error and the Chi-Square of the interpolation.</para>
		/// <para>The extension must be .txt.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT")]
		public object? OutRmsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Trend SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type of regression</para>
		/// </summary>
		public enum RegressionTypeEnum 
		{
			/// <summary>
			/// <para>Linear—Polynomial regression is performed to fit a least-squares surface to the set of input points. This is applicable for continuous types of data.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Logistic—Logistic trend surface analysis is performed. It generates a continuous probability surface for binary, or dichotomous, types of data.</para>
			/// </summary>
			[GPValue("LOGISTIC")]
			[Description("Logistic")]
			Logistic,

		}

#endregion
	}
}
