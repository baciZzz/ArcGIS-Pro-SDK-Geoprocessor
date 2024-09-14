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
	/// <para>Feature to NetCDF</para>
	/// <para>要素至 NetCDF</para>
	/// <para>将点要素类转换为 NetCDF 文件。</para>
	/// </summary>
	public class FeatureToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入点要素类。</para>
		/// </param>
		/// <param name="FieldsToVariables">
		/// <para>Fields to Variables</para>
		/// <para>在 netCDF 文件中创建变量时使用的字段。</para>
		/// <para>使用四个特殊字段（Shape.X、Shape.Y、Shape.Z 和 Shape.M）可以分别导出输入要素的 x 坐标或经度、y 坐标或纬度、Z 值和 M 值。</para>
		/// <para>Field - 输入要素属性表中的某个字段。</para>
		/// <para>Variable - netCDF 变量名</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF File</para>
		/// <para>输出的 netCDF 文件。 文件名的扩展名必须是 .nc。</para>
		/// </param>
		public FeatureToNetCDF(object InFeatures, object FieldsToVariables, object OutNetcdfFile)
		{
			this.InFeatures = InFeatures;
			this.FieldsToVariables = FieldsToVariables;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素至 NetCDF</para>
		/// </summary>
		public override string DisplayName() => "要素至 NetCDF";

		/// <summary>
		/// <para>Tool Name : FeatureToNetCDF</para>
		/// </summary>
		public override string ToolName() => "FeatureToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : md.FeatureToNetCDF</para>
		/// </summary>
		public override string ExcuteName() => "md.FeatureToNetCDF";

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
		public override object[] Parameters() => new object[] { InFeatures, FieldsToVariables, OutNetcdfFile, FieldsToDimensions };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Fields to Variables</para>
		/// <para>在 netCDF 文件中创建变量时使用的字段。</para>
		/// <para>使用四个特殊字段（Shape.X、Shape.Y、Shape.Z 和 Shape.M）可以分别导出输入要素的 x 坐标或经度、y 坐标或纬度、Z 值和 M 值。</para>
		/// <para>Field - 输入要素属性表中的某个字段。</para>
		/// <para>Variable - netCDF 变量名</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object FieldsToVariables { get; set; }

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
		/// <para>Fields to Dimensions</para>
		/// <para>在 netCDF 文件中创建维度时使用的字段。</para>
		/// <para>Field - 输入要素属性表中的某个字段。</para>
		/// <para>Dimension - netCDF 维度名称</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object FieldsToDimensions { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureToNetCDF SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
