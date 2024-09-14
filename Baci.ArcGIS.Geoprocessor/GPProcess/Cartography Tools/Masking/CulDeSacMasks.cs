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
	/// <para>Cul-De-Sac Masks</para>
	/// <para>Cul-De-Sac Masks</para>
	/// <para>Creates a feature class of polygon masks from a symbolized input line layer.</para>
	/// </summary>
	public class CulDeSacMasks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The input line layer from which the masks will be created.</para>
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
		/// <param name="Attributes">
		/// <para>Transfer Attributes</para>
		/// <para>Specifies the attributes that will be transferred from the input features to the output features.</para>
		/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output features. This is the default.</para>
		/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output features.</para>
		/// <para>All attributes—All the attributes from the input features will be transferred to the output features.</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </param>
		public CulDeSacMasks(object InputLayer, object OutputFc, object ReferenceScale, object SpatialReference, object Margin, object Attributes)
		{
			this.InputLayer = InputLayer;
			this.OutputFc = OutputFc;
			this.ReferenceScale = ReferenceScale;
			this.SpatialReference = SpatialReference;
			this.Margin = Margin;
			this.Attributes = Attributes;
		}

		/// <summary>
		/// <para>Tool Display Name : Cul-De-Sac Masks</para>
		/// </summary>
		public override string DisplayName() => "Cul-De-Sac Masks";

		/// <summary>
		/// <para>Tool Name : CulDeSacMasks</para>
		/// </summary>
		public override string ToolName() => "CulDeSacMasks";

		/// <summary>
		/// <para>Tool Excute Name : cartography.CulDeSacMasks</para>
		/// </summary>
		public override string ExcuteName() => "cartography.CulDeSacMasks";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputFc, ReferenceScale, SpatialReference, Margin, Attributes };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input line layer from which the masks will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InputLayer { get; set; }

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
		[Low(Inclusive = true, Value = 0)]
		public object Margin { get; set; } = "0 Points";

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// <para>Specifies the attributes that will be transferred from the input features to the output features.</para>
		/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output features. This is the default.</para>
		/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output features.</para>
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
		public CulDeSacMasks SetEnviroment(object? cartographicCoordinateSystem = null)
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transfer Attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output features.</para>
			/// </summary>
			[GPValue("NO_FID")]
			[Description("All attributes except feature IDs")]
			All_attributes_except_feature_IDs,

			/// <summary>
			/// <para>Only feature IDs—Only the FID field from the input features will be transferred to the output features. This is the default.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only feature IDs")]
			Only_feature_IDs,

			/// <summary>
			/// <para>All attributes except feature IDs—All the attributes except the FID from the input features will be transferred to the output features.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All attributes")]
			All_attributes,

		}

#endregion
	}
}
