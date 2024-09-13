using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Iso Cluster</para>
	/// <para>Iso 聚类</para>
	/// <para>使用 isodata 聚类算法来确定多维属性空间中像元自然分组的特征并将结果存储在输出 ASCII 特征文件中。</para>
	/// </summary>
	public class IsoCluster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutSignatureFile">
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </param>
		/// <param name="NumberClasses">
		/// <para>Number of classes</para>
		/// <para>要将像元划分成的类数目。</para>
		/// </param>
		public IsoCluster(object InRasterBands, object OutSignatureFile, object NumberClasses)
		{
			this.InRasterBands = InRasterBands;
			this.OutSignatureFile = OutSignatureFile;
			this.NumberClasses = NumberClasses;
		}

		/// <summary>
		/// <para>Tool Display Name : Iso 聚类</para>
		/// </summary>
		public override string DisplayName() => "Iso 聚类";

		/// <summary>
		/// <para>Tool Name : IsoCluster</para>
		/// </summary>
		public override string ToolName() => "IsoCluster";

		/// <summary>
		/// <para>Tool Excute Name : sa.IsoCluster</para>
		/// </summary>
		public override string ExcuteName() => "sa.IsoCluster";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, OutSignatureFile, NumberClasses, NumberIterations, MinClassSize, SampleInterval };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object OutSignatureFile { get; set; }

		/// <summary>
		/// <para>Number of classes</para>
		/// <para>要将像元划分成的类数目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPNumericDomain()]
		[High(Allow = true, Value = 32767)]
		public object NumberClasses { get; set; }

		/// <summary>
		/// <para>Number of iterations</para>
		/// <para>要运行的聚类过程的迭代次数。</para>
		/// <para>默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberIterations { get; set; } = "20";

		/// <summary>
		/// <para>Minimum class size</para>
		/// <para>一个有效类中的最小像元数。</para>
		/// <para>默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object MinClassSize { get; set; } = "20";

		/// <summary>
		/// <para>Sample interval</para>
		/// <para>采样所使用的间隔。</para>
		/// <para>默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object SampleInterval { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IsoCluster SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
