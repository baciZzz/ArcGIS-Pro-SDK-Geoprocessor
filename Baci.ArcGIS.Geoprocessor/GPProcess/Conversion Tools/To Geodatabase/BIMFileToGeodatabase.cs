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
	/// <para>BIM File To Geodatabase</para>
	/// <para>BIM File To Geodatabase</para>
	/// <para>Imports the contents of one or more BIM file workspaces into a single geodatabase feature dataset.</para>
	/// </summary>
	public class BIMFileToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBimFileWorkspace">
		/// <para>Input BIM File Workspace</para>
		/// <para>The BIM file or files that will be converted to geodatabase feature classes.</para>
		/// </param>
		/// <param name="OutGdbPath">
		/// <para>Output Geodatabase</para>
		/// <para>The geodatabase where the output feature dataset will be created. This must be an existing geodatabase.</para>
		/// </param>
		/// <param name="OutDatasetName">
		/// <para>Dataset</para>
		/// <para>The building dataset name.</para>
		/// </param>
		public BIMFileToGeodatabase(object InBimFileWorkspace, object OutGdbPath, object OutDatasetName)
		{
			this.InBimFileWorkspace = InBimFileWorkspace;
			this.OutGdbPath = OutGdbPath;
			this.OutDatasetName = OutDatasetName;
		}

		/// <summary>
		/// <para>Tool Display Name : BIM File To Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "BIM File To Geodatabase";

		/// <summary>
		/// <para>Tool Name : BIMFileToGeodatabase</para>
		/// </summary>
		public override string ToolName() => "BIMFileToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.BIMFileToGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "conversion.BIMFileToGeodatabase";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBimFileWorkspace, OutGdbPath, OutDatasetName, SpatialReference!, Identifier!, OutFeatureDataset!, OutFeatureclassDataset! };

		/// <summary>
		/// <para>Input BIM File Workspace</para>
		/// <para>The BIM file or files that will be converted to geodatabase feature classes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InBimFileWorkspace { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The geodatabase where the output feature dataset will be created. This must be an existing geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutGdbPath { get; set; }

		/// <summary>
		/// <para>Dataset</para>
		/// <para>The building dataset name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutDatasetName { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output feature dataset.</para>
		/// <para>To control other aspects of the spatial reference, such as the x,y-, z-, and m- domains, resolutions, and tolerances, set the appropriate geoprocessing environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Identifier</para>
		/// <para>A unique building identifier that will be added to all output feature classes. The identifier allows you to add unique names to each building to be used at a later time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Identifier { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeatureclassDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BIMFileToGeodatabase SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
