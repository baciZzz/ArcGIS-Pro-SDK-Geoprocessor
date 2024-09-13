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
	/// <para>Remove Spatial Index</para>
	/// <para>移除空间索引</para>
	/// <para>从 shapefile 或文件地理数据库、移动地理数据库或企业级地理数据库要素类中删除空间索引。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveSpatialIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将从中移除空间索引的 shapefile 或文件地理数据库、移动地理数据库或企业级地理数据库要素类。</para>
		/// </param>
		public RemoveSpatialIndex(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除空间索引</para>
		/// </summary>
		public override string DisplayName() => "移除空间索引";

		/// <summary>
		/// <para>Tool Name : RemoveSpatialIndex</para>
		/// </summary>
		public override string ToolName() => "RemoveSpatialIndex";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveSpatialIndex</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveSpatialIndex";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将从中移除空间索引的 shapefile 或文件地理数据库、移动地理数据库或企业级地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveSpatialIndex SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
