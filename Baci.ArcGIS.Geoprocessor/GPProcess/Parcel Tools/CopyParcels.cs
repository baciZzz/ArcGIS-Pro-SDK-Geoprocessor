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
	/// <para>Copy Parcels</para>
	/// <para>复制宗地</para>
	/// <para>将宗地从输入宗地结构复制到新要素数据集中的新宗地结构。</para>
	/// </summary>
	public class CopyParcels : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将被复制到新宗地结构的输入宗地。 输入宗地结构可来自文件地理数据库、企业级地理数据库、移动地理数据库或要素服务。</para>
		/// </param>
		/// <param name="TargetDatabase">
		/// <para>Target Database</para>
		/// <para>将创建新宗地结构的地理数据库。 地理数据库可以为文件地理数据库、企业级地理数据库或移动地理数据库。</para>
		/// </param>
		public CopyParcels(object InParcelFabric, object TargetDatabase)
		{
			this.InParcelFabric = InParcelFabric;
			this.TargetDatabase = TargetDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制宗地</para>
		/// </summary>
		public override string DisplayName() => "复制宗地";

		/// <summary>
		/// <para>Tool Name : CopyParcels</para>
		/// </summary>
		public override string ToolName() => "CopyParcels";

		/// <summary>
		/// <para>Tool Excute Name : parcel.CopyParcels</para>
		/// </summary>
		public override string ExcuteName() => "parcel.CopyParcels";

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
		public override object[] Parameters() => new object[] { InParcelFabric, TargetDatabase, OutDatasetName!, OutFabricName!, OutDataset!, OutParcelFabric! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将被复制到新宗地结构的输入宗地。 输入宗地结构可来自文件地理数据库、企业级地理数据库、移动地理数据库或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Target Database</para>
		/// <para>将创建新宗地结构的地理数据库。 地理数据库可以为文件地理数据库、企业级地理数据库或移动地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetDatabase { get; set; }

		/// <summary>
		/// <para>Feature Dataset Name</para>
		/// <para>将为新宗地结构创建的要素数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutDatasetName { get; set; }

		/// <summary>
		/// <para>Parcel Fabric Name</para>
		/// <para>新宗地结构的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutFabricName { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Output Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? OutParcelFabric { get; set; }

	}
}
