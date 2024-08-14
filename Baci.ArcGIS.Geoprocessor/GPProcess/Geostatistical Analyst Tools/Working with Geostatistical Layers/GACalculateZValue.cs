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
	/// <para>Calculate Z-value</para>
	/// <para>Uses the interpolation model in a geostatistical layer to predict a value at a single location.</para>
	/// </summary>
	public class GACalculateZValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </param>
		/// <param name="PointCoord">
		/// <para>Input point</para>
		/// <para>The x,y coordinate of the point for which the Z-value will be calculated.</para>
		/// </param>
		public GACalculateZValue(object InGeostatLayer, object PointCoord)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.PointCoord = PointCoord;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Z-value</para>
		/// </summary>
		public override string DisplayName => "Calculate Z-value";

		/// <summary>
		/// <para>Tool Name : GACalculateZValue</para>
		/// </summary>
		public override string ToolName => "GACalculateZValue";

		/// <summary>
		/// <para>Tool Excute Name : ga.GACalculateZValue</para>
		/// </summary>
		public override string ExcuteName => "ga.GACalculateZValue";

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
		public override object[] Parameters => new object[] { InGeostatLayer, PointCoord, OutZValue! };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Input point</para>
		/// <para>The x,y coordinate of the point for which the Z-value will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object PointCoord { get; set; }

		/// <summary>
		/// <para>Output Z-value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? OutZValue { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GACalculateZValue SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
