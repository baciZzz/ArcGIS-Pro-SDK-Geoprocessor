using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Calculate Bridge Offsets</para>
	/// <para>Calculates the offsets necessary to properly display bridges at a given location.</para>
	/// </summary>
	public class CalculateBridgeOffsets : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBridgeFeatures">
		/// <para>Input Bridge Features</para>
		/// <para>The feature layer that contains bridge features for which symbol offsets will be updated. Symbolize the bridge features layer with proper bridge features and enable attribute-driven symbology on it.</para>
		/// </param>
		/// <param name="InOverpassingFeatures">
		/// <para>Overpassing Features</para>
		/// <para>The feature layer that contains the features overpassing the bridges.</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference Scale</para>
		/// <para>The scale at which symbols appear at their intended size.</para>
		/// </param>
		public CalculateBridgeOffsets(object InBridgeFeatures, object InOverpassingFeatures, object ReferenceScale)
		{
			this.InBridgeFeatures = InBridgeFeatures;
			this.InOverpassingFeatures = InOverpassingFeatures;
			this.ReferenceScale = ReferenceScale;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Bridge Offsets</para>
		/// </summary>
		public override string DisplayName => "Calculate Bridge Offsets";

		/// <summary>
		/// <para>Tool Name : CalculateBridgeOffsets</para>
		/// </summary>
		public override string ToolName => "CalculateBridgeOffsets";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CalculateBridgeOffsets</para>
		/// </summary>
		public override string ExcuteName => "topographic.CalculateBridgeOffsets";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InBridgeFeatures, InOverpassingFeatures, ReferenceScale, SearchDistance, Expand, Offset, MinLength, BridgeSubtype, OverpassingSubtype, UpdatedBridgeFeatures };

		/// <summary>
		/// <para>Input Bridge Features</para>
		/// <para>The feature layer that contains bridge features for which symbol offsets will be updated. Symbolize the bridge features layer with proper bridge features and enable attribute-driven symbology on it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Point", "Polyline")]
		public object InBridgeFeatures { get; set; }

		/// <summary>
		/// <para>Overpassing Features</para>
		/// <para>The feature layer that contains the features overpassing the bridges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPLayerDomain()]
		[GeometryType("Polyline")]
		public object InOverpassingFeatures { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>The scale at which symbols appear at their intended size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance, calculated in map units, by which this tool will buffer point bridge features when identifying the overpassing features. This parameter is only available for point bridges. The default is 0 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Expand to Markers</para>
		/// <para>Specifies whether marker layers on overpassing symbols will be included when analyzing widths.</para>
		/// <para>Checked—Marker layers on overpassing symbols will be included when analyzing widths.</para>
		/// <para>Unchecked—Marker layers on overpassing symbols will not be included. This is the default.</para>
		/// <para><see cref="ExpandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Expand { get; set; } = "false";

		/// <summary>
		/// <para>Additional Offset</para>
		/// <para>An offset added to the bridge width. The default is 0 points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Offset { get; set; } = "0 Points";

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>The minimum length of a line bridge. The default is 1.35 millimeters.</para>
		/// <para>If the length of the bridge is less than the minimum length, it will be expanded to minimum length.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinLength { get; set; } = "1.5 Millimeters";

		/// <summary>
		/// <para>Bridge Features Subtype</para>
		/// <para>The subtype of the feature class from the Input Bridge Features parameter that will be modified by this operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Subtypes (optional)")]
		public object BridgeSubtype { get; set; }

		/// <summary>
		/// <para>Overpassing Features Subtype</para>
		/// <para>The subtype of the feature class in the Overpassing Features parameter that will be used in this operation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Subtypes (optional)")]
		public object OverpassingSubtype { get; set; }

		/// <summary>
		/// <para>Updated Bridge Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object UpdatedBridgeFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Expand to Markers</para>
		/// </summary>
		public enum ExpandEnum 
		{
			/// <summary>
			/// <para>Checked—Marker layers on overpassing symbols will be included when analyzing widths.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPAND")]
			EXPAND,

			/// <summary>
			/// <para>Unchecked—Marker layers on overpassing symbols will not be included. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXPAND")]
			NO_EXPAND,

		}

#endregion
	}
}
