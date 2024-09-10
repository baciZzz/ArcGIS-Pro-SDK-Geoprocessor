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
	/// <para>Raster Compare</para>
	/// <para>Compares the properties of two raster or mosaic datasets.</para>
	/// </summary>
	public class RasterCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseRaster">
		/// <para>Input Base Raster</para>
		/// <para>The first raster or mosaic dataset to compare.</para>
		/// </param>
		/// <param name="InTestRaster">
		/// <para>Input Test Raster</para>
		/// <para>The second raster or mosaic dataset to compare with the first.</para>
		/// </param>
		public RasterCompare(object InBaseRaster, object InTestRaster)
		{
			this.InBaseRaster = InBaseRaster;
			this.InTestRaster = InTestRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster Compare</para>
		/// </summary>
		public override string DisplayName() => "Raster Compare";

		/// <summary>
		/// <para>Tool Name : RasterCompare</para>
		/// </summary>
		public override string ToolName() => "RasterCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.RasterCompare</para>
		/// </summary>
		public override string ExcuteName() => "management.RasterCompare";

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
		public override object[] Parameters() => new object[] { InBaseRaster, InTestRaster, CompareType, IgnoreOption, ContinueCompare, OutCompareFile, ParameterTolerances, AttributeTolerances, OmitField, CompareStatus };

		/// <summary>
		/// <para>Input Base Raster</para>
		/// <para>The first raster or mosaic dataset to compare.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InBaseRaster { get; set; }

		/// <summary>
		/// <para>Input Test Raster</para>
		/// <para>The second raster or mosaic dataset to compare with the first.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTestRaster { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>Specifies the type of rasters that will be compared.</para>
		/// <para>Raster dataset—Two raster datasets will be compared.</para>
		/// <para>Geodatabase raster dataset—Two raster datasets in a geodatabase will be compared.</para>
		/// <para>Mosaic dataset—Two mosaic datasets will be compared.</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompareType { get; set; } = "RASTER_DATASET";

		/// <summary>
		/// <para>Ignore Options</para>
		/// <para>Specifies the properties that will be ignored in the comparison.</para>
		/// <para>Band count—The number of bands will be ignored.</para>
		/// <para>Extent—The extent will be ignored.</para>
		/// <para>Columns and rows—The number of columns and rows will be ignored.</para>
		/// <para>Pixel type—The pixel type will be ignored.</para>
		/// <para>NoData—The NoData value will be ignored.</para>
		/// <para>Spatial reference—The spatial reference system will be ignored.</para>
		/// <para>Pixel value—The pixel values will be ignored.</para>
		/// <para>Colormap—Existing color maps will be ignored.</para>
		/// <para>Raster attribute table—Existing attribute tables will be ignored.</para>
		/// <para>Statistics—Statistics will be ignored.</para>
		/// <para>Metadata—Metadata will be ignored.</para>
		/// <para>Pyramids exist—Existing pyramids will be ignored.</para>
		/// <para>Compression type—The compression type will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object IgnoreOption { get; set; }

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>Specifies whether the comparison will stop if a mismatch is encountered.</para>
		/// <para>Unchecked—The comparison will stop if a mismatch is encountered. This is the default.</para>
		/// <para>Checked—The comparison will continue if a mismatch is encountered.</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>A text file containing the comparison results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutCompareFile { get; set; }

		/// <summary>
		/// <para>Parameter Tolerance</para>
		/// <para>The tolerances that determine the range in which values are considered equal. The same tolerance can be applied to all parameters, or different tolerances can be applied to individual parameters.</para>
		/// <para>The tolerance type can be set as either a value or a fraction. For example, if the base value is 100 and a fraction tolerance is set to 0.00001, the compare tolerance will be within 100 * 0.001 (100 * 0.00001).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ParameterTolerances { get; set; }

		/// <summary>
		/// <para>Attribute Tolerance</para>
		/// <para>The fields that will be compared to determine if they are within a tolerance. The tolerance value is a value in the units of the attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AttributeTolerances { get; set; }

		/// <summary>
		/// <para>Omit Fields</para>
		/// <para>The field or fields that will be omitted during comparison.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object OmitField { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareStatus { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterCompare SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>Raster dataset—Two raster datasets will be compared.</para>
			/// </summary>
			[GPValue("RASTER_DATASET")]
			[Description("Raster dataset")]
			Raster_dataset,

			/// <summary>
			/// <para>Geodatabase raster dataset—Two raster datasets in a geodatabase will be compared.</para>
			/// </summary>
			[GPValue("GDB_RASTER_DATASET")]
			[Description("Geodatabase raster dataset")]
			Geodatabase_raster_dataset,

			/// <summary>
			/// <para>Mosaic dataset—Two mosaic datasets will be compared.</para>
			/// </summary>
			[GPValue("MOSAIC_DATASET")]
			[Description("Mosaic dataset")]
			Mosaic_dataset,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para>Checked—The comparison will continue if a mismatch is encountered.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para>Unchecked—The comparison will stop if a mismatch is encountered. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
