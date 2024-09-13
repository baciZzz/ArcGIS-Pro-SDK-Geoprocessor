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
	/// <para>Features To GTFS Shapes</para>
	/// <para>要素转 GTFS 形状</para>
	/// <para>可基于根据 GTFS 生成形状要素工具创建的路线制图表达，为 GTFS 公共交通数据集创建 shapes.txt 文件。</para>
	/// </summary>
	public class FeaturesToGTFSShapes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InShapeLines">
		/// <para>Input Shape Lines</para>
		/// <para>一个线要素类，表示通过运行根据 GTFS 生成形状要素工具创建的 GTFS形状。该要素类必须包含 shape_id 字段，其中值对应于其他工具输入中的 shape_id 字段值。</para>
		/// </param>
		/// <param name="InShapeStops">
		/// <para>Input Shape Stops</para>
		/// <para>一个点要素类，表示与通过运行根据 GTFS 生成形状要素工具创建的每个形状相关联的 GTFS 停靠点。如果多个形状使用交通停靠点，则应在此要素类中针对使用该停靠点的每个形状复制该停靠点。</para>
		/// <para>该要素类必须包含 shape_id 字段，其中值对应于其他工具输入中的 shape_id 字段值。它还必须包含 stop_id 字段，其中值对应于输入 GTFS stop_times.txt 文件中 shape_id 列的值。</para>
		/// </param>
		/// <param name="InGtfsTrips">
		/// <para>Input Updated GTFS Trips</para>
		/// <para>通过运行根据 GTFS 生成形状要素工具创建的更新后的 GTFS trips.txt 文件。该文件必须具有 shape_id 列，其值对应于其他工具输入中 shape_id 字段的值。</para>
		/// </param>
		/// <param name="InGtfsStopTimes">
		/// <para>Input GTFS Stop Times</para>
		/// <para>运行根据 GTFS 生成形状要素工具时使用的 GTFS 数据集中的原始 stop_times.txt 文件。</para>
		/// </param>
		/// <param name="OutGtfsShapes">
		/// <para>Output GTFS Shapes</para>
		/// <para>输出 GTFS shapes.txt 文件。</para>
		/// </param>
		/// <param name="OutGtfsStopTimes">
		/// <para>Output GTFS Stop Times</para>
		/// <para>输出 GTFS stop_times.txt 文件，此文件将包含 shape_dist_traveled 字段，其中值源自新形状。</para>
		/// </param>
		public FeaturesToGTFSShapes(object InShapeLines, object InShapeStops, object InGtfsTrips, object InGtfsStopTimes, object OutGtfsShapes, object OutGtfsStopTimes)
		{
			this.InShapeLines = InShapeLines;
			this.InShapeStops = InShapeStops;
			this.InGtfsTrips = InGtfsTrips;
			this.InGtfsStopTimes = InGtfsStopTimes;
			this.OutGtfsShapes = OutGtfsShapes;
			this.OutGtfsStopTimes = OutGtfsStopTimes;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转 GTFS 形状</para>
		/// </summary>
		public override string DisplayName() => "要素转 GTFS 形状";

		/// <summary>
		/// <para>Tool Name : FeaturesToGTFSShapes</para>
		/// </summary>
		public override string ToolName() => "FeaturesToGTFSShapes";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeaturesToGTFSShapes</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeaturesToGTFSShapes";

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
		public override string[] ValidEnvironments() => new string[] { "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InShapeLines, InShapeStops, InGtfsTrips, InGtfsStopTimes, OutGtfsShapes, OutGtfsStopTimes, DistanceUnits };

		/// <summary>
		/// <para>Input Shape Lines</para>
		/// <para>一个线要素类，表示通过运行根据 GTFS 生成形状要素工具创建的 GTFS形状。该要素类必须包含 shape_id 字段，其中值对应于其他工具输入中的 shape_id 字段值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InShapeLines { get; set; }

		/// <summary>
		/// <para>Input Shape Stops</para>
		/// <para>一个点要素类，表示与通过运行根据 GTFS 生成形状要素工具创建的每个形状相关联的 GTFS 停靠点。如果多个形状使用交通停靠点，则应在此要素类中针对使用该停靠点的每个形状复制该停靠点。</para>
		/// <para>该要素类必须包含 shape_id 字段，其中值对应于其他工具输入中的 shape_id 字段值。它还必须包含 stop_id 字段，其中值对应于输入 GTFS stop_times.txt 文件中 shape_id 列的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InShapeStops { get; set; }

		/// <summary>
		/// <para>Input Updated GTFS Trips</para>
		/// <para>通过运行根据 GTFS 生成形状要素工具创建的更新后的 GTFS trips.txt 文件。该文件必须具有 shape_id 列，其值对应于其他工具输入中 shape_id 字段的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsTrips { get; set; }

		/// <summary>
		/// <para>Input GTFS Stop Times</para>
		/// <para>运行根据 GTFS 生成形状要素工具时使用的 GTFS 数据集中的原始 stop_times.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsStopTimes { get; set; }

		/// <summary>
		/// <para>Output GTFS Shapes</para>
		/// <para>输出 GTFS shapes.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsShapes { get; set; }

		/// <summary>
		/// <para>Output GTFS Stop Times</para>
		/// <para>输出 GTFS stop_times.txt 文件，此文件将包含 shape_dist_traveled 字段，其中值源自新形状。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsStopTimes { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>指定在填充输出 GTFS 文件中的 shape_dist_traveled 字段时要使用的距离单位。</para>
		/// <para>英里—单位为英里。这是默认设置。</para>
		/// <para>米—单位为米</para>
		/// <para>千米—单位为千米</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "MILES";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGTFSShapes SetEnviroment(object randomGenerator = null )
		{
			base.SetEnv(randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>英里—单位为英里。这是默认设置。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>米—单位为米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—单位为千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

		}

#endregion
	}
}
