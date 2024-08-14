using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Thin Hydrology Lines</para>
	/// <para>Generates a simplified hydrographic line network for display at a smaller scale. The resulting hydrographic network maintains the main arteries while thinning less significant features based on hierarchy, length, and spacing between features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ThinHydrologyLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The hydrography line feature to be thinned.</para>
		/// </param>
		/// <param name="InvisibilityField">
		/// <para>Invisibility Field</para>
		/// <para>Features that participate in the thinned hydrography collection will have a value of 0. Those that are extraneous have a value of 1. A layer definition query can be used to display the results.</para>
		/// </param>
		/// <param name="MinLength">
		/// <para>Minimum Length</para>
		/// <para>An indication of the shortest hydrographic segment that is sensible to display at the output scale. It defines a sense of the resolution or granularity of the resulting thinned hydrography. It should correspond to a length that is visually significant to include at the final scale. The results of this tool are a balanced compromise between the requirements posed by hierarchy, minimum length, minimum spacing, angle of connecting features, and directionality of the hydro geometry. Therefore, the minimum length value cannot necessarily be measured directly in the resulting feature set.</para>
		/// </param>
		public ThinHydrologyLines(object InFeatures, object InvisibilityField, object MinLength)
		{
			this.InFeatures = InFeatures;
			this.InvisibilityField = InvisibilityField;
			this.MinLength = MinLength;
		}

		/// <summary>
		/// <para>Tool Display Name : Thin Hydrology Lines</para>
		/// </summary>
		public override string DisplayName => "Thin Hydrology Lines";

		/// <summary>
		/// <para>Tool Name : ThinHydrologyLines</para>
		/// </summary>
		public override string ToolName => "ThinHydrologyLines";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ThinHydrologyLines</para>
		/// </summary>
		public override string ExcuteName => "topographic.ThinHydrologyLines";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, InvisibilityField, MinLength, MinSpacing!, HierarchyField!, IntersectingFeatures!, UnsplitLines!, UseAngles!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The hydrography line feature to be thinned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Invisibility Field</para>
		/// <para>Features that participate in the thinned hydrography collection will have a value of 0. Those that are extraneous have a value of 1. A layer definition query can be used to display the results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InvisibilityField { get; set; }

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>An indication of the shortest hydrographic segment that is sensible to display at the output scale. It defines a sense of the resolution or granularity of the resulting thinned hydrography. It should correspond to a length that is visually significant to include at the final scale. The results of this tool are a balanced compromise between the requirements posed by hierarchy, minimum length, minimum spacing, angle of connecting features, and directionality of the hydro geometry. Therefore, the minimum length value cannot necessarily be measured directly in the resulting feature set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinLength { get; set; }

		/// <summary>
		/// <para>Minimum Spacing</para>
		/// <para>An indication of the shortest distance between a hydrographic segment that is sensible to display at the output scale. If the spacing between two parallel trending features is smaller than this value, one of the features will be set as invisible. It defines a sense of the density of the resulting thinned hydrography. It should correspond to the distance between two parallel trending features that is visually significant to include at the final scale. When the density of features is too high (that is, the features are too closely spaced), at least one feature will be hidden. This can result in important features or features longer than the Minimum Length being hidden.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinSpacing { get; set; }

		/// <summary>
		/// <para>Hierarchy Field</para>
		/// <para>This field contains the hierarchical ranking of feature importance, where 1 is very important, and larger integers reflect decreasing importance. A value of 0 forces the feature to remain visible in the final results. It identifies the relative importance of features to help establish which features are significant. For optimal results, use no more than five levels of hierarchy. Input features with Hierarchy = 0 are considered locked and will remain visible, along with adjacent features necessary for connectivity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? HierarchyField { get; set; }

		/// <summary>
		/// <para>Intersecting Features</para>
		/// <para>If a segment is snapped to features in the provided layers, it will not be removed. An example would be a small river segment snapped to a lake. Even if the segment is under the Minimum Length, it would need to remain to ensure that it remains connected to the water body into which it flows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object? IntersectingFeatures { get; set; }

		/// <summary>
		/// <para>Unsplit Lines</para>
		/// <para>This will merge any split features in the Input Features to help ensure that the main waterway is preserved. If unchecked, the ends of the waterway may be removed due to them being under the Minimum Length.</para>
		/// <para>Checked—Features that are closed on both end points will be merged before thinning to preserve main hydrographic arteries that traverse a long distance. This is the default.</para>
		/// <para>Unchecked—Features will remain split before the thinning process.</para>
		/// <para><see cref="UnsplitLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UnsplitLines { get; set; } = "true";

		/// <summary>
		/// <para>Use intersection angles to determine main waterway</para>
		/// <para>If checked, the angles between waterway branches will be used to help determine the main waterway; the highest angle will be used. If unchecked, the longest branch will be considered part of the main waterway.</para>
		/// <para>Checked—In junctions with 3 or more waterways, features that are closer together in angle will be kept.</para>
		/// <para>Unchecked—In junctions with 3 or more waterways, features that are longer will be kept. This is the default.</para>
		/// <para><see cref="UseAnglesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseAngles { get; set; } = "false";

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Unsplit Lines</para>
		/// </summary>
		public enum UnsplitLinesEnum 
		{
			/// <summary>
			/// <para>Checked—Features that are closed on both end points will be merged before thinning to preserve main hydrographic arteries that traverse a long distance. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UNSPLIT_LINES")]
			UNSPLIT_LINES,

			/// <summary>
			/// <para>Unchecked—Features will remain split before the thinning process.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UNSPLIT_LINES")]
			NO_UNSPLIT_LINES,

		}

		/// <summary>
		/// <para>Use intersection angles to determine main waterway</para>
		/// </summary>
		public enum UseAnglesEnum 
		{
			/// <summary>
			/// <para>Checked—In junctions with 3 or more waterways, features that are closer together in angle will be kept.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_ANGLES")]
			USE_ANGLES,

			/// <summary>
			/// <para>Unchecked—In junctions with 3 or more waterways, features that are longer will be kept. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USE_ANGLES")]
			NO_USE_ANGLES,

		}

#endregion
	}
}
