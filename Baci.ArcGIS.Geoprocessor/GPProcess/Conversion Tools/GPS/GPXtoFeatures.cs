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
	/// <para>GPX To Features</para>
	/// <para>Converts the point information inside a GPX file to features.</para>
	/// </summary>
	public class GPXtoFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputGPXFile">
		/// <para>Input GPX File</para>
		/// <para>The GPX file to convert.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature class</para>
		/// <para>The feature class to create.</para>
		/// </param>
		public GPXtoFeatures(object InputGPXFile, object OutputFeatureClass)
		{
			this.InputGPXFile = InputGPXFile;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GPX To Features</para>
		/// </summary>
		public override string DisplayName => "GPX To Features";

		/// <summary>
		/// <para>Tool Name : GPXtoFeatures</para>
		/// </summary>
		public override string ToolName => "GPXtoFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GPXtoFeatures</para>
		/// </summary>
		public override string ExcuteName => "conversion.GPXtoFeatures";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputGPXFile, OutputFeatureClass };

		/// <summary>
		/// <para>Input GPX File</para>
		/// <para>The GPX file to convert.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InputGPXFile { get; set; }

		/// <summary>
		/// <para>Output Feature class</para>
		/// <para>The feature class to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GPXtoFeatures SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
