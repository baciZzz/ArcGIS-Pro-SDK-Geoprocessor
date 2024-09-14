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
	/// <para>Set Territory Distance Parameters</para>
	/// <para>Set Territory Distance Parameters</para>
	/// <para>Defines the type of distance calculation or distance constraints to use when creating territories.</para>
	/// </summary>
	public class SetTerritoryDistanceParameters : AbstractGPProcess
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
		/// <para>The level to which the distance parameters will be applied.</para>
		/// </param>
		public SetTerritoryDistanceParameters(object InTerritorySolution, object Level)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Territory Distance Parameters</para>
		/// </summary>
		public override string DisplayName() => "Set Territory Distance Parameters";

		/// <summary>
		/// <para>Tool Name : SetTerritoryDistanceParameters</para>
		/// </summary>
		public override string ToolName() => "SetTerritoryDistanceParameters";

		/// <summary>
		/// <para>Tool Excute Name : td.SetTerritoryDistanceParameters</para>
		/// </summary>
		public override string ExcuteName() => "td.SetTerritoryDistanceParameters";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, DistanceType!, Units!, MaxRadius!, BufferDistance!, MinDistance!, OutTerritorySolution!, NetworkDatasource!, BuildIndex!, TravelDirection!, TimeOfDay!, TimeZone!, SearchTolerance! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level to which the distance parameters will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>Specifies how distance will be calculated based on the method of travel.</para>
		/// <para>Straight line—Straight-line, or Euclidean distance, will be used as the distance measure. This is the default.</para>
		/// <para>Additional distance types (travel modes—for example, Driving Time, Driving Distance) will be dependent on the available network dataset.</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceType { get; set; }

		/// <summary>
		/// <para>Measure Units</para>
		/// <para>Specifies the type of measuring units that will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Units { get; set; }

		/// <summary>
		/// <para>Maximum Territory Radius</para>
		/// <para>The maximum radius of the territory.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? MaxRadius { get; set; }

		/// <summary>
		/// <para>Territory Buffer Distance</para>
		/// <para>The radius of the territory buffer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Additional Distance Settings")]
		public object? BufferDistance { get; set; }

		/// <summary>
		/// <para>Minimum Distance Between Centers</para>
		/// <para>The minimum distance between territory centers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Additional Distance Settings")]
		public object? MinDistance { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>The network dataset on which the network distance calculation will be performed. The parameter requires a locally installed dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[Category("Network Parameters")]
		public object? NetworkDatasource { get; set; }

		/// <summary>
		/// <para>Build Network Index</para>
		/// <para>Specifies whether a network index will be built. A network index will improve performance when solving the territory solution.</para>
		/// <para>Checked—A network index will be built. This is the default.</para>
		/// <para>Unchecked—A network index will not be built.</para>
		/// <para><see cref="BuildIndexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? BuildIndex { get; set; } = "true";

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel between stores and customers.</para>
		/// <para>Toward Stores—Direction of travel will be from customers to stores. This is the default.</para>
		/// <para>Away from Stores—Direction of travel will be from stores to customers.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TravelDirection { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time and date that will be used when calculating distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone of the Time of Day parameter.</para>
		/// <para>Time Zone at Location—The time zone in which the territories are located will be used. This is the default.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TimeZone { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The search tolerance to be used for locating territories on the network. Territories that are outside the search tolerance will be left unlocated.</para>
		/// <para>This parameter requires a distance value and units for the tolerance. The default value is 5000 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Network Parameters")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetTerritoryDistanceParameters SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Type</para>
		/// </summary>
		public enum DistanceTypeEnum 
		{
			/// <summary>
			/// <para>Straight line—Straight-line, or Euclidean distance, will be used as the distance measure. This is the default.</para>
			/// </summary>
			[GPValue("STRAIGHT_LINE")]
			[Description("Straight line")]
			Straight_line,

		}

		/// <summary>
		/// <para>Build Network Index</para>
		/// </summary>
		public enum BuildIndexEnum 
		{
			/// <summary>
			/// <para>Checked—A network index will be built. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_INDEX")]
			BUILD_INDEX,

			/// <summary>
			/// <para>Unchecked—A network index will not be built.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD_INDEX")]
			DO_NOT_BUILD_INDEX,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward Stores—Direction of travel will be from customers to stores. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Stores")]
			Toward_Stores,

			/// <summary>
			/// <para>Away from Stores—Direction of travel will be from stores to customers.</para>
			/// </summary>
			[GPValue("AWAY_FROM_STORES")]
			[Description("Away from Stores")]
			Away_from_Stores,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>Time Zone at Location—The time zone in which the territories are located will be used. This is the default.</para>
			/// </summary>
			[GPValue("TIME_ZONE_AT_LOCATION")]
			[Description("Time Zone at Location")]
			Time_Zone_at_Location,

			/// <summary>
			/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

#endregion
	}
}
