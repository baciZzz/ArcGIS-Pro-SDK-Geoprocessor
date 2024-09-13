using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Add Feature Class To Topology</para>
	/// <para>Add Feature Class To Topology</para>
	/// <para>Adds a feature class to a topology.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddFeatureClassToTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The topology to which the feature class will participate.</para>
		/// </param>
		/// <param name="InFeatureclass">
		/// <para>Input Feature class</para>
		/// <para>The feature class to add to the topology. The feature class must be in the same feature dataset as the topology.</para>
		/// </param>
		/// <param name="XyRank">
		/// <para>XY Rank</para>
		/// <para>The relative degree of positional accuracy associated with vertices of features in the feature class versus those in other feature classes participating in the topology. The feature class with the highest accuracy should get a higher rank (lower number, for example, 1) than a feature class which is known to be less accurate.</para>
		/// </param>
		/// <param name="ZRank">
		/// <para>Z Rank</para>
		/// <para>Feature classes that are z-aware have elevation values embedded in their geometry for each vertex. By setting a z rank, you can influence how vertices with accurate z-values are snapped or clustered with vertices that contain less accurate z measurements.</para>
		/// </param>
		public AddFeatureClassToTopology(object InTopology, object InFeatureclass, object XyRank, object ZRank)
		{
			this.InTopology = InTopology;
			this.InFeatureclass = InFeatureclass;
			this.XyRank = XyRank;
			this.ZRank = ZRank;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Feature Class To Topology</para>
		/// </summary>
		public override string DisplayName() => "Add Feature Class To Topology";

		/// <summary>
		/// <para>Tool Name : AddFeatureClassToTopology</para>
		/// </summary>
		public override string ToolName() => "AddFeatureClassToTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.AddFeatureClassToTopology</para>
		/// </summary>
		public override string ExcuteName() => "management.AddFeatureClassToTopology";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTopology, InFeatureclass, XyRank, ZRank, OutTopology! };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>The topology to which the feature class will participate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Input Feature class</para>
		/// <para>The feature class to add to the topology. The feature class must be in the same feature dataset as the topology.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>XY Rank</para>
		/// <para>The relative degree of positional accuracy associated with vertices of features in the feature class versus those in other feature classes participating in the topology. The feature class with the highest accuracy should get a higher rank (lower number, for example, 1) than a feature class which is known to be less accurate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object XyRank { get; set; } = "1";

		/// <summary>
		/// <para>Z Rank</para>
		/// <para>Feature classes that are z-aware have elevation values embedded in their geometry for each vertex. By setting a z rank, you can influence how vertices with accurate z-values are snapped or clustered with vertices that contain less accurate z measurements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object ZRank { get; set; } = "1";

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object? OutTopology { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFeatureClassToTopology SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
