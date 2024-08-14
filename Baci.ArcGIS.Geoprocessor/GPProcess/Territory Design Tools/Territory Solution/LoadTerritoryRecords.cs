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
	/// <para>Load Territory Records</para>
	/// <para>Adds records (features) or updates existing records for the specified level.</para>
	/// </summary>
	public class LoadTerritoryRecords : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The name of the input territory solution.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The name of the level to which the data will be loaded.</para>
		/// </param>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>The layer or records to be loaded.</para>
		/// </param>
		public LoadTerritoryRecords(object InTerritorySolution, object Level, object InData)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
			this.InData = InData;
		}

		/// <summary>
		/// <para>Tool Display Name : Load Territory Records</para>
		/// </summary>
		public override string DisplayName => "Load Territory Records";

		/// <summary>
		/// <para>Tool Name : LoadTerritoryRecords</para>
		/// </summary>
		public override string ToolName => "LoadTerritoryRecords";

		/// <summary>
		/// <para>Tool Excute Name : td.LoadTerritoryRecords</para>
		/// </summary>
		public override string ExcuteName => "td.LoadTerritoryRecords";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTerritorySolution, Level, InData, IdField!, NameField!, FieldMap!, AppendData!, OutTerritorySolution! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The name of the input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The name of the level to which the data will be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Input Data</para>
		/// <para>The layer or records to be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InData { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>The field containing the ID values to be loaded into the level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? IdField { get; set; }

		/// <summary>
		/// <para>Name Field</para>
		/// <para>The field containing the name values to be loaded into the level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? NameField { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>The values that will be used for the territory properties.</para>
		/// <para>Parent Territory ID—The ID of the parent territory.</para>
		/// <para>Locked State—The territory can&apos;t be modified.</para>
		/// <para>Center Locked—Center points can&apos;t be modified and will remain in their fixed locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? FieldMap { get; set; }

		/// <summary>
		/// <para>Append Data</para>
		/// <para>Specifies whether the records being loaded will be appended or replaced.</para>
		/// <para>Checked—The records being loaded to the specified level will be appended.</para>
		/// <para>Unchecked—The records being loaded to the specified level will be replaced. This is the default.</para>
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
		public LoadTerritoryRecords SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append Data</para>
		/// </summary>
		public enum AppendDataEnum 
		{
			/// <summary>
			/// <para>Checked—The records being loaded to the specified level will be appended.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—The records being loaded to the specified level will be replaced. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
