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
	/// <para>Converts one or more feature classes or feature layers to geodatabase feature classes.</para>
	/// </summary>
	public class FeatureClassToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>One or more feature classes or feature layers to be imported into a geodatabase.</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The output or destination geodatabase.</para>
		/// </param>
		public FeatureClassToGeodatabase(object InputFeatures, object OutputGeodatabase)
		{
			this.InputFeatures = InputFeatures;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature Class To Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Feature Class To Geodatabase";

		/// <summary>
		/// <para>Tool Name : FeatureClassToGeodatabase</para>
		/// </summary>
		public override string ToolName => "FeatureClassToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.FeatureClassToGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "conversion.FeatureClassToGeodatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatures, OutputGeodatabase, DerivedGeodatabase };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>One or more feature classes or feature layers to be imported into a geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The output or destination geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object DerivedGeodatabase { get; set; } = "tmp";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureClassToGeodatabase SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
