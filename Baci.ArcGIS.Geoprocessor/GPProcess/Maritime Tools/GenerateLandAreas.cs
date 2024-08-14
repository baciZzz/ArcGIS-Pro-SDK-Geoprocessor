using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Generate Land Areas</para>
	/// <para>Creates land area polygon features by identifying existing land topology features, such as coastline and shoreline construction, and eliminating any polygons over water or other exclusionary features. An area of interest is specified to limit the processing area.</para>
	/// </summary>
	public class GenerateLandAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The workspace containing a Maritime product schema (S-57 or S-101 based) in which existing land topology features, such as coastline and shoreline construction, will be processed to identify the land areas that will be created.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The workspace that will contain the land area polygons that are created. The workspace must be a Nautical workspace with S-57 or S-101 schema. For S-57 schema, the workspace should have a NaturalFeaturesA polygon feature class with a LNDARE_LandArea subtype. For S-101 schema, the workspace should have a LandArea_A polygon feature class.</para>
		/// </param>
		/// <param name="InExtentPolygon">
		/// <para>Extent Polygon Features</para>
		/// <para>The extent polygon in which the land area polygons will be generated.</para>
		/// </param>
		public GenerateLandAreas(object InWorkspace, object TargetWorkspace, object InExtentPolygon)
		{
			this.InWorkspace = InWorkspace;
			this.TargetWorkspace = TargetWorkspace;
			this.InExtentPolygon = InExtentPolygon;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Land Areas</para>
		/// </summary>
		public override string DisplayName => "Generate Land Areas";

		/// <summary>
		/// <para>Tool Name : GenerateLandAreas</para>
		/// </summary>
		public override string ToolName => "GenerateLandAreas";

		/// <summary>
		/// <para>Tool Excute Name : maritime.GenerateLandAreas</para>
		/// </summary>
		public override string ExcuteName => "maritime.GenerateLandAreas";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, TargetWorkspace, InExtentPolygon, InConfigurationFile!, UpdatedLandAreas! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The workspace containing a Maritime product schema (S-57 or S-101 based) in which existing land topology features, such as coastline and shoreline construction, will be processed to identify the land areas that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The workspace that will contain the land area polygons that are created. The workspace must be a Nautical workspace with S-57 or S-101 schema. For S-57 schema, the workspace should have a NaturalFeaturesA polygon feature class with a LNDARE_LandArea subtype. For S-101 schema, the workspace should have a LandArea_A polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Extent Polygon Features</para>
		/// <para>The extent polygon in which the land area polygons will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InExtentPolygon { get; set; }

		/// <summary>
		/// <para>Configuration File</para>
		/// <para>The location of an .xml configuration file that lists the feature classes that will participate in defining the land topology edges and the feature classes that indicate areas where land should not exist. If not specified, the default GenerateLandAreasSettings.xml configuration file will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InConfigurationFile { get; set; }

		/// <summary>
		/// <para>Updated Land Areas</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedLandAreas { get; set; }

	}
}
