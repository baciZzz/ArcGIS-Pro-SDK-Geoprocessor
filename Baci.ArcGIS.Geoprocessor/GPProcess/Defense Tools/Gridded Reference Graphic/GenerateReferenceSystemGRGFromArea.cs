using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Generate Reference System Grid From Area</para>
	/// <para>Creates Gridded Reference Graphics (GRG) based on Military Grid Reference System (MGRS) or United States National Grid (USNG) reference grids.</para>
	/// </summary>
	public class GenerateReferenceSystemGRGFromArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Feature</para>
		/// <para>The input polygon feature on which the GRG will be based.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the GRG.</para>
		/// </param>
		/// <param name="GridReferenceSystem">
		/// <para>Grid Reference System</para>
		/// <para>Specifies the reference system the GRG will use.</para>
		/// <para>Military Grid Reference System—The Military Grid Reference System will be used. This is the default.</para>
		/// <para>United States National Grid—The United States National Grid will be used.</para>
		/// <para><see cref="GridReferenceSystemEnum"/></para>
		/// </param>
		/// <param name="GridSquareSize">
		/// <para>Grid Square Size</para>
		/// <para>Specifies the grid square size that will be used for the cells in the GRG.</para>
		/// <para>Grid Zone Designator—The size of the grid cells will be a Grid Zone. This is the default.</para>
		/// <para>100,000 m grid—The size of the grid cells will be 100,000-meter grid squares.</para>
		/// <para>10,000 m grid—The size of the grid cells will be 10,000-meter grid squares.</para>
		/// <para>1,000 m grid—The size of the grid cells will be 1,000-meter grid squares.</para>
		/// <para>100 m grid—The size of the grid cells will be 100-meter grid squares.</para>
		/// <para>10 m grid—The size of the grid cells will be 10-meter grid squares.</para>
		/// <para><see cref="GridSquareSizeEnum"/></para>
		/// </param>
		public GenerateReferenceSystemGRGFromArea(object InFeatures, object OutputFeatureClass, object GridReferenceSystem, object GridSquareSize)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.GridReferenceSystem = GridReferenceSystem;
			this.GridSquareSize = GridSquareSize;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Reference System Grid From Area</para>
		/// </summary>
		public override string DisplayName => "Generate Reference System Grid From Area";

		/// <summary>
		/// <para>Tool Name : GenerateReferenceSystemGRGFromArea</para>
		/// </summary>
		public override string ToolName => "GenerateReferenceSystemGRGFromArea";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateReferenceSystemGRGFromArea</para>
		/// </summary>
		public override string ExcuteName => "defense.GenerateReferenceSystemGRGFromArea";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutputFeatureClass, GridReferenceSystem, GridSquareSize, LargeGridHandling };

		/// <summary>
		/// <para>Input Feature</para>
		/// <para>The input polygon feature on which the GRG will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the GRG.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Grid Reference System</para>
		/// <para>Specifies the reference system the GRG will use.</para>
		/// <para>Military Grid Reference System—The Military Grid Reference System will be used. This is the default.</para>
		/// <para>United States National Grid—The United States National Grid will be used.</para>
		/// <para><see cref="GridReferenceSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GridReferenceSystem { get; set; } = "MGRS";

		/// <summary>
		/// <para>Grid Square Size</para>
		/// <para>Specifies the grid square size that will be used for the cells in the GRG.</para>
		/// <para>Grid Zone Designator—The size of the grid cells will be a Grid Zone. This is the default.</para>
		/// <para>100,000 m grid—The size of the grid cells will be 100,000-meter grid squares.</para>
		/// <para>10,000 m grid—The size of the grid cells will be 10,000-meter grid squares.</para>
		/// <para>1,000 m grid—The size of the grid cells will be 1,000-meter grid squares.</para>
		/// <para>100 m grid—The size of the grid cells will be 100-meter grid squares.</para>
		/// <para>10 m grid—The size of the grid cells will be 10-meter grid squares.</para>
		/// <para><see cref="GridSquareSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GridSquareSize { get; set; } = "GRID_ZONE_DESIGNATOR";

		/// <summary>
		/// <para>Large Grid Handling</para>
		/// <para>Specifies how large input areas that may contain many features will be handled.</para>
		/// <para>No large grids—Processing will stop when 2000 features are created. This is the default.</para>
		/// <para>Allow large grids—Large grids are supported.</para>
		/// <para><see cref="LargeGridHandlingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LargeGridHandling { get; set; } = "NO_LARGE_GRIDS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateReferenceSystemGRGFromArea SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Grid Reference System</para>
		/// </summary>
		public enum GridReferenceSystemEnum 
		{
			/// <summary>
			/// <para>Military Grid Reference System—The Military Grid Reference System will be used. This is the default.</para>
			/// </summary>
			[GPValue("MGRS")]
			[Description("Military Grid Reference System")]
			Military_Grid_Reference_System,

			/// <summary>
			/// <para>United States National Grid—The United States National Grid will be used.</para>
			/// </summary>
			[GPValue("USNG")]
			[Description("United States National Grid")]
			United_States_National_Grid,

		}

		/// <summary>
		/// <para>Grid Square Size</para>
		/// </summary>
		public enum GridSquareSizeEnum 
		{
			/// <summary>
			/// <para>Grid Zone Designator—The size of the grid cells will be a Grid Zone. This is the default.</para>
			/// </summary>
			[GPValue("GRID_ZONE_DESIGNATOR")]
			[Description("Grid Zone Designator")]
			Grid_Zone_Designator,

			/// <summary>
			/// <para>100,000 m grid—The size of the grid cells will be 100,000-meter grid squares.</para>
			/// </summary>
			[GPValue("100000M_GRID")]
			[Description("100,000 m grid")]
			_100000M_GRID,

			/// <summary>
			/// <para>10,000 m grid—The size of the grid cells will be 10,000-meter grid squares.</para>
			/// </summary>
			[GPValue("10000M_GRID")]
			[Description("10,000 m grid")]
			_10000M_GRID,

			/// <summary>
			/// <para>1,000 m grid—The size of the grid cells will be 1,000-meter grid squares.</para>
			/// </summary>
			[GPValue("1000M_GRID")]
			[Description("1,000 m grid")]
			_1000M_GRID,

			/// <summary>
			/// <para>100 m grid—The size of the grid cells will be 100-meter grid squares.</para>
			/// </summary>
			[GPValue("100M_GRID")]
			[Description("100 m grid")]
			_100_m_grid,

			/// <summary>
			/// <para>10 m grid—The size of the grid cells will be 10-meter grid squares.</para>
			/// </summary>
			[GPValue("10M_GRID")]
			[Description("10 m grid")]
			_10_m_grid,

		}

		/// <summary>
		/// <para>Large Grid Handling</para>
		/// </summary>
		public enum LargeGridHandlingEnum 
		{
			/// <summary>
			/// <para>No large grids—Processing will stop when 2000 features are created. This is the default.</para>
			/// </summary>
			[GPValue("NO_LARGE_GRIDS")]
			[Description("No large grids")]
			No_large_grids,

			/// <summary>
			/// <para>Allow large grids—Large grids are supported.</para>
			/// </summary>
			[GPValue("ALLOW_LARGE_GRIDS")]
			[Description("Allow large grids")]
			Allow_large_grids,

		}

#endregion
	}
}
