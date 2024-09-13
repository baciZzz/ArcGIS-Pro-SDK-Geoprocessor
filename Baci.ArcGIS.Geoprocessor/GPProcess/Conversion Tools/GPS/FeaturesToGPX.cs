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
	/// <para>Features To GPX</para>
	/// <para>要素转 GPX</para>
	/// <para>用于将点、多点或折线要素转换为 GPX 格式文件 (.gpx)。</para>
	/// </summary>
	public class FeaturesToGPX : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入点、多点或线要素。</para>
		/// </param>
		/// <param name="OutGpxFile">
		/// <para>Output GPX File</para>
		/// <para>将使用输入要素的几何和属性创建的 .gpx 文件。</para>
		/// </param>
		public FeaturesToGPX(object InFeatures, object OutGpxFile)
		{
			this.InFeatures = InFeatures;
			this.OutGpxFile = OutGpxFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转 GPX</para>
		/// </summary>
		public override string DisplayName() => "要素转 GPX";

		/// <summary>
		/// <para>Tool Name : FeaturesToGPX</para>
		/// </summary>
		public override string ToolName() => "FeaturesToGPX";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeaturesToGPX</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeaturesToGPX";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutGpxFile, NameField!, DescriptionField!, ZField!, DateField! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入点、多点或线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output GPX File</para>
		/// <para>将使用输入要素的几何和属性创建的 .gpx 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gpx")]
		public object OutGpxFile { get; set; }

		/// <summary>
		/// <para>Name Field</para>
		/// <para>输入要素中的字段，其值用于填充 GPX name 标签。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "GlobalID", "GUID", "Long", "OID", "Float", "Short", "Text")]
		public object? NameField { get; set; }

		/// <summary>
		/// <para>Description Field</para>
		/// <para>输入要素中的字段，其值用于填充 GPX desc 标签。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "GlobalID", "GUID", "Long", "OID", "Float", "Short", "Text")]
		public object? DescriptionField { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>输入要素中的数字字段，其值用于填充 GPX elevation 标签。如果未指定高程字段，则输入要素的几何中的 z 值将用于填充 GPX elevation 标签。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double")]
		public object? ZField { get; set; }

		/// <summary>
		/// <para>Date Field</para>
		/// <para>输入要素中的日期/时间字段，其值用于填充 GPX time 标签。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? DateField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGPX SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
