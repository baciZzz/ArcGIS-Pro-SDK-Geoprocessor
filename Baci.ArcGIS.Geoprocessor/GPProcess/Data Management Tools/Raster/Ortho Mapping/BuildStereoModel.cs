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
	/// <para>Build Stereo Model</para>
	/// <para>构建立体模型</para>
	/// <para>根据用户提供的立体像对构建镶嵌数据集的立体模型。</para>
	/// </summary>
	public class BuildStereoModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>构建立体模型时基于的镶嵌数据集。</para>
		/// <para>在输入镶嵌数据集上先运行应用区域网平差有助于创建更加准确的立体模型。</para>
		/// </param>
		public BuildStereoModel(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建立体模型</para>
		/// </summary>
		public override string DisplayName() => "构建立体模型";

		/// <summary>
		/// <para>Tool Name : BuildStereoModel</para>
		/// </summary>
		public override string ToolName() => "BuildStereoModel";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildStereoModel</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildStereoModel";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, MinimumAngle!, MaximumAngle!, MinimumOverlap!, MaximumDiffOP!, MaximumDiffGSD!, GroupBy!, OutMosaicDataset!, SameFlight! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>构建立体模型时基于的镶嵌数据集。</para>
		/// <para>在输入镶嵌数据集上先运行应用区域网平差有助于创建更加准确的立体模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Minimum Intersection Angle (in degree)</para>
		/// <para>用于定义立体像对必须满足的最小角度的值（单位为度）。默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumAngle { get; set; } = "5";

		/// <summary>
		/// <para>Maximum Intersection Angle (in degree)</para>
		/// <para>用于定义立体像对必须满足的最大角度的值（单位为度）。默认值为 70。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumAngle { get; set; } = "90";

		/// <summary>
		/// <para>Minimum Area Overlap</para>
		/// <para>重叠区域在整个图像中所占的百分比。默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumOverlap { get; set; } = "0.5";

		/// <summary>
		/// <para>Maximum Omega/Phi Difference (in degree)</para>
		/// <para>两个图像对之间的 Omega 和 Phi 差异的最大阈值。将比较图像对的 Omega 值和 Phi 值。如果两个 Omega 值或两个 Phi 值之差大于阈值，则该像对将不会被格式化为立体像对。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffOP { get; set; }

		/// <summary>
		/// <para>Maximum GSD Difference</para>
		/// <para>像对中两个图像间的最大 GSD 阈值。如果这两个图像之间的分辨率比值大于阈值，则该像对将不会被构建为立体像对。默认值为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffGSD { get; set; } = "2";

		/// <summary>
		/// <para>Group by</para>
		/// <para>根据镶嵌数据集字段（如 RGB、全色或红外）定义的同一组内的栅格项目构建立体模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Date", "OID", "Text")]
		public object? GroupBy { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only pick stereo models in the same flight line</para>
		/// <para>指定如何选择立体模型。</para>
		/// <para>选中 - 将沿同一航线选择立体像对。</para>
		/// <para>未选中 - 将沿不同航线选择立体像对。这是默认设置。</para>
		/// <para>此参数不适用于基于卫星的传感器。</para>
		/// <para><see cref="SameFlightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SameFlight { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Only pick stereo models in the same flight line</para>
		/// </summary>
		public enum SameFlightEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAMEFLIGHT")]
			SAMEFLIGHT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SAMEFLIGHT")]
			NO_SAMEFLIGHT,

		}

#endregion
	}
}
