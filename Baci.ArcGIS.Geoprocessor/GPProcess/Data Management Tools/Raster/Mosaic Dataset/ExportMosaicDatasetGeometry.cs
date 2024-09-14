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
	/// <para>Export Mosaic Dataset Geometry</para>
	/// <para>导出镶嵌数据集几何</para>
	/// <para>创建显示镶嵌数据集的轮廓线、边界、接缝线或空间分辨率的要素类。</para>
	/// </summary>
	public class ExportMosaicDatasetGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>想要从中导出几何的镶嵌数据集。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>为您正在创建的要素类命名。</para>
		/// </param>
		public ExportMosaicDatasetGeometry(object InMosaicDataset, object OutFeatureClass)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出镶嵌数据集几何</para>
		/// </summary>
		public override string DisplayName() => "导出镶嵌数据集几何";

		/// <summary>
		/// <para>Tool Name : ExportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ToolName() => "ExportMosaicDatasetGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportMosaicDatasetGeometry";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutFeatureClass, WhereClause, GeometryType };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>想要从中导出几何的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>为您正在创建的要素类命名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中导出特定栅格的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>要导出的几何的类型。</para>
		/// <para>轮廓线— 创建显示每个影像的轮廓线的要素类。</para>
		/// <para>边界— 创建显示镶嵌数据集的边界的要素类。</para>
		/// <para>接缝线— 创建显示接缝线的要素类。</para>
		/// <para>像元大小等级— 根据镶嵌数据集中要素的像元大小等级创建要素类。</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "FOOTPRINT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportMosaicDatasetGeometry SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>轮廓线— 创建显示每个影像的轮廓线的要素类。</para>
			/// </summary>
			[GPValue("FOOTPRINT")]
			[Description("轮廓线")]
			Footprint,

			/// <summary>
			/// <para>边界— 创建显示镶嵌数据集的边界的要素类。</para>
			/// </summary>
			[GPValue("BOUNDARY")]
			[Description("边界")]
			Boundary,

			/// <summary>
			/// <para>接缝线— 创建显示接缝线的要素类。</para>
			/// </summary>
			[GPValue("SEAMLINE")]
			[Description("接缝线")]
			Seamline,

			/// <summary>
			/// <para>像元大小等级— 根据镶嵌数据集中要素的像元大小等级创建要素类。</para>
			/// </summary>
			[GPValue("LEVEL")]
			[Description("像元大小等级")]
			Cell_size_level,

		}

#endregion
	}
}
