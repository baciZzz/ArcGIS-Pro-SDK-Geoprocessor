using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Annotate Selected Features</para>
	/// <para>Annotate Selected Features</para>
	/// <para>Creates annotation for the selected features of a layer. The labeling properties defined in the annotation class properties of  the specified related annotation feature classes are used.</para>
	/// </summary>
	public class AnnotateSelectedFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The input map.</para>
		/// </param>
		/// <param name="InLayer">
		/// <para>Input Features</para>
		/// <para>The layer for which the selected features will have annotation created.</para>
		/// </param>
		/// <param name="AnnoLayers">
		/// <para>Annotation Layers</para>
		/// <para>The feature-linked annotation layers and the specified sublayers that will have annotation converted into them.</para>
		/// </param>
		public AnnotateSelectedFeatures(object InMap, object InLayer, object AnnoLayers)
		{
			this.InMap = InMap;
			this.InLayer = InLayer;
			this.AnnoLayers = AnnoLayers;
		}

		/// <summary>
		/// <para>Tool Display Name : Annotate Selected Features</para>
		/// </summary>
		public override string DisplayName() => "Annotate Selected Features";

		/// <summary>
		/// <para>Tool Name : AnnotateSelectedFeatures</para>
		/// </summary>
		public override string ToolName() => "AnnotateSelectedFeatures";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AnnotateSelectedFeatures</para>
		/// </summary>
		public override string ExcuteName() => "cartography.AnnotateSelectedFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, InLayer, AnnoLayers, GenerateUnplaced, OutAnnoLayers };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The layer for which the selected features will have annotation created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Annotation Layers</para>
		/// <para>The feature-linked annotation layers and the specified sublayers that will have annotation converted into them.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AnnoLayers { get; set; }

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// <para>Specifies whether to create unplaced annotation from unplaced labels.</para>
		/// <para>Unchecked—Annotation will only be created for features that are currently labeled. This is the default.</para>
		/// <para>Checked—Unplaced annotation are stored in the annotation feature class. The status field for these annotation is set to Unplaced.</para>
		/// <para><see cref="GenerateUnplacedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateUnplaced { get; set; } = "false";

		/// <summary>
		/// <para>Output Annotation Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutAnnoLayers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// </summary>
		public enum GenerateUnplacedEnum 
		{
			/// <summary>
			/// <para>Checked—Unplaced annotation are stored in the annotation feature class. The status field for these annotation is set to Unplaced.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED")]
			GENERATE_UNPLACED,

			/// <summary>
			/// <para>Unchecked—Annotation will only be created for features that are currently labeled. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_PLACED")]
			ONLY_PLACED,

		}

#endregion
	}
}
