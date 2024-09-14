using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Generate Sector Lines</para>
	/// <para>Generate Sector Lines</para>
	/// <para>Creates line features that represent the extent of cell site antenna sectors.</para>
	/// </summary>
	public class GenerateSectorLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSiteFeatures">
		/// <para>Input Cell Site Points</para>
		/// <para>The point feature class derived from the Cell Site Records to Feature Class or Cell Phone Records to Feature Class tool.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Sector Lines</para>
		/// <para>The output feature class containing the sector lines.</para>
		/// </param>
		public GenerateSectorLines(object InSiteFeatures, object OutFeatureClass)
		{
			this.InSiteFeatures = InSiteFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Sector Lines</para>
		/// </summary>
		public override string DisplayName() => "Generate Sector Lines";

		/// <summary>
		/// <para>Tool Name : GenerateSectorLines</para>
		/// </summary>
		public override string ToolName() => "GenerateSectorLines";

		/// <summary>
		/// <para>Tool Excute Name : ca.GenerateSectorLines</para>
		/// </summary>
		public override string ExcuteName() => "ca.GenerateSectorLines";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSiteFeatures, OutFeatureClass };

		/// <summary>
		/// <para>Input Cell Site Points</para>
		/// <para>The point feature class derived from the Cell Site Records to Feature Class or Cell Phone Records to Feature Class tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InSiteFeatures { get; set; }

		/// <summary>
		/// <para>Output Sector Lines</para>
		/// <para>The output feature class containing the sector lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSectorLines SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, bool? maintainAttachments = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
