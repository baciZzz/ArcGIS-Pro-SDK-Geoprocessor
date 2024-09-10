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
	/// <para>Repair Mosaic Dataset Paths</para>
	/// <para>Resets paths to source imagery if you have moved or copied a mosaic dataset.</para>
	/// </summary>
	public class RepairMosaicDatasetPaths : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset with the broken paths.</para>
		/// </param>
		/// <param name="PathsList">
		/// <para>Paths List</para>
		/// <para>A list of the paths to remap. Include the current path stored in the mosaic dataset and the path to which it will be changed. You can enter an asterisk (*) as the original path if you wish to change all your paths.</para>
		/// </param>
		public RepairMosaicDatasetPaths(object InMosaicDataset, object PathsList)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.PathsList = PathsList;
		}

		/// <summary>
		/// <para>Tool Display Name : Repair Mosaic Dataset Paths</para>
		/// </summary>
		public override string DisplayName() => "Repair Mosaic Dataset Paths";

		/// <summary>
		/// <para>Tool Name : RepairMosaicDatasetPaths</para>
		/// </summary>
		public override string ToolName() => "RepairMosaicDatasetPaths";

		/// <summary>
		/// <para>Tool Excute Name : management.RepairMosaicDatasetPaths</para>
		/// </summary>
		public override string ExcuteName() => "management.RepairMosaicDatasetPaths";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, PathsList, WhereClause, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset with the broken paths.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Paths List</para>
		/// <para>A list of the paths to remap. Include the current path stored in the mosaic dataset and the path to which it will be changed. You can enter an asterisk (*) as the original path if you wish to change all your paths.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object PathsList { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to limit the repairs to selected rasters within the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Repaired Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RepairMosaicDatasetPaths SetEnviroment(object extent = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
