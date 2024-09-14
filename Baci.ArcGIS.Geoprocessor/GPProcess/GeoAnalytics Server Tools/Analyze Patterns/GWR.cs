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
	/// <para>Geographically Weighted Regression (GWR)</para>
	/// <para>地理加权回归 (GWR)</para>
	/// <para>执行“地理加权回归 (GWR)”，这是一种用于建模空间变化关系的线性回归的局部形式。</para>
	/// </summary>
	public class GWR : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含因变量和解释变量的点要素类。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>包含将进行建模的观测值的数值字段。</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）— 因变量值是连续的。将使用高斯模型，并且工具将执行普通最小二乘法回归。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="NeighborhoodType">
		/// <para>Neighborhood Type</para>
		/// <para>指定是将使用的邻域构造为固定距离，还是允许根据要素的密度在空间范围内变化。</para>
		/// <para>相邻要素的数目— 邻域大小是每个要素的计算中包括的指定相邻要素数目的函数。在要素密集的位置，邻域的空间范围较小；在要素稀疏的位置，邻域的空间范围较大。</para>
		/// <para>距离范围—邻域大小是每个要素的恒定或固定距离。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSelectionMethod">
		/// <para>Neighborhood Selection Method</para>
		/// <para>指定将如何确定邻域大小。</para>
		/// <para>用户定义— 邻域大小将由相邻要素的数目或距离范围参数确定。</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </param>
		public GWR(object InFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeatures, object NeighborhoodType, object NeighborhoodSelectionMethod)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
			this.ExplanatoryVariables = ExplanatoryVariables;
			this.OutputFeatures = OutputFeatures;
			this.NeighborhoodType = NeighborhoodType;
			this.NeighborhoodSelectionMethod = NeighborhoodSelectionMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 地理加权回归 (GWR)</para>
		/// </summary>
		public override string DisplayName() => "地理加权回归 (GWR)";

		/// <summary>
		/// <para>Tool Name : GWR</para>
		/// </summary>
		public override string ToolName() => "GWR";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.GWR</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.GWR";

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
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, NeighborhoodType, NeighborhoodSelectionMethod, NumberOfNeighbors, DistanceBand, LocalWeightingScheme, DataStore, Output };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含因变量和解释变量的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>包含将进行建模的观测值的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>用于指定将进行建模的数据类型。</para>
		/// <para>连续（高斯）— 因变量值是连续的。将使用高斯模型，并且工具将执行普通最小二乘法回归。</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>表示回归模型中的解释变量或自变量的字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>指定是将使用的邻域构造为固定距离，还是允许根据要素的密度在空间范围内变化。</para>
		/// <para>相邻要素的数目— 邻域大小是每个要素的计算中包括的指定相邻要素数目的函数。在要素密集的位置，邻域的空间范围较小；在要素稀疏的位置，邻域的空间范围较大。</para>
		/// <para>距离范围—邻域大小是每个要素的恒定或固定距离。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// <para>指定将如何确定邻域大小。</para>
		/// <para>用户定义— 邻域大小将由相邻要素的数目或距离范围参数确定。</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodSelectionMethod { get; set; } = "USER_DEFINED";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>将要考虑的各要素的最近相邻要素数目（最多 1000）。该数值必须是介于 2 到 1000 之间的整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 5000)]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>邻域的空间范围。</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>用于指定将用于在模型中提供空间权重的核类型。核将定义每个要素与其邻域内其他要素相关的方式。</para>
		/// <para>双平方—权重 0 将会分配给指定邻域外的任何要素。这是默认设置。</para>
		/// <para>高斯函数—所有要素都将获得权重，但是距离目标要素越远，则权重将以指数方式变小。</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object LocalWeightingScheme { get; set; } = "BISQUARE";

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
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GWR SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>连续（高斯）— 因变量值是连续的。将使用高斯模型，并且工具将执行普通最小二乘法回归。</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("连续（高斯）")]
			CONTINUOUS,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>相邻要素的数目— 邻域大小是每个要素的计算中包括的指定相邻要素数目的函数。在要素密集的位置，邻域的空间范围较小；在要素稀疏的位置，邻域的空间范围较大。</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("相邻要素的数目")]
			Number_of_neighbors,

			/// <summary>
			/// <para>距离范围—邻域大小是每个要素的恒定或固定距离。</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("距离范围")]
			Distance_band,

		}

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// </summary>
		public enum NeighborhoodSelectionMethodEnum 
		{
			/// <summary>
			/// <para>用户定义— 邻域大小将由相邻要素的数目或距离范围参数确定。</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("用户定义")]
			User_defined,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
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
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>双平方—权重 0 将会分配给指定邻域外的任何要素。这是默认设置。</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("双平方")]
			Bisquare,

			/// <summary>
			/// <para>高斯函数—所有要素都将获得权重，但是距离目标要素越远，则权重将以指数方式变小。</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("高斯函数")]
			Gaussian,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
