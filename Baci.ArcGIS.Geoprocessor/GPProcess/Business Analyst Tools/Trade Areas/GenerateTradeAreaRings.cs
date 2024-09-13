using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Trade Area Rings</para>
	/// <para>Generate Trade Area Rings</para>
	/// <para>Creates rings around point locations.</para>
	/// </summary>
	public class GenerateTradeAreaRings : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features containing the center points for the rings.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the output ring features.</para>
		/// </param>
		public GenerateTradeAreaRings(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Trade Area Rings</para>
		/// </summary>
		public override string DisplayName() => "Generate Trade Area Rings";

		/// <summary>
		/// <para>Tool Name : GenerateTradeAreaRings</para>
		/// </summary>
		public override string ToolName() => "GenerateTradeAreaRings";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateTradeAreaRings</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateTradeAreaRings";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Radii!, Units!, IdField!, RemoveOverlap!, DissolveOption!, InputMethod!, Expression! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features containing the center points for the rings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the output ring features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>The distances, in ascending size, used to create rings around the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		public object? Radii { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The linear unit to be used with the distance values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Units { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>A unique ID field in the ring center layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object? IdField { get; set; }

		/// <summary>
		/// <para>Remove Overlap</para>
		/// <para>Creates overlapping concentric rings or removes overlap.</para>
		/// <para>Checked—Thiessen polygons are used to remove overlap between output ring polygons.</para>
		/// <para>Unchecked—Output ring features are created with overlap. This is the default.</para>
		/// <para><see cref="RemoveOverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RemoveOverlap { get; set; } = "false";

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>Specifies whether overlapping or nonoverlapping service areas for a single location will be used when multiple distances are specified.</para>
		/// <para>Overlap—Each polygon will include the area reachable from the facility up to the distance value. This is the default.</para>
		/// <para>Split—Each polygon will include only the area between consecutive distance values.</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DissolveOption { get; set; } = "OVERLAP";

		/// <summary>
		/// <para>Input Method</para>
		/// <para>Specifies the type of value that is to be used for each drive time.</para>
		/// <para>Values—Uses a constant value (all trade areas will be the same size). This is the default.</para>
		/// <para>Expression—The values from a field or an expression (trade areas can be a different size).</para>
		/// <para><see cref="InputMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InputMethod { get; set; } = "VALUES";

		/// <summary>
		/// <para>Distance Expression</para>
		/// <para>A fields-based expression to calculate the radii.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTradeAreaRings SetEnviroment(object? geographicTransformations = null , object? workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Remove Overlap</para>
		/// </summary>
		public enum RemoveOverlapEnum 
		{
			/// <summary>
			/// <para>Checked—Thiessen polygons are used to remove overlap between output ring polygons.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_OVERLAP")]
			REMOVE_OVERLAP,

			/// <summary>
			/// <para>Unchecked—Output ring features are created with overlap. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_OVERLAP")]
			KEEP_OVERLAP,

		}

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>Overlap—Each polygon will include the area reachable from the facility up to the distance value. This is the default.</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Split—Each polygon will include only the area between consecutive distance values.</para>
			/// </summary>
			[GPValue("SPLIT")]
			[Description("Split")]
			Split,

		}

		/// <summary>
		/// <para>Input Method</para>
		/// </summary>
		public enum InputMethodEnum 
		{
			/// <summary>
			/// <para>Values—Uses a constant value (all trade areas will be the same size). This is the default.</para>
			/// </summary>
			[GPValue("VALUES")]
			[Description("Values")]
			Values,

			/// <summary>
			/// <para>Expression—The values from a field or an expression (trade areas can be a different size).</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("Expression")]
			Expression,

		}

#endregion
	}
}
