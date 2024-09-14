using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Sun Shadow Frequency</para>
	/// <para>太阳阴影频率</para>
	/// <para>用于计算从某表面上固定位置到太阳的直接视线被多面体要素遮挡的次数。</para>
	/// </summary>
	public class SunShadowFrequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将构成阳光遮挡来源的多面体要素。</para>
		/// </param>
		/// <param name="Ground">
		/// <para>Ground Surface</para>
		/// <para>用于确定阳光遮挡评估位置的地表。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Shadow Raster</para>
		/// <para>其像元值可反映相应地面高度位置被输入要素遮挡的次数的输出栅格。</para>
		/// </param>
		public SunShadowFrequency(object InFeatures, object Ground, object OutRaster)
		{
			this.InFeatures = InFeatures;
			this.Ground = Ground;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 太阳阴影频率</para>
		/// </summary>
		public override string DisplayName() => "太阳阴影频率";

		/// <summary>
		/// <para>Tool Name : SunShadowFrequency</para>
		/// </summary>
		public override string ToolName() => "SunShadowFrequency";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SunShadowFrequency</para>
		/// </summary>
		public override string ExcuteName() => "3d.SunShadowFrequency";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Ground, OutRaster, CellSize!, StartTime!, EndTime!, TimeInterval!, TimeZone!, Dst!, MaxShadowLength! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将构成阳光遮挡来源的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Ground Surface</para>
		/// <para>用于确定阳光遮挡评估位置的地表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object Ground { get; set; }

		/// <summary>
		/// <para>Output Shadow Raster</para>
		/// <para>其像元值可反映相应地面高度位置被输入要素遮挡的次数的输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>输出栅格的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? CellSize { get; set; } = "10 Feet";

		/// <summary>
		/// <para>Start Time</para>
		/// <para>将开始计算太阳位置的日期和时间。默认值为初始化工具的日期和时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? StartTime { get; set; }

		/// <summary>
		/// <para>End Time</para>
		/// <para>将结束计算太阳位置的日期和时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? EndTime { get; set; }

		/// <summary>
		/// <para>Time Interval</para>
		/// <para>用于计算从开始日期和时间到结束日期和时间的太阳位置的时间间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		public object? TimeInterval { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>与用于确定太阳相对位置的指定输入时间相对应的时区。可用值的列表由操作系统定义，但其默认设置为计算机上当前时间的时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeZone { get; set; } = "Pacific_Standard_Time";

		/// <summary>
		/// <para>Adjusted for Daylight Saving Time</para>
		/// <para>用于指定是否按夏令时调整指定时间。</para>
		/// <para>选中 - 按夏令时调整输入时间。</para>
		/// <para>未选中 - 不按夏令时调整输入时间。这是默认设置。</para>
		/// <para><see cref="DstEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Dst { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Shadow Length</para>
		/// <para>计算过程中从输入要素投射阴影的最大距离。在处理太阳位置高度角较低的时间时，请考虑定义该值，如果不定义，则生成的阴影会比较长，可能会增加不必要的处理时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object? MaxShadowLength { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SunShadowFrequency SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Adjusted for Daylight Saving Time</para>
		/// </summary>
		public enum DstEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DST")]
			DST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DST")]
			NO_DST,

		}

#endregion
	}
}
