using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Skyline Graph</para>
	/// <para>Calculates sky visibility and generates an optional table and polar graph.</para>
	/// </summary>
	public class SkylineGraph : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPointFeatures">
		/// <para>Input Observer Point Features</para>
		/// <para>The input features containing one or more observer points.</para>
		/// </param>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line features that represent the skyline.</para>
		/// </param>
		public SkylineGraph(object InObserverPointFeatures, object InLineFeatures)
		{
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.InLineFeatures = InLineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Skyline Graph</para>
		/// </summary>
		public override string DisplayName => "Skyline Graph";

		/// <summary>
		/// <para>Tool Name : SkylineGraph</para>
		/// </summary>
		public override string ToolName => "SkylineGraph";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SkylineGraph</para>
		/// </summary>
		public override string ExcuteName => "3d.SkylineGraph";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObserverPointFeatures, InLineFeatures, BaseVisibilityAngle, AdditionalFields, OutAnglesTable, OutGraph, OutVisibilityRatio };

		/// <summary>
		/// <para>Input Observer Point Features</para>
		/// <para>The input features containing one or more observer points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features that represent the skyline.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Base  Visibility Angle</para>
		/// <para>The baseline vertical angle that is used for calculating the percentage of visible sky. 0 is the horizon, 90 is straight up; -90 is straight down. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BaseVisibilityAngle { get; set; } = "0";

		/// <summary>
		/// <para>Additional Fields</para>
		/// <para>Indicates whether additional fields will be added to the angles table.</para>
		/// <para>Unchecked—Additional fields will not be added. This is the default.</para>
		/// <para>Checked—Additional fields will be added.</para>
		/// <para><see cref="AdditionalFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AdditionalFields { get; set; } = "false";

		/// <summary>
		/// <para>Output Angles Table</para>
		/// <para>The table to be created for outputting the angles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutAnglesTable { get; set; }

		/// <summary>
		/// <para>Output Graph Name</para>
		/// <para>This parameter is not supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGraph()]
		public object OutGraph { get; set; }

		/// <summary>
		/// <para>Visibility Ratio</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutVisibilityRatio { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SkylineGraph SetEnviroment(object extent = null , object geographicTransformations = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Additional Fields</para>
		/// </summary>
		public enum AdditionalFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Additional fields will be added.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADDITIONAL_FIELDS")]
			ADDITIONAL_FIELDS,

			/// <summary>
			/// <para>Unchecked—Additional fields will not be added. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ADDITIONAL_FIELDS")]
			NO_ADDITIONAL_FIELDS,

		}

#endregion
	}
}
