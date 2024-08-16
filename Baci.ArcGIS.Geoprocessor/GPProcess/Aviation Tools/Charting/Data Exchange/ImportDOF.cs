using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Import Digital Obstacle File</para>
	/// <para>Adds, deletes, and updates the obstacle point features in an input obstacle feature class using an input digital obstacle file (DOF).</para>
	/// </summary>
	public class ImportDOF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObstacleFile">
		/// <para>Input Digital Obstacle File</para>
		/// <para>A DOF with a .DAT file extension. The contents of the DOF will be used to update the Target Obstacle Features parameter values.</para>
		/// </param>
		/// <param name="ObstacleFeatures">
		/// <para>Target Obstacle Features</para>
		/// <para>The point feature class that will contain obstacle information from the DOF after execution.</para>
		/// </param>
		public ImportDOF(object InObstacleFile, object ObstacleFeatures)
		{
			this.InObstacleFile = InObstacleFile;
			this.ObstacleFeatures = ObstacleFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Digital Obstacle File</para>
		/// </summary>
		public override string DisplayName => "Import Digital Obstacle File";

		/// <summary>
		/// <para>Tool Name : ImportDOF</para>
		/// </summary>
		public override string ToolName => "ImportDOF";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ImportDOF</para>
		/// </summary>
		public override string ExcuteName => "aviation.ImportDOF";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObstacleFile, ObstacleFeatures, UpdatedObstacleFeatures };

		/// <summary>
		/// <para>Input Digital Obstacle File</para>
		/// <para>A DOF with a .DAT file extension. The contents of the DOF will be used to update the Target Obstacle Features parameter values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("DAT")]
		public object InObstacleFile { get; set; }

		/// <summary>
		/// <para>Target Obstacle Features</para>
		/// <para>The point feature class that will contain obstacle information from the DOF after execution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object ObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Updated Obstacle Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object UpdatedObstacleFeatures { get; set; }

	}
}
