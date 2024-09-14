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
	/// <para>Copy Traversed Source Features</para>
	/// <para>复制遍历的源要素</para>
	/// <para>创建两个要素类和一个表，它们组合在一起以包含求解网络分析图层时所遍历的边、交汇点和转弯的信息。</para>
	/// </summary>
	public class CopyTraversedSourceFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>将复制遍历源要素的网络分析图层。如果网络分析图层没有有效结果，则会通过求解图层以生成有效结果。</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>用来保存输出表和两个要素类的工作空间。</para>
		/// </param>
		/// <param name="EdgeFeatureClassName">
		/// <para>Edge Feature Class Name</para>
		/// <para>将包含遍历边源要素相关信息的要素类的名称。如果求解的网络分析图层不遍历任何边要素，则会创建空要素类。</para>
		/// </param>
		/// <param name="JunctionFeatureClassName">
		/// <para>Junction Feature Class Name</para>
		/// <para>将包含遍历交汇点源要素（包括输入网络分析图层中的系统交汇点和相关点）相关信息的要素类的名称。如果求解的网络分析图层不遍历任何交汇点，则会创建空要素类。</para>
		/// </param>
		/// <param name="TurnTableName">
		/// <para>Turn Table Name</para>
		/// <para>将包含基础边成本按比例增加的遍历通用转弯和转弯要素相关信息的表的名称。如果求解的网络分析图层不遍历任何转弯，则会创建空表。因为始终不会遍历受限制的转弯，因此它们始终不会包含在输出中。</para>
		/// </param>
		public CopyTraversedSourceFeatures(object InputNetworkAnalysisLayer, object OutputLocation, object EdgeFeatureClassName, object JunctionFeatureClassName, object TurnTableName)
		{
			this.InputNetworkAnalysisLayer = InputNetworkAnalysisLayer;
			this.OutputLocation = OutputLocation;
			this.EdgeFeatureClassName = EdgeFeatureClassName;
			this.JunctionFeatureClassName = JunctionFeatureClassName;
			this.TurnTableName = TurnTableName;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制遍历的源要素</para>
		/// </summary>
		public override string DisplayName() => "复制遍历的源要素";

		/// <summary>
		/// <para>Tool Name : CopyTraversedSourceFeatures</para>
		/// </summary>
		public override string ToolName() => "CopyTraversedSourceFeatures";

		/// <summary>
		/// <para>Tool Excute Name : na.CopyTraversedSourceFeatures</para>
		/// </summary>
		public override string ExcuteName() => "na.CopyTraversedSourceFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputNetworkAnalysisLayer, OutputLocation, EdgeFeatureClassName, JunctionFeatureClassName, TurnTableName, EdgeFeatures!, JunctionFeatures!, TurnTable!, ModifiedInputNetworkAnalysisLayer! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>将复制遍历源要素的网络分析图层。如果网络分析图层没有有效结果，则会通过求解图层以生成有效结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InputNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>用来保存输出表和两个要素类的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Edge Feature Class Name</para>
		/// <para>将包含遍历边源要素相关信息的要素类的名称。如果求解的网络分析图层不遍历任何边要素，则会创建空要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EdgeFeatureClassName { get; set; }

		/// <summary>
		/// <para>Junction Feature Class Name</para>
		/// <para>将包含遍历交汇点源要素（包括输入网络分析图层中的系统交汇点和相关点）相关信息的要素类的名称。如果求解的网络分析图层不遍历任何交汇点，则会创建空要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object JunctionFeatureClassName { get; set; }

		/// <summary>
		/// <para>Turn Table Name</para>
		/// <para>将包含基础边成本按比例增加的遍历通用转弯和转弯要素相关信息的表的名称。如果求解的网络分析图层不遍历任何转弯，则会创建空表。因为始终不会遍历受限制的转弯，因此它们始终不会包含在输出中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TurnTableName { get; set; }

		/// <summary>
		/// <para>Edge Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? EdgeFeatures { get; set; }

		/// <summary>
		/// <para>Junction Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? JunctionFeatures { get; set; }

		/// <summary>
		/// <para>Turn Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? TurnTable { get; set; }

		/// <summary>
		/// <para>Modified Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? ModifiedInputNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyTraversedSourceFeatures SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
