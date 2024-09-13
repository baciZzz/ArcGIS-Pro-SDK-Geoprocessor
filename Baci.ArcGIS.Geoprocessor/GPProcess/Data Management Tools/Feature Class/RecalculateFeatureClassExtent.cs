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
	/// <para>Recalculates the xy, z, and m extent properties of a feature class based on the features in the feature class.</para>
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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures!, StoreExtent! };

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
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Store Extent</para>
		/// <para>Specifies whether the extent will be stored for feature classes that are not registered. This parameter is only active when the input feature class is an unregistered spatial table.</para>
		/// <para>If the input feature class is updated frequently, you may choose not to store the recalculated extent value. If you choose to store the extent, the extent will not be recalculated each time the feature class is added to a map.</para>
		/// <para>Checked—The extent will be stored for the input feature class.</para>
		/// <para>Unchecked—The extent will not be stored for the input feature class. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? StoreExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RecalculateFeatureClassExtent SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
