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
	/// <para>Calculate Central Meridian And Parallels</para>
	/// <para>Calculates the central meridian and optional standard parallels based on the center point of a feature's extent; stores this coordinate system as a spatial reference string in a specified text field; and repeats this for a set, or subset, of features. This field can be used with a spatial map series  to update the data frame coordinate system for each page.</para>
	/// </summary>
	public class CalculateCentralMeridianAndParallels : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature layer.</para>
		/// </param>
		/// <param name="InField">
		/// <para>Coordinate System Field</para>
		/// <para>The text field where the coordinate system string will be stored.</para>
		/// </param>
		public CalculateCentralMeridianAndParallels(object InFeatures, object InField)
		{
			this.InFeatures = InFeatures;
			this.InField = InField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Central Meridian And Parallels</para>
		/// </summary>
		public override string DisplayName() => "Calculate Central Meridian And Parallels";

		/// <summary>
		/// <para>Tool Name : CalculateCentralMeridianAndParallels</para>
		/// </summary>
		public override string ToolName() => "CalculateCentralMeridianAndParallels";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateCentralMeridianAndParallels</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateCentralMeridianAndParallels";

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
		public override object[] Parameters() => new object[] { InFeatures, InField, StandardOffset, OutFeatures };

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
		/// <para>Coordinate System Field</para>
		/// <para>The text field where the coordinate system string will be stored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object InField { get; set; }

		/// <summary>
		/// <para>Standard Parallel Offset</para>
		/// <para>The percentage of the height of the input feature used to offset the standard parallels from the center latitude of the input feature. The default is 25 percent or 0.25. Negative values and values greater than 1 are acceptable inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object StandardOffset { get; set; } = "0.25";

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateCentralMeridianAndParallels SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
