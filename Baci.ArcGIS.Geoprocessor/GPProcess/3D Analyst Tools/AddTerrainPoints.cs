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
	/// <para>Add Terrain Points</para>
	/// <para>Adds terrain multipoints to an embedded terrain feature class.</para>
	/// </summary>
	[Obsolete()]
	public class AddTerrainPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// </param>
		/// <param name="TerrainFeatureClass">
		/// <para>Input Terrain Feature Class</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// </param>
		public AddTerrainPoints(object InTerrain, object TerrainFeatureClass, object InFeatureClass)
		{
			this.InTerrain = InTerrain;
			this.TerrainFeatureClass = TerrainFeatureClass;
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Terrain Points</para>
		/// </summary>
		public override string DisplayName() => "Add Terrain Points";

		/// <summary>
		/// <para>Tool Name : AddTerrainPoints</para>
		/// </summary>
		public override string ToolName() => "AddTerrainPoints";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddTerrainPoints</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddTerrainPoints";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, TerrainFeatureClass, InFeatureClass, Method, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Terrain Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TerrainFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "APPEND";

		/// <summary>
		/// <para>Output Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("APPEND")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("REPLACE")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
