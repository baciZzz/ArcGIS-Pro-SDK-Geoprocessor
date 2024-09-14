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
	/// <para>Create Custom Geographic Transformation</para>
	/// <para>创建自定义地理(坐标)变换</para>
	/// <para>可创建一种变换方法，用于在两个地理坐标系或基准面之间对数据进行转换。对于任何参数要求进行地理变换的工具，都可使用此工具的输出作为变换方法。</para>
	/// </summary>
	public class CreateCustomGeoTransformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="GeotName">
		/// <para>Geographic Transformation Name</para>
		/// <para>自定义变换方法的名称。</para>
		/// <para>所有的自定义地理变换文件都将存储为扩展名为 .gtf 的文件，并存储在用户应用程序数据文件夹中的 ESRI\&lt;ArcGIS product&gt;\ArcToolbox\CustomTransformations 文件夹中。如果 CustomTransformations 文件夹不存在，此工具会自动创建。如果应用程序数据文件夹为只读或已隐藏，则输出会创建到用户临时文件夹中的 ArcToolbox\CustomTransformations 中。Application Data 和 temp 文件夹的位置或名称取决于操作系统。</para>
		/// <para>在所有 Windows 操作系统中，应用程序数据文件夹均位于 %appdata% 中，而用户的临时文件夹则位于 %temp% 中。在命令窗口中输入 %appdata% 将返回应用程序数据文件夹位置。输入 %temp% 将返回临时文件夹位置。</para>
		/// <para>在 Unix 系统中，tmp 文件夹和应用程序数据文件夹分别位于用户的主目录 $HOME 和 $TMP 下。在终端键入 /tmp 将返回该位置。</para>
		/// </param>
		/// <param name="InCoorSystem">
		/// <para>Input Geographic Coordinate System</para>
		/// <para>起始地理坐标系。</para>
		/// </param>
		/// <param name="OutCoorSystem">
		/// <para>Output Geographic Coordinate System</para>
		/// <para>最终地理坐标系。</para>
		/// </param>
		/// <param name="CustomGeot">
		/// <para>Custom Geographic Transformation</para>
		/// <para>从下拉列表中选择一种变换方法，将使用该方法在输入地理坐标系与输出地理坐标系之间变换数据。完成选择后，其参数将显示在表格中以供编辑。</para>
		/// </param>
		public CreateCustomGeoTransformation(object GeotName, object InCoorSystem, object OutCoorSystem, object CustomGeot)
		{
			this.GeotName = GeotName;
			this.InCoorSystem = InCoorSystem;
			this.OutCoorSystem = OutCoorSystem;
			this.CustomGeot = CustomGeot;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建自定义地理(坐标)变换</para>
		/// </summary>
		public override string DisplayName() => "创建自定义地理(坐标)变换";

		/// <summary>
		/// <para>Tool Name : CreateCustomGeoTransformation</para>
		/// </summary>
		public override string ToolName() => "CreateCustomGeoTransformation";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateCustomGeoTransformation</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateCustomGeoTransformation";

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
		public override object[] Parameters() => new object[] { GeotName, InCoorSystem, OutCoorSystem, CustomGeot };

		/// <summary>
		/// <para>Geographic Transformation Name</para>
		/// <para>自定义变换方法的名称。</para>
		/// <para>所有的自定义地理变换文件都将存储为扩展名为 .gtf 的文件，并存储在用户应用程序数据文件夹中的 ESRI\&lt;ArcGIS product&gt;\ArcToolbox\CustomTransformations 文件夹中。如果 CustomTransformations 文件夹不存在，此工具会自动创建。如果应用程序数据文件夹为只读或已隐藏，则输出会创建到用户临时文件夹中的 ArcToolbox\CustomTransformations 中。Application Data 和 temp 文件夹的位置或名称取决于操作系统。</para>
		/// <para>在所有 Windows 操作系统中，应用程序数据文件夹均位于 %appdata% 中，而用户的临时文件夹则位于 %temp% 中。在命令窗口中输入 %appdata% 将返回应用程序数据文件夹位置。输入 %temp% 将返回临时文件夹位置。</para>
		/// <para>在 Unix 系统中，tmp 文件夹和应用程序数据文件夹分别位于用户的主目录 $HOME 和 $TMP 下。在终端键入 /tmp 将返回该位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object GeotName { get; set; }

		/// <summary>
		/// <para>Input Geographic Coordinate System</para>
		/// <para>起始地理坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object InCoorSystem { get; set; }

		/// <summary>
		/// <para>Output Geographic Coordinate System</para>
		/// <para>最终地理坐标系。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoorSystem { get; set; }

		/// <summary>
		/// <para>Custom Geographic Transformation</para>
		/// <para>从下拉列表中选择一种变换方法，将使用该方法在输入地理坐标系与输出地理坐标系之间变换数据。完成选择后，其参数将显示在表格中以供编辑。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CustomGeot { get; set; } = "Null";

	}
}
