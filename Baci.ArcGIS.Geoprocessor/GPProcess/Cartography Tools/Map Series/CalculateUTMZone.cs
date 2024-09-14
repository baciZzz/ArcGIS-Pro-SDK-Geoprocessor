using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Calculate UTM Zone</para>
	/// <para>Calculate UTM Zone</para>
	/// <para>Calculates the UTM zone of each feature based on the center point and stores this spatial reference string in a specified field. This field can be used with a spatial map series  to update the spatial reference to the correct UTM zone for each map.</para>
	/// </summary>
	public class CalculateUTMZone : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature layer.</para>
		/// </param>
		/// <param name="InField">
		/// <para>UTM Zone Field</para>
		/// <para>The string field that stores the spatial reference string for the coordinate system. The field should have sufficient length (more than 600 characters) to hold the spatial reference string.</para>
		/// </param>
		public CalculateUTMZone(object InFeatures, object InField)
		{
			this.InFeatures = InFeatures;
			this.InField = InField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate UTM Zone</para>
		/// </summary>
		public override string DisplayName() => "Calculate UTM Zone";

		/// <summary>
		/// <para>Tool Name : CalculateUTMZone</para>
		/// </summary>
		public override string ToolName() => "CalculateUTMZone";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateUTMZone</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateUTMZone";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InField, OutFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>UTM Zone Field</para>
		/// <para>The string field that stores the spatial reference string for the coordinate system. The field should have sufficient length (more than 600 characters) to hold the spatial reference string.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateUTMZone SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
