using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>DOF To Obstacle Features</para>
	/// <para>Converts the U.S. Federal Aviation Administration (FAA) Digital Obstacle File (DOF) to obstruction points and obstruction buffer features.</para>
	/// </summary>
	public class DOFToObstacleFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input DOF table to convert into obstacle features.</para>
		/// </param>
		/// <param name="OutObstacleFeatures">
		/// <para>Output Obstacle Features</para>
		/// <para>The point obstacle features created from the Input Table.</para>
		/// </param>
		/// <param name="OutObstacleBuffers">
		/// <para>Output Obstacle Buffers</para>
		/// <para>The distance buffers created at 10 times the value of the AGL field in the Input Table.</para>
		/// </param>
		public DOFToObstacleFeatures(object InTable, object OutObstacleFeatures, object OutObstacleBuffers)
		{
			this.InTable = InTable;
			this.OutObstacleFeatures = OutObstacleFeatures;
			this.OutObstacleBuffers = OutObstacleBuffers;
		}

		/// <summary>
		/// <para>Tool Display Name : DOF To Obstacle Features</para>
		/// </summary>
		public override string DisplayName => "DOF To Obstacle Features";

		/// <summary>
		/// <para>Tool Name : DOFToObstacleFeatures</para>
		/// </summary>
		public override string ToolName => "DOFToObstacleFeatures";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.DOFToObstacleFeatures</para>
		/// </summary>
		public override string ExcuteName => "intelligence.DOFToObstacleFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutObstacleFeatures, OutObstacleBuffers, ClipFeatures };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input DOF table to convert into obstacle features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Obstacle Features</para>
		/// <para>The point obstacle features created from the Input Table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Output Obstacle Buffers</para>
		/// <para>The distance buffers created at 10 times the value of the AGL field in the Input Table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutObstacleBuffers { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>An area to clip from the Input Table. Only obstacles within this area will be created and buffered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object ClipFeatures { get; set; }

	}
}
