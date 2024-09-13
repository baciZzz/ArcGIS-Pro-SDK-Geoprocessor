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
	/// <para>栅格转数字地形高程 (DTED)</para>
	/// <para>根据数字地形高程数据分块结构将栅格数据集分割成独立的文件。</para>
	/// </summary>
	public class RasterToDTED : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>选择表示高程的单波段栅格数据集。</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>选择将创建文件夹结构和 DTED 文件的目标文件夹。</para>
		/// </param>
		/// <param name="DtedLevel">
		/// <para>DTED Level</para>
		/// <para>根据高程数据的分辨率选择相应的级别。</para>
		/// <para>级别 0— 900 m</para>
		/// <para>级别 1— 90 m</para>
		/// <para>级别 2—30 m</para>
		/// <para><see cref="DtedLevelEnum"/></para>
		/// </param>
		public RasterToDTED(object InRaster, object OutFolder, object DtedLevel)
		{
			this.InRaster = InRaster;
			this.OutFolder = OutFolder;
			this.DtedLevel = DtedLevel;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转数字地形高程 (DTED)</para>
		/// </summary>
		public override string DisplayName() => "栅格转数字地形高程 (DTED)";

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
		public override object[] Parameters() => new object[] { InRaster, OutFolder, DtedLevel, ResamplingType, DerivedFolder };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>选择表示高程的单波段栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>选择将创建文件夹结构和 DTED 文件的目标文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>DTED Level</para>
		/// <para>根据高程数据的分辨率选择相应的级别。</para>
		/// <para>级别 0— 900 m</para>
		/// <para>级别 1— 90 m</para>
		/// <para>级别 2—30 m</para>
		/// <para><see cref="DtedLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DtedLevel { get; set; } = "DTED_1";

		/// <summary>
		/// <para>Resampling Technique</para>
		/// <para>根据您拥有的数据类型选择相应的技术。</para>
		/// <para>最邻近—最快的重采样方法，可最大程度减少像素值的变化。适用于离散数据，例如土地覆被。</para>
		/// <para>双线性—可采用平均化（距离权重）周围 4 个像素的值计算每个像素的值。适用于连续数据。</para>
		/// <para>三次—通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。生成平滑影像，但可创建位于源数据中超出范围外的值。适用于连续数据。</para>
		/// <para><see cref="ResamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResamplingType { get; set; } = "BILINEAR";

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToDTED SetEnviroment(object resamplingMethod = null )
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
			/// <para>级别 0— 900 m</para>
			/// </summary>
			[GPValue("DTED_0")]
			[Description("级别 0")]
			Level_0,

			/// <summary>
			/// <para>级别 1— 90 m</para>
			/// </summary>
			[GPValue("DTED_1")]
			[Description("级别 1")]
			Level_1,

			/// <summary>
			/// <para>级别 2—30 m</para>
			/// </summary>
			[GPValue("DTED_2")]
			[Description("级别 2")]
			Level_2,

		}

		/// <summary>
		/// <para>Resampling Technique</para>
		/// </summary>
		public enum ResamplingTypeEnum 
		{
			/// <summary>
			/// <para>双线性—可采用平均化（距离权重）周围 4 个像素的值计算每个像素的值。适用于连续数据。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性")]
			Bilinear,

			/// <summary>
			/// <para>最邻近—最快的重采样方法，可最大程度减少像素值的变化。适用于离散数据，例如土地覆被。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近")]
			Nearest,

			/// <summary>
			/// <para>三次—通过根据周围的 16 像素拟合平滑曲线来计算每个像素的值。生成平滑影像，但可创建位于源数据中超出范围外的值。适用于连续数据。</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("三次")]
			Cubic,

		}

#endregion
	}
}
