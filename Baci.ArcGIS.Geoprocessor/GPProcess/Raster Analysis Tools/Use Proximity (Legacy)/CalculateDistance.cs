using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Calculate Distance</para>
	/// <para>Calculates the Euclidean distance from a single source or set of sources.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation))]
	public class CalculateDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsourcerasterorfeatures">
		/// <para>Input Source Raster or Features</para>
		/// <para>The layer that defines the sources to calculate the distance to. The layer can be image service or feature service.</para>
		/// <para>For image service, the input type can be integer or floating point.</para>
		/// <para>For feature service, the input can be point, line or polygon.</para>
		/// </param>
		/// <param name="Outputdistancename">
		/// <para>Output Distance Name</para>
		/// <para>The name of the output distance raster service.</para>
		/// </param>
		public CalculateDistance(object Inputsourcerasterorfeatures, object Outputdistancename)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Outputdistancename = Outputdistancename;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Distance</para>
		/// </summary>
		public override string DisplayName => "Calculate Distance";

		/// <summary>
		/// <para>Tool Name : CalculateDistance</para>
		/// </summary>
		public override string ToolName => "CalculateDistance";

		/// <summary>
		/// <para>Tool Excute Name : ra.CalculateDistance</para>
		/// </summary>
		public override string ExcuteName => "ra.CalculateDistance";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputsourcerasterorfeatures, Outputdistancename, Maximumdistance!, Outputcellsize!, Outputdirectionname!, Outputallocationname!, Allocationfield!, Outputdistanceraster!, Outputdirectionraster!, Outputallocationraster!, Distancemethod!, Inputbarrierrasterorfeatures!, Outputbackdirectionname!, Outputbackdirectionraster! };

		/// <summary>
		/// <para>Input Source Raster or Features</para>
		/// <para>The layer that defines the sources to calculate the distance to. The layer can be image service or feature service.</para>
		/// <para>For image service, the input type can be integer or floating point.</para>
		/// <para>For feature service, the input can be point, line or polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Distance Name</para>
		/// <para>The name of the output distance raster service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputdistancename { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>The maximum distance to calculate out to.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Maximumdistance { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>Set the cell size and units for the output raster.</para>
		/// <para>The units can be Kilometers, Meters, Miles, Yards, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Direction Name</para>
		/// <para>The name of the output direction raster service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputdirectionname { get; set; }

		/// <summary>
		/// <para>Output Allocation Name</para>
		/// <para>The name of the output allocation raster service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputallocationname { get; set; }

		/// <summary>
		/// <para>Allocation Field</para>
		/// <para>A field on the source input that holds the values that define each source. It must be of type integer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Allocationfield { get; set; }

		/// <summary>
		/// <para>Output Distance Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputdistanceraster { get; set; }

		/// <summary>
		/// <para>Output Direction Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Allocation Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputallocationraster { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies whether to calculate the distance using a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
		/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
		/// <para><see cref="DistancemethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Distancemethod { get; set; } = "Planar";

		/// <summary>
		/// <para>Input Barrier Raster or Features</para>
		/// <para>Dataset that defines the barriers.</para>
		/// <para>The barriers can be defined by an integer or floating point raster, or a feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? Inputbarrierrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Back Direction Name</para>
		/// <para>The name of the output back direction raster service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputbackdirectionname { get; set; }

		/// <summary>
		/// <para>Output Back Direction Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputbackdirectionraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDistance SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistancemethodEnum 
		{
			/// <summary>
			/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("Planar")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
			/// </summary>
			[GPValue("Geodesic")]
			[Description("Geodesic")]
			Geodesic,

		}

#endregion
	}
}
