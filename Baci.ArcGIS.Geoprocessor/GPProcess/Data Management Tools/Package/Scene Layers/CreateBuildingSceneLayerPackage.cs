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
	/// <para>Create Building Scene Layer Package</para>
	/// <para>Creates a scene layer package (.slpk file) from a building layer input.</para>
	/// </summary>
	public class CreateBuildingSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>The input building layer or layer file (.lyrx).</para>
		/// </param>
		/// <param name="OutSlpk">
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk).</para>
		/// </param>
		public CreateBuildingSceneLayerPackage(object InDataset, object OutSlpk)
		{
			this.InDataset = InDataset;
			this.OutSlpk = OutSlpk;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Building Scene Layer Package</para>
		/// </summary>
		public override string DisplayName => "Create Building Scene Layer Package";

		/// <summary>
		/// <para>Tool Name : CreateBuildingSceneLayerPackage</para>
		/// </summary>
		public override string ToolName => "CreateBuildingSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateBuildingSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreateBuildingSceneLayerPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDataset, OutSlpk, OutCoorSystem, TransformMethod, TextureOptimization };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>The input building layer or layer file (.lyrx).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Scene Layer Package</para>
		/// <para>The output scene layer package (.slpk).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutSlpk { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The coordinate system of the output scene layer package. It can be any projected or custom coordinate system. Supported geographic coordinate systems include WGS 1984 and China Geodetic Coordinate System 2000. WGS 1984 and EGM96 Geoid are the default horizontal and vertical coordinate systems, respectively. The coordinate system can be specified in any of the following ways:</para>
		/// <para>Specify the path to a .prj file.</para>
		/// <para>Reference a dataset with the desired coordinate system.</para>
		/// <para>Use an arcpy.SpatialReference object.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object OutCoorSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]],VERTCS[\"EGM96_Geoid\",VDATUM[\"EGM96_Geoid\"],PARAMETER[\"Vertical_Shift\",0.0],PARAMETER[\"Direction\",1.0],UNIT[\"Meter\",1.0]];-400 -400 1000000000;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Geographic Transformation</para>
		/// <para>The datum transformation method that will be used when the input layer&apos;s coordinate system uses a datum that differs from the output coordinate system. All transformations are bidirectional, regardless of the direction implied by their names. For example, NAD_1927_to_WGS_1984_3 will work correctly even if the datum conversion is from WGS84 to NAD 1927.</para>
		/// <para>The ArcGIS Coordinate System data is required for vertical datum transformations between ellipsoidal and gravity-related and two gravity-related datums.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TransformMethod { get; set; }

		/// <summary>
		/// <para>Texture Optimization</para>
		/// <para>Specifies the textures that will be optimized according to the target platform where the scene layer package is used. Desktop includes Windows, Linux, and Mac platforms. Mobile include iOS and Android.Optimizations that include ETC2 may take significant time to process. For fastest results, use the Desktop or None option.</para>
		/// <para>All—Texture formats will be optimized for use on desktop, web, and mobile platforms. Texture formats will be JPEG, DXT, and ETC2.</para>
		/// <para>Desktop—Texture formats will be optimized for use on desktop and web platforms. Texture formats will be JPEG and DXT.</para>
		/// <para>Mobile—Texture formats will be optimized for use on desktop and mobile platforms. Texture formats will be JPEG and ETC2.</para>
		/// <para>None—Textures formats will be optimized for use on a desktop platform. The texture format will be JPEG.</para>
		/// <para><see cref="TextureOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TextureOptimization { get; set; } = "DESKTOP";

		#region InnerClass

		/// <summary>
		/// <para>Texture Optimization</para>
		/// </summary>
		public enum TextureOptimizationEnum 
		{
			/// <summary>
			/// <para>All—Texture formats will be optimized for use on desktop, web, and mobile platforms. Texture formats will be JPEG, DXT, and ETC2.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Desktop—Texture formats will be optimized for use on desktop and web platforms. Texture formats will be JPEG and DXT.</para>
			/// </summary>
			[GPValue("DESKTOP")]
			[Description("Desktop")]
			Desktop,

			/// <summary>
			/// <para>Mobile—Texture formats will be optimized for use on desktop and mobile platforms. Texture formats will be JPEG and ETC2.</para>
			/// </summary>
			[GPValue("MOBILE")]
			[Description("Mobile")]
			Mobile,

			/// <summary>
			/// <para>None—Textures formats will be optimized for use on a desktop platform. The texture format will be JPEG.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

#endregion
	}
}
