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
	/// <para>Refresh Multifile Feature Connection</para>
	/// <para>刷新多文件要素连接</para>
	/// <para>用于刷新现有多文件要素连接 (MFC)，并注册已添加到源位置的所有新数据集。</para>
	/// </summary>
	public class RefreshBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcFile">
		/// <para>Multifile Feature Connection File</para>
		/// <para>要刷新的 MFC 文件。</para>
		/// </param>
		public RefreshBDC(object BdcFile)
		{
			this.BdcFile = BdcFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 刷新多文件要素连接</para>
		/// </summary>
		public override string DisplayName() => "刷新多文件要素连接";

		/// <summary>
		/// <para>Tool Name : RefreshBDC</para>
		/// </summary>
		public override string ToolName() => "RefreshBDC";

		/// <summary>
		/// <para>Tool Excute Name : gapro.RefreshBDC</para>
		/// </summary>
		public override string ExcuteName() => "gapro.RefreshBDC";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcFile, VisibleGeometry!, VisibleTime!, UpdatedBdc! };

		/// <summary>
		/// <para>Multifile Feature Connection File</para>
		/// <para>要刷新的 MFC 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("bdc", "mfc")]
		public object BdcFile { get; set; }

		/// <summary>
		/// <para>Visible Geometry Fields</para>
		/// <para>指定当在其他地理处理工具中使用 MFC 文件时，是否会将用于标识几何的字段作为分析字段包括在内（可见）。 当几何字段不可见时，几何仍将应用于数据集。 可以在 MFC 中修改几何可见性设置。</para>
		/// <para>选中 - 几何字段将作为分析字段包括在内。 这是默认设置。</para>
		/// <para>未选中 - 几何字段不会作为分析字段包括在内。</para>
		/// <para><see cref="VisibleGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? VisibleGeometry { get; set; } = "true";

		/// <summary>
		/// <para>Visible Time Fields</para>
		/// <para>指定当在其他地理处理工具中使用 MFC 文件时，是否会将用于指示时间的字段作为分析字段包括在内（可见）。 当时间字段不可见时，时间仍应用于数据集。 可以在 MFC 中修改时间可见性设置。</para>
		/// <para>选中 - 时间字段将作为分析字段包括在内。 这是默认设置。</para>
		/// <para>未选中 - 时间字段不会作为分析字段包括在内。</para>
		/// <para><see cref="VisibleTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? VisibleTime { get; set; } = "true";

		/// <summary>
		/// <para>Updated MFC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("bdc", "mfc")]
		public object? UpdatedBdc { get; set; }

		#region InnerClass

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
