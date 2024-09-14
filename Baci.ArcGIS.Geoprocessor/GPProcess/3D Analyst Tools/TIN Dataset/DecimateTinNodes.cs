using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Decimate TIN Nodes</para>
	/// <para>抽稀 TIN 结点</para>
	/// <para>使用源 TIN 的结点子集创建不规则三角网 (TIN) 数据集。</para>
	/// </summary>
	public class DecimateTinNodes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Decimation Method</para>
		/// <para>指定用于从输入 TIN 选择结点子集的细化方法。</para>
		/// <para>Z 容差—创建 TIN，该 TIN 维持 Z 容差参数中所指定的垂直精度。这是默认设置。</para>
		/// <para>计数—创建未超过最大节点数参数所指定的节点限值的 TIN。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public DecimateTinNodes(object InTin, object OutTin, object Method)
		{
			this.InTin = InTin;
			this.OutTin = OutTin;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : 抽稀 TIN 结点</para>
		/// </summary>
		public override string DisplayName() => "抽稀 TIN 结点";

		/// <summary>
		/// <para>Tool Name : DecimateTinNodes</para>
		/// </summary>
		public override string ToolName() => "DecimateTinNodes";

		/// <summary>
		/// <para>Tool Excute Name : 3d.DecimateTinNodes</para>
		/// </summary>
		public override string ExcuteName() => "3d.DecimateTinNodes";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutTin, Method, CopyBreaklines!, ZToleranceValue!, MaxNodeValue! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Decimation Method</para>
		/// <para>指定用于从输入 TIN 选择结点子集的细化方法。</para>
		/// <para>Z 容差—创建 TIN，该 TIN 维持 Z 容差参数中所指定的垂直精度。这是默认设置。</para>
		/// <para>计数—创建未超过最大节点数参数所指定的节点限值的 TIN。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "Z_TOLERANCE";

		/// <summary>
		/// <para>Copy Breaklines</para>
		/// <para>指示是否将输入 TIN 的隔断线复制到输出。</para>
		/// <para>取消选中 - 不会复制隔断线。这是默认设置。</para>
		/// <para>选中 - 将复制隔断线。</para>
		/// <para><see cref="CopyBreaklinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CopyBreaklines { get; set; } = "false";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>输出 TIN 中允许的源 TIN 的 Z 值最大偏差，默认为小于 Z 范围的十分之一或数值 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZToleranceValue { get; set; }

		/// <summary>
		/// <para>Maximum Number of Nodes</para>
		/// <para>可存储在输出 TIN 中的最大节点数，默认为源 TIN 中的节点总数减 1。使用 Z 容差方法时，如果 Z 容差值导致生成的 TIN 超出最大节点数，则工具将停止处理。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxNodeValue { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DecimateTinNodes SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? tinSaveVersion = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Decimation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Z 容差—创建 TIN，该 TIN 维持 Z 容差参数中所指定的垂直精度。这是默认设置。</para>
			/// </summary>
			[GPValue("Z_TOLERANCE")]
			[Description("Z 容差")]
			Z_Tolerance,

			/// <summary>
			/// <para>计数—创建未超过最大节点数参数所指定的节点限值的 TIN。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("计数")]
			Count,

		}

		/// <summary>
		/// <para>Copy Breaklines</para>
		/// </summary>
		public enum CopyBreaklinesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BREAKLINES")]
			BREAKLINES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_BREAKLINES")]
			NO_BREAKLINES,

		}

#endregion
	}
}
