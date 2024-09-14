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
	/// <para>Turn Table To Turn Feature Class</para>
	/// <para>转弯表至转弯要素类</para>
	/// <para>将 ArcView 转弯表或 ArcInfo Workstation coverage 转弯表转换为 ArcGIS 转弯要素类。</para>
	/// </summary>
	public class TurnTableToTurnFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTurnTable">
		/// <para>Input Turn Table</para>
		/// <para>用来创建新转弯要素类的 .dbf 文件或 INFO 转弯表。</para>
		/// </param>
		/// <param name="ReferenceLineFeatures">
		/// <para>Reference Line Features</para>
		/// <para>输入转弯表引用的线要素类。要素类必须是网络数据集中的源。</para>
		/// </param>
		/// <param name="OutFeatureClassName">
		/// <para>Output Turn Feature Class Name</para>
		/// <para>要创建的新转弯要素类的名称。</para>
		/// </param>
		public TurnTableToTurnFeatureClass(object InTurnTable, object ReferenceLineFeatures, object OutFeatureClassName)
		{
			this.InTurnTable = InTurnTable;
			this.ReferenceLineFeatures = ReferenceLineFeatures;
			this.OutFeatureClassName = OutFeatureClassName;
		}

		/// <summary>
		/// <para>Tool Display Name : 转弯表至转弯要素类</para>
		/// </summary>
		public override string DisplayName() => "转弯表至转弯要素类";

		/// <summary>
		/// <para>Tool Name : TurnTableToTurnFeatureClass</para>
		/// </summary>
		public override string ToolName() => "TurnTableToTurnFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : na.TurnTableToTurnFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "na.TurnTableToTurnFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTurnTable, ReferenceLineFeatures, OutFeatureClassName, ReferenceNodesTable!, MaximumEdges!, ConfigKeyword!, SpatialGrid1!, SpatialGrid2!, SpatialGrid3!, OutTurnFeatures! };

		/// <summary>
		/// <para>Input Turn Table</para>
		/// <para>用来创建新转弯要素类的 .dbf 文件或 INFO 转弯表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTurnTable { get; set; }

		/// <summary>
		/// <para>Reference Line Features</para>
		/// <para>输入转弯表引用的线要素类。要素类必须是网络数据集中的源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Line", "Polyline")]
		public object ReferenceLineFeatures { get; set; }

		/// <summary>
		/// <para>Output Turn Feature Class Name</para>
		/// <para>要创建的新转弯要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFeatureClassName { get; set; }

		/// <summary>
		/// <para>Reference Nodes Table</para>
		/// <para>.nws 文件夹中包含输入转弯表所参与的原始 ArcView GIS 网络的 nodes.dbf 表。</para>
		/// <para>如果输入转弯表为 INFO 表，则将忽略该参数。</para>
		/// <para>如果输入转弯表为 .dbf 表，并且忽略了该参数，则不会在输出转弯要素类中创建 U 形转弯，也不会创建通过两端彼此相连的边的转弯。</para>
		/// <para>错误将记录在被写入到 TEMP 系统变量所定义的目录的错误文件中。错误文件的完整路径名将作为警告消息显示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEDbaseTable()]
		public object? ReferenceNodesTable { get; set; }

		/// <summary>
		/// <para>Maximum Edges</para>
		/// <para>新转弯要素类中每个转弯的最大边数。默认值为 5。最大值为 50。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumEdges { get; set; } = "5";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>指定用来确定输出转弯要素类的存储参数的配置关键字。仅当在工作组或企业级地理数据库中创建输出转弯要素类时，才会使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid1 { get; set; } = "1000";

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Output Turn Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEGeoDatasetType()]
		public object? OutTurnFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TurnTableToTurnFeatureClass SetEnviroment(object? configKeyword = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
