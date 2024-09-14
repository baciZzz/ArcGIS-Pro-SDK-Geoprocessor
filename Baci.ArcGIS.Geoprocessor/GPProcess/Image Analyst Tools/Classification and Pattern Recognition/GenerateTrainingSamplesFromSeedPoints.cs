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
	/// <para>Generate Training Samples From Seed Points</para>
	/// <para>从种子点生成训练样本</para>
	/// <para>从种子点（如精度评估点或训练样本点）生成训练样本。 典型用例是从现有源（如专题栅格或要素类）生成训练样本。</para>
	/// </summary>
	public class GenerateTrainingSamplesFromSeedPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InClassData">
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>标注训练样本的数据源。</para>
		/// </param>
		/// <param name="InSeedPoints">
		/// <para>Input Seed Points</para>
		/// <para>提供训练样本面中心的点 shapefile 或要素类。</para>
		/// </param>
		/// <param name="OutTrainingFeatureClass">
		/// <para>Output Training Sample Feature Class</para>
		/// <para>采用可用于训练工具的格式的输出训练样本要素类，其中包括 shapefile。输出要素类可以是面要素类，也可以是点要素类。</para>
		/// </param>
		public GenerateTrainingSamplesFromSeedPoints(object InClassData, object InSeedPoints, object OutTrainingFeatureClass)
		{
			this.InClassData = InClassData;
			this.InSeedPoints = InSeedPoints;
			this.OutTrainingFeatureClass = OutTrainingFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 从种子点生成训练样本</para>
		/// </summary>
		public override string DisplayName() => "从种子点生成训练样本";

		/// <summary>
		/// <para>Tool Name : GenerateTrainingSamplesFromSeedPoints</para>
		/// </summary>
		public override string ToolName() => "GenerateTrainingSamplesFromSeedPoints";

		/// <summary>
		/// <para>Tool Excute Name : ia.GenerateTrainingSamplesFromSeedPoints</para>
		/// </summary>
		public override string ExcuteName() => "ia.GenerateTrainingSamplesFromSeedPoints";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InClassData, InSeedPoints, OutTrainingFeatureClass, MinSampleArea!, MaxSampleRadius! };

		/// <summary>
		/// <para>Input Raster or Feature Class Data</para>
		/// <para>标注训练样本的数据源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InClassData { get; set; }

		/// <summary>
		/// <para>Input Seed Points</para>
		/// <para>提供训练样本面中心的点 shapefile 或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSeedPoints { get; set; }

		/// <summary>
		/// <para>Output Training Sample Feature Class</para>
		/// <para>采用可用于训练工具的格式的输出训练样本要素类，其中包括 shapefile。输出要素类可以是面要素类，也可以是点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutTrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Min Sample Area</para>
		/// <para>每个训练样本所需的最小区域（以平方米为单位）。最小值必须大于或等于 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinSampleArea { get; set; } = "30";

		/// <summary>
		/// <para>Max Sample Radius</para>
		/// <para>训练样本内的任意点到其中心种子点之间的最长距离（以米为单位）。如果设置为 0，则输出训练样本将为点，而非面。最小值必须大于或等于 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxSampleRadius { get; set; } = "50";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTrainingSamplesFromSeedPoints SetEnviroment(object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
