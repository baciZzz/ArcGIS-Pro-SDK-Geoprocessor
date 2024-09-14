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
	/// <para>Generate Shapes Features From GTFS</para>
	/// <para>根据 GTFS 生成形状要素</para>
	/// <para>用于生成公共交通系统中车辆所行驶路径的预估。该工具的输出可用于为 GTFS 公共交通数据集生成新的 shapes.txt 文件。</para>
	/// </summary>
	public class GenerateShapesFeaturesFromGTFS : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsFolder">
		/// <para>Input GTFS Folder</para>
		/// <para>一个文件夹，其中包含要为其创建 shapes.txt 文件的有效 GTFS 数据集。该文件夹必须包含 GTFS、stops.txt、trips.txt、routes.txt 和 stop_times.txt 文件。</para>
		/// </param>
		/// <param name="OutShapeLines">
		/// <para>Output Transit Shape Lines</para>
		/// <para>一个线要素类，表示此工具计算的预估路径形状。输出中的每行均表示此 GTFS 数据集所需的唯一形状。可以编辑线几何，并使用此要素类作为要素转 GTFS 形状工具的输入。</para>
		/// </param>
		/// <param name="OutShapeStops">
		/// <para>Output Shape Stops</para>
		/// <para>GTFS 交通停靠点的点要素类，其中 ID 可将其与该工具要创建的每个形状线相关联。如果多个形状访问相同的 GTFS 停靠点，则此要素类将包含该停靠点的多个副本，一个副本对应于与该停靠点相关联的每个形状。如果一次编辑一个形状线，则此要素类对定义查询非常有用。可以使用此要素类作为 要素转 GTFS 形状工具的输入。</para>
		/// <para>此输出要素类不等同于 GTFS 停靠点转要素工具的输出。该工具将生成 GTFS 停靠点的要素类，这些要素类与原始数据集中的要素类完全相同，而此工具可能会生成每个停靠点的多个副本，以将其与不同的形状相关联。此输出要素类仅与根据 GTFS 生成形状要素工具的其他输出配合使用以创建 shapes.txt 文件。</para>
		/// </param>
		/// <param name="OutGtfsTrips">
		/// <para>Output GTFS Trips</para>
		/// <para>输出 GTFS trips.txt 文件。此文件将等同于输入 GTFS 文件夹中的 trips.txt 文件，但将包含添加的 shape_id 字段，已使用与输出交通形状线要素类中的 shape_id 字段对应的值填充该字段。</para>
		/// </param>
		public GenerateShapesFeaturesFromGTFS(object InGtfsFolder, object OutShapeLines, object OutShapeStops, object OutGtfsTrips)
		{
			this.InGtfsFolder = InGtfsFolder;
			this.OutShapeLines = OutShapeLines;
			this.OutShapeStops = OutShapeStops;
			this.OutGtfsTrips = OutGtfsTrips;
		}

		/// <summary>
		/// <para>Tool Display Name : 根据 GTFS 生成形状要素</para>
		/// </summary>
		public override string DisplayName() => "根据 GTFS 生成形状要素";

		/// <summary>
		/// <para>Tool Name : GenerateShapesFeaturesFromGTFS</para>
		/// </summary>
		public override string ToolName() => "GenerateShapesFeaturesFromGTFS";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GenerateShapesFeaturesFromGTFS</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GenerateShapesFeaturesFromGTFS";

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
		public override object[] Parameters() => new object[] { InGtfsFolder, OutShapeLines, OutShapeStops, OutGtfsTrips, NetworkModes, NetworkDataSource, TravelMode, DriveSide, BearingTolerance, MaxBearingAngle };

		/// <summary>
		/// <para>Input GTFS Folder</para>
		/// <para>一个文件夹，其中包含要为其创建 shapes.txt 文件的有效 GTFS 数据集。该文件夹必须包含 GTFS、stops.txt、trips.txt、routes.txt 和 stop_times.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InGtfsFolder { get; set; }

		/// <summary>
		/// <para>Output Transit Shape Lines</para>
		/// <para>一个线要素类，表示此工具计算的预估路径形状。输出中的每行均表示此 GTFS 数据集所需的唯一形状。可以编辑线几何，并使用此要素类作为要素转 GTFS 形状工具的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutShapeLines { get; set; }

		/// <summary>
		/// <para>Output Shape Stops</para>
		/// <para>GTFS 交通停靠点的点要素类，其中 ID 可将其与该工具要创建的每个形状线相关联。如果多个形状访问相同的 GTFS 停靠点，则此要素类将包含该停靠点的多个副本，一个副本对应于与该停靠点相关联的每个形状。如果一次编辑一个形状线，则此要素类对定义查询非常有用。可以使用此要素类作为 要素转 GTFS 形状工具的输入。</para>
		/// <para>此输出要素类不等同于 GTFS 停靠点转要素工具的输出。该工具将生成 GTFS 停靠点的要素类，这些要素类与原始数据集中的要素类完全相同，而此工具可能会生成每个停靠点的多个副本，以将其与不同的形状相关联。此输出要素类仅与根据 GTFS 生成形状要素工具的其他输出配合使用以创建 shapes.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutShapeStops { get; set; }

		/// <summary>
		/// <para>Output GTFS Trips</para>
		/// <para>输出 GTFS trips.txt 文件。此文件将等同于输入 GTFS 文件夹中的 trips.txt 文件，但将包含添加的 shape_id 字段，已使用与输出交通形状线要素类中的 shape_id 字段对应的值填充该字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsTrips { get; set; }

		/// <summary>
		/// <para>Transit Modes for Network</para>
		/// <para>指定将沿道路网络，而非直线生成线形状的交通模式。将使用直线生成未选择的所有模式的形状。</para>
		/// <para>通常，您应该选择在街道上运行的模式，例如公共汽车，因为道路网络可以最准确地表示这些模式。请勿选择道路网络未进行模拟的模式。例如，除非您的网络明确模拟渡轮车道，否则请勿使用网络来表示渡轮行驶的路径。</para>
		/// <para>可以使用下表中的代码来指定模式。这些模式对应于 GTFS 文档中的有效 GTFS routes.txt route_type 值。</para>
		/// <para>默认使用模式 3、5 和 11，</para>
		/// <para>有轨电车、地面电车、轻轨 (GTFS 0)— 有轨电车、地面电车、轻轨。该模式对应于 GTFS route_type 0。</para>
		/// <para>地铁 (GTFS 1)— 地铁。该模式对应于 GTFS route_type 1。</para>
		/// <para>铁路 (GTFS 2)— 铁路。该模式对应于 GTFS route_type 2。</para>
		/// <para>公共汽车 (GTFS 3)— 公共汽车。该模式对应于 GTFS route_type 3。</para>
		/// <para>渡轮 (GTFS 4)— 渡轮。该模式对应于 GTFS route_type 4。</para>
		/// <para>缆道电车 (GTFS 5)— 缆道电车。该模式对应于 GTFS route_type 5。</para>
		/// <para>空中缆车、缆索车、缆车、架空索道 (GTFS 6)— 空中缆车、缆索车、缆车、架空索道。该模式对应于 GTFS route_type 6。</para>
		/// <para>索道 (GTFS 7)— 索道。该模式对应于 GTFS route_type 7。</para>
		/// <para>无轨电车 (GTFS 11)— 无轨电车。该模式对应于 GTFS route_type 11。</para>
		/// <para>单轨索道 (GTFS 12)— 单轨索道。该模式对应于 GTFS route_type 12。</para>
		/// <para>其他交通模式—其他选项未涵盖的任何公共交通模式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object NetworkModes { get; set; } = "3;5;11";

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>网络数据集或服务，将用于计算沿道路网络的路径形状。可以使用网络数据集的目录路径、网络数据集图层对象、网络数据集图层的字符串名称或网络分析服务的门户 URL。网络必须包含至少一个出行模式。</para>
		/// <para>要使用门户 URL，您必须使用具有路径选择权限的帐户登录门户。</para>
		/// <para>如果使用 ArcGIS Online 作为网络数据源，则运行该工具将消耗配额。</para>
		/// <para>如果选择任何网络模式，则此参数为必需项。</para>
		/// <para>您选择的网络数据集应该适用于模拟在街道上行驶的交通车辆，例如公共汽车。请勿使用经过配置的网络数据集，该网络数据集将公共交通数据与公共交通赋值器配合使用，因为此类型的网络将模拟乘坐公共交通的乘客，而非在街道上行驶的公共交通车辆。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDataSource()]
		[Category("Network options")]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>计算沿道路网络的路径形状时要使用的网络数据源上的出行模式。可以指定出行模式作为出行模式的字符串名称，也可以作为 arcpy.nax.TravelMode 对象。</para>
		/// <para>在沿道路网络行驶的交通系统中，可以使用最适用于模拟车辆的出行模式。</para>
		/// <para>如果选择任何网络模式，则此参数为必需项。</para>
		/// <para>请勿将出行模式与使用公共交通赋值器的阻抗属性配合使用，因为该出行模式将模拟乘坐公共交通的乘客，而非在街道上行驶的交通车辆。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NetworkTravelMode()]
		[Category("Network options")]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Side of Road on which Vehicles Drive</para>
		/// <para>指定车辆在交通系统中行驶的道路侧。这可用于确保访问正确道路侧上的停靠点。</para>
		/// <para>左侧—车辆将行驶在道路左侧。</para>
		/// <para>右侧—车辆将行驶在道路右侧。这是默认设置。</para>
		/// <para><see cref="DriveSideEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network options")]
		public object DriveSide { get; set; } = "RIGHT";

		/// <summary>
		/// <para>Bearing Tolerance</para>
		/// <para>在计算沿道路网络的路径形状时，方位角和方位角容差可用于更精确地定位沿道路网络的交通停靠点。根据当前停靠点与沿交通路径的上一个停靠点和下一个停靠点之间的角度，估算每个停靠点处交通车辆的方位角。</para>
		/// <para>此参数中指定的值将指示停靠点处交通车辆的预估行驶方向之间的最大允许角度以及该停靠点位于的网络边的角度。如果角度差值超过此值，则 Network Analyst 将假设这并非要在其上定位停靠点的正确网络边，并且将继续搜索其他附近网络边以寻找更合适的网络边。</para>
		/// <para>指定一个介于 0 到 180 之间的值，以度为单位。默认值为 30。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 180)]
		[Category("Network options")]
		public object BearingTolerance { get; set; } = "30";

		/// <summary>
		/// <para>Maximum Bearing Angle Difference</para>
		/// <para>根据当前停靠点与沿交通路径的上一个停靠点和下一个停靠点之间的角度，估算每个停靠点处交通车辆的方位角。如果交通路径沿相对较直的道路，则此角度是方位角的良好表示。但是，如果该路径出现转弯、调头、弯路或者改道进入停车场或旁路，则平均角度不是实际方位角的良好预估，使用此预估会导致要在网络上定位的停靠点远离其应有位置，并且会降低工具输出的质量。</para>
		/// <para>如果上一个停靠点到当前停靠点以及当前停靠点到下一个停靠点的角度差值大于此参数中指定的值，则该工具将忽略方位角预估。在这种情况下，停靠点将恢复为正常网络定位行为，并将捕捉到最近的非限制网络边。</para>
		/// <para>指定一个介于 0 到 180 之间的值，以度为单位。默认值为 65。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 180)]
		[Category("Network options")]
		public object MaxBearingAngle { get; set; } = "65";

		#region InnerClass

		/// <summary>
		/// <para>Side of Road on which Vehicles Drive</para>
		/// </summary>
		public enum DriveSideEnum 
		{
			/// <summary>
			/// <para>左侧—车辆将行驶在道路左侧。</para>
			/// </summary>
			[GPValue("LEFT")]
			[Description("左侧")]
			Left,

			/// <summary>
			/// <para>右侧—车辆将行驶在道路右侧。这是默认设置。</para>
			/// </summary>
			[GPValue("RIGHT")]
			[Description("右侧")]
			Right,

		}

#endregion
	}
}
