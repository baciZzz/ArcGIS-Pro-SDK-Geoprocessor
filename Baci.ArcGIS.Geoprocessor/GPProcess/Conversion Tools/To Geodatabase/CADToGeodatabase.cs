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
	/// <para>CAD To Geodatabase</para>
	/// <para>Reads a CAD dataset and creates feature classes of the drawing. The feature classes are written to a geodatabase feature dataset.</para>
	/// </summary>
	public class CADToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputCadDatasets">
		/// <para>Input CAD Datasets</para>
		/// <para>The collection of CAD files to convert to geodatabase features.</para>
		/// </param>
		/// <param name="OutGdbPath">
		/// <para>Output Geodatabase</para>
		/// <para>The geodatabase where the output feature dataset will be created. This geodatabase must already exist.</para>
		/// </param>
		/// <param name="OutDatasetName">
		/// <para>Dataset</para>
		/// <para>The name of the feature dataset to be created.</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference scale</para>
		/// <para>This parameter is not needed for this tool as CAD annotation is treated as points in ArcGIS Pro.</para>
		/// </param>
		public CADToGeodatabase(object InputCadDatasets, object OutGdbPath, object OutDatasetName, object ReferenceScale)
		{
			this.InputCadDatasets = InputCadDatasets;
			this.OutGdbPath = OutGdbPath;
			this.OutDatasetName = OutDatasetName;
			this.ReferenceScale = ReferenceScale;
		}

		/// <summary>
		/// <para>Tool Display Name : CAD To Geodatabase</para>
		/// </summary>
		public override string DisplayName => "CAD To Geodatabase";

		/// <summary>
		/// <para>Tool Name : CADToGeodatabase</para>
		/// </summary>
		public override string ToolName => "CADToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.CADToGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "conversion.CADToGeodatabase";

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
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputCadDatasets, OutGdbPath, OutDatasetName, ReferenceScale, SpatialReference!, OutDataset! };

		/// <summary>
		/// <para>Input CAD Datasets</para>
		/// <para>The collection of CAD files to convert to geodatabase features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputCadDatasets { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The geodatabase where the output feature dataset will be created. This geodatabase must already exist.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object OutGdbPath { get; set; }

		/// <summary>
		/// <para>Dataset</para>
		/// <para>The name of the feature dataset to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutDatasetName { get; set; }

		/// <summary>
		/// <para>Reference scale</para>
		/// <para>This parameter is not needed for this tool as CAD annotation is treated as points in ArcGIS Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output feature dataset. If you wish to control other aspects of the spatial reference, such as the xy, z, m domains, resolutions, and tolerances, set the appropriate geoprocessing environments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object? OutDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CADToGeodatabase SetEnviroment(double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
