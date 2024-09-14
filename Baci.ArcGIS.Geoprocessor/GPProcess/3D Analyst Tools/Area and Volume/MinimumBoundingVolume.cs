using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Minimum Bounding Volume</para>
	/// <para>Minimum Bounding Volume</para>
	/// <para>Creates multipatch features that represent the volume of space occupied by a set of 3D features.</para>
	/// </summary>
	public class MinimumBoundingVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The LAS dataset or 3D features whose minimum bounding volume will be evaluated.</para>
		/// </param>
		/// <param name="ZValue">
		/// <para>Z Value</para>
		/// <para>The source of z-values for the input data.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		public MinimumBoundingVolume(object InFeatures, object ZValue, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.ZValue = ZValue;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Minimum Bounding Volume</para>
		/// </summary>
		public override string DisplayName() => "Minimum Bounding Volume";

		/// <summary>
		/// <para>Tool Name : MinimumBoundingVolume</para>
		/// </summary>
		public override string ToolName() => "MinimumBoundingVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.MinimumBoundingVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.MinimumBoundingVolume";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ZValue, OutFeatureClass, GeometryType, Group, GroupField, MbvFields };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The LAS dataset or 3D features whose minimum bounding volume will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z Value</para>
		/// <para>The source of z-values for the input data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		[KeyField("Shape.Z")]
		public object ZValue { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>Specifies the method that will be used to determine the geometry of the minimum bounding volume.</para>
		/// <para>Convex hull—The smallest convex region surrounding the input data.</para>
		/// <para>Sphere—The smallest sphere enclosing the input data.</para>
		/// <para>Envelope—The XYZ extent of the input data.</para>
		/// <para>Concave hull—The concave hull that encloses the input data.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "CONVEX_HULL";

		/// <summary>
		/// <para>Group Options</para>
		/// <para>Specifies how the input features will be grouped; each group will be enclosed with one output multipatch.</para>
		/// <para>None—Input features will not be grouped. This is the default. This option is not available for point input.</para>
		/// <para>All—All input features will be treated as one group.</para>
		/// <para>List—Input features will be grouped based on their common values in the specified field or fields in the group field parameter.</para>
		/// <para><see cref="GroupEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Group { get; set; } = "NONE";

		/// <summary>
		/// <para>Group Field(s)</para>
		/// <para>The field or fields in the input features that will be used to group features when List is specified as Group Option. At least one group field is required for the List option. All features that have the same value in the specified field or fields will be treated as a group.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object GroupField { get; set; }

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// <para>Specifies whether each feature will be attributed with the volume and surface area of the minimum bounding volume.</para>
		/// <para>Unchecked—No geometric attributes will be added to the output feature. This is the default.</para>
		/// <para>Checked—Geometric attributes will be added to the output feature.</para>
		/// <para><see cref="MbvFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MbvFields { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MinimumBoundingVolume SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Convex hull—The smallest convex region surrounding the input data.</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("Convex hull")]
			Convex_hull,

			/// <summary>
			/// <para>Sphere—The smallest sphere enclosing the input data.</para>
			/// </summary>
			[GPValue("SPHERE")]
			[Description("Sphere")]
			Sphere,

			/// <summary>
			/// <para>Envelope—The XYZ extent of the input data.</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("Envelope")]
			Envelope,

			/// <summary>
			/// <para>Concave hull—The concave hull that encloses the input data.</para>
			/// </summary>
			[GPValue("CONCAVE_HULL")]
			[Description("Concave hull")]
			Concave_hull,

		}

		/// <summary>
		/// <para>Group Options</para>
		/// </summary>
		public enum GroupEnum 
		{
			/// <summary>
			/// <para>None—Input features will not be grouped. This is the default. This option is not available for point input.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>All—All input features will be treated as one group.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>List—Input features will be grouped based on their common values in the specified field or fields in the group field parameter.</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("List")]
			List,

		}

		/// <summary>
		/// <para>Add geometry characteristics as attributes to output</para>
		/// </summary>
		public enum MbvFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—Geometric attributes will be added to the output feature.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MBV_FIELDS")]
			MBV_FIELDS,

			/// <summary>
			/// <para>Unchecked—No geometric attributes will be added to the output feature. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MBV_FIELDS")]
			NO_MBV_FIELDS,

		}

#endregion
	}
}
