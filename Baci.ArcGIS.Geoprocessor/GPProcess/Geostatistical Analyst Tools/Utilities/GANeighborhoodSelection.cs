using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Neighborhood Selection</para>
	/// <para>邻域选择</para>
	/// <para>基于用户定义的邻域创建点图层。</para>
	/// </summary>
	public class GANeighborhoodSelection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input point features</para>
		/// <para>用于创建邻域选择的点。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output layer</para>
		/// <para>存储邻域选择的图层。</para>
		/// </param>
		/// <param name="PointCoord">
		/// <para>Input point</para>
		/// <para>邻域中心的 x,y 坐标。</para>
		/// </param>
		/// <param name="NeighborsMax">
		/// <para>Maximum neighbors to include</para>
		/// <para>每个扇区中所要使用的点数。如果某个扇区具有所需点数，则使用该扇区中的所有点。</para>
		/// </param>
		/// <param name="NeighborsMin">
		/// <para>Include at least</para>
		/// <para>每个扇区中所要使用的最小点数。如果任何指定扇区中的点数都没有达到所需的最小值，则会选择扇区之外最近的可用点。</para>
		/// </param>
		/// <param name="MinorSemiaxis">
		/// <para>Minor semiaxis</para>
		/// <para>搜索邻域短半轴的尺寸。</para>
		/// </param>
		/// <param name="MajorSemiaxis">
		/// <para>Major semiaxis</para>
		/// <para>搜索邻域长半轴的尺寸。</para>
		/// </param>
		/// <param name="Angle">
		/// <para>Angle</para>
		/// <para>邻域轴的旋转角度。</para>
		/// </param>
		public GANeighborhoodSelection(object InDataset, object OutLayer, object PointCoord, object NeighborsMax, object NeighborsMin, object MinorSemiaxis, object MajorSemiaxis, object Angle)
		{
			this.InDataset = InDataset;
			this.OutLayer = OutLayer;
			this.PointCoord = PointCoord;
			this.NeighborsMax = NeighborsMax;
			this.NeighborsMin = NeighborsMin;
			this.MinorSemiaxis = MinorSemiaxis;
			this.MajorSemiaxis = MajorSemiaxis;
			this.Angle = Angle;
		}

		/// <summary>
		/// <para>Tool Display Name : 邻域选择</para>
		/// </summary>
		public override string DisplayName() => "邻域选择";

		/// <summary>
		/// <para>Tool Name : GANeighborhoodSelection</para>
		/// </summary>
		public override string ToolName() => "GANeighborhoodSelection";

		/// <summary>
		/// <para>Tool Excute Name : ga.GANeighborhoodSelection</para>
		/// </summary>
		public override string ExcuteName() => "ga.GANeighborhoodSelection";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutLayer, PointCoord, NeighborsMax, NeighborsMin, MinorSemiaxis, MajorSemiaxis, Angle, ShapeType };

		/// <summary>
		/// <para>Input point features</para>
		/// <para>用于创建邻域选择的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output layer</para>
		/// <para>存储邻域选择的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Input point</para>
		/// <para>邻域中心的 x,y 坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object PointCoord { get; set; }

		/// <summary>
		/// <para>Maximum neighbors to include</para>
		/// <para>每个扇区中所要使用的点数。如果某个扇区具有所需点数，则使用该扇区中的所有点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		public object NeighborsMax { get; set; }

		/// <summary>
		/// <para>Include at least</para>
		/// <para>每个扇区中所要使用的最小点数。如果任何指定扇区中的点数都没有达到所需的最小值，则会选择扇区之外最近的可用点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 2147483647)]
		public object NeighborsMin { get; set; }

		/// <summary>
		/// <para>Minor semiaxis</para>
		/// <para>搜索邻域短半轴的尺寸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 1.7976931348623157e+308)]
		public object MinorSemiaxis { get; set; }

		/// <summary>
		/// <para>Major semiaxis</para>
		/// <para>搜索邻域长半轴的尺寸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2250738585072014e-308, Max = 1.7976931348623157e+308)]
		public object MajorSemiaxis { get; set; }

		/// <summary>
		/// <para>Angle</para>
		/// <para>邻域轴的旋转角度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 360)]
		public object Angle { get; set; }

		/// <summary>
		/// <para>Shape type</para>
		/// <para>邻域的几何。</para>
		/// <para>一个扇区— 单个椭圆</para>
		/// <para>四个扇区— 分为四个扇区的椭圆</para>
		/// <para>偏移四个扇区— 分为四个扇区且偏移 45 度的椭圆</para>
		/// <para>八个扇区— 分为八个扇区的椭圆</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeType { get; set; } = "ONE_SECTOR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GANeighborhoodSelection SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>一个扇区— 单个椭圆</para>
			/// </summary>
			[GPValue("ONE_SECTOR")]
			[Description("一个扇区")]
			One_sector,

			/// <summary>
			/// <para>四个扇区— 分为四个扇区的椭圆</para>
			/// </summary>
			[GPValue("FOUR_SECTORS")]
			[Description("四个扇区")]
			Four_sectors,

			/// <summary>
			/// <para>偏移四个扇区— 分为四个扇区且偏移 45 度的椭圆</para>
			/// </summary>
			[GPValue("FOUR_SECTORS_SHIFTED")]
			[Description("偏移四个扇区")]
			Four_shifted_sectors,

			/// <summary>
			/// <para>八个扇区— 分为八个扇区的椭圆</para>
			/// </summary>
			[GPValue("EIGHT_SECTORS")]
			[Description("八个扇区")]
			Eight_sectors,

		}

#endregion
	}
}
