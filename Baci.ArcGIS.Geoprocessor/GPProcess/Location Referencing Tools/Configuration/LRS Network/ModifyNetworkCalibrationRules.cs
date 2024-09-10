using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Modify Network Calibration Rules</para>
	/// <para>Modifies the network calibration rules for an LRS Network.</para>
	/// </summary>
	public class ModifyNetworkCalibrationRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>The input LRS Network feature class.</para>
		/// </param>
		public ModifyNetworkCalibrationRules(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify Network Calibration Rules</para>
		/// </summary>
		public override string DisplayName() => "Modify Network Calibration Rules";

		/// <summary>
		/// <para>Tool Name : ModifyNetworkCalibrationRules</para>
		/// </summary>
		public override string ToolName() => "ModifyNetworkCalibrationRules";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyNetworkCalibrationRules</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyNetworkCalibrationRules";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, CalibrationRule, CalibrationOffset, OutFeatureClass };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>The input LRS Network feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibration Rule</para>
		/// <para>Specifies the method that will be used to define calibration gap measures.</para>
		/// <para>As Is—The existing defined method in the network will be used while changing the calibration offset value.</para>
		/// <para>Adding Euclidean Distance—The Euclidean, or straight-line, distance will be calculated and added at each physical gap along an edited route.</para>
		/// <para>Stepping Increment—A value will be defined that will adjust, or step, at each physical gap in the route. This is the default.</para>
		/// <para>Adding Increment— A value will be defined and added to each measure of a route at each physical gap, in addition to the total length of the from and to measures of the route.</para>
		/// <para><see cref="CalibrationRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CalibrationRule { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Calibration Offset</para>
		/// <para>The value of the Calibration Rule parameter's Adding Increment or Stepping Increment method. The increment value must be numeric and can include decimals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object CalibrationOffset { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyNetworkCalibrationRules SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibration Rule</para>
		/// </summary>
		public enum CalibrationRuleEnum 
		{
			/// <summary>
			/// <para>As Is—The existing defined method in the network will be used while changing the calibration offset value.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As Is")]
			As_Is,

			/// <summary>
			/// <para>Adding Euclidean Distance—The Euclidean, or straight-line, distance will be calculated and added at each physical gap along an edited route.</para>
			/// </summary>
			[GPValue("ADDING_EUCLIDEAN_DISTANCE")]
			[Description("Adding Euclidean Distance")]
			Adding_Euclidean_Distance,

			/// <summary>
			/// <para>Stepping Increment—A value will be defined that will adjust, or step, at each physical gap in the route. This is the default.</para>
			/// </summary>
			[GPValue("STEPPING_INCREMENT")]
			[Description("Stepping Increment")]
			Stepping_Increment,

			/// <summary>
			/// <para>Adding Increment— A value will be defined and added to each measure of a route at each physical gap, in addition to the total length of the from and to measures of the route.</para>
			/// </summary>
			[GPValue("ADDING_INCREMENT")]
			[Description("Adding Increment")]
			Adding_Increment,

		}

#endregion
	}
}
