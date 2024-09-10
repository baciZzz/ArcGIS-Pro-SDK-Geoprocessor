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
	/// <para>Analyze Mosaic Dataset</para>
	/// <para>Performs checks on a mosaic dataset for errors and possible improvements.</para>
	/// </summary>
	public class AnalyzeMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset you want to analyze.</para>
		/// </param>
		public AnalyzeMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName() => "Analyze Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : AnalyzeMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "AnalyzeMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeMosaicDataset";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, CheckerKeywords, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset you want to analyze.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL statement that confines your analysis to specific raster datasets within this mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Checks Performed</para>
		/// <para>Choose which parts of the mosaic dataset you want to analyze for known issues.</para>
		/// <para>Footprint geometry— Analyze the footprint geometry of each selected mosaic dataset item. This is checked on by default.</para>
		/// <para>Function chains— Analyze the function chains for each selected mosaic dataset item.</para>
		/// <para>Raster— Analyze the original raster datasets. This is checked on by default.</para>
		/// <para>Broken paths— Check for broken paths. This is checked on by default.</para>
		/// <para>Source validity— Analyze potential problems with the source data associated with each mosaic dataset item in the selected mosaic dataset. This is a good way to detect issues that may arise during synchronization workflows.</para>
		/// <para>Stale overviews— Overviews are stale when the underlying source data has changed. Once the mosaic dataset is analyzed, you can select which items are stale by right-clicking on the error and clicking Select Associated Items on the context menu.</para>
		/// <para>Pyramids— Analyze the raster pyramids associated with each mosaic dataset item in the selected mosaic dataset. Test for disconnected auxiliary files, which can occur when they are stored in a raster proxy location.</para>
		/// <para>Statistics— Test for disconnected auxiliary statistics files if they are stored in the raster proxy location. Analyze the covariance matrix associated with the raster, when the Gram-Schmidt pan-sharpening method is enabled. Analyze the radiometric pixel depth of a mosaic dataset item against the pixel depth of the mosaic dataset.</para>
		/// <para>Performance— Factors that increase performance include compression during transmission and caching items with many raster functions.</para>
		/// <para>Information— Generate general information about the mosaic dataset.</para>
		/// <para><see cref="CheckerKeywordsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object CheckerKeywords { get; set; }

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeMosaicDataset SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Checks Performed</para>
		/// </summary>
		public enum CheckerKeywordsEnum 
		{
			/// <summary>
			/// <para>Footprint geometry— Analyze the footprint geometry of each selected mosaic dataset item. This is checked on by default.</para>
			/// </summary>
			[GPValue("FOOTPRINT")]
			[Description("Footprint geometry")]
			Footprint_geometry,

			/// <summary>
			/// <para>Function chains— Analyze the function chains for each selected mosaic dataset item.</para>
			/// </summary>
			[GPValue("FUNCTION")]
			[Description("Function chains")]
			Function_chains,

			/// <summary>
			/// <para>Raster— Analyze the original raster datasets. This is checked on by default.</para>
			/// </summary>
			[GPValue("RASTER")]
			[Description("Raster")]
			Raster,

			/// <summary>
			/// <para>Broken paths— Check for broken paths. This is checked on by default.</para>
			/// </summary>
			[GPValue("PATHS")]
			[Description("Broken paths")]
			Broken_paths,

			/// <summary>
			/// <para>Source validity— Analyze potential problems with the source data associated with each mosaic dataset item in the selected mosaic dataset. This is a good way to detect issues that may arise during synchronization workflows.</para>
			/// </summary>
			[GPValue("SOURCE_VALIDITY")]
			[Description("Source validity")]
			Source_validity,

			/// <summary>
			/// <para>Stale overviews— Overviews are stale when the underlying source data has changed. Once the mosaic dataset is analyzed, you can select which items are stale by right-clicking on the error and clicking Select Associated Items on the context menu.</para>
			/// </summary>
			[GPValue("STALE")]
			[Description("Stale overviews")]
			Stale_overviews,

			/// <summary>
			/// <para>Pyramids— Analyze the raster pyramids associated with each mosaic dataset item in the selected mosaic dataset. Test for disconnected auxiliary files, which can occur when they are stored in a raster proxy location.</para>
			/// </summary>
			[GPValue("PYRAMIDS")]
			[Description("Pyramids")]
			Pyramids,

			/// <summary>
			/// <para>Statistics— Test for disconnected auxiliary statistics files if they are stored in the raster proxy location. Analyze the covariance matrix associated with the raster, when the Gram-Schmidt pan-sharpening method is enabled. Analyze the radiometric pixel depth of a mosaic dataset item against the pixel depth of the mosaic dataset.</para>
			/// </summary>
			[GPValue("STATISTICS")]
			[Description("Statistics")]
			Statistics,

			/// <summary>
			/// <para>Performance— Factors that increase performance include compression during transmission and caching items with many raster functions.</para>
			/// </summary>
			[GPValue("PERFORMANCE")]
			[Description("Performance")]
			Performance,

			/// <summary>
			/// <para>Information— Generate general information about the mosaic dataset.</para>
			/// </summary>
			[GPValue("INFORMATION")]
			[Description("Information")]
			Information,

		}

#endregion
	}
}
