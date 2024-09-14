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
	/// <para>Remove LRS Entity</para>
	/// <para>移除 LRS 实体</para>
	/// <para>从输入地理数据库工作空间中移除线性参考系统 (LRS) 实体。</para>
	/// </summary>
	public class RemoveLRSEntity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>LRS Workspace</para>
		/// <para>包含要移除的 LRS 实体的输入地理数据库工作空间。</para>
		/// </param>
		/// <param name="LrsEntityType">
		/// <para>LRS Entity Type</para>
		/// <para>指定将从输入地理数据库工作空间中移除的 LRS 实体的类型。</para>
		/// <para>LRS—将移除 LRS 及其从属 LRS 网络，以及注册到这些 LRS 网络的 LRS 事件和 LRS 交叉点。</para>
		/// <para>网络—将移除 LRS 网络以及注册到该 LRS 网络的 LRS 事件和 LRS 交叉点。</para>
		/// <para>事件—将移除 LRS 事件。</para>
		/// <para>交叉点—将移除 LRS 交叉点。</para>
		/// <para>公共设施网络要素类—将移除公共设施网络。</para>
		/// <para><see cref="LrsEntityTypeEnum"/></para>
		/// </param>
		/// <param name="LrsEntityName">
		/// <para>LRS Entity Name</para>
		/// <para>将从输入地理数据库工作空间中移除的 LRS 实体的名称。 LRS 实体的基础要素类和表不会被删除。</para>
		/// </param>
		public RemoveLRSEntity(object InWorkspace, object LrsEntityType, object LrsEntityName)
		{
			this.InWorkspace = InWorkspace;
			this.LrsEntityType = LrsEntityType;
			this.LrsEntityName = LrsEntityName;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除 LRS 实体</para>
		/// </summary>
		public override string DisplayName() => "移除 LRS 实体";

		/// <summary>
		/// <para>Tool Name : RemoveLRSEntity</para>
		/// </summary>
		public override string ToolName() => "RemoveLRSEntity";

		/// <summary>
		/// <para>Tool Excute Name : locref.RemoveLRSEntity</para>
		/// </summary>
		public override string ExcuteName() => "locref.RemoveLRSEntity";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, LrsEntityType, LrsEntityName, OutWorkspace! };

		/// <summary>
		/// <para>LRS Workspace</para>
		/// <para>包含要移除的 LRS 实体的输入地理数据库工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>LRS Entity Type</para>
		/// <para>指定将从输入地理数据库工作空间中移除的 LRS 实体的类型。</para>
		/// <para>LRS—将移除 LRS 及其从属 LRS 网络，以及注册到这些 LRS 网络的 LRS 事件和 LRS 交叉点。</para>
		/// <para>网络—将移除 LRS 网络以及注册到该 LRS 网络的 LRS 事件和 LRS 交叉点。</para>
		/// <para>事件—将移除 LRS 事件。</para>
		/// <para>交叉点—将移除 LRS 交叉点。</para>
		/// <para>公共设施网络要素类—将移除公共设施网络。</para>
		/// <para><see cref="LrsEntityTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsEntityType { get; set; }

		/// <summary>
		/// <para>LRS Entity Name</para>
		/// <para>将从输入地理数据库工作空间中移除的 LRS 实体的名称。 LRS 实体的基础要素类和表不会被删除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsEntityName { get; set; }

		/// <summary>
		/// <para>Updated LRS Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>LRS Entity Type</para>
		/// </summary>
		public enum LrsEntityTypeEnum 
		{
			/// <summary>
			/// <para>LRS Entity Type</para>
			/// </summary>
			[GPValue("LRS")]
			[Description("LRS")]
			LRS,

			/// <summary>
			/// <para>网络—将移除 LRS 网络以及注册到该 LRS 网络的 LRS 事件和 LRS 交叉点。</para>
			/// </summary>
			[GPValue("NETWORK")]
			[Description("网络")]
			Network,

			/// <summary>
			/// <para>事件—将移除 LRS 事件。</para>
			/// </summary>
			[GPValue("EVENT")]
			[Description("事件")]
			Event,

			/// <summary>
			/// <para>交叉点—将移除 LRS 交叉点。</para>
			/// </summary>
			[GPValue("INTERSECTION")]
			[Description("交叉点")]
			Intersection,

			/// <summary>
			/// <para>公共设施网络要素类—将移除公共设施网络。</para>
			/// </summary>
			[GPValue("UN_FEATURE_CLASS")]
			[Description("公共设施网络要素类")]
			Utility_Network_Feature_Class,

		}

#endregion
	}
}
