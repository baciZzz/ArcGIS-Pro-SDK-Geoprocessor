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
	/// <para>Apply Orbit Correction</para>
	/// <para>Apply Orbit Correction</para>
	/// <para>Updates the orbital information in the synthetic aperture radar (SAR) dataset using a more accurate orbit state vector file.</para>
	/// </summary>
	public class ApplyOrbitCorrection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </param>
		public ApplyOrbitCorrection(object InRadarData)
		{
			this.InRadarData = InRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Orbit Correction</para>
		/// </summary>
		public override string DisplayName() => "Apply Orbit Correction";

		/// <summary>
		/// <para>Tool Name : ApplyOrbitCorrection</para>
		/// </summary>
		public override string ToolName() => "ApplyOrbitCorrection";

		/// <summary>
		/// <para>Tool Excute Name : ia.ApplyOrbitCorrection</para>
		/// </summary>
		public override string ExcuteName() => "ia.ApplyOrbitCorrection";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRadarData, InOrbitFile!, OutRadarData! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Input Orbit File</para>
		/// <para>The input orbit file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("eof")]
		public object? InOrbitFile { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRadarData { get; set; }

	}
}
