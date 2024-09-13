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
	/// <para>生成扇区线</para>
	/// <para>创建线要素，以表示蜂窝基站天线扇区的范围。</para>
	/// </summary>
	public class GenerateSectorLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSiteFeatures">
		/// <para>Input Cell Site Points</para>
		/// <para>通过蜂窝基站记录转要素类或手机记录转要素类工具获得的点要素类。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Sector Lines</para>
		/// <para>包含扇区线的输出要素类。</para>
		/// </param>
		public GenerateSectorLines(object InSiteFeatures, object OutFeatureClass)
		{
			this.InSiteFeatures = InSiteFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成扇区线</para>
		/// </summary>
		public override string DisplayName() => "生成扇区线";

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
		/// <para>通过蜂窝基站记录转要素类或手机记录转要素类工具获得的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InSiteFeatures { get; set; }

		/// <summary>
		/// <para>Output Sector Lines</para>
		/// <para>包含扇区线的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSectorLines SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainAttachments = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainAttachments: maintainAttachments, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
