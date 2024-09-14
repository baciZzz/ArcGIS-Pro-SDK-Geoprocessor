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
	/// <para>Analyze</para>
	/// <para>分析</para>
	/// <para>更新业务表、要素表和增量表的数据库统计数据，以及这些表的索引的统计数据。</para>
	/// </summary>
	public class Analyze : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>要分析的表或要素类。</para>
		/// </param>
		/// <param name="Components">
		/// <para>Components to Analyze</para>
		/// <para>要分析的组件类型。</para>
		/// <para>业务表—更新业务规则统计数据。</para>
		/// <para>要素表—更新要素统计数据。</para>
		/// <para>栅格表—更新栅格表统计数据。</para>
		/// <para>添加表—更新所添加数据集的统计数据。</para>
		/// <para>删除表—更新所删除数据集的统计数据。</para>
		/// <para><see cref="ComponentsEnum"/></para>
		/// </param>
		public Analyze(object InDataset, object Components)
		{
			this.InDataset = InDataset;
			this.Components = Components;
		}

		/// <summary>
		/// <para>Tool Display Name : 分析</para>
		/// </summary>
		public override string DisplayName() => "分析";

		/// <summary>
		/// <para>Tool Name : 分析</para>
		/// </summary>
		public override string ToolName() => "分析";

		/// <summary>
		/// <para>Tool Excute Name : management.Analyze</para>
		/// </summary>
		public override string ExcuteName() => "management.Analyze";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, Components, OutDataset! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>要分析的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Components to Analyze</para>
		/// <para>要分析的组件类型。</para>
		/// <para>业务表—更新业务规则统计数据。</para>
		/// <para>要素表—更新要素统计数据。</para>
		/// <para>栅格表—更新栅格表统计数据。</para>
		/// <para>添加表—更新所添加数据集的统计数据。</para>
		/// <para>删除表—更新所删除数据集的统计数据。</para>
		/// <para><see cref="ComponentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Components { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Analyze SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Components to Analyze</para>
		/// </summary>
		public enum ComponentsEnum 
		{
			/// <summary>
			/// <para>业务表—更新业务规则统计数据。</para>
			/// </summary>
			[GPValue("BUSINESS")]
			[Description("业务表")]
			Business_table,

			/// <summary>
			/// <para>要素表—更新要素统计数据。</para>
			/// </summary>
			[GPValue("FEATURE")]
			[Description("要素表")]
			Feature_table,

			/// <summary>
			/// <para>栅格表—更新栅格表统计数据。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格表")]
			Raster_table,

			/// <summary>
			/// <para>添加表—更新所添加数据集的统计数据。</para>
			/// </summary>
			[GPValue("ADDS")]
			[Description("添加表")]
			Adds_table,

			/// <summary>
			/// <para>删除表—更新所删除数据集的统计数据。</para>
			/// </summary>
			[GPValue("DELETES")]
			[Description("删除表")]
			Deletes_table,

		}

#endregion
	}
}
