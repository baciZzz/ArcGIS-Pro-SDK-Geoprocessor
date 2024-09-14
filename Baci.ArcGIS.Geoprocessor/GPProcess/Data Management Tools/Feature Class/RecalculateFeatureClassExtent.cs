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
	/// <para>Recalculate Feature Class Extent</para>
	/// <para>重新计算要素类范围</para>
	/// <para>可基于要素类中的各个要素重新计算要素类的 XY、Z 和 M 范围属性。</para>
	/// </summary>
	public class RecalculateFeatureClassExtent : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Feature Class</para>
		/// <para>将要更新的 shapefile 或地理数据库要素类。</para>
		/// </param>
		public RecalculateFeatureClassExtent(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新计算要素类范围</para>
		/// </summary>
		public override string DisplayName() => "重新计算要素类范围";

		/// <summary>
		/// <para>Tool Name : RecalculateFeatureClassExtent</para>
		/// </summary>
		public override string ToolName() => "RecalculateFeatureClassExtent";

		/// <summary>
		/// <para>Tool Excute Name : management.RecalculateFeatureClassExtent</para>
		/// </summary>
		public override string ExcuteName() => "management.RecalculateFeatureClassExtent";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures };

		/// <summary>
		/// <para>Feature Class</para>
		/// <para>将要更新的 shapefile 或地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RecalculateFeatureClassExtent SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
