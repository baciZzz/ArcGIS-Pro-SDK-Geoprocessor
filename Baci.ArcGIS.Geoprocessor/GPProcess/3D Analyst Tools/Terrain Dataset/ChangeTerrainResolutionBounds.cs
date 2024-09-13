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
	/// <para>Change Terrain Resolution Bounds</para>
	/// <para>Change Terrain Resolution Bounds</para>
	/// <para>Changes the pyramid levels at which a feature class will be enforced for a given terrain dataset.</para>
	/// </summary>
	public class ChangeTerrainResolutionBounds : AbstractGPProcess
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
		/// <para>The feature class referenced by the terrain that will have its pyramid-level resolutions modified.</para>
		/// </param>
		public ChangeTerrainResolutionBounds(object InTerrain, object FeatureClass)
		{
			this.InTerrain = InTerrain;
			this.FeatureClass = FeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Change Terrain Resolution Bounds</para>
		/// </summary>
		public override string DisplayName() => "Change Terrain Resolution Bounds";

		/// <summary>
		/// <para>Tool Name : ChangeTerrainResolutionBounds</para>
		/// </summary>
		public override string ToolName() => "ChangeTerrainResolutionBounds";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ChangeTerrainResolutionBounds</para>
		/// </summary>
		public override string ExcuteName() => "3d.ChangeTerrainResolutionBounds";

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
		public override object[] Parameters() => new object[] { InTerrain, FeatureClass, LowerPyramidResolution!, UpperPyramidResolution!, Overview!, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class referenced by the terrain that will have its pyramid-level resolutions modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FeatureClass { get; set; }

		/// <summary>
		/// <para>Lower Pyramid Resolution</para>
		/// <para>The new lower pyramid-level resolution for the chosen feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? LowerPyramidResolution { get; set; }

		/// <summary>
		/// <para>Upper Pyramid Resolution</para>
		/// <para>The new upper pyramid-level resolution for the chosen feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? UpperPyramidResolution { get; set; }

		/// <summary>
		/// <para>Contributes to Overview</para>
		/// <para>Specifies whether the feature class will contribute to the overview of the terrain dataset.</para>
		/// <para>Checked—Enforces the feature class at the overview display of the terrain dataset. This is the default.</para>
		/// <para>Unchecked—Omits the feature class from the overview display of the terrain dataset.</para>
		/// <para><see cref="OverviewEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overview { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ChangeTerrainResolutionBounds SetEnviroment(int? autoCommit = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contributes to Overview</para>
		/// </summary>
		public enum OverviewEnum 
		{
			/// <summary>
			/// <para>Checked—Enforces the feature class at the overview display of the terrain dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERVIEW")]
			OVERVIEW,

			/// <summary>
			/// <para>Unchecked—Omits the feature class from the overview display of the terrain dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERVIEW")]
			NO_OVERVIEW,

		}

#endregion
	}
}
