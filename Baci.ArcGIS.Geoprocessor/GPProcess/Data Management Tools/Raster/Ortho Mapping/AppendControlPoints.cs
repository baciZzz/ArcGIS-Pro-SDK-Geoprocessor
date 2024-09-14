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
	/// <para>Append Control Points</para>
	/// <para>追加控制点</para>
	/// <para>将控制点和现有控制点表结合在一起。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AppendControlPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMasterControlPoints">
		/// <para>Target Control Points</para>
		/// <para>输入控制点表。这通常是计算连接点工具的输出。</para>
		/// </param>
		/// <param name="InInputControlPoints">
		/// <para>Input Control Points</para>
		/// <para>存储控制点的点要素类。它可以是通过计算控制点工具、计算连接点工具，或具有地面控制点的点要素类所创建的控制点表。</para>
		/// </param>
		public AppendControlPoints(object InMasterControlPoints, object InInputControlPoints)
		{
			this.InMasterControlPoints = InMasterControlPoints;
			this.InInputControlPoints = InInputControlPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加控制点</para>
		/// </summary>
		public override string DisplayName() => "追加控制点";

		/// <summary>
		/// <para>Tool Name : AppendControlPoints</para>
		/// </summary>
		public override string ToolName() => "AppendControlPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.AppendControlPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.AppendControlPoints";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMasterControlPoints, InInputControlPoints, InZField, InTagField, InDem, OutMasterControlPoints, InXyAccuracy, InZAccuracy, Geoid, AreaOfInterest, AppendOption };

		/// <summary>
		/// <para>Target Control Points</para>
		/// <para>输入控制点表。这通常是计算连接点工具的输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMasterControlPoints { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>存储控制点的点要素类。它可以是通过计算控制点工具、计算连接点工具，或具有地面控制点的点要素类所创建的控制点表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InInputControlPoints { get; set; }

		/// <summary>
		/// <para>Z Value Field Name</para>
		/// <para>该字段存储控制点 Z 值。</para>
		/// <para>如果既设置了 Z 值字段名称参数，又设置了输入 DEM 参数，那么将使用 Z 值字段。如果既没设置 Z 值字段名称参数，又没设置输入 DEM 参数，那么所有地面控制点和检测点的 Z 值都将被设置为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object InZField { get; set; }

		/// <summary>
		/// <para>Tag Field Name</para>
		/// <para>输入控制点表中的字段值是唯一的。该字段将被添加到目标控制点表中，标签字段可用于引入与地面控制点相关联的标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object InTagField { get; set; }

		/// <summary>
		/// <para>Input DEM</para>
		/// <para>DEM 用于获取输入控制点表中控制点的 Z 值。</para>
		/// <para>如果既设置了 Z 值字段名称参数，又设置了输入 DEM 参数，那么将使用 Z 值字段。如果既没设置 Z 值字段名称参数，又没设置输入 DEM 参数，那么所有地面控制点和检测点的 Z 值都将被设置为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InDem { get; set; }

		/// <summary>
		/// <para>Updated Control Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMasterControlPoints { get; set; }

		/// <summary>
		/// <para>XY Accuracy</para>
		/// <para>X 和 Y 坐标的输入精度。精度单位与输入控制点的单位相同。</para>
		/// <para>此信息应由数据提供商提供。如果精度信息不可用，请将此可选参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-09, Max = 1.7976931348623157e+308)]
		public object InXyAccuracy { get; set; }

		/// <summary>
		/// <para>Z Accuracy</para>
		/// <para>垂直坐标的输入精度。精度单位与输入控制点的单位相同。</para>
		/// <para>此信息应由数据提供商提供。如果精度信息不可用，请将此可选参数留空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-09, Max = 1.7976931348623157e+308)]
		public object InZAccuracy { get; set; }

		/// <summary>
		/// <para>Geoid</para>
		/// <para>参考椭球体高的有理多项式系数 (RPC) 需要进行大地水准面校正。大多数高程数据集均参考海平面正高，因此在这些情况下，需要进行此项校正以将海平面正高转换为椭球体高。</para>
		/// <para>未选中 - 不进行大地水准面校正。只有在已使用椭球体高表示 DEM 的情况下，才能使用此选项。这是默认设置。</para>
		/// <para>选中 - 将进行大地水准面校正以将正高转换为椭球体高（根据 EGM96 大地水准面）。</para>
		/// <para><see cref="GeoidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Geoid { get; set; } = "false";

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>通过在输入控制点表的空间参考中输入最小和最大的 x 和 y 坐标，来定义感兴趣区域的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Append Option</para>
		/// <para>指定控制点追加到控制点表的方式。</para>
		/// <para>添加所有点—将输入控制点表中的所有点添加到目标控制点表，包括 GCP、检测点和所有连接点。这是默认设置。</para>
		/// <para>仅添加 GCP—仅将输入点表中的 GCP 添加到目标控制点表。</para>
		/// <para>添加 GCP 和连接点—将与 GCP 明确相关联的 GCP 和连接点添加到目标控制点表。使用此选项时请注意 - 只有在输入和目标控制点表中的连接点具有相同的变换时此选项才适用。如果使用其他校正过程进行计算，则连接点可能不在所需的位置。</para>
		/// <para><see cref="AppendOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AppendOption { get; set; } = "ALL";

		#region InnerClass

		/// <summary>
		/// <para>Geoid</para>
		/// </summary>
		public enum GeoidEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOID")]
			GEOID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Append Option</para>
		/// </summary>
		public enum AppendOptionEnum 
		{
			/// <summary>
			/// <para>添加所有点—将输入控制点表中的所有点添加到目标控制点表，包括 GCP、检测点和所有连接点。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("添加所有点")]
			Add_all_points,

			/// <summary>
			/// <para>仅添加 GCP—仅将输入点表中的 GCP 添加到目标控制点表。</para>
			/// </summary>
			[GPValue("GCP")]
			[Description("仅添加 GCP")]
			Add_GCPs_only,

			/// <summary>
			/// <para>添加 GCP 和连接点—将与 GCP 明确相关联的 GCP 和连接点添加到目标控制点表。使用此选项时请注意 - 只有在输入和目标控制点表中的连接点具有相同的变换时此选项才适用。如果使用其他校正过程进行计算，则连接点可能不在所需的位置。</para>
			/// </summary>
			[GPValue("GCPSET")]
			[Description("添加 GCP 和连接点")]
			Add_GCPs_and_tie_points,

		}

#endregion
	}
}
