using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Data Exists</para>
	/// <para>如果数据已存在</para>
	/// <para>用于评估指定数据是否已存在。</para>
	/// </summary>
	public class DataExistsIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public DataExistsIfThenElse()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : 如果数据已存在</para>
		/// </summary>
		public override string DisplayName() => "如果数据已存在";

		/// <summary>
		/// <para>Tool Name : DataExistsIfThenElse</para>
		/// </summary>
		public override string ToolName() => "DataExistsIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.DataExistsIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.DataExistsIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, DataType, True, False };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>要评估的输入数据元素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPType()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Data Type</para>
		/// <para>正在进行评估的数据元素的数据类型。仅当地理数据库中的要素数据集和要素类或表具有相同名称时，才需要提供一个值。在这种情况下，您需要为希望进行评估的项选择数据类型（要素数据集、要素类或表）。</para>
		/// <para>任何—任何值。这是默认设置。</para>
		/// <para>要素数据集—要素数据集</para>
		/// <para>要素类—要素类</para>
		/// <para>表—表</para>
		/// <para>视图—视图</para>
		/// <para>关系类—关系类</para>
		/// <para>栅格数据集—栅格数据集</para>
		/// <para>镶嵌数据集—镶嵌数据集</para>
		/// <para>工具箱—工具箱</para>
		/// <para>拓扑—拓扑</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "ANY";

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Data Type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>任何—任何值。这是默认设置。</para>
			/// </summary>
			[GPValue("ANY")]
			[Description("任何")]
			Any,

			/// <summary>
			/// <para>要素数据集—要素数据集</para>
			/// </summary>
			[GPValue("DEFeatureDataset")]
			[Description("要素数据集")]
			Feature_Dataset,

			/// <summary>
			/// <para>要素类—要素类</para>
			/// </summary>
			[GPValue("DEFeatureClass")]
			[Description("要素类")]
			Feature_Class,

			/// <summary>
			/// <para>表—表</para>
			/// </summary>
			[GPValue("DETable")]
			[Description("表")]
			Table,

			/// <summary>
			/// <para>视图—视图</para>
			/// </summary>
			[GPValue("DEView")]
			[Description("视图")]
			View,

			/// <summary>
			/// <para>关系类—关系类</para>
			/// </summary>
			[GPValue("DERelationshipClass")]
			[Description("关系类")]
			Relationship_Class,

			/// <summary>
			/// <para>栅格数据集—栅格数据集</para>
			/// </summary>
			[GPValue("DERasterDataset")]
			[Description("栅格数据集")]
			Raster_Dataset,

			/// <summary>
			/// <para>镶嵌数据集—镶嵌数据集</para>
			/// </summary>
			[GPValue("DEMosaicDataset")]
			[Description("镶嵌数据集")]
			Mosaic_Dataset,

			/// <summary>
			/// <para>工具箱—工具箱</para>
			/// </summary>
			[GPValue("DEToolbox")]
			[Description("工具箱")]
			Toolbox,

			/// <summary>
			/// <para>拓扑—拓扑</para>
			/// </summary>
			[GPValue("DETopology")]
			[Description("拓扑")]
			Topology,

		}

#endregion
	}
}
