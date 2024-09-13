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
	/// <para>Project</para>
	/// <para>投影</para>
	/// <para>将空间数据从一种坐标系投影到另一种坐标系。</para>
	/// </summary>
	public class Project : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset or Feature Class</para>
		/// <para>要投影的要素类、要素图层、要素数据集、场景图层或场景图层包。</para>
		/// </param>
		/// <param name="OutDataset">
		/// <para>Output Dataset or Feature Class</para>
		/// <para>将要写入结果的输出数据集。</para>
		/// </param>
		/// <param name="OutCoorSystem">
		/// <para>Output Coordinate System</para>
		/// <para>输入数据待投影到的目标坐标系。</para>
		/// </param>
		public Project(object InDataset, object OutDataset, object OutCoorSystem)
		{
			this.InDataset = InDataset;
			this.OutDataset = OutDataset;
			this.OutCoorSystem = OutCoorSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 投影</para>
		/// </summary>
		public override string DisplayName() => "投影";

		/// <summary>
		/// <para>Tool Name : 投影</para>
		/// </summary>
		public override string ToolName() => "投影";

		/// <summary>
		/// <para>Tool Excute Name : management.Project</para>
		/// </summary>
		public override string ExcuteName() => "management.Project";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "maintainAttachments", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutDataset, OutCoorSystem, TransformMethod, InCoorSystem, PreserveShape, MaxDeviation, Vertical };

		/// <summary>
		/// <para>Input Dataset or Feature Class</para>
		/// <para>要投影的要素类、要素图层、要素数据集、场景图层或场景图层包。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Dataset or Feature Class</para>
		/// <para>将要写入结果的输出数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutDataset { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>输入数据待投影到的目标坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoorSystem { get; set; }

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>此方法可用于在两个地理坐标系或基准面之间对数据进行转换。如果输入和输出坐标系具有不同的基准面，则可能需要此可选参数。</para>
		/// <para>该工具自动选择默认变换。 您可从下拉列表中选择其他变换。 变换是双向的。 例如，如果将数据从 WGS 1984 转换为 NAD 1927，可以选取一个名为 NAD_1927_to_WGS_1984_3 的变换，然后此工具即可正确应用它。</para>
		/// <para>参数会提供一个包含有效变换方法的下拉列表。 要详细了解如何选择一个或多个适当的变换，请参阅使用提示。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TransformMethod { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>输入要素类或数据集的坐标系。 当输入具有未知或未指定的坐标系时，此参数将变为活动参数。 这样，无需修改输入数据就可以指定数据的坐标系（当输入数据为只读格式时，可能无法修改）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InCoorSystem { get; set; }

		/// <summary>
		/// <para>Preserve Shape</para>
		/// <para>指定是否向输出线或面添加折点，以便其投影形状更加准确。</para>
		/// <para>未选中 - 不会向输出线或面添加额外折点。 这是默认设置。</para>
		/// <para>选中 - 根据需要向输出线或面添加额外折点，以便其投影形状更加准确。</para>
		/// <para><see cref="PreserveShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveShape { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>当选中保留形状参数时，投影线或面可从其准确投影位置偏移的距离。 默认为输出数据集空间参考 x,y 容差的 100 倍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxDeviation { get; set; }

		/// <summary>
		/// <para>Vertical</para>
		/// <para>指定是否将应用垂直变换。</para>
		/// <para>此选项仅在输入坐标系和输出坐标系都具有垂直坐标系且输入要素类坐标具有 Z 值时才会处于活动状态。 此外，许多垂直变换需要附加数据文件，而这些文件必须通过 ArcGIS Coordinate Systems Data 安装包进行安装。</para>
		/// <para>当选中垂直时，地理变换参数可以包括椭圆体变换和垂直基准面之间的变换。 例如，~NAD_1983_To_NAVD88_CONUS_GEOID12B_Height + NAD_1983_To_WGS_1984_1 可将在 NAD 1983 基准面（具有 NAVD 1988 高度）上定义的几何折点变换为 WGS 1984 椭圆体（具有表示椭圆体高度的 Z 值）上的折点。 波形符 (~) 表示变换的反转方向。</para>
		/// <para>此参数与保留形状参数不兼容。</para>
		/// <para>未选中 - 不会应用垂直变换。 几何坐标的 Z 值将被忽略，并且 z 值将不会进行修改。 这是默认设置。</para>
		/// <para>选中 - 将应用地理变换参数中指定的变换。 投影工具将变换几何坐标的 X、Y 和 Z 值。</para>
		/// <para><see cref="VerticalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Vertical { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Project SetEnviroment(object XYResolution = null , object XYTolerance = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Preserve Shape</para>
		/// </summary>
		public enum PreserveShapeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SHAPE")]
			PRESERVE_SHAPE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PRESERVE_SHAPE")]
			NO_PRESERVE_SHAPE,

		}

		/// <summary>
		/// <para>Vertical</para>
		/// </summary>
		public enum VerticalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VERTICAL")]
			VERTICAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VERTICAL")]
			NO_VERTICAL,

		}

#endregion
	}
}
