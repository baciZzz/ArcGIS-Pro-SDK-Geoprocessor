using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Apportion Polygon</para>
	/// <para>Summarizes the attributes of an input polygon layer based on the</para>
	/// <para>spatial overlay of a target polygon layer and assigns the summarized attributes to the target polygons. The target polygons have summed numeric attributes derived from the input polygons that each target overlaps. This process is</para>
	/// <para>typically known as apportioning or apportionment.</para>
	/// </summary>
	public class ApportionPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Polygons</para>
		/// <para>The polygon features with numeric attributes that will be summarized into the target polygon geometries.</para>
		/// </param>
		/// <param name="ApportionFields">
		/// <para>Fields to Apportion</para>
		/// <para>The numeric fields from the input polygons that will be summarized by each target polygon and recorded in the output feature class.</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Polygons</para>
		/// <para>The polygon features and their apportioned fields that will be copied to the output feature class.</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the attribute and geometries of the target polygons as well as the specified apportion fields from the input polygons.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Apportion Method</para>
		/// <para>Specifies the method that will be used to apportion the fields from the input polygons to the target polygons.</para>
		/// <para>Area—The amount that each input polygon contributes to the summarized values for each target feature will be determined by the area of overlap between the two features. If an input feature overlaps two target features by the same amount, the apportioned fields will be divided in two and contribute to both target features by half of the total value. This is the default.</para>
		/// <para>Length—The attributes from the input features will be divided based on the percentage of how much of a line is within each target feature. Only the line intersecting the input feature is included in the calculation. The line outside the input feature is excluded. For example, if one target feature covers 750 meters of a line, and another target feature covers 250 meters of a line, 75% (750 / 1000) of the input feature&apos;s attribute values will be aggregated to the first target feature, and 25% (250 / 1000) of the input feature&apos;s attribute values will be aggregated to the second target feature.</para>
		/// <para>Points—The attributes from the input features will be divided based on the number of points inside each target feature overlapping an input feature. Points outside of the input feature are excluded. Optionally, a weight field can be specified so that the total weight of all points within each target feature will be used to determine how the input features&apos; attribute values are divided. For example, if two target features overlap one input feature, and there are two points inside the first target feature and eight points inside the second target feature, 20% (2 / 10) of the input feature&apos;s attribute values will be aggregated to the first target feature, and 80% (8 / 10) of the input feature&apos;s attribute values will be aggregated to the second target feature.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public ApportionPolygon(object InFeatures, object ApportionFields, object TargetFeatures, object OutFeatures, object Method)
		{
			this.InFeatures = InFeatures;
			this.ApportionFields = ApportionFields;
			this.TargetFeatures = TargetFeatures;
			this.OutFeatures = OutFeatures;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : Apportion Polygon</para>
		/// </summary>
		public override string DisplayName => "Apportion Polygon";

		/// <summary>
		/// <para>Tool Name : ApportionPolygon</para>
		/// </summary>
		public override string ToolName => "ApportionPolygon";

		/// <summary>
		/// <para>Tool Excute Name : analysis.ApportionPolygon</para>
		/// </summary>
		public override string ExcuteName => "analysis.ApportionPolygon";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, ApportionFields, TargetFeatures, OutFeatures, Method, EstimationFeatures!, WeightField!, MaintainGeometries! };

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>The polygon features with numeric attributes that will be summarized into the target polygon geometries.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Apportion</para>
		/// <para>The numeric fields from the input polygons that will be summarized by each target polygon and recorded in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object ApportionFields { get; set; }

		/// <summary>
		/// <para>Target Polygons</para>
		/// <para>The polygon features and their apportioned fields that will be copied to the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the attribute and geometries of the target polygons as well as the specified apportion fields from the input polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Apportion Method</para>
		/// <para>Specifies the method that will be used to apportion the fields from the input polygons to the target polygons.</para>
		/// <para>Area—The amount that each input polygon contributes to the summarized values for each target feature will be determined by the area of overlap between the two features. If an input feature overlaps two target features by the same amount, the apportioned fields will be divided in two and contribute to both target features by half of the total value. This is the default.</para>
		/// <para>Length—The attributes from the input features will be divided based on the percentage of how much of a line is within each target feature. Only the line intersecting the input feature is included in the calculation. The line outside the input feature is excluded. For example, if one target feature covers 750 meters of a line, and another target feature covers 250 meters of a line, 75% (750 / 1000) of the input feature&apos;s attribute values will be aggregated to the first target feature, and 25% (250 / 1000) of the input feature&apos;s attribute values will be aggregated to the second target feature.</para>
		/// <para>Points—The attributes from the input features will be divided based on the number of points inside each target feature overlapping an input feature. Points outside of the input feature are excluded. Optionally, a weight field can be specified so that the total weight of all points within each target feature will be used to determine how the input features&apos; attribute values are divided. For example, if two target features overlap one input feature, and there are two points inside the first target feature and eight points inside the second target feature, 20% (2 / 10) of the input feature&apos;s attribute values will be aggregated to the first target feature, and 80% (8 / 10) of the input feature&apos;s attribute values will be aggregated to the second target feature.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "AREA";

		/// <summary>
		/// <para>Estimation Features</para>
		/// <para>The input point or polyline features that will be used to estimate the percent of the input polygon apportion fields to apportion to the target polygon. This is the amount of the point or line within the intersection divided by the amount within the input feature to create a percentage.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? EstimationFeatures { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>A numeric field from the target polygon layer that will be used to adjust which target polygons receive larger apportioned values from the input polygons&apos; fields to apportion. Targets with higher weight are apportioned a higher ratio of the field values.</para>
		/// <para>If estimation features are specified, the weight field will be a numeric field from the estimation features that will adjust the values apportioned to the target polygons intersecting the estimation features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Maintain target geometry</para>
		/// <para>Specifies whether the output feature class will maintain the original geometries from the target polygon layer.</para>
		/// <para>Checked—The output feature class will maintain the original geometries of the target polygon layer. This is the default.</para>
		/// <para>Unchecked—The output feature class will be a geometric intersection of the target polygons and the input polygons. Only areas of the target polygons that overlap an input polygon will be included in the output.</para>
		/// <para><see cref="MaintainGeometriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MaintainGeometries { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ApportionPolygon SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Apportion Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Area—The amount that each input polygon contributes to the summarized values for each target feature will be determined by the area of overlap between the two features. If an input feature overlaps two target features by the same amount, the apportioned fields will be divided in two and contribute to both target features by half of the total value. This is the default.</para>
			/// </summary>
			[GPValue("AREA")]
			[Description("Area")]
			Area,

			/// <summary>
			/// <para>Length—The attributes from the input features will be divided based on the percentage of how much of a line is within each target feature. Only the line intersecting the input feature is included in the calculation. The line outside the input feature is excluded. For example, if one target feature covers 750 meters of a line, and another target feature covers 250 meters of a line, 75% (750 / 1000) of the input feature&apos;s attribute values will be aggregated to the first target feature, and 25% (250 / 1000) of the input feature&apos;s attribute values will be aggregated to the second target feature.</para>
			/// </summary>
			[GPValue("LENGTH")]
			[Description("Length")]
			Length,

			/// <summary>
			/// <para>Points—The attributes from the input features will be divided based on the number of points inside each target feature overlapping an input feature. Points outside of the input feature are excluded. Optionally, a weight field can be specified so that the total weight of all points within each target feature will be used to determine how the input features&apos; attribute values are divided. For example, if two target features overlap one input feature, and there are two points inside the first target feature and eight points inside the second target feature, 20% (2 / 10) of the input feature&apos;s attribute values will be aggregated to the first target feature, and 80% (8 / 10) of the input feature&apos;s attribute values will be aggregated to the second target feature.</para>
			/// </summary>
			[GPValue("POINTS")]
			[Description("Points")]
			Points,

		}

		/// <summary>
		/// <para>Maintain target geometry</para>
		/// </summary>
		public enum MaintainGeometriesEnum 
		{
			/// <summary>
			/// <para>Checked—The output feature class will maintain the original geometries of the target polygon layer. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_GEOMETRIES")]
			MAINTAIN_GEOMETRIES,

			/// <summary>
			/// <para>Unchecked—The output feature class will be a geometric intersection of the target polygons and the input polygons. Only areas of the target polygons that overlap an input polygon will be included in the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERSECT_GEOMETRIES")]
			INTERSECT_GEOMETRIES,

		}

#endregion
	}
}
