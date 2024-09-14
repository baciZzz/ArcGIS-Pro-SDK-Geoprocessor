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
	/// <para>设置流向</para>
	/// <para>设置版本 1 追踪网络中线要素的流向。</para>
	/// </summary>
	public class SetFlowDirection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>包含要为其设置流向的线要素类的追踪网络。</para>
		/// <para>此参数需要一个追踪网络版本 1 作为输入。</para>
		/// </param>
		/// <param name="InEdges">
		/// <para>Feature Layers</para>
		/// <para>参与输入追踪网络的折线要素。</para>
		/// </param>
		/// <param name="FlowDirection">
		/// <para>Flow Direction</para>
		/// <para>指定边的流向。</para>
		/// <para>沿数字化方向—流向将沿着边的数字化方向。</para>
		/// <para>沿数字化方向的反方向—流向将沿着边的数字化方向的反方向。</para>
		/// <para>不确定的方向—流向将不确定。</para>
		/// <para><see cref="FlowDirectionEnum"/></para>
		/// </param>
		public SetFlowDirection(object InputTraceNetwork, object InEdges, object FlowDirection)
		{
			this.InputTraceNetwork = InputTraceNetwork;
			this.InEdges = InEdges;
			this.FlowDirection = FlowDirection;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置流向</para>
		/// </summary>
		public override string DisplayName() => "设置流向";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTraceNetwork, InEdges, FlowDirection, UpdatedTraceNetwork };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>包含要为其设置流向的线要素类的追踪网络。</para>
		/// <para>此参数需要一个追踪网络版本 1 作为输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputTraceNetwork { get; set; }

		/// <summary>
		/// <para>Feature Layers</para>
		/// <para>参与输入追踪网络的折线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InEdges { get; set; }

		/// <summary>
		/// <para>Flow Direction</para>
		/// <para>指定边的流向。</para>
		/// <para>沿数字化方向—流向将沿着边的数字化方向。</para>
		/// <para>沿数字化方向的反方向—流向将沿着边的数字化方向的反方向。</para>
		/// <para>不确定的方向—流向将不确定。</para>
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
		public object UpdatedTraceNetwork { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Flow Direction</para>
		/// </summary>
		public enum FlowDirectionEnum 
		{
			/// <summary>
			/// <para>沿数字化方向—流向将沿着边的数字化方向。</para>
			/// </summary>
			[GPValue("WITH_DIGITIZED_DIRECTION")]
			[Description("沿数字化方向")]
			With_digitized_direction,

			/// <summary>
			/// <para>沿数字化方向的反方向—流向将沿着边的数字化方向的反方向。</para>
			/// </summary>
			[GPValue("AGAINST_DIGITIZED_DIRECTION")]
			[Description("沿数字化方向的反方向")]
			Against_digitized_direction,

			/// <summary>
			/// <para>不确定的方向—流向将不确定。</para>
			/// </summary>
			[GPValue("INDETERMINATE")]
			[Description("不确定的方向")]
			Indeterminate_direction,

		}

#endregion
	}
}
