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
	/// <para>Linear Directional Mean</para>
	/// <para>Linear Directional Mean</para>
	/// <para>Identifies the mean direction, length, and geographic center for a set of lines.</para>
	/// </summary>
	public class DirectionalMean : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class containing vectors for which the mean direction will be calculated.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A line feature class that will contain the features representing the mean directions of the input feature class.</para>
		/// </param>
		/// <param name="OrientationOnly">
		/// <para>Orientation Only</para>
		/// <para>Specifies whether to include direction (From and To nodes) information in the analysis.</para>
		/// <para>Checked—The From and To node information is ignored.</para>
		/// <para>Unchecked—The From and To nodes are utilized in calculating the mean. This is the default.</para>
		/// <para><see cref="OrientationOnlyEnum"/></para>
		/// </param>
		public DirectionalMean(object InputFeatureClass, object OutputFeatureClass, object OrientationOnly)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputFeatureClass = OutputFeatureClass;
			this.OrientationOnly = OrientationOnly;
		}

		/// <summary>
		/// <para>Tool Display Name : Linear Directional Mean</para>
		/// </summary>
		public override string DisplayName() => "Linear Directional Mean";

		/// <summary>
		/// <para>Tool Name : DirectionalMean</para>
		/// </summary>
		public override string ToolName() => "DirectionalMean";

		/// <summary>
		/// <para>Tool Excute Name : stats.DirectionalMean</para>
		/// </summary>
		public override string ExcuteName() => "stats.DirectionalMean";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputFeatureClass, OrientationOnly, CaseField! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class containing vectors for which the mean direction will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A line feature class that will contain the features representing the mean directions of the input feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Orientation Only</para>
		/// <para>Specifies whether to include direction (From and To nodes) information in the analysis.</para>
		/// <para>Checked—The From and To node information is ignored.</para>
		/// <para>Unchecked—The From and To nodes are utilized in calculating the mean. This is the default.</para>
		/// <para><see cref="OrientationOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OrientationOnly { get; set; } = "false";

		/// <summary>
		/// <para>Case Field</para>
		/// <para>Field used to group features for separate directional mean calculations. The case field can be of integer, date, or string type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object? CaseField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DirectionalMean SetEnviroment(double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Orientation Only</para>
		/// </summary>
		public enum OrientationOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—The From and To node information is ignored.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ORIENTATION_ONLY")]
			ORIENTATION_ONLY,

			/// <summary>
			/// <para>Unchecked—The From and To nodes are utilized in calculating the mean. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DIRECTION")]
			DIRECTION,

		}

#endregion
	}
}
