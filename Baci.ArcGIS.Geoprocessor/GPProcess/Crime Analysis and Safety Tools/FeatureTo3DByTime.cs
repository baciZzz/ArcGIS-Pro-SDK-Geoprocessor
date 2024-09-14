using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Feature To 3D By Time</para>
	/// <para>Feature To 3D By Time</para>
	/// <para>Creates a 3D feature class using date values from</para>
	/// <para>input features.</para>
	/// </summary>
	public class FeatureTo3DByTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features used to create 3D features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output z-enabled feature class.</para>
		/// </param>
		/// <param name="DateField">
		/// <para>Date Field</para>
		/// <para>A date field from the input that will be used to calculate the extrusion of the feature..</para>
		/// </param>
		public FeatureTo3DByTime(object InFeatures, object OutFeatureClass, object DateField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DateField = DateField;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature To 3D By Time</para>
		/// </summary>
		public override string DisplayName() => "Feature To 3D By Time";

		/// <summary>
		/// <para>Tool Name : FeatureTo3DByTime</para>
		/// </summary>
		public override string ToolName() => "FeatureTo3DByTime";

		/// <summary>
		/// <para>Tool Excute Name : ca.FeatureTo3DByTime</para>
		/// </summary>
		public override string ExcuteName() => "ca.FeatureTo3DByTime";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZValue", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, DateField, TimeZUnit, BaseZ, BaseDate };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features used to create 3D features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output z-enabled feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>A date field from the input that will be used to calculate the extrusion of the feature..</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateField { get; set; }

		/// <summary>
		/// <para>Time Z Interval and Unit</para>
		/// <para>The time interval and unit that will be represented by one vertical linear unit in the output feature class.</para>
		/// <para>For example, if the output feature class has a vertical coordinate system based in meters and this parameter has a value of 1 second, the resulting feature class will have features extruded in which 1 meter of elevation is equal to 1 second of time.</para>
		/// <para><see cref="TimeZUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeZUnit { get; set; } = "1 Seconds";

		/// <summary>
		/// <para>Base z-value</para>
		/// <para>The base z-value from which the output feature will start the extrusion.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object BaseZ { get; set; } = "0";

		/// <summary>
		/// <para>Base Date and Time</para>
		/// <para>The date and time on which the time extrusion will be based.</para>
		/// <para>When no value is specified, the minimum date value of the input will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object BaseDate { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureTo3DByTime SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputZValue = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZValue: outputZValue, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Z Interval and Unit</para>
		/// </summary>
		public enum TimeZUnitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

		}

#endregion
	}
}
