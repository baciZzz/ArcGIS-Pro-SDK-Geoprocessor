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
	/// <para>Build Overviews</para>
	/// <para>构建概视图</para>
	/// <para>定义并生成镶嵌数据集的概视图。</para>
	/// </summary>
	public class BuildOverviews : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>用来构建概视图的镶嵌数据集。</para>
		/// </param>
		public BuildOverviews(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建概视图</para>
		/// </summary>
		public override string DisplayName() => "构建概视图";

		/// <summary>
		/// <para>Tool Name : BuildOverviews</para>
		/// </summary>
		public override string ToolName() => "BuildOverviews";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildOverviews</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildOverviews";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, DefineMissingTiles, GenerateOverviews, GenerateMissingImages, RegenerateStaleImages, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>用来构建概视图的镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>用来在镶嵌数据集中选择特定栅格的 SQL 语句。选定栅格将构建其自己的概视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Define Missing Overview Tiles</para>
		/// <para>识别需要概视图的位置并定义概视图。</para>
		/// <para>选中 - 自动识别需要概视图的位置并定义概视图。这是默认设置。</para>
		/// <para>未选中 - 不定义新的概视图。</para>
		/// <para><see cref="DefineMissingTilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DefineMissingTiles { get; set; } = "true";

		/// <summary>
		/// <para>Generate Overviews</para>
		/// <para>生成所有需要创建或重新创建的概视图。这包括缺失的概视图和过时的概视图。</para>
		/// <para>选中 - 生成所有概视图，包括已经存在的概视图。这是默认设置。</para>
		/// <para>未选中 - 只生成已经定义但尚未生成的概视图。</para>
		/// <para><see cref="GenerateOverviewsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateOverviews { get; set; } = "true";

		/// <summary>
		/// <para>Generate Missing Overview Images Only</para>
		/// <para>在已经定义但尚未生成概视图时使用。</para>
		/// <para>选中 - 生成已经定义但尚未生成的概视图。这是默认设置。</para>
		/// <para>取消选中 - 不生成已经定义但尚未生成的金字塔。</para>
		/// <para><see cref="GenerateMissingImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Overview Generation Options")]
		public object GenerateMissingImages { get; set; } = "true";

		/// <summary>
		/// <para>Regenerate Stale Overview Images Only</para>
		/// <para>更改基础栅格数据集或修改其属性时，会导致概视图过时。</para>
		/// <para>选中 - 识别并重新生成过时概视图。这是默认设置。</para>
		/// <para>未选中 - 不重新生成过时概视图。</para>
		/// <para><see cref="RegenerateStaleImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Overview Generation Options")]
		public object RegenerateStaleImages { get; set; } = "true";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildOverviews SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Define Missing Overview Tiles</para>
		/// </summary>
		public enum DefineMissingTilesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_MISSING_TILES")]
			DEFINE_MISSING_TILES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DEFINE_MISSING_TILES")]
			NO_DEFINE_MISSING_TILES,

		}

		/// <summary>
		/// <para>Generate Overviews</para>
		/// </summary>
		public enum GenerateOverviewsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_OVERVIEWS")]
			GENERATE_OVERVIEWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_OVERVIEWS")]
			NO_GENERATE_OVERVIEWS,

		}

		/// <summary>
		/// <para>Generate Missing Overview Images Only</para>
		/// </summary>
		public enum GenerateMissingImagesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_MISSING_IMAGES")]
			GENERATE_MISSING_IMAGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_MISSING_IMAGES")]
			IGNORE_MISSING_IMAGES,

		}

		/// <summary>
		/// <para>Regenerate Stale Overview Images Only</para>
		/// </summary>
		public enum RegenerateStaleImagesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REGENERATE_STALE_IMAGES")]
			REGENERATE_STALE_IMAGES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_STALE_IMAGES")]
			IGNORE_STALE_IMAGES,

		}

#endregion
	}
}
