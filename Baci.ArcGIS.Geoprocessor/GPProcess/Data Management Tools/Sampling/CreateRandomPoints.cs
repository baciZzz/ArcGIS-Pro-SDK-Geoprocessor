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
	/// <para>Create Random Points</para>
	/// <para>Creates a specified number of random point features. Random points can be generated in an extent window, inside polygon features, on point features, or along line features.</para>
	/// </summary>
	public class CreateRandomPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>The location or workspace in which the random points feature class will be created. This location or workspace must already exist.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Point Feature Class</para>
		/// <para>The name of the random points feature class to be created.</para>
		/// </param>
		public CreateRandomPoints(object OutPath, object OutName)
		{
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Random Points</para>
		/// </summary>
		public override string DisplayName => "Create Random Points";

		/// <summary>
		/// <para>Tool Name : CreateRandomPoints</para>
		/// </summary>
		public override string ToolName => "CreateRandomPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRandomPoints</para>
		/// </summary>
		public override string ExcuteName => "management.CreateRandomPoints";

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
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutPath, OutName, ConstrainingFeatureClass!, ConstrainingExtent!, NumberOfPointsOrField!, MinimumAllowedDistance!, CreateMultipointOutput!, MultipointSize!, OutFeatureClass! };

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The location or workspace in which the random points feature class will be created. This location or workspace must already exist.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Output Point Feature Class</para>
		/// <para>The name of the random points feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Constraining Feature Class</para>
		/// <para>Random points will be generated inside or along the features in this feature class. The constraining feature class can be point, multipoint, line, or polygon. Points will be randomly placed inside polygon features, along line features, or at point feature locations. Each feature in this feature class will have the specified number of points generated inside it (for example, if you specify 100 points, and the constraining feature class has 5 features, 100 random points will be generated in each feature, totaling 500 points).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? ConstrainingFeatureClass { get; set; }

		/// <summary>
		/// <para>Constraining Extent</para>
		/// <para>Random points will be generated inside the extent. The constraining extent will only be used if no constraining feature class is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? ConstrainingExtent { get; set; }

		/// <summary>
		/// <para>Number of Points [value or field]</para>
		/// <para>The number of points to be randomly generated.</para>
		/// <para>The number of points can be specified as a long integer number or as a field from the constraining features containing numeric values for how many random points to place within each feature. The field option is only valid for polygon or line constraining features. If the number of points is supplied as a long integer number, each feature in the constraining feature class will have that number of random points generated inside or along it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? NumberOfPointsOrField { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Allowed Distance [value or field]</para>
		/// <para>The shortest distance allowed between any two randomly placed points. If a value of 1 Meter is specified, all random points will be farther than 1 meter away from the closest point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? MinimumAllowedDistance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Create Multipoint Output</para>
		/// <para>Determines if the output feature class will be a multipart or single-part feature.</para>
		/// <para>Unchecked—The output will be geometry type point (each point is a separate feature). This is the default.</para>
		/// <para>Checked—The output will be geometry type multipoint (all points are a single feature).</para>
		/// <para><see cref="CreateMultipointOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateMultipointOutput { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Number of Points per Multipoint</para>
		/// <para>If Create Multipoint Output is checked, specify the number of random points to be placed in each multipoint geometry.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? MultipointSize { get; set; } = "10";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRandomPoints SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? randomGenerator = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create Multipoint Output</para>
		/// </summary>
		public enum CreateMultipointOutputEnum 
		{
			/// <summary>
			/// <para>Checked—The output will be geometry type multipoint (all points are a single feature).</para>
			/// </summary>
			[GPValue("true")]
			[Description("MULTIPOINT")]
			MULTIPOINT,

			/// <summary>
			/// <para>Unchecked—The output will be geometry type point (each point is a separate feature). This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("POINT")]
			POINT,

		}

#endregion
	}
}
