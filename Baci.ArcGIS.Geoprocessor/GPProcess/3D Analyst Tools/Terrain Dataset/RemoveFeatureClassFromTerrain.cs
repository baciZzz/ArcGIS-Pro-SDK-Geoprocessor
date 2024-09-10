using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Remove Feature Class From Terrain</para>
	/// <para>Removes reference to a feature class participating in a terrain dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveFeatureClassFromTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="FeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class to be removed.</para>
		/// </param>
		public RemoveFeatureClassFromTerrain(object InTerrain, object FeatureClass)
		{
			this.InTerrain = InTerrain;
			this.FeatureClass = FeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Feature Class From Terrain</para>
		/// </summary>
		public override string DisplayName() => "Remove Feature Class From Terrain";

		/// <summary>
		/// <para>Tool Name : RemoveFeatureClassFromTerrain</para>
		/// </summary>
		public override string ToolName() => "RemoveFeatureClassFromTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RemoveFeatureClassFromTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.RemoveFeatureClassFromTerrain";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, FeatureClass, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class to be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureClass { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveFeatureClassFromTerrain SetEnviroment(int? autoCommit = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
