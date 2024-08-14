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
	/// <para>Central Feature</para>
	/// <para>Identifies the most centrally located feature in a point, line, or polygon feature class.</para>
	/// </summary>
	public class CentralFeature : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class containing a distribution of features from which to identify the most centrally located feature.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the most centrally located feature in the Input Feature Class.</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		public CentralFeature(object InputFeatureClass, object OutputFeatureClass, object DistanceMethod)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputFeatureClass = OutputFeatureClass;
			this.DistanceMethod = DistanceMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Central Feature</para>
		/// </summary>
		public override string DisplayName => "Central Feature";

		/// <summary>
		/// <para>Tool Name : CentralFeature</para>
		/// </summary>
		public override string ToolName => "CentralFeature";

		/// <summary>
		/// <para>Tool Excute Name : stats.CentralFeature</para>
		/// </summary>
		public override string ExcuteName => "stats.CentralFeature";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatureClass, OutputFeatureClass, DistanceMethod, WeightField, SelfPotentialWeightField, CaseField };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class containing a distribution of features from which to identify the most centrally located feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the most centrally located feature in the Input Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>The numeric field used to weight distances in the origin-destination distance matrix.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Self Potential Weight Field</para>
		/// <para>The field representing self-potential—the distance or weight between a feature and itself.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object SelfPotentialWeightField { get; set; }

		/// <summary>
		/// <para>Case Field</para>
		/// <para>Field used to group features for separate central feature computations. The case field can be of integer, date, or string type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CentralFeature SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
			/// </summary>
			[GPValue("EUCLIDEAN_DISTANCE")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
			/// </summary>
			[GPValue("MANHATTAN_DISTANCE")]
			[Description("Manhattan")]
			Manhattan,

		}

#endregion
	}
}
