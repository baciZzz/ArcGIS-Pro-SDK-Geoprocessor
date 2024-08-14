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
	/// <para>Extracts cell values from a set of rasters to a table, based on a point or polygon feature class.</para>
	/// </summary>
	public class ExtractValuesToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The points or polygon features to be created.</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>The rasters must all have the same extent, coordinate system, and cell size.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>The output table contains a record for each point and each raster that has data. If polygon features are input, they are converted to points that coincide with the raster cell centers.</para>
		/// </param>
		public ExtractValuesToTable(object InFeatures, object InRasters, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.InRasters = InRasters;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Values To Table</para>
		/// </summary>
		public override string DisplayName => "Extract Values To Table";

		/// <summary>
		/// <para>Tool Name : ExtractValuesToTable</para>
		/// </summary>
		public override string ToolName => "ExtractValuesToTable";

		/// <summary>
		/// <para>Tool Excute Name : ga.ExtractValuesToTable</para>
		/// </summary>
		public override string ExcuteName => "ga.ExtractValuesToTable";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, InRasters, OutTable, OutRasterNamesTable!, AddWarningField! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The points or polygon features to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>The rasters must all have the same extent, coordinate system, and cell size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>The output table contains a record for each point and each raster that has data. If polygon features are input, they are converted to points that coincide with the raster cell centers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output raster names table</para>
		/// <para>Saves the names of the Input rasters to disc.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutRasterNamesTable { get; set; }

		/// <summary>
		/// <para>Add warnings to output table</para>
		/// <para>Records if input features are partially or completely covered by the Input rasters.</para>
		/// <para>Checked—Warning field is added to the output table and populated with a P when a feature is partially covered by raster values.</para>
		/// <para>Unchecked—Warning field is not added to the output table.</para>
		/// <para><see cref="AddWarningFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddWarningField { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractValuesToTable SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
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
			/// <para>Checked—Warning field is added to the output table and populated with a P when a feature is partially covered by raster values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_WARNING_FIELD")]
			ADD_WARNING_FIELD,

			/// <summary>
			/// <para>Unchecked—Warning field is not added to the output table.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_ADD_WARNING_FIELD")]
			DO_NOT_ADD_WARNING_FIELD,

		}

#endregion
	}
}
