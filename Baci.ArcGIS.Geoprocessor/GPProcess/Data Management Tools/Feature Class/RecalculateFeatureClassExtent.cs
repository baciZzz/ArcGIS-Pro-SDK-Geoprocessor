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
	/// <para>可基于要素类中的各个要素重新计算要素类的 xy、z 和 m 范围属性。</para>
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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatures!, StoreExtent! };

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
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Store Extent</para>
		/// <para>用于指定是否将为未注册的要素类存储范围。 仅当输入要素类是未注册的空间表时，此参数才有效。</para>
		/// <para>如果输入要素类经常更新，您可以选择不存储重新计算的范围值。 如果您选择存储范围，则系统将不会在每次将要素类添加到地图时重新计算范围。</para>
		/// <para>选中 - 将为输入要素类存储范围。</para>
		/// <para>未选中 - 将不会为输入要素类存储范围。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? StoreExtent { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RecalculateFeatureClassExtent SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
