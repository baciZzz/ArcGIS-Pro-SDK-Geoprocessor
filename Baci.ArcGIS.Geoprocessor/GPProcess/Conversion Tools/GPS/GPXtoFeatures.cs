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
	/// <para>GPX To Features</para>
	/// <para>Converts the point data in a .gpx file to features.</para>
	/// </summary>
	public class GPXtoFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputGPXFile">
		/// <para>Input GPX File</para>
		/// <para>The input .gpx file to be converted.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature class</para>
		/// <para>The output point feature class.</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>Specifies the geometry type of the output feature class.</para>
		/// <para>Points—An output point feature class will be created. All GPX points will be included in the output. This is the default.</para>
		/// <para>Tracks as polylines—An output polyline feature class will be created. Only GPX track points will be included in the output.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </param>
		public GPXtoFeatures(object InputGPXFile, object OutputFeatureClass, object OutputType)
		{
			this.InputGPXFile = InputGPXFile;
			this.OutputFeatureClass = OutputFeatureClass;
			this.OutputType = OutputType;
		}

		/// <summary>
		/// <para>Tool Display Name : GPX To Features</para>
		/// </summary>
		public override string DisplayName() => "GPX To Features";

		/// <summary>
		/// <para>Tool Name : GPXtoFeatures</para>
		/// </summary>
		public override string ToolName() => "GPXtoFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GPXtoFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GPXtoFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputGPXFile, OutputFeatureClass, OutputType };

		/// <summary>
		/// <para>Input GPX File</para>
		/// <para>The input .gpx file to be converted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gpx")]
		public object InputGPXFile { get; set; }

		/// <summary>
		/// <para>Output Feature class</para>
		/// <para>The output point feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the geometry type of the output feature class.</para>
		/// <para>Points—An output point feature class will be created. All GPX points will be included in the output. This is the default.</para>
		/// <para>Tracks as polylines—An output polyline feature class will be created. Only GPX track points will be included in the output.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "POINTS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GPXtoFeatures SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Points—An output point feature class will be created. All GPX points will be included in the output. This is the default.</para>
			/// </summary>
			[GPValue("POINTS")]
			[Description("Points")]
			Points,

			/// <summary>
			/// <para>Tracks as polylines—An output polyline feature class will be created. Only GPX track points will be included in the output.</para>
			/// </summary>
			[GPValue("TRACKS_AS_LINES")]
			[Description("Tracks as polylines")]
			Tracks_as_polylines,

		}

#endregion
	}
}
