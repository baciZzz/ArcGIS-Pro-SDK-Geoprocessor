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
	/// <para>Repair Mosaic Dataset Paths</para>
	/// <para>修复镶嵌数据集路径</para>
	/// <para>如果曾移动或复制镶嵌数据集，请重置源影像的路径。</para>
	/// </summary>
	public class RepairMosaicDatasetPaths : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>包含损坏路径的镶嵌数据集。</para>
		/// </param>
		/// <param name="PathsList">
		/// <para>Paths List</para>
		/// <para>一系列要重新映射的路径。其中包括在镶嵌数据集中存储的当前路径以及将更改的路径。如果要更改所有路径，可输入星号 (*) 作为原始路径。</para>
		/// </param>
		public RepairMosaicDatasetPaths(object InMosaicDataset, object PathsList)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.PathsList = PathsList;
		}

		/// <summary>
		/// <para>Tool Display Name : 修复镶嵌数据集路径</para>
		/// </summary>
		public override string DisplayName() => "修复镶嵌数据集路径";

		/// <summary>
		/// <para>Tool Name : RepairMosaicDatasetPaths</para>
		/// </summary>
		public override string ToolName() => "RepairMosaicDatasetPaths";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairMosaicDatasetPaths</para>
		/// </summary>
		public override string ExcuteName() => "management.RepairMosaicDatasetPaths";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, PathsList, WhereClause, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>包含损坏路径的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Paths List</para>
		/// <para>一系列要重新映射的路径。其中包括在镶嵌数据集中存储的当前路径以及将更改的路径。如果要更改所有路径，可输入星号 (*) 作为原始路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object PathsList { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>将修复限制为镶嵌数据集中所选栅格的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Repaired Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairMosaicDatasetPaths SetEnviroment(object extent = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
