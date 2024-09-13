using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Describe Space Time Cube</para>
	/// <para>Describe Space Time Cube</para>
	/// <para>Summarizes the contents and characteristics of a space-time cube. The tool describes the temporal and spatial extent of the space-time cube, the variables in the space-time cube, the analyses performed on each variable, and the 2D and 3D display themes available for each variable.</para>
	/// </summary>
	public class DescribeSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The space-time cube to be described. Space-time cubes have an .nc file extension and are created using various tools in the Space Time Pattern Mining toolbox.</para>
		/// </param>
		public DescribeSpaceTimeCube(object InCube)
		{
			this.InCube = InCube;
		}

		/// <summary>
		/// <para>Tool Display Name : Describe Space Time Cube</para>
		/// </summary>
		public override string DisplayName() => "Describe Space Time Cube";

		/// <summary>
		/// <para>Tool Name : DescribeSpaceTimeCube</para>
		/// </summary>
		public override string ToolName() => "DescribeSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : stpm.DescribeSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName() => "stpm.DescribeSpaceTimeCube";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, OutCharacteristicsTable!, OutSpatialExtent! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The space-time cube to be described. Space-time cubes have an .nc file extension and are created using various tools in the Space Time Pattern Mining toolbox.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Output Characteristics Table</para>
		/// <para>The table containing summary information about the input space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutCharacteristicsTable { get; set; }

		/// <summary>
		/// <para>Output Spatial Extent Features</para>
		/// <para>A feature class with a single rectangle that represents the spatial extent of the input space-time cube.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutSpatialExtent { get; set; }

	}
}
