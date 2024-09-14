using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Raster to NetCDF</para>
	/// <para>栅格至 NetCDF</para>
	/// <para>将栅格数据集转换为 NetCDF 文件。</para>
	/// </summary>
	public class RasterToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入栅格数据集。</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF File</para>
		/// <para>输出的 netCDF 文件。 文件名的扩展名必须是 .nc。</para>
		/// </param>
		public RasterToNetCDF(object InRaster, object OutNetcdfFile)
		{
			this.InRaster = InRaster;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格至 NetCDF</para>
		/// </summary>
		public override string DisplayName() => "栅格至 NetCDF";

		/// <summary>
		/// <para>Tool Name : RasterToNetCDF</para>
		/// </summary>
		public override string ToolName() => "RasterToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : md.RasterToNetCDF</para>
		/// </summary>
		public override string ExcuteName() => "md.RasterToNetCDF";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutNetcdfFile, Variable, VariableUnits, XDimension, YDimension, BandDimension, FieldsToDimensions, CompressionLevel };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output netCDF File</para>
		/// <para>输出的 netCDF 文件。 文件名的扩展名必须是 .nc。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>将在输出 netCDF 文件中使用的 netCDF 变量名。此变量将包含输入栅格中像元的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Variable { get; set; }

		/// <summary>
		/// <para>Variable Units</para>
		/// <para>包含在变量中的数据的单位。变量名在变量参数中指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object VariableUnits { get; set; }

		/// <summary>
		/// <para>X Dimension</para>
		/// <para>将用于指定 x 坐标或经度坐标的 NetCDF 维度名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object XDimension { get; set; }

		/// <summary>
		/// <para>Y Dimension</para>
		/// <para>将用于指定 y 坐标或纬度坐标的 NetCDF 维度名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object YDimension { get; set; }

		/// <summary>
		/// <para>Band Dimension</para>
		/// <para>将用于指定波段的 NetCDF 维度名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BandDimension { get; set; }

		/// <summary>
		/// <para>Fields to Dimensions</para>
		/// <para>在 netCDF 文件中创建维度时使用的字段。</para>
		/// <para>Field - 输入栅格属性表中的某个字段。</para>
		/// <para>Dimension - netCDF 维度名称</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object FieldsToDimensions { get; set; }

		/// <summary>
		/// <para>Compression Level</para>
		/// <para>输出 netCDF 文件将被压缩的级别。默认值为 0，表示不进行压缩。值为 9 表示压缩程度最大。</para>
		/// <para><see cref="CompressionLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object CompressionLevel { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToNetCDF SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compression Level</para>
		/// </summary>
		public enum CompressionLevelEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("1")]
			[Description("1")]
			_1,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2")]
			[Description("2")]
			_2,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("3")]
			[Description("3")]
			_3,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("4")]
			[Description("4")]
			_4,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("5")]
			[Description("5")]
			_5,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("6")]
			[Description("6")]
			_6,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("7")]
			[Description("7")]
			_7,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("8")]
			[Description("8")]
			_8,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("9")]
			[Description("9")]
			_9,

		}

#endregion
	}
}
