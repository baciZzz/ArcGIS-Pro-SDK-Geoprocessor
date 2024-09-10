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
	/// <para>Remove Terrain Points</para>
	/// <para>This tool removes points within an area of interest from one or more embedded feature classes.</para>
	/// </summary>
	[Obsolete()]
	public class RemoveTerrainPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to be modified</para>
		/// </param>
		/// <param name="DataSource">
		/// <para>Embedded Feature Class</para>
		/// <para>One or more embedded feature classes from which points will be removed</para>
		/// </param>
		/// <param name="AoiExtents">
		/// <para>Area of Interest</para>
		/// <para>The XY extent defining the area from which points will be removed</para>
		/// </param>
		public RemoveTerrainPoints(object InTerrain, object DataSource, object AoiExtents)
		{
			this.InTerrain = InTerrain;
			this.DataSource = DataSource;
			this.AoiExtents = AoiExtents;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Terrain Points</para>
		/// </summary>
		public override string DisplayName() => "Remove Terrain Points";

		/// <summary>
		/// <para>Tool Name : RemoveTerrainPoints</para>
		/// </summary>
		public override string ToolName() => "RemoveTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RemoveTerrainPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.RemoveTerrainPoints";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, DataSource, AoiExtents, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to be modified</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Embedded Feature Class</para>
		/// <para>One or more embedded feature classes from which points will be removed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object DataSource { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The XY extent defining the area from which points will be removed</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPExtent()]
		public object AoiExtents { get; set; }

		/// <summary>
		/// <para>Output Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveTerrainPoints SetEnviroment(object scratchWorkspace = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

	}
}
