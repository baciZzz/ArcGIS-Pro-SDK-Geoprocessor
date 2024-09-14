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
	/// <para>Upgrade ArcMap Parcel Fabric</para>
	/// <para>升级 ArcMap 宗地结构</para>
	/// <para>将 ArcMap 宗地结构升级为 ArcGIS Pro 宗地结构。</para>
	/// </summary>
	public class UpgradeArcMapParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric For ArcMap</para>
		/// <para>将升级为 ArcGIS Pro 宗地结构的 ArcMap 宗地结构。</para>
		/// </param>
		/// <param name="TargetDataset">
		/// <para>Target Feature Dataset</para>
		/// <para>将包含已升级的 ArcGIS Pro 宗地结构的要素数据集。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>已升级的 ArcGIS Pro 宗地结构的名称。</para>
		/// </param>
		public UpgradeArcMapParcelFabric(object InParcelFabric, object TargetDataset, object Name)
		{
			this.InParcelFabric = InParcelFabric;
			this.TargetDataset = TargetDataset;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级 ArcMap 宗地结构</para>
		/// </summary>
		public override string DisplayName() => "升级 ArcMap 宗地结构";

		/// <summary>
		/// <para>Tool Name : UpgradeArcMapParcelFabric</para>
		/// </summary>
		public override string ToolName() => "UpgradeArcMapParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.UpgradeArcMapParcelFabric</para>
		/// </summary>
		public override string ExcuteName() => "parcel.UpgradeArcMapParcelFabric";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, TargetDataset, Name, OutParcelFabric!, DeleteIdentical! };

		/// <summary>
		/// <para>Input Parcel Fabric For ArcMap</para>
		/// <para>将升级为 ArcGIS Pro 宗地结构的 ArcMap 宗地结构。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCadastralFabricLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Target Feature Dataset</para>
		/// <para>将包含已升级的 ArcGIS Pro 宗地结构的要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object TargetDataset { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>已升级的 ArcGIS Pro 宗地结构的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Output Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? OutParcelFabric { get; set; }

		/// <summary>
		/// <para>Delete identical overlapping lines</para>
		/// <para>指定是否删除相同重叠线。 选中此参数后，如果线形状相同（线重合）并且具有以下匹配属性，则会将这些重叠线删除：</para>
		/// <para>Direction 字段中的方向。 这包括反转 180 度的方向。</para>
		/// <para>Distance 字段中的距离 距离舍入为四位小数。</para>
		/// <para>Created By Record 字段中的记录。</para>
		/// <para>Retired By Record 字段中的记录。</para>
		/// <para>选中 - 将删除相同重叠线。</para>
		/// <para>未选中 - 不会删除相同重叠线。 这是默认设置。</para>
		/// <para><see cref="DeleteIdenticalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteIdentical { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Delete identical overlapping lines</para>
		/// </summary>
		public enum DeleteIdenticalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_IDENTICAL_LINES")]
			DELETE_IDENTICAL_LINES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_IDENTICAL_LINES")]
			KEEP_IDENTICAL_LINES,

		}

#endregion
	}
}
