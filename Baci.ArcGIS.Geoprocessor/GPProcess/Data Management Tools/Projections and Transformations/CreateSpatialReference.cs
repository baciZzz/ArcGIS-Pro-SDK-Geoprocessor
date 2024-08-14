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
	/// <para>Create Spatial Reference</para>
	/// <para>Creates a spatial reference for use in ModelBuilder.</para>
	/// </summary>
	public class CreateSpatialReference : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public CreateSpatialReference()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : Create Spatial Reference</para>
		/// </summary>
		public override string DisplayName => "Create Spatial Reference";

		/// <summary>
		/// <para>Tool Name : CreateSpatialReference</para>
		/// </summary>
		public override string ToolName => "CreateSpatialReference";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateSpatialReference</para>
		/// </summary>
		public override string ExcuteName => "management.CreateSpatialReference";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SpatialReference, SpatialReferenceTemplate, XyDomain, ZDomain, MDomain, Template, ExpandRatio, OutSpatialReference };

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The name of the spatial reference to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Spatial Reference Template</para>
		/// <para>The feature class or layer to be used as a template to set the value for the spatial reference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object SpatialReferenceTemplate { get; set; }

		/// <summary>
		/// <para>XY Domain</para>
		/// <para>The allowable coordinate range for x,y coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object XyDomain { get; set; }

		/// <summary>
		/// <para>Z Domain (min max)</para>
		/// <para>The allowable coordinate range for z-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ZDomain { get; set; }

		/// <summary>
		/// <para>M Domain (min max)</para>
		/// <para>The allowable coordinate range for m-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object MDomain { get; set; }

		/// <summary>
		/// <para>Template XYDomains</para>
		/// <para>The feature classes or layers that can be used to define the XY Domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Template { get; set; }

		/// <summary>
		/// <para>Grow XYDomain By Percentage</para>
		/// <para>The percentage by which the XY Domain will be expanded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ExpandRatio { get; set; } = "0";

		/// <summary>
		/// <para>Output Spatial Reference</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPSpatialReference()]
		public object OutSpatialReference { get; set; }

	}
}
