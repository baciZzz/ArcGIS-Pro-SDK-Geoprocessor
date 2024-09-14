using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Generate Obstacle Features</para>
	/// <para>Generate Obstacle Features</para>
	/// <para>Converts features with a height field to a 3D obstacle feature and an obstacle restriction buffer for use in evaluating helicopter landing zones.</para>
	/// </summary>
	public class GenerateObstacleFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input source features used to create obstacle features.</para>
		/// </param>
		/// <param name="HeightField">
		/// <para>Height Field</para>
		/// <para>A field from the Input Features parameter containing height values. The field type can be numeric or text. If a text field is used, the field values must be numeric.</para>
		/// </param>
		/// <param name="OutObstacleFeatures">
		/// <para>Output Obstacle Features</para>
		/// <para>The output 3D obstacle features.</para>
		/// </param>
		/// <param name="OutObstacleBuffers">
		/// <para>Output Obstacle Buffers</para>
		/// <para>The output obstacle buffer features</para>
		/// </param>
		public GenerateObstacleFeatures(object InFeatures, object HeightField, object OutObstacleFeatures, object OutObstacleBuffers)
		{
			this.InFeatures = InFeatures;
			this.HeightField = HeightField;
			this.OutObstacleFeatures = OutObstacleFeatures;
			this.OutObstacleBuffers = OutObstacleBuffers;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Obstacle Features</para>
		/// </summary>
		public override string DisplayName() => "Generate Obstacle Features";

		/// <summary>
		/// <para>Tool Name : GenerateObstacleFeatures</para>
		/// </summary>
		public override string ToolName() => "GenerateObstacleFeatures";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.GenerateObstacleFeatures</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.GenerateObstacleFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, HeightField, OutObstacleFeatures, OutObstacleBuffers, ClipFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input source features used to create obstacle features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>A field from the Input Features parameter containing height values. The field type can be numeric or text. If a text field is used, the field values must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double", "Text")]
		public object HeightField { get; set; }

		/// <summary>
		/// <para>Output Obstacle Features</para>
		/// <para>The output 3D obstacle features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Output Obstacle Buffers</para>
		/// <para>The output obstacle buffer features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleBuffers { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>An area to clip the Output Obstacle Features. Only features within the Clip Features will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object ClipFeatures { get; set; }

	}
}
