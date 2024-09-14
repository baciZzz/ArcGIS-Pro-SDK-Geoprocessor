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
	/// <para>Features To GTFS Stops</para>
	/// <para>要素转 GTFS 停靠点</para>
	/// <para>用于将要素类转换为 GTFS 公共交通数据集的 GTFS stops.txt 文件。</para>
	/// </summary>
	[Obsolete()]
	public class FeaturesToGTFSStops : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>此点要素类包含交通停靠点几何，且至少包含最低要求的 GTFS stops.txt 文件字段，但 stop_lat 和 stop_lon 除外。</para>
		/// </param>
		/// <param name="OutGtfsStopsFile">
		/// <para>Output GTFS Stops File</para>
		/// <para>输出 stops.txt 文件。</para>
		/// </param>
		public FeaturesToGTFSStops(object InFeatures, object OutGtfsStopsFile)
		{
			this.InFeatures = InFeatures;
			this.OutGtfsStopsFile = OutGtfsStopsFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转 GTFS 停靠点</para>
		/// </summary>
		public override string DisplayName() => "要素转 GTFS 停靠点";

		/// <summary>
		/// <para>Tool Name : FeaturesToGTFSStops</para>
		/// </summary>
		public override string ToolName() => "FeaturesToGTFSStops";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeaturesToGTFSStops</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeaturesToGTFSStops";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutGtfsStopsFile };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>此点要素类包含交通停靠点几何，且至少包含最低要求的 GTFS stops.txt 文件字段，但 stop_lat 和 stop_lon 除外。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output GTFS Stops File</para>
		/// <para>输出 stops.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object OutGtfsStopsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGTFSStops SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
