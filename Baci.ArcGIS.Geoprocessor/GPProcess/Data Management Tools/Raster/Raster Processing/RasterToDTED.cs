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
	/// <para>Raster To DTED</para>
	/// <para>Raster To DTED</para>
	/// <para>Splits a raster dataset into separate files based on the DTED tiling structure.</para>
	/// </summary>
	public class RasterToDTED : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>Select a single band raster dataset that represents elevation.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>Select a destination where the folder structure and DTED files will be created.</para>
		/// </param>
		/// <param name="DtedLevel">
		/// <para>DTED Level</para>
		/// <para>Select an appropriate level based on the resolution of your elevation data.</para>
		/// <para>Level 0— 900 m</para>
		/// <para>Level 1— 90 m</para>
		/// <para>Level 2—30 m</para>
		/// <para><see cref="DtedLevelEnum"/></para>
		/// </param>
		public RasterToDTED(object InRaster, object OutFolder, object DtedLevel)
		{
			this.InRaster = InRaster;
			this.OutFolder = OutFolder;
			this.DtedLevel = DtedLevel;
		}

		/// <summary>
		/// <para>Tool Display Name : Raster To DTED</para>
		/// </summary>
		public override string DisplayName() => "Raster To DTED";

		/// <summary>
		/// <para>Tool Name : RasterToDTED</para>
		/// </summary>
		public override string ToolName() => "RasterToDTED";

		/// <summary>
		/// <para>Tool Excute Name : management.RasterToDTED</para>
		/// </summary>
		public override string ExcuteName() => "management.RasterToDTED";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "resamplingMethod" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutFolder, DtedLevel, ResamplingType!, DerivedFolder! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>Select a single band raster dataset that represents elevation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>Select a destination where the folder structure and DTED files will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>DTED Level</para>
		/// <para>Select an appropriate level based on the resolution of your elevation data.</para>
		/// <para>Level 0— 900 m</para>
		/// <para>Level 1— 90 m</para>
		/// <para>Level 2—30 m</para>
		/// <para><see cref="DtedLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DtedLevel { get; set; } = "DTED_1";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>Choose an appropriate technique based on the type of data you have.</para>
		/// <para>Nearest—The fastest resampling method, and it minimizes changes to pixel values. Suitable for discrete data, such as land cover.</para>
		/// <para>Bilinear—Calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding 4 pixels. Suitable for continuous data.</para>
		/// <para>Cubic—Calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. Produces the smoothest image, but can create values outside of the range found in the source data. Suitable for continuous data.</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResamplingType { get; set; } = "BILINEAR";

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToDTED SetEnviroment(object? resamplingMethod = null)
		{
			base.SetEnv(resamplingMethod: resamplingMethod);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>DTED Level</para>
		/// </summary>
		public enum DtedLevelEnum 
		{
			/// <summary>
			/// <para>Level 0— 900 m</para>
			/// </summary>
			[GPValue("DTED_0")]
			[Description("Level 0")]
			Level_0,

			/// <summary>
			/// <para>Level 1— 90 m</para>
			/// </summary>
			[GPValue("DTED_1")]
			[Description("Level 1")]
			Level_1,

			/// <summary>
			/// <para>Level 2—30 m</para>
			/// </summary>
			[GPValue("DTED_2")]
			[Description("Level 2")]
			Level_2,

		}

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>Bilinear—Calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding 4 pixels. Suitable for continuous data.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Nearest—The fastest resampling method, and it minimizes changes to pixel values. Suitable for discrete data, such as land cover.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Cubic—Calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. Produces the smoothest image, but can create values outside of the range found in the source data. Suitable for continuous data.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

		}

#endregion
	}
}
