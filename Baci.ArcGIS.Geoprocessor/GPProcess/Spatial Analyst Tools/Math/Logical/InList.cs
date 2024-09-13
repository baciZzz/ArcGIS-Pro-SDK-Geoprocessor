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
	/// <para>InList</para>
	/// <para>InList</para>
	/// <para>逐个像元来确定第一个输入栅格中的哪些值同样包含在该组的其他输入栅格中。</para>
	/// </summary>
	public class InList : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterOrConstant">
		/// <para>Input raster or constant value</para>
		/// <para>定义将在栅格列表中逐个像元地查找的值的输入。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </param>
		/// <param name="InRasterOrConstants">
		/// <para>Input raster or constant values</para>
		/// <para>将对第一个输入进行评估的输入栅格的列表。对于每个位置，只要来自第一个输入的像元值存在于任何其他栅格中，则将该值分配给输出栅格。如果该值在任何其他栅格中都不存在，则该位置的输出值将为 NoData。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// </param>
		public InList(object InRasterOrConstant, object InRasterOrConstants, object OutRaster)
		{
			this.InRasterOrConstant = InRasterOrConstant;
			this.InRasterOrConstants = InRasterOrConstants;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : InList</para>
		/// </summary>
		public override string DisplayName() => "InList";

		/// <summary>
		/// <para>Tool Name : InList</para>
		/// </summary>
		public override string ToolName() => "InList";

		/// <summary>
		/// <para>Tool Excute Name : sa.InList</para>
		/// </summary>
		public override string ExcuteName() => "sa.InList";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterOrConstant, InRasterOrConstants, OutRaster, ProcessAsMultiband };

		/// <summary>
		/// <para>Input raster or constant value</para>
		/// <para>定义将在栅格列表中逐个像元地查找的值的输入。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstant { get; set; }

		/// <summary>
		/// <para>Input raster or constant values</para>
		/// <para>将对第一个输入进行评估的输入栅格的列表。对于每个位置，只要来自第一个输入的像元值存在于任何其他栅格中，则将该值分配给输出栅格。如果该值在任何其他栅格中都不存在，则该位置的输出值将为 NoData。</para>
		/// <para>假如已为其他参数指定栅格，则可将数字用作此参数的输入。 要为两个输入指定数字，像元大小和范围必须先在环境中进行设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "GPRasterFormulated", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile", "GPDouble", "GPLong")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterOrConstants { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>输出栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Process as multiband</para>
		/// <para>指定如何处理输入多波段栅格波段。</para>
		/// <para>未选中 - 来自多波段栅格输入的每个波段将被单独处理为单波段栅格。 这是默认设置。</para>
		/// <para>选中 - 每个多波段栅格输入都将作为多波段栅格进行处理。 将使用其他输入的相应波段数对一个输入的每个波段执行操作。</para>
		/// <para><see cref="ProcessAsMultibandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ProcessAsMultiband { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InList SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Process as multiband</para>
		/// </summary>
		public enum ProcessAsMultibandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_BAND")]
			SINGLE_BAND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_BAND")]
			MULTI_BAND,

		}

#endregion
	}
}
