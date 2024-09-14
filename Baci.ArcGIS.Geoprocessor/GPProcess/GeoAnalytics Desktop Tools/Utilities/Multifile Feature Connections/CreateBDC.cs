using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Create Multifile Feature Connection</para>
	/// <para>创建多文件要素连接</para>
	/// <para>用于创建多文件要素连接文件 (.mfc) 和项目。 在多文件要素连接 (MFC) 中注册的数据集可用作 GeoAnalytics Desktop 工具和其他地理处理工具的输入。</para>
	/// </summary>
	public class CreateBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcLocation">
		/// <para>Multifile Feature Connection Output Location</para>
		/// <para>将在其中创建 .mfc 文件的文件夹。</para>
		/// </param>
		/// <param name="BdcName">
		/// <para>Output Multifile Feature Connection Name</para>
		/// <para>要创建的 .mfc 文件的名称。</para>
		/// </param>
		/// <param name="ConnectionType">
		/// <para>Connection Type</para>
		/// <para>指定要创建的连接类型。</para>
		/// <para>文件夹—连接到文件系统位置。 这是默认设置。</para>
		/// <para><see cref="ConnectionTypeEnum"/></para>
		/// </param>
		public CreateBDC(object BdcLocation, object BdcName, object ConnectionType)
		{
			this.BdcLocation = BdcLocation;
			this.BdcName = BdcName;
			this.ConnectionType = ConnectionType;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建多文件要素连接</para>
		/// </summary>
		public override string DisplayName() => "创建多文件要素连接";

		/// <summary>
		/// <para>Tool Name : CreateBDC</para>
		/// </summary>
		public override string ToolName() => "CreateBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.CreateBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.CreateBDC";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcLocation, BdcName, ConnectionType, DataSourceFolder!, VisibleGeometry!, VisibleTime!, OutputBdc! };

		/// <summary>
		/// <para>Multifile Feature Connection Output Location</para>
		/// <para>将在其中创建 .mfc 文件的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object BdcLocation { get; set; }

		/// <summary>
		/// <para>Output Multifile Feature Connection Name</para>
		/// <para>要创建的 .mfc 文件的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BdcName { get; set; }

		/// <summary>
		/// <para>Connection Type</para>
		/// <para>指定要创建的连接类型。</para>
		/// <para>文件夹—连接到文件系统位置。 这是默认设置。</para>
		/// <para><see cref="ConnectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConnectionType { get; set; } = "FOLDER";

		/// <summary>
		/// <para>Data Source Folder</para>
		/// <para>包含要在 MFC 中注册的数据集的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? DataSourceFolder { get; set; }

		/// <summary>
		/// <para>Visible Geometry Fields</para>
		/// <para>指定当 MFC 文件用作其他地理处理工具的输入时，用于指定几何的字段是否作为字段可见。 当几何字段不可见时，几何仍会应用于数据集。 可以在 MFC 中修改几何可见性设置。</para>
		/// <para>选中 - 几何字段将包含在待分析字段范围内。 这是默认设置。</para>
		/// <para>未选中 - 几何字段将不在待分析字段范围内。</para>
		/// <para><see cref="VisibleGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? VisibleGeometry { get; set; } = "true";

		/// <summary>
		/// <para>Visible Time Fields</para>
		/// <para>指定当 MFC 文件用作其他地理处理工具的输入时，用于指定时间的字段是否作为字段可见。 当时间字段不可见时，时间仍会应用于数据集。 可以在 MFC 中修改时间可见性设置。</para>
		/// <para>选中 - 时间字段将包含在待分析字段范围内。 这是默认设置。</para>
		/// <para>未选中 - 时间字段将不在待分析字段范围内。</para>
		/// <para><see cref="VisibleTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? VisibleTime { get; set; } = "true";

		/// <summary>
		/// <para>Output MFC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("bdc", "mfc")]
		public object? OutputBdc { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Connection Type</para>
		/// </summary>
		public enum ConnectionTypeEnum 
		{
			/// <summary>
			/// <para>文件夹—连接到文件系统位置。 这是默认设置。</para>
			/// </summary>
			[GPValue("FOLDER")]
			[Description("文件夹")]
			Folder,

		}

		/// <summary>
		/// <para>Visible Geometry Fields</para>
		/// </summary>
		public enum VisibleGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOMETRY_VISIBLE")]
			GEOMETRY_VISIBLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("GEOMETRY_NOT_VISIBLE")]
			GEOMETRY_NOT_VISIBLE,

		}

		/// <summary>
		/// <para>Visible Time Fields</para>
		/// </summary>
		public enum VisibleTimeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TIME_VISIBLE")]
			TIME_VISIBLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("TIME_NOT_VISIBLE")]
			TIME_NOT_VISIBLE,

		}

#endregion
	}
}
