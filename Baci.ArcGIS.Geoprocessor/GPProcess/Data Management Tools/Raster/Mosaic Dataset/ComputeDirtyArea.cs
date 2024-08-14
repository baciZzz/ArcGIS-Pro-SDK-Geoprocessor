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
	/// <para>Compute Dirty Area</para>
	/// <para>Identifies areas within a mosaic dataset that have changed since a specified point in time. This is used commonly when a mosaic dataset is updated or synchronized, or when  derived products, such as cache, need to be updated. This tool will enable you to limit such processes to only the areas that have changed.</para>
	/// </summary>
	public class ComputeDirtyArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to analyze for changes.</para>
		/// </param>
		/// <param name="Timestamp">
		/// <para>Start Date and Time</para>
		/// <para>Compute the areas that have changed since the input time.</para>
		/// <para>XML time syntax:</para>
		/// <para>YYYY-MM-DDThh:mm:ss</para>
		/// <para>YYYY-MM-DDThh:mm:ss.ssssZ</para>
		/// <para>2002-10-10T12:00:00.ssss-00:00</para>
		/// <para>2002-10-10T12:00:00+00:00</para>
		/// <para>Non-XML time syntax:</para>
		/// <para>2002/12/25 23:59:58.123</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the areas that have changed.</para>
		/// </param>
		public ComputeDirtyArea(object InMosaicDataset, object Timestamp, object OutFeatureClass)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.Timestamp = Timestamp;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Dirty Area</para>
		/// </summary>
		public override string DisplayName => "Compute Dirty Area";

		/// <summary>
		/// <para>Tool Name : ComputeDirtyArea</para>
		/// </summary>
		public override string ToolName => "ComputeDirtyArea";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeDirtyArea</para>
		/// </summary>
		public override string ExcuteName => "management.ComputeDirtyArea";

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
		public override string[] ValidEnvironments => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, WhereClause!, Timestamp, OutFeatureClass };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to analyze for changes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>SQL expression to select specific rasters within the mosaic dataset on which to compute dirty areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Start Date and Time</para>
		/// <para>Compute the areas that have changed since the input time.</para>
		/// <para>XML time syntax:</para>
		/// <para>YYYY-MM-DDThh:mm:ss</para>
		/// <para>YYYY-MM-DDThh:mm:ss.ssssZ</para>
		/// <para>2002-10-10T12:00:00.ssss-00:00</para>
		/// <para>2002-10-10T12:00:00+00:00</para>
		/// <para>Non-XML time syntax:</para>
		/// <para>2002/12/25 23:59:58.123</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Timestamp { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing the areas that have changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeDirtyArea SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
