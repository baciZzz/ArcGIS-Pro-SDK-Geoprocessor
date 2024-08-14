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
	/// <para>Compute Pansharpen Weights</para>
	/// <para>Calculates an optimal set of pan sharpened weights for new or custom sensor data.</para>
	/// </summary>
	public class ComputePansharpenWeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>A multispectral raster that has a panchromatic band.</para>
		/// </param>
		/// <param name="InPanchromaticImage">
		/// <para>Panchromatic Image</para>
		/// <para>The panchromatic band associated with the multispectral raster.</para>
		/// </param>
		public ComputePansharpenWeights(object InRaster, object InPanchromaticImage)
		{
			this.InRaster = InRaster;
			this.InPanchromaticImage = InPanchromaticImage;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Pansharpen Weights</para>
		/// </summary>
		public override string DisplayName => "Compute Pansharpen Weights";

		/// <summary>
		/// <para>Tool Name : ComputePansharpenWeights</para>
		/// </summary>
		public override string ToolName => "ComputePansharpenWeights";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputePansharpenWeights</para>
		/// </summary>
		public override string ExcuteName => "management.ComputePansharpenWeights";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRaster, InPanchromaticImage, BandIndexes!, OutString! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>A multispectral raster that has a panchromatic band.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Panchromatic Image</para>
		/// <para>The panchromatic band associated with the multispectral raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InPanchromaticImage { get; set; }

		/// <summary>
		/// <para>Band Indexes</para>
		/// <para>The band order for the pan sharpened weights.</para>
		/// <para>If a raster product is used as the Input Raster, the band order within the raster product template will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? BandIndexes { get; set; }

		/// <summary>
		/// <para>Pan-sharpened Weights</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutString { get; set; }

	}
}
