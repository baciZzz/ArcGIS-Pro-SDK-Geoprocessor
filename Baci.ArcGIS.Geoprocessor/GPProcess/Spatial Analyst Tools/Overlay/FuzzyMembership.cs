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
	/// <para>Fuzzy Membership</para>
	/// <para>模糊隶属度</para>
	/// <para>根据指定的模糊化算法，将输入栅格转换为 0 到 1 数值范围以指示其对某一集合的隶属度。</para>
	/// </summary>
	public class FuzzyMembership : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>值域从 0 到 1 的输入栅格。</para>
		/// <para>它可以是整型栅格或浮点型栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出为浮点型栅格，取值范围是 0 到 1。</para>
		/// </param>
		public FuzzyMembership(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 模糊隶属度</para>
		/// </summary>
		public override string DisplayName() => "模糊隶属度";

		/// <summary>
		/// <para>Tool Name : FuzzyMembership</para>
		/// </summary>
		public override string ToolName() => "FuzzyMembership";

		/// <summary>
		/// <para>Tool Excute Name : sa.FuzzyMembership</para>
		/// </summary>
		public override string ExcuteName() => "sa.FuzzyMembership";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, FuzzyFunction!, Hedge! };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>值域从 0 到 1 的输入栅格。</para>
		/// <para>它可以是整型栅格或浮点型栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出为浮点型栅格，取值范围是 0 到 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Membership type</para>
		/// <para>指定用于模糊化输入栅格的算法。</para>
		/// <para>隶属度类型的某些设置使用散度参数来确定模糊隶属度从 1 变为 0 的下降速度。散度参数的默认值在下表中进行了详细说明。</para>
		/// <para>Gaussian—在中点处指定隶属度值 1。对于沿正态曲线偏离中点的值，隶属度将降为 0。高斯函数与近邻 (Near) 函数类似，但高斯函数的散度 (spread) 更小。</para>
		/// <para>中点 - 默认值为输入栅格的值范围的中点。</para>
		/// <para>散度 - 默认值是 0.1。通常，值在 [0.01–1] 内变化。</para>
		/// <para>Small—用于指示输入栅格中的小值在模糊集内的隶属度较高。在中点处指定隶属度值 0.5。</para>
		/// <para>中点 - 默认值为输入栅格的值范围的中点。</para>
		/// <para>散度 - 默认值是 5。</para>
		/// <para>Large—用于指示输入栅格中的大值在模糊集内的隶属度较高。在中点处指定隶属度值 0.5。</para>
		/// <para>中点 - 默认值为输入栅格的值范围的中点。</para>
		/// <para>散度 - 默认值是 5。</para>
		/// <para>Near—计算距离某个中间值较近的值的隶属度。在中点处指定隶属度值 1。对于偏离中点的值，隶属度将降为 0。</para>
		/// <para>中点 - 默认值为输入栅格的值范围的中点。</para>
		/// <para>散度 - 默认值是 0.1。通常，值在 [0.001–1] 的范围内变化。</para>
		/// <para>MSLarge—根据输入数据的平均值和标准差计算隶属度，输入数据中的大值具有较高隶属度。 计算结果可能与“大值”函数类似，具体取决于如何定义平均值和标准差的乘数。</para>
		/// <para>平均值乘数 - 默认值是 1。</para>
		/// <para>标准差乘数 - 默认值是 2。</para>
		/// <para>MSSmall—根据输入数据的平均值和标准差计算隶属度，输入数据中的小值具有较高隶属度。此为默认隶属度类型。 计算结果可能与“小值”函数类似，具体取决于如何定义平均值和标准差的乘数。</para>
		/// <para>平均值乘数 - 默认值是 1。</para>
		/// <para>标准差乘数 - 默认值是 2。</para>
		/// <para>Linear—根据对输入栅格进行的线性变换计算隶属度。 在最小值处指定隶属度值 0，在最大值处指定隶属度值 1。</para>
		/// <para>最小值 - 默认值是 1。</para>
		/// <para>最大值 - 默认值是 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAFuzzyFunction()]
		public object? FuzzyFunction { get; set; } = "MSSMALL 1 1";

		/// <summary>
		/// <para>Hedge</para>
		/// <para>定义模糊限制语将增大或减小可修改模糊集含义的模糊隶属度值。模糊限制语在帮助控制条件或重要属性时非常有用。</para>
		/// <para>无—不应用模糊限制语。这是默认设置。</para>
		/// <para>Somewhat—也称为膨胀，被定义为模糊隶属度函数的平方根。该模糊限制语可增大模糊隶属度函数。</para>
		/// <para>Very—也称为收缩，被定义为模糊隶属度函数的平方。该模糊限制语可减小模糊隶属度函数。</para>
		/// <para><see cref="HedgeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Hedge { get; set; } = "NONE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FuzzyMembership SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Hedge</para>
		/// </summary>
		public enum HedgeEnum 
		{
			/// <summary>
			/// <para>无—不应用模糊限制语。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>Somewhat—也称为膨胀，被定义为模糊隶属度函数的平方根。该模糊限制语可增大模糊隶属度函数。</para>
			/// </summary>
			[GPValue("SOMEWHAT")]
			[Description("Somewhat")]
			Somewhat,

			/// <summary>
			/// <para>Very—也称为收缩，被定义为模糊隶属度函数的平方。该模糊限制语可减小模糊隶属度函数。</para>
			/// </summary>
			[GPValue("VERY")]
			[Description("Very")]
			Very,

		}

#endregion
	}
}
