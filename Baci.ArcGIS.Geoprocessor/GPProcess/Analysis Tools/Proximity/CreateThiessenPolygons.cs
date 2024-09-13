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
	/// <para>创建泰森多边形</para>
	/// <para>根据点要素创建泰森多边形。</para>
	/// </summary>
	public class CreateThiessenPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>生成泰森多边形所依据的点输入要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含根据点输入要素生成的泰森多边形的输出要素类。</para>
		/// </param>
		public CreateThiessenPolygons(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建泰森多边形</para>
		/// </summary>
		public override string DisplayName() => "创建泰森多边形";

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
		/// <para>生成泰森多边形所依据的点输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含根据点输入要素生成的泰森多边形的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Fields</para>
		/// <para>指定将输入要素的哪些字段传递到输出要素类。</para>
		/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。 这是默认设置。</para>
		/// <para>所有字段—输入要素的所有字段都将传递到输出要素类。</para>
		/// <para><see cref="FieldsToCopyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldsToCopy { get; set; } = "ONLY_FID";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateThiessenPolygons SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
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
			/// <para>仅要素 ID—仅输入要素的 FID 字段将传递到输出要素类。 这是默认设置。</para>
			/// </summary>
			[GPValue("ONLY_FID")]
			[Description("仅要素 ID")]
			Only_Feature_ID,

			/// <summary>
			/// <para>所有字段—输入要素的所有字段都将传递到输出要素类。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有字段")]
			All_fields,

		}

#endregion
	}
}
