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
	/// <para>Remove Small Lines</para>
	/// <para>Remove Small Lines</para>
	/// <para>Removes lines that are shorter than a specified minimum length and do not connect to other features on one end.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveSmallLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features that will have small lines removed.</para>
		/// </param>
		/// <param name="MinimumLength">
		/// <para>Minimum Length</para>
		/// <para>The minimum length for input lines. Features shorter than this distance will be removed.</para>
		/// </param>
		public RemoveSmallLines(object InFeatures, object MinimumLength)
		{
			this.InFeatures = InFeatures;
			this.MinimumLength = MinimumLength;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Small Lines</para>
		/// </summary>
		public override string DisplayName() => "Remove Small Lines";

		/// <summary>
		/// <para>Tool Name : RemoveSmallLines</para>
		/// </summary>
		public override string ToolName() => "RemoveSmallLines";

		/// <summary>
		/// <para>Tool Excute Name : topographic.RemoveSmallLines</para>
		/// </summary>
		public override string ExcuteName() => "topographic.RemoveSmallLines";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MinimumLength, MaximumAngle!, InIntersectingFeatures!, Recursive!, OutputFeatures!, SplitInputLines! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features that will have small lines removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>The minimum length for input lines. Features shorter than this distance will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinimumLength { get; set; }

		/// <summary>
		/// <para>Maximum Angle</para>
		/// <para>Any line below the minimum length that is within the defined angle of a consecutive line segment will be kept.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumAngle { get; set; }

		/// <summary>
		/// <para>Intersecting Features</para>
		/// <para>Additional intersecting features that the input features can be compared to when determining whether the feature is a small line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		[FeatureType("Simple", "ComplexEdge")]
		public object? InIntersectingFeatures { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Specifies whether small lines on the line features will be removed.</para>
		/// <para>Unchecked—All the small lines on lines will be removed. The remaining lines will not be analyzed to determine whether they are small lines. This is the default.</para>
		/// <para>Checked—The small lines will be removed from the lines and the remaining lines will be analyzed to determine whether they are considered small lines. If they do not meet the Minimum Length value, they will be considered small lines and removed.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutputFeatures { get; set; }

		/// <summary>
		/// <para>Split Input Lines</para>
		/// <para>Specifies whether the input line features will be split at all intersections before determining the small lines to remove.</para>
		/// <para>Checked—All lines in the input feature class will be split at intersections to ensure topological integrity. The length of the split features, not the original feature geometries, will be considered when applying the minimum length value to determine small lines. This is the default.</para>
		/// <para>Unchecked—The lines will not be split before determining the lines to remove. The length of the input feature geometries will be used when applying the minimum length value to determine small lines.</para>
		/// <para><see cref="SplitInputLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SplitInputLines { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—The small lines will be removed from the lines and the remaining lines will be analyzed to determine whether they are considered small lines. If they do not meet the Minimum Length value, they will be considered small lines and removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—All the small lines on lines will be removed. The remaining lines will not be analyzed to determine whether they are small lines. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_RECURSIVE")]
			NON_RECURSIVE,

		}

		/// <summary>
		/// <para>Split Input Lines</para>
		/// </summary>
		public enum SplitInputLinesEnum 
		{
			/// <summary>
			/// <para>Checked—All lines in the input feature class will be split at intersections to ensure topological integrity. The length of the split features, not the original feature geometries, will be considered when applying the minimum length value to determine small lines. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT")]
			SPLIT,

			/// <summary>
			/// <para>Unchecked—The lines will not be split before determining the lines to remove. The length of the input feature geometries will be used when applying the minimum length value to determine small lines.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPLIT")]
			NO_SPLIT,

		}

#endregion
	}
}
