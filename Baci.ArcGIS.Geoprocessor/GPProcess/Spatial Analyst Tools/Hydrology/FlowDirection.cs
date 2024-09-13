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
	/// <para>Flow Direction</para>
	/// <para>流向</para>
	/// <para>使用 D8、多流向 (MFD) 或 D-Infinity (DINF) 方法创建从每个像元到其下坡相邻点的流向的栅格。</para>
	/// </summary>
	public class FlowDirection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </param>
		/// <param name="OutFlowDirectionRaster">
		/// <para>Output flow direction raster</para>
		/// <para>输出栅格显示了使用 D8、MFD 或 DINF 方法创建的从每个像元到其下坡相邻像元的流向。</para>
		/// <para>输出为整型。</para>
		/// </param>
		public FlowDirection(object InSurfaceRaster, object OutFlowDirectionRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutFlowDirectionRaster = OutFlowDirectionRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 流向</para>
		/// </summary>
		public override string DisplayName() => "流向";

		/// <summary>
		/// <para>Tool Name : FlowDirection</para>
		/// </summary>
		public override string ToolName() => "FlowDirection";

		/// <summary>
		/// <para>Tool Excute Name : sa.FlowDirection</para>
		/// </summary>
		public override string ExcuteName() => "sa.FlowDirection";

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
		public override object[] Parameters() => new object[] { InSurfaceRaster, OutFlowDirectionRaster, ForceFlow!, OutDropRaster!, FlowDirectionType! };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>输入栅格表示连续表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output flow direction raster</para>
		/// <para>输出栅格显示了使用 D8、MFD 或 DINF 方法创建的从每个像元到其下坡相邻像元的流向。</para>
		/// <para>输出为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutFlowDirectionRaster { get; set; }

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// <para>指定边缘像元始终向外流还是遵循正常流动规则。</para>
		/// <para>未选中 - 如果边缘像元内部的最大降幅大于零，则将照常确定流向；否则流向将朝向边缘。 应从表面栅格的边缘向内流的像元也将执行此行为。 这是默认设置。</para>
		/// <para>选中 - 表面栅格边缘的所有像元将从表面栅格向外流。</para>
		/// <para><see cref="ForceFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ForceFlow { get; set; } = "false";

		/// <summary>
		/// <para>Output drop raster</para>
		/// <para>可选输出下降率栅格数据。</para>
		/// <para>下降率栅格用于返回从沿流向的各像元到像元中心间的路径长度的最大高程变化率（以百分比表示）。</para>
		/// <para>输出为浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutDropRaster { get; set; }

		/// <summary>
		/// <para>Flow direction type</para>
		/// <para>指定计算流向时将使用的流向法的类型。</para>
		/// <para>D8—流向将由 D8 方法确定。 此方法会将流向分配至最陡的下坡相邻点。 这是默认设置。</para>
		/// <para>MFD—流向将基于 MFD 流量法。 流向将根据自适应分区指数跨下坡邻域进行分区。</para>
		/// <para>DINF—流向将基于 DINF 方法。 此方法将流向分配给三角形面的最陡坡度。</para>
		/// <para><see cref="FlowDirectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FlowDirectionType { get; set; } = "D8";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FlowDirection SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Force all edge cells to flow outward</para>
		/// </summary>
		public enum ForceFlowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NORMAL")]
			NORMAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE")]
			FORCE,

		}

		/// <summary>
		/// <para>Flow direction type</para>
		/// </summary>
		public enum FlowDirectionTypeEnum 
		{
			/// <summary>
			/// <para>D8—流向将由 D8 方法确定。 此方法会将流向分配至最陡的下坡相邻点。 这是默认设置。</para>
			/// </summary>
			[GPValue("D8")]
			[Description("D8")]
			D8,

			/// <summary>
			/// <para>MFD—流向将基于 MFD 流量法。 流向将根据自适应分区指数跨下坡邻域进行分区。</para>
			/// </summary>
			[GPValue("MFD")]
			[Description("MFD")]
			MFD,

			/// <summary>
			/// <para>DINF—流向将基于 DINF 方法。 此方法将流向分配给三角形面的最陡坡度。</para>
			/// </summary>
			[GPValue("DINF")]
			[Description("DINF")]
			DINF,

		}

#endregion
	}
}
