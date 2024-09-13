using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Update by Geometry</para>
	/// <para>Update by Geometry</para>
	/// <para>Updates all the edge references in the turn feature class using the geometry of the turn features. This tool is useful when the IDs listed for the turn can no longer find the edges participating in the turn due to edits to the underlying edges.</para>
	/// </summary>
	public class UpdateByGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTurnFeatures">
		/// <para>Input Turn Feature Class</para>
		/// <para>The turn feature class to be updated.</para>
		/// </param>
		public UpdateByGeometry(object InTurnFeatures)
		{
			this.InTurnFeatures = InTurnFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Update by Geometry</para>
		/// </summary>
		public override string DisplayName() => "Update by Geometry";

		/// <summary>
		/// <para>Tool Name : UpdateByGeometry</para>
		/// </summary>
		public override string ToolName() => "UpdateByGeometry";

		/// <summary>
		/// <para>Tool Excute Name : na.UpdateByGeometry</para>
		/// </summary>
		public override string ExcuteName() => "na.UpdateByGeometry";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTurnFeatures, OutTurnFeatures! };

		/// <summary>
		/// <para>Input Turn Feature Class</para>
		/// <para>The turn feature class to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InTurnFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Turn Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutTurnFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateByGeometry SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
