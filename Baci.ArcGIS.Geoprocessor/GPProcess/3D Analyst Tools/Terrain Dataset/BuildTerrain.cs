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
	/// <para>Build Terrain</para>
	/// <para>Build Terrain</para>
	/// <para>Performs tasks required for analyzing and displaying a terrain dataset.</para>
	/// </summary>
	public class BuildTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		public BuildTerrain(object InTerrain)
		{
			this.InTerrain = InTerrain;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Terrain</para>
		/// </summary>
		public override string DisplayName() => "Build Terrain";

		/// <summary>
		/// <para>Tool Name : BuildTerrain</para>
		/// </summary>
		public override string ToolName() => "BuildTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.BuildTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.BuildTerrain";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, UpdateExtent, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Update Extent</para>
		/// <para>Recalculates the data extent of a window-size-based terrain dataset when the data area has been reduced through editing. It is not needed if the data extent has increased or if the terrain dataset is z-tolerance based. It will scan through all the terrain data to determine the new extent.</para>
		/// <para>Maintain Extent— The extent of the terrain dataset will not be recalculated. This is the default.</para>
		/// <para>Update Extent— The extent of the terrain dataset will be recalculated.</para>
		/// <para><see cref="UpdateExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateExtent { get; set; } = "NO_UPDATE_EXTENT";

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildTerrain SetEnviroment(int? autoCommit = null, object extent = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Extent</para>
		/// </summary>
		public enum UpdateExtentEnum 
		{
			/// <summary>
			/// <para>Maintain Extent— The extent of the terrain dataset will not be recalculated. This is the default.</para>
			/// </summary>
			[GPValue("NO_UPDATE_EXTENT")]
			[Description("Maintain Extent")]
			Maintain_Extent,

			/// <summary>
			/// <para>Update Extent</para>
			/// </summary>
			[GPValue("UPDATE_EXTENT")]
			[Description("Update Extent")]
			Update_Extent,

		}

#endregion
	}
}
