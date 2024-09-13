using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Create Parcel Fabric</para>
	/// <para>创建宗地结构</para>
	/// <para>创建宗地结构及其关联的数据集。宗地结构将在位于文件或企业级地理数据库中的要素数据集中创建。</para>
	/// </summary>
	public class CreateParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>将在其中创建宗地结构和相关方案的要素数据集。要素数据集可位于文件或企业级地理数据库中。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>将创建的宗地结构的名称。关联的数据集将前缀宗地结构名称。</para>
		/// </param>
		public CreateParcelFabric(object TargetDataset, object Name)
		{
			this.TargetDataset = TargetDataset;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建宗地结构</para>
		/// </summary>
		public override string DisplayName() => "创建宗地结构";

		/// <summary>
		/// <para>Tool Name : CreateParcelFabric</para>
		/// </summary>
		public override string ToolName() => "CreateParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.CreateParcelFabric</para>
		/// </summary>
		public override string ExcuteName() => "parcel.CreateParcelFabric";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetDataset, Name, OutParcelFabric };

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>将在其中创建宗地结构和相关方案的要素数据集。要素数据集可位于文件或企业级地理数据库中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetDataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>将创建的宗地结构的名称。关联的数据集将前缀宗地结构名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Output Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object OutParcelFabric { get; set; }

	}
}
