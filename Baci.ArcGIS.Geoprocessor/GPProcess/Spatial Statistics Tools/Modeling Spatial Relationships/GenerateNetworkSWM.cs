using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Generate Network Spatial Weights</para>
	/// <para>生成网络空间权重</para>
	/// <para>使用网络数据集构建一个空间权重矩阵文件 (.swm)，从而在基础网络结构方面定义空间关系。</para>
	/// </summary>
	public class GenerateNetworkSWM : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>表示网络上的位置的点要素类。对于每个要素，计算相邻要素和权重并将其存储在输出空间权重矩阵文件中。</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素唯一值的整型字段。如果没有具有唯一 ID 值的字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </param>
		/// <param name="OutputSpatialWeightsMatrixFile">
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>此输出网络空间权重矩阵文件 (.swm) 将存储每个输入要素的相邻要素和权重。</para>
		/// </param>
		/// <param name="InputNetworkDataSource">
		/// <para>Input Network Data Source</para>
		/// <para>用于查找每个输入要素的相邻要素的网络数据集。网络数据集通常表示街道网络，但也可以表示其他种类的运输网络，例如铁路或步行路径。网络数据集必须至少包含一个与距离、行驶时间或成本相关的属性。</para>
		/// </param>
		/// <param name="TravelMode">
		/// <para>Travel Mode</para>
		/// <para>用于分析的交通模式。出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于定义行人、汽车、卡车或其他交通媒介在网络中的移动方式。</para>
		/// </param>
		public GenerateNetworkSWM(object InputFeatureClass, object UniqueIDField, object OutputSpatialWeightsMatrixFile, object InputNetworkDataSource, object TravelMode)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.UniqueIDField = UniqueIDField;
			this.OutputSpatialWeightsMatrixFile = OutputSpatialWeightsMatrixFile;
			this.InputNetworkDataSource = InputNetworkDataSource;
			this.TravelMode = TravelMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成网络空间权重</para>
		/// </summary>
		public override string DisplayName() => "生成网络空间权重";

		/// <summary>
		/// <para>Tool Name : GenerateNetworkSWM</para>
		/// </summary>
		public override string ToolName() => "GenerateNetworkSWM";

		/// <summary>
		/// <para>Tool Excute Name : stats.GenerateNetworkSWM</para>
		/// </summary>
		public override string ExcuteName() => "stats.GenerateNetworkSWM";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, InputNetworkDataSource, TravelMode, ImpedanceDistanceCutoff!, ImpedanceTemporalCutoff!, ImpedanceCostCutoff!, MaximumNumberOfNeighbors!, TimeOfDay!, TimeZone!, Barriers!, SearchTolerance!, ConceptualizationOfSpatialRelationships!, Exponent!, RowStandardization! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>表示网络上的位置的点要素类。对于每个要素，计算相邻要素和权重并将其存储在输出空间权重矩阵文件中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素唯一值的整型字段。如果没有具有唯一 ID 值的字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>此输出网络空间权重矩阵文件 (.swm) 将存储每个输入要素的相邻要素和权重。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Input Network Data Source</para>
		/// <para>用于查找每个输入要素的相邻要素的网络数据集。网络数据集通常表示街道网络，但也可以表示其他种类的运输网络，例如铁路或步行路径。网络数据集必须至少包含一个与距离、行驶时间或成本相关的属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDataSource()]
		public object InputNetworkDataSource { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>用于分析的交通模式。出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于定义行人、汽车、卡车或其他交通媒介在网络中的移动方式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Impedance Distance Cutoff</para>
		/// <para>所允许的、要素的相邻要素最大阻抗距离。距离比该值远的任何要素都不会用作相邻要素。默认情况下不使用距离中断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		[Category("Network Analysis Options")]
		public object? ImpedanceDistanceCutoff { get; set; }

		/// <summary>
		/// <para>Impedance Temporal Cutoff</para>
		/// <para>所允许的、要素的相邻要素最大阻抗行驶时间。行驶时间比该值长的任何要素都不会用作相邻要素。默认情况下不使用临时中断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		[Category("Network Analysis Options")]
		public object? ImpedanceTemporalCutoff { get; set; }

		/// <summary>
		/// <para>Impedance Cost Cutoff</para>
		/// <para>所允许的、要素的相邻要素最大阻抗成本。行驶成本比该值大的任何要素都不会用作相邻要素。默认情况下不使用成本中断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Network Analysis Options")]
		public object? ImpedanceCostCutoff { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>用于表示各要素的最大相邻要素数的整数。由于阻抗中断，用于每个要素的实际相邻要素数可能会更少。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Network Analysis Options")]
		public object? MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>将在分析中考虑一天中的交通状况。交通状况会影响可在给定时间内行驶的距离。如果未提供任何日期或时间，则分析将不会考虑流量的影响。</para>
		/// <para>您可以使用以下日期而非特定日期来指定一周中的某一天：</para>
		/// <para>今天 - 12/30/1899</para>
		/// <para>星期日 - 12/31/1899</para>
		/// <para>星期一 - 1/1/1900</para>
		/// <para>星期二 - 1/2/1900</para>
		/// <para>星期三 - 1/3/1900</para>
		/// <para>星期四 - 1/4/1900</para>
		/// <para>星期五 - 1/5/1900</para>
		/// <para>星期六 - 1/6/1900</para>
		/// <para>例如，要指定行程从星期二 5:00 p.m. 开始，则请将该参数值指定为 1/2/1900 5:00 PM。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Analysis Options")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>指定时间参数的时区。</para>
		/// <para>各位置的本地时间—将使用输入要素类位于的时区。这是默认设置。</para>
		/// <para>UTC—将使用世界标准时间 (UTC)。</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Analysis Options")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>此要素用于表示阻塞的路口、封锁的道路、事故现场或网络中行程被阻止的其他位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		[Category("Network Analysis Options")]
		public object? Barriers { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>用于将每个输入要素分配到网络上的某个位置的最大距离。如果任何输入点并未恰好位于网络的线上，它们将被分配到网络上最近的位置进行分析。但是，如果该要素比来自网络上任何位置的搜索容差值都远，则该要素将不会被分配给网络，也不会包含在分析中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		[Category("Network Analysis Options")]
		public object? SearchTolerance { get; set; } = "5000 Meters";

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定为每个相邻要素定义权重的方式。</para>
		/// <para>反向—距离、时间或成本中较远的要素的权重将比附近的要素小。权重将按指数的倒数减小。</para>
		/// <para>固定—所有相邻要素都将获得同等权重。这是默认设置。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object? ConceptualizationOfSpatialRelationships { get; set; } = "FIXED";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>为空间关系的概念化参数指定反向时使用的指数。通过将距离、时间或成本乘以指数幂来计算已分配给每个相邻要素的权重。默认值为 1，且该值必须介于 0.01 到 4 之间。权重将随着指数的增加而更快地下降。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.10000000000000001, Max = 4)]
		[Category("Weights Options")]
		public object? Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>指定是否会应用行标准化。当输入点的位置由于采样设计或施加的聚合方案而可能偏离时，建议使用行标准化。此外，还建议您在根据反距离、时间或成本对相邻要素加权时，对行进行标准化。</para>
		/// <para>选中 - 将按行对空间权重执行标准化。每个权重都除以它的行总和。这是默认设置。</para>
		/// <para>未选中 - 将不会对空间权重执行标准化。</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object? RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateNetworkSWM SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>各位置的本地时间—将使用输入要素类位于的时区。这是默认设置。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

			/// <summary>
			/// <para>UTC—将使用世界标准时间 (UTC)。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>固定—所有相邻要素都将获得同等权重。这是默认设置。</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("固定")]
			Fixed,

			/// <summary>
			/// <para>反向—距离、时间或成本中较远的要素的权重将比附近的要素小。权重将按指数的倒数减小。</para>
			/// </summary>
			[GPValue("INVERSE")]
			[Description("反向")]
			Inverse,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STANDARDIZATION")]
			NO_STANDARDIZATION,

		}

#endregion
	}
}
