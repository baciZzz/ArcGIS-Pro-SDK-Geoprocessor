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
	/// <para>Add Spatial Index</para>
	/// <para>Adds a spatial index to a shapefile, file geodatabase, mobile geodatabase, or enterprise geodatabase feature class.   Use this tool to either add a spatial index to a shapefile or feature class that does not already have one or to re-create an existing spatial index.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddSpatialIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>An enterprise geodatabase feature class, file geodatabase feature class, mobile geodatabase feature class, or shapefile to which a spatial index is to be added or rebuilt.</para>
		/// </param>
		public AddSpatialIndex(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Spatial Index</para>
		/// </summary>
		public override string DisplayName => "Add Spatial Index";

		/// <summary>
		/// <para>Tool Name : AddSpatialIndex</para>
		/// </summary>
		public override string ToolName => "AddSpatialIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.AddSpatialIndex</para>
		/// </summary>
		public override string ExcuteName => "management.AddSpatialIndex";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, SpatialGrid1, SpatialGrid2, SpatialGrid3, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>An enterprise geodatabase feature class, file geodatabase feature class, mobile geodatabase feature class, or shapefile to which a spatial index is to be added or rebuilt.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Spatial Grid 1</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpatialGrid1 { get; set; } = "0";

		/// <summary>
		/// <para>Spatial Grid 2</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpatialGrid2 { get; set; } = "0";

		/// <summary>
		/// <para>Spatial Grid 3</para>
		/// <para>This parameter has been deprecated in ArcGIS Pro. Any value you enter will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SpatialGrid3 { get; set; } = "0";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSpatialIndex SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
