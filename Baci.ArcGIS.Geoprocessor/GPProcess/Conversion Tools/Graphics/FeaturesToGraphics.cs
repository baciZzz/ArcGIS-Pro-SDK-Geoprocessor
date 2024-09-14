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
	/// <para>Features To Graphics</para>
	/// <para>要素转图形</para>
	/// <para>将要素图层的符号化要素转换为图形图层中的图形元素。</para>
	/// </summary>
	public class FeaturesToGraphics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Features</para>
		/// <para>要转换为图形的图层。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Graphics Layer</para>
		/// <para>包含转换后的图形元素的图形图层。</para>
		/// </param>
		public FeaturesToGraphics(object InLayer, object OutLayer)
		{
			this.InLayer = InLayer;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素转图形</para>
		/// </summary>
		public override string DisplayName() => "要素转图形";

		/// <summary>
		/// <para>Tool Name : FeaturesToGraphics</para>
		/// </summary>
		public override string ToolName() => "FeaturesToGraphics";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeaturesToGraphics</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeaturesToGraphics";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, OutLayer, ExcludeFeatures!, UpdatedLayer! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要转换为图形的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "CoverageAnnotation", "ComplexJunction")]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output Graphics Layer</para>
		/// <para>包含转换后的图形元素的图形图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGraphicsLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Exclude converted features from drawing</para>
		/// <para>指定是否使用查询排除转换后的要素。</para>
		/// <para>选中 - 将排除要素。 这是默认设置。</para>
		/// <para>未选中 - 不会排除要素；其将被保留。</para>
		/// <para><see cref="ExcludeFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExcludeFeatures { get; set; } = "true";

		/// <summary>
		/// <para>Updated layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? UpdatedLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeaturesToGraphics SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Exclude converted features from drawing</para>
		/// </summary>
		public enum ExcludeFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE_FEATURES")]
			EXCLUDE_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_FEATURES")]
			KEEP_FEATURES,

		}

#endregion
	}
}
