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
	/// <para>Graphics To Features</para>
	/// <para>Graphics To Features</para>
	/// <para>Converts a graphics layer into a feature layer with geometries based on the input graphics layer's elements.</para>
	/// </summary>
	public class GraphicsToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Graphics</para>
		/// <para>The graphics layer containing the source graphic elements that will be converted to features.</para>
		/// </param>
		/// <param name="GraphicsType">
		/// <para>Graphics Type</para>
		/// <para>Specifies the type of graphic element that will be converted.</para>
		/// <para>Point—Point graphic elements will be converted.</para>
		/// <para>Polyline—Polyline graphic elements will be converted.</para>
		/// <para>Polygon—Polygon graphic elements will be converted.</para>
		/// <para>Multipoint—Multipoint graphic elements will be converted.</para>
		/// <para>Annotation—Annotation and text graphic elements will be converted.</para>
		/// <para><see cref="GraphicsTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature layer that will contain the converted graphic elements.</para>
		/// </param>
		public GraphicsToFeatures(object InLayer, object GraphicsType, object OutFeatureClass)
		{
			this.InLayer = InLayer;
			this.GraphicsType = GraphicsType;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Graphics To Features</para>
		/// </summary>
		public override string DisplayName() => "Graphics To Features";

		/// <summary>
		/// <para>Tool Name : GraphicsToFeatures</para>
		/// </summary>
		public override string ToolName() => "GraphicsToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GraphicsToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GraphicsToFeatures";

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
		public override object[] Parameters() => new object[] { InLayer, GraphicsType, OutFeatureClass, DeleteGraphics!, ReferenceScale!, UpdatedLayer! };

		/// <summary>
		/// <para>Input Graphics</para>
		/// <para>The graphics layer containing the source graphic elements that will be converted to features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGraphicsLayer()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Graphics Type</para>
		/// <para>Specifies the type of graphic element that will be converted.</para>
		/// <para>Point—Point graphic elements will be converted.</para>
		/// <para>Polyline—Polyline graphic elements will be converted.</para>
		/// <para>Polygon—Polygon graphic elements will be converted.</para>
		/// <para>Multipoint—Multipoint graphic elements will be converted.</para>
		/// <para>Annotation—Annotation and text graphic elements will be converted.</para>
		/// <para><see cref="GraphicsTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GraphicsType { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature layer that will contain the converted graphic elements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Delete graphics after conversion</para>
		/// <para>Specifies whether the converted graphic elements from the Input Graphics parameter will be deleted after conversion.</para>
		/// <para>Checked—The graphic elements will be deleted. This is the default.</para>
		/// <para>Unchecked—The graphic elements will not be deleted; they will be preserved.</para>
		/// <para><see cref="DeleteGraphicsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteGraphics { get; set; } = "true";

		/// <summary>
		/// <para>Reference Scale</para>
		/// <para>The reference scale that will be used to convert text elements to annotation features. This parameter is required when the Graphics Type parameter is set to Annotation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ReferenceScale { get; set; }

		/// <summary>
		/// <para>Updated layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? UpdatedLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GraphicsToFeatures SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Graphics Type</para>
		/// </summary>
		public enum GraphicsTypeEnum 
		{
			/// <summary>
			/// <para>Point—Point graphic elements will be converted.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polyline—Polyline graphic elements will be converted.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

			/// <summary>
			/// <para>Polygon—Polygon graphic elements will be converted.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Multipoint—Multipoint graphic elements will be converted.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Annotation—Annotation and text graphic elements will be converted.</para>
			/// </summary>
			[GPValue("ANNOTATION")]
			[Description("Annotation")]
			Annotation,

		}

		/// <summary>
		/// <para>Delete graphics after conversion</para>
		/// </summary>
		public enum DeleteGraphicsEnum 
		{
			/// <summary>
			/// <para>Checked—The graphic elements will be deleted. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_GRAPHICS")]
			DELETE_GRAPHICS,

			/// <summary>
			/// <para>Unchecked—The graphic elements will not be deleted; they will be preserved.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_GRAPHICS")]
			KEEP_GRAPHICS,

		}

#endregion
	}
}
