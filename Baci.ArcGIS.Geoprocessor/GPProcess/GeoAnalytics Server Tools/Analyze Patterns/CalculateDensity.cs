using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Calculate Density</para>
	/// <para>计算密度</para>
	/// <para>根据落入每个单元周围邻域内的点要素计算每单位面积的量级。</para>
	/// </summary>
	public class CalculateDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input layer</para>
		/// <para>用于计算密度的点。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="BinType">
		/// <para>Bin Type</para>
		/// <para>指定分析中将使用的图格形状。</para>
		/// <para>正方形—图格形状将为方形。这是默认设置。</para>
		/// <para>六边形—图格形状将为六边形。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </param>
		/// <param name="BinSize">
		/// <para>Bin Size</para>
		/// <para>用于聚合输入要素的图格大小。生成方形图格时，由指定的数字和单位决定正方形的高度和长度。生成六边形图格时，由指定的数字和单位决定平行边之间的距离。</para>
		/// <para><see cref="BinSizeEnum"/></para>
		/// </param>
		/// <param name="Weight">
		/// <para>Weight</para>
		/// <para>指定要应用于密度函数的权重。</para>
		/// <para>均匀—单位面积的量级计算（所有立方图格的权重均相等）。这是默认设置。</para>
		/// <para>核—应用了平滑算法（核）的单位面积的量级计算，权重立方图格离点越近，权重越大。</para>
		/// <para><see cref="WeightEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSize">
		/// <para>Neighborhood Size</para>
		/// <para>要应用于密度计算的搜索半径。</para>
		/// <para><see cref="NeighborhoodSizeEnum"/></para>
		/// </param>
		public CalculateDensity(object InputLayer, object OutputName, object BinType, object BinSize, object Weight, object NeighborhoodSize)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.BinType = BinType;
			this.BinSize = BinSize;
			this.Weight = Weight;
			this.NeighborhoodSize = NeighborhoodSize;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算密度</para>
		/// </summary>
		public override string DisplayName() => "计算密度";

		/// <summary>
		/// <para>Tool Name : CalculateDensity</para>
		/// </summary>
		public override string ToolName() => "CalculateDensity";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CalculateDensity</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CalculateDensity";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, BinType, BinSize, Weight, NeighborhoodSize, Fields, AreaUnitScaleFactor, TimeStepInterval, TimeStepRepeat, TimeStepReference, Output, DataStore };

		/// <summary>
		/// <para>Input layer</para>
		/// <para>用于计算密度的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>指定分析中将使用的图格形状。</para>
		/// <para>正方形—图格形状将为方形。这是默认设置。</para>
		/// <para>六边形—图格形状将为六边形。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BinType { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>用于聚合输入要素的图格大小。生成方形图格时，由指定的数字和单位决定正方形的高度和长度。生成六边形图格时，由指定的数字和单位决定平行边之间的距离。</para>
		/// <para><see cref="BinSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object BinSize { get; set; }

		/// <summary>
		/// <para>Weight</para>
		/// <para>指定要应用于密度函数的权重。</para>
		/// <para>均匀—单位面积的量级计算（所有立方图格的权重均相等）。这是默认设置。</para>
		/// <para>核—应用了平滑算法（核）的单位面积的量级计算，权重立方图格离点越近，权重越大。</para>
		/// <para><see cref="WeightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Weight { get; set; } = "UNIFORM";

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// <para>要应用于密度计算的搜索半径。</para>
		/// <para><see cref="NeighborhoodSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object NeighborhoodSize { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>表示各要素的总体值的一个或多个字段。总体字段表示遍布于用来创建连续表面的景观内的计数或数量。</para>
		/// <para>总体字段中的值必须为数字。默认情况下，将始终计算输入点计数的密度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Area Unit Scale Factor</para>
		/// <para>指定输出密度值的面积单位。默认单位基于输出空间参考的单位。</para>
		/// <para>英亩—面积单位为英亩</para>
		/// <para>公顷—面积单位为公顷</para>
		/// <para>平方英里—面积单位为平方英里</para>
		/// <para>平方千米—面积单位为平方千米</para>
		/// <para>平方米—面积单位为平方米</para>
		/// <para>平方英尺—面积单位为平方英尺</para>
		/// <para>平方码—面积单位为平方码</para>
		/// <para><see cref="AreaUnitScaleFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnitScaleFactor { get; set; } = "SQUARE_KILOMETERS";

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>用来指定时间步长持续时间的值。只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// <para>只有对输入启用了时间的情况下，才可应用时间步长。</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// <para>用来指定时间步长间隔发生频率的值。只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// <para><see cref="TimeStepRepeatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>用来指定时间步长所要对齐的参考时间的日期。默认情况下为 1970 年 1 月 1 日 12:00 a.m. 只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeStepReference { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDensity SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>正方形—图格形状将为方形。这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>六边形—图格形状将为六边形。</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("六边形")]
			Hexagon,

		}

		/// <summary>
		/// <para>Bin Size</para>
		/// </summary>
		public enum BinSizeEnum 
		{
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

		/// <summary>
		/// <para>Weight</para>
		/// </summary>
		public enum WeightEnum 
		{
			/// <summary>
			/// <para>核—应用了平滑算法（核）的单位面积的量级计算，权重立方图格离点越近，权重越大。</para>
			/// </summary>
			[GPValue("KERNEL")]
			[Description("核")]
			Kernel,

			/// <summary>
			/// <para>均匀—单位面积的量级计算（所有立方图格的权重均相等）。这是默认设置。</para>
			/// </summary>
			[GPValue("UNIFORM")]
			[Description("均匀")]
			Uniform,

		}

		/// <summary>
		/// <para>Neighborhood Size</para>
		/// </summary>
		public enum NeighborhoodSizeEnum 
		{
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

		/// <summary>
		/// <para>Area Unit Scale Factor</para>
		/// </summary>
		public enum AreaUnitScaleFactorEnum 
		{
			/// <summary>
			/// <para>平方英里—面积单位为平方英里</para>
			/// </summary>
			[GPValue("SQUARE_MILES")]
			[Description("平方英里")]
			Square_miles,

			/// <summary>
			/// <para>平方千米—面积单位为平方千米</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("平方千米")]
			Square_kilometers,

			/// <summary>
			/// <para>英亩—面积单位为英亩</para>
			/// </summary>
			[GPValue("ACRES")]
			[Description("英亩")]
			Acres,

			/// <summary>
			/// <para>公顷—面积单位为公顷</para>
			/// </summary>
			[GPValue("HECTARES")]
			[Description("公顷")]
			Hectares,

			/// <summary>
			/// <para>平方码—面积单位为平方码</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("平方码")]
			Square_yards,

			/// <summary>
			/// <para>平方英尺—面积单位为平方英尺</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("平方英尺")]
			Square_feet,

			/// <summary>
			/// <para>平方米—面积单位为平方米</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("平方米")]
			Square_meters,

		}

		/// <summary>
		/// <para>Time Step Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// </summary>
		public enum TimeStepRepeatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
