using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Download Orbit File</para>
	/// <para>下载轨道文件</para>
	/// <para>下载输入合成孔径雷达 (SAR) 数据的更新轨道文件。</para>
	/// </summary>
	public class DownloadOrbitFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </param>
		public DownloadOrbitFile(object InRadarData)
		{
			this.InRadarData = InRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : 下载轨道文件</para>
		/// </summary>
		public override string DisplayName() => "下载轨道文件";

		/// <summary>
		/// <para>Tool Name : DownloadOrbitFile</para>
		/// </summary>
		public override string ToolName() => "DownloadOrbitFile";

		/// <summary>
		/// <para>Tool Excute Name : ia.DownloadOrbitFile</para>
		/// </summary>
		public override string ExcuteName() => "ia.DownloadOrbitFile";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRadarData, OrbitType!, Username!, Password!, OutOrbitFile! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Orbit Type</para>
		/// <para>指定将下载的轨道状态矢量类型。</para>
		/// <para>Sentinel 回归—将下载近似轨道状态矢量数据。 这在数据采集几个小时后可用。</para>
		/// <para>Sentinel 精密—将下载优化轨道状态矢量数据。 这在数据采集 20 天后可用。 这是默认设置。</para>
		/// <para><see cref="OrbitTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OrbitType { get; set; } = "SENTINEL_PRECISE";

		/// <summary>
		/// <para>Username</para>
		/// <para>用户名凭据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Login Credentials")]
		public object? Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>密码凭据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEncryptedString()]
		[Category("Login Credentials")]
		public object? Password { get; set; }

		/// <summary>
		/// <para>Orbit File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutOrbitFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Orbit Type</para>
		/// </summary>
		public enum OrbitTypeEnum 
		{
			/// <summary>
			/// <para>Sentinel 回归—将下载近似轨道状态矢量数据。 这在数据采集几个小时后可用。</para>
			/// </summary>
			[GPValue("SENTINEL_RESTITUTED")]
			[Description("Sentinel 回归")]
			Sentinel_Restituted,

			/// <summary>
			/// <para>Sentinel 精密—将下载优化轨道状态矢量数据。 这在数据采集 20 天后可用。 这是默认设置。</para>
			/// </summary>
			[GPValue("SENTINEL_PRECISE")]
			[Description("Sentinel 精密")]
			Sentinel_Precise,

		}

#endregion
	}
}
