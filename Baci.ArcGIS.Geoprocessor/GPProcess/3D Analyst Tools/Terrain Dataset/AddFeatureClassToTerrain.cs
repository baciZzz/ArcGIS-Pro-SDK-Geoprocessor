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
	/// <para>Add Feature Class To Terrain</para>
	/// <para>Add Feature Class To Terrain</para>
	/// <para>Adds one or more feature classes to a terrain dataset.</para>
	/// </summary>
	public class AddFeatureClassToTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain to which feature classes will be added. The terrain dataset must already have one or more pyramid levels created.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Feature Class</para>
		/// <para>Identifies features being added to the terrain. Each feature must reside in the same feature dataset as the terrain and have its role defined through the following properties:</para>
		/// <para>Input Features—Name of the feature class being added to the terrain.</para>
		/// <para>Height Field—Field containing the feature&apos;s height information. Any numeric field can be specified, and z-enabled features can also choose the geometry field. If the &lt;none&gt; option is chosen, z-values are interpolated from the surface.</para>
		/// <para>Type—Surface feature type that defines how the features contributes to the terrain. Mass points denote features that contribute z-measurements; breaklines denote linear features with known z-measurements, and several polygon types. Breaklines and polygon-based feature types also have hard and soft qualifiers that define the interpolation behavior around the feature&apos;s edges when exporting to raster. Soft features exhibit gradual changes in slope, whereas hard features represent sharp discontinuities.</para>
		/// <para>Group—Defines the group of each contributing feature. Unspecification of breaklines and polygon surface features representing the same geographic features at different levels of detail are intended for display at certain scale ranges. Data representing the same geographic features at different levels of detail can be grouped by assigning the same numeric value. For example, assigning two boundary features with a high and low level of detail to the same group would ensure there is no overlap in their associated display scale range.</para>
		/// <para>Min/Max Resolution—Defines the range of pyramid resolutions at which the feature is enforced in the terrain. Mass points must use the smallest and largest range of values.</para>
		/// <para>Overview—Indicates whether the feature is enforced at the coarsest representation of the terrain dataset. To maximize display performance, make sure that feature classes represented in the overview contain simplified geometry. Only valid for feature types other than mass points.</para>
		/// <para>Embed—Setting this option to TRUE indicates the source features will be copied to a hidden feature class that will be referenced by and only available to the terrain. Embedded features will not be directly viewable, as they can only be accessed through terrain tools. Only valid for multipoint features.</para>
		/// <para>Embed Name—Name of the embedded feature class. Only applies if the feature is being embedded.</para>
		/// <para>Embed Fields—Specifies BLOB field attributes to be retained in the embedded feature class. These attributes can be used to symbolize the terrain. LAS attribution can be stored in BLOB fields of multipoint features through the LAS To Multipoint tool.</para>
		/// <para>Anchor—Specifies whether the point feature class will be anchored through all terrain pyramid levels. Anchor points are never filtered or thinned away to ensure they persist in the terrain surface. This option only applies to single-point feature classes.</para>
		/// </param>
		public AddFeatureClassToTerrain(object InTerrain, object InFeatures)
		{
			this.InTerrain = InTerrain;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Feature Class To Terrain</para>
		/// </summary>
		public override string DisplayName() => "Add Feature Class To Terrain";

		/// <summary>
		/// <para>Tool Name : AddFeatureClassToTerrain</para>
		/// </summary>
		public override string ToolName() => "AddFeatureClassToTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddFeatureClassToTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddFeatureClassToTerrain";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerrain, InFeatures, DerivedOutTerrain };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain to which feature classes will be added. The terrain dataset must already have one or more pyramid levels created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>Identifies features being added to the terrain. Each feature must reside in the same feature dataset as the terrain and have its role defined through the following properties:</para>
		/// <para>Input Features—Name of the feature class being added to the terrain.</para>
		/// <para>Height Field—Field containing the feature&apos;s height information. Any numeric field can be specified, and z-enabled features can also choose the geometry field. If the &lt;none&gt; option is chosen, z-values are interpolated from the surface.</para>
		/// <para>Type—Surface feature type that defines how the features contributes to the terrain. Mass points denote features that contribute z-measurements; breaklines denote linear features with known z-measurements, and several polygon types. Breaklines and polygon-based feature types also have hard and soft qualifiers that define the interpolation behavior around the feature&apos;s edges when exporting to raster. Soft features exhibit gradual changes in slope, whereas hard features represent sharp discontinuities.</para>
		/// <para>Group—Defines the group of each contributing feature. Unspecification of breaklines and polygon surface features representing the same geographic features at different levels of detail are intended for display at certain scale ranges. Data representing the same geographic features at different levels of detail can be grouped by assigning the same numeric value. For example, assigning two boundary features with a high and low level of detail to the same group would ensure there is no overlap in their associated display scale range.</para>
		/// <para>Min/Max Resolution—Defines the range of pyramid resolutions at which the feature is enforced in the terrain. Mass points must use the smallest and largest range of values.</para>
		/// <para>Overview—Indicates whether the feature is enforced at the coarsest representation of the terrain dataset. To maximize display performance, make sure that feature classes represented in the overview contain simplified geometry. Only valid for feature types other than mass points.</para>
		/// <para>Embed—Setting this option to TRUE indicates the source features will be copied to a hidden feature class that will be referenced by and only available to the terrain. Embedded features will not be directly viewable, as they can only be accessed through terrain tools. Only valid for multipoint features.</para>
		/// <para>Embed Name—Name of the embedded feature class. Only applies if the feature is being embedded.</para>
		/// <para>Embed Fields—Specifies BLOB field attributes to be retained in the embedded feature class. These attributes can be used to symbolize the terrain. LAS attribution can be stored in BLOB fields of multipoint features through the LAS To Multipoint tool.</para>
		/// <para>Anchor—Specifies whether the point feature class will be anchored through all terrain pyramid levels. Anchor points are never filtered or thinned away to ensure they persist in the terrain surface. This option only applies to single-point feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTerrainLayer()]
		public object DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddFeatureClassToTerrain SetEnviroment(int? autoCommit = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
