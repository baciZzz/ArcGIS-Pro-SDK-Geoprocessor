using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Import 3D Files</para>
	/// <para>Import 3D Files</para>
	/// <para>Imports one or more 3D models into a multipatch feature class.</para>
	/// </summary>
	public class Import3DFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFiles">
		/// <para>Input Files</para>
		/// <para>One or more 3D models or folders containing such files in the supported formats, which are 3D Studio Max (*.3ds), VRML and GeoVRML (*.wrl), OpenFlight (*.flt), COLLADA (*.dae), and Wavefront OBJ models (*.obj).</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The multipatch that will be created from the input files.</para>
		/// </param>
		public Import3DFiles(object InFiles, object OutFeatureclass)
		{
			this.InFiles = InFiles;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : Import 3D Files</para>
		/// </summary>
		public override string DisplayName() => "Import 3D Files";

		/// <summary>
		/// <para>Tool Name : Import3DFiles</para>
		/// </summary>
		public override string ToolName() => "Import3DFiles";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Import3DFiles</para>
		/// </summary>
		public override string ExcuteName() => "3d.Import3DFiles";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFiles, OutFeatureclass, RootPerFeature, SpatialReference, YIsUp, FileSuffix, InFeatureclass, SymbolField };

		/// <summary>
		/// <para>Input Files</para>
		/// <para>One or more 3D models or folders containing such files in the supported formats, which are 3D Studio Max (*.3ds), VRML and GeoVRML (*.wrl), OpenFlight (*.flt), COLLADA (*.dae), and Wavefront OBJ models (*.obj).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InFiles { get; set; }

		/// <summary>
		/// <para>Output Multipatch Feature Class</para>
		/// <para>The multipatch that will be created from the input files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>One Root Per Feature</para>
		/// <para>Indicates whether to produce one feature per file or one feature for every root node in the file. This option only applies to VRML models.</para>
		/// <para>Unchecked—The generated output will contain one file for each feature. This is the default.</para>
		/// <para>Checked—The generated output will contain one feature for each root node in the file.</para>
		/// <para><see cref="RootPerFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RootPerFeature { get; set; } = "false";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system of the input data. For the majority of formats, this is unknown. Only the GeoVRML format stores its coordinate system, and its default will be obtained from the first file in the list unless a spatial reference is specified here.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Y Is Up</para>
		/// <para>Identifies the axis that defines the vertical orientation of the input files.</para>
		/// <para>Unchecked—Indicates that z is up. This is the default.</para>
		/// <para>Checked—Indicates that y is up.</para>
		/// <para><see cref="YIsUpEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object YIsUp { get; set; } = "false";

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>The file extension of the files to import from an input folder. This parameter is required when at least one folder is specified as an input.</para>
		/// <para>All Supported Files—All supported files. This is the default.</para>
		/// <para>3D Studio Max (*.3ds)—3D Studio Max</para>
		/// <para>VRML or GeoVRML (*.wrl)—VRML or GeoVRML</para>
		/// <para>OpenFlight (*.flt)—OpenFlight</para>
		/// <para>Collada (*.dae)—Collada</para>
		/// <para>Wavefront OBJ format (*.obj)—Wavefront OBJ model</para>
		/// <para><see cref="FileSuffixEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FileSuffix { get; set; } = "*";

		/// <summary>
		/// <para>Placement Points</para>
		/// <para>The point features whose coordinates define the real-world position of the input files. Each input file will be matched to its corresponding point based on the file names stored in the Symbol Field. The Coordinate System parameter should be defined to match the spatial reference of the points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>Symbol Field</para>
		/// <para>The field in the point features containing the name of the 3D file associated with each point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Text", "Float", "Double", "Date")]
		public object SymbolField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Import3DFiles SetEnviroment(object XYDomain = null, object ZDomain = null, int? autoCommit = null, object configKeyword = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>One Root Per Feature</para>
		/// </summary>
		public enum RootPerFeatureEnum 
		{
			/// <summary>
			/// <para>Checked—The generated output will contain one feature for each root node in the file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ONE_FILE_ONE_FEATURE")]
			ONE_FILE_ONE_FEATURE,

			/// <summary>
			/// <para>Unchecked—The generated output will contain one file for each feature. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONE_ROOT_ONE_FEATURE")]
			ONE_ROOT_ONE_FEATURE,

		}

		/// <summary>
		/// <para>Y Is Up</para>
		/// </summary>
		public enum YIsUpEnum 
		{
			/// <summary>
			/// <para>Checked—Indicates that y is up.</para>
			/// </summary>
			[GPValue("true")]
			[Description("Y_IS_UP")]
			Y_IS_UP,

			/// <summary>
			/// <para>Unchecked—Indicates that z is up. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("Z_IS_UP")]
			Z_IS_UP,

		}

		/// <summary>
		/// <para>File Suffix</para>
		/// </summary>
		public enum FileSuffixEnum 
		{
			/// <summary>
			/// <para>3D Studio Max (*.3ds)—3D Studio Max</para>
			/// </summary>
			[GPValue("3DS")]
			[Description("3D Studio Max (*.3ds)")]
			_3DS,

			/// <summary>
			/// <para>VRML or GeoVRML (*.wrl)—VRML or GeoVRML</para>
			/// </summary>
			[GPValue("WRL")]
			[Description("VRML or GeoVRML (*.wrl)")]
			WRL,

			/// <summary>
			/// <para>OpenFlight (*.flt)—OpenFlight</para>
			/// </summary>
			[GPValue("FLT")]
			[Description("OpenFlight (*.flt)")]
			FLT,

			/// <summary>
			/// <para>Collada (*.dae)—Collada</para>
			/// </summary>
			[GPValue("DAE")]
			[Description("Collada (*.dae)")]
			DAE,

			/// <summary>
			/// <para>Wavefront OBJ format (*.obj)—Wavefront OBJ model</para>
			/// </summary>
			[GPValue("OBJ")]
			[Description("Wavefront OBJ format (*.obj)")]
			OBJ,

			/// <summary>
			/// <para>All Supported Files—All supported files. This is the default.</para>
			/// </summary>
			[GPValue("*")]
			[Description("All Supported Files")]
			All_Supported_Files,

		}

#endregion
	}
}
