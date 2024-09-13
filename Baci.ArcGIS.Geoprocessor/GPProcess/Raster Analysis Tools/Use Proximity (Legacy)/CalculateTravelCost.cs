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
	/// <para>Calculate Travel Cost</para>
	/// <para>计算行程成本</para>
	/// <para>考虑表面距离以及水平和垂直成本因素的情况下，计算与最小成本源之间的最小累积成本距离。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.DistanceAllocation))]
	public class CalculateTravelCost : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsourcerasterorfeatures">
		/// <para>Input Source Raster or Features</para>
		/// <para>此图层用于定义计算距离的源。图层可以是栅格或要素。</para>
		/// </param>
		/// <param name="Outputdistancename">
		/// <para>Output Distance Name</para>
		/// <para>输出距离栅格服务的名称。</para>
		/// <para>此成本距离影像服务用于标识每个像元到标识的源位置在成本表面上的最小累积成本距离。</para>
		/// </param>
		public CalculateTravelCost(object Inputsourcerasterorfeatures, object Outputdistancename)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Outputdistancename = Outputdistancename;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算行程成本</para>
		/// </summary>
		public override string DisplayName() => "计算行程成本";

		/// <summary>
		/// <para>Tool Name : CalculateTravelCost</para>
		/// </summary>
		public override string ToolName() => "CalculateTravelCost";

		/// <summary>
		/// <para>Tool Excute Name : ra.CalculateTravelCost</para>
		/// </summary>
		public override string ExcuteName() => "ra.CalculateTravelCost";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputsourcerasterorfeatures, Outputdistancename, Inputcostraster, Inputsurfaceraster, Maximumdistance, Inputhorizontalraster, Horizontalfactor, Inputverticalraster, Verticalfactor, Sourcecostmultiplier, Sourcestartcost, Sourceresistancerate, Sourcecapacity, Sourcetraveldirection, Outputbacklinkname, Outputallocationname, Allocationfield, Outputdistanceraster, Outputbacklinkraster, Outputallocationraster };

		/// <summary>
		/// <para>Input Source Raster or Features</para>
		/// <para>此图层用于定义计算距离的源。图层可以是栅格或要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Distance Name</para>
		/// <para>输出距离栅格服务的名称。</para>
		/// <para>此成本距离影像服务用于标识每个像元到标识的源位置在成本表面上的最小累积成本距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputdistancename { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Input Surface Raster</para>
		/// <para>定义每个像元位置的高程值的栅格。这些值用于计算经过两个像元时所涉及的实际表面距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsurfaceraster { get; set; }

		/// <summary>
		/// <para>Maximum Distance</para>
		/// <para>定义累积成本值不能超过的阈值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Maximumdistance { get; set; }

		/// <summary>
		/// <para>Input Horizontal Raster</para>
		/// <para>定义每个像元的水平方向的栅格。</para>
		/// <para>在栅格上的这些值必须是整数，以北纬 0 度(或朝向屏幕顶部)为起始值，范围为 0 至 360，顺时针增加。平坦区域应赋值为 -1。</para>
		/// <para>每个位置上的值与水平系数结合使用，用来确定在相邻像元之间移动时产生的水平成本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputhorizontalraster { get; set; }

		/// <summary>
		/// <para>Horizontal Factor</para>
		/// <para>水平系数用于定义水平成本系数与水平相对移动角度之间的关系。</para>
		/// <para>有若干个带有修饰属性的系数可供选择，用于标识定义的水平系数图。这些图表用于标识在计算移动到相邻像元的总成本时的水平系数。</para>
		/// <para>在下面的说明中，将使用两个英文首字母缩写词：HF 表示水平系数，用于定义从一个像元移动到下一像元时所遇到的水平阻力；HRMA 表示水平相对移动角度，用于定义像元的水平方向与移动方向之间的角度。</para>
		/// <para>有多种类型的可用水平系数：</para>
		/// <para>二进制 - 指示如果 HRMA 小于交角，则将 HF 设置为与零系数相关联的值；否则为无穷大。</para>
		/// <para>前向 - 只允许建立向前的移动。HRMA 必须大于等于 0 度且小于 90 度 (0 &lt;= HRMA &lt; 90)。如果 HRMA 大于 0 度且小于 45 度，则将像元的 HF 设置为与零系数相关联的值。如果 HRMA 大于等于 45 度，则使用边值修饰属性值。对于 HRMA 等于或大于 90 度的任何情况，均将 HF 设置为无穷大。</para>
		/// <para>线性 - 指定 HF 是 HRMA 的线性函数。</para>
		/// <para>逆线性 - 指定 HF 是 HRMA 的逆线性函数。</para>
		/// <para>默认值为二进制。</para>
		/// <para>水平关键字的特征：</para>
		/// <para>零系数 - 确定 HRMA 为零时要使用的水平系数。该系数可确定任意水平系数函数的 y 截距。</para>
		/// <para>交角 - 定义一个 HRMA 角度，大于该角度时 HF 将被设置为无穷大。</para>
		/// <para>坡度 - 与线性和逆线性水平系数关键字相结合使用，确定直线坡度。坡度被指定为垂直增量与水平增量的比值(例如，45 百分比坡度是 1/45，以 0.02222 的方式输入)。</para>
		/// <para>边值 - 在指定了前向水平系数关键字的情况下，确定 HRMA 大于或等于 45 度且小于 90 度时的 HF。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAHorizontalFactor()]
		public object Horizontalfactor { get; set; } = "BINARY 1 45";

		/// <summary>
		/// <para>Input Vertical Raster</para>
		/// <para>定义每个像元的垂直 (z) 值的栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputverticalraster { get; set; }

		/// <summary>
		/// <para>Vertical Factor</para>
		/// <para>垂直系数用于定义垂直成本系数和垂直相对移动角度 (VRMA) 之间的关系。</para>
		/// <para>有若干个带有修饰属性的系数可供选择，用于标识定义的垂直系数图。这些图表用于标识在计算移动到相邻像元的总成本时的垂直系数。</para>
		/// <para>在下面的说明中，将使用两个英文首字母缩写词：VF 表示垂直系数，用于定义从一个像元移至下一像元时所遇到的垂直阻力；VRMA 表示垂直相对移动角度，用于定义“起始”像元或处理像元与“终止”像元之间的坡度角度。</para>
		/// <para>有多种类型的可用垂直系数：</para>
		/// <para>二进制 - 指定如果 VRMA 大于交角的下限且小于交角的上限，则将 VF 设置为与零系数相关联的值；否则为无穷大。</para>
		/// <para>线性 - 指示 VF 是 VRMA 的线性函数。</para>
		/// <para>对称线性 - 指定无论在 VRMA 正侧还是负侧，VF 均为 VRMA 的线性函数，并且这两个线性函数关于 VF (y) 轴对称。</para>
		/// <para>逆线性 - 指示 VF 是 VRMA 的逆线性函数。</para>
		/// <para>对称逆线性 - 指定无论在 VRMA 正侧还是负侧，VF 均为 VRMA 的逆线性函数，并且这两个线性函数关于 VF (y) 轴对称。</para>
		/// <para>Cos - 将 VF 标识为 VRMA 的余弦函数。</para>
		/// <para>Sec - 将 VF 标识为 VRMA 的正割函数。</para>
		/// <para>Cos-Sec - 指定当 VRMA 为负时，VF 为 VRMA 的余弦函数；当 VRMA 为非负时，VF 为 VRMA 的正割函数。</para>
		/// <para>Sec-Cos - 指定当 VRMA 为负时，VF 为 VRMA 的正割函数；当 VRMA 为非负时，VF 为 VRMA 的余弦函数。</para>
		/// <para>默认值为二进制。</para>
		/// <para>垂直关键字的特征：</para>
		/// <para>零系数 - 确定 VRMA 为零时要使用的垂直系数。该系数可确定指定函数的 y 截距。按照定义，零系数对于任意三角垂直函数(COS、SEC、COS-SEC 或 SEC-COS)都不适用。y 截距由以上函数定义。</para>
		/// <para>交角下限 - 定义一个 VRMA 角度，小于该角度时 VF 将被设置为无穷大。</para>
		/// <para>交角上限 - 定义一个 VRMA 角度，大于该角度时 VF 将被设置为无穷大。</para>
		/// <para>坡度 - 与线性和逆线性垂直系数关键字相结合使用，确定直线坡度。坡度被指定为垂直增量与水平增量的比值(例如，45 百分比坡度是 1/45，以 0.02222 的方式输入)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAVerticalFactor()]
		public object Verticalfactor { get; set; } = "BINARY 1 -30 30";

		/// <summary>
		/// <para>Cost Multiplier</para>
		/// <para>要应用于成本值的乘数。</para>
		/// <para>用于控制源的出行或放大模式。乘数越大，在每个像元间移动的成本将越大。</para>
		/// <para>值必须大于零。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourcecostmultiplier { get; set; }

		/// <summary>
		/// <para>Start Cost</para>
		/// <para>开始计算成本时的起始成本。</para>
		/// <para>适用于与源相关的固定成本规范。成本算法将从通过开始成本设置的值开始，而非从零成本开始。</para>
		/// <para>值必须大于等于零。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourcestartcost { get; set; }

		/// <summary>
		/// <para>Resistance Rate</para>
		/// <para>此参数将模拟累积成本增加时所耗费成本的增加情况。用于为行驶者的疲劳程度建模。利用到达某个像元的累积成本的增长量乘以阻力比率，再加上移动至下一个像元的成本。</para>
		/// <para>这是修改后版本的用于计算移动经过像元的显性成本混合利率公式。随着阻力比率的值增加，之后访问的像元成本也随之增加。阻力比率越大，到达下一个像元需要加的附加成本也越多，将针对每个后续移动进行复合。由于阻力比率与复利率相似且累积成本值通常会很大，因此建议采用较小的阻力比率，如 0.02、0.005 或更小，具体取决于累积成本值。</para>
		/// <para>值必须大于等于零。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourceresistancerate { get; set; }

		/// <summary>
		/// <para>Capacity</para>
		/// <para>定义源的行驶者的成本容量。</para>
		/// <para>每个源的成本计算将在达到指定容量后停止。</para>
		/// <para>值必须大于零。默认容量是到输出栅格边的容量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Source Characteristics")]
		public object Sourcecapacity { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>应用水平和垂直系数、源阻力比率和源开始成本时定义行驶者的方向。</para>
		/// <para>来自源—水平系数、垂直系数、源阻力比率和源开始成本将应用于开始于输入源并移动至非源像元的情况。这是默认设置。</para>
		/// <para>到源—水平系数、垂直系数、源阻力比率和源开始成本将应用于开始于每个非源像元并移动回输入源的情况。</para>
		/// <para>指定将应用于所有源的来自源或到源关键字，或指定包含用于确定各个源行驶方向关键字的源数据字段。该字段必须包含字符串 FROM_SOURCE 或 TO_SOURCE。</para>
		/// <para><see cref="SourcetraveldirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Source Characteristics")]
		public object Sourcetraveldirection { get; set; }

		/// <summary>
		/// <para>Output Backlink Name</para>
		/// <para>输出回溯链接栅格服务的名称。</para>
		/// <para>回溯链接栅格包含从 0 到 360 的值，这些值用于定义从某像元开始沿最小累积成本路径的方向，以达到最小成本源，同时会考虑表面距离以及水平和垂直表面系数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputbacklinkname { get; set; }

		/// <summary>
		/// <para>Output Allocation Name</para>
		/// <para>输出分配栅格服务的名称。</para>
		/// <para>该栅格可识别花费最小累积成本便可到达的每个源位置（像元或要素）的区域。</para>
		/// <para>输出栅格为整型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputallocationname { get; set; }

		/// <summary>
		/// <para>Allocation Field</para>
		/// <para>用于保存定义每个源的值的源输出上的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Allocationfield { get; set; }

		/// <summary>
		/// <para>Output Distance Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputdistanceraster { get; set; }

		/// <summary>
		/// <para>Output Backlink Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputbacklinkraster { get; set; }

		/// <summary>
		/// <para>Output Allocation Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputallocationraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateTravelCost SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum SourcetraveldirectionEnum 
		{
			/// <summary>
			/// <para>来自源—水平系数、垂直系数、源阻力比率和源开始成本将应用于开始于输入源并移动至非源像元的情况。这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_SOURCE")]
			[Description("来自源")]
			From_source,

			/// <summary>
			/// <para>到源—水平系数、垂直系数、源阻力比率和源开始成本将应用于开始于每个非源像元并移动回输入源的情况。</para>
			/// </summary>
			[GPValue("TO_SOURCE")]
			[Description("到源")]
			To_source,

		}

#endregion
	}
}
