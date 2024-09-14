using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.PublicTransitTools
{
	/// <summary>
	/// <para>Connect Public Transit Data Model To Streets</para>
	/// <para>将公共交通数据模型连接到街道</para>
	/// <para>将交通停靠点连接到街道要素，以便在启用交通的网络数据集中使用。 此工具可创建 Network Analyst 公共交通数据模型所定义的 StopsOnStreets 和 StopConnectors 要素类，并可作为较大工作流的一部分运行，以创建和使用具有公共交通数据的网络数据集中所描述的交通网络数据集。</para>
	/// </summary>
	public class ConnectPublicTransitDataModelToStreets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>将创建启用交通的网络数据集的要素数据集。 此要素数据集必须已经存在，并包含称为 Stops 的点要素类，以及 Network Analyst 公共交通数据模型中所描述的方案。 可使用 GTFS 转网络数据集交通源工具创建有效的 Stops 要素类。</para>
		/// <para>运行该工具后，Stops 要素类可能会更改。 GStopType 值为 2 的停靠点要素表示入站口，可以删除。 这些停靠点要素将包括在输出 StopsOnStreets 要素类中，用于对从街道，通过入站口，到停靠点的正确连接进行建模。 也可以删除在空间上与停靠点重合的父站点。</para>
		/// </param>
		/// <param name="InStreetsFeatures">
		/// <para>Input Streets Features</para>
		/// <para>交通停靠点和交通线将连接到的街道的折线要素类。 此街道要素类应与您打算在启用交通的网络数据集中使用的要素类相同，以便对沿着街道行走的行人进行建模。 要运行此工具，要素类不需要位于目标要素数据集中；但是，在创建网络数据集时，要素类必须位于目标要素数据集中。</para>
		/// <para>运行该工具后，输入街道要素将被更改。 折点将添加到 StopsOnStreets 要素与街道相交的位置。 如果您不希望更改街道数据，请在运行此工具之前创建副本。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于将交通停靠点捕捉到输入街道要素的搜索距离。 超出搜索距离的停靠点不会被捕捉，也不会连接到街道。 较小的搜索距离可以确保停靠点不会捕捉到远处的街道，但是会增加停靠点在应进行捕捉时捕捉失败的可能性。 较大的搜索距离会增加停靠点可能的捕捉次数，但可能会导致误差，这些误差需要通过编辑街道数据来纠正。 如果在特定停靠点的搜索距离内没有找到街道要素，则输出 StopsOnStreets 要素将不会捕捉到街道，并将与 Stops 中的相应要素重合，这可能导致该位置的网络数据集中连接质量较差。</para>
		/// <para>默认值是 100 米。</para>
		/// </param>
		public ConnectPublicTransitDataModelToStreets(object TargetFeatureDataset, object InStreetsFeatures, object SearchDistance)
		{
			this.TargetFeatureDataset = TargetFeatureDataset;
			this.InStreetsFeatures = InStreetsFeatures;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 将公共交通数据模型连接到街道</para>
		/// </summary>
		public override string DisplayName() => "将公共交通数据模型连接到街道";

		/// <summary>
		/// <para>Tool Name : ConnectPublicTransitDataModelToStreets</para>
		/// </summary>
		public override string ToolName() => "ConnectPublicTransitDataModelToStreets";

		/// <summary>
		/// <para>Tool Excute Name : transit.ConnectPublicTransitDataModelToStreets</para>
		/// </summary>
		public override string ExcuteName() => "transit.ConnectPublicTransitDataModelToStreets";

		/// <summary>
		/// <para>Toolbox Display Name : Public Transit Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Public Transit Tools";

		/// <summary>
		/// <para>Toolbox Alise : transit</para>
		/// </summary>
		public override string ToolboxAlise() => "transit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatureDataset, InStreetsFeatures, SearchDistance, Expression!, UpdatedTargetFeatureDataset!, UpdatedInStreetsFeatures!, UpdatedInStops!, OutputStopsOnStreets!, OutputStopConnectors! };

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>将创建启用交通的网络数据集的要素数据集。 此要素数据集必须已经存在，并包含称为 Stops 的点要素类，以及 Network Analyst 公共交通数据模型中所描述的方案。 可使用 GTFS 转网络数据集交通源工具创建有效的 Stops 要素类。</para>
		/// <para>运行该工具后，Stops 要素类可能会更改。 GStopType 值为 2 的停靠点要素表示入站口，可以删除。 这些停靠点要素将包括在输出 StopsOnStreets 要素类中，用于对从街道，通过入站口，到停靠点的正确连接进行建模。 也可以删除在空间上与停靠点重合的父站点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Input Streets Features</para>
		/// <para>交通停靠点和交通线将连接到的街道的折线要素类。 此街道要素类应与您打算在启用交通的网络数据集中使用的要素类相同，以便对沿着街道行走的行人进行建模。 要运行此工具，要素类不需要位于目标要素数据集中；但是，在创建网络数据集时，要素类必须位于目标要素数据集中。</para>
		/// <para>运行该工具后，输入街道要素将被更改。 折点将添加到 StopsOnStreets 要素与街道相交的位置。 如果您不希望更改街道数据，请在运行此工具之前创建副本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InStreetsFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>用于将交通停靠点捕捉到输入街道要素的搜索距离。 超出搜索距离的停靠点不会被捕捉，也不会连接到街道。 较小的搜索距离可以确保停靠点不会捕捉到远处的街道，但是会增加停靠点在应进行捕捉时捕捉失败的可能性。 较大的搜索距离会增加停靠点可能的捕捉次数，但可能会导致误差，这些误差需要通过编辑街道数据来纠正。 如果在特定停靠点的搜索距离内没有找到街道要素，则输出 StopsOnStreets 要素将不会捕捉到街道，并将与 Stops 中的相应要素重合，这可能导致该位置的网络数据集中连接质量较差。</para>
		/// <para>默认值是 100 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择输入街道要素记录子集的 SQL 表达式。 交通停靠点仅会捕捉到与此表达式匹配的街道要素。 例如，此表达式可以用于防止停靠点捕捉到禁止行人通行的街道。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Updated Target Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? UpdatedTargetFeatureDataset { get; set; }

		/// <summary>
		/// <para>Updated Input Streets Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedInStreetsFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? UpdatedInStops { get; set; }

		/// <summary>
		/// <para>Output Stops On Streets</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutputStopsOnStreets { get; set; }

		/// <summary>
		/// <para>Output Stop Connectors</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutputStopConnectors { get; set; }

	}
}
