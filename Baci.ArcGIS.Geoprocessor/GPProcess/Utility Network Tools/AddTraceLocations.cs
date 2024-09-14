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
	/// <para>Add Trace Locations</para>
	/// <para>添加追踪位置</para>
	/// <para>用于创建要用作追踪工具的起点和障碍输入的要素类。</para>
	/// </summary>
	public class AddTraceLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将添加追踪位置的输入公共设施网络。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含追踪位置的输出要素类。如果指定新要素类名称，则将创建新的输出要素类。</para>
		/// <para>要使用之前由此工具创建的现有要素类，并追加或覆盖现有位置，请指定现有要素类的名称。</para>
		/// </param>
		public AddTraceLocations(object InUtilityNetwork, object OutFeatureClass)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加追踪位置</para>
		/// </summary>
		public override string DisplayName() => "添加追踪位置";

		/// <summary>
		/// <para>Tool Name : AddTraceLocations</para>
		/// </summary>
		public override string ToolName() => "AddTraceLocations";

		/// <summary>
		/// <para>Tool Excute Name : un.AddTraceLocations</para>
		/// </summary>
		public override string ExcuteName() => "un.AddTraceLocations";

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
		public override string[] ValidEnvironments() => new string[] { "outputZFlag", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, OutFeatureClass, LoadSelectedFeatures, ClearTraceLocations, TraceLocations, FilterBarrier };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将添加追踪位置的输入公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含追踪位置的输出要素类。如果指定新要素类名称，则将创建新的输出要素类。</para>
		/// <para>要使用之前由此工具创建的现有要素类，并追加或覆盖现有位置，请指定现有要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Load Selected Features</para>
		/// <para>指定是否将活动地图中的选定要素作为追踪位置加载。</para>
		/// <para>选中 - 将根据地图中选择的内容加载追踪位置。</para>
		/// <para>未选中 - 不会根据地图中选择的内容加载追踪位置。这是默认设置。但是，可以使用追踪位置参数加载追踪位置。</para>
		/// <para><see cref="LoadSelectedFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object LoadSelectedFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Clear Trace Locations</para>
		/// <para>指定是否清除输出要素类中的追踪位置。</para>
		/// <para>选中 - 将清除现有追踪位置。</para>
		/// <para>未选中 - 现有位置将不会清除，而会保留。这是默认设置。</para>
		/// <para><see cref="ClearTraceLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClearTraceLocations { get; set; } = "false";

		/// <summary>
		/// <para>Trace Locations</para>
		/// <para>将添加到输出要素类的追踪位置。如果在活动地图中未使用加载所选要素参数，则可以使用此参数，通过在值表中提供所需值来指定要作为追踪位置添加的公共设施网络要素。</para>
		/// <para>追踪位置属性如下所示：</para>
		/// <para>图层名称 - 参与公共设施网络（包含要添加的起点或障碍位置）的图层。如果存在活动地图，则仅允许地图中的图层。</para>
		/// <para>全局 ID - 要添加位置的图层要素的全局 ID。</para>
		/// <para>终端 ID - 要添加位置的图层要素的终端 ID。</para>
		/// <para>延伸百分比 - 图层要素的延伸百分比值。对于线要素，默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object TraceLocations { get; set; }

		/// <summary>
		/// <para>Filter Barrier</para>
		/// <para>指定追踪位置的障碍的行为。</para>
		/// <para>选中 - 障碍的行为类似于过滤器障碍。这对于基于子网的追踪非常有用，在此类追踪中，障碍允许先评估子网，然后应用于网络要素的第二次遍历，本质上行为与过滤器障碍类似。</para>
		/// <para>未选中 - 障碍的行为类似于可遍历性障碍。可遍历性障碍用于定义子网范围，并将在第一次穿越时进行评估。这是默认设置。</para>
		/// <para>此参数要求 ArcGIS Enterprise 10.9 或更高版本。</para>
		/// <para><see cref="FilterBarrierEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FilterBarrier { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddTraceLocations SetEnviroment(object outputZFlag = null, object workspace = null)
		{
			base.SetEnv(outputZFlag: outputZFlag, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Load Selected Features</para>
		/// </summary>
		public enum LoadSelectedFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LOAD_SELECTED_FEATURES")]
			LOAD_SELECTED_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_LOAD_SELECTED_FEATURES")]
			DO_NOT_LOAD_SELECTED_FEATURES,

		}

		/// <summary>
		/// <para>Clear Trace Locations</para>
		/// </summary>
		public enum ClearTraceLocationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_LOCATIONS")]
			CLEAR_LOCATIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_LOCATIONS")]
			KEEP_LOCATIONS,

		}

		/// <summary>
		/// <para>Filter Barrier</para>
		/// </summary>
		public enum FilterBarrierEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BARRIER")]
			FILTER_BARRIER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("TRAVERSABILITY_BARRIER")]
			TRAVERSABILITY_BARRIER,

		}

#endregion
	}
}
