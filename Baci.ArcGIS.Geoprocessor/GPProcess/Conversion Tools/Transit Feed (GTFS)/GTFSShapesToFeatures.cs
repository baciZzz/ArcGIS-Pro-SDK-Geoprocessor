using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>GTFS Shapes To Features</para>
	/// <para>GTFS 形状转要素</para>
	/// <para>将 GTFS 公共交通数据集的 GTFS shapes.txt 文件转换为可显示公共交通系统中车辆所采用的物理路径的折线要素类。</para>
	/// </summary>
	public class GTFSShapesToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGtfsShapesFile">
		/// <para>Input GTFS Shapes File</para>
		/// <para>来自 GTFS 数据集的有效 shapes.txt 文件。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </param>
		public GTFSShapesToFeatures(object InGtfsShapesFile, object OutFeatureClass)
		{
			this.InGtfsShapesFile = InGtfsShapesFile;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GTFS 形状转要素</para>
		/// </summary>
		public override string DisplayName() => "GTFS 形状转要素";

		/// <summary>
		/// <para>Tool Name : GTFSShapesToFeatures</para>
		/// </summary>
		public override string ToolName() => "GTFSShapesToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.GTFSShapesToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.GTFSShapesToFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGtfsShapesFile, OutFeatureClass };

		/// <summary>
		/// <para>Input GTFS Shapes File</para>
		/// <para>来自 GTFS 数据集的有效 shapes.txt 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object InGtfsShapesFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GTFSShapesToFeatures SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
