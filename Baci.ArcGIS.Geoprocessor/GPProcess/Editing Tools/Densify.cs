using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Densify</para>
	/// <para>Adds vertices along line or polygon features and replaces curve segments (Bezier, circular arcs, and elliptical arcs) with line segments.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Densify : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygon or line feature class to be densified.</para>
		/// </param>
		public Densify(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Densify</para>
		/// </summary>
		public override string DisplayName() => "Densify";

		/// <summary>
		/// <para>Tool Name : Densify</para>
		/// </summary>
		public override string ToolName() => "Densify";

		/// <summary>
		/// <para>Tool Excute Name : edit.Densify</para>
		/// </summary>
		public override string ExcuteName() => "edit.Densify";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DensificationMethod, Distance, MaxDeviation, MaxAngle, OutFeatureClass, MaxVertexPerSegment };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon or line feature class to be densified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Densification Method</para>
		/// <para>Specifies the feature densification method to be used.</para>
		/// <para>Distance—Straight lines and curves will be densified using the specified distance. This is the default.</para>
		/// <para>Offset—Curves will be densified using the specified maximum offset deviation.</para>
		/// <para>Angle—Curves will be densified using the specified maximum deflection angle.</para>
		/// <para><see cref="DensificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DensificationMethod { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Distance</para>
		/// <para>The maximum distance between vertices. This distance will always be applied to line segments and to simplify curves. The default value is a function of the data&apos;s x,y tolerance.</para>
		/// <para>New vertices may not be inserted at this exact interval along the line, rather they will be inserted within this distance of the previous vertex. There is no way to ensure that a vertex is added exactly at the specified interval along the line segment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Distance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>The maximum distance the output segment will be from the original. This parameter only affects curves. The default value is a function of the data's x,y tolerance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxDeviation { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Maximum Deflection Angle (Degrees)</para>
		/// <para>The maximum angle the output geometry can be from the input geometry. The valid range is 0 to 90. The default value is 10. This parameter only affects curves.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = false, Value = 90)]
		public object MaxAngle { get; set; } = "10";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Vertex Count (per segment)</para>
		/// <para>The maximum vertex count allowed per segment. If no value or an invalid value (0 or less) is entered, there will be no vertex limit for linear segments, and curve segments will have a default of 12000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxVertexPerSegment { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Densify SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Densification Method</para>
		/// </summary>
		public enum DensificationMethodEnum 
		{
			/// <summary>
			/// <para>Distance—Straight lines and curves will be densified using the specified distance. This is the default.</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("Distance")]
			Distance,

			/// <summary>
			/// <para>Offset—Curves will be densified using the specified maximum offset deviation.</para>
			/// </summary>
			[GPValue("OFFSET")]
			[Description("Offset")]
			Offset,

			/// <summary>
			/// <para>Angle—Curves will be densified using the specified maximum deflection angle.</para>
			/// </summary>
			[GPValue("ANGLE")]
			[Description("Angle")]
			Angle,

		}

#endregion
	}
}
