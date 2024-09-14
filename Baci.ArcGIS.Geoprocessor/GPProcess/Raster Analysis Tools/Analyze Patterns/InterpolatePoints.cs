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
	/// <para>Interpolate Points</para>
	/// <para>Interpolate Points</para>
	/// <para>Predicts values at new locations based on measurements from a collection of points. The tool takes point data with values at each point and returns a raster of predicted values.</para>
	/// </summary>
	public class InterpolatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpointfeatures">
		/// <para>Input Point Features</para>
		/// <para>The input point features you want to interpolate.</para>
		/// </param>
		/// <param name="Interpolatefield">
		/// <para>Interpolate Field</para>
		/// <para>The field containing the data values you want to interpolate. The field must be numeric.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public InterpolatePoints(object Inputpointfeatures, object Interpolatefield, object Outputname)
		{
			this.Inputpointfeatures = Inputpointfeatures;
			this.Interpolatefield = Interpolatefield;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Interpolate Points</para>
		/// </summary>
		public override string DisplayName() => "Interpolate Points";

		/// <summary>
		/// <para>Tool Name : InterpolatePoints</para>
		/// </summary>
		public override string ToolName() => "InterpolatePoints";

		/// <summary>
		/// <para>Tool Excute Name : ra.InterpolatePoints</para>
		/// </summary>
		public override string ExcuteName() => "ra.InterpolatePoints";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpointfeatures, Interpolatefield, Outputname, Optimizefor, Transformdata, Sizeoflocalmodels, Numberofneighbors, Outputcellsize, Outputpredictionerror, Outputraster, Outputerrorraster };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The input point features you want to interpolate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object Inputpointfeatures { get; set; }

		/// <summary>
		/// <para>Interpolate Field</para>
		/// <para>The field containing the data values you want to interpolate. The field must be numeric.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Interpolatefield { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Optimize For</para>
		/// <para>Choose your preference for speed versus accuracy. More accurate predictions will take longer to calculate.</para>
		/// <para>Speed—The operation is optimized for speed.</para>
		/// <para>Balance—A balance between speed and accuracy. This is the default.</para>
		/// <para>Accuracy—The operation is optimized for accuracy.</para>
		/// <para><see cref="OptimizeforEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Optimizefor { get; set; } = "BALANCE";

		/// <summary>
		/// <para>Transform Data to Normal Distribution</para>
		/// <para>Choose whether to transform your data to a normal distribution before performing analysis. If your data values do not appear to be normally distributed (bell-shaped), it is recommended to perform a transformation.</para>
		/// <para>Checked—A transformation to the normal distribution is applied.</para>
		/// <para>Unchecked—No transformation is applied. This is the default.</para>
		/// <para><see cref="TransformdataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object Transformdata { get; set; } = "false";

		/// <summary>
		/// <para>Size of Local Models</para>
		/// <para>Choose the number of points in each of the local models. A larger value will make the interpolation more global and stable, but small-scale effects may be missed. Smaller values will make the interpolation more local, so small-scale effects are more likely to be captured, but the interpolation may be unstable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 500)]
		[Category("Additional Options")]
		public object Sizeoflocalmodels { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors to use when calculating the prediction at a particular cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 64)]
		[Category("Additional Options")]
		public object Numberofneighbors { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>Set the cell size and units of the output raster. If a prediction error raster is created, it will also use this cell size.</para>
		/// <para>The units can be Kilometers, Meters, Miles, or Feet.</para>
		/// <para>The default units are Meters.</para>
		/// <para><see cref="OutputcellsizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Prediction Error</para>
		/// <para>Choose whether to output a raster of standard errors of the interpolated predictions.</para>
		/// <para>Standard errors are useful because they provide information about the reliability of the predicted values. A simple rule of thumb is that the true value will fall within two standard errors of the predicted value 95 percent of the time. For example, suppose a new location gets a predicted value of 50 with a standard error of 5. This means that this task&apos;s best guess is that the true value at that location is 50, but it reasonably could be as low as 40 or as high as 60. To calculate this range of reasonable values, multiply the standard error by 2, add this value to the predicted value to get the upper end of the range, and subtract it from the predicted value to get the lower end of the range.</para>
		/// <para>If a raster of standard errors for the interpolated predictions is requested, it will have the same name as the Result layer name but with Errors appended.</para>
		/// <para>Unchecked—No output prediction error is generated. This is the default.</para>
		/// <para>Checked—An output prediction error is generated.</para>
		/// <para><see cref="OutputpredictionerrorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Outputpredictionerror { get; set; } = "false";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Output Error Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputerrorraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolatePoints SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Optimize For</para>
		/// </summary>
		public enum OptimizeforEnum 
		{
			/// <summary>
			/// <para>Speed—The operation is optimized for speed.</para>
			/// </summary>
			[GPValue("SPEED")]
			[Description("Speed")]
			Speed,

			/// <summary>
			/// <para>Balance—A balance between speed and accuracy. This is the default.</para>
			/// </summary>
			[GPValue("BALANCE")]
			[Description("Balance")]
			Balance,

			/// <summary>
			/// <para>Accuracy—The operation is optimized for accuracy.</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("Accuracy")]
			Accuracy,

		}

		/// <summary>
		/// <para>Transform Data to Normal Distribution</para>
		/// </summary>
		public enum TransformdataEnum 
		{
			/// <summary>
			/// <para>Checked—A transformation to the normal distribution is applied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRANSFORM")]
			TRANSFORM,

			/// <summary>
			/// <para>Unchecked—No transformation is applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRANSFORM")]
			NO_TRANSFORM,

		}

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

		/// <summary>
		/// <para>Output Prediction Error</para>
		/// </summary>
		public enum OutputpredictionerrorEnum 
		{
			/// <summary>
			/// <para>Checked—An output prediction error is generated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_ERROR")]
			OUTPUT_ERROR,

			/// <summary>
			/// <para>Unchecked—No output prediction error is generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OUTPUT_ERROR")]
			NO_OUTPUT_ERROR,

		}

#endregion
	}
}
