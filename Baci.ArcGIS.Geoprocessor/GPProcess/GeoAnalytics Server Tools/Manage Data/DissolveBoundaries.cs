using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Dissolve Boundaries</para>
	/// <para>融合边界</para>
	/// <para>查找相交或具有相同字段值的面，并将其合并为一个面。</para>
	/// </summary>
	public class DissolveBoundaries : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Features</para>
		/// <para>将要融合的包含面要素的图层。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		public DissolveBoundaries(object InputLayer, object OutputName)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
		}

		/// <summary>
		/// <para>Tool Display Name : 融合边界</para>
		/// </summary>
		public override string DisplayName() => "融合边界";

		/// <summary>
		/// <para>Tool Name : DissolveBoundaries</para>
		/// </summary>
		public override string ToolName() => "DissolveBoundaries";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.DissolveBoundaries</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.DissolveBoundaries";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, Multipart, DissolveFields, Fields, SummaryFields, Output, DataStore };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将要融合的包含面要素的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// <para>指定在输出要素类中是否将创建多部分要素。</para>
		/// <para>选中 - 将创建多部分要素。</para>
		/// <para>未选中 - 将不会创建多部分要素。相反，系统将为各部分创建单独的要素。这是默认设置。</para>
		/// <para><see cref="MultipartEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Multipart { get; set; } = "false";

		/// <summary>
		/// <para>Dissolve by Field Value(s)</para>
		/// <para>指定是否融合具有相同字段值的要素。</para>
		/// <para>未选中 - 共用公共边界的面（即相邻的面）或重叠的面将会被融合为一个面。这是默认设置。</para>
		/// <para>选中 - 具有相同字段值的面将被融合。</para>
		/// <para><see cref="DissolveFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DissolveFields { get; set; }

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>将用于融合类要素的一个或多个字段。各字段都具有相同值的要素将被融合。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// <para>计数 - 非空值的数目。可用于数值字段或字符串。[null, 0, 2] 的计数为 2。</para>
		/// <para>总和 - 字段内数值的总和。[null, null, 3] 的总和为 3。</para>
		/// <para>平均值 - 数值的平均值。[0, 2, null] 的平均值为 1。</para>
		/// <para>最小值 - 数值字段的最小值。[0, 2, null] 的最小值为 0。</para>
		/// <para>最大值 - 数值字段的最大值。[0, 2, null] 的最大值为 2。</para>
		/// <para>标准差 - 数值字段的标准差。[1] 的标准差为 null。[null, 1,1,1] 的标准差为 null。</para>
		/// <para>方差 - 轨迹中数值字段内数值的方差。[1] 的方差为 null。[null, 1, 1, 1] 的方差为 null。</para>
		/// <para>范围 - 数值字段的范围。其计算方法为最大值减去最小值。[0, null, 1] 的范围为 1。[null, 4] 的范围为 0。</para>
		/// <para>任何 - 字符串型字段中的示例字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DissolveBoundaries SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Multipart Features</para>
		/// </summary>
		public enum MultipartEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTI_PART")]
			MULTI_PART,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SINGLE_PART")]
			SINGLE_PART,

		}

		/// <summary>
		/// <para>Dissolve by Field Value(s)</para>
		/// </summary>
		public enum DissolveFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISSOLVE_FIELDS")]
			DISSOLVE_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISSOLVE_FIELDS")]
			NO_DISSOLVE_FIELDS,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
