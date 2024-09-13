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
	/// <para>Extend Diagram</para>
	/// <para>Extend Diagram</para>
	/// <para>Extend a Network Diagram</para>
	/// </summary>
	[Obsolete()]
	public class ExtendDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// </param>
		public ExtendDiagram(object InNetworkDiagramLayer)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Extend Diagram</para>
		/// </summary>
		public override string DisplayName() => "Extend Diagram";

		/// <summary>
		/// <para>Tool Name : ExtendDiagram</para>
		/// </summary>
		public override string ToolName() => "ExtendDiagram";

		/// <summary>
		/// <para>Tool Excute Name : un.ExtendDiagram</para>
		/// </summary>
		public override string ExcuteName() => "un.ExtendDiagram";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, IgnoreTraversability!, OutNetworkDiagramLayer!, ExtensionType! };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Ignore traversability</para>
		/// <para><see cref="IgnoreTraversabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreTraversability { get; set; } = "true";

		/// <summary>
		/// <para>Output Network Diagram</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDiagramLayer()]
		public object? OutNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Extension Type</para>
		/// <para><see cref="ExtensionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtensionType { get; set; } = "BY_CONNECTIVITY";

		#region InnerClass

		/// <summary>
		/// <para>Ignore traversability</para>
		/// </summary>
		public enum IgnoreTraversabilityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_TRAVERSABILITY")]
			IGNORE_TRAVERSABILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HONOR_TRAVERSABILITY")]
			HONOR_TRAVERSABILITY,

		}

		/// <summary>
		/// <para>Extension Type</para>
		/// </summary>
		public enum ExtensionTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_CONNECTIVITY")]
			[Description("BY_CONNECTIVITY")]
			BY_CONNECTIVITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_TRAVERSABILITY")]
			[Description("BY_TRAVERSABILITY")]
			BY_TRAVERSABILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_ATTACHMENT")]
			[Description("BY_ATTACHMENT")]
			BY_ATTACHMENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BY_CONTAINMENT")]
			[Description("BY_CONTAINMENT")]
			BY_CONTAINMENT,

		}

#endregion
	}
}
