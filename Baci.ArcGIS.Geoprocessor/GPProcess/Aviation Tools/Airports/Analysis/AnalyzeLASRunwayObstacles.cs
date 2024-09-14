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
	/// <para>Analyze LAS Runway Obstacles</para>
	/// <para>Analyze LAS Runway Obstacles</para>
	/// <para>Analyzes lidar data and obstruction identification surfaces (OIS) to determine if lidar points are penetrating.</para>
	/// </summary>
	public class AnalyzeLASRunwayObstacles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InOisFeatures">
		/// <para>Input OIS Features</para>
		/// <para>The input multipatch features representing one or more OIS. The feature class must be z-enabled.</para>
		/// </param>
		/// <param name="InLasObstacles">
		/// <para>Input LAS Obstacles</para>
		/// <para>The input LAS dataset that contains 3D data points covering the area around an airport. The points represent a 3D view of natural and human-made objects that may pose a hazard to flight.</para>
		/// </param>
		public AnalyzeLASRunwayObstacles(object InOisFeatures, object InLasObstacles)
		{
			this.InOisFeatures = InOisFeatures;
			this.InLasObstacles = InLasObstacles;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze LAS Runway Obstacles</para>
		/// </summary>
		public override string DisplayName() => "Analyze LAS Runway Obstacles";

		/// <summary>
		/// <para>Tool Name : AnalyzeLASRunwayObstacles</para>
		/// </summary>
		public override string ToolName() => "AnalyzeLASRunwayObstacles";

		/// <summary>
		/// <para>Tool Excute Name : aviation.AnalyzeLASRunwayObstacles</para>
		/// </summary>
		public override string ExcuteName() => "aviation.AnalyzeLASRunwayObstacles";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InOisFeatures, InLasObstacles, OutObstacleFeatureClass!, TargetFolder!, OutLasObstacles!, VerticalClearance!, VerticalClearanceUnit! };

		/// <summary>
		/// <para>Input OIS Features</para>
		/// <para>The input multipatch features representing one or more OIS. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InOisFeatures { get; set; }

		/// <summary>
		/// <para>Input LAS Obstacles</para>
		/// <para>The input LAS dataset that contains 3D data points covering the area around an airport. The points represent a 3D view of natural and human-made objects that may pose a hazard to flight.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasObstacles { get; set; }

		/// <summary>
		/// <para>Output Obstacle Feature Class</para>
		/// <para>The output point features that represent lidar points in OIS features in which the height of the lidar point is greater than the height of the enclosing OIS feature at that point. This feature class is required output only if no output LAS dataset is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? OutObstacleFeatureClass { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The folder to which .las files will be written. Each output file will have the same .las file version and point record format as the input file. This folder is required output only if no output feature class is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? TargetFolder { get; set; }

		/// <summary>
		/// <para>Output LAS Obstacles</para>
		/// <para>The output LAS dataset referencing the newly created .las files. This LAS dataset is created only when the output folder is specified to generate the LAS output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLasDatasetLayer()]
		public object? OutLasObstacles { get; set; }

		/// <summary>
		/// <para>Vertical Clearance</para>
		/// <para>If a LAS point height is above the OIS surface, that point will be captured. The height of an OIS surface above a given LAS point is temporarily lowered by the specified vertical clearance value. This decreases the distance between the height of the LAS point and the corresponding OIS surface, resulting in the likeliness that more points will be captured. Consequently, a larger collection of ground features, represented by the LAS points penetrating through the OIS surface, will be captured.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? VerticalClearance { get; set; } = "0";

		/// <summary>
		/// <para>Vertical Clearance Unit</para>
		/// <para>The linear unit that will be used for the vertical clearance.</para>
		/// <para>Kilometers—The linear unit will be kilometers.</para>
		/// <para>Meters—The linear unit will be meters.</para>
		/// <para>Decimeters—The linear unit will be decimeters.</para>
		/// <para>Centimeters—The linear unit will be centimeters.</para>
		/// <para>Millimeters—The linear unit will be millimeters.</para>
		/// <para>Nautical miles—The linear unit will be nautical miles.</para>
		/// <para>Miles—The linear unit will be miles.</para>
		/// <para>Yards—The linear unit will be yards.</para>
		/// <para>Feet—The linear unit will be feet.</para>
		/// <para>Inches—The linear unit will be inches.</para>
		/// <para>Decimal degrees—The linear unit will be decimal degrees.</para>
		/// <para>Points—The linear unit will be points.</para>
		/// <para>Unknown—The linear unit will be unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? VerticalClearanceUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeLASRunwayObstacles SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
