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
	/// <para>Remove Terrain Pyramid Level</para>
	/// <para>Remove Terrain Pyramid Level</para>
	/// <para>Removes a pyramid level from a terrain dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveTerrainPyramidLevel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="PyramidLevelResolution">
		/// <para>Pyramid Level Resolution</para>
		/// <para>The pyramid level to be removed as specified by its resolution.</para>
		/// </param>
		public RemoveTerrainPyramidLevel(object InTerrain, object PyramidLevelResolution)
		{
			this.InTerrain = InTerrain;
			this.PyramidLevelResolution = PyramidLevelResolution;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Terrain Pyramid Level</para>
		/// </summary>
		public override string DisplayName() => "Remove Terrain Pyramid Level";

		/// <summary>
		/// <para>Tool Name : RemoveTerrainPyramidLevel</para>
		/// </summary>
		public override string ToolName() => "RemoveTerrainPyramidLevel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RemoveTerrainPyramidLevel</para>
		/// </summary>
		public override string ExcuteName() => "3d.RemoveTerrainPyramidLevel";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, PyramidLevelResolution, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The pyramid level to be removed as specified by its resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveTerrainPyramidLevel SetEnviroment(int? autoCommit = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
