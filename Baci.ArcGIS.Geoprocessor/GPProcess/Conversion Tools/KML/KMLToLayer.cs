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
	/// <para>KML To Layer</para>
	/// <para>Converts a KML or KMZ file into feature classes  and a layer file.  The layer file  maintains the symbology found within the original KML or KMZ file.</para>
	/// </summary>
	public class KMLToLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InKmlFile">
		/// <para>Input KML File</para>
		/// <para>The KML or KMZ file to translate.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Location</para>
		/// <para>The destination folder for the file geodatabase and layer (.lyrx) file.</para>
		/// </param>
		public KMLToLayer(object InKmlFile, object OutputFolder)
		{
			this.InKmlFile = InKmlFile;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : KML To Layer</para>
		/// </summary>
		public override string DisplayName() => "KML To Layer";

		/// <summary>
		/// <para>Tool Name : KMLToLayer</para>
		/// </summary>
		public override string ToolName() => "KMLToLayer";

		/// <summary>
		/// <para>Tool Excute Name : conversion.KMLToLayer</para>
		/// </summary>
		public override string ExcuteName() => "conversion.KMLToLayer";

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
		public override object[] Parameters() => new object[] { InKmlFile, OutputFolder, OutputData, IncludeGroundoverlay, OutputLayer, OutGeodatabase };

		/// <summary>
		/// <para>Input KML File</para>
		/// <para>The KML or KMZ file to translate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InKmlFile { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The destination folder for the file geodatabase and layer (.lyrx) file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Output Data Name</para>
		/// <para>The name of the output file geodatabase and layer file. The default is the name of the input KML file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutputData { get; set; }

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// <para>Include ground overlays from the KML (raster, air photos, and so on). Use caution if the KMZ points to a service that serves raster imagery. The tool will attempt to translate the raster imagery at all available scales. This process could be lengthy and possibly overwhelm the service.</para>
		/// <para>Checked—Ground overlay is included in the output.</para>
		/// <para>Unchecked—Ground overlay is not included in the output. This is the default.</para>
		/// <para><see cref="IncludeGroundoverlayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeGroundoverlay { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public KMLToLayer SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Ground Overlay</para>
		/// </summary>
		public enum IncludeGroundoverlayEnum 
		{
			/// <summary>
			/// <para>Checked—Ground overlay is included in the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GROUNDOVERLAY")]
			GROUNDOVERLAY,

			/// <summary>
			/// <para>Unchecked—Ground overlay is not included in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GROUNDOVERLAY")]
			NO_GROUNDOVERLAY,

		}

#endregion
	}
}
