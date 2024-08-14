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
	/// <para>Add Terrain Pyramid Level</para>
	/// <para>Adds one or more pyramid levels to an existing terrain dataset.</para>
	/// </summary>
	public class AddTerrainPyramidLevel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="PyramidLevelDefinition">
		/// <para>Pyramid Levels Definition</para>
		/// <para>The z-tolerance or window size and its associated reference scale for each pyramid level being added to the terrain. Each pyramid level is entered as a space-delimited pair of the pyramid level resolution and reference scale (for example, &quot;20 24000&quot; for a window size of 20 and reference scale of 1:24000, or &quot;1.5 10000&quot; for a z-tolerance of 1.5 and reference scale of 1:10000). The pyramid level resolution can be provided as a floating-point value, while the reference scale must be entered as a whole number.</para>
		/// <para>The z-tolerance value represents the maximum deviation that can occur from the elevation of the terrain at full resolution, whereas the window size value defines the area of the terrain tile used in thinning elevation points by selecting one or two points from the area based on the window size method defined during the creation of the terrain. The reference scale represents the largest map scale at which the pyramid level is enforced. When the terrain is displayed at a scale larger than this value, the next highest pyramid level is displayed.</para>
		/// </param>
		public AddTerrainPyramidLevel(object InTerrain, object PyramidLevelDefinition)
		{
			this.InTerrain = InTerrain;
			this.PyramidLevelDefinition = PyramidLevelDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Terrain Pyramid Level</para>
		/// </summary>
		public override string DisplayName => "Add Terrain Pyramid Level";

		/// <summary>
		/// <para>Tool Name : AddTerrainPyramidLevel</para>
		/// </summary>
		public override string ToolName => "AddTerrainPyramidLevel";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddTerrainPyramidLevel</para>
		/// </summary>
		public override string ExcuteName => "3d.AddTerrainPyramidLevel";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTerrain, PyramidType!, PyramidLevelDefinition, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Pyramid Type</para>
		/// <para>The pyramid type used by the terrain dataset. This parameter is not used in ArcGIS 9.3 and beyond, as its purpose is to ensure backward-compatibility with scripts and models written using ArcGIS 9.2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PyramidType { get; set; }

		/// <summary>
		/// <para>Pyramid Levels Definition</para>
		/// <para>The z-tolerance or window size and its associated reference scale for each pyramid level being added to the terrain. Each pyramid level is entered as a space-delimited pair of the pyramid level resolution and reference scale (for example, &quot;20 24000&quot; for a window size of 20 and reference scale of 1:24000, or &quot;1.5 10000&quot; for a z-tolerance of 1.5 and reference scale of 1:10000). The pyramid level resolution can be provided as a floating-point value, while the reference scale must be entered as a whole number.</para>
		/// <para>The z-tolerance value represents the maximum deviation that can occur from the elevation of the terrain at full resolution, whereas the window size value defines the area of the terrain tile used in thinning elevation points by selecting one or two points from the area based on the window size method defined during the creation of the terrain. The reference scale represents the largest map scale at which the pyramid level is enforced. When the terrain is displayed at a scale larger than this value, the next highest pyramid level is displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object PyramidLevelDefinition { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddTerrainPyramidLevel SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
