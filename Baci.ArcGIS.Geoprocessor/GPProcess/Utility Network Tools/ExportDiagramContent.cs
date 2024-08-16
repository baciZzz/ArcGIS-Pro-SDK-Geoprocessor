using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Export Diagram Content</para>
	/// <para>Export a diagram content to a file</para>
	/// </summary>
	[Obsolete()]
	public class ExportDiagramContent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network or Network Diagram Layer</para>
		/// </param>
		/// <param name="NetworkDiagramName">
		/// <para>Network Diagram Name</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
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
		/// <para>Tool Excute Name : un.ExportDiagramContent</para>
		/// </summary>
		public override string ExcuteName => "un.ExportDiagramContent";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

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
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkDiagramName { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Include diagram properties</para>
		/// <para><see cref="IncludeDiagramPropertiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeDiagramProperties { get; set; } = "false";

		/// <summary>
		/// <para>Include geometries</para>
		/// <para><see cref="IncludeGeometriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGeometries { get; set; } = "false";

		/// <summary>
		/// <para>Include attributes</para>
		/// <para><see cref="IncludeAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeAttributes { get; set; } = "false";

		/// <summary>
		/// <para>Include aggregations</para>
		/// <para><see cref="IncludeAggregationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeAggregations { get; set; } = "false";

		/// <summary>
		/// <para>Use domain and subtype descriptions</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_DIAGRAM_PROPERTIES")]
			INCLUDE_DIAGRAM_PROPERTIES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_GEOMETRIES")]
			INCLUDE_GEOMETRIES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_ATTRIBUTES")]
			INCLUDE_ATTRIBUTES,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_AGGREGATIONS")]
			INCLUDE_AGGREGATIONS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CODED_VALUE_NAMES")]
			USE_CODED_VALUE_NAMES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_USE_CODED_VALUE_NAMES")]
			DONT_USE_CODED_VALUE_NAMES,

		}

#endregion
	}
}
