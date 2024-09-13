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
	/// <para>创建随机栅格</para>
	/// <para>基于“分析”窗口的范围和像元大小创建一个具有介于 0.0 与 1.0 之间的随机浮点值的栅格。</para>
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
		/// <para>0.0 到 1.0 之间随机分布值的输出栅格</para>
		/// </param>
		public CreateRandomRaster(object OutRaster)
		{
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建随机栅格</para>
		/// </summary>
		public override string DisplayName() => "创建随机栅格";

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
		public override object[] Parameters() => new object[] { OutRaster, SeedValue!, CellSize!, Extent! };

		/// <summary>
		/// <para>Output raster</para>
		/// <para>0.0 到 1.0 之间随机分布值的输出栅格</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Seed value</para>
		/// <para>用于重新填充随机数生成器的值。</para>
		/// <para>可以是整数或浮点数。 栅格不可以作为输入。</para>
		/// <para>随机数生成器会使用系统时钟的当前值（自 1970 年 1 月 1 日后的秒数）来进行自动播种。 种子值的允许值范围是 -231 + 1 到 231（或 -2,147,483,647 到 2,147,483,648）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = -2147483647)]
		[High(Allow = true, Value = 2147483648)]
		public object? SeedValue { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>将创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。 如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。 有关详细信息，请参阅用法部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Output extent</para>
		/// <para>输出栅格数据集的范围。</para>
		/// <para>如果专门进行设置，则范围将为环境中的值。如果未进行专门设置，默认值将为 0、0、250、250。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRandomRaster SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
