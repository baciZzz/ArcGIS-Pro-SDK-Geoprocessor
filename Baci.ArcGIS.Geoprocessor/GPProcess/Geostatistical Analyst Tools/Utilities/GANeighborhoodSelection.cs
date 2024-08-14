using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Neighborhood Selection</para>
	/// <para>Creates a layer of points based on a user-defined neighborhood.</para>
	/// </summary>
	public class GANeighborhoodSelection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input point features</para>
		/// <para>Points used to create a neighborhood selection.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output layer</para>
		/// <para>Layer to store the neighborhood selection.</para>
		/// </param>
		/// <param name="PointCoord">
		/// <para>Input point</para>
		/// <para>The neighborhood center's x,y coordinate.</para>
		/// </param>
		/// <param name="NeighborsMax">
		/// <para>Maximum neighbors to include</para>
		/// <para>The number of points to use in each sector. If a sector has the required number of points, all points in that sector are used.</para>
		/// </param>
		/// <param name="NeighborsMin">
		/// <para>Include at least</para>
		/// <para>The minimum number of points to use in each sector. If the minimum number of required points are not available in any given sector, the nearest available point outside the sector will be selected.</para>
		/// </param>
		/// <param name="MinorSemiaxis">
		/// <para>Minor semiaxis</para>
		/// <para>Size of the minor semiaxis of the search neighborhood.</para>
		/// </param>
		/// <param name="MajorSemiaxis">
		/// <para>Major semiaxis</para>
		/// <para>Size of the major semiaxis of the search neighborhood.</para>
		/// </param>
		/// <param name="Angle">
		/// <para>Angle</para>
		/// <para>The angle of rotation of the neighborhood axis.</para>
		/// </param>
		public GANeighborhoodSelection(object InDataset, object OutLayer, object PointCoord, object NeighborsMax, object NeighborsMin, object MinorSemiaxis, object MajorSemiaxis, object Angle)
		{
			this.InDataset = InDataset;
			this.OutLayer = OutLayer;
			this.PointCoord = PointCoord;
			this.NeighborsMax = NeighborsMax;
			this.NeighborsMin = NeighborsMin;
			this.MinorSemiaxis = MinorSemiaxis;
			this.MajorSemiaxis = MajorSemiaxis;
			this.Angle = Angle;
		}

		/// <summary>
		/// <para>Tool Display Name : Neighborhood Selection</para>
		/// </summary>
		public override string DisplayName => "Neighborhood Selection";

		/// <summary>
		/// <para>Tool Name : GANeighborhoodSelection</para>
		/// </summary>
		public override string ToolName => "GANeighborhoodSelection";

		/// <summary>
		/// <para>Tool Excute Name : ga.GANeighborhoodSelection</para>
		/// </summary>
		public override string ExcuteName => "ga.GANeighborhoodSelection";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutLayer, PointCoord, NeighborsMax, NeighborsMin, MinorSemiaxis, MajorSemiaxis, Angle, ShapeType };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>Points used to create a neighborhood selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output layer</para>
		/// <para>Layer to store the neighborhood selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Input point</para>
		/// <para>The neighborhood center's x,y coordinate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object PointCoord { get; set; }

		/// <summary>
		/// <para>Maximum neighbors to include</para>
		/// <para>The number of points to use in each sector. If a sector has the required number of points, all points in that sector are used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain()]
		public object NeighborsMax { get; set; }

		/// <summary>
		/// <para>Include at least</para>
		/// <para>The minimum number of points to use in each sector. If the minimum number of required points are not available in any given sector, the nearest available point outside the sector will be selected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain()]
		public object NeighborsMin { get; set; }

		/// <summary>
		/// <para>Minor semiaxis</para>
		/// <para>Size of the minor semiaxis of the search neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPRangeDomain()]
		public object MinorSemiaxis { get; set; }

		/// <summary>
		/// <para>Major semiaxis</para>
		/// <para>Size of the major semiaxis of the search neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPRangeDomain()]
		public object MajorSemiaxis { get; set; }

		/// <summary>
		/// <para>Angle</para>
		/// <para>The angle of rotation of the neighborhood axis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPRangeDomain()]
		public object Angle { get; set; }

		/// <summary>
		/// <para>Shape type</para>
		/// <para>The geometry of the neighborhood.</para>
		/// <para>One sector— Single ellipse</para>
		/// <para>Four sectors— Ellipse divided into four sectors</para>
		/// <para>Four shifted sectors— Ellipse divided into four sectors and shifted 45 degrees</para>
		/// <para>Eight sectors— Ellipse divided into eight sectors</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeType { get; set; } = "ONE_SECTOR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GANeighborhoodSelection SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>One sector— Single ellipse</para>
			/// </summary>
			[GPValue("ONE_SECTOR")]
			[Description("One sector")]
			One_sector,

			/// <summary>
			/// <para>Four sectors— Ellipse divided into four sectors</para>
			/// </summary>
			[GPValue("FOUR_SECTORS")]
			[Description("Four sectors")]
			Four_sectors,

			/// <summary>
			/// <para>Four shifted sectors— Ellipse divided into four sectors and shifted 45 degrees</para>
			/// </summary>
			[GPValue("FOUR_SECTORS_SHIFTED")]
			[Description("Four shifted sectors")]
			Four_shifted_sectors,

			/// <summary>
			/// <para>Eight sectors— Ellipse divided into eight sectors</para>
			/// </summary>
			[GPValue("EIGHT_SECTORS")]
			[Description("Eight sectors")]
			Eight_sectors,

		}

#endregion
	}
}
