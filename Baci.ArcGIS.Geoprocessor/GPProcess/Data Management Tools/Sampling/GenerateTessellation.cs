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
	/// <para>Generate Tessellation</para>
	/// <para>Generates a tessellated grid of regular polygon features to cover a given extent.  The tessellation can be of triangles, squares, diamonds, hexagons, or transverse hexagons.</para>
	/// </summary>
	public class GenerateTessellation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The path and name of the output feature class containing the tessellated grid.</para>
		/// </param>
		/// <param name="Extent">
		/// <para>Extent</para>
		/// <para>The extent that the tessellation will cover. This can be the currently visible area, the extent of a dataset, or manually entered values.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </param>
		public GenerateTessellation(object OutputFeatureClass, object Extent)
		{
			this.OutputFeatureClass = OutputFeatureClass;
			this.Extent = Extent;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Tessellation</para>
		/// </summary>
		public override string DisplayName => "Generate Tessellation";

		/// <summary>
		/// <para>Tool Name : GenerateTessellation</para>
		/// </summary>
		public override string ToolName => "GenerateTessellation";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTessellation</para>
		/// </summary>
		public override string ExcuteName => "management.GenerateTessellation";

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
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OutputFeatureClass, Extent, ShapeType!, Size!, SpatialReference! };

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The path and name of the output feature class containing the tessellated grid.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>The extent that the tessellation will cover. This can be the currently visible area, the extent of a dataset, or manually entered values.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Shape Type</para>
		/// <para>Specifies the shape that will be generated.</para>
		/// <para>Hexagon—Hexagon-shaped features will be generated. The top and bottom side of each hexagon will be parallel with the x-axis of the coordinate system (the top and bottom are flat).</para>
		/// <para>Transverse hexagon—Transverse hexagon-shaped features will be generated. The right and left side of each hexagon will be parallel with the y-axis of the dataset&apos;s coordinate system (the top and bottom are pointed).</para>
		/// <para>Square—Square-shaped features will be generated. The top and bottom side of each square will be parallel with the x-axis of the coordinate system, and the right and left sides will be parallel with the y-axis of the coordinate system.</para>
		/// <para>Diamond—Diamond-shaped features will be generated. The sides of each polygon will be rotated 45 degrees away from the x- and y-axis of the coordinate system.</para>
		/// <para>Triangle—Triangular-shaped features will be generated. Each triangle will be a regular three-sided equilateral polygon.</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShapeType { get; set; } = "HEXAGON";

		/// <summary>
		/// <para>Size</para>
		/// <para>The area of each individual shape that comprises the tessellation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? Size { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference to which the output dataset will be projected. If a spatial reference is not provided, the output will be projected to the spatial reference of the input extent. If neither has a spatial reference, the output will be projected in GCS_WGS_1984.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTessellation SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape Type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>Square—Square-shaped features will be generated. The top and bottom side of each square will be parallel with the x-axis of the coordinate system, and the right and left sides will be parallel with the y-axis of the coordinate system.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Triangle—Triangular-shaped features will be generated. Each triangle will be a regular three-sided equilateral polygon.</para>
			/// </summary>
			[GPValue("TRIANGLE")]
			[Description("Triangle")]
			Triangle,

			/// <summary>
			/// <para>Hexagon—Hexagon-shaped features will be generated. The top and bottom side of each hexagon will be parallel with the x-axis of the coordinate system (the top and bottom are flat).</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

			/// <summary>
			/// <para>Diamond—Diamond-shaped features will be generated. The sides of each polygon will be rotated 45 degrees away from the x- and y-axis of the coordinate system.</para>
			/// </summary>
			[GPValue("DIAMOND")]
			[Description("Diamond")]
			Diamond,

			/// <summary>
			/// <para>Transverse hexagon—Transverse hexagon-shaped features will be generated. The right and left side of each hexagon will be parallel with the y-axis of the dataset&apos;s coordinate system (the top and bottom are pointed).</para>
			/// </summary>
			[GPValue("TRANSVERSE_HEXAGON")]
			[Description("Transverse hexagon")]
			Transverse_hexagon,

		}

#endregion
	}
}
