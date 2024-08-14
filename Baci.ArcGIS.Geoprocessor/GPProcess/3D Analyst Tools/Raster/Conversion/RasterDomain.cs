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
	/// <para>Raster Domain</para>
	/// <para>Constructs a 3D polygon or polyline delineating the height along the boundary of a raster surface.</para>
	/// </summary>
	public class RasterDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="OutGeometryType">
		/// <para>Output Feature Class Type</para>
		/// <para>The geometry of the output feature class.</para>
		/// <para>Line—The output will be a z-enabled line feature class.</para>
		/// <para>Polygon—The output will be a z-enabled polygon feature class.</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </param>
		public RasterDomain(object InRaster, object OutFeatureClass, object OutGeometryType)
		{
			this.InRaster = InRaster;
			this.OutFeatureClass = OutFeatureClass;
			this.OutGeometryType = OutGeometryType;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster Domain</para>
		/// </summary>
		public override string DisplayName => "Raster Domain";

		/// <summary>
		/// <para>Tool Name : RasterDomain</para>
		/// </summary>
		public override string ToolName => "RasterDomain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RasterDomain</para>
		/// </summary>
		public override string ExcuteName => "3d.RasterDomain";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, OutFeatureClass, OutGeometryType };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>The geometry of the output feature class.</para>
		/// <para>Line—The output will be a z-enabled line feature class.</para>
		/// <para>Polygon—The output will be a z-enabled polygon feature class.</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutGeometryType { get; set; } = "LINE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterDomain SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>Line—The output will be a z-enabled line feature class.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Polygon—The output will be a z-enabled polygon feature class.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

		}

#endregion
	}
}
