using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Create Network Dataset</para>
	/// <para>创建网络数据集</para>
	/// <para>在现有要素数据集中创建网络数据集。网络数据集可用于对要素数据集中的数据执行网络分析。</para>
	/// </summary>
	public class CreateNetworkDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FeatureDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>将创建网络数据集的要素数据集。要素数据集应包含将参与网络数据集的源要素类。</para>
		/// <para>如果要素数据集位于企业级地理数据库中，则无法对要素数据集和所有源要素类进行版本化。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Network Dataset Name</para>
		/// <para>要创建的网络数据集的名称。目标要素数据集及其父地理数据库不得包含具有此名称的网络数据集。</para>
		/// </param>
		/// <param name="SourceFeatureClassNames">
		/// <para>Source Feature Classes</para>
		/// <para>要作为网络源要素包含在网络数据集中的要素类的名称。将此参数指定为字符串列表。</para>
		/// <para>必须至少选择一个不是转弯要素类的线要素类。该线要素类将在网络数据集中用作边源。您可以选择点要素类作为网络数据集中的交汇点源，选择转弯要素类作为转弯源。</para>
		/// <para>所有源要素类必须位于目标要素数据集中，且不得参与几何网络、公共设施网络或其他网络数据集。</para>
		/// </param>
		/// <param name="ElevationModel">
		/// <para>Elevation Model</para>
		/// <para>指定用于控制网络数据集中垂直连通性的模型。</para>
		/// <para>高程字段— 具有相同高程字段值的重合端点在网络数据集中被视为连接。这是默认设置。</para>
		/// <para>Z 坐标—线要素几何中的 z 坐标值用于确定垂直连通性。仅当重合点具有匹配的 z 坐标值时，才将其视为连接。</para>
		/// <para>无高程— 网络数据集连通性仅由水平重合确定。</para>
		/// <para><see cref="ElevationModelEnum"/></para>
		/// </param>
		public CreateNetworkDataset(object FeatureDataset, object OutName, object SourceFeatureClassNames, object ElevationModel)
		{
			this.FeatureDataset = FeatureDataset;
			this.OutName = OutName;
			this.SourceFeatureClassNames = SourceFeatureClassNames;
			this.ElevationModel = ElevationModel;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建网络数据集</para>
		/// </summary>
		public override string DisplayName() => "创建网络数据集";

		/// <summary>
		/// <para>Tool Name : CreateNetworkDataset</para>
		/// </summary>
		public override string ToolName() => "CreateNetworkDataset";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateNetworkDataset</para>
		/// </summary>
		public override string ExcuteName() => "na.CreateNetworkDataset";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { FeatureDataset, OutName, SourceFeatureClassNames, ElevationModel, OutNetworkDataset };

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>将创建网络数据集的要素数据集。要素数据集应包含将参与网络数据集的源要素类。</para>
		/// <para>如果要素数据集位于企业级地理数据库中，则无法对要素数据集和所有源要素类进行版本化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object FeatureDataset { get; set; }

		/// <summary>
		/// <para>Network Dataset Name</para>
		/// <para>要创建的网络数据集的名称。目标要素数据集及其父地理数据库不得包含具有此名称的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Source Feature Classes</para>
		/// <para>要作为网络源要素包含在网络数据集中的要素类的名称。将此参数指定为字符串列表。</para>
		/// <para>必须至少选择一个不是转弯要素类的线要素类。该线要素类将在网络数据集中用作边源。您可以选择点要素类作为网络数据集中的交汇点源，选择转弯要素类作为转弯源。</para>
		/// <para>所有源要素类必须位于目标要素数据集中，且不得参与几何网络、公共设施网络或其他网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object SourceFeatureClassNames { get; set; }

		/// <summary>
		/// <para>Elevation Model</para>
		/// <para>指定用于控制网络数据集中垂直连通性的模型。</para>
		/// <para>高程字段— 具有相同高程字段值的重合端点在网络数据集中被视为连接。这是默认设置。</para>
		/// <para>Z 坐标—线要素几何中的 z 坐标值用于确定垂直连通性。仅当重合点具有匹配的 z 坐标值时，才将其视为连接。</para>
		/// <para>无高程— 网络数据集连通性仅由水平重合确定。</para>
		/// <para><see cref="ElevationModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationModel { get; set; } = "ELEVATION_FIELDS";

		/// <summary>
		/// <para>Output Network Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DENetworkDataset()]
		public object OutNetworkDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Elevation Model</para>
		/// </summary>
		public enum ElevationModelEnum 
		{
			/// <summary>
			/// <para>高程字段— 具有相同高程字段值的重合端点在网络数据集中被视为连接。这是默认设置。</para>
			/// </summary>
			[GPValue("ELEVATION_FIELDS")]
			[Description("高程字段")]
			Elevation_fields,

			/// <summary>
			/// <para>Z 坐标—线要素几何中的 z 坐标值用于确定垂直连通性。仅当重合点具有匹配的 z 坐标值时，才将其视为连接。</para>
			/// </summary>
			[GPValue("Z_COORDINATES")]
			[Description("Z 坐标")]
			Z_coordinates,

			/// <summary>
			/// <para>无高程— 网络数据集连通性仅由水平重合确定。</para>
			/// </summary>
			[GPValue("NO_ELEVATION")]
			[Description("无高程")]
			No_elevation,

		}

#endregion
	}
}
