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
	/// <para>3D GA 图层转 NetCDF</para>
	/// <para>将使用 3D 经验贝叶斯克里金工具创建的一个或多个 3D 地统计图层导出为 netCDF 格式（*.nc 文件）。此工具的主要目的是准备 3D 地统计图层，以将其可视化为局部场景中的体素图层。</para>
	/// </summary>
	public class GALayer3DToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="In3DGeostatLayers">
		/// <para>Input 3D geostatistical layers</para>
		/// <para>将导出到输出 netCDF 文件的 3D 地统计图层。如果提供了多个图层，则输出将是多元 netCDF 文件。</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF file</para>
		/// <para>包含从 输入 3D 地统计图层导出的值的输出 netCDF 文件。</para>
		/// </param>
		public GALayer3DToNetCDF(object In3DGeostatLayers, object OutNetcdfFile)
		{
			this.In3DGeostatLayers = In3DGeostatLayers;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D GA 图层转 NetCDF</para>
		/// </summary>
		public override string DisplayName() => "3D GA 图层转 NetCDF";

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
		/// <para>将导出到输出 netCDF 文件的 3D 地统计图层。如果提供了多个图层，则输出将是多元 netCDF 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object In3DGeostatLayers { get; set; }

		/// <summary>
		/// <para>Output netCDF file</para>
		/// <para>包含从 输入 3D 地统计图层导出的值的输出 netCDF 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Export locations</para>
		/// <para>指定要从输入 3D 地统计图层导出的位置。您可以导出到 3D 格网化点或提供自定义 3D 点要素来表示导出位置。如果您选择 3D 格网化点，则必须提供 X 间距、Y 间距和高程间距参数的值，这些参数表示所有维度上每个格网化的点之间的距离。如果您选择自定义 3D 点，则必须在 3D 点位置参数中提供 3D 点要素，其表示要导出的位置。</para>
		/// <para>3D 格网化点—预测位置是 3D 格网化点。这是默认设置。</para>
		/// <para>自定义 3D 点—预测位置由自定义 3D 点要素定义。</para>
		/// <para><see cref="ExportLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportLocations { get; set; } = "3D_GRIDDED_POINTS";

		/// <summary>
		/// <para>X spacing</para>
		/// <para>x 维度中每个格网化点之间的间距。默认值沿输出 x 范围创建 40 个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object XSpacing { get; set; }

		/// <summary>
		/// <para>Y spacing</para>
		/// <para>y 维度中每个格网化点之间的间距。默认值沿输出 y 范围创建 40 个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object YSpacing { get; set; }

		/// <summary>
		/// <para>Elevation spacing</para>
		/// <para>高程 (z) 维度中每个格网化点之间的间距。默认值沿输出 z 范围创建 40 个点。</para>
		/// <para><see cref="ElevationSpacingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object ElevationSpacing { get; set; }

		/// <summary>
		/// <para>3D point locations</para>
		/// <para>表示要导出的位置的 3D 点要素。点要素的高程必须存储在 Shape.Z 几何属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InPoints3D { get; set; }

		/// <summary>
		/// <para>Output variables</para>
		/// <para>指定输入 3D 地统计图层的输出类型。您可以为每个图层指定一个或多个输出类型，也可以将输出类型应用于所有输入地统计图层。默认情况下，将导出所有图层的预测。</para>
		/// <para>要导出其他输出类型，请在值表的第一个条目中指定要导出的图层（或选择所有以指定所有图层）。在值表的第二个条目中指定输出类型。如果您选择概率或分位数作为输出类型，请在值表的第三个条目中指定阈值（用于概率）或分位数（用于分位数）。如果您选择预测或预测标准误差作为输出类型，则可将值表中的第三个条目留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object OutputVariables { get; set; }

		/// <summary>
		/// <para>Input study area polygons</para>
		/// <para>表示研究区域的面要素。仅研究区域内的点保存在输出 netCDF 文件中。如果可视化为体素图层，则场景中将仅显示研究区域内的体素。将仅使用点的 x 和 y 坐标来确定点位于研究区域内部还是外部。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InStudyArea { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayer3DToNetCDF SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
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
			/// <para>3D 格网化点—预测位置是 3D 格网化点。这是默认设置。</para>
			/// </summary>
			[GPValue("3D_GRIDDED_POINTS")]
			[Description("3D 格网化点")]
			_3D_gridded_points,

			/// <summary>
			/// <para>自定义 3D 点—预测位置由自定义 3D 点要素定义。</para>
			/// </summary>
			[GPValue("CUSTOM_3D_POINTS")]
			[Description("自定义 3D 点")]
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
