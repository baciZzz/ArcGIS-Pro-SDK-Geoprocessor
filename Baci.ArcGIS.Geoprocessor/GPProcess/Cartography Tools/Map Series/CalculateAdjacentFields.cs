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
	/// <para>Calculate Adjacent Fields</para>
	/// <para>Calculate Adjacent Fields</para>
	/// <para>Creates fields and calculates values for the neighboring pages (polygon) of a grid polygon feature class.</para>
	/// </summary>
	public class CalculateAdjacentFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygon grid index features that will be appended with adjacent field data.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Field Name</para>
		/// <para>The field whose values will be used to populate adjacent field data.</para>
		/// </param>
		public CalculateAdjacentFields(object InFeatures, object InField)
		{
			this.InFeatures = InFeatures;
			this.InField = InField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Adjacent Fields</para>
		/// </summary>
		public override string DisplayName() => "Calculate Adjacent Fields";

		/// <summary>
		/// <para>Tool Name : CalculateAdjacentFields</para>
		/// </summary>
		public override string ToolName() => "CalculateAdjacentFields";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateAdjacentFields</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateAdjacentFields";

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
		/// <para>The polygon grid index features that will be appended with adjacent field data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>The field whose values will be used to populate adjacent field data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Float", "Double", "Short", "Long")]
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
		public CalculateAdjacentFields SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
