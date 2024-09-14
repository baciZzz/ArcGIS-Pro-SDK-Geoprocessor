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
	/// <para>Simplify Line</para>
	/// <para>Simplify Line</para>
	/// <para>Simplifies lines by removing relatively extraneous vertices while preserving essential shape.</para>
	/// </summary>
	public class SimplifyLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input line features to be simplified.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The simplified output line feature class. It contains all fields present in the input feature class. The output line feature class is topologically correct. The tool does not introduce topology errors, but topological errors in the input data are flagged in the output line feature class. The output feature class includes two additional fields, InLine_FID and SimLnFlag, to contain the input feature IDs and the input topological errors, respectively. A SimLnFlag value of 1 indicates that an input topological error is present; a value of 0 (zero) indicates that no input error is present.</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para>Specifies the line simplification algorithm.</para>
		/// <para>Retain critical points (Douglas-Peucker)—Critical points that preserve the essential shape of a line are retained, and all other points are removed (Douglas-Peucker).This is the default.</para>
		/// <para>Retain critical bends (Wang-Müller)—Critical bends are retained, and extraneous bends are removed from a line (Wang-Müller).</para>
		/// <para>Retain weighted effective areas (Zhou-Jones)—Vertices that form triangles of effective area that have been weighted by triangle shape are retained (Zhou-Jones).</para>
		/// <para>Retain effective areas (Visvalingam-Whyatt)—Vertices that form triangles of effective area are retained (Visvalingam-Whyatt).</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>The tolerance determines the degree of simplification. You can choose a preferred unit; otherwise, units of the input will be used. The MinSimpTol and MaxSimpTol fields are added to the output to store the tolerance that was used when processing occurred.</para>
		/// <para>For the Retain critical points (Douglas-Peucker) algorithm, the tolerance is the maximum allowable perpendicular distance between each vertex and the new line created.</para>
		/// <para>For the Retain critical bends (Wang-Müller) algorithm, the tolerance is the diameter of a circle that approximates a significant bend.</para>
		/// <para>For the Retain weighted effective areas (Zhou-Jones) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices. The further a triangle deviates from equilateral, the higher weight it is given, and the less likely it is to be removed.</para>
		/// <para>For the Retain effective areas (Visvalingam-Whyatt) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices.</para>
		/// </param>
		public SimplifyLine(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify Line</para>
		/// </summary>
		public override string DisplayName() => "Simplify Line";

		/// <summary>
		/// <para>Tool Name : SimplifyLine</para>
		/// </summary>
		public override string ToolName() => "SimplifyLine";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SimplifyLine</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SimplifyLine";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, ErrorResolvingOption, CollapsedPointOption, ErrorCheckingOption, OutPointFeatureClass, InBarriers };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input line features to be simplified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The simplified output line feature class. It contains all fields present in the input feature class. The output line feature class is topologically correct. The tool does not introduce topology errors, but topological errors in the input data are flagged in the output line feature class. The output feature class includes two additional fields, InLine_FID and SimLnFlag, to contain the input feature IDs and the input topological errors, respectively. A SimLnFlag value of 1 indicates that an input topological error is present; a value of 0 (zero) indicates that no input error is present.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para>Specifies the line simplification algorithm.</para>
		/// <para>Retain critical points (Douglas-Peucker)—Critical points that preserve the essential shape of a line are retained, and all other points are removed (Douglas-Peucker).This is the default.</para>
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
		/// <para>For the Retain critical points (Douglas-Peucker) algorithm, the tolerance is the maximum allowable perpendicular distance between each vertex and the new line created.</para>
		/// <para>For the Retain critical bends (Wang-Müller) algorithm, the tolerance is the diameter of a circle that approximates a significant bend.</para>
		/// <para>For the Retain weighted effective areas (Zhou-Jones) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices. The further a triangle deviates from equilateral, the higher weight it is given, and the less likely it is to be removed.</para>
		/// <para>For the Retain effective areas (Visvalingam-Whyatt) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Resolve topological errors</para>
		/// <para>This is a legacy parameter that is no longer used. It was formerly used to indicate how topological errors, possibly introduced during processing, were resolved. This parameter is still included in the tool's syntax for compatibility in scripts and models but is hidden from the tool's dialog box.</para>
		/// <para><see cref="ErrorResolvingOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ErrorResolvingOption { get; set; } = "true";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para>Specifies whether an output point feature class will be created to store the endpoints of any lines that are smaller than the spatial tolerance. The point output is derived; it will use the same name and location as the Output feature class parameter but with a _Pnt suffix.</para>
		/// <para>Checked—A derived output point feature class will be created to store the endpoints of collapsed zero length lines. This is the default.</para>
		/// <para>Unchecked—A derived output point feature class will not be created.</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapsedPointOption { get; set; } = "true";

		/// <summary>
		/// <para>Check for topological errors</para>
		/// <para>This is a legacy parameter that is no longer used. It was formerly used to indicate how topological errors, possibly introduced during processing, were handled. This parameter is still included in the tool's syntax for compatibility in scripts and models but is hidden from the tool's dialog box.</para>
		/// <para><see cref="ErrorCheckingOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ErrorCheckingOption { get; set; } = "true";

		/// <summary>
		/// <para>Lines Collapsed To Zero Length</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>Inputs containing features to act as barriers for simplification. Resulting simplified lines will not touch or cross barrier features. For example, when simplifying contour lines, spot height features input as barriers ensure that the simplified contour lines will not simplify across these points. The output will not violate the elevation as described by measured spot heights.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyLine SetEnviroment(object MDomain = null, object XYDomain = null, object XYTolerance = null, object cartographicPartitions = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
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
			/// <para>Retain critical points (Douglas-Peucker)—Critical points that preserve the essential shape of a line are retained, and all other points are removed (Douglas-Peucker).This is the default.</para>
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
		/// <para>Resolve topological errors</para>
		/// </summary>
		public enum ErrorResolvingOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RESOLVE_ERRORS")]
			RESOLVE_ERRORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FLAG_ERRORS")]
			FLAG_ERRORS,

		}

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// </summary>
		public enum CollapsedPointOptionEnum 
		{
			/// <summary>
			/// <para>Checked—A derived output point feature class will be created to store the endpoints of collapsed zero length lines. This is the default.</para>
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

		/// <summary>
		/// <para>Check for topological errors</para>
		/// </summary>
		public enum ErrorCheckingOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CHECK")]
			CHECK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CHECK")]
			NO_CHECK,

		}

#endregion
	}
}
