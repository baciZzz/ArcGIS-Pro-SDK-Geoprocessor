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
	/// <para>NetCDF Time Series To Feature Class (Discrete Sampling Geometry)</para>
	/// <para>NetCDF 时间序列到要素类（离散采样几何）</para>
	/// <para>根据 netCDF 文件中的时间序列创建要素类。 在气候和预报 (CF) 元数据约定中，时间序列是一种离散采样几何 (DSG)。</para>
	/// </summary>
	public class NetCDFTimeSeriesToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFilesOrFolders">
		/// <para>Input NetCDF Files or Folders</para>
		/// <para>将用于创建要素类的输入 netCDF 文件。 可以使用单个 netCDF 文件以及包含多个 netCDF 文件的文件夹。</para>
		/// <para>输入 netCDF 文件必须具有相同的 DSG 要素类型和方案。</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>将在其中创建输出要素类和表的企业级地理数据库或文件地理数据库。 该工作空间必须是现有的工作空间。</para>
		/// </param>
		/// <param name="OutPointName">
		/// <para>Output Point Name</para>
		/// <para>将包含来自 netCDF 变量的位置的要素类的名称。 这些变量将作为实例变量参数中的字段进行添加。</para>
		/// </param>
		public NetCDFTimeSeriesToFeatureClass(object InFilesOrFolders, object TargetWorkspace, object OutPointName)
		{
			this.InFilesOrFolders = InFilesOrFolders;
			this.TargetWorkspace = TargetWorkspace;
			this.OutPointName = OutPointName;
		}

		/// <summary>
		/// <para>Tool Display Name : NetCDF 时间序列到要素类（离散采样几何）</para>
		/// </summary>
		public override string DisplayName() => "NetCDF 时间序列到要素类（离散采样几何）";

		/// <summary>
		/// <para>Tool Name : NetCDFTimeSeriesToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "NetCDFTimeSeriesToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : md.NetCDFTimeSeriesToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "md.NetCDFTimeSeriesToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFilesOrFolders, TargetWorkspace, OutPointName, ObservationVariables!, OutTableName!, InstanceVariables!, IncludeSubdirectories!, InCfMetadata!, AnalysisExtent!, OutJoinLayer!, OutPoint!, OutTable! };

		/// <summary>
		/// <para>Input NetCDF Files or Folders</para>
		/// <para>将用于创建要素类的输入 netCDF 文件。 可以使用单个 netCDF 文件以及包含多个 netCDF 文件的文件夹。</para>
		/// <para>输入 netCDF 文件必须具有相同的 DSG 要素类型和方案。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InFilesOrFolders { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>将在其中创建输出要素类和表的企业级地理数据库或文件地理数据库。 该工作空间必须是现有的工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Output Point Name</para>
		/// <para>将包含来自 netCDF 变量的位置的要素类的名称。 这些变量将作为实例变量参数中的字段进行添加。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutPointName { get; set; }

		/// <summary>
		/// <para>Observation Variables</para>
		/// <para>包含每个位置和每个垂直级别的所有观测值的 netCDF 变量。 这些变量将作为字段添加到输出表</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ObservationVariables { get; set; }

		/// <summary>
		/// <para>Output Join Table Name</para>
		/// <para>将包含观测变量参数中所有记录的输出表的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutTableName { get; set; }

		/// <summary>
		/// <para>Instance Variables</para>
		/// <para>区分各个要素并表示执行观测的位置的 netCDF 变量。 这些变量将作为字段添加到输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InstanceVariables { get; set; }

		/// <summary>
		/// <para>Include Subdirectories</para>
		/// <para>指定是否使用位于输入文件夹子目录中的文件。</para>
		/// <para>选中 - 将使用所有子目录中的所有 netCDF 文件。</para>
		/// <para>未选中 - 仅使用输入文件夹中的文件。 这是默认设置。</para>
		/// <para><see cref="IncludeSubdirectoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeSubdirectories { get; set; } = "false";

		/// <summary>
		/// <para>Input Climate and Forecast Metadata</para>
		/// <para>带有 .ncml 扩展名的 XML 文件，将为输入 netCDF 文件提供丢失或更改的 CF 信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("ncml", "xml")]
		public object? InCfMetadata { get; set; }

		/// <summary>
		/// <para>Analysis Extent</para>
		/// <para>定义输出要素类区域的范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? AnalysisExtent { get; set; }

		/// <summary>
		/// <para>Output Join Layer</para>
		/// <para>通过将输入表连接到输出要素类创建的输出图层。 此为可选输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? OutJoinLayer { get; set; }

		/// <summary>
		/// <para>Output Point</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline")]
		[FeatureType("Simple")]
		public object? OutPoint { get; set; }

		/// <summary>
		/// <para>Output Join Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NetCDFTimeSeriesToFeatureClass SetEnviroment(object? extent = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Subdirectories</para>
		/// </summary>
		public enum IncludeSubdirectoriesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SUBDIRECTORIES")]
			INCLUDE_SUBDIRECTORIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_SUBDIRECTORIES")]
			DO_NOT_INCLUDE_SUBDIRECTORIES,

		}

#endregion
	}
}
