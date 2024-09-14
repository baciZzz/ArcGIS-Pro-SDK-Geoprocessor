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
	/// <para>Copy Traversed Source Features</para>
	/// <para>Creates two feature classes and a table, which together contain information about the edges, junctions, and turns that are traversed while solving a network analysis layer.</para>
	/// </summary>
	public class CopyTraversedSourceFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer from which traversed source features will be copied. If the network analysis layer does not have a valid result, the layer will be solved to produce one.</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The workspace where the output table and two feature classes will be saved.</para>
		/// </param>
		/// <param name="EdgeFeatureClassName">
		/// <para>Edge Feature Class Name</para>
		/// <para>The name of the feature class that will contain information about the traversed edge source features. If the solved network analysis layer doesn't traverse any edge features, an empty feature class is created.</para>
		/// </param>
		/// <param name="JunctionFeatureClassName">
		/// <para>Junction Feature Class Name</para>
		/// <para>The name of the feature class that will contain information about the traversed junction source features, including system junctions and relevant points from the input network analysis layer. If the solved network analysis layer doesn't traverse any junctions, an empty feature class is created.</para>
		/// </param>
		/// <param name="TurnTableName">
		/// <para>Turn Table Name</para>
		/// <para>The name of the table that will contain information about the traversed global turns and turn features that scale cost for the underlying edges. If the solved network analysis layer doesn't traverse any turns, an empty table is created. Since restricted turns are never traversed, they are never included in the output.</para>
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
		/// <para>Tool Display Name : Copy Traversed Source Features</para>
		/// </summary>
		public override string DisplayName() => "Copy Traversed Source Features";

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
		public override object[] Parameters() => new object[] { InputNetworkAnalysisLayer, OutputLocation, EdgeFeatureClassName, JunctionFeatureClassName, TurnTableName, EdgeFeatures, JunctionFeatures, TurnTable, ModifiedInputNetworkAnalysisLayer };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>The network analysis layer from which traversed source features will be copied. If the network analysis layer does not have a valid result, the layer will be solved to produce one.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InputNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The workspace where the output table and two feature classes will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Edge Feature Class Name</para>
		/// <para>The name of the feature class that will contain information about the traversed edge source features. If the solved network analysis layer doesn't traverse any edge features, an empty feature class is created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EdgeFeatureClassName { get; set; }

		/// <summary>
		/// <para>Junction Feature Class Name</para>
		/// <para>The name of the feature class that will contain information about the traversed junction source features, including system junctions and relevant points from the input network analysis layer. If the solved network analysis layer doesn't traverse any junctions, an empty feature class is created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object JunctionFeatureClassName { get; set; }

		/// <summary>
		/// <para>Turn Table Name</para>
		/// <para>The name of the table that will contain information about the traversed global turns and turn features that scale cost for the underlying edges. If the solved network analysis layer doesn't traverse any turns, an empty table is created. Since restricted turns are never traversed, they are never included in the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TurnTableName { get; set; }

		/// <summary>
		/// <para>Edge Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object EdgeFeatures { get; set; }

		/// <summary>
		/// <para>Junction Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object JunctionFeatures { get; set; }

		/// <summary>
		/// <para>Turn Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object TurnTable { get; set; }

		/// <summary>
		/// <para>Modified Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object ModifiedInputNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyTraversedSourceFeatures SetEnviroment(object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
