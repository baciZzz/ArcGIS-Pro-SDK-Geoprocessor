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
	/// <para>用于将 .gpx 文件中的点数据转换为要素。</para>
	/// </summary>
	public class GPXtoFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputGPXFile">
		/// <para>Input GPX File</para>
		/// <para>要转换的输入 .gpx 文件。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature class</para>
		/// <para>输出点要素类。</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>指定输出要素类的几何类型。</para>
		/// <para>点—将创建输出点要素类。 输出中将包含所有 GPX 点。 这是默认设置。</para>
		/// <para>轨迹作为折线—将创建输出折线要素类。 输出中仅会包含 GPX 轨迹点。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </param>
		public GPXtoFeatures(object InputGPXFile, object OutputFeatureClass, object OutputType)
		{
			this.InputGPXFile = InputGPXFile;
			this.OutputFeatureClass = OutputFeatureClass;
			this.OutputType = OutputType;
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
		public override object[] Parameters() => new object[] { InputGPXFile, OutputFeatureClass, OutputType };

		/// <summary>
		/// <para>Input GPX File</para>
		/// <para>要转换的输入 .gpx 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gpx")]
		public object InputGPXFile { get; set; }

		/// <summary>
		/// <para>Output Feature class</para>
		/// <para>输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定输出要素类的几何类型。</para>
		/// <para>点—将创建输出点要素类。 输出中将包含所有 GPX 点。 这是默认设置。</para>
		/// <para>轨迹作为折线—将创建输出折线要素类。 输出中仅会包含 GPX 轨迹点。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "POINTS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GPXtoFeatures SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>点—将创建输出点要素类。 输出中将包含所有 GPX 点。 这是默认设置。</para>
			/// </summary>
			[GPValue("POINTS")]
			[Description("点")]
			Points,

			/// <summary>
			/// <para>轨迹作为折线—将创建输出折线要素类。 输出中仅会包含 GPX 轨迹点。</para>
			/// </summary>
			[GPValue("TRACKS_AS_LINES")]
			[Description("轨迹作为折线")]
			Tracks_as_polylines,

		}

#endregion
	}
}
