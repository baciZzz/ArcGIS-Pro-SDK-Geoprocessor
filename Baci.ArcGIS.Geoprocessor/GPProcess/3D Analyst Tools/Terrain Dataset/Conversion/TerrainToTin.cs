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
	/// <para>Terrain To TIN</para>
	/// <para>Converts a terrain dataset to a triangulated irregular network (TIN) dataset.</para>
	/// </summary>
	public class TerrainToTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </param>
		public TerrainToTin(object InTerrain, object OutTin)
		{
			this.InTerrain = InTerrain;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : Terrain To TIN</para>
		/// </summary>
		public override string DisplayName => "Terrain To TIN";

		/// <summary>
		/// <para>Tool Name : TerrainToTin</para>
		/// </summary>
		public override string ToolName => "TerrainToTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TerrainToTin</para>
		/// </summary>
		public override string ExcuteName => "3d.TerrainToTin";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "terrainMemoryUsage", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTerrain, OutTin, PyramidLevelResolution, MaxNodes, ClipToExtent };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Number of Nodes</para>
		/// <para>The maximum number of nodes permitted in the output TIN. The tool will return an error if the analysis extent and pyramid level would produce a TIN that exceeds this size. The default is 5 million.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxNodes { get; set; } = "5000000";

		/// <summary>
		/// <para>Clip to Extent</para>
		/// <para>Specifies whether the resulting TIN will be clipped against the analysis extent. This only has an effect if the analysis extent is defined and it&apos;s smaller than the extent of the input terrain.</para>
		/// <para>Checked—Clips the output TIN against the analysis extent. This is the default.</para>
		/// <para>Unchecked—Does not clip the output TIN against the analysis extent.</para>
		/// <para><see cref="ClipToExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipToExtent { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TerrainToTin SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object terrainMemoryUsage = null , object tinSaveVersion = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, terrainMemoryUsage: terrainMemoryUsage, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip to Extent</para>
		/// </summary>
		public enum ClipToExtentEnum 
		{
			/// <summary>
			/// <para>Checked—Clips the output TIN against the analysis extent. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para>Unchecked—Does not clip the output TIN against the analysis extent.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIP")]
			NO_CLIP,

		}

#endregion
	}
}
