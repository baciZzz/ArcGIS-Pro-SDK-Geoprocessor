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
	/// <para>Package Map</para>
	/// <para>打包地图</para>
	/// <para>对地图以及所有引用的数据源进行打包以创建单个压缩的 .mpkx 文件。</para>
	/// </summary>
	public class PackageMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input  Map</para>
		/// <para>要打包的地图 (.mapx)。在 ArcGIS Pro 中运行此工具时，输入可以是地图、场景或底图。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出地图包 (.mpkx)。</para>
		/// </param>
		public PackageMap(object InMap, object OutputFile)
		{
			this.InMap = InMap;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 打包地图</para>
		/// </summary>
		public override string DisplayName() => "打包地图";

		/// <summary>
		/// <para>Tool Name : PackageMap</para>
		/// </summary>
		public override string ToolName() => "PackageMap";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageMap</para>
		/// </summary>
		public override string ExcuteName() => "management.PackageMap";

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
		public override object[] Parameters() => new object[] { InMap, OutputFile, ConvertData, ConvertArcsdeData, Extent, ApplyExtentToArcsde, Arcgisruntime, ReferenceAllData, Version, AdditionalFiles, Summary, Tags, SelectRelatedRows };

		/// <summary>
		/// <para>Input  Map</para>
		/// <para>要打包的地图 (.mapx)。在 ArcGIS Pro 中运行此工具时，输入可以是地图、场景或底图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出地图包 (.mpkx)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mpkx")]
		public object OutputFile { get; set; }

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
		/// <para>Support ArcGIS Runtime</para>
		/// <para>指定包是否支持 ArcGIS Runtime。要支持 ArcGIS Runtime，所有数据源均需转换为文件地理数据库，并在输出包中创建 .msd 文件。</para>
		/// <para>未选中 - 输出包将不支持 ArcGIS Runtime。</para>
		/// <para>选中 - 输出包将支持 ArcGIS Runtime。</para>
		/// <para>仅 ArcGIS 10.x 可创建已启用 Runtime 的包。</para>
		/// <para><see cref="ArcgisruntimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Arcgisruntime { get; set; } = "false";

		/// <summary>
		/// <para>Reference all data for Runtime</para>
		/// <para>如果选中此选项，则会创建引用所需数据（而非复制数据）的包。在尝试打包位于组织内中心位置的大型数据集时，此选项十分有用。</para>
		/// <para>选中 - 创建一个引用所需数据（而非复制数据）的包。</para>
		/// <para>未选中 - 创建一个包含所有所需数据的包。这是默认设置。</para>
		/// <para><see cref="ReferenceAllDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReferenceAllData { get; set; } = "false";

		/// <summary>
		/// <para>Package version</para>
		/// <para>指定将在结果包中创建的地理数据库版本。指定版本可实现与之前版本的 ArcGIS 共享包，并可支持向后兼容。保存为之前版本的包可能会丢失仅适用于较新版本的属性。</para>
		/// <para>所有版本—包中将包含与所有版本（ArcGIS Pro 1.2 和更高版本）均兼容的地理数据库和地图。</para>
		/// <para>当前版本— 包中包含与当前版本兼容的地理数据库和地图。</para>
		/// <para>2.x—包中将包含与 2.0 和更高版本均兼容的地理数据库和地图。</para>
		/// <para>1.2—包中将包含与 1.2 和更高版本均兼容的地理数据库和地图。</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "ALL";

		/// <summary>
		/// <para>Additional Files</para>
		/// <para>将附加文件添加到包中。诸如 .doc、.txt、.pdf 等附加文件可用于提供有关打包内容和目的的详细信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object AdditionalFiles { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将摘要信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到包的属性中。可以添加多个标签，标签之间用逗号或分号进行分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

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
		public PackageMap SetEnviroment(object extent = null, object workspace = null)
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
		/// <para>Support ArcGIS Runtime</para>
		/// </summary>
		public enum ArcgisruntimeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RUNTIME")]
			RUNTIME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DESKTOP")]
			DESKTOP,

		}

		/// <summary>
		/// <para>Reference all data for Runtime</para>
		/// </summary>
		public enum ReferenceAllDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REFERENCED")]
			REFERENCED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_REFERENCED")]
			NOT_REFERENCED,

		}

		/// <summary>
		/// <para>Package version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>所有版本—包中将包含与所有版本（ArcGIS Pro 1.2 和更高版本）均兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有版本")]
			All_versions,

			/// <summary>
			/// <para>当前版本— 包中包含与当前版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("当前版本")]
			Current_version,

			/// <summary>
			/// <para>1.2—包中将包含与 1.2 和更高版本均兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>2.x—包中将包含与 2.0 和更高版本均兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.x")]
			[Description("2.x")]
			_2x,

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
