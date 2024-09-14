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
	/// <para>Simplify Polygon</para>
	/// <para>Simplify Polygon</para>
	/// <para>Simplifies polygon features by removing relatively extraneous vertices while preserving essential shape.</para>
	/// </summary>
	public class SimplifyPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input polygon features to be simplified.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The simplified output polygon feature class. It contains all fields present in the input feature class. The output polygon feature class is topologically correct. The tool does not introduce topology errors, but topological errors in the input data are flagged in the output polygon feature class.</para>
		/// <para>The output feature class includes two additional fields, InPoly_FID and SimPgnFlag, that contain the input feature IDs and the input topological errors or discrepancies, respectively.</para>
		/// <para>SimPgnFlag attribute values are as follows:</para>
		/// <para>SimPgnFlag = 0 indicates that no errors are present.</para>
		/// <para>SimPgnFlag = 1 indicates a topological error is present.</para>
		/// <para>SimPgnFlag = 2 indicates features that have been split by a partition and are now smaller than the minimum area after simplification. The flag may appear on only one part of the split feature. These features are all retained in the output feature class. This situation occurs only when the Cartographic Partitions environment setting is used.</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para>Specifies the polygon simplification algorithm.</para>
		/// <para>Retain critical points (Douglas-Peucker)—Critical points that preserve the essential shape of a polygon outline are retained, and all other points are removed (Douglas-Peucker). This is the default.</para>
		/// <para>Retain critical bends (Wang-Müller)—Critical bends are retained, and extraneous bends are removed from a line (Wang-Müller).</para>
		/// <para>Retain weighted effective areas (Zhou-Jones)—Vertices that form triangles of effective area that have been weighted by triangle shape are retained (Zhou-Jones).</para>
		/// <para>Retain effective areas (Visvalingam-Whyatt)—Vertices that form triangles of effective area are retained (Visvalingam-Whyatt).</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance determines the degree of simplification. You can choose a preferred unit; otherwise, units of the input will be used. The MinSimpTol and MaxSimpTol fields are added to the output to store the tolerance that was used when processing occurred.</para>
		/// <para>For the Retain critical points (Douglas-Peucker) algorithm, the tolerance is the maximum allowable perpendicular distance between each vertex and the newly created line.</para>
		/// <para>For the Retain critical bends (Wang-Müller) algorithm, the tolerance is the diameter of a circle that approximates a significant bend.</para>
		/// <para>For the Retain weighted effective areas (Zhou-Jones) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices. The further a triangle deviates from equilateral, the higher weight it is given, and the less likely it is to be removed.</para>
		/// <para>For the Retain effective areas (Visvalingam-Whyatt) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices.</para>
		/// </param>
		public SimplifyPolygon(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify Polygon</para>
		/// </summary>
		public override string DisplayName() => "Simplify Polygon";

		/// <summary>
		/// <para>Tool Name : SimplifyPolygon</para>
		/// </summary>
		public override string ToolName() => "SimplifyPolygon";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SimplifyPolygon</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SimplifyPolygon";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "XYTolerance", "cartographicPartitions", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, MinimumArea, ErrorOption, CollapsedPointOption, OutPointFeatureClass, InBarriers };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input polygon features to be simplified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The simplified output polygon feature class. It contains all fields present in the input feature class. The output polygon feature class is topologically correct. The tool does not introduce topology errors, but topological errors in the input data are flagged in the output polygon feature class.</para>
		/// <para>The output feature class includes two additional fields, InPoly_FID and SimPgnFlag, that contain the input feature IDs and the input topological errors or discrepancies, respectively.</para>
		/// <para>SimPgnFlag attribute values are as follows:</para>
		/// <para>SimPgnFlag = 0 indicates that no errors are present.</para>
		/// <para>SimPgnFlag = 1 indicates a topological error is present.</para>
		/// <para>SimPgnFlag = 2 indicates features that have been split by a partition and are now smaller than the minimum area after simplification. The flag may appear on only one part of the split feature. These features are all retained in the output feature class. This situation occurs only when the Cartographic Partitions environment setting is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para>Specifies the polygon simplification algorithm.</para>
		/// <para>Retain critical points (Douglas-Peucker)—Critical points that preserve the essential shape of a polygon outline are retained, and all other points are removed (Douglas-Peucker). This is the default.</para>
		/// <para>Retain critical bends (Wang-Müller)—Critical bends are retained, and extraneous bends are removed from a line (Wang-Müller).</para>
		/// <para>Retain weighted effective areas (Zhou-Jones)—Vertices that form triangles of effective area that have been weighted by triangle shape are retained (Zhou-Jones).</para>
		/// <para>Retain effective areas (Visvalingam-Whyatt)—Vertices that form triangles of effective area are retained (Visvalingam-Whyatt).</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "POINT_REMOVE";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance determines the degree of simplification. You can choose a preferred unit; otherwise, units of the input will be used. The MinSimpTol and MaxSimpTol fields are added to the output to store the tolerance that was used when processing occurred.</para>
		/// <para>For the Retain critical points (Douglas-Peucker) algorithm, the tolerance is the maximum allowable perpendicular distance between each vertex and the newly created line.</para>
		/// <para>For the Retain critical bends (Wang-Müller) algorithm, the tolerance is the diameter of a circle that approximates a significant bend.</para>
		/// <para>For the Retain weighted effective areas (Zhou-Jones) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices. The further a triangle deviates from equilateral, the higher weight it is given, and the less likely it is to be removed.</para>
		/// <para>For the Retain effective areas (Visvalingam-Whyatt) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>The minimum area for a polygon to be retained. The default value is zero, that is, to keep all polygons. You can choose a preferred unit for the specified value; otherwise, units of the input will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para>This is a legacy parameter that is no longer used. It was formerly used to specify how topological errors possibly introduced during processing were handled. This parameter is still included in the tool's syntax for compatibility in scripts and model but is hidden from the tool's dialog box.</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ErrorOption { get; set; } = "RESOLVE_ERRORS";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para>Specifies whether an output point feature class will be created to store the centers of polygons that are removed because they are smaller than the Minimum area parameter value. The point output is derived; it will use the same name and location as the Output feature class parameter but with a _Pnt suffix.</para>
		/// <para>Checked—A derived output point feature class will be created to store the centers of polygons that are removed because they are smaller than the minimum area. This is the default.</para>
		/// <para>Unchecked—A derived output point feature class will not be created.</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapsedPointOption { get; set; } = "true";

		/// <summary>
		/// <para>Polygons Collapsed To Zero Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>The inputs containing features to act as barriers for simplification. Resulting simplified polygons will not touch or cross barrier features. For example, when simplifying forested areas, the resulting simplified forest polygons will not cross road features defined as barriers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyPolygon SetEnviroment(object MDomain = null, object XYDomain = null, object XYTolerance = null, object cartographicPartitions = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para>Retain critical points (Douglas-Peucker)—Critical points that preserve the essential shape of a polygon outline are retained, and all other points are removed (Douglas-Peucker). This is the default.</para>
			/// </summary>
			[GPValue("POINT_REMOVE")]
			[Description("Retain critical points (Douglas-Peucker)")]
			POINT_REMOVE,

			/// <summary>
			/// <para>Retain critical bends (Wang-Müller)—Critical bends are retained, and extraneous bends are removed from a line (Wang-Müller).</para>
			/// </summary>
			[GPValue("BEND_SIMPLIFY")]
			[Description("Retain critical bends (Wang-Müller)")]
			BEND_SIMPLIFY,

			/// <summary>
			/// <para>Retain weighted effective areas (Zhou-Jones)—Vertices that form triangles of effective area that have been weighted by triangle shape are retained (Zhou-Jones).</para>
			/// </summary>
			[GPValue("WEIGHTED_AREA")]
			[Description("Retain weighted effective areas (Zhou-Jones)")]
			WEIGHTED_AREA,

			/// <summary>
			/// <para>Retain effective areas (Visvalingam-Whyatt)—Vertices that form triangles of effective area are retained (Visvalingam-Whyatt).</para>
			/// </summary>
			[GPValue("EFFECTIVE_AREA")]
			[Description("Retain effective areas (Visvalingam-Whyatt)")]
			EFFECTIVE_AREA,

		}

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// </summary>
		public enum ErrorOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_CHECK")]
			[Description("NO_CHECK")]
			NO_CHECK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FLAG_ERRORS")]
			[Description("FLAG_ERRORS")]
			FLAG_ERRORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RESOLVE_ERRORS")]
			[Description("RESOLVE_ERRORS")]
			RESOLVE_ERRORS,

		}

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// </summary>
		public enum CollapsedPointOptionEnum 
		{
			/// <summary>
			/// <para>Checked—A derived output point feature class will be created to store the centers of polygons that are removed because they are smaller than the minimum area. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_COLLAPSED_POINTS")]
			KEEP_COLLAPSED_POINTS,

			/// <summary>
			/// <para>Unchecked—A derived output point feature class will not be created.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

		}

#endregion
	}
}
