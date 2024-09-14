using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>LAS Point Statistics By Area</para>
	/// <para>按区域统计 LAS 点</para>
	/// <para>评估与面要素定义的区域叠加的 LAS 点的统计信息。</para>
	/// </summary>
	public class LasPointStatsByArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Polygons</para>
		/// <para>用于定义将要为其报告统计数据的区域的面。</para>
		/// </param>
		public LasPointStatsByArea(object InLasDataset, object InFeatures)
		{
			this.InLasDataset = InLasDataset;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 按区域统计 LAS 点</para>
		/// </summary>
		public override string DisplayName() => "按区域统计 LAS 点";

		/// <summary>
		/// <para>Tool Name : LasPointStatsByArea</para>
		/// </summary>
		public override string ToolName() => "LasPointStatsByArea";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasPointStatsByArea</para>
		/// </summary>
		public override string ExcuteName() => "3d.LasPointStatsByArea";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, InFeatures, OutProperty, OutputPolygons };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>用于定义将要为其报告统计数据的区域的面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Property</para>
		/// <para>将要计算的属性。</para>
		/// <para>Z 最小值—与要素重叠的 LAS 点的最低 Z 值。</para>
		/// <para>Z 最大值—与要素重叠的 LAS 点的最高 Z 值。</para>
		/// <para>Z 平均值—与要素重叠的 LAS 点的平均 Z 值。</para>
		/// <para>LAS 点计数—已评估的 LAS 点的计数。</para>
		/// <para>标准差—Z 值的标准差。</para>
		/// <para><see cref="OutPropertyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object OutProperty { get; set; }

		/// <summary>
		/// <para>Updated Input Polygons</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutputPolygons { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasPointStatsByArea SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Property</para>
		/// </summary>
		public enum OutPropertyEnum 
		{
			/// <summary>
			/// <para>Z 最小值—与要素重叠的 LAS 点的最低 Z 值。</para>
			/// </summary>
			[GPValue("Z_MIN")]
			[Description("Z 最小值")]
			Minimum_Z,

			/// <summary>
			/// <para>Z 最大值—与要素重叠的 LAS 点的最高 Z 值。</para>
			/// </summary>
			[GPValue("Z_MAX")]
			[Description("Z 最大值")]
			Maximum_Z,

			/// <summary>
			/// <para>Z 平均值—与要素重叠的 LAS 点的平均 Z 值。</para>
			/// </summary>
			[GPValue("Z_MEAN")]
			[Description("Z 平均值")]
			Average_Z,

			/// <summary>
			/// <para>LAS 点计数—已评估的 LAS 点的计数。</para>
			/// </summary>
			[GPValue("POINT_COUNT")]
			[Description("LAS 点计数")]
			LAS_Point_Count,

			/// <summary>
			/// <para>标准差—Z 值的标准差。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("标准差")]
			Standard_Deviation,

		}

#endregion
	}
}
