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
	/// <para>Create TIN</para>
	/// <para>Create TIN</para>
	/// <para>Creates a triangulated irregular network (TIN) dataset.</para>
	/// </summary>
	public class CreateTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </param>
		public CreateTin(object OutTin)
		{
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : Create TIN</para>
		/// </summary>
		public override string DisplayName() => "Create TIN";

		/// <summary>
		/// <para>Tool Name : CreateTin</para>
		/// </summary>
		public override string ToolName() => "CreateTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CreateTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.CreateTin";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutTin, SpatialReference!, InFeatures!, ConstrainedDelaunay! };

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>The TIN dataset that will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The spatial reference of the output TIN. Set the spatial reference to a projected coordinate system. Geographic coordinate systems are not recommended because Delaunay triangulation cannot be guaranteed when the x,y coordinates are expressed in angular units, which could have an adverse impact on the accuracy of distance-based calculations, such as slope, volume, and line of sight.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The input features and their related properties that will contribute to the definition of the TIN.</para>
		/// <para>Input Features—The feature with the geometry that will be imported to the TIN.</para>
		/// <para>Height Field—The source of elevation for the input features. Any numeric field from the input feature&apos;s attribute table can be used, along with Shape.Z for the z-values of 3D features and Shape.M for the m-values stored in the geometry. Choosing the &lt;None&gt; keyword will result in the feature&apos;s elevation being interpolated from the surrounding surface.</para>
		/// <para>Type—The feature&apos;s role in shaping the TIN surface will be defined. See the tool&apos;s usage tips for more information about surface feature types.</para>
		/// <para>Tag Field—A numeric attribute will be assigned to the TIN&apos;s data elements using values obtained from an integer field in the input feature&apos;s attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? InFeatures { get; set; }

		/// <summary>
		/// <para>Constrained Delaunay</para>
		/// <para>Specifies the triangulation technique that will be used along the breaklines of the TIN.</para>
		/// <para>Unchecked—The TIN will use Delaunay conforming triangulation, which may densify each segment of the breaklines to produce multiple triangle edges. This is the default.</para>
		/// <para>Checked—The TIN will use constrained Delaunay triangulation, which will add each segment as a single edge. Delaunay triangulation rules are honored everywhere except along breaklines, which will not be densified.</para>
		/// <para><see cref="ConstrainedDelaunayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConstrainedDelaunay { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTin SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? tinSaveVersion = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Constrained Delaunay</para>
		/// </summary>
		public enum ConstrainedDelaunayEnum 
		{
			/// <summary>
			/// <para>Checked—The TIN will use constrained Delaunay triangulation, which will add each segment as a single edge. Delaunay triangulation rules are honored everywhere except along breaklines, which will not be densified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONSTRAINED_DELAUNAY")]
			CONSTRAINED_DELAUNAY,

			/// <summary>
			/// <para>Unchecked—The TIN will use Delaunay conforming triangulation, which may densify each segment of the breaklines to produce multiple triangle edges. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DELAUNAY")]
			DELAUNAY,

		}

#endregion
	}
}
