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
	/// <para>Refresh Multifile Feature Connection</para>
	/// <para>Refreshes an existing multifile feature connection (MFC) and registers any new datasets that have been added to the source location.</para>
	/// </summary>
	public class RefreshBDC : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcFile">
		/// <para>Multifile Feature Connection File</para>
		/// <para>The MFC file to refresh.</para>
		/// </param>
		public RefreshBDC(object BdcFile)
		{
			this.BdcFile = BdcFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Refresh Multifile Feature Connection</para>
		/// </summary>
		public override string DisplayName() => "Refresh Multifile Feature Connection";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { BdcFile, VisibleGeometry!, VisibleTime!, UpdatedBdc! };

		/// <summary>
		/// <para>Multifile Feature Connection File</para>
		/// <para>The MFC file to refresh.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("bdc", "mfc")]
		public object BdcFile { get; set; }

		/// <summary>
		/// <para>Visible Geometry Fields</para>
		/// <para>Specifies whether the fields used to identify the geometry will be included (visible) as fields for analysis when the MFC file is used in other geoprocessing tools. When geometry fields are not visible, geometry is still applied to the dataset. The geometry visibility setting can be modified in the MFC.</para>
		/// <para>Checked—Geometry fields will be included as fields for analysis. This is the default.</para>
		/// <para>Unchecked—Geometry fields will not be included as fields for analysis.</para>
		/// <para><see cref="VisibleGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? VisibleGeometry { get; set; } = "true";

		/// <summary>
		/// <para>Visible Time Fields</para>
		/// <para>Specifies whether the fields used to indicate the time will be included (visible) as fields for analysis when the MFC file is used in other geoprocessing tools. When time fields are not visible, time is still applied to the dataset. The time visibility setting can be modified in the MFC.</para>
		/// <para>Checked—Time fields will be included as fields for analysis. This is the default.</para>
		/// <para>Unchecked—Time fields will not be included as fields for analysis.</para>
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
			/// <para>Checked—Geometry fields will be included as fields for analysis. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GEOMETRY_VISIBLE")]
			GEOMETRY_VISIBLE,

			/// <summary>
			/// <para>Unchecked—Geometry fields will not be included as fields for analysis.</para>
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
			/// <para>Checked—Time fields will be included as fields for analysis. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TIME_VISIBLE")]
			TIME_VISIBLE,

			/// <summary>
			/// <para>Unchecked—Time fields will not be included as fields for analysis.</para>
			/// </summary>
			[GPValue("false")]
			[Description("TIME_NOT_VISIBLE")]
			TIME_NOT_VISIBLE,

		}

#endregion
	}
}
