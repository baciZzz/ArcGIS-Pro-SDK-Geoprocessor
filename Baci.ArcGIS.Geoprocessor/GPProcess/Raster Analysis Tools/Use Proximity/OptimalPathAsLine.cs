using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Optimal Path As Line</para>
	/// <para>最佳路径为线</para>
	/// <para>将从源到目的地的最佳路径计算为线。</para>
	/// </summary>
	public class OptimalPathAsLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputdestinationrasterorfeatures">
		/// <para>Input Raster or Feature Destination Data</para>
		/// <para>用于标识确定通向最小成本源的最小积累成本路径时基于的位置的栅格或要素数据集。</para>
		/// <para>对于栅格，输入类型必须为整型，并且必须由具有有效值（零为有效值）的像元组成。并且必须为其余的像元指定 NoData。</para>
		/// </param>
		/// <param name="Inputdistanceaccumulationraster">
		/// <para>Input Distance Accumulation Raster</para>
		/// <para>距离累积栅格用于确定从源到目的地的最佳路径。</para>
		/// <para>距离累积栅格通常使用距离累积或距离分配工具进行创建。距离累积栅格中的每个像元表示表面上从每个像元到源像元集的最小累积成本距离。</para>
		/// </param>
		/// <param name="Inputbackdirectionraster">
		/// <para>Input Back Direction or Flow Direction Raster</para>
		/// <para>反向栅格包含以度为单位的计算方向。该方向用于标识沿最佳路径返回最小累积成本源同时避开障碍的下一个像元。</para>
		/// <para>值范围为 0 度到 360 度。值 0 将会留供源像元使用。正东(右侧)是 90 度，且值以顺时针方向增加(180 是南方、270 是西方、360 是北方)。</para>
		/// </param>
		/// <param name="Outputpolylinename">
		/// <para>Output Optimal Path as Feature</para>
		/// <para>包含最佳路径的输出要素服务的名称。</para>
		/// </param>
		public OptimalPathAsLine(object Inputdestinationrasterorfeatures, object Inputdistanceaccumulationraster, object Inputbackdirectionraster, object Outputpolylinename)
		{
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Inputdistanceaccumulationraster = Inputdistanceaccumulationraster;
			this.Inputbackdirectionraster = Inputbackdirectionraster;
			this.Outputpolylinename = Outputpolylinename;
		}

		/// <summary>
		/// <para>Tool Display Name : 最佳路径为线</para>
		/// </summary>
		public override string DisplayName() => "最佳路径为线";

		/// <summary>
		/// <para>Tool Name : OptimalPathAsLine</para>
		/// </summary>
		public override string ToolName() => "OptimalPathAsLine";

		/// <summary>
		/// <para>Tool Excute Name : ra.OptimalPathAsLine</para>
		/// </summary>
		public override string ExcuteName() => "ra.OptimalPathAsLine";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputdestinationrasterorfeatures, Inputdistanceaccumulationraster, Inputbackdirectionraster, Outputpolylinename, Destinationfield, Pathtype, Outputpolylinefeatures, Createnetworkpaths };

		/// <summary>
		/// <para>Input Raster or Feature Destination Data</para>
		/// <para>用于标识确定通向最小成本源的最小积累成本路径时基于的位置的栅格或要素数据集。</para>
		/// <para>对于栅格，输入类型必须为整型，并且必须由具有有效值（零为有效值）的像元组成。并且必须为其余的像元指定 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Distance Accumulation Raster</para>
		/// <para>距离累积栅格用于确定从源到目的地的最佳路径。</para>
		/// <para>距离累积栅格通常使用距离累积或距离分配工具进行创建。距离累积栅格中的每个像元表示表面上从每个像元到源像元集的最小累积成本距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdistanceaccumulationraster { get; set; }

		/// <summary>
		/// <para>Input Back Direction or Flow Direction Raster</para>
		/// <para>反向栅格包含以度为单位的计算方向。该方向用于标识沿最佳路径返回最小累积成本源同时避开障碍的下一个像元。</para>
		/// <para>值范围为 0 度到 360 度。值 0 将会留供源像元使用。正东(右侧)是 90 度，且值以顺时针方向增加(180 是南方、270 是西方、360 是北方)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputbackdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Optimal Path as Feature</para>
		/// <para>包含最佳路径的输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputpolylinename { get; set; }

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>用于获得目标位置的值的字段。</para>
		/// <para>此字段必须为整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Destinationfield { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>用于指定对输入目标数据上的值和区域在成本路径计算中的解释方式进行定义的关键字。</para>
		/// <para>每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的像元。这是默认设置。</para>
		/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
		/// <para>每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会分别处理输入目标数据中的每个像元，并确定每个像元的最小成本路径。</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Pathtype { get; set; } = "EACH_ZONE";

		/// <summary>
		/// <para>Output Polyline Feature</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object Outputpolylinefeatures { get; set; }

		/// <summary>
		/// <para>Create network paths</para>
		/// <para>指定是计算从目的地到源的完整路径（可能重叠），还是创建不重叠的网络路径。</para>
		/// <para>未选中 - 计算从目的地到源的完整路径，这些路径可以重叠。这是默认设置。</para>
		/// <para>选中 - 计算不重叠的网络路径。</para>
		/// <para><see cref="CreatenetworkpathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Createnetworkpaths { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OptimalPathAsLine SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathtypeEnum 
		{
			/// <summary>
			/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("最佳单一")]
			Best_single,

			/// <summary>
			/// <para>每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会分别处理输入目标数据中的每个像元，并确定每个像元的最小成本路径。</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("每个像元")]
			Each_cell,

			/// <summary>
			/// <para>每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的像元。这是默认设置。</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("每个区域")]
			Each_zone,

		}

		/// <summary>
		/// <para>Create network paths</para>
		/// </summary>
		public enum CreatenetworkpathsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NETWORK_PATHS")]
			NETWORK_PATHS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DESTINATIONS_TO_SOURCES")]
			DESTINATIONS_TO_SOURCES,

		}

#endregion
	}
}
