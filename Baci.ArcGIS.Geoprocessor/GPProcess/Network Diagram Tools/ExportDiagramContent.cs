using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Export Diagram Content</para>
	/// <para>Exports diagram content in a simple format (JSON) that reflects basic connectivity. Additional optional information such as diagram properties, diagram feature geometry, network elements attributes, and aggregated elements can also be exported.</para>
	/// </summary>
	public class ExportDiagramContent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The utility network or trace network layer, utility network or trace network data element, or network diagram layer related to the network diagram to export.</para>
		/// </param>
		/// <param name="NetworkDiagramName">
		/// <para>Network Diagram Name</para>
		/// <para>The name of the network diagram to export.</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
		/// <para>The output .json file that will be created with the exported diagram content.</para>
		/// </param>
		public ExportDiagramContent(object InUtilityNetwork, object NetworkDiagramName, object OutFile)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkDiagramName = NetworkDiagramName;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Diagram Content</para>
		/// </summary>
		public override string DisplayName => "Export Diagram Content";

		/// <summary>
		/// <para>Tool Name : ExportDiagramContent</para>
		/// </summary>
		public override string ToolName => "ExportDiagramContent";

		/// <summary>
		/// <para>Tool Excute Name : nd.ExportDiagramContent</para>
		/// </summary>
		public override string ExcuteName => "nd.ExportDiagramContent";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, NetworkDiagramName, OutFile, IncludeDiagramProperties, IncludeGeometries, IncludeAttributes, IncludeAggregations, UseDomains };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The utility network or trace network layer, utility network or trace network data element, or network diagram layer related to the network diagram to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// <para>The name of the network diagram to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkDiagramName { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output .json file that will be created with the exported diagram content.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Include diagram properties</para>
		/// <para>Specifies whether the diagram properties will be exported.</para>
		/// <para>Checked—The diagram properties (statistics, creation and update dates, and so on) will be exported.</para>
		/// <para>Unchecked—The diagram properties will not be exported. This is the default.</para>
		/// <para><see cref="IncludeDiagramPropertiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeDiagramProperties { get; set; } = "false";

		/// <summary>
		/// <para>Include geometries</para>
		/// <para>Specifies whether the geometry of the diagram features will be exported.</para>
		/// <para>Checked—Each diagram feature will be exported with its geometry.</para>
		/// <para>Unchecked—Each diagram feature will be exported without its geometry. This is the default.</para>
		/// <para><see cref="IncludeGeometriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGeometries { get; set; } = "false";

		/// <summary>
		/// <para>Include attributes</para>
		/// <para>Specifies whether the attributes of the associated network elements will be exported.</para>
		/// <para>Checked—The associated network element attributes will be exported.</para>
		/// <para>Unchecked—The associated network element attributes will not be exported. This is the default.</para>
		/// <para><see cref="IncludeAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeAttributes { get; set; } = "false";

		/// <summary>
		/// <para>Include aggregations</para>
		/// <para>Specifies whether each diagram feature will be exported with a list of network elements it aggregates.</para>
		/// <para>Checked—Each diagram feature will be exported with a list of network elements it aggregates with their asset group and asset type values.</para>
		/// <para>Unchecked—The diagram feature aggregations will not be exported. This is the default.</para>
		/// <para><see cref="IncludeAggregationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeAggregations { get; set; } = "false";

		/// <summary>
		/// <para>Use domain and subtype descriptions</para>
		/// <para>Specifies how coded domain and subtype values will be exported. This parameter is enabled when the Include attributes or Include aggregations parameter is checked.</para>
		/// <para>Checked—Coded domain and subtype values will be exported using their string descriptions rather than raw values.</para>
		/// <para>Unchecked—Coded domain and subtype values will be exported as raw values. This is the default.</para>
		/// <para><see cref="UseDomainsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseDomains { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Include diagram properties</para>
		/// </summary>
		public enum IncludeDiagramPropertiesEnum 
		{
			/// <summary>
			/// <para>Checked—The diagram properties (statistics, creation and update dates, and so on) will be exported.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_DIAGRAM_PROPERTIES")]
			INCLUDE_DIAGRAM_PROPERTIES,

			/// <summary>
			/// <para>Unchecked—The diagram properties will not be exported. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_DIAGRAM_PROPERTIES")]
			EXCLUDE_DIAGRAM_PROPERTIES,

		}

		/// <summary>
		/// <para>Include geometries</para>
		/// </summary>
		public enum IncludeGeometriesEnum 
		{
			/// <summary>
			/// <para>Checked—Each diagram feature will be exported with its geometry.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRIES")]
			INCLUDE_GEOMETRIES,

			/// <summary>
			/// <para>Unchecked—Each diagram feature will be exported without its geometry. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_GEOMETRIES")]
			EXCLUDE_GEOMETRIES,

		}

		/// <summary>
		/// <para>Include attributes</para>
		/// </summary>
		public enum IncludeAttributesEnum 
		{
			/// <summary>
			/// <para>Checked—The associated network element attributes will be exported.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_ATTRIBUTES")]
			INCLUDE_ATTRIBUTES,

			/// <summary>
			/// <para>Unchecked—The associated network element attributes will not be exported. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_ATTRIBUTES")]
			EXCLUDE_ATTRIBUTES,

		}

		/// <summary>
		/// <para>Include aggregations</para>
		/// </summary>
		public enum IncludeAggregationsEnum 
		{
			/// <summary>
			/// <para>Checked—Each diagram feature will be exported with a list of network elements it aggregates with their asset group and asset type values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_AGGREGATIONS")]
			INCLUDE_AGGREGATIONS,

			/// <summary>
			/// <para>Unchecked—The diagram feature aggregations will not be exported. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_AGGREGATIONS")]
			EXCLUDE_AGGREGATIONS,

		}

		/// <summary>
		/// <para>Use domain and subtype descriptions</para>
		/// </summary>
		public enum UseDomainsEnum 
		{
			/// <summary>
			/// <para>Checked—Coded domain and subtype values will be exported using their string descriptions rather than raw values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CODED_VALUE_NAMES")]
			USE_CODED_VALUE_NAMES,

			/// <summary>
			/// <para>Unchecked—Coded domain and subtype values will be exported as raw values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_USE_CODED_VALUE_NAMES")]
			DONT_USE_CODED_VALUE_NAMES,

		}

#endregion
	}
}
