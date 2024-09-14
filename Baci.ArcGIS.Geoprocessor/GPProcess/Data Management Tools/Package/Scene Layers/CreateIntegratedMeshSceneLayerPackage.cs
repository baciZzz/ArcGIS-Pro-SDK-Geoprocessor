using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Integrated Mesh Scene Layer Content</para>
	/// <para>Create Integrated Mesh Scene Layer Content</para>
	/// <para>Creates  scene layer content (.slpk or .i3sREST) from OpenSceneGraph binary (OSGB) data.</para>
	/// </summary>
	public class CreateIntegratedMeshSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The OSGB format files, or folders containing OSGB format files, that will be imported into the integrated mesh scene layer package. This parameter allows a selection of multiple OSGB format files or a selection of multiple folders containing OSGB format files.</para>
		/// </param>
		public CreateIntegratedMeshSceneLayerPackage(object InDataset)
		{
			this.InDataset = InDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Integrated Mesh Scene Layer Content</para>
		/// </summary>
		public override string DisplayName() => "Create Integrated Mesh Scene Layer Content";

		/// <summary>
		/// <para>Tool Name : CreateIntegratedMeshSceneLayerPackage</para>
		/// </summary>
		public override string ToolName() => "CreateIntegratedMeshSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateIntegratedMeshSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateIntegratedMeshSceneLayerPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutSlpk!, AnchorPoint!, FileSuffix!, OutCoorSystem!, MaxTextureSize!, TextureOptimization!, TargetCloudConnection!, OutName! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The OSGB format files, or folders containing OSGB format files, that will be imported into the integrated mesh scene layer package. This parameter allows a selection of multiple OSGB format files or a selection of multiple folders containing OSGB format files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>The integrated mesh scene layer package that will be created. This parameter is required if a Target Cloud Connection parameter value is not specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("slpk")]
		public object? OutSlpk { get; set; }

		/// <summary>
		/// <para>Anchor Point</para>
		/// <para>The point feature or .3mx, .xml, or .wld3 file that will be used to position the center of the OSGB model. If there are multiple points in the feature class, only the first point will be used to georeference the data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? AnchorPoint { get; set; }

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>Specifies the files that will be processed for the input dataset.</para>
		/// <para>All supported files—All binary files, regardless of their extension, will be processed to determine if they are in the OSGB format.</para>
		/// <para>Files with *.osgb extension—Only files with the .osgb extension will be processed.</para>
		/// <para><see cref="FileSuffixEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FileSuffix { get; set; } = "osgb";

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system of the output scene layer package. It can be any projected or custom coordinate system. Supported geographic coordinate systems include WGS 1984 and China Geodetic Coordinate System 2000. WGS 1984 and EGM96 Geoid are the default horizontal and vertical coordinate systems, respectively. The coordinate system can be specified in any of the following ways:</para>
		/// <para>Specify the path to a .prj file.</para>
		/// <para>Reference a dataset with the desired coordinate system.</para>
		/// <para>Use an arcpy.SpatialReference object.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? OutCoorSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Maximum Texture Size</para>
		/// <para>The maximum texture size in pixels for each scene layer node.</para>
		/// <para><see cref="MaxTextureSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? MaxTextureSize { get; set; }

		/// <summary>
		/// <para>Texture Optimization</para>
		/// <para>Specifies the textures that will be optimized according to the target platform where the scene layer package is used.Optimizations that include KTX2 may take significant time to process. For fastest results, use the Desktop or None options.</para>
		/// <para>All—All texture formats will be optimized including JPEG, DXT, and KTX2 for use in desktop, web, and mobile platforms.</para>
		/// <para>Desktop—Windows, Linux, and Mac supported textures will be optimized including JPEG and DXT for use in ArcGIS Pro clients on Windows and ArcGIS Runtime desktop clients on Windows, Linux, and Mac. This is the default.</para>
		/// <para>Mobile—Android and iOS supported textures will be optimized including JPEG and KTX2 for use in ArcGIS Runtime mobile applications.</para>
		/// <para>None—JPEG textures will be optimized for use in desktop and web platforms.</para>
		/// <para><see cref="TextureOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TextureOptimization { get; set; } = "Desktop";

		/// <summary>
		/// <para>Target Cloud Connection</para>
		/// <para>The target cloud connection file (.acs) where the scene layer content (.i3sREST) will be output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? TargetCloudConnection { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The output name of the scene layer content when output to a cloud store. This parameter is only available when a Target Cloud Connection parameter value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateIntegratedMeshSceneLayerPackage SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Suffix</para>
		/// </summary>
		public enum FileSuffixEnum 
		{
			/// <summary>
			/// <para>Files with *.osgb extension—Only files with the .osgb extension will be processed.</para>
			/// </summary>
			[GPValue("osgb")]
			[Description("Files with *.osgb extension")]
			osgb,

			/// <summary>
			/// <para>All supported files—All binary files, regardless of their extension, will be processed to determine if they are in the OSGB format.</para>
			/// </summary>
			[GPValue("*")]
			[Description("All supported files")]
			All_supported_files,

		}

		/// <summary>
		/// <para>Maximum Texture Size</para>
		/// </summary>
		public enum MaxTextureSizeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2048")]
			[Description("2048")]
			_2048,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("4096")]
			[Description("4096")]
			_4096,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("8192")]
			[Description("8192")]
			_8192,

		}

		/// <summary>
		/// <para>Texture Optimization</para>
		/// </summary>
		public enum TextureOptimizationEnum 
		{
			/// <summary>
			/// <para>All—All texture formats will be optimized including JPEG, DXT, and KTX2 for use in desktop, web, and mobile platforms.</para>
			/// </summary>
			[GPValue("All")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Desktop—Windows, Linux, and Mac supported textures will be optimized including JPEG and DXT for use in ArcGIS Pro clients on Windows and ArcGIS Runtime desktop clients on Windows, Linux, and Mac. This is the default.</para>
			/// </summary>
			[GPValue("Desktop")]
			[Description("Desktop")]
			Desktop,

			/// <summary>
			/// <para>Mobile—Android and iOS supported textures will be optimized including JPEG and KTX2 for use in ArcGIS Runtime mobile applications.</para>
			/// </summary>
			[GPValue("Mobile")]
			[Description("Mobile")]
			Mobile,

			/// <summary>
			/// <para>None—JPEG textures will be optimized for use in desktop and web platforms.</para>
			/// </summary>
			[GPValue("None")]
			[Description("None")]
			None,

		}

#endregion
	}
}
