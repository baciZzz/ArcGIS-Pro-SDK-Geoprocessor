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
	/// <para>Create Turn Feature Class</para>
	/// <para>创建转弯要素类</para>
	/// <para>创建新的转弯要素类，以将对转弯移动进行建模的转弯要素存储在网络数据集中。</para>
	/// </summary>
	public class CreateTurnFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>将在其中创建输出转弯要素类的文件地理数据库、工作组级地理数据库、企业级地理数据库或文件夹。此工作空间必须已经存在。</para>
		/// </param>
		/// <param name="OutFeatureClassName">
		/// <para>Output Turn Feature Class Name</para>
		/// <para>要创建的转弯要素类的名称。</para>
		/// </param>
		public CreateTurnFeatureClass(object OutLocation, object OutFeatureClassName)
		{
			this.OutLocation = OutLocation;
			this.OutFeatureClassName = OutFeatureClassName;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建转弯要素类</para>
		/// </summary>
		public override string DisplayName() => "创建转弯要素类";

		/// <summary>
		/// <para>Tool Name : CreateTurnFeatureClass</para>
		/// </summary>
		public override string ToolName() => "CreateTurnFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : na.CreateTurnFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "na.CreateTurnFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutLocation, OutFeatureClassName, MaximumEdges!, InNetworkDataset!, InTemplateFeatureClass!, SpatialReference!, ConfigKeyword!, SpatialGrid1!, SpatialGrid2!, SpatialGrid3!, HasZ!, OutTurnFeatures! };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>将在其中创建输出转弯要素类的文件地理数据库、工作组级地理数据库、企业级地理数据库或文件夹。此工作空间必须已经存在。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output Turn Feature Class Name</para>
		/// <para>要创建的转弯要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFeatureClassName { get; set; }

		/// <summary>
		/// <para>Maximum Edges</para>
		/// <para>对新转弯要素类中的转弯进行建模的最大边数。默认值为 5。最大值为 50。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumEdges { get; set; } = "5";

		/// <summary>
		/// <para>Input Network Dataset</para>
		/// <para>转弯要素类将参与的网络数据集。所生成的转弯要素类将作为转弯源添加到网络数据集中。如果未指定任何网络数据集，将创建不参与网络数据集的转弯要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDatasetLayer()]
		public object? InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Template Feature Class</para>
		/// <para>用作模板以定义新转弯要素类的属性方案的要素类。</para>
		/// <para>如果模板要素类具有以下字段，则不会对输出转弯要素类创建这些字段：NODE_、NODE#、JUNCTION、F_EDGE、T_EDGE、F-EDGE、T-EDGE、ARC1_、ARC2_、ARC1#、ARC2#、ARC1-ID、ARC2-ID、AZIMUTH、ANGLE。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InTemplateFeatureClass { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>要应用到输出转弯要素类的空间参考。 如果输出位置为地理数据库要素数据集，此参数将被忽略，因为输出转弯要素类将继承要素数据集的空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>指定用于确定新转弯要素类的存储参数的配置关键字。仅当输出位置为工作组级或企业级地理数据库时，才会使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geodatabase Settings")]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings")]
		public object? SpatialGrid1 { get; set; } = "1000";

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings")]
		public object? SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>已在 ArcGIS Pro 中弃用此参数。将忽略您输入的任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Geodatabase Settings")]
		public object? SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Has Z</para>
		/// <para>选中 - 新转弯要素类中的坐标将具有高程 (Z) 值。如果指定了输入网络数据集并且它支持基于网络源中 z 坐标值的连通性，则会自动选中和禁用此参数。</para>
		/// <para>未选中 - 新转弯要素类中的坐标将不具有高程 (Z) 值。</para>
		/// <para><see cref="HasZEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? HasZ { get; set; } = "false";

		/// <summary>
		/// <para>Output Turn Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutTurnFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTurnFeatureClass SetEnviroment(object? configKeyword = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Has Z</para>
		/// </summary>
		public enum HasZEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLED")]
			ENABLED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLED")]
			DISABLED,

		}

#endregion
	}
}
