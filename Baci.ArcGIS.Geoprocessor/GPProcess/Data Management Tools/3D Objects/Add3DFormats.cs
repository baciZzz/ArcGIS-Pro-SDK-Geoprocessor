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
	/// <para>Add 3D Formats To Multipatch</para>
	/// <para>Converts a multipatch to a 3D object feature</para>
	/// <para>layer by linking the feature class with one or more 3D model</para>
	/// <para>formats.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Add3DFormats : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input geodatabase multipatch feature that will be converted to a 3D object feature layer.</para>
		/// </param>
		public Add3DFormats(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add 3D Formats To Multipatch</para>
		/// </summary>
		public override string DisplayName => "Add 3D Formats To Multipatch";

		/// <summary>
		/// <para>Tool Name : Add3DFormats</para>
		/// </summary>
		public override string ToolName => "Add3DFormats";

		/// <summary>
		/// <para>Tool Excute Name : management.Add3DFormats</para>
		/// </summary>
		public override string ExcuteName => "management.Add3DFormats";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, MultipatchMaterials, Formats, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input geodatabase multipatch feature that will be converted to a 3D object feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Use multipatch materials</para>
		/// <para>Specifies whether the multipatch geometry will be visualized using material information from the associated 3D models or the texture and color information stored with the multipatch.</para>
		/// <para>Checked—The multipatch geometry will be visualized using the textures, colors, effects, and materials associated with the 3D models. This is the default.</para>
		/// <para>Unchecked—The multipatch geometry will be visualized using the textures and colors defined for the multipatch.</para>
		/// <para><see cref="MultipatchMaterialsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MultipatchMaterials { get; set; } = "true";

		/// <summary>
		/// <para>3D Formats to Add</para>
		/// <para>Specifies the 3D formats that will be associated with the multipatch features. Each input feature will be duplicated for each selected format. The available options depend on the codecs installed on the computer.</para>
		/// <para>Collada (.dae)—The COLLADA format will be added.</para>
		/// <para>Autodesk (.fbx)—The Autodesk FilmBox format will be added.</para>
		/// <para>Khronos Group glTF json (.gltf)—The JSON Graphics Library Transmission format will be added.</para>
		/// <para>Khronos Group glTF binary (.glb)—The binary Graphics Library Transmission format will be added.</para>
		/// <para>Wavefront (.obj)—The Wavefront format will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Formats { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Add3DFormats SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use multipatch materials</para>
		/// </summary>
		public enum MultipatchMaterialsEnum 
		{
			/// <summary>
			/// <para>Checked—The multipatch geometry will be visualized using the textures, colors, effects, and materials associated with the 3D models. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPATCH_WITH_MATERIALS")]
			MULTIPATCH_WITH_MATERIALS,

			/// <summary>
			/// <para>Unchecked—The multipatch geometry will be visualized using the textures and colors defined for the multipatch.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MULTIPATCH_WITHOUT_MATERIALS")]
			MULTIPATCH_WITHOUT_MATERIALS,

		}

#endregion
	}
}
