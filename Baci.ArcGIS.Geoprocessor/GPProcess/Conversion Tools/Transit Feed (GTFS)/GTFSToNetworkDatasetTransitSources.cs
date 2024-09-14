using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>GTFS To Network Dataset Transit Sources</para>
	/// <para>GTFS 转网络数据集交通源</para>
	/// <para>用于将一个或多个通用交通数据规范 (GTFS) 公共交通数据集转换为一组要素类和表，以在创建网络数据集时使用。 输出要素类和表使用 Network Analyst 公共交通数据模型定义的格式表示交通停靠点、线和时间表，可使用网络数据集中的公共交通赋值器进行解释。</para>
	/// </summary>
	public class GTFSToNetworkDatasetTransitSources : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsFolders">
		/// <para>Input GTFS Folders</para>
		/// <para>一个或多个包含有效 GTFS 数据的文件夹。 每个文件夹必须包含 GTFS stops.txt、routes.txt、trips.txt 和 stop_times.txt 文件，以及 calendar.txt 或 calendar_dates.txt 文件，或二者兼而有之。</para>
		/// </param>
		/// <param name="TargetFeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>将创建启用交通的网络数据集的要素数据集。 此工具创建的 Stops 和 LineVariantElements 要素类将放置在此要素数据集中，此工具创建的输出表将放置在此要素数据集的父地理数据库中。</para>
		/// <para>要素数据集可以位于文件地理数据库或企业级地理数据库中，并且可以包含任何空间参考。 如果目标要素数据集位于企业级地理数据库中，则不得对其进行版本化。 具有含公共交通数据模型要素类的现有要素数据集中不应包括目标要素数据集。</para>
		/// </param>
		public GTFSToNetworkDatasetTransitSources(object InGtfsFolders, object TargetFeatureDataset)
		{
			this.InGtfsFolders = InGtfsFolders;
			this.TargetFeatureDataset = TargetFeatureDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : GTFS 转网络数据集交通源</para>
		/// </summary>
		public override string DisplayName() => "GTFS 转网络数据集交通源";

		/// <summary>
		/// <para>Tool Name : GTFSToNetworkDatasetTransitSources</para>
		/// </summary>
		public override string ToolName() => "GTFSToNetworkDatasetTransitSources";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GTFSToNetworkDatasetTransitSources</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GTFSToNetworkDatasetTransitSources";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGtfsFolders, TargetFeatureDataset, UpdatedTargetFeatureDataset, OutputStops, OutputLineVariantElements, OutputCalendars, OutputCalendarExceptions, OutputLines, OutputLineVariants, OutputRuns, OutputScheduleElements, OutputSchedules, Interpolate, Append };

		/// <summary>
		/// <para>Input GTFS Folders</para>
		/// <para>一个或多个包含有效 GTFS 数据的文件夹。 每个文件夹必须包含 GTFS stops.txt、routes.txt、trips.txt 和 stop_times.txt 文件，以及 calendar.txt 或 calendar_dates.txt 文件，或二者兼而有之。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InGtfsFolders { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>将创建启用交通的网络数据集的要素数据集。 此工具创建的 Stops 和 LineVariantElements 要素类将放置在此要素数据集中，此工具创建的输出表将放置在此要素数据集的父地理数据库中。</para>
		/// <para>要素数据集可以位于文件地理数据库或企业级地理数据库中，并且可以包含任何空间参考。 如果目标要素数据集位于企业级地理数据库中，则不得对其进行版本化。 具有含公共交通数据模型要素类的现有要素数据集中不应包括目标要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Updated Target Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object UpdatedTargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutputStops { get; set; }

		/// <summary>
		/// <para>Output Line Variant Elements</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutputLineVariantElements { get; set; }

		/// <summary>
		/// <para>Output Calendars</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputCalendars { get; set; }

		/// <summary>
		/// <para>Output Calendar Exceptions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputCalendarExceptions { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputLines { get; set; }

		/// <summary>
		/// <para>Output Line Variants</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputLineVariants { get; set; }

		/// <summary>
		/// <para>Output Runs</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputRuns { get; set; }

		/// <summary>
		/// <para>Output Schedule Elements</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputScheduleElements { get; set; }

		/// <summary>
		/// <para>Output Schedules</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutputSchedules { get; set; }

		/// <summary>
		/// <para>Interpolate blank stop times</para>
		/// <para>指定在创建公共交通数据模型表时，是否在 GTFS stop_times.txt 文件中 arrival_time 和 departure_time 字段中内插空白值。</para>
		/// <para>选中 - 将使用简单的线性插值法内插空白值。 原始 GTFS 数据不会被更改。 如果原始数据中没有空白值，则不会进行插值。</para>
		/// <para>未选中 - 将不会内插空白值。 如果在输入 GTFS 数据中找到空白值，则该工具将发出警告且不会处理 GTFS 数据集。 这是默认设置。</para>
		/// <para><see cref="InterpolateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Interpolate { get; set; } = "false";

		/// <summary>
		/// <para>Append to existing tables</para>
		/// <para>指定是否将输入 GTFS 数据集追加到目标要素数据集及其父地理数据库中的现有公共交通数据模型要素类和表。</para>
		/// <para>如果目标要素数据集及其父地理数据库不包含现有公共交通数据模型要素类和表，则将隐藏此参数。</para>
		/// <para>选中 - 数据将被追加到现有要素类和表。</para>
		/// <para>未选中 - 将覆盖现有要素类和表。 这是默认设置。</para>
		/// <para><see cref="AppendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Append { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Interpolate blank stop times</para>
		/// </summary>
		public enum InterpolateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INTERPOLATE")]
			INTERPOLATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_INTERPOLATE")]
			NO_INTERPOLATE,

		}

		/// <summary>
		/// <para>Append to existing tables</para>
		/// </summary>
		public enum AppendEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPEND")]
			NO_APPEND,

		}

#endregion
	}
}
