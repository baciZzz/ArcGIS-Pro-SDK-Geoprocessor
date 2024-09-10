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
	/// <para>Converts an ArcView turn table or ArcInfo Workstation coverage turn table to an ArcGIS turn feature class.</para>
	/// </summary>
	public class TurnTableToTurnFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTurnTable">
		/// <para>Input Turn Table</para>
		/// <para>The .dbf file or INFO turn table from which the new turn feature class will be created.</para>
		/// </param>
		/// <param name="ReferenceLineFeatures">
		/// <para>Reference Line Features</para>
		/// <para>The line feature class to which the input turn table refers. The feature class must be a source in a network dataset.</para>
		/// </param>
		/// <param name="OutFeatureClassName">
		/// <para>Output Turn Feature Class Name</para>
		/// <para>The name of the new turn feature class to create.</para>
		/// </param>
		public TurnTableToTurnFeatureClass(object InTurnTable, object ReferenceLineFeatures, object OutFeatureClassName)
		{
			this.InTurnTable = InTurnTable;
			this.ReferenceLineFeatures = ReferenceLineFeatures;
			this.OutFeatureClassName = OutFeatureClassName;
		}

		/// <summary>
		/// <para>Tool Display Name : Turn Table To Turn Feature Class</para>
		/// </summary>
		public override string DisplayName() => "Turn Table To Turn Feature Class";

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
		public override object[] Parameters() => new object[] { InTurnTable, ReferenceLineFeatures, OutFeatureClassName, ReferenceNodesTable, MaximumEdges, ConfigKeyword, SpatialGrid1, SpatialGrid2, SpatialGrid3, OutTurnFeatures };

		/// <summary>
		/// <para>Input Turn Table</para>
		/// <para>The .dbf file or INFO turn table from which the new turn feature class will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTurnTable { get; set; }

		/// <summary>
		/// <para>Reference Line Features</para>
		/// <para>The line feature class to which the input turn table refers. The feature class must be a source in a network dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Line", "Polyline")]
		public object ReferenceLineFeatures { get; set; }

		/// <summary>
		/// <para>Output Turn Feature Class Name</para>
		/// <para>The name of the new turn feature class to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFeatureClassName { get; set; }

		/// <summary>
		/// <para>Reference Nodes Table</para>
		/// <para>The nodes.dbf table in the .nws folder containing the original ArcView GIS network in which the input turn table participated.</para>
		/// <para>This parameter is ignored if the input turn table is an INFO table.</para>
		/// <para>If the input turn table is a .dbf table and this parameter is omitted, then U-turns and turns that traverse between edges connected to each other at both ends will not be created in the output turn feature class.</para>
		/// <para>Errors will be reported in an error file written to the directory defined by the TEMP system variable. The full path name to the error file is reported as a warning message.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEDbaseTable()]
		public object ReferenceNodesTable { get; set; }

		/// <summary>
		/// <para>Maximum Edges</para>
		/// <para>The maximum number of edges per turn in the new turn feature class. The default value is 5. The maximum value is 50.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaximumEdges { get; set; } = "5";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>Specifies the configuration keyword that determines the storage parameters of the output turn feature class. This parameter is used only if the output turn feature class is created in a workgroup or enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Spatial Grid 1</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpatialGrid1 { get; set; } = "1000";

		/// <summary>
		/// <para>Output Spatial Grid 2</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Grid 3</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Output Turn Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEGeoDatasetType()]
		public object OutTurnFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TurnTableToTurnFeatureClass SetEnviroment(object configKeyword = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, workspace: workspace);
			return this;
		}

	}
}
