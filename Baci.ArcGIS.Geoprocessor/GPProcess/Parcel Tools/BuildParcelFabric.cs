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
	/// <para>Build Parcel Fabric</para>
	/// <para>构建宗地结构</para>
	/// <para>在宗地结构中构建宗地。 宗地可根据面或线进行构建。 如果宗地是根据面构建的，则该工具会创建宗地线和宗地点。 如果宗地是根据线构建的，则该工具会创建缺失的面和点。 根据线构建宗地时，需要宗地种子。</para>
	/// </summary>
	public class BuildParcelFabric : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将为其构建宗地的宗地结构。 宗地结构可来自文件地理数据库或要素服务。</para>
		/// </param>
		public BuildParcelFabric(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建宗地结构</para>
		/// </summary>
		public override string DisplayName() => "构建宗地结构";

		/// <summary>
		/// <para>Tool Name : BuildParcelFabric</para>
		/// </summary>
		public override string ToolName() => "BuildParcelFabric";

		/// <summary>
		/// <para>Tool Excute Name : parcel.BuildParcelFabric</para>
		/// </summary>
		public override string ExcuteName() => "parcel.BuildParcelFabric";

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
		public override object[] Parameters() => new object[] { InParcelFabric, Extent, UpdatedParcelFabric, RecordName };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将为其构建宗地的宗地结构。 宗地结构可来自文件地理数据库或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>要处理的数据集的范围。 仅会处理指定范围内的要素。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Record Name</para>
		/// <para>现有宗地记录的名称。 仅会构建与此记录相关联的宗地。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object RecordName { get; set; }

	}
}
