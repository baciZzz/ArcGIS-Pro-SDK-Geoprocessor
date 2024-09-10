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
	/// <para>Append Terrain Points</para>
	/// <para>Appends points to a point  feature referenced by a terrain dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AppendTerrainPoints : AbstractGPProcess
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
		/// <para>The feature class that contributes to the terrain dataset into which the points or multipoints will be added.</para>
		/// </param>
		/// <param name="InPointFeatures">
		/// <para>Input Points</para>
		/// <para>The feature class of points or multipoints to add as an additional data source for the terrain dataset.</para>
		/// </param>
		public AppendTerrainPoints(object InTerrain, object TerrainFeatureClass, object InPointFeatures)
		{
			this.InTerrain = InTerrain;
			this.TerrainFeatureClass = TerrainFeatureClass;
			this.InPointFeatures = InPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Terrain Points</para>
		/// </summary>
		public override string DisplayName() => "Append Terrain Points";

		/// <summary>
		/// <para>Tool Name : AppendTerrainPoints</para>
		/// </summary>
		public override string ToolName() => "AppendTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AppendTerrainPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.AppendTerrainPoints";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, TerrainFeatureClass, InPointFeatures, PolygonFeaturesOrExtent, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Terrain Data Source</para>
		/// <para>The feature class that contributes to the terrain dataset into which the points or multipoints will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TerrainFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The feature class of points or multipoints to add as an additional data source for the terrain dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>Specify a polygon feature class or extent values to define the area where point features will be added. This parameter is empty by default, which results in all the points from the input feature class being loaded to the terrain feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object PolygonFeaturesOrExtent { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendTerrainPoints SetEnviroment(int? autoCommit = null , object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
