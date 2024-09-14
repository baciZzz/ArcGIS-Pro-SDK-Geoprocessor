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
	/// <para>Export to CAD</para>
	/// <para>Export to CAD</para>
	/// <para>Exports features to  new or existing CAD files based on one or more input feature layers or feature classes.</para>
	/// </summary>
	public class ExportCAD : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>A collection of feature classes and feature layers whose spatial reference and geometry will be exported to one or more CAD files. Both the feature geometry and the feature attributes will be added to AutoCAD formatted files.</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>Specifies the CAD platform and file version that will be used for new output CAD files. Multiple versions of CAD software may share one file format version for multiple releases. The choices specify the file format version, not necessarily the software version that may still use a previous file format version.</para>
		/// <para>Microstation DGN file—The output type will be Microstation DGN.</para>
		/// <para>DWG version 2018—The output type will be DWG version 2018. This is the default.</para>
		/// <para>DWG version 2013—The output type will be DWG version 2013.</para>
		/// <para>DWG version 2010—The output type will be DWG version 2010.</para>
		/// <para>DWG version 2007—The output type will be DWG version 2007.</para>
		/// <para>DWG version 2005—The output type will be DWG version 2005.</para>
		/// <para>DWG version 2004—The output type will be DWG version 2004.</para>
		/// <para>DWG version 2000—The output type will be DWG version 2000.</para>
		/// <para>DWG version 14—The output type will be DWG version 14.</para>
		/// <para>DXF version 2018—The output type will be DXF version 2018.</para>
		/// <para>DXF version 2013—The output type will be DXF version 2013.</para>
		/// <para>DXF version 2010—The output type will be DXF version 2010.</para>
		/// <para>DXF version 2007—The output type will be DXF version 2007.</para>
		/// <para>DXF version 2005—The output type will be DXF version 2005.</para>
		/// <para>DXF version 2004—The output type will be DXF version 2004.</para>
		/// <para>DXF version 2000—The output type will be DXF version 2000.</para>
		/// <para>DXF version 14—The output type will be DXF version 14.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The path of the output CAD drawing file. This path will be overridden by any valid file paths included as field values in the input feature's field or alias field named DocPath unless the Ignore Paths in Tables parameter is checked.</para>
		/// </param>
		public ExportCAD(object InFeatures, object OutputType, object OutputFile)
		{
			this.InFeatures = InFeatures;
			this.OutputType = OutputType;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export to CAD</para>
		/// </summary>
		public override string DisplayName() => "Export to CAD";

		/// <summary>
		/// <para>Tool Name : ExportCAD</para>
		/// </summary>
		public override string ToolName() => "ExportCAD";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExportCAD</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ExportCAD";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputType, OutputFile, IgnoreFilenames!, AppendToExisting!, SeedFile! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A collection of feature classes and feature layers whose spatial reference and geometry will be exported to one or more CAD files. Both the feature geometry and the feature attributes will be added to AutoCAD formatted files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies the CAD platform and file version that will be used for new output CAD files. Multiple versions of CAD software may share one file format version for multiple releases. The choices specify the file format version, not necessarily the software version that may still use a previous file format version.</para>
		/// <para>Microstation DGN file—The output type will be Microstation DGN.</para>
		/// <para>DWG version 2018—The output type will be DWG version 2018. This is the default.</para>
		/// <para>DWG version 2013—The output type will be DWG version 2013.</para>
		/// <para>DWG version 2010—The output type will be DWG version 2010.</para>
		/// <para>DWG version 2007—The output type will be DWG version 2007.</para>
		/// <para>DWG version 2005—The output type will be DWG version 2005.</para>
		/// <para>DWG version 2004—The output type will be DWG version 2004.</para>
		/// <para>DWG version 2000—The output type will be DWG version 2000.</para>
		/// <para>DWG version 14—The output type will be DWG version 14.</para>
		/// <para>DXF version 2018—The output type will be DXF version 2018.</para>
		/// <para>DXF version 2013—The output type will be DXF version 2013.</para>
		/// <para>DXF version 2010—The output type will be DXF version 2010.</para>
		/// <para>DXF version 2007—The output type will be DXF version 2007.</para>
		/// <para>DXF version 2005—The output type will be DXF version 2005.</para>
		/// <para>DXF version 2004—The output type will be DXF version 2004.</para>
		/// <para>DXF version 2000—The output type will be DXF version 2000.</para>
		/// <para>DXF version 14—The output type will be DXF version 14.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "DWG_R2018";

		/// <summary>
		/// <para>Output File</para>
		/// <para>The path of the output CAD drawing file. This path will be overridden by any valid file paths included as field values in the input feature's field or alias field named DocPath unless the Ignore Paths in Tables parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DECadDrawingDataset()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Ignore Paths in Tables</para>
		/// <para>Specifies whether valid paths included in the DocPath field of input features will be ignored.</para>
		/// <para>Checked—Valid paths will be ignored and the output of all entities will be added to the Output File parameter value. This is the default.</para>
		/// <para>Unchecked—Valid paths will be used so that each new CAD entity will be written to the file specified by that field value.</para>
		/// <para><see cref="IgnoreFilenamesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreFilenames { get; set; } = "true";

		/// <summary>
		/// <para>Append to Existing Files</para>
		/// <para>Specifies whether entities will be appended to an existing output CAD file or CAD files specified by the Output File parameter or any valid file paths contained in DocPath field values according to the Ignore Paths in Tables parameter will be overwritten.</para>
		/// <para>Checked—Entities will be appended to an output CAD file if one exists. The existing CAD file content will be retained.</para>
		/// <para>Unchecked—If an output CAD file exists, it will be overwritten. This is the default.</para>
		/// <para><see cref="AppendToExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToExisting { get; set; } = "false";

		/// <summary>
		/// <para>Seed File</para>
		/// <para>An existing CAD drawing whose contents and document and layer properties will be used as a seed file when output CAD files are created. The CAD platform and format version of the seed file overrides the value specified by the Output Type parameter. If appending to existing CAD files, the seed drawing is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DECadDrawingDataset()]
		public object? SeedFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportCAD SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ignore Paths in Tables</para>
		/// </summary>
		public enum IgnoreFilenamesEnum 
		{
			/// <summary>
			/// <para>Checked—Valid paths will be ignored and the output of all entities will be added to the Output File parameter value. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Ignore_Filenames_in_Tables")]
			Ignore_Filenames_in_Tables,

			/// <summary>
			/// <para>Unchecked—Valid paths will be used so that each new CAD entity will be written to the file specified by that field value.</para>
			/// </summary>
			[GPValue("false")]
			[Description("Use_Filenames_in_Tables")]
			Use_Filenames_in_Tables,

		}

		/// <summary>
		/// <para>Append to Existing Files</para>
		/// </summary>
		public enum AppendToExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Entities will be appended to an output CAD file if one exists. The existing CAD file content will be retained.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Append_To_Existing_Files")]
			Append_To_Existing_Files,

			/// <summary>
			/// <para>Unchecked—If an output CAD file exists, it will be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("Overwrite_Existing_Files")]
			Overwrite_Existing_Files,

		}

#endregion
	}
}
