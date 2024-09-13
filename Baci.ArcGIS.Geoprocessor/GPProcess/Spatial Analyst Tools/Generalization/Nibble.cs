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
	/// <para>Nibble</para>
	/// <para>蚕食</para>
	/// <para>用最邻近点的值替换掩膜范围内的栅格像元的值。</para>
	/// </summary>
	public class Nibble : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>将被蚕食的输入栅格。</para>
		/// <para>输入栅格可以是整型，也可以是浮点型。</para>
		/// </param>
		/// <param name="InMaskRaster">
		/// <para>Input raster mask</para>
		/// <para>用作掩膜的栅格。</para>
		/// <para>掩膜栅格中的 NoData 像元能够识别输入栅格中将被蚕食或被最近邻域的值替换的像元。</para>
		/// <para>掩膜栅格可以是整型，也可以是浮点型。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出已蚕食的栅格。</para>
		/// <para>识别的输入像元将被用其最邻近点的值进行替换。</para>
		/// <para>如果输入栅格为整型，那么输出栅格也为整型。如果输入栅格为浮点型，则输出栅格也为浮点型。</para>
		/// </param>
		public Nibble(object InRaster, object InMaskRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.InMaskRaster = InMaskRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 蚕食</para>
		/// </summary>
		public override string DisplayName() => "蚕食";

		/// <summary>
		/// <para>Tool Name : 蚕食</para>
		/// </summary>
		public override string ToolName() => "蚕食";

		/// <summary>
		/// <para>Tool Excute Name : sa.Nibble</para>
		/// </summary>
		public override string ExcuteName() => "sa.Nibble";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, InMaskRaster, OutRaster, NibbleValues!, NibbleNodata!, InZoneRaster! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>将被蚕食的输入栅格。</para>
		/// <para>输入栅格可以是整型，也可以是浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Input raster mask</para>
		/// <para>用作掩膜的栅格。</para>
		/// <para>掩膜栅格中的 NoData 像元能够识别输入栅格中将被蚕食或被最近邻域的值替换的像元。</para>
		/// <para>掩膜栅格可以是整型，也可以是浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InMaskRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出已蚕食的栅格。</para>
		/// <para>识别的输入像元将被用其最邻近点的值进行替换。</para>
		/// <para>如果输入栅格为整型，那么输出栅格也为整型。如果输入栅格为浮点型，则输出栅格也为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// <para>指定是否允许将输入栅格中的 NoData 像元蚕食为由掩膜栅格定义的区域。</para>
		/// <para>选中 - 可以将 NoData 和数据值蚕食为在掩膜栅格中定义的区域。如果输入栅格中的 NoData 值是最邻近点，则可自由地将其蚕食掉为掩膜中定义的区域。这是默认设置。</para>
		/// <para>未选中 - 只能将数据值蚕食为在掩膜栅格中定义的区域。即使输入栅格中的 NoData 值是最邻近点，也不允许将其蚕食为掩膜栅格中定义的区域。</para>
		/// <para><see cref="NibbleValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NibbleValues { get; set; } = "true";

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// <para>指定输入栅格中处于掩膜内的 NoData 像元在输出栅格中是否保持为 NoData。</para>
		/// <para>未选中 - 输入栅格中处于掩膜内的 NoData 像元在输出中将保持为 NoData。这是默认设置。</para>
		/// <para>选中 - 可以将输入栅格中处于掩膜内的 NoData 像元蚕食为有效的输出像元值。</para>
		/// <para><see cref="NibbleNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NibbleNodata { get; set; } = "false";

		/// <summary>
		/// <para>Input zone raster</para>
		/// <para>输入区域栅格。在每个区域中，掩膜内的输入像元仅会被同一区域内的最近像元值替换。</para>
		/// <para>区域是指栅格中具有相同值的所有像元，无论这些像元是否相连。输入区域图层定义了区域的形状、值和位置。区域栅格可以是整型，也可以是浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? InZoneRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Nibble SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use NoData values if they are the nearest neighbor</para>
		/// </summary>
		public enum NibbleValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_VALUES")]
			ALL_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DATA_ONLY")]
			DATA_ONLY,

		}

		/// <summary>
		/// <para>Nibble NoData cells</para>
		/// </summary>
		public enum NibbleNodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_NODATA")]
			PRESERVE_NODATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_NODATA")]
			PROCESS_NODATA,

		}

#endregion
	}
}
