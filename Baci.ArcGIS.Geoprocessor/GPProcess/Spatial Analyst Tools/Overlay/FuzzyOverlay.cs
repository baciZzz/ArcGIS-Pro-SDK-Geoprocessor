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
	/// <para>Fuzzy Overlay</para>
	/// <para>模糊叠加</para>
	/// <para>基于所选叠加类型组合模糊分类栅格数据。</para>
	/// </summary>
	public class FuzzyOverlay : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>要在叠加中进行组合的输入隶属度栅格列表。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>应用模糊运算符后得到的输出栅格。</para>
		/// <para>输出值将始终介于 0 到 1 之间。</para>
		/// </param>
		public FuzzyOverlay(object InRasters, object OutRaster)
		{
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 模糊叠加</para>
		/// </summary>
		public override string DisplayName() => "模糊叠加";

		/// <summary>
		/// <para>Tool Name : FuzzyOverlay</para>
		/// </summary>
		public override string ToolName() => "FuzzyOverlay";

		/// <summary>
		/// <para>Tool Excute Name : sa.FuzzyOverlay</para>
		/// </summary>
		public override string ExcuteName() => "sa.FuzzyOverlay";

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
		public override object[] Parameters() => new object[] { InRasters, OutRaster, OverlayType!, Gamma! };

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>要在叠加中进行组合的输入隶属度栅格列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>应用模糊运算符后得到的输出栅格。</para>
		/// <para>输出值将始终介于 0 到 1 之间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Overlay type</para>
		/// <para>指定在组合两个或多个隶属度数据时所使用的方法。</para>
		/// <para>与—输入模糊栅格中模糊隶属度栅格的最小值。</para>
		/// <para>或—输入栅格中模糊隶属度栅格的最大值。</para>
		/// <para>产品—递减函数。当多个证据栅格的组合的重要性或该组合小于任何单个输入栅格时使用此函数。</para>
		/// <para>总和—递增函数。当多个证据栅格的组合的重要性或该组合大于任何单个输入栅格时使用此函数。</para>
		/// <para>Gamma—以 fuzzy 总和和 fuzzy 产品为底，以 gamma 为指数的代数乘积。</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OverlayType { get; set; } = "AND";

		/// <summary>
		/// <para>Gamma</para>
		/// <para>要使用的 gamma 值。仅适用于将叠加类型设置为 Gamma 时。</para>
		/// <para>默认值为 0.9。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 1)]
		public object? Gamma { get; set; } = "0.9";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FuzzyOverlay SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay type</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>与—输入模糊栅格中模糊隶属度栅格的最小值。</para>
			/// </summary>
			[GPValue("AND")]
			[Description("与")]
			And,

			/// <summary>
			/// <para>或—输入栅格中模糊隶属度栅格的最大值。</para>
			/// </summary>
			[GPValue("OR")]
			[Description("或")]
			Or,

			/// <summary>
			/// <para>总和—递增函数。当多个证据栅格的组合的重要性或该组合大于任何单个输入栅格时使用此函数。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

			/// <summary>
			/// <para>产品—递减函数。当多个证据栅格的组合的重要性或该组合小于任何单个输入栅格时使用此函数。</para>
			/// </summary>
			[GPValue("PRODUCT")]
			[Description("产品")]
			Product,

			/// <summary>
			/// <para>Gamma—以 fuzzy 总和和 fuzzy 产品为底，以 gamma 为指数的代数乘积。</para>
			/// </summary>
			[GPValue("GAMMA")]
			[Description("Gamma")]
			Gamma,

		}

#endregion
	}
}
