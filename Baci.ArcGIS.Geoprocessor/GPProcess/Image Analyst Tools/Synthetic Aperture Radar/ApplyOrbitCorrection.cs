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
	/// <para>应用轨道校正</para>
	/// <para>使用更准确的轨道状态矢量文件更新合成孔径雷达 (SAR) 数据集中的轨道信息。</para>
	/// </summary>
	public class ApplyOrbitCorrection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </param>
		public ApplyOrbitCorrection(object InRadarData)
		{
			this.InRadarData = InRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用轨道校正</para>
		/// </summary>
		public override string DisplayName() => "应用轨道校正";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRadarData, InOrbitFile!, OutRadarData! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Input Orbit File</para>
		/// <para>输入轨道文件。</para>
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
