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
	/// <para>Add Territory Barriers</para>
	/// <para>Add Territory Barriers</para>
	/// <para>Allows the addition of polygon or line features to prevent or restrict the growth of territories.</para>
	/// </summary>
	public class AddTerritoryBarriers : AbstractGPProcess
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
		/// <para>The level to which the barriers will be applied.</para>
		/// </param>
		/// <param name="InBarrierFeatures">
		/// <para>Input Barrier Features</para>
		/// <para>Line or polygon features used as a barrier.</para>
		/// </param>
		public AddTerritoryBarriers(object InTerritorySolution, object Level, object InBarrierFeatures)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
			this.InBarrierFeatures = InBarrierFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Territory Barriers</para>
		/// </summary>
		public override string DisplayName() => "Add Territory Barriers";

		/// <summary>
		/// <para>Tool Name : AddTerritoryBarriers</para>
		/// </summary>
		public override string ToolName() => "AddTerritoryBarriers";

		/// <summary>
		/// <para>Tool Excute Name : td.AddTerritoryBarriers</para>
		/// </summary>
		public override string ExcuteName() => "td.AddTerritoryBarriers";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, InBarrierFeatures, BarrierType!, AppendData!, OutTerritorySolution! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level to which the barriers will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Input Barrier Features</para>
		/// <para>Line or polygon features used as a barrier.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Barrier Type</para>
		/// <para>Specifies the type of barrier.</para>
		/// <para>Impedance— Limits the growth of territories. This is the default.</para>
		/// <para>Restricted Area—Prevents the creation of territories.</para>
		/// <para><see cref="BarrierTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BarrierType { get; set; }

		/// <summary>
		/// <para>Append to existing barriers</para>
		/// <para>Specifies whether to append or replace the records to the barrier layer.</para>
		/// <para>Checked—Appends records to an existing barrier layer.</para>
		/// <para>Unchecked—Creates a new barrier layer or replaces records in an existing barrier layer. This is the default.</para>
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
		public AddTerritoryBarriers SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Barrier Type</para>
		/// </summary>
		public enum BarrierTypeEnum 
		{
			/// <summary>
			/// <para>Impedance— Limits the growth of territories. This is the default.</para>
			/// </summary>
			[GPValue("IMPEDANCE")]
			[Description("Impedance")]
			Impedance,

			/// <summary>
			/// <para>Restricted Area—Prevents the creation of territories.</para>
			/// </summary>
			[GPValue("RESTRICTED_AREA")]
			[Description("Restricted Area")]
			Restricted_Area,

		}

		/// <summary>
		/// <para>Append to existing barriers</para>
		/// </summary>
		public enum AppendDataEnum 
		{
			/// <summary>
			/// <para>Checked—Appends records to an existing barrier layer.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para>Unchecked—Creates a new barrier layer or replaces records in an existing barrier layer. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
