using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Export Mosaic Dataset Paths</para>
	/// <para>导出镶嵌数据集路径</para>
	/// <para>为镶嵌数据集中的各个项创建文件路径表。可指定该表是包含所有文件路径，还是只包含损坏的路径。</para>
	/// </summary>
	public class ExportMosaicDatasetPaths : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>包含要导出的文件路径的镶嵌数据集。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>要创建的表。表可以是地理数据库表或 .dbf 文件。</para>
		/// <para>输出表中的 SourceOID 字段从原始镶嵌数据集表中行的 OID 中获取。</para>
		/// </param>
		public ExportMosaicDatasetPaths(object InMosaicDataset, object OutTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出镶嵌数据集路径</para>
		/// </summary>
		public override string DisplayName() => "导出镶嵌数据集路径";

		/// <summary>
		/// <para>Tool Name : ExportMosaicDatasetPaths</para>
		/// </summary>
		public override string ToolName() => "ExportMosaicDatasetPaths";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportMosaicDatasetPaths</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportMosaicDatasetPaths";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutTable, WhereClause, ExportMode, TypesOfPaths };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>包含要导出的文件路径的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>要创建的表。表可以是地理数据库表或 .dbf 文件。</para>
		/// <para>输出表中的 SourceOID 字段从原始镶嵌数据集表中行的 OID 中获取。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用于选择待导出的特定栅格的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Export Mode</para>
		/// <para>可以用所有路径填充表，或者仅以损坏的路径填充。</para>
		/// <para>所有路径—将所有路径导出至表。这是默认设置。</para>
		/// <para>仅损坏的路径—仅将损坏的路径导出至表。</para>
		/// <para><see cref="ExportModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportMode { get; set; } = "ALL";

		/// <summary>
		/// <para>Types of paths to export</para>
		/// <para>选择只从源栅格导出文件路径，只从缓存中导出，还是从二者同时导出。默认设置为导出所有路径类型。</para>
		/// <para>栅格—从栅格中导出文件路径。</para>
		/// <para>项目缓存—从项缓存中导出文件路径。</para>
		/// <para><see cref="TypesOfPathsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TypesOfPaths { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetPaths SetEnviroment(object configKeyword = null, object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Mode</para>
		/// </summary>
		public enum ExportModeEnum 
		{
			/// <summary>
			/// <para>所有路径—将所有路径导出至表。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有路径")]
			All_paths,

			/// <summary>
			/// <para>仅损坏的路径—仅将损坏的路径导出至表。</para>
			/// </summary>
			[GPValue("BROKEN")]
			[Description("仅损坏的路径")]
			Broken_paths_only,

		}

		/// <summary>
		/// <para>Types of paths to export</para>
		/// </summary>
		public enum TypesOfPathsEnum 
		{
			/// <summary>
			/// <para>栅格—从栅格中导出文件路径。</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("栅格")]
			Raster,

			/// <summary>
			/// <para>项目缓存—从项缓存中导出文件路径。</para>
			/// </summary>
			[GPValue("ITEM_CACHE")]
			[Description("项目缓存")]
			Item_cache,

		}

#endregion
	}
}
