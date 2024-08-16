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
	/// <para>Add XY Coordinates</para>
	/// <para>Adds the fields POINT_X and POINT_Y to the point input features and calculates their values. It also appends the POINT_Z and POINT_M fields if the input features are Z- and M-enabled.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes"/> tool provides enhanced functionality or performance</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.DataManagementTools.CalculateGeometryAttributes))]
	[InputWillBeModified()]
	public class AddXY : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point features whose x,y coordinates will be appended as POINT_X and POINT_Y fields.</para>
		/// </param>
		public AddXY(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add XY Coordinates</para>
		/// </summary>
		public override string DisplayName => "Add XY Coordinates";

		/// <summary>
		/// <para>Tool Name : AddXY</para>
		/// </summary>
		public override string ToolName => "AddXY";

		/// <summary>
		/// <para>Tool Excute Name : management.AddXY</para>
		/// </summary>
		public override string ExcuteName => "management.AddXY";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features whose x,y coordinates will be appended as POINT_X and POINT_Y fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddXY SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
