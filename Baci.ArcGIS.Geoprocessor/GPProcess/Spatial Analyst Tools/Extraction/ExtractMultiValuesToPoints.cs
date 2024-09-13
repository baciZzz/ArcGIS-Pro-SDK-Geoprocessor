using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Extract Multi Values to Points</para>
	/// <para>多值提取至点</para>
	/// <para>在点要素类的指定位置提取一个或多个栅格像元值，并将这些值记录到点要素类的属性表中。</para>
	/// </summary>
	public class ExtractMultiValuesToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input point features</para>
		/// <para>将添加栅格值的输入点要素。</para>
		/// </param>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>将基于输入点要素的位置提取的输入栅格（或栅格）值。</para>
		/// <para>您还可以为存储栅格值的字段指定名称。 默认情况下，将根据输入栅格数据集的名称创建唯一的字段名称。</para>
		/// </param>
		public ExtractMultiValuesToPoints(object InPointFeatures, object InRasters)
		{
			this.InPointFeatures = InPointFeatures;
			this.InRasters = InRasters;
		}

		/// <summary>
		/// <para>Tool Display Name : 多值提取至点</para>
		/// </summary>
		public override string DisplayName() => "多值提取至点";

		/// <summary>
		/// <para>Tool Name : ExtractMultiValuesToPoints</para>
		/// </summary>
		public override string ToolName() => "ExtractMultiValuesToPoints";

		/// <summary>
		/// <para>Tool Excute Name : sa.ExtractMultiValuesToPoints</para>
		/// </summary>
		public override string ExcuteName() => "sa.ExtractMultiValuesToPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "extent", "mask", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, InRasters, BilinearInterpolateValues!, OutPointFeatures! };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>将添加栅格值的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DEFeatureClass", "GPFeatureLayer", "GPTableView", "DETextFile")]
		[FieldType("Short", "Long", "Float", "Double", "Geometry")]
		[GeometryType("Point", "Multipoint")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>将基于输入点要素的位置提取的输入栅格（或栅格）值。</para>
		/// <para>您还可以为存储栅格值的字段指定名称。 默认情况下，将根据输入栅格数据集的名称创建唯一的字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAExtractValues()]
		[GPCompositeDomain()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Bilinear interpolation of values at point locations</para>
		/// <para>指定是否使用插值。</para>
		/// <para>未选中 - 不应用任何插值法；将使用像元中心值。 这是默认设置。</para>
		/// <para>选中 - 将使用双线性插值法根据相邻像元的有效值计算像元值。 将在插值中忽略 NoData 值，除非所有相邻像元均为 NoData。</para>
		/// <para><see cref="BilinearInterpolateValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? BilinearInterpolateValues { get; set; } = "false";

		/// <summary>
		/// <para>Updated point features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutPointFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractMultiValuesToPoints SetEnviroment(int? autoCommit = null , object? configKeyword = null , object? extent = null , object? mask = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, mask: mask, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bilinear interpolation of values at point locations</para>
		/// </summary>
		public enum BilinearInterpolateValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BILINEAR")]
			BILINEAR,

		}

#endregion
	}
}
