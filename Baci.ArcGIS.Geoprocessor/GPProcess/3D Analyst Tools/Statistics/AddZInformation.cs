using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Add Z Information</para>
	/// <para>Add Z Information</para>
	/// <para>Adds information about elevation properties of features in a z-enabled feature class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddZInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>The input features to process.</para>
		/// </param>
		/// <param name="OutProperty">
		/// <para>Output Property</para>
		/// <para>Specifies the z-properties that will be added to the attribute table of the input feature class.</para>
		/// <para>Spot Z—Spot elevation of single-point feature.</para>
		/// <para>Point Count—Number of points in each multipoint feature.</para>
		/// <para>Lowest Z—Lowest z-value found in each multipoint, polyline, polygon, or multipatch feature.</para>
		/// <para>Highest Z—Highest z-value found in each multipoint, polyline, polygon, or multipatch feature.</para>
		/// <para>Average Z—Average z-value found in each multipoint, polyline, polygon, or multipatch feature.</para>
		/// <para>3-Dimensional Length—3-dimensional length of each polyline or polygon feature.</para>
		/// <para>Surface Area—Total area of the surface of a multipatch feature.</para>
		/// <para>Vertex Count—Total number of vertices in each polyline or polygon feature.</para>
		/// <para>Lowest Slope—Lowest slope value calculated for each polyline, polygon, or multipatch feature.</para>
		/// <para>Highest Slope—Highest slope value calculated for each polyline, polygon, or multipatch feature.</para>
		/// <para>Average Slope—Average slope value calculated for each polyline, polygon, or multipatch feature.</para>
		/// <para>Volume—Volume of space enclosed by each multipatch feature.</para>
		/// </param>
		public AddZInformation(object InFeatureClass, object OutProperty)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutProperty = OutProperty;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Z Information</para>
		/// </summary>
		public override string DisplayName() => "Add Z Information";

		/// <summary>
		/// <para>Tool Name : AddZInformation</para>
		/// </summary>
		public override string ToolName() => "AddZInformation";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddZInformation</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddZInformation";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutProperty, NoiseFiltering!, OutputFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint", "MultiPatch")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Property</para>
		/// <para>Specifies the z-properties that will be added to the attribute table of the input feature class.</para>
		/// <para>Spot Z—Spot elevation of single-point feature.</para>
		/// <para>Point Count—Number of points in each multipoint feature.</para>
		/// <para>Lowest Z—Lowest z-value found in each multipoint, polyline, polygon, or multipatch feature.</para>
		/// <para>Highest Z—Highest z-value found in each multipoint, polyline, polygon, or multipatch feature.</para>
		/// <para>Average Z—Average z-value found in each multipoint, polyline, polygon, or multipatch feature.</para>
		/// <para>3-Dimensional Length—3-dimensional length of each polyline or polygon feature.</para>
		/// <para>Surface Area—Total area of the surface of a multipatch feature.</para>
		/// <para>Vertex Count—Total number of vertices in each polyline or polygon feature.</para>
		/// <para>Lowest Slope—Lowest slope value calculated for each polyline, polygon, or multipatch feature.</para>
		/// <para>Highest Slope—Highest slope value calculated for each polyline, polygon, or multipatch feature.</para>
		/// <para>Average Slope—Average slope value calculated for each polyline, polygon, or multipatch feature.</para>
		/// <para>Volume—Volume of space enclosed by each multipatch feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object OutProperty { get; set; }

		/// <summary>
		/// <para>Noise Filtering</para>
		/// <para>An numeric value that will be used to exclude portions of features from the resulting calculations. This can be useful when the 3D input contains relatively small features with extreme slopes which may bias statistical results. If the 3D input's linear units are meters, specifying a value of 0.001 will result in the exclusion of lines or polygon edges that are shorter than 0.001 meters. For multipatch features, the same value will result in the exclusion of its subparts that have an area less than 0.001 square meters. This parameter does not apply to point and multipoint features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NoiseFiltering { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddZInformation SetEnviroment(int? autoCommit = null , object? extent = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, workspace: workspace);
			return this;
		}

	}
}
