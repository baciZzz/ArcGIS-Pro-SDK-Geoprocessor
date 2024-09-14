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
	/// <para>LAS To Multipoint</para>
	/// <para>LAS 转多点</para>
	/// <para>使用一个或多个激光雷达文件创建多点要素。</para>
	/// </summary>
	public class LASToMultipoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input</para>
		/// <para>将要导入到多点要素类中的 LAS 或 ZLAS 文件。如果指定了文件夹，则将导入位于该文件夹中的所有 LAS 文件。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="AveragePointSpacing">
		/// <para>Average Point Spacing</para>
		/// <para>一个或多个输入文件中点之间的平均 2D 距离。此距离可以是一个近似值。如果以不同的密度对区域进行采样，应指定较小的间距。所提供的值需要使用输出坐标系的投影单位。</para>
		/// </param>
		public LASToMultipoint(object Input, object OutFeatureClass, object AveragePointSpacing)
		{
			this.Input = Input;
			this.OutFeatureClass = OutFeatureClass;
			this.AveragePointSpacing = AveragePointSpacing;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS 转多点</para>
		/// </summary>
		public override string DisplayName() => "LAS 转多点";

		/// <summary>
		/// <para>Tool Name : LASToMultipoint</para>
		/// </summary>
		public override string ToolName() => "LASToMultipoint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LASToMultipoint</para>
		/// </summary>
		public override string ExcuteName() => "3d.LASToMultipoint";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, OutFeatureClass, AveragePointSpacing, ClassCode!, Return!, Attribute!, InputCoordinateSystem!, FileSuffix!, ZFactor!, FolderRecursion! };

		/// <summary>
		/// <para>Input</para>
		/// <para>将要导入到多点要素类中的 LAS 或 ZLAS 文件。如果指定了文件夹，则将导入位于该文件夹中的所有 LAS 文件。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>一个或多个输入文件中点之间的平均 2D 距离。此距离可以是一个近似值。如果以不同的密度对区域进行采样，应指定较小的间距。所提供的值需要使用输出坐标系的投影单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>Class Codes</para>
		/// <para>用作 LAS 数据点的查询过滤器的分类代码。 值的有效范围从 1 到 32。 默认情况下，不使用过滤器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ClassCode { get; set; }

		/// <summary>
		/// <para>Return Values</para>
		/// <para>将用于过滤已导入到多点要素中的 LAS 点的回波值。</para>
		/// <para>所有回波—任意回波</para>
		/// <para>第 1 个回波—1</para>
		/// <para>第 2 个回波—2</para>
		/// <para>第 3 个回波—3</para>
		/// <para>第 4 个回波—4</para>
		/// <para>第 5 个回波—5</para>
		/// <para>第 6 个回波—6</para>
		/// <para>第 7 个回波—7</para>
		/// <para>第 8 个回波—8</para>
		/// <para>最后回波—最后回波</para>
		/// <para><see cref="ReturnEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Return { get; set; } = "ANY_RETURNS";

		/// <summary>
		/// <para>Input Attribute Names</para>
		/// <para>LAS 点属性，其值将存储在输出的属性表的二进制大对象 (BLOB) 字段中。如果所生成的要素将参与 terrain 数据集，则已存储的属性可用于对 terrain 进行符号化。名称列表示将用于存储指定属性的字段的名称。支持的 LAS 属性如下：</para>
		/// <para>INTENSITY—强度</para>
		/// <para>RETURN_NUMBER—回波编号</para>
		/// <para>NUMBER_OF_RETURNS—每个脉冲的回波数</para>
		/// <para>SCAN_DIRECTION_FLAG —扫描方向标记</para>
		/// <para>EDGE_OF_FLIGHTLINE—摄影航线的边缘</para>
		/// <para>CLASSIFICATION—分类</para>
		/// <para>SCAN_ANGLE_RANK—扫描角度等级</para>
		/// <para>FILE_MARKER—文件标记</para>
		/// <para>USER_BIT_FIELD—用户数据值</para>
		/// <para>GPS_TIME—GPS 时间</para>
		/// <para>COLOR_RED—红色波段</para>
		/// <para>COLOR_GREEN—绿色波段</para>
		/// <para>COLOR_BLUE—蓝色波段</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Attribute { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输入 LAS 文件的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>将从输入文件夹导入的文件的后缀。 将文件夹指定为输入时，此参数为必填项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FileSuffix { get; set; } = "las";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Include Subfolders</para>
		/// <para>当所选输入文件夹中的子文件夹含有数据时，扫描子文件夹。为目录结构中包含的每个文件生成一行输出要素类。</para>
		/// <para>未选中 - 只有在输入文件夹中找到的 LAS 文件将转换为多点要素。这是默认设置。</para>
		/// <para>选中 - 位于输入文件夹子目录中的所有 LAS 文件将转换为多点要素。</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LASToMultipoint SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Return Values</para>
		/// </summary>
		public enum ReturnEnum 
		{
			/// <summary>
			/// <para>所有回波—任意回波</para>
			/// </summary>
			[GPValue("ANY_RETURNS")]
			[Description("所有回波")]
			All_Returns,

			/// <summary>
			/// <para>第 1 个回波—1</para>
			/// </summary>
			[GPValue("1")]
			[Description("第 1 个回波")]
			_1st_Return,

			/// <summary>
			/// <para>第 2 个回波—2</para>
			/// </summary>
			[GPValue("2")]
			[Description("第 2 个回波")]
			_2nd_Return,

			/// <summary>
			/// <para>第 3 个回波—3</para>
			/// </summary>
			[GPValue("3")]
			[Description("第 3 个回波")]
			_3rd_Return,

			/// <summary>
			/// <para>第 4 个回波—4</para>
			/// </summary>
			[GPValue("4")]
			[Description("第 4 个回波")]
			_4th_Return,

			/// <summary>
			/// <para>第 5 个回波—5</para>
			/// </summary>
			[GPValue("5")]
			[Description("第 5 个回波")]
			_5th_Return,

			/// <summary>
			/// <para>第 6 个回波—6</para>
			/// </summary>
			[GPValue("6")]
			[Description("第 6 个回波")]
			_6th_Return,

			/// <summary>
			/// <para>第 7 个回波—7</para>
			/// </summary>
			[GPValue("7")]
			[Description("第 7 个回波")]
			_7th_Return,

			/// <summary>
			/// <para>第 8 个回波—8</para>
			/// </summary>
			[GPValue("8")]
			[Description("第 8 个回波")]
			_8th_Return,

			/// <summary>
			/// <para>最后回波—最后回波</para>
			/// </summary>
			[GPValue("LAST_RETURNS")]
			[Description("最后回波")]
			Last_Return,

		}

		/// <summary>
		/// <para>Include Subfolders</para>
		/// </summary>
		public enum FolderRecursionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSION")]
			RECURSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECURSION")]
			NO_RECURSION,

		}

#endregion
	}
}
