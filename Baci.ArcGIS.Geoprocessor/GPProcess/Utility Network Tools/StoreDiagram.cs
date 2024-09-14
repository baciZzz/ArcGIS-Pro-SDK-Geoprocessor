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
	/// <para>Store Diagram</para>
	/// <para>Store Diagram</para>
	/// <para>Store a temporary diagram and alter its location and its access rights</para>
	/// </summary>
	[Obsolete()]
	public class StoreDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDiagramLayer">
		/// <para>Input Network Diagram Layer</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Network Diagram Name</para>
		/// </param>
		public StoreDiagram(object InNetworkDiagramLayer, object OutName)
		{
			this.InNetworkDiagramLayer = InNetworkDiagramLayer;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Store Diagram</para>
		/// </summary>
		public override string DisplayName() => "Store Diagram";

		/// <summary>
		/// <para>Tool Name : StoreDiagram</para>
		/// </summary>
		public override string ToolName() => "StoreDiagram";

		/// <summary>
		/// <para>Tool Excute Name : un.StoreDiagram</para>
		/// </summary>
		public override string ExcuteName() => "un.StoreDiagram";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkDiagramLayer, OutName, AccessRightType, Tags };

		/// <summary>
		/// <para>Input Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object InNetworkDiagramLayer { get; set; }

		/// <summary>
		/// <para>Network Diagram Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDiagramLayer()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// <para><see cref="AccessRightTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AccessRightType { get; set; } = "PUBLIC";

		/// <summary>
		/// <para>Tags (optional)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Network Diagram Access Rights</para>
		/// </summary>
		public enum AccessRightTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PUBLIC")]
			[Description("PUBLIC")]
			PUBLIC,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PROTECTED")]
			[Description("PROTECTED")]
			PROTECTED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PRIVATE")]
			[Description("PRIVATE")]
			PRIVATE,

		}

#endregion
	}
}
