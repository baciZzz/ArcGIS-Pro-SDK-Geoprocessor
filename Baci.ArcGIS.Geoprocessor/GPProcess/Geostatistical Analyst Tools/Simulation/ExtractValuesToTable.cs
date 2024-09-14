using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Extract Values To Table</para>
	/// <para>提取值到表</para>
	/// <para>基于点或面要素类将一组栅格中的单元值提取到表。</para>
	/// </summary>
	public class ExtractValuesToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>要创建的点或面要素。</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>栅格必须具有相同的范围、坐标系和像元大小。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>对于每个包含数据的点和栅格，输出表中都有对应的记录。如果输入为面要素，则将它们转换为与栅格像元中心重合的点。</para>
		/// </param>
		public ExtractValuesToTable(object InFeatures, object InRasters, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.InRasters = InRasters;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 提取值到表</para>
		/// </summary>
		public override string DisplayName() => "提取值到表";

		/// <summary>
		/// <para>Tool Name : ExtractValuesToTable</para>
		/// </summary>
		public override string ToolName() => "ExtractValuesToTable";

		/// <summary>
		/// <para>Tool Excute Name : ga.ExtractValuesToTable</para>
		/// </summary>
		public override string ExcuteName() => "ga.ExtractValuesToTable";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InRasters, OutTable, OutRasterNamesTable!, AddWarningField! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>要创建的点或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>栅格必须具有相同的范围、坐标系和像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>对于每个包含数据的点和栅格，输出表中都有对应的记录。如果输入为面要素，则将它们转换为与栅格像元中心重合的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output raster names table</para>
		/// <para>将“输入”栅格的名称保存到磁盘中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutRasterNamesTable { get; set; }

		/// <summary>
		/// <para>Add warnings to output table</para>
		/// <para>用于在“输入”栅格部分或全部覆盖输入要素时进行记录。</para>
		/// <para>选中 - 向输出表中添加警告字段，且当栅格值部分覆盖要素时用“P”填充该字段。</para>
		/// <para>未选中 - 不向输出表中添加警告字段。</para>
		/// <para><see cref="AddWarningFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddWarningField { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractValuesToTable SetEnviroment(object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add warnings to output table</para>
		/// </summary>
		public enum AddWarningFieldEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_WARNING_FIELD")]
			ADD_WARNING_FIELD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_ADD_WARNING_FIELD")]
			DO_NOT_ADD_WARNING_FIELD,

		}

#endregion
	}
}
