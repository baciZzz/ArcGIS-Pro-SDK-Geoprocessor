using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Change Version</para>
	/// <para>切换版本</para>
	/// <para>用于修改图层或表视图的工作空间以连接到指定版本。</para>
	/// </summary>
	public class ChangeVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Layer</para>
		/// <para>将连接到指定版本的图层或表视图。</para>
		/// <para>拓扑图层、宗地图层、公共设施网络图层或追踪网络图层的子图层不是有效输入。</para>
		/// </param>
		/// <param name="VersionType">
		/// <para>Version Type</para>
		/// <para>指定输入要素图层将连接到的版本类型。</para>
		/// <para>传统版本—连接到数据库的一种已定义状态（传统版本）。</para>
		/// <para>历史版本—连接到表示过去某一特定时刻的版本，通常通过时间标记或历史标记指定。</para>
		/// <para>分支版本—连接到分支版本。</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </param>
		public ChangeVersion(object InFeatures, object VersionType)
		{
			this.InFeatures = InFeatures;
			this.VersionType = VersionType;
		}

		/// <summary>
		/// <para>Tool Display Name : 切换版本</para>
		/// </summary>
		public override string DisplayName() => "切换版本";

		/// <summary>
		/// <para>Tool Name : ChangeVersion</para>
		/// </summary>
		public override string ToolName() => "ChangeVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.ChangeVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.ChangeVersion";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, VersionType, VersionName!, Date!, OutFeatureLayer!, IncludeParticipating! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将连接到指定版本的图层或表视图。</para>
		/// <para>拓扑图层、宗地图层、公共设施网络图层或追踪网络图层的子图层不是有效输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Version Type</para>
		/// <para>指定输入要素图层将连接到的版本类型。</para>
		/// <para>传统版本—连接到数据库的一种已定义状态（传统版本）。</para>
		/// <para>历史版本—连接到表示过去某一特定时刻的版本，通常通过时间标记或历史标记指定。</para>
		/// <para>分支版本—连接到分支版本。</para>
		/// <para><see cref="VersionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object VersionType { get; set; } = "TRANSACTIONAL";

		/// <summary>
		/// <para>Version Name</para>
		/// <para>输入要素图层将连接到的版本的名称。 如果使用历史版本，则此参数为可选参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? VersionName { get; set; }

		/// <summary>
		/// <para>Date and Time</para>
		/// <para>输入要素图层将连接到的历史版本的日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? Date { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureLayer { get; set; }

		/// <summary>
		/// <para>Include participating classes of controller dataset</para>
		/// <para>指定参与类的工作空间是否也会更改。</para>
		/// <para>仅当输入图层是拓扑图层、宗地图层、公共设施网络图层或追踪网络图层时，此参数才适用。</para>
		/// <para>选中 - 如果控制器数据集的参与类来自与控制器数据集相同的工作空间，则其版本将更改。 这是默认设置。</para>
		/// <para>未选中 - 仅控制器数据集的版本将更改。</para>
		/// <para><see cref="IncludeParticipatingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeParticipating { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Version Type</para>
		/// </summary>
		public enum VersionTypeEnum 
		{
			/// <summary>
			/// <para>传统版本—连接到数据库的一种已定义状态（传统版本）。</para>
			/// </summary>
			[GPValue("TRANSACTIONAL")]
			[Description("传统版本")]
			Traditional_version,

			/// <summary>
			/// <para>分支版本—连接到分支版本。</para>
			/// </summary>
			[GPValue("BRANCH")]
			[Description("分支版本")]
			Branch_version,

			/// <summary>
			/// <para>历史版本—连接到表示过去某一特定时刻的版本，通常通过时间标记或历史标记指定。</para>
			/// </summary>
			[GPValue("HISTORICAL")]
			[Description("历史版本")]
			Historical_version,

		}

		/// <summary>
		/// <para>Include participating classes of controller dataset</para>
		/// </summary>
		public enum IncludeParticipatingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE")]
			INCLUDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE")]
			EXCLUDE,

		}

#endregion
	}
}
