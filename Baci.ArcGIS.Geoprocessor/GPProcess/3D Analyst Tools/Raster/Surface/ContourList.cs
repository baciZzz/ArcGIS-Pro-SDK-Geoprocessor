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
	/// <para>Contour List</para>
	/// <para>等值线列表</para>
	/// <para>根据栅格表面创建所选等值线值的要素类。</para>
	/// </summary>
	public class ContourList : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </param>
		/// <param name="OutPolylineFeatures">
		/// <para>Output polyline features</para>
		/// <para>输出等值线折线要素。</para>
		/// </param>
		/// <param name="ContourValues">
		/// <para>Contour values</para>
		/// <para>要创建等值线的 z 值的列表。</para>
		/// </param>
		public ContourList(object InRaster, object OutPolylineFeatures, object ContourValues)
		{
			this.InRaster = InRaster;
			this.OutPolylineFeatures = OutPolylineFeatures;
			this.ContourValues = ContourValues;
		}

		/// <summary>
		/// <para>Tool Display Name : 等值线列表</para>
		/// </summary>
		public override string DisplayName() => "等值线列表";

		/// <summary>
		/// <para>Tool Name : ContourList</para>
		/// </summary>
		public override string ToolName() => "ContourList";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ContourList</para>
		/// </summary>
		public override string ExcuteName() => "3d.ContourList";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutPolylineFeatures, ContourValues };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>输入表面栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = true)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output polyline features</para>
		/// <para>输出等值线折线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutPolylineFeatures { get; set; }

		/// <summary>
		/// <para>Contour values</para>
		/// <para>要创建等值线的 z 值的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object ContourValues { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ContourList SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
