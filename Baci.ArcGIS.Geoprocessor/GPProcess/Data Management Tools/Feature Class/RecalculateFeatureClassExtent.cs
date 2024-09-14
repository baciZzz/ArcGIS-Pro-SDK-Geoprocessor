using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Recalculate Feature Class Extent</para>
	/// <para>Recalculate Feature Class Extent</para>
	/// <para>Recalculates the XY, Z, and M extent properties of a feature class based on the features in the feature class.</para>
	/// </summary>
	public class RecalculateFeatureClassExtent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Feature Class</para>
		/// <para>The shapefile or geodatabase feature class that will be updated.</para>
		/// </param>
		public RecalculateFeatureClassExtent(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Recalculate Feature Class Extent</para>
		/// </summary>
		public override string DisplayName() => "Recalculate Feature Class Extent";

		/// <summary>
		/// <para>Tool Name : RecalculateFeatureClassExtent</para>
		/// </summary>
		public override string ToolName() => "RecalculateFeatureClassExtent";

		/// <summary>
		/// <para>Tool Excute Name : management.RecalculateFeatureClassExtent</para>
		/// </summary>
		public override string ExcuteName() => "management.RecalculateFeatureClassExtent";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures };

		/// <summary>
		/// <para>Feature Class</para>
		/// <para>The shapefile or geodatabase feature class that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RecalculateFeatureClassExtent SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
