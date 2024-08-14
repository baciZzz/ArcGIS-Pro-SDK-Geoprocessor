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
	/// <para>Replace Terrain Points</para>
	/// <para>Replaces points referenced by a terrain dataset with points from a specified feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ReplaceTerrainPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="TerrainFeatureClass">
		/// <para>Input Terrain Data Source</para>
		/// <para>The name of the terrain point feature class that will have some or all of its points replaced.</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Input Points</para>
		/// <para>The point or multipoint features that will replace the terrain point features.</para>
		/// </param>
		public ReplaceTerrainPoints(object InTerrain, object TerrainFeatureClass, object InPointFeatures)
		{
			this.InTerrain = InTerrain;
			this.TerrainFeatureClass = TerrainFeatureClass;
			this.InPointFeatures = InPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Replace Terrain Points</para>
		/// </summary>
		public override string DisplayName => "Replace Terrain Points";

		/// <summary>
		/// <para>Tool Name : ReplaceTerrainPoints</para>
		/// </summary>
		public override string ToolName => "ReplaceTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ReplaceTerrainPoints</para>
		/// </summary>
		public override string ExcuteName => "3d.ReplaceTerrainPoints";

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
		public override object[] Parameters => new object[] { InTerrain, TerrainFeatureClass, InPointFeatures, PolygonFeaturesOrExtent!, DerivedOutTerrain! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Terrain Data Source</para>
		/// <para>The name of the terrain point feature class that will have some or all of its points replaced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TerrainFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The point or multipoint features that will replace the terrain point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>An optional area of interest can be used to define the extent of the area in which the terrain points would be replaced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? PolygonFeaturesOrExtent { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReplaceTerrainPoints SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
