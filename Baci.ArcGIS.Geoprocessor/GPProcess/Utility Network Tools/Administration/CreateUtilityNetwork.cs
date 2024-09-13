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
	/// <para>Create Utility Network</para>
	/// <para>创建公共设施网络</para>
	/// <para>在企业级、文件或移动地理数据库要素数据集中创建公共设施网络。</para>
	/// </summary>
	public class CreateUtilityNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>将创建公共设施网络和方案的地理数据库要素数据集。</para>
		/// </param>
		/// <param name="InUtilityNetworkName">
		/// <para>Utility Network Name</para>
		/// <para>将创建的公共设施网络名称。</para>
		/// </param>
		/// <param name="ServiceTerritoryFeatureClass">
		/// <para>Service Territory Feature Class</para>
		/// <para>将用于创建公共设施网络地理范围的现有面要素类。 无法在此范围外创建公共设施网络要素。</para>
		/// <para>要素类必须启用 z 和 m。</para>
		/// </param>
		public CreateUtilityNetwork(object InFeatureDataset, object InUtilityNetworkName, object ServiceTerritoryFeatureClass)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.InUtilityNetworkName = InUtilityNetworkName;
			this.ServiceTerritoryFeatureClass = ServiceTerritoryFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建公共设施网络</para>
		/// </summary>
		public override string DisplayName() => "创建公共设施网络";

		/// <summary>
		/// <para>Tool Name : CreateUtilityNetwork</para>
		/// </summary>
		public override string ToolName() => "CreateUtilityNetwork";

		/// <summary>
		/// <para>Tool Excute Name : un.CreateUtilityNetwork</para>
		/// </summary>
		public override string ExcuteName() => "un.CreateUtilityNetwork";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureDataset, InUtilityNetworkName, ServiceTerritoryFeatureClass, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>将创建公共设施网络和方案的地理数据库要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		[GPDatasetDomain()]
		[DataSetType("FeatureDataset")]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Utility Network Name</para>
		/// <para>将创建的公共设施网络名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InUtilityNetworkName { get; set; }

		/// <summary>
		/// <para>Service Territory Feature Class</para>
		/// <para>将用于创建公共设施网络地理范围的现有面要素类。 无法在此范围外创建公共设施网络要素。</para>
		/// <para>要素类必须启用 z 和 m。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object ServiceTerritoryFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateUtilityNetwork SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
