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
	/// <para>Downloads the updated orbit  files for the  input synthetic aperture radar (SAR) data.</para>
	/// </summary>
	public class DownloadOrbitFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </param>
		public DownloadOrbitFile(object InRadarData)
		{
			this.InRadarData = InRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : Download Orbit File</para>
		/// </summary>
		public override string DisplayName => "Download Orbit File";

		/// <summary>
		/// <para>Tool Name : DownloadOrbitFile</para>
		/// </summary>
		public override string ToolName => "DownloadOrbitFile";

		/// <summary>
		/// <para>Tool Excute Name : ia.DownloadOrbitFile</para>
		/// </summary>
		public override string ExcuteName => "ia.DownloadOrbitFile";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRadarData, OrbitType!, Username!, Password!, OutOrbitFile };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Orbit Type</para>
		/// <para>Specifies the orbit state vector type that will be downloaded.</para>
		/// <para>Sentinel Restituted—Approximate orbit state vector data will be downloaded. This is available several hours after data acquisition.</para>
		/// <para>Sentinel Precise—Refined orbit state vector data will be downloaded. This is available 20 days after data acquisition. This is the default.</para>
		/// <para><see cref="OrbitTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OrbitType { get; set; } = "SENTINEL_PRECISE";

		/// <summary>
		/// <para>Username</para>
		/// <para>The username credential.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Login Credentials")]
		public object? Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>The password credential.</para>
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
			/// <para>Sentinel Restituted—Approximate orbit state vector data will be downloaded. This is available several hours after data acquisition.</para>
			/// </summary>
			[GPValue("SENTINEL_RESTITUTED")]
			[Description("Sentinel Restituted")]
			Sentinel_Restituted,

			/// <summary>
			/// <para>Sentinel Precise—Refined orbit state vector data will be downloaded. This is available 20 days after data acquisition. This is the default.</para>
			/// </summary>
			[GPValue("SENTINEL_PRECISE")]
			[Description("Sentinel Precise")]
			Sentinel_Precise,

		}

#endregion
	}
}
