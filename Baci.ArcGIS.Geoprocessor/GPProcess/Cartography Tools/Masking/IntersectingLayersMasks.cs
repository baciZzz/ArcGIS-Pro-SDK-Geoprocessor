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
	/// <para>Intersecting Layers Masks</para>
	/// <para>Creates masking polygons at a specified shape and size at the intersection of two symbolized input layers: the masking layer and the masked layer.</para>
	/// </summary>
	public class IntersectingLayersMasks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="MaskingLayer">
		/// <para>Masking Layer</para>
		/// <para>The symbolized input layer that will intersect the masked layer to create masking polygons. This is the layer that will be prominently displayed when masking is applied to the masked layer.</para>
		/// </param>
		/// <param name="MaskedLayer">
		/// <para>Masked Layer</para>
		/// <para>The symbolized input layer to be masked. This is the layer that will be obscured by the masking polygons.</para>
		/// </param>
		/// <param name="OutputFc">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the mask features.</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference Scale</para>
		/// <para>The reference scale used for calculating the masking geometry when masks are specified in page units. This is typically the reference scale of the map.</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Calculation coordinate system</para>
		/// <para>The spatial reference of the map in which the masking polygons will be created. This is not the spatial reference that will be assigned to the output feature class. It is the spatial reference of the map in which the masking polygons will be used, since the position of symbology may change when features are projected.</para>
		/// </param>
		/// <param name="Margin">
		/// <para>Margin</para>
		/// <para>The space in page units surrounding the symbolized input features used to create the mask polygons. Typically, masking polygons are created with a small margin around the symbol to improve visual appearance. Margin values are specified in either page units or map units. Most of the time, you will specify your margin distance value in page units.</para>
		/// <para>The margin cannot be negative.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Mask Kind</para>
		/// <para>Specifies the type of masking geometry created.</para>
		/// <para>Box—A polygon representing the extent of the symbolized feature.</para>
		/// <para>Convex hull—The convex hull of the symbolized geometry of the feature. This is the default.</para>
		/// <para>Exact simplified—A generalized polygon representing the exact shape of the symbolized feature. Polygons created with this method will have a significantly smaller number of vertices compared to polygons created with the EXACT method.</para>
		/// <para>Exact—A polygon representing the exact shape of the symbolized feature.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="MaskForNonPlacedAnno">
		/// <para>Create masks for unplaced annotation</para>
		/// <para>Specifies whether to create masks for unplaced annotation. This option is only used when masking geodatabase annotation layers.</para>
		/// <para>All annotation features—Creates masks for all the annotation features.</para>
		/// <para>Only placed annotation features—Only creates masks for features with a status of placed.</para>
		/// <para><see cref="MaskForNonPlacedAnnoEnum"/></para>
		/// </param>
		/// <param name="Attributes">
		/// <para>Transfer Attributes</para>
		/// <para>Specifies the attributes that will be transferred from the input features to the output features.</para>
		/// <para>Only the FID field—Only the FID field from the input features will be transferred to the output features. This is the default.</para>
		/// <para>All attributes except the FID field—All the attributes except the FID from the input features will be transferred to the output features.</para>
		/// <para>All attributes—All the attributes from the input features will be transferred to the output features.</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </param>
		public IntersectingLayersMasks(object MaskingLayer, object MaskedLayer, object OutputFc, object ReferenceScale, object SpatialReference, object Margin, object Method, object MaskForNonPlacedAnno, object Attributes)
		{
			this.MaskingLayer = MaskingLayer;
			this.MaskedLayer = MaskedLayer;
			this.OutputFc = OutputFc;
			this.ReferenceScale = ReferenceScale;
			this.SpatialReference = SpatialReference;
			this.Margin = Margin;
			this.Method = Method;
			this.MaskForNonPlacedAnno = MaskForNonPlacedAnno;
			this.Attributes = Attributes;
		}

		/// <summary>
		/// <para>Tool Display Name : Intersecting Layers Masks</para>
		/// </summary>
		public override string DisplayName => "Intersecting Layers Masks";

		/// <summary>
		/// <para>Tool Name : IntersectingLayersMasks</para>
		/// </summary>
		public override string ToolName => "IntersectingLayersMasks";

		/// <summary>
		/// <para>Tool Excute Name : cartography.IntersectingLayersMasks</para>
		/// </summary>
		public override string ExcuteName => "cartography.IntersectingLayersMasks";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicCoordinateSystem", "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { MaskingLayer, MaskedLayer, OutputFc, ReferenceScale, SpatialReference, Margin, Method, MaskForNonPlacedAnno, Attributes };

		/// <summary>
		/// <para>Masking Layer</para>
		/// <para>The symbolized input layer that will intersect the masked layer to create masking polygons. This is the layer that will be prominently displayed when masking is applied to the masked layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		public object MaskingLayer { get; set; }

		/// <summary>
		/// <para>Masked Layer</para>
		/// <para>The symbolized input layer to be masked. This is the layer that will be obscured by the masking polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		public object MaskedLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the mask features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFc { get; set; }

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>The reference scale used for calculating the masking geometry when masks are specified in page units. This is typically the reference scale of the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Calculation coordinate system</para>
		/// <para>The spatial reference of the map in which the masking polygons will be created. This is not the spatial reference that will be assigned to the output feature class. It is the spatial reference of the map in which the masking polygons will be used, since the position of symbology may change when features are projected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Margin</para>
		/// <para>The space in page units surrounding the symbolized input features used to create the mask polygons. Typically, masking polygons are created with a small margin around the symbol to improve visual appearance. Margin values are specified in either page units or map units. Most of the time, you will specify your margin distance value in page units.</para>
		/// <para>The margin cannot be negative.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		public object Margin { get; set; } = "0 Points";

		/// <summary>
		/// <para>Mask Kind</para>
		/// <para>Specifies the type of masking geometry created.</para>
		/// <para>Box—A polygon representing the extent of the symbolized feature.</para>
		/// <para>Convex hull—The convex hull of the symbolized geometry of the feature. This is the default.</para>
		/// <para>Exact simplified—A generalized polygon representing the exact shape of the symbolized feature. Polygons created with this method will have a significantly smaller number of vertices compared to polygons created with the EXACT method.</para>
		/// <para>Exact—A polygon representing the exact shape of the symbolized feature.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "CONVEX_HULL";

		/// <summary>
		/// <para>Create masks for unplaced annotation</para>
		/// <para>Specifies whether to create masks for unplaced annotation. This option is only used when masking geodatabase annotation layers.</para>
		/// <para>All annotation features—Creates masks for all the annotation features.</para>
		/// <para>Only placed annotation features—Only creates masks for features with a status of placed.</para>
		/// <para><see cref="MaskForNonPlacedAnnoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MaskForNonPlacedAnno { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// <para>Specifies the attributes that will be transferred from the input features to the output features.</para>
		/// <para>Only the FID field—Only the FID field from the input features will be transferred to the output features. This is the default.</para>
		/// <para>All attributes except the FID field—All the attributes except the FID from the input features will be transferred to the output features.</para>
		/// <para>All attributes—All the attributes from the input features will be transferred to the output features.</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Attributes { get; set; } = "ONLY_FID";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IntersectingLayersMasks SetEnviroment(object cartographicCoordinateSystem = null , object cartographicPartitions = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mask Kind</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Box—A polygon representing the extent of the symbolized feature.</para>
			/// </summary>
			[GPValue("BOX")]
			[Description("Box")]
			Box,

			/// <summary>
			/// <para>Convex hull—The convex hull of the symbolized geometry of the feature. This is the default.</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("Convex hull")]
			Convex_hull,

			/// <summary>
			/// <para>Exact simplified—A generalized polygon representing the exact shape of the symbolized feature. Polygons created with this method will have a significantly smaller number of vertices compared to polygons created with the EXACT method.</para>
			/// </summary>
			[GPValue("EXACT_SIMPLIFIED")]
			[Description("Exact simplified")]
			Exact_simplified,

			/// <summary>
			/// <para>Exact simplified—A generalized polygon representing the exact shape of the symbolized feature. Polygons created with this method will have a significantly smaller number of vertices compared to polygons created with the EXACT method.</para>
			/// </summary>
			[GPValue("EXACT")]
			[Description("Exact")]
			Exact,

		}

		/// <summary>
		/// <para>Create masks for unplaced annotation</para>
		/// </summary>
		public enum MaskForNonPlacedAnnoEnum 
		{
			/// <summary>
			/// <para>All annotation features—Creates masks for all the annotation features.</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("All annotation features")]
			All_annotation_features,

			/// <summary>
			/// <para>Only placed annotation features—Only creates masks for features with a status of placed.</para>
			/// </summary>
			[GPValue("ONLY_PLACED")]
			[Description("Only placed annotation features")]
			Only_placed_annotation_features,

		}

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>All attributes except the FID field—All the attributes except the FID from the input features will be transferred to the output features.</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("All attributes except the FID field")]
			All_attributes_except_the_FID_field,

			/// <summary>
			/// <para>Only the FID field—Only the FID field from the input features will be transferred to the output features. This is the default.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only the FID field")]
			Only_the_FID_field,

			/// <summary>
			/// <para>All attributes except the FID field—All the attributes except the FID from the input features will be transferred to the output features.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All attributes")]
			All_attributes,

		}

#endregion
	}
}
