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
	/// <para>Apply Parcel Least Squares Adjustment</para>
	/// <para>应用宗地最小二乘平差</para>
	/// <para>将最小二乘平差的结果应用到宗地结构要素类。存储在 AdjustmentLines 和 AdjustmentPoints 要素类中的最小二乘平差结果将应用至相应的宗地线、连接线和宗地结构点要素类。</para>
	/// </summary>
	public class ApplyParcelLeastSquaresAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>要更新的宗地结构。</para>
		/// </param>
		public ApplyParcelLeastSquaresAdjustment(object InParcelFabric)
		{
			this.InParcelFabric = InParcelFabric;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用宗地最小二乘平差</para>
		/// </summary>
		public override string DisplayName() => "应用宗地最小二乘平差";

		/// <summary>
		/// <para>Tool Name : ApplyParcelLeastSquaresAdjustment</para>
		/// </summary>
		public override string ToolName() => "ApplyParcelLeastSquaresAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : parcel.ApplyParcelLeastSquaresAdjustment</para>
		/// </summary>
		public override string ExcuteName() => "parcel.ApplyParcelLeastSquaresAdjustment";

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
		public override object[] Parameters() => new object[] { InParcelFabric, MovementTolerance!, UpdatedParcelFabric!, UpdateAttributes! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>要更新的宗地结构。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Movement Tolerance</para>
		/// <para>该容差表示更新宗地结构点时的最小容许坐标偏移。如果校正点和宗地结构点之间的距离大于指定的容差，则宗地结构点将更新为校正点的位置。默认容差为 0.05 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MovementTolerance { get; set; } = "0.05 Meters";

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Update Attribute Fields</para>
		/// <para>指定是否将使用统计元数据更新宗地结构点要素类中的属性字段。XY Uncertainty、Error Ellipse Semi Major、Error Ellipse Semi Minor 和 Error Ellipse Direction 字段将使用 AdjustmentPoints 要素类的相同字段中存储的值进行更新。</para>
		/// <para>选中 - 将使用统计元数据更新宗地结构点要素类中的属性字段。</para>
		/// <para>未选中 - 不更新属性字段。这是默认设置。</para>
		/// <para><see cref="UpdateAttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateAttributes { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Update Attribute Fields</para>
		/// </summary>
		public enum UpdateAttributesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_ATTRIBUTES")]
			UPDATE_ATTRIBUTES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_ATTRIBUTES")]
			NO_UPDATE_ATTRIBUTES,

		}

#endregion
	}
}
