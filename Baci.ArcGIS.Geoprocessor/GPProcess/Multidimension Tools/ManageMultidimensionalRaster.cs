using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Manage Multidimensional Raster</para>
	/// <para>Edits a multidimensional raster by adding or deleting variables or dimensions.</para>
	/// </summary>
	public class ManageMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetMultidimensionalRaster">
		/// <para>Target Multidimensional Raster</para>
		/// <para>The multidimensional raster in Cloud Raster Format (.crf) to modify.</para>
		/// </param>
		public ManageMultidimensionalRaster(object TargetMultidimensionalRaster)
		{
			this.TargetMultidimensionalRaster = TargetMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Multidimensional Raster</para>
		/// </summary>
		public override string DisplayName() => "Manage Multidimensional Raster";

		/// <summary>
		/// <para>Tool Name : ManageMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "ManageMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : md.ManageMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "md.ManageMultidimensionalRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetMultidimensionalRaster, ManageMode, Variables, InMultidimensionalRasters, DimensionName, DimensionValue, DimensionDescription, DimensionUnit, UpdateStatistics, UpdateTranspose, UpdatedTargetMultidimensionalRaster };

		/// <summary>
		/// <para>Target Multidimensional Raster</para>
		/// <para>The multidimensional raster in Cloud Raster Format (.crf) to modify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object TargetMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Manage Mode</para>
		/// <para>Specifies the type of modification that will be performed on the target raster.</para>
		/// <para>Add Dimension—A dimension will be added to the input multidimensional raster.</para>
		/// <para>Append Slices—Slices from the input multidimensional rasters will be added to the end of the slices for a dimension. This is the default.</para>
		/// <para>Append Variables—The variables from the input multidimensional rasters will be added.</para>
		/// <para>Replace Slices—Existing slices will be replaced by slices from another multidimensional raster, at specific dimension values.</para>
		/// <para>Delete Variables—One or more variables will be deleted from the multidimensional raster.</para>
		/// <para>Remove Dimension—A single slice multidimensional raster will be converted to a dimensionless raster.</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ManageMode { get; set; } = "APPEND_SLICES";

		/// <summary>
		/// <para>Variables</para>
		/// <para>The variable or variables that will be modified in the target multidimensional raster. This parameter is required if the operation being performed is a modification of an existing variable.</para>
		/// <para>If no variable is specified, the first variable in the target multidimensional raster will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Input Multidimensional Rasters</para>
		/// <para>The multidimensional raster datasets that contain the slices or variables to be added to the target multidimensional raster. This parameter is required when Manage Mode is set to Append Slices, Replace Slices, or Append Variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InMultidimensionalRasters { get; set; }

		/// <summary>
		/// <para>Dimension Name</para>
		/// <para>The name of the new dimension to be added to the raster properties. This parameter is required if Manage Mode is set to Add Dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionName { get; set; }

		/// <summary>
		/// <para>Dimension Value</para>
		/// <para>The value of the dimension to be added. The value can be a single value or a range of values. For a range of values, provide the minimum and maximum values separated by a comma. For example, for a new height dimension, enter 0,10 to generate a dimension in which the first slice contains information for the first 10 meters of height.</para>
		/// <para>This parameter is required if Manage Mode is set to Add Dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionValue { get; set; }

		/// <summary>
		/// <para>Dimension Description</para>
		/// <para>The description of the new dimension to be added to the raster properties for metadata purposes. This parameter is active if Manage Mode is set to Add Dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionDescription { get; set; }

		/// <summary>
		/// <para>Dimension Unit</para>
		/// <para>The unit of the new dimension to be added to the raster properties for metadata purposes. This parameter is active if Manage Mode is set to Add Dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DimensionUnit { get; set; }

		/// <summary>
		/// <para>Update Statistics</para>
		/// <para>Specifies whether the statistics will be recalculated for the multidimensional raster dataset.</para>
		/// <para>Checked—Statistics will be recalculated. This is the default.</para>
		/// <para>Unchecked—Statistics will not be recalculated.</para>
		/// <para><see cref="UpdateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateStatistics { get; set; } = "true";

		/// <summary>
		/// <para>Update Transpose</para>
		/// <para>Specifies whether the transpose will be rebuilt for the multidimensional raster dataset.</para>
		/// <para>Checked—The transpose will be rebuilt. If no transpose exists, a new transpose will be built. This is the default.</para>
		/// <para>Unchecked—The transpose will not be rebuilt.</para>
		/// <para><see cref="UpdateTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateTranspose { get; set; } = "true";

		/// <summary>
		/// <para>Target Multidimensional Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object UpdatedTargetMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageMultidimensionalRaster SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Manage Mode</para>
		/// </summary>
		public enum ManageModeEnum 
		{
			/// <summary>
			/// <para>Append Slices—Slices from the input multidimensional rasters will be added to the end of the slices for a dimension. This is the default.</para>
			/// </summary>
			[GPValue("APPEND_SLICES")]
			[Description("Append Slices")]
			Append_Slices,

			/// <summary>
			/// <para>Replace Slices—Existing slices will be replaced by slices from another multidimensional raster, at specific dimension values.</para>
			/// </summary>
			[GPValue("REPLACE_SLICES")]
			[Description("Replace Slices")]
			Replace_Slices,

			/// <summary>
			/// <para>Append Variables—The variables from the input multidimensional rasters will be added.</para>
			/// </summary>
			[GPValue("APPEND_VARIABLES")]
			[Description("Append Variables")]
			Append_Variables,

			/// <summary>
			/// <para>Delete Variables—One or more variables will be deleted from the multidimensional raster.</para>
			/// </summary>
			[GPValue("DELETE_VARIABLES")]
			[Description("Delete Variables")]
			Delete_Variables,

			/// <summary>
			/// <para>Add Dimension—A dimension will be added to the input multidimensional raster.</para>
			/// </summary>
			[GPValue("ADD_DIMENSION")]
			[Description("Add Dimension")]
			Add_Dimension,

			/// <summary>
			/// <para>Remove Dimension—A single slice multidimensional raster will be converted to a dimensionless raster.</para>
			/// </summary>
			[GPValue("REMOVE_DIMENSION")]
			[Description("Remove Dimension")]
			Remove_Dimension,

		}

		/// <summary>
		/// <para>Update Statistics</para>
		/// </summary>
		public enum UpdateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be recalculated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_STATISTICS")]
			UPDATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—Statistics will not be recalculated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_STATISTICS")]
			NO_UPDATE_STATISTICS,

		}

		/// <summary>
		/// <para>Update Transpose</para>
		/// </summary>
		public enum UpdateTransposeEnum 
		{
			/// <summary>
			/// <para>Checked—The transpose will be rebuilt. If no transpose exists, a new transpose will be built. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_TRANSPOSE")]
			UPDATE_TRANSPOSE,

			/// <summary>
			/// <para>Unchecked—The transpose will not be rebuilt.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_TRANSPOSE")]
			NO_UPDATE_TRANSPOSE,

		}

#endregion
	}
}
