using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Directional Distribution (Standard Deviational Ellipse)</para>
	/// <para>Directional Distribution (Standard Deviational Ellipse)</para>
	/// <para>Creates standard deviational ellipses or ellipsoids to summarize the spatial characteristics of geographic features: central tendency, dispersion, and directional trends.</para>
	/// </summary>
	public class DirectionalDistribution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>A feature class containing a distribution of features for which the standard deviational ellipse or ellipsoid will be calculated.</para>
		/// </param>
		/// <param name="OutputEllipseFeatureClass">
		/// <para>Output Ellipse Feature Class</para>
		/// <para>A polygon feature class that will contain the output ellipse feature.</para>
		/// </param>
		/// <param name="EllipseSize">
		/// <para>Ellipse Size</para>
		/// <para>The size of output ellipses in standard deviations. The default ellipse size is 1; valid choices are 1, 2, or 3 standard deviations.</para>
		/// <para>1 standard deviation—1 standard deviation</para>
		/// <para>2 standard deviations—2 standard deviations</para>
		/// <para>3 standard deviations—3 standard deviations</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </param>
		public DirectionalDistribution(object InputFeatureClass, object OutputEllipseFeatureClass, object EllipseSize)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputEllipseFeatureClass = OutputEllipseFeatureClass;
			this.EllipseSize = EllipseSize;
		}

		/// <summary>
		/// <para>Tool Display Name : Directional Distribution (Standard Deviational Ellipse)</para>
		/// </summary>
		public override string DisplayName() => "Directional Distribution (Standard Deviational Ellipse)";

		/// <summary>
		/// <para>Tool Name : DirectionalDistribution</para>
		/// </summary>
		public override string ToolName() => "DirectionalDistribution";

		/// <summary>
		/// <para>Tool Excute Name : stats.DirectionalDistribution</para>
		/// </summary>
		public override string ExcuteName() => "stats.DirectionalDistribution";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputEllipseFeatureClass, EllipseSize, WeightField!, CaseField! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>A feature class containing a distribution of features for which the standard deviational ellipse or ellipsoid will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Ellipse Feature Class</para>
		/// <para>A polygon feature class that will contain the output ellipse feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputEllipseFeatureClass { get; set; }

		/// <summary>
		/// <para>Ellipse Size</para>
		/// <para>The size of output ellipses in standard deviations. The default ellipse size is 1; valid choices are 1, 2, or 3 standard deviations.</para>
		/// <para>1 standard deviation—1 standard deviation</para>
		/// <para>2 standard deviations—2 standard deviations</para>
		/// <para>3 standard deviations—3 standard deviations</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EllipseSize { get; set; } = "1_STANDARD_DEVIATION";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>The numeric field used to weight locations according to their relative importance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Case Field</para>
		/// <para>The field used to group features for separate directional distribution calculations. The case field can be of integer, date, or string type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object? CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DirectionalDistribution SetEnviroment(double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ellipse Size</para>
		/// </summary>
		public enum EllipseSizeEnum 
		{
			/// <summary>
			/// <para>1 standard deviation—1 standard deviation</para>
			/// </summary>
			[GPValue("1_STANDARD_DEVIATION")]
			[Description("1 standard deviation")]
			_1_standard_deviation,

			/// <summary>
			/// <para>2 standard deviations—2 standard deviations</para>
			/// </summary>
			[GPValue("2_STANDARD_DEVIATIONS")]
			[Description("2 standard deviations")]
			_2_standard_deviations,

			/// <summary>
			/// <para>3 standard deviations—3 standard deviations</para>
			/// </summary>
			[GPValue("3_STANDARD_DEVIATIONS")]
			[Description("3 standard deviations")]
			_3_standard_deviations,

		}

#endregion
	}
}
