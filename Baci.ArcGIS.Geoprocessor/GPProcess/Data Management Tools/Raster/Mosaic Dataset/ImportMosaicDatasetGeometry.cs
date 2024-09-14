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
	/// <para>Import Mosaic Dataset Geometry</para>
	/// <para>导入镶嵌数据集几何</para>
	/// <para>修改镶嵌数据集中轮廓线、边界或接缝线的几何，使其与要素类相匹配。</para>
	/// </summary>
	public class ImportMosaicDatasetGeometry : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>要编辑其几何的镶嵌数据集。</para>
		/// </param>
		/// <param name="TargetFeatureclassType">
		/// <para>Target Feature Class</para>
		/// <para>要更改的几何。</para>
		/// <para>轮廓线—镶嵌数据集中的轮廓线面</para>
		/// <para>接缝线—镶嵌数据集中的接缝面</para>
		/// <para>边界—镶嵌数据集中的边界面</para>
		/// <para><see cref="TargetFeatureclassTypeEnum"/></para>
		/// </param>
		/// <param name="TargetJoinField">
		/// <para>Target Join Field</para>
		/// <para>镶嵌数据集中充当连接基础的字段。</para>
		/// </param>
		/// <param name="InputFeatureclass">
		/// <para>Input Feature Class</para>
		/// <para>具有新几何的要素类。</para>
		/// </param>
		/// <param name="InputJoinField">
		/// <para>Input Join Field</para>
		/// <para>输入要素类中用作连接基础的字段。</para>
		/// <para>如果输入要素类具有的记录超过 1,000 条，则应通过运行 Add_Attribute_Index 工具在该字段上添加索引。如果镶嵌数据集非常大而未在连接字段上建立索引，则该工具将花费非常长的时间才能完成。</para>
		/// </param>
		public ImportMosaicDatasetGeometry(object InMosaicDataset, object TargetFeatureclassType, object TargetJoinField, object InputFeatureclass, object InputJoinField)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.TargetFeatureclassType = TargetFeatureclassType;
			this.TargetJoinField = TargetJoinField;
			this.InputFeatureclass = InputFeatureclass;
			this.InputJoinField = InputJoinField;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入镶嵌数据集几何</para>
		/// </summary>
		public override string DisplayName() => "导入镶嵌数据集几何";

		/// <summary>
		/// <para>Tool Name : ImportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ToolName() => "ImportMosaicDatasetGeometry";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportMosaicDatasetGeometry</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportMosaicDatasetGeometry";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, TargetFeatureclassType, TargetJoinField, InputFeatureclass, InputJoinField, OutMosaicDataset! };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>要编辑其几何的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Target Feature Class</para>
		/// <para>要更改的几何。</para>
		/// <para>轮廓线—镶嵌数据集中的轮廓线面</para>
		/// <para>接缝线—镶嵌数据集中的接缝面</para>
		/// <para>边界—镶嵌数据集中的边界面</para>
		/// <para><see cref="TargetFeatureclassTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TargetFeatureclassType { get; set; }

		/// <summary>
		/// <para>Target Join Field</para>
		/// <para>镶嵌数据集中充当连接基础的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID")]
		public object TargetJoinField { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>具有新几何的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputFeatureclass { get; set; }

		/// <summary>
		/// <para>Input Join Field</para>
		/// <para>输入要素类中用作连接基础的字段。</para>
		/// <para>如果输入要素类具有的记录超过 1,000 条，则应通过运行 Add_Attribute_Index 工具在该字段上添加索引。如果镶嵌数据集非常大而未在连接字段上建立索引，则该工具将花费非常长的时间才能完成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID")]
		public object InputJoinField { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object? OutMosaicDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Target Feature Class</para>
		/// </summary>
		public enum TargetFeatureclassTypeEnum 
		{
			/// <summary>
			/// <para>轮廓线—镶嵌数据集中的轮廓线面</para>
			/// </summary>
			[GPValue("FOOTPRINT")]
			[Description("轮廓线")]
			Footprint,

			/// <summary>
			/// <para>接缝线—镶嵌数据集中的接缝面</para>
			/// </summary>
			[GPValue("SEAMLINE")]
			[Description("接缝线")]
			Seamline,

			/// <summary>
			/// <para>边界—镶嵌数据集中的边界面</para>
			/// </summary>
			[GPValue("BOUNDARY")]
			[Description("边界")]
			Boundary,

		}

#endregion
	}
}
