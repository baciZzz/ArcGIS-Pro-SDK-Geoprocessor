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
	/// <para>Update Feature Z</para>
	/// <para>Updates the z-coordinates of 3D feature vertices using a surface.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateFeatureZ : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The 3D features whose vertex z-values will be modified.</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The surface that will be used to determine the new z-value for the 3D feature vertices.</para>
		/// </param>
		public UpdateFeatureZ(object InFeatures, object InSurface)
		{
			this.InFeatures = InFeatures;
			this.InSurface = InSurface;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Feature Z</para>
		/// </summary>
		public override string DisplayName() => "Update Feature Z";

		/// <summary>
		/// <para>Tool Name : UpdateFeatureZ</para>
		/// </summary>
		public override string ToolName() => "UpdateFeatureZ";

		/// <summary>
		/// <para>Tool Excute Name : 3d.UpdateFeatureZ</para>
		/// </summary>
		public override string ExcuteName() => "3d.UpdateFeatureZ";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InSurface, Method, StatusField, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The 3D features whose vertex z-values will be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The surface that will be used to determine the new z-value for the 3D feature vertices.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Interpolation Method</para>
		/// <para>Interpolation method used in determining information about the surface. The available options depend on the data type of the input surface:</para>
		/// <para>Bilinear—An interpolation method exclusive to the raster surface, which determines cell values from the four nearest cells. This is the only option available for a raster surface.</para>
		/// <para>Linear— Default interpolation method for a TIN, terrain, and LAS dataset. Obtains elevation from the plane defined by the triangle that contains the XY location of a query point.</para>
		/// <para>Natural Neighbors— Obtains elevation by applying area-based weights to the natural neighbors of a query point.</para>
		/// <para>Conflate Minimum Z— Obtains elevation from the smallest z-value found among the natural neighbors of a query point.</para>
		/// <para>Conflate Maximum Z— Obtains elevation from the largest z-value found among the natural neighbors of a query point.</para>
		/// <para>Conflate Nearest Z— Obtains elevation from the nearest value among the natural neighbors of a query point.</para>
		/// <para>Conflate Z Closest To Mean— Obtains elevation from the z-value that is closest to the average of all the natural neighbors of a query point.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Status Field</para>
		/// <para>An existing numeric field that will be populated with values to reflect whether the feature's vertices were successfully updated. A value of 1 would be specified for updated features and 0 for features that were not updated. Features that partially overlap the surface will not be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object StatusField { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateFeatureZ SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Linear— Default interpolation method for a TIN, terrain, and LAS dataset. Obtains elevation from the plane defined by the triangle that contains the XY location of a query point.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbors— Obtains elevation by applying area-based weights to the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("Natural Neighbors")]
			Natural_Neighbors,

			/// <summary>
			/// <para>Conflate Minimum Z— Obtains elevation from the smallest z-value found among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_ZMIN")]
			[Description("Conflate Minimum Z")]
			Conflate_Minimum_Z,

			/// <summary>
			/// <para>Conflate Maximum Z— Obtains elevation from the largest z-value found among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_ZMAX")]
			[Description("Conflate Maximum Z")]
			Conflate_Maximum_Z,

			/// <summary>
			/// <para>Conflate Nearest Z— Obtains elevation from the nearest value among the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_NEAREST")]
			[Description("Conflate Nearest Z")]
			Conflate_Nearest_Z,

			/// <summary>
			/// <para>Conflate Z Closest To Mean— Obtains elevation from the z-value that is closest to the average of all the natural neighbors of a query point.</para>
			/// </summary>
			[GPValue("CONFLATE_CLOSEST_TO_MEAN")]
			[Description("Conflate Z Closest To Mean")]
			Conflate_Z_Closest_To_Mean,

			/// <summary>
			/// <para>Bilinear—An interpolation method exclusive to the raster surface, which determines cell values from the four nearest cells. This is the only option available for a raster surface.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

		}

#endregion
	}
}
