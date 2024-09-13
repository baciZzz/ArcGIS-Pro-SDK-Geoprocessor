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
	/// <para>CAD 至地理数据库</para>
	/// <para>读取 CAD 数据集并创建工程图对应的要素类。这些要素类将被写入地理数据库要素数据集中。</para>
	/// </summary>
	public class CADToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputCadDatasets">
		/// <para>Input CAD Datasets</para>
		/// <para>要转换为地理数据库要素的 CAD 文件的集合。</para>
		/// </param>
		/// <param name="OutGdbPath">
		/// <para>Output Geodatabase</para>
		/// <para>将创建输出要素数据集的地理数据库。此地理数据库必须已经存在。</para>
		/// </param>
		/// <param name="OutDatasetName">
		/// <para>Dataset</para>
		/// <para>要创建的要素数据集的名称。</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference scale</para>
		/// <para>由于 CAD 注记被视为 ArcGIS Pro 中的点，所以该工具不需要此参数。</para>
		/// </param>
		public CADToGeodatabase(object InputCadDatasets, object OutGdbPath, object OutDatasetName, object ReferenceScale)
		{
			this.InputCadDatasets = InputCadDatasets;
			this.OutGdbPath = OutGdbPath;
			this.OutDatasetName = OutDatasetName;
			this.ReferenceScale = ReferenceScale;
		}

		/// <summary>
		/// <para>Tool Display Name : CAD 至地理数据库</para>
		/// </summary>
		public override string DisplayName() => "CAD 至地理数据库";

		/// <summary>
		/// <para>Tool Name : CADToGeodatabase</para>
		/// </summary>
		public override string ToolName() => "CADToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.CADToGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "conversion.CADToGeodatabase";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputCadDatasets, OutGdbPath, OutDatasetName, ReferenceScale, SpatialReference!, OutDataset! };

		/// <summary>
		/// <para>Input CAD Datasets</para>
		/// <para>要转换为地理数据库要素的 CAD 文件的集合。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputCadDatasets { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>将创建输出要素数据集的地理数据库。此地理数据库必须已经存在。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutGdbPath { get; set; }

		/// <summary>
		/// <para>Dataset</para>
		/// <para>要创建的要素数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutDatasetName { get; set; }

		/// <summary>
		/// <para>Reference scale</para>
		/// <para>由于 CAD 注记被视为 ArcGIS Pro 中的点，所以该工具不需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出要素数据集的空间参考。如果要控制空间参考的其他方面（例如，xy 值域、z 值域、m 值域、分辨率和容差），请设置相应的地理处理环境。</para>
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
