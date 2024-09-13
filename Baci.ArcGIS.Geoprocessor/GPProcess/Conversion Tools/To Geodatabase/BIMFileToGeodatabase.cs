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
	/// <para>BIM 文件至地理数据库</para>
	/// <para>将一个或多个 BIM 文件工作空间的内容导入单个地理数据库要素数据集。</para>
	/// </summary>
	public class BIMFileToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBimFileWorkspace">
		/// <para>Input BIM File Workspace</para>
		/// <para>将转换为地理数据库要素类的一个或多个 BIM 文件。</para>
		/// </param>
		/// <param name="OutGdbPath">
		/// <para>Output Geodatabase</para>
		/// <para>将创建输出要素数据集的地理数据库。 该地理数据库必须是现有的地理数据库。</para>
		/// </param>
		/// <param name="OutDatasetName">
		/// <para>Dataset</para>
		/// <para>建筑数据集名称。</para>
		/// </param>
		public BIMFileToGeodatabase(object InBimFileWorkspace, object OutGdbPath, object OutDatasetName)
		{
			this.InBimFileWorkspace = InBimFileWorkspace;
			this.OutGdbPath = OutGdbPath;
			this.OutDatasetName = OutDatasetName;
		}

		/// <summary>
		/// <para>Tool Display Name : BIM 文件至地理数据库</para>
		/// </summary>
		public override string DisplayName() => "BIM 文件至地理数据库";

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
		public override object[] Parameters() => new object[] { InBimFileWorkspace, OutGdbPath, OutDatasetName, SpatialReference, Identifier, OutFeatureDataset, OutFeatureclassDataset };

		/// <summary>
		/// <para>Input BIM File Workspace</para>
		/// <para>将转换为地理数据库要素类的一个或多个 BIM 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InBimFileWorkspace { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>将创建输出要素数据集的地理数据库。 该地理数据库必须是现有的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutGdbPath { get; set; }

		/// <summary>
		/// <para>Dataset</para>
		/// <para>建筑数据集名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutDatasetName { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出要素数据集的空间参考。</para>
		/// <para>要控制空间参考的其他方面（例如，xy 值域、z 值域、m 值域、分辨率和容差），设置相应的地理处理环境。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Identifier</para>
		/// <para>将添加到所有输出要素类中的唯一建筑物标识符。 您可利用标识符为每个稍后要使用的建筑物添加唯一的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Identifier { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureDataset()]
		public object OutFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutFeatureclassDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BIMFileToGeodatabase SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

	}
}
