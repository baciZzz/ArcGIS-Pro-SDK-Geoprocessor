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
	/// <para>Remove Cutback Vertices</para>
	/// <para>Remove Cutback Vertices</para>
	/// <para>Removes unwanted cutbacks from polyline and polygon features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveCutbackVertices : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polyline or polygon feature class from which cutback vertices will be removed. This feature class (or layer) will be modified.</para>
		/// </param>
		/// <param name="MinimumAngle">
		/// <para>Minimum Angle</para>
		/// <para>The minimum angle threshold value in degrees. The angle value should be within the range of 0–180. If the angle formed by a vertex and its two neighboring points is smaller than the specified minimum angle, the vertex is a candidate for cutback removal.</para>
		/// </param>
		public RemoveCutbackVertices(object InFeatures, object MinimumAngle)
		{
			this.InFeatures = InFeatures;
			this.MinimumAngle = MinimumAngle;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Cutback Vertices</para>
		/// </summary>
		public override string DisplayName() => "Remove Cutback Vertices";

		/// <summary>
		/// <para>Tool Name : RemoveCutbackVertices</para>
		/// </summary>
		public override string ToolName() => "RemoveCutbackVertices";

		/// <summary>
		/// <para>Tool Excute Name : topographic.RemoveCutbackVertices</para>
		/// </summary>
		public override string ExcuteName() => "topographic.RemoveCutbackVertices";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MinimumAngle, RemovalMethod!, SkipCoincidentVertices!, UpdatedFeatures! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polyline or polygon feature class from which cutback vertices will be removed. This feature class (or layer) will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Angle</para>
		/// <para>The minimum angle threshold value in degrees. The angle value should be within the range of 0–180. If the angle formed by a vertex and its two neighboring points is smaller than the specified minimum angle, the vertex is a candidate for cutback removal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MinimumAngle { get; set; }

		/// <summary>
		/// <para>Removal Method</para>
		/// <para>Specifies whether cutbacks will be removed sequentially (individually) or all at once.</para>
		/// <para>Sequential—Cutbacks will be removed sequentially for a feature. After a cutback is removed, the change in geometry is considered when determining cutbacks to the remaining vertices of a feature. This is the default.</para>
		/// <para>All—Cutbacks will be removed for all vertices at once.</para>
		/// <para><see cref="RemovalMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RemovalMethod { get; set; } = "SEQUENTIAL";

		/// <summary>
		/// <para>Skip vertices coincident between multiple features</para>
		/// <para>Specifies whether cutback vertices will be removed when the vertex is snapped to another feature in the same feature class.</para>
		/// <para>Checked—Cutback vertices with angles less than the specified Minimum Angle value will not be removed from the feature geometry if they are snapped to other features.</para>
		/// <para>Unchecked—Cutback vertices will be removed without considering whether they are snapped to other features. This is the default.</para>
		/// <para><see cref="SkipCoincidentVerticesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SkipCoincidentVertices { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Removal Method</para>
		/// </summary>
		public enum RemovalMethodEnum 
		{
			/// <summary>
			/// <para>Sequential—Cutbacks will be removed sequentially for a feature. After a cutback is removed, the change in geometry is considered when determining cutbacks to the remaining vertices of a feature. This is the default.</para>
			/// </summary>
			[GPValue("SEQUENTIAL")]
			[Description("Sequential")]
			Sequential,

			/// <summary>
			/// <para>All—Cutbacks will be removed for all vertices at once.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

		}

		/// <summary>
		/// <para>Skip vertices coincident between multiple features</para>
		/// </summary>
		public enum SkipCoincidentVerticesEnum 
		{
			/// <summary>
			/// <para>Unchecked—Cutback vertices will be removed without considering whether they are snapped to other features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SKIP_COINCIDENT")]
			SKIP_COINCIDENT,

			/// <summary>
			/// <para>Checked—Cutback vertices with angles less than the specified Minimum Angle value will not be removed from the feature geometry if they are snapped to other features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_COINCIDENT")]
			REMOVE_COINCIDENT,

		}

#endregion
	}
}
