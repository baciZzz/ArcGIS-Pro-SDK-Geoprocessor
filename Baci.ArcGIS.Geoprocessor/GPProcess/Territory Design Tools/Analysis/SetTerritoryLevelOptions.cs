using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TerritoryDesignTools
{
	/// <summary>
	/// <para>Set Territory Level Options</para>
	/// <para>Set Territory Level Options</para>
	/// <para>Sets options for how territory levels are created.</para>
	/// </summary>
	public class SetTerritoryLevelOptions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The level to which the options will be applied.</para>
		/// </param>
		public SetTerritoryLevelOptions(object InTerritorySolution, object Level)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Territory Level Options</para>
		/// </summary>
		public override string DisplayName() => "Set Territory Level Options";

		/// <summary>
		/// <para>Tool Name : SetTerritoryLevelOptions</para>
		/// </summary>
		public override string ToolName() => "SetTerritoryLevelOptions";

		/// <summary>
		/// <para>Tool Excute Name : td.SetTerritoryLevelOptions</para>
		/// </summary>
		public override string ExcuteName() => "td.SetTerritoryLevelOptions";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise() => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, Compactness!, FillExtent!, OutTerritorySolution!, RandomSeed!, SpatialRelationship!, BufferTolerance! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level to which the options will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Compactness</para>
		/// <para>A numeric value between 0 and 100 that defines the shape of territories.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 100)]
		public object? Compactness { get; set; }

		/// <summary>
		/// <para>Fill Extent Automatically</para>
		/// <para>Specifies whether features are automatically assigned to the nearest territory.</para>
		/// <para>Checked—Features are automatically assigned to the nearest territory.</para>
		/// <para>Unchecked—Features are not automatically assigned to the nearest territory. This is the default.</para>
		/// <para><see cref="FillExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FillExtent { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Random Number Generator Seed</para>
		/// <para>An integer used for the seed value. The default is no value and uses a random generator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object? RandomSeed { get; set; }

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>Specifies the spatial relationship of how features are related to determine adjacency.</para>
		/// <para>Contiguity Edges Only—Polygon features that share a boundary or share a node with neighboring features.</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Feature Adjacency Parameters")]
		public object? SpatialRelationship { get; set; }

		/// <summary>
		/// <para>Buffer Tolerance</para>
		/// <para>The distance between features to determine adjacency. Features that are within the buffer tolerance are considered adjacent features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Feature Adjacency Parameters")]
		public object? BufferTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetTerritoryLevelOptions SetEnviroment(object? baDataSource = null, object? workspace = null)
		{
			base.SetEnv(baDataSource: baDataSource, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Fill Extent Automatically</para>
		/// </summary>
		public enum FillExtentEnum 
		{
			/// <summary>
			/// <para>Checked—Features are automatically assigned to the nearest territory.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_FILL_EXTENT")]
			AUTO_FILL_EXTENT,

			/// <summary>
			/// <para>Unchecked—Features are not automatically assigned to the nearest territory. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_AUTO_FILL_EXTENT")]
			DO_NOT_AUTO_FILL_EXTENT,

		}

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>Contiguity Edges Only—Polygon features that share a boundary or share a node with neighboring features.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity Edges Only")]
			Contiguity_Edges_Only,

		}

#endregion
	}
}
