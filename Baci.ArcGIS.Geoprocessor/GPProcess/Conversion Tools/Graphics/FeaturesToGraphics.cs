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
	/// <para>Features To Graphics</para>
	/// <para>Converts a feature layer's symbolized features into graphic elements in a graphics layer.</para>
	/// </summary>
	public class FeaturesToGraphics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Features</para>
		/// <para>The layer to convert to graphics.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Graphics Layer</para>
		/// <para>The graphics layer containing the converted graphic elements.</para>
		/// </param>
		public FeaturesToGraphics(object InLayer, object OutLayer)
		{
			this.InLayer = InLayer;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Features To Graphics</para>
		/// </summary>
		public override string DisplayName() => "Features To Graphics";

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
		/// <para>The layer to convert to graphics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "CoverageAnnotation", "ComplexJunction")]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output Graphics Layer</para>
		/// <para>The graphics layer containing the converted graphic elements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGraphicsLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Exclude converted features from drawing</para>
		/// <para>Specifies whether the converted features will be excluded using a query.</para>
		/// <para>Checked—The features will be excluded. This is the default.</para>
		/// <para>Unchecked—The features will not be excluded; they will be preserved.</para>
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
		public FeaturesToGraphics SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null )
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
			/// <para>Checked—The features will be excluded. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE_FEATURES")]
			EXCLUDE_FEATURES,

			/// <summary>
			/// <para>Unchecked—The features will not be excluded; they will be preserved.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_FEATURES")]
			KEEP_FEATURES,

		}

#endregion
	}
}
