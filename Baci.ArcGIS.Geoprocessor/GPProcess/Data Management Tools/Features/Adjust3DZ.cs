using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Adjust 3D Z</para>
	/// <para>Adjust 3D Z</para>
	/// <para>Modifies z-values of 3D features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Adjust3DZ : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The 3D features with the z-values that will be modified.</para>
		/// </param>
		public Adjust3DZ(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Adjust 3D Z</para>
		/// </summary>
		public override string DisplayName() => "Adjust 3D Z";

		/// <summary>
		/// <para>Tool Name : Adjust3DZ</para>
		/// </summary>
		public override string ToolName() => "Adjust3DZ";

		/// <summary>
		/// <para>Tool Excute Name : management.Adjust3DZ</para>
		/// </summary>
		public override string ExcuteName() => "management.Adjust3DZ";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ReverseSign, AdjustValue, FromUnits, ToUnits, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The 3D features with the z-values that will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Reverse Sign of Z Values</para>
		/// <para>Specifies whether features will be inverted along the z-axis.</para>
		/// <para>Reverse Z Orientation—The sign of z-values will be inverted causing the feature to flip upside down.</para>
		/// <para>Maintain Z Orientation—The sign of z-values will not be inverted; it will be maintained. This is the default.</para>
		/// <para><see cref="ReverseSignEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReverseSign { get; set; } = "NO_REVERSE";

		/// <summary>
		/// <para>Adjust Z Value</para>
		/// <para>A numeric value or field from the input features that will be used to adjust the z of each vertex in the input features. A positive value will shift the feature higher, while a negative number will shift it lower along the z-axis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object AdjustValue { get; set; } = "0";

		/// <summary>
		/// <para>Convert From Units</para>
		/// <para>Specifies the existing units of the z-values. This parameter is used in conjunction with the Convert To Units parameter.</para>
		/// <para>Millimeters—The units will be millimeters.</para>
		/// <para>Centimeters—The units will be centimeters.</para>
		/// <para>Meters—The units will be meters.</para>
		/// <para>Inches—The units will be inches.</para>
		/// <para>Feet—The units will be feet.</para>
		/// <para>Yards—The units will be yards.</para>
		/// <para>Fathoms—The units will be fathoms.</para>
		/// <para><see cref="FromUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FromUnits { get; set; }

		/// <summary>
		/// <para>Convert To Units</para>
		/// <para>Specifies the units that existing z-values will be converted to.</para>
		/// <para>Millimeters—The units will be millimeters.</para>
		/// <para>Centimeters—The units will be centimeters.</para>
		/// <para>Meters—The units will be meters.</para>
		/// <para>Inches—The units will be inches.</para>
		/// <para>Feet—The units will be feet.</para>
		/// <para>Yards—The units will be yards.</para>
		/// <para>Fathoms—The units will be fathoms.</para>
		/// <para><see cref="ToUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ToUnits { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Adjust3DZ SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reverse Sign of Z Values</para>
		/// </summary>
		public enum ReverseSignEnum 
		{
			/// <summary>
			/// <para>Maintain Z Orientation—The sign of z-values will not be inverted; it will be maintained. This is the default.</para>
			/// </summary>
			[GPValue("NO_REVERSE")]
			[Description("Maintain Z Orientation")]
			Maintain_Z_Orientation,

			/// <summary>
			/// <para>Reverse Z Orientation—The sign of z-values will be inverted causing the feature to flip upside down.</para>
			/// </summary>
			[GPValue("REVERSE")]
			[Description("Reverse Z Orientation")]
			Reverse_Z_Orientation,

		}

		/// <summary>
		/// <para>Convert From Units</para>
		/// </summary>
		public enum FromUnitsEnum 
		{
			/// <summary>
			/// <para>Millimeters—The units will be millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETERS")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para>Centimeters—The units will be centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETERS")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para>Meters—The units will be meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Inches—The units will be inches.</para>
			/// </summary>
			[GPValue("INCHES")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para>Feet—The units will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units will be yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Fathoms—The units will be fathoms.</para>
			/// </summary>
			[GPValue("FATHOMS")]
			[Description("Fathoms")]
			Fathoms,

		}

		/// <summary>
		/// <para>Convert To Units</para>
		/// </summary>
		public enum ToUnitsEnum 
		{
			/// <summary>
			/// <para>Millimeters—The units will be millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETERS")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para>Centimeters—The units will be centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETERS")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para>Meters—The units will be meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Inches—The units will be inches.</para>
			/// </summary>
			[GPValue("INCHES")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para>Feet—The units will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Yards—The units will be yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Fathoms—The units will be fathoms.</para>
			/// </summary>
			[GPValue("FATHOMS")]
			[Description("Fathoms")]
			Fathoms,

		}

#endregion
	}
}
