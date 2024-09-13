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
	/// <para>Terrain To Points</para>
	/// <para>Terrain To Points</para>
	/// <para>Converts a terrain dataset into a new point or multipoint feature class.</para>
	/// </summary>
	public class TerrainToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public TerrainToPoints(object InTerrain, object OutFeatureClass)
		{
			this.InTerrain = InTerrain;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Terrain To Points</para>
		/// </summary>
		public override string DisplayName() => "Terrain To Points";

		/// <summary>
		/// <para>Tool Name : TerrainToPoints</para>
		/// </summary>
		public override string ToolName() => "TerrainToPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TerrainToPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.TerrainToPoints";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, OutFeatureClass, PyramidLevelResolution!, SourceEmbeddedFeatureClass!, OutGeometryType! };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Input Embedded Feature Class</para>
		/// <para>The name of the terrain dataset's embedded points to be exported. If an embedded feature is specified, only the points from the feature will be written to the output. Otherwise, all points from all data sources in the terrain will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SourceEmbeddedFeatureClass { get; set; } = "<NONE>";

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>The geometry of the output feature class.</para>
		/// <para>Multipoint—The output point features will be written to a multipoint feature class. This is the default.</para>
		/// <para>Point—The output point features will be written to a point feature class.</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutGeometryType { get; set; } = "MULTIPOINT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TerrainToPoints SetEnviroment(object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>Multipoint—The output point features will be written to a multipoint feature class. This is the default.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Point—The output point features will be written to a point feature class.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

		}

#endregion
	}
}
