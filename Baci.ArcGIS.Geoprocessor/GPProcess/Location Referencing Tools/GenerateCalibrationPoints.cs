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
	/// <para>Generate Calibration Points</para>
	/// <para>Generates calibration points for any route shape provided, including  complex shapes such as self-closing, self-intersecting, and branched routes.</para>
	/// </summary>
	public class GenerateCalibrationPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolylineFeatures">
		/// <para>Input Polyline Features</para>
		/// <para>The features that will be used as the source to calculate the measure values for calibration points.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The field containing values that uniquely identify each route. The field type must match the Route ID field in the calibration point feature class.</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>The field containing the from date values of a route.</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>The field containing the to date values of a route.</para>
		/// </param>
		/// <param name="InCalibrationPointFeatureClass">
		/// <para>Calibration Point Feature Class</para>
		/// <para>The existing calibration point feature class to which new features will be added.</para>
		/// </param>
		/// <param name="LrsNetwork">
		/// <para>LRS Network</para>
		/// <para>The LRS Network for which the measure values will be generated in the calibration points feature class.</para>
		/// </param>
		public GenerateCalibrationPoints(object InPolylineFeatures, object RouteIdField, object FromDateField, object ToDateField, object InCalibrationPointFeatureClass, object LrsNetwork)
		{
			this.InPolylineFeatures = InPolylineFeatures;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
			this.InCalibrationPointFeatureClass = InCalibrationPointFeatureClass;
			this.LrsNetwork = LrsNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Calibration Points</para>
		/// </summary>
		public override string DisplayName => "Generate Calibration Points";

		/// <summary>
		/// <para>Tool Name : GenerateCalibrationPoints</para>
		/// </summary>
		public override string ToolName => "GenerateCalibrationPoints";

		/// <summary>
		/// <para>Tool Excute Name : locref.GenerateCalibrationPoints</para>
		/// </summary>
		public override string ExcuteName => "locref.GenerateCalibrationPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPolylineFeatures, RouteIdField, FromDateField, ToDateField, InCalibrationPointFeatureClass, LrsNetwork, CalibrationDirection!, CalibrationMethod!, OutCalibrationPointFeatureClass!, OutDetailsFile!, FromMeasureField!, ToMeasureField! };

		/// <summary>
		/// <para>Input Polyline Features</para>
		/// <para>The features that will be used as the source to calculate the measure values for calibration points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field containing values that uniquely identify each route. The field type must match the Route ID field in the calibration point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>The field containing the from date values of a route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>The field containing the to date values of a route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Calibration Point Feature Class</para>
		/// <para>The existing calibration point feature class to which new features will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InCalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>LRS Network</para>
		/// <para>The LRS Network for which the measure values will be generated in the calibration points feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsNetwork { get; set; }

		/// <summary>
		/// <para>Calibration Direction</para>
		/// <para>Specifies the direction of increasing calibration on a route when creating calibration points.</para>
		/// <para>Digitized direction—The direction of digitization of the Input Polyline Features parameter value determines the direction of calibration for the route. This is the default.</para>
		/// <para>Measure direction—The direction of increasing m-values of the Input Polyline Features parameter value determines the direction of calibration for the route. If the Input Polyline Features parameter value does not include m-values, the digitized direction will be used instead.</para>
		/// <para><see cref="CalibrationDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationDirection { get; set; } = "DIGITIZED_DIRECTION";

		/// <summary>
		/// <para>Calibration Method</para>
		/// <para>Specifies the method that will be used to determine the measures on a route when creating calibration points.</para>
		/// <para>Geometry length—The geometrical length of the input route feature will be used as the calibration method. This is the default.</para>
		/// <para>M on route—The measure values on the input route feature will be used as the calibration method.</para>
		/// <para>Attribute fields—The measure values stored in attribute fields of the input route feature will be used as the calibration method.</para>
		/// <para><see cref="CalibrationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationMethod { get; set; } = "GEOMETRY_LENGTH";

		/// <summary>
		/// <para>Updated Calibration Point Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutCalibrationPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>From Measure Field</para>
		/// <para>The field containing the from measure for the selected route.</para>
		/// <para>This parameter is active when the Calibration Method parameter is set to Attribute fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? FromMeasureField { get; set; }

		/// <summary>
		/// <para>To Measure Field</para>
		/// <para>The field containing the to measure for the selected route.</para>
		/// <para>This parameter is active when the Calibration Method parameter is set to Attribute fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? ToMeasureField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCalibrationPoints SetEnviroment(object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibration Direction</para>
		/// </summary>
		public enum CalibrationDirectionEnum 
		{
			/// <summary>
			/// <para>Digitized direction—The direction of digitization of the Input Polyline Features parameter value determines the direction of calibration for the route. This is the default.</para>
			/// </summary>
			[GPValue("DIGITIZED_DIRECTION")]
			[Description("Digitized direction")]
			Digitized_direction,

			/// <summary>
			/// <para>Measure direction—The direction of increasing m-values of the Input Polyline Features parameter value determines the direction of calibration for the route. If the Input Polyline Features parameter value does not include m-values, the digitized direction will be used instead.</para>
			/// </summary>
			[GPValue("MEASURE_DIRECTION")]
			[Description("Measure direction")]
			Measure_direction,

		}

		/// <summary>
		/// <para>Calibration Method</para>
		/// </summary>
		public enum CalibrationMethodEnum 
		{
			/// <summary>
			/// <para>Geometry length—The geometrical length of the input route feature will be used as the calibration method. This is the default.</para>
			/// </summary>
			[GPValue("GEOMETRY_LENGTH")]
			[Description("Geometry length")]
			Geometry_length,

			/// <summary>
			/// <para>M on route—The measure values on the input route feature will be used as the calibration method.</para>
			/// </summary>
			[GPValue("M_ON_ROUTE")]
			[Description("M on route")]
			M_on_route,

			/// <summary>
			/// <para>Attribute fields—The measure values stored in attribute fields of the input route feature will be used as the calibration method.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_FIELDS")]
			[Description("Attribute fields")]
			Attribute_fields,

		}

#endregion
	}
}
