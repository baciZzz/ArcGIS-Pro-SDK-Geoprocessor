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
	/// <para>Consolidate Map</para>
	/// <para>合并地图</para>
	/// <para>将地图和所有引用的数据源合并到一个指定的输出文件夹中。</para>
	/// </summary>
	public class ConsolidateMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>要合并的地图 (.mapx)。在 ArcGIS Pro 应用程序中运行此工具时，输入可以是地图、场景或底图。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>此输出文件夹将包含合并的地图和数据。</para>
		/// <para>如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </param>
		public ConsolidateMap(object InMap, object OutputFolder)
		{
			this.InMap = InMap;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并地图</para>
		/// </summary>
		public override string DisplayName() => "合并地图";

		/// <summary>
		/// <para>Tool Name : ConsolidateMap</para>
		/// </summary>
		public override string ToolName() => "ConsolidateMap";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateMap</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateMap";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutputFolder, ConvertData, ConvertArcsdeData, Extent, ApplyExtentToArcsde, PreserveSqlite, SelectRelatedRows };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>要合并的地图 (.mapx)。在 ArcGIS Pro 应用程序中运行此工具时，输入可以是地图、场景或底图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>此输出文件夹将包含合并的地图和数据。</para>
		/// <para>如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// <para>指定输入图层是转换为文件地理数据库还是保留原始格式。</para>
		/// <para>选中 - 所有数据将转换为文件地理数据库。此选项不适用于企业级地理数据库数据源。要包括企业级地理数据库数据，请选中包括企业级地理数据库数据，而不是仅引用该数据参数。</para>
		/// <para>未选中 - 保留数据格式（如有可能）。这是默认设置。</para>
		/// <para><see cref="ConvertDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertData { get; set; } = "false";

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// <para>指定是将输入企业级地理数据库图层转换为文件地理数据库，还是保留其原始格式。</para>
		/// <para>选中 - 所有企业级地理数据库数据源都将转换为文件地理数据库。这是默认设置。</para>
		/// <para>未选中 - 将保留所有企业级地理数据库数据源，并在生成的包中对其进行引用。</para>
		/// <para><see cref="ConvertArcsdeDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertArcsdeData { get; set; } = "true";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定用于选择或裁剪要素的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// <para>指定是将指定范围应用到所有图层，还是仅应用到企业级地理数据库图层。</para>
		/// <para>未选中 - 范围将应用到所有图层。这是默认设置。</para>
		/// <para>选中 - 范围将仅应用到企业级地理数据库图层。</para>
		/// <para><see cref="ApplyExtentToArcsdeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyExtentToArcsde { get; set; } = "false";

		/// <summary>
		/// <para>Preserve SQLite</para>
		/// <para>可以将输入 SQLite 数据保留为 SQLite 输出，而无需转换为文件地理数据库格式。当输入数据为 SQLite 时，此参数将覆盖将数据转换为文件地理数据库参数。如果输入数据为 SQLite 网络数据集，则输出将始终为 SQLite。</para>
		/// <para>未选中 - SQLite 数据将被转换为文件地理数据库。这是默认设置。</para>
		/// <para>选中 - 在合并文件夹中，SQLite 数据将保留为 SQLite。</para>
		/// <para><see cref="PreserveSqliteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveSqlite { get; set; } = "false";

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>指定是否将指定的范围应用至相关数据源。</para>
		/// <para>未选中 - 相关的数据源将全部合并。这是默认设置。</para>
		/// <para>选中 - 仅合并指定范围内与记录对应的相关数据。</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SelectRelatedRows { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConsolidateMap SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// </summary>
		public enum ConvertDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT")]
			CONVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE")]
			PRESERVE,

		}

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// </summary>
		public enum ConvertArcsdeDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT_ARCSDE")]
			CONVERT_ARCSDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_ARCSDE")]
			PRESERVE_ARCSDE,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToArcsdeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ARCSDE_ONLY")]
			ARCSDE_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Preserve SQLite</para>
		/// </summary>
		public enum PreserveSqliteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SQLITE")]
			PRESERVE_SQLITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_SQLITE")]
			CONVERT_SQLITE,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

#endregion
	}
}
