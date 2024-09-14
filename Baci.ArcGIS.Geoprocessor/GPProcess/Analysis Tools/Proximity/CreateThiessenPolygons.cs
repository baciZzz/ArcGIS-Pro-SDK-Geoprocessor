using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Create Thiessen Polygons</para>
	/// <para>Create Thiessen Polygons</para>
	/// <para>Creates Thiessen polygons from point features.</para>
	/// </summary>
	public class CreateThiessenPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point input features from which Thiessen polygons will be generated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the Thiessen polygons that are generated from the point input features.</para>
		/// </param>
		public CreateThiessenPolygons(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Thiessen Polygons</para>
		/// </summary>
		public override string DisplayName() => "Create Thiessen Polygons";

		/// <summary>
		/// <para>Tool Name : CreateThiessenPolygons</para>
		/// </summary>
		public override string ToolName() => "CreateThiessenPolygons";

		/// <summary>
		/// <para>Tool Excute Name : analysis.CreateThiessenPolygons</para>
		/// </summary>
		public override string ExcuteName() => "analysis.CreateThiessenPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, FieldsToCopy };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point input features from which Thiessen polygons will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the Thiessen polygons that are generated from the point input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>Specifies which fields from the input features will be transferred to the output feature class.</para>
		/// <para>Only Feature ID—Only the FID field from the input features will be transferred to the output feature class. This is the default.</para>
		/// <para>All fields—All fields from the input features will be transferred to the output feature class.</para>
		/// <para><see cref="FieldsToCopyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldsToCopy { get; set; } = "ONLY_FID";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateThiessenPolygons SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Fields</para>
		/// </summary>
		public enum FieldsToCopyEnum 
		{
			/// <summary>
			/// <para>Only Feature ID—Only the FID field from the input features will be transferred to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("Only Feature ID")]
			Only_Feature_ID,

			/// <summary>
			/// <para>All fields—All fields from the input features will be transferred to the output feature class.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All fields")]
			All_fields,

		}

#endregion
	}
}
