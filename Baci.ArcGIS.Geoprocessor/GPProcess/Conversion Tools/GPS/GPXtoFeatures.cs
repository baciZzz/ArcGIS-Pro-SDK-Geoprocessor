using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>GPX To Features</para>
	/// <para>GPX 转要素</para>
	/// <para>用于将 GPX 文件内的点信息转换为要素。</para>
	/// </summary>
	public class GPXtoFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputGPXFile">
		/// <para>Input GPX File</para>
		/// <para>要转换的 GPX 文件。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature class</para>
		/// <para>要创建的要素类。</para>
		/// </param>
		public GPXtoFeatures(object InputGPXFile, object OutputFeatureClass)
		{
			this.InputGPXFile = InputGPXFile;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GPX 转要素</para>
		/// </summary>
		public override string DisplayName() => "GPX 转要素";

		/// <summary>
		/// <para>Tool Name : GPXtoFeatures</para>
		/// </summary>
		public override string ToolName() => "GPXtoFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GPXtoFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GPXtoFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputGPXFile, OutputFeatureClass };

		/// <summary>
		/// <para>Input GPX File</para>
		/// <para>要转换的 GPX 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gpx")]
		public object InputGPXFile { get; set; }

		/// <summary>
		/// <para>Output Feature class</para>
		/// <para>要创建的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GPXtoFeatures SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
