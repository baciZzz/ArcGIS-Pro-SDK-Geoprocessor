using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Unzip MGCP Cell And Import</para>
	/// <para>Unzips and imports compressed Multinational Geospatial Co-production Program (MGCP) 1-degree-by-1-degree cell packages (*.zip) into a target geodatabase.</para>
	/// </summary>
	public class UnzipCellAndImport : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="RootFolder">
		/// <para>Root Folder</para>
		/// <para>The root folder that contains one or more compressed shapefile cell packages in a .zip file.</para>
		/// </param>
		/// <param name="TargetGeodatabase">
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase where the unzipped shapefiles will be imported.</para>
		/// </param>
		public UnzipCellAndImport(object RootFolder, object TargetGeodatabase)
		{
			this.RootFolder = RootFolder;
			this.TargetGeodatabase = TargetGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Unzip MGCP Cell And Import</para>
		/// </summary>
		public override string DisplayName => "Unzip MGCP Cell And Import";

		/// <summary>
		/// <para>Tool Name : UnzipCellAndImport</para>
		/// </summary>
		public override string ToolName => "UnzipCellAndImport";

		/// <summary>
		/// <para>Tool Excute Name : topographic.UnzipCellAndImport</para>
		/// </summary>
		public override string ExcuteName => "topographic.UnzipCellAndImport";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { RootFolder, TargetGeodatabase, OutputGeodatabase! };

		/// <summary>
		/// <para>Root Folder</para>
		/// <para>The root folder that contains one or more compressed shapefile cell packages in a .zip file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object RootFolder { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase where the unzipped shapefiles will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UnzipCellAndImport SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
