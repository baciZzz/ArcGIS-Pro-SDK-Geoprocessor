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
	/// <para>Band Collection Statistics</para>
	/// <para>波段集统计</para>
	/// <para>计算一组栅格波段的统计信息。</para>
	/// </summary>
	public class BandCollectionStats : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="OutStatFile">
		/// <para>Output statistics file</para>
		/// <para>包含统计数据的输出 ASCII 文件。</para>
		/// <para>需要使用 .txt 扩展名。</para>
		/// </param>
		public BandCollectionStats(object InRasterBands, object OutStatFile)
		{
			this.InRasterBands = InRasterBands;
			this.OutStatFile = OutStatFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 波段集统计</para>
		/// </summary>
		public override string DisplayName() => "波段集统计";

		/// <summary>
		/// <para>Tool Name : BandCollectionStats</para>
		/// </summary>
		public override string ToolName() => "BandCollectionStats";

		/// <summary>
		/// <para>Tool Excute Name : sa.BandCollectionStats</para>
		/// </summary>
		public override string ExcuteName() => "sa.BandCollectionStats";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, OutStatFile, ComputeMatrices };

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
		/// <para>Output statistics file</para>
		/// <para>包含统计数据的输出 ASCII 文件。</para>
		/// <para>需要使用 .txt 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutStatFile { get; set; }

		/// <summary>
		/// <para>Compute covariance and correlation matrices</para>
		/// <para>指定是否计算协方差和相关矩阵。</para>
		/// <para>未选中 - 仅计算每个图层的基本统计测量值（最小值、最大值、平均值和标准差）。这是默认设置。</para>
		/// <para>选中 - 除了计算标准的统计数据外，还要确定协方差和相关矩阵。</para>
		/// <para><see cref="ComputeMatricesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeMatrices { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BandCollectionStats SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute covariance and correlation matrices</para>
		/// </summary>
		public enum ComputeMatricesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("BRIEF")]
			BRIEF,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DETAILED")]
			DETAILED,

		}

#endregion
	}
}
