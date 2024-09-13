using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Calculate Density</para>
	/// <para>计算密度</para>
	/// <para>通过在地图范围内扩展某一现象（表示为点或线的属性）的已知量，根据点要素或线要素创建密度图。 结果是按密度从小到大分类的面图层。</para>
	/// </summary>
	public class CalculateDensity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputpointorlinefeatures">
		/// <para>Input Point or Line Features</para>
		/// <para>将用于计算密度栅格的输入点或线要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public CalculateDensity(object Inputpointorlinefeatures, object Outputname)
		{
			this.Inputpointorlinefeatures = Inputpointorlinefeatures;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算密度</para>
		/// </summary>
		public override string DisplayName() => "计算密度";

		/// <summary>
		/// <para>Tool Name : CalculateDensity</para>
		/// </summary>
		public override string ToolName() => "CalculateDensity";

		/// <summary>
		/// <para>Tool Excute Name : ra.CalculateDensity</para>
		/// </summary>
		public override string ExcuteName() => "ra.CalculateDensity";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputpointorlinefeatures, Outputname, Countfield!, Searchdistance!, Outputareaunits!, Outputcellsize!, Outputraster!, Inbarriers! };

		/// <summary>
		/// <para>Input Point or Line Features</para>
		/// <para>将用于计算密度栅格的输入点或线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object Inputpointorlinefeatures { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。 如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Count Field</para>
		/// <para>此字段用于指示每个位置处的事件点数量。 例如，如果正在创建人口密度栅格且输入点为城市，则为计数字段使用城市人口最为合适，以便人口较多的城市对密度计算产生更大的影响。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? Countfield { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>搜索距离和距离单位。 计算像元的密度时，该距离内的所有要素都将用于该像元的密度计算。</para>
		/// <para>单位可以是千米、米、英里或英尺。</para>
		/// <para>默认单位是米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Searchdistance { get; set; }

		/// <summary>
		/// <para>Output Area Units</para>
		/// <para>指定将用于计算面积的单位。 密度等于计数除以面积，此参数用于设置密度计算中的面积单位。</para>
		/// <para>平方米—计算每平方米的密度。 这是默认设置。</para>
		/// <para>平方千米—计算每平方千米的密度。</para>
		/// <para>平方英尺—计算每平方英尺的密度。</para>
		/// <para>平方英里—计算每平方英里的密度。</para>
		/// <para><see cref="OutputareaunitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Outputareaunits { get; set; }

		/// <summary>
		/// <para>Output Cell Size</para>
		/// <para>输出栅格的像元大小和单位。</para>
		/// <para>单位可以是千米、米、英里或英尺。</para>
		/// <para>默认单位是米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? Outputcellsize { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Input Barrier Features</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>障碍可以是折线或面要素的要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object? Inbarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateDensity SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Area Units</para>
		/// </summary>
		public enum OutputareaunitsEnum 
		{
			/// <summary>
			/// <para>平方米—计算每平方米的密度。 这是默认设置。</para>
			/// </summary>
			[GPValue("Square Meters")]
			[Description("平方米")]
			Square_Meters,

			/// <summary>
			/// <para>平方千米—计算每平方千米的密度。</para>
			/// </summary>
			[GPValue("Square Kilometers")]
			[Description("平方千米")]
			Square_Kilometers,

			/// <summary>
			/// <para>平方英尺—计算每平方英尺的密度。</para>
			/// </summary>
			[GPValue("Square Feet")]
			[Description("平方英尺")]
			Square_Feet,

			/// <summary>
			/// <para>平方英里—计算每平方英里的密度。</para>
			/// </summary>
			[GPValue("Square Miles")]
			[Description("平方英里")]
			Square_Miles,

		}

#endregion
	}
}
