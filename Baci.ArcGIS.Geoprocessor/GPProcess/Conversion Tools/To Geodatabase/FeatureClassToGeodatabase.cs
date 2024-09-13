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
	/// <para>Feature Class To Geodatabase</para>
	/// <para>要素类至地理数据库</para>
	/// <para>将一个或多个要素类/要素图层转换为地理数据库要素类。</para>
	/// </summary>
	public class FeatureClassToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>要导入到地理数据库的一个或多个要素类或要素图层。</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>输出或目标地理数据库。</para>
		/// </param>
		public FeatureClassToGeodatabase(object InputFeatures, object OutputGeodatabase)
		{
			this.InputFeatures = InputFeatures;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素类至地理数据库</para>
		/// </summary>
		public override string DisplayName() => "要素类至地理数据库";

		/// <summary>
		/// <para>Tool Name : FeatureClassToGeodatabase</para>
		/// </summary>
		public override string ToolName() => "FeatureClassToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeatureClassToGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "conversion.FeatureClassToGeodatabase";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputGeodatabase, DerivedGeodatabase! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要导入到地理数据库的一个或多个要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>输出或目标地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? DerivedGeodatabase { get; set; } = "tmp";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureClassToGeodatabase SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
