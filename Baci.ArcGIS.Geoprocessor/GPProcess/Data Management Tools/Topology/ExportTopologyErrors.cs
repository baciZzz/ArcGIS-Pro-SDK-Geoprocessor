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
	/// <para>Export Topology Errors</para>
	/// <para>导出拓扑错误</para>
	/// <para>将错误和异常从地理数据库拓扑导出到目标地理数据库。将导出与错误和异常相关联的所有信息，如错误或异常所引用的要素。导出错误和异常后，可使用任何许可级别的 ArcGIS 访问要素类。要素类可与按位置选择图层工具配合使用，并可共享给无权访问拓扑的其他用户。</para>
	/// </summary>
	public class ExportTopologyErrors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>将从中导出错误的拓扑。</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>要创建要素类的输出工作空间。默认设置为拓扑所在的工作空间。如果输入是拓扑服务，则默认值将是工程的默认地理数据库。</para>
		/// </param>
		/// <param name="OutBasename">
		/// <para>Base Name</para>
		/// <para>要加到每个输出要素类前面的名称。向同一工作空间进行多个导出操作时，可通过该名称指定唯一的输出名称。默认设置为拓扑名称。</para>
		/// </param>
		public ExportTopologyErrors(object InTopology, object OutPath, object OutBasename)
		{
			this.InTopology = InTopology;
			this.OutPath = OutPath;
			this.OutBasename = OutBasename;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出拓扑错误</para>
		/// </summary>
		public override string DisplayName() => "导出拓扑错误";

		/// <summary>
		/// <para>Tool Name : ExportTopologyErrors</para>
		/// </summary>
		public override string ToolName() => "ExportTopologyErrors";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportTopologyErrors</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportTopologyErrors";

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
		public override object[] Parameters() => new object[] { InTopology, OutPath, OutBasename, OutFeatureClassPoints!, OutFeatureClassLines!, OutFeatureClassPolygons! };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>将从中导出错误的拓扑。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>要创建要素类的输出工作空间。默认设置为拓扑所在的工作空间。如果输入是拓扑服务，则默认值将是工程的默认地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Base Name</para>
		/// <para>要加到每个输出要素类前面的名称。向同一工作空间进行多个导出操作时，可通过该名称指定唯一的输出名称。默认设置为拓扑名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutBasename { get; set; }

		/// <summary>
		/// <para>Output point features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClassPoints { get; set; }

		/// <summary>
		/// <para>Output line features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClassLines { get; set; }

		/// <summary>
		/// <para>Output polygon features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClassPolygons { get; set; }

	}
}
