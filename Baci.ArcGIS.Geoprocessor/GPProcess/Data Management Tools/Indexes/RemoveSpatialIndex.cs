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
	/// <para>Remove Spatial Index</para>
	/// <para>Remove Spatial Index</para>
	/// <para>Deletes the spatial index from a shapefile or file geodatabase, mobile geodatabase, or an enterprise geodatabase feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveSpatialIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The shapefile or file geodatabase, mobile geodatabase, or an enterprise geodatabase feature class from which a spatial index will be removed.</para>
		/// </param>
		public RemoveSpatialIndex(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Spatial Index</para>
		/// </summary>
		public override string DisplayName() => "Remove Spatial Index";

		/// <summary>
		/// <para>Tool Name : RemoveSpatialIndex</para>
		/// </summary>
		public override string ToolName() => "RemoveSpatialIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveSpatialIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveSpatialIndex";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The shapefile or file geodatabase, mobile geodatabase, or an enterprise geodatabase feature class from which a spatial index will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveSpatialIndex SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
