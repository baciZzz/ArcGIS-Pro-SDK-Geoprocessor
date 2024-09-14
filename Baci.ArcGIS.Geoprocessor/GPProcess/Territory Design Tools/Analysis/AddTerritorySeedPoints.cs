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
	/// <para>Add Territory Seed Points</para>
	/// <para>Add Territory Seed Points</para>
	/// <para>Creates a point feature that is used to determine the starting point for creating territories.</para>
	/// </summary>
	public class AddTerritorySeedPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution dataset.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The target territory level for which the seed points feature will be created.</para>
		/// </param>
		/// <param name="InSeedPoints">
		/// <para>Input Seed Point Features</para>
		/// <para>The points feature layer that represents seed points for territories.</para>
		/// </param>
		public AddTerritorySeedPoints(object InTerritorySolution, object Level, object InSeedPoints)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
			this.InSeedPoints = InSeedPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Territory Seed Points</para>
		/// </summary>
		public override string DisplayName() => "Add Territory Seed Points";

		/// <summary>
		/// <para>Tool Name : AddTerritorySeedPoints</para>
		/// </summary>
		public override string ToolName() => "AddTerritorySeedPoints";

		/// <summary>
		/// <para>Tool Excute Name : td.AddTerritorySeedPoints</para>
		/// </summary>
		public override string ExcuteName() => "td.AddTerritorySeedPoints";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, InSeedPoints, FieldMap!, AppendData!, OutTerritorySolution! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The target territory level for which the seed points feature will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Input Seed Point Features</para>
		/// <para>The points feature layer that represents seed points for territories.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InSeedPoints { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>Specifies the attributes and fields that will be used for the seed point properties.</para>
		/// <para>Name—The name for a seed point feature</para>
		/// <para>ID—The ID for a seed point feature</para>
		/// <para>Type—The seed point type</para>
		/// <para>The field value associated with the Type attribute can only be Required or Candidate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? FieldMap { get; set; }

		/// <summary>
		/// <para>Append to Existing Seed Points</para>
		/// <para>Specifies whether the data will be appended or replaced.</para>
		/// <para>Checked—The data will be appended.</para>
		/// <para>Unchecked—The data will be replaced. This is the default.</para>
		/// <para><see cref="AppendDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendData { get; set; } = "false";

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddTerritorySeedPoints SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append to Existing Seed Points</para>
		/// </summary>
		public enum AppendDataEnum 
		{
			/// <summary>
			/// <para>Checked—The data will be appended.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—The data will be replaced. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
