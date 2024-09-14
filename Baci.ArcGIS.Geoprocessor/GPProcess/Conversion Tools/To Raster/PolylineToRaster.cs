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
	/// <para>Polyline to Raster</para>
	/// <para>折线转栅格</para>
	/// <para>将折线要素转换为栅格数据集。</para>
	/// </summary>
	public class PolylineToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要转换为栅格的折线输入要素数据集。</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>用于向输出栅格分配值的字段。</para>
		/// <para>可以是输入要素数据集属性表中的任何字段。</para>
		/// </param>
		/// <param name="OutRasterdataset">
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </param>
		public PolylineToRaster(object InFeatures, object ValueField, object OutRasterdataset)
		{
			this.InFeatures = InFeatures;
			this.ValueField = ValueField;
			this.OutRasterdataset = OutRasterdataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 折线转栅格</para>
		/// </summary>
		public override string DisplayName() => "折线转栅格";

		/// <summary>
		/// <para>Tool Name : PolylineToRaster</para>
		/// </summary>
		public override string ToolName() => "PolylineToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.PolylineToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.PolylineToRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ValueField, OutRasterdataset, CellAssignment, PriorityField, Cellsize, BuildRat };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要转换为栅格的折线输入要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>用于向输出栅格分配值的字段。</para>
		/// <para>可以是输入要素数据集属性表中的任何字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID")]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的输出栅格数据集。</para>
		/// <para>如果不希望将输出栅格保存到地理数据库，请为 TIFF 文件格式指定 .tif，为 CRF 文件格式指定 .CRF，为 ERDAS IMAGINE 文件格式指定 .img，而对于 Esri Grid 栅格格式，无需指定扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRasterdataset { get; set; }

		/// <summary>
		/// <para>Cell assignment type</para>
		/// <para>用于确定当多个要素落在一个像元中时如何为像元分配值的方法。</para>
		/// <para>最大长度—具有覆盖像元的最大长度的要素确定分配给像元的值。</para>
		/// <para>最大合并长度—如果像元中有多个要素具有相同的值，则合并这些要素的长度。像元中具有最大长度的合并要素确定分配给像元的值。</para>
		/// <para><see cref="CellAssignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CellAssignment { get; set; } = "MAXIMUM_LENGTH";

		/// <summary>
		/// <para>Priority field</para>
		/// <para>此字段用于确定哪个要素应该优先于像元外的其他要素。使用时，无论选择何种像元分配类型，始终为转换选择优先级为最大正值的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[KeyField("NONE")]
		public object PriorityField { get; set; } = "NONE";

		/// <summary>
		/// <para>Cellsize</para>
		/// <para>正在创建的输出栅格的像元大小。</para>
		/// <para>此参数可以通过数值进行定义，也可以从现有栅格数据集获取。如果未将像元大小明确指定为参数值，则将使用环境像元大小值（如果已指定）；否则，将使用其他规则通过其他输出计算像元大小。有关详细信息，请参阅“用法”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPCompositeDomain()]
		public object Cellsize { get; set; }

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// <para>指定输出栅格是否将具有栅格属性表。</para>
		/// <para>此参数仅适用于整型栅格。</para>
		/// <para>选中 - 输出栅格将具有栅格属性表。这是默认设置。</para>
		/// <para>未选中 - 输出栅格将不具有栅格属性表。</para>
		/// <para><see cref="BuildRatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildRat { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolylineToRaster SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object pyramid = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell assignment type</para>
		/// </summary>
		public enum CellAssignmentEnum 
		{
			/// <summary>
			/// <para>最大长度—具有覆盖像元的最大长度的要素确定分配给像元的值。</para>
			/// </summary>
			[GPValue("MAXIMUM_LENGTH")]
			[Description("最大长度")]
			Maximum_length,

			/// <summary>
			/// <para>最大合并长度—如果像元中有多个要素具有相同的值，则合并这些要素的长度。像元中具有最大长度的合并要素确定分配给像元的值。</para>
			/// </summary>
			[GPValue("MAXIMUM_COMBINED_LENGTH")]
			[Description("最大合并长度")]
			Maximum_combined_length,

		}

		/// <summary>
		/// <para>Build raster attribute table</para>
		/// </summary>
		public enum BuildRatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD")]
			BUILD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD")]
			DO_NOT_BUILD,

		}

#endregion
	}
}
