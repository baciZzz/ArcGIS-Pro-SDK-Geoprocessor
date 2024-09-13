using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Set Flow Direction</para>
	/// <para>Set Flow Direction</para>
	/// <para>Sets the flow direction of line features in a version 1 trace network.</para>
	/// </summary>
	public class SetFlowDirection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network that contains the line feature class on which the flow direction will be set.</para>
		/// <para>This parameter requires a Trace Network Version 1 as input.</para>
		/// </param>
		/// <param name="InEdges">
		/// <para>Feature Layers</para>
		/// <para>The polyline features that participate in the input trace network.</para>
		/// </param>
		/// <param name="FlowDirection">
		/// <para>Flow Direction</para>
		/// <para>Specifies the flow direction of the edges.</para>
		/// <para>With digitized direction—Flow direction will be along the digitized direction of the edges.</para>
		/// <para>Against digitized direction—Flow direction will be against the digitized direction of the edges.</para>
		/// <para>Indeterminate direction—Flow direction will be indeterminate.</para>
		/// <para><see cref="FlowDirectionEnum"/></para>
		/// </param>
		public SetFlowDirection(object InputTraceNetwork, object InEdges, object FlowDirection)
		{
			this.InputTraceNetwork = InputTraceNetwork;
			this.InEdges = InEdges;
			this.FlowDirection = FlowDirection;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Flow Direction</para>
		/// </summary>
		public override string DisplayName() => "Set Flow Direction";

		/// <summary>
		/// <para>Tool Name : SetFlowDirection</para>
		/// </summary>
		public override string ToolName() => "SetFlowDirection";

		/// <summary>
		/// <para>Tool Excute Name : tn.SetFlowDirection</para>
		/// </summary>
		public override string ExcuteName() => "tn.SetFlowDirection";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTraceNetwork, InEdges, FlowDirection, UpdatedTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network that contains the line feature class on which the flow direction will be set.</para>
		/// <para>This parameter requires a Trace Network Version 1 as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputTraceNetwork { get; set; }

		/// <summary>
		/// <para>Feature Layers</para>
		/// <para>The polyline features that participate in the input trace network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InEdges { get; set; }

		/// <summary>
		/// <para>Flow Direction</para>
		/// <para>Specifies the flow direction of the edges.</para>
		/// <para>With digitized direction—Flow direction will be along the digitized direction of the edges.</para>
		/// <para>Against digitized direction—Flow direction will be against the digitized direction of the edges.</para>
		/// <para>Indeterminate direction—Flow direction will be indeterminate.</para>
		/// <para><see cref="FlowDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FlowDirection { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? UpdatedTraceNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Flow Direction</para>
		/// </summary>
		public enum FlowDirectionEnum 
		{
			/// <summary>
			/// <para>With digitized direction—Flow direction will be along the digitized direction of the edges.</para>
			/// </summary>
			[GPValue("WITH_DIGITIZED_DIRECTION")]
			[Description("With digitized direction")]
			With_digitized_direction,

			/// <summary>
			/// <para>Against digitized direction—Flow direction will be against the digitized direction of the edges.</para>
			/// </summary>
			[GPValue("AGAINST_DIGITIZED_DIRECTION")]
			[Description("Against digitized direction")]
			Against_digitized_direction,

			/// <summary>
			/// <para>Indeterminate direction—Flow direction will be indeterminate.</para>
			/// </summary>
			[GPValue("INDETERMINATE")]
			[Description("Indeterminate direction")]
			Indeterminate_direction,

		}

#endregion
	}
}
