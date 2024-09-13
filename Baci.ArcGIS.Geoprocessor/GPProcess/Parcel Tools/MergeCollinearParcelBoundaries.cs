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
	/// <para>Merge Collinear Parcel Boundaries</para>
	/// <para>合并共线宗地边界</para>
	/// <para>将连接的共线宗地线合并为单个宗地线。将删除连接的共线之间的共享宗地结构点，并在这些位置创建折点。</para>
	/// </summary>
	public class MergeCollinearParcelBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelBoundaries">
		/// <para>Input Parcel Boundaries</para>
		/// <para>要合并的宗地线。线可以是宗地线或连接线。</para>
		/// </param>
		/// <param name="OffsetTolerance">
		/// <para>Offset Tolerance</para>
		/// <para>线视为共线时共享宗地点可以与其连接的线偏移的最大距离。偏移指共享宗地点与连接的宗地线端点之间的直线之间的距离。</para>
		/// </param>
		public MergeCollinearParcelBoundaries(object InParcelBoundaries, object OffsetTolerance)
		{
			this.InParcelBoundaries = InParcelBoundaries;
			this.OffsetTolerance = OffsetTolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并共线宗地边界</para>
		/// </summary>
		public override string DisplayName() => "合并共线宗地边界";

		/// <summary>
		/// <para>Tool Name : MergeCollinearParcelBoundaries</para>
		/// </summary>
		public override string ToolName() => "MergeCollinearParcelBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : parcel.MergeCollinearParcelBoundaries</para>
		/// </summary>
		public override string ExcuteName() => "parcel.MergeCollinearParcelBoundaries";

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
		public override object[] Parameters() => new object[] { InParcelBoundaries, OffsetTolerance, OutParcelBoundaries };

		/// <summary>
		/// <para>Input Parcel Boundaries</para>
		/// <para>要合并的宗地线。线可以是宗地线或连接线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InParcelBoundaries { get; set; }

		/// <summary>
		/// <para>Offset Tolerance</para>
		/// <para>线视为共线时共享宗地点可以与其连接的线偏移的最大距离。偏移指共享宗地点与连接的宗地线端点之间的直线之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object OffsetTolerance { get; set; } = "0.5 Meters";

		/// <summary>
		/// <para>Updated Parcel Boundaries</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutParcelBoundaries { get; set; }

	}
}
