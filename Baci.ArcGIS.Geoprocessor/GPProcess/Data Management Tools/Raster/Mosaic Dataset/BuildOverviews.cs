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
	/// <para>Defines and generates overviews on a mosaic dataset.</para>
	/// </summary>
	public class BuildOverviews : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset where you want to build overviews.</para>
		/// </param>
		public BuildOverviews(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Overviews</para>
		/// </summary>
		public override string DisplayName => "Build Overviews";

		/// <summary>
		/// <para>Tool Name : BuildOverviews</para>
		/// </summary>
		public override string ToolName => "BuildOverviews";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildOverviews</para>
		/// </summary>
		public override string ExcuteName => "management.BuildOverviews";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, WhereClause, DefineMissingTiles, GenerateOverviews, GenerateMissingImages, RegenerateStaleImages, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset where you want to build overviews.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL statement to select specific rasters within the mosaic dataset. The selected rasters will have their overview built.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Define Missing Overview Tiles</para>
		/// <para>Identify where overviews are needed and define them.</para>
		/// <para>Checked—Automatically identify where overviews are needed and define them. This is the default.</para>
		/// <para>Unchecked—Do not define new overviews.</para>
		/// <para><see cref="DefineMissingTilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DefineMissingTiles { get; set; } = "true";

		/// <summary>
		/// <para>Generate Overviews</para>
		/// <para>Generate all overviews that need to be created or re-created. This includes missing overviews and stale overviews.</para>
		/// <para>Checked—Generate all overviews, including those that already exist. This is the default.</para>
		/// <para>Unchecked—Generate only the overviews that have been defined but not yet generated.</para>
		/// <para><see cref="GenerateOverviewsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateOverviews { get; set; } = "true";

		/// <summary>
		/// <para>Generate Missing Overview Images Only</para>
		/// <para>Use if overviews have been defined but not generated.</para>
		/// <para>Checked—Overviews that have been defined but not generated will be generated. This is the default.</para>
		/// <para>Unchecked—Overviews that have been defined but not generated will not be generated.</para>
		/// <para><see cref="GenerateMissingImagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Overview Generation Options")]
		public object GenerateMissingImages { get; set; } = "true";

		/// <summary>
		/// <para>Regenerate Stale Overview Images Only</para>
		/// <para>Overviews become stale when you change the underlying raster datasets or modify their properties.</para>
		/// <para>Checked—Identify and regenerate stale overviews. This is the default.</para>
		/// <para>Unchecked—Do not regenerate stale overviews.</para>
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
			/// <para>Checked—Automatically identify where overviews are needed and define them. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_MISSING_TILES")]
			DEFINE_MISSING_TILES,

			/// <summary>
			/// <para>Unchecked—Do not define new overviews.</para>
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
			/// <para>Checked—Generate all overviews, including those that already exist. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_OVERVIEWS")]
			GENERATE_OVERVIEWS,

			/// <summary>
			/// <para>Unchecked—Generate only the overviews that have been defined but not yet generated.</para>
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
			/// <para>Checked—Overviews that have been defined but not generated will be generated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_MISSING_IMAGES")]
			GENERATE_MISSING_IMAGES,

			/// <summary>
			/// <para>Unchecked—Overviews that have been defined but not generated will not be generated.</para>
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
			/// <para>Checked—Identify and regenerate stale overviews. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REGENERATE_STALE_IMAGES")]
			REGENERATE_STALE_IMAGES,

			/// <summary>
			/// <para>Unchecked—Do not regenerate stale overviews.</para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_STALE_IMAGES")]
			IGNORE_STALE_IMAGES,

		}

#endregion
	}
}
