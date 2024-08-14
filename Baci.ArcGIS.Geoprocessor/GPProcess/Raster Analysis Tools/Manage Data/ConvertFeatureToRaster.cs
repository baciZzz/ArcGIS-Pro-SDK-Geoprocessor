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
	/// <para>Convert Feature To Raster</para>
	/// <para>Converts features to a raster dataset.</para>
	/// </summary>
	public class ConvertFeatureToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputfeatures">
		/// <para>Input Features</para>
		/// <para>The input feature layer.</para>
		/// </param>
		/// <param name="Valuefield">
		/// <para>Value field</para>
		/// <para>Choose the field that will be used to assign values to the output raster.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public ConvertFeatureToRaster(object Inputfeatures, object Valuefield, object Outputname)
		{
			this.Inputfeatures = Inputfeatures;
			this.Valuefield = Valuefield;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Feature To Raster</para>
		/// </summary>
		public override string DisplayName => "Convert Feature To Raster";

		/// <summary>
		/// <para>Tool Name : ConvertFeatureToRaster</para>
		/// </summary>
		public override string ToolName => "ConvertFeatureToRaster";

		/// <summary>
		/// <para>Tool Excute Name : ra.ConvertFeatureToRaster</para>
		/// </summary>
		public override string ExcuteName => "ra.ConvertFeatureToRaster";

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
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputfeatures, Valuefield, Outputname, Outputcellsize, Outputraster };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputfeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>Choose the field that will be used to assign values to the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object Valuefield { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>Enter the cell size and unit for the output raster.</para>
		/// <para>The units can be Kilometers, Meters, Miles, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="OutputcellsizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertFeatureToRaster SetEnviroment(object cellSize = null , object extent = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Cell Size</para>
		/// </summary>
		public enum OutputcellsizeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

#endregion
	}
}
