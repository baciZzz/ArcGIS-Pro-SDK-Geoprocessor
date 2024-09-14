using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>GA Layer 3D To NetCDF</para>
	/// <para>GA Layer 3D To NetCDF</para>
	/// <para>Exports one or more 3D geostatistical layers created using the Empirical Bayesian Kriging 3D tool to netCDF format (*.nc file). The primary purpose of this tool is to prepare the 3D geostatistical layers for visualization as a voxel layer in a local scene.</para>
	/// </summary>
	public class GALayer3DToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="In3DGeostatLayers">
		/// <para>Input 3D geostatistical layers</para>
		/// <para>The 3D geostatistical layers that will be exported to the Output netCDF file. If more than one layer is provided, the output will be a multivariate netCDF file.</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF file</para>
		/// <para>The output netCDF file containing the exported values from the Input 3D geostatistical layers.</para>
		/// </param>
		public GALayer3DToNetCDF(object In3DGeostatLayers, object OutNetcdfFile)
		{
			this.In3DGeostatLayers = In3DGeostatLayers;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : GA Layer 3D To NetCDF</para>
		/// </summary>
		public override string DisplayName() => "GA Layer 3D To NetCDF";

		/// <summary>
		/// <para>Tool Name : GALayer3DToNetCDF</para>
		/// </summary>
		public override string ToolName() => "GALayer3DToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayer3DToNetCDF</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayer3DToNetCDF";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { In3DGeostatLayers, OutNetcdfFile, ExportLocations, XSpacing, YSpacing, ElevationSpacing, InPoints3D, OutputVariables, InStudyArea };

		/// <summary>
		/// <para>Input 3D geostatistical layers</para>
		/// <para>The 3D geostatistical layers that will be exported to the Output netCDF file. If more than one layer is provided, the output will be a multivariate netCDF file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object In3DGeostatLayers { get; set; }

		/// <summary>
		/// <para>Output netCDF file</para>
		/// <para>The output netCDF file containing the exported values from the Input 3D geostatistical layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Export locations</para>
		/// <para>Specifies the locations to export from the Input 3D geostatistical layers. You can export to 3D gridded points or provide custom 3D point features to represent the export locations. If you choose 3D gridded points, you must provide values for the X spacing, Y spacing, and Elevation spacing parameters that represent the distance between each gridded point in all dimensions. If you choose Custom 3D points, you must provide 3D point features in the 3D point locations parameter representing the locations to export.</para>
		/// <para>3D gridded points—Prediction locations are 3D gridded points. This is the default.</para>
		/// <para>Custom 3D points—Prediction locations are defined by custom 3D point features.</para>
		/// <para><see cref="ExportLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportLocations { get; set; } = "3D_GRIDDED_POINTS";

		/// <summary>
		/// <para>X spacing</para>
		/// <para>The spacing between each gridded point in the x-dimension. The default value creates 40 points along the output x-extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object XSpacing { get; set; }

		/// <summary>
		/// <para>Y spacing</para>
		/// <para>The spacing between each gridded point in the y-dimension. The default value creates 40 points along the output y-extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object YSpacing { get; set; }

		/// <summary>
		/// <para>Elevation spacing</para>
		/// <para>The spacing between each gridded point in the elevation (z) dimension. The default value creates 40 points along the output z-extent.</para>
		/// <para><see cref="ElevationSpacingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object ElevationSpacing { get; set; }

		/// <summary>
		/// <para>3D point locations</para>
		/// <para>The 3D point features representing locations to export. The point features must have their elevations stored in the Shape.Z geometry attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InPoints3D { get; set; }

		/// <summary>
		/// <para>Output variables</para>
		/// <para>Specifies the output types for the Input 3D geostatistical layers. You can specify one or more output types for each of the layers or you can apply an output type to all input geostatistical layers. By default, the predictions for all layers will be exported.</para>
		/// <para>To export other output types, specify the layer to export (or choose All to specify all layers) in the first entry of the value table. Specify the output type in the second entry of the value table. If you choose Probability or Quantile as the output type, specify the threshold value (for probability) or the quantile value (for quantile) in the third entry of the value table. If you choose Prediction or Prediction standard error as the output type, you can leave the third entry in the value table empty.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object OutputVariables { get; set; }

		/// <summary>
		/// <para>Input study area polygons</para>
		/// <para>The polygon features that represent the study area. Only points that are within the study area are saved in the output netCDF file. When visualized as a voxel layer, only voxels within the study area will display in the scene. Points are determined to be inside or outside of the study area using only their x- and y-coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InStudyArea { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayer3DToNetCDF SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export locations</para>
		/// </summary>
		public enum ExportLocationsEnum 
		{
			/// <summary>
			/// <para>3D gridded points—Prediction locations are 3D gridded points. This is the default.</para>
			/// </summary>
			[GPValue("3D_GRIDDED_POINTS")]
			[Description("3D gridded points")]
			_3D_gridded_points,

			/// <summary>
			/// <para>Custom 3D points—Prediction locations are defined by custom 3D point features.</para>
			/// </summary>
			[GPValue("CUSTOM_3D_POINTS")]
			[Description("Custom 3D points")]
			Custom_3D_points,

		}

		/// <summary>
		/// <para>Elevation spacing</para>
		/// </summary>
		public enum ElevationSpacingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Millimeters")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

#endregion
	}
}
