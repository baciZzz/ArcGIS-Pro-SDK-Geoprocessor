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
	/// <para>Compute Dirty Area</para>
	/// <para>计算脏区</para>
	/// <para>识别在指定时间点后发生更改的镶嵌数据集中的区域。对镶嵌数据集进行更新或同步，或需要更新衍生产品（例如缓存）时经常使用该工具。该工具可将此类进程限制为仅适用于已更改的区域。</para>
	/// </summary>
	public class ComputeDirtyArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要针对更改进行分析的镶嵌数据集。</para>
		/// </param>
		/// <param name="Timestamp">
		/// <para>Start Date and Time</para>
		/// <para>计算自输入时间起更改的区域。</para>
		/// <para>XML 时间语法：</para>
		/// <para>YYYY-MM-DDThh:mm:ss</para>
		/// <para>YYYY-MM-DDThh:mm:ss.ssssZ</para>
		/// <para>2002-10-10T12:00:00.ssss-00:00</para>
		/// <para>2002-10-10T12:00:00+00:00</para>
		/// <para>非 XML 时间语法：</para>
		/// <para>2002/12/25 23:59:58.123</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含已更改区域的要素类。</para>
		/// </param>
		public ComputeDirtyArea(object InMosaicDataset, object Timestamp, object OutFeatureClass)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.Timestamp = Timestamp;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算脏区</para>
		/// </summary>
		public override string DisplayName() => "计算脏区";

		/// <summary>
		/// <para>Tool Name : ComputeDirtyArea</para>
		/// </summary>
		public override string ToolName() => "ComputeDirtyArea";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeDirtyArea</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeDirtyArea";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, Timestamp, OutFeatureClass };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>想要针对更改进行分析的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于选择镶嵌数据集中的特定栅格（将在其中计算脏区）的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Start Date and Time</para>
		/// <para>计算自输入时间起更改的区域。</para>
		/// <para>XML 时间语法：</para>
		/// <para>YYYY-MM-DDThh:mm:ss</para>
		/// <para>YYYY-MM-DDThh:mm:ss.ssssZ</para>
		/// <para>2002-10-10T12:00:00.ssss-00:00</para>
		/// <para>2002-10-10T12:00:00+00:00</para>
		/// <para>非 XML 时间语法：</para>
		/// <para>2002/12/25 23:59:58.123</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Timestamp { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含已更改区域的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeDirtyArea SetEnviroment(object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
