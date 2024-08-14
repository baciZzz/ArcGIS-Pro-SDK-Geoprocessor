using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Convert Raster To Feature</para>
	/// <para>Converts a raster to a feature dataset as points, lines, or polygons.</para>
	/// </summary>
	public class ConvertRasterToFeature : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputraster">
		/// <para>Input Raster Layer</para>
		/// <para>The input raster layer.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The output feature class that will contain the converted points, lines, or polygons.</para>
		/// </param>
		public ConvertRasterToFeature(object Inputraster, object Outputname)
		{
			this.Inputraster = Inputraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Raster To Feature</para>
		/// </summary>
		public override string DisplayName => "Convert Raster To Feature";

		/// <summary>
		/// <para>Tool Name : ConvertRasterToFeature</para>
		/// </summary>
		public override string ToolName => "ConvertRasterToFeature";

		/// <summary>
		/// <para>Tool Excute Name : ra.ConvertRasterToFeature</para>
		/// </summary>
		public override string ExcuteName => "ra.ConvertRasterToFeature";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputraster, Field, Outputtype, Simplifylinesorpolygons, Outputname, Outputfeatures, Createmultipartfeatures, Maxverticesperfeature };

		/// <summary>
		/// <para>Input Raster Layer</para>
		/// <para>The input raster layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputraster { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>A field that specifies the conversion value.</para>
		/// <para>It can be any integer or text value.</para>
		/// <para>A field containing floating-point values can only be used if the output is to a point dataset.</para>
		/// <para>The default is the Value field, which contains the value in each raster cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Field { get; set; } = "Value";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the output type.</para>
		/// <para>Point—The raster will be converted to a point dataset. This is the default.</para>
		/// <para>Line—The raster will be converted to a line feature dataset.</para>
		/// <para>Polygon—The raster will be converted to a polygon feature dataset.</para>
		/// <para>If the output type is Line or Polygon, an additional parameter appears allowing the simplification of lines or polygons.</para>
		/// <para><see cref="OutputtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Outputtype { get; set; } = "POINT";

		/// <summary>
		/// <para>Simplify Lines or Polygons</para>
		/// <para>Specifies whether lines or polygons will be simplified (smoothed). The smoothing is done in such a way that the line contains a minimum number of segments while remaining as close as possible to the original raster cell edges.</para>
		/// <para>Checked—The line or polygon features will be smoothed to produce a more generalized result. This is the default.</para>
		/// <para>Unchecked—The line or polygon features will not be smoothed and will follow the cell boundaries of the raster dataset.</para>
		/// <para><see cref="SimplifylinesorpolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Simplifylinesorpolygons { get; set; } = "true";

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The output feature class that will contain the converted points, lines, or polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Output Feature</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object Outputfeatures { get; set; }

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// <para>Specifies whether the output polygons will consist of single-part or multipart features.</para>
		/// <para>Checked— Multipart features will be created based on polygons that have the same value.</para>
		/// <para>Unchecked— Individual (single-part) features will be created for each polygon. This is the default.</para>
		/// <para><see cref="CreatemultipartfeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Createmultipartfeatures { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Vertices Per Polygon Feature</para>
		/// <para>The vertex limit used to subdivide a polygon into smaller polygons. This parameter produces similar output as that created by the Dice tool in the Data Management toolbox.</para>
		/// <para>If left empty, the output polygons will not be split. This is the default.</para>
		/// <para>This parameter is only supported if Output Type is Polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Maxverticesperfeature { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertRasterToFeature SetEnviroment(object extent = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputtypeEnum 
		{
			/// <summary>
			/// <para>Point—The raster will be converted to a point dataset. This is the default.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Line—The raster will be converted to a line feature dataset.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Polygon—The raster will be converted to a polygon feature dataset.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

		}

		/// <summary>
		/// <para>Simplify Lines or Polygons</para>
		/// </summary>
		public enum SimplifylinesorpolygonsEnum 
		{
			/// <summary>
			/// <para>Checked—The line or polygon features will be smoothed to produce a more generalized result. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SIMPLIFY")]
			SIMPLIFY,

			/// <summary>
			/// <para>Unchecked—The line or polygon features will not be smoothed and will follow the cell boundaries of the raster dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SIMPLIFY")]
			NO_SIMPLIFY,

		}

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// </summary>
		public enum CreatemultipartfeaturesEnum 
		{
			/// <summary>
			/// <para>Checked— Multipart features will be created based on polygons that have the same value.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPLE_OUTER_PART")]
			MULTIPLE_OUTER_PART,

			/// <summary>
			/// <para>Unchecked— Individual (single-part) features will be created for each polygon. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_OUTER_PART")]
			SINGLE_OUTER_PART,

		}

#endregion
	}
}
