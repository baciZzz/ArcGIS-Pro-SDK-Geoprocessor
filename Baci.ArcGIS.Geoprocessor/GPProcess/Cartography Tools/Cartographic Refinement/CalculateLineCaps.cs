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
	/// <para>Calculate Line Caps</para>
	/// <para>Calculate Line Caps</para>
	/// <para>Modifies the cap type for stroke symbol layers in the line symbols of the input layer.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class CalculateLineCaps : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input feature layer containing line symbols. Stroke symbol layers must have the Cap Type property connected to a single attribute field with no expression applied. The values in this field are updated by this tool.</para>
		/// </param>
		public CalculateLineCaps(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Line Caps</para>
		/// </summary>
		public override string DisplayName() => "Calculate Line Caps";

		/// <summary>
		/// <para>Tool Name : CalculateLineCaps</para>
		/// </summary>
		public override string ToolName() => "CalculateLineCaps";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CalculateLineCaps</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CalculateLineCaps";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, CapType!, DangleOption!, OutRepresentations! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature layer containing line symbols. Stroke symbol layers must have the Cap Type property connected to a single attribute field with no expression applied. The values in this field are updated by this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Cap Type</para>
		/// <para>Specifies how the ends of stroke symbol layers are drawn. The default cap type of strokes is round; the symbol is terminated with a semicircle of radius equal to stroke width centered at the line endpoint.</para>
		/// <para>Butt cap type—The stroke symbol ends exactly where the line geometry ends. This is the default.</para>
		/// <para>Square cap type—The stroke symbol ends with closed, square caps that extend past the endpoint of the line by half of the symbol width.</para>
		/// <para><see cref="CapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CapType { get; set; } = "BUTT";

		/// <summary>
		/// <para>Dangle Option</para>
		/// <para>Specifies how line caps are calculated for adjoining line features that share an endpoint but are drawn with different symbology.</para>
		/// <para>Cased line dangle—The cap style is modified for dangling lines (those not connected at their endpoints to another line) and also for the lines where a cased-line symbol is joined at the endpoint of a single-stroke layer line symbol. This is the default.</para>
		/// <para>True dangle—The cap style is modified only for endpoints that are not connected to another feature.</para>
		/// <para><see cref="DangleOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DangleOption { get; set; } = "CASED_LINE_DANGLE";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? OutRepresentations { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Cap Type</para>
		/// </summary>
		public enum CapTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BUTT")]
			[Description("Butt  cap type")]
			Butt__cap_type,

			/// <summary>
			/// <para>Square cap type—The stroke symbol ends with closed, square caps that extend past the endpoint of the line by half of the symbol width.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square cap type")]
			Square_cap_type,

		}

		/// <summary>
		/// <para>Dangle Option</para>
		/// </summary>
		public enum DangleOptionEnum 
		{
			/// <summary>
			/// <para>Cased line dangle—The cap style is modified for dangling lines (those not connected at their endpoints to another line) and also for the lines where a cased-line symbol is joined at the endpoint of a single-stroke layer line symbol. This is the default.</para>
			/// </summary>
			[GPValue("CASED_LINE_DANGLE")]
			[Description("Cased line dangle")]
			Cased_line_dangle,

			/// <summary>
			/// <para>True dangle—The cap style is modified only for endpoints that are not connected to another feature.</para>
			/// </summary>
			[GPValue("TRUE_DANGLE")]
			[Description("True dangle")]
			True_dangle,

		}

#endregion
	}
}
