using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Modify Event Behavior Rules</para>
	/// <para>修改事件行为规则</para>
	/// <para>修改已注册事件图层或要素类的事件行为规则。</para>
	/// </summary>
	public class ModifyEventBehaviorRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Event Feature Class</para>
		/// <para>事件要素类。</para>
		/// </param>
		public ModifyEventBehaviorRules(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改事件行为规则</para>
		/// </summary>
		public override string DisplayName() => "修改事件行为规则";

		/// <summary>
		/// <para>Tool Name : ModifyEventBehaviorRules</para>
		/// </summary>
		public override string ToolName() => "ModifyEventBehaviorRules";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyEventBehaviorRules</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyEventBehaviorRules";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, CalibrateRule!, RetireRule!, ExtendRule!, ReassignRule!, RealignRule!, OutFeatureClass!, ReverseRule!, CartoRealignRule! };

		/// <summary>
		/// <para>Event Feature Class</para>
		/// <para>事件要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// <para>指定将为校准活动定义的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para><see cref="CalibrateRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrateRule { get; set; }

		/// <summary>
		/// <para>Retire Rule</para>
		/// <para>指定将为停用活动定义的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para><see cref="RetireRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RetireRule { get; set; }

		/// <summary>
		/// <para>Extend Rule</para>
		/// <para>指定将为扩展活动定义的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
		/// <para><see cref="ExtendRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExtendRule { get; set; }

		/// <summary>
		/// <para>Reassign Rule</para>
		/// <para>指定将为重新分配活动定义的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para>捕捉—通过将事件捕捉到并发路径，保留事件的地理位置；测量值可能会改变。</para>
		/// <para><see cref="ReassignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReassignRule { get; set; }

		/// <summary>
		/// <para>Realign Rule</para>
		/// <para>指定将为重新对活动定义的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para>捕捉—通过将事件捕捉到并发路径，保留事件的地理位置；测量值可能会改变。</para>
		/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
		/// <para><see cref="RealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RealignRule { get; set; }

		/// <summary>
		/// <para>Updated Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Reverse Rule</para>
		/// <para>指定将为反向活动定义的事件行为规则。</para>
		/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
		/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
		/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
		/// <para><see cref="ReverseRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReverseRule { get; set; }

		/// <summary>
		/// <para>Carto Realign Rule</para>
		/// <para>指定将为制图重新对齐活动定义的事件行为规则。</para>
		/// <para>支持路径测量—将保留事件的测量值，或与路径测量值更改成比例地更改测量值。 这是默认设置。</para>
		/// <para>支持引用位置—将保留事件的引用位置。</para>
		/// <para><see cref="CartoRealignRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CartoRealignRule { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyEventBehaviorRules SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibrate Rule</para>
		/// </summary>
		public enum CalibrateRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

		}

		/// <summary>
		/// <para>Retire Rule</para>
		/// </summary>
		public enum RetireRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

		}

		/// <summary>
		/// <para>Extend Rule</para>
		/// </summary>
		public enum ExtendRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

			/// <summary>
			/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
			/// </summary>
			[GPValue("COVER")]
			[Description("覆盖")]
			Cover,

		}

		/// <summary>
		/// <para>Reassign Rule</para>
		/// </summary>
		public enum ReassignRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

			/// <summary>
			/// <para>捕捉—通过将事件捕捉到并发路径，保留事件的地理位置；测量值可能会改变。</para>
			/// </summary>
			[GPValue("SNAP")]
			[Description("捕捉")]
			Snap,

		}

		/// <summary>
		/// <para>Realign Rule</para>
		/// </summary>
		public enum RealignRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

			/// <summary>
			/// <para>捕捉—通过将事件捕捉到并发路径，保留事件的地理位置；测量值可能会改变。</para>
			/// </summary>
			[GPValue("SNAP")]
			[Description("捕捉")]
			Snap,

			/// <summary>
			/// <para>覆盖—线事件的几何位置和测量值将被修改以包括新的或新修改的部分。</para>
			/// </summary>
			[GPValue("COVER")]
			[Description("覆盖")]
			Cover,

		}

		/// <summary>
		/// <para>Reverse Rule</para>
		/// </summary>
		public enum ReverseRuleEnum 
		{
			/// <summary>
			/// <para>固定不动—事件的地理位置将被保留；测量值可能会改变。 这是默认设置。</para>
			/// </summary>
			[GPValue("STAY_PUT")]
			[Description("固定不动")]
			Stay_put,

			/// <summary>
			/// <para>停用—测量值和地理位置都将被保留；该事件将被停用。</para>
			/// </summary>
			[GPValue("RETIRE")]
			[Description("停用")]
			Retire,

			/// <summary>
			/// <para>移动—事件测量值将被保留，地理位置可能发生变化。</para>
			/// </summary>
			[GPValue("MOVE")]
			[Description("移动")]
			Move,

		}

		/// <summary>
		/// <para>Carto Realign Rule</para>
		/// </summary>
		public enum CartoRealignRuleEnum 
		{
			/// <summary>
			/// <para>支持路径测量—将保留事件的测量值，或与路径测量值更改成比例地更改测量值。 这是默认设置。</para>
			/// </summary>
			[GPValue("HONOR_ROUTE_MEASURE")]
			[Description("支持路径测量")]
			Honor_Route_Measure,

			/// <summary>
			/// <para>支持引用位置—将保留事件的引用位置。</para>
			/// </summary>
			[GPValue("HONOR_REFERENT_LOCATION")]
			[Description("支持引用位置")]
			Honor_Referent_Location,

		}

#endregion
	}
}
