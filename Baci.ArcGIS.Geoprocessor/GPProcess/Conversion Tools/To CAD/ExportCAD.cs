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
	/// <para>Creates one or more CAD drawings based on the values contained in one or more input feature classes or feature layers and supporting tables.</para>
	/// </summary>
	public class ExportCAD : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>A collection of feature classes and/or feature layers whose geometry will be exported to one or more CAD files.</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>The CAD platform and file version of the output files. This value overrides any Output_Type values contained in the keyname column or alias column CADFile_type.</para>
		/// <para>Microstation DGN file—Microstation DGN file</para>
		/// <para>DWG version 2018—DWG version 2018</para>
		/// <para>DWG version 2013—DWG version 2013</para>
		/// <para>DWG version 2010—DWG version 2010</para>
		/// <para>DWG version 2007—DWG version 2007</para>
		/// <para>DWG version 2005—DWG version 2005</para>
		/// <para>DWG version 2004—DWG version 2004</para>
		/// <para>DWG version 2000—DWG version 2000</para>
		/// <para>DWG version 14—DWG version 14</para>
		/// <para>DXF version 2018—DXF version 2018</para>
		/// <para>DXF version 2013—DXF version 2013</para>
		/// <para>DXF version 2010—DXF version 2010</para>
		/// <para>DXF version 2007—DXF version 2007</para>
		/// <para>DXF version 2005—DXF version 2005</para>
		/// <para>DXF version 2004—DXF version 2004</para>
		/// <para>DXF version 2000—DXF version 2000</para>
		/// <para>DXF version 14—DXF version 14</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The path of the desired output CAD drawing file. This name overrides any drawing name information included in the input features columns or alias columns named DrawingPathName.</para>
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
		public override string DisplayName => "Export to CAD";

		/// <summary>
		/// <para>Tool Name : ExportCAD</para>
		/// </summary>
		public override string ToolName => "ExportCAD";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExportCAD</para>
		/// </summary>
		public override string ExcuteName => "conversion.ExportCAD";

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
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutputType, OutputFile, IgnoreFilenames, AppendToExisting, SeedFile };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A collection of feature classes and/or feature layers whose geometry will be exported to one or more CAD files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>The CAD platform and file version of the output files. This value overrides any Output_Type values contained in the keyname column or alias column CADFile_type.</para>
		/// <para>Microstation DGN file—Microstation DGN file</para>
		/// <para>DWG version 2018—DWG version 2018</para>
		/// <para>DWG version 2013—DWG version 2013</para>
		/// <para>DWG version 2010—DWG version 2010</para>
		/// <para>DWG version 2007—DWG version 2007</para>
		/// <para>DWG version 2005—DWG version 2005</para>
		/// <para>DWG version 2004—DWG version 2004</para>
		/// <para>DWG version 2000—DWG version 2000</para>
		/// <para>DWG version 14—DWG version 14</para>
		/// <para>DXF version 2018—DXF version 2018</para>
		/// <para>DXF version 2013—DXF version 2013</para>
		/// <para>DXF version 2010—DXF version 2010</para>
		/// <para>DXF version 2007—DXF version 2007</para>
		/// <para>DXF version 2005—DXF version 2005</para>
		/// <para>DXF version 2004—DXF version 2004</para>
		/// <para>DXF version 2000—DXF version 2000</para>
		/// <para>DXF version 14—DXF version 14</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "DWG_R2018";

		/// <summary>
		/// <para>Output File</para>
		/// <para>The path of the desired output CAD drawing file. This name overrides any drawing name information included in the input features columns or alias columns named DrawingPathName.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DECadDrawingDataset()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Ignore Paths in Tables</para>
		/// <para>Specifies whether the function will ignore or use the paths in the DrawingPathName. This allows the function to output CAD entities to specific drawings or ignore this and add to one CAD file.</para>
		/// <para>Checked—The paths in the document entity fields will be ignored and the output of all entities will be added to a single CAD file. This is the default.</para>
		/// <para>Unchecked—The paths in the document entity fields and each entity&apos;s path will be used so that each CAD part will be written to a separate file.</para>
		/// <para><see cref="IgnoreFilenamesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreFilenames { get; set; } = "true";

		/// <summary>
		/// <para>Append to Existing Files</para>
		/// <para>Specifies whether the output will be appended to an existing CAD file. This allows you to add information to a CAD file on disk.</para>
		/// <para>Checked—The output file content will be added to an existing output CAD file. The existing CAD file content will not be lost.</para>
		/// <para>Unchecked—The output file content will overwrite the existing CAD file content. This is the default.</para>
		/// <para><see cref="AppendToExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToExisting { get; set; } = "false";

		/// <summary>
		/// <para>Seed File</para>
		/// <para>An existing CAD drawing whose contents and document and layer properties will be used for all new output CAD files. The CAD platform and format version of the seed file overrides the value specified by the Output Type parameter. If appending to existing CAD files, the seed drawing is ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DECadDrawingDataset()]
		public object SeedFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportCAD SetEnviroment(object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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
			/// <para>Checked—The paths in the document entity fields will be ignored and the output of all entities will be added to a single CAD file. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Ignore_Filenames_in_Tables")]
			Ignore_Filenames_in_Tables,

			/// <summary>
			/// <para>Unchecked—The paths in the document entity fields and each entity&apos;s path will be used so that each CAD part will be written to a separate file.</para>
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
			/// <para>Checked—The output file content will be added to an existing output CAD file. The existing CAD file content will not be lost.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Append_To_Existing_Files")]
			Append_To_Existing_Files,

			/// <summary>
			/// <para>Unchecked—The output file content will overwrite the existing CAD file content. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("Overwrite_Existing_Files")]
			Overwrite_Existing_Files,

		}

#endregion
	}
}
