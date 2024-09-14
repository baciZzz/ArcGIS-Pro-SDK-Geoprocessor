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
	/// <para>ASCII 3D To Feature Class</para>
	/// <para>3D ASCII 文件转要素类</para>
	/// <para>将 3D 要素从一个或多个以 XYZ、XYZI 或 GENERATE 格式存储的 ASCII 文件导入到新要素类中。</para>
	/// </summary>
	public class ASCII3DToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>ASCII 3D Data</para>
		/// <para>包含 XYZ、XYZI（具有激光雷达强度）或 3D GENERATE 格式数据的 ASCII 文件或文件夹。所有输入文件的格式必须相同。如果指定了某个文件夹，则文件后缀参数将成为必选项，并将处理所有与指定后缀具有相同扩展名的文件。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </param>
		/// <param name="InFileType">
		/// <para>File Format</para>
		/// <para>将转换为要素类的 ASCII 文件格式。</para>
		/// <para>XYZ—包含存储为 XYZ 坐标的几何信息的文本文件。</para>
		/// <para>XYZI—同时包含 XYZ 坐标和强度测量值的文本文件。</para>
		/// <para>生成—以 GENERATE 格式进行结构化的文本文件。</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="OutGeometryType">
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何类型。</para>
		/// <para>多点要素—由于输入数据包含大量每个要素不需要的点和属性，所以建议使用多点。</para>
		/// <para>点要素—每个 XYZ 坐标将生成一个点要素。</para>
		/// <para>折线要素—输出将包含折线要素。</para>
		/// <para>多边形要素—输出将包含面要素。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </param>
		public ASCII3DToFeatureClass(object Input, object InFileType, object OutFeatureClass, object OutGeometryType)
		{
			this.Input = Input;
			this.InFileType = InFileType;
			this.OutFeatureClass = OutFeatureClass;
			this.OutGeometryType = OutGeometryType;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D ASCII 文件转要素类</para>
		/// </summary>
		public override string DisplayName() => "3D ASCII 文件转要素类";

		/// <summary>
		/// <para>Tool Name : ASCII3DToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "ASCII3DToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ASCII3DToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "3d.ASCII3DToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, InFileType, OutFeatureClass, OutGeometryType, ZFactor, InputCoordinateSystem, AveragePointSpacing, FileSuffix, DecimalSeparator };

		/// <summary>
		/// <para>ASCII 3D Data</para>
		/// <para>包含 XYZ、XYZI（具有激光雷达强度）或 3D GENERATE 格式数据的 ASCII 文件或文件夹。所有输入文件的格式必须相同。如果指定了某个文件夹，则文件后缀参数将成为必选项，并将处理所有与指定后缀具有相同扩展名的文件。</para>
		/// <para>在“工具”对话框中，可将文件夹指定为输入，具体方法如下：在 Windows 资源管理器中选择文件夹，然后将其拖动到参数的输入框上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Input { get; set; }

		/// <summary>
		/// <para>File Format</para>
		/// <para>将转换为要素类的 ASCII 文件格式。</para>
		/// <para>XYZ—包含存储为 XYZ 坐标的几何信息的文本文件。</para>
		/// <para>XYZI—同时包含 XYZ 坐标和强度测量值的文本文件。</para>
		/// <para>生成—以 GENERATE 格式进行结构化的文本文件。</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFileType { get; set; } = "XYZ";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何类型。</para>
		/// <para>多点要素—由于输入数据包含大量每个要素不需要的点和属性，所以建议使用多点。</para>
		/// <para>点要素—每个 XYZ 坐标将生成一个点要素。</para>
		/// <para>折线要素—输出将包含折线要素。</para>
		/// <para>多边形要素—输出将包含面要素。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutGeometryType { get; set; } = "MULTIPOINT";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输入数据的坐标系。默认为“未知坐标系”。如果已指定坐标系，则输出可能会（也可能不会）被投影到不同的坐标系中。这取决于地理处理环境是否具有为目标要素类位置而定义的坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>输入点之间的平均平面距离。仅当将输出几何设置为 MULTIPOINT 时才可使用此参数，且其功能是提供一个平均值以将点归组到一起。结合每个形状限制的点数使用该值，以构造用于组合点的虚拟分块系统。分块系统的原点取决于目标要素类的空间域。指定目标要素类的水平单位的间距。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>将从输入文件夹导入的文件的后缀。 将文件夹指定为输入时，此参数为必填项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FileSuffix { get; set; }

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>文本文件中将用于区分数字的整数部分与其小数部分的小数分隔符。</para>
		/// <para>点—将使用点作为小数字符。 这是默认设置。</para>
		/// <para>逗号—将使用逗号作为小数字符。</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ASCII3DToFeatureClass SetEnviroment(object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Format</para>
		/// </summary>
		public enum InFileTypeEnum 
		{
			/// <summary>
			/// <para>XYZ—包含存储为 XYZ 坐标的几何信息的文本文件。</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("XYZ")]
			XYZ,

			/// <summary>
			/// <para>XYZI—同时包含 XYZ 坐标和强度测量值的文本文件。</para>
			/// </summary>
			[GPValue("XYZI")]
			[Description("XYZI")]
			XYZI,

			/// <summary>
			/// <para>生成—以 GENERATE 格式进行结构化的文本文件。</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("生成")]
			Generate,

		}

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>点要素—每个 XYZ 坐标将生成一个点要素。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点要素")]
			Point_features,

			/// <summary>
			/// <para>多点要素—由于输入数据包含大量每个要素不需要的点和属性，所以建议使用多点。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点要素")]
			Multipoint_features,

			/// <summary>
			/// <para>折线要素—输出将包含折线要素。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线要素")]
			Polyline_features,

			/// <summary>
			/// <para>多边形要素—输出将包含面要素。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("多边形要素")]
			Polygon_features,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>点—将使用点作为小数字符。 这是默认设置。</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>逗号—将使用逗号作为小数字符。</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("逗号")]
			Comma,

		}

#endregion
	}
}
