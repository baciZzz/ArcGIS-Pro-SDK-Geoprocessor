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
	/// <para>Create Viewshed</para>
	/// <para>创建视域</para>
	/// <para>创建能够查看地面上对象的观察点区域。输入观察点可以表示观察点（例如地面上的人或火警瞭望塔上的人）或被观察的对象（例如，风力涡轮机、水塔、车辆或其他人）。</para>
	/// </summary>
	public class CreateViewshed : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputelevationsurface">
		/// <para>Input Elevation Surface</para>
		/// <para>用于计算视域的高程表面。</para>
		/// <para>如果输入表面的垂直单位与水平单位存在差异（例如，高程值用英尺表示，但坐标系用米表示），则该表面必须具有确定的垂直坐标系。其原因在于，工具将使用垂直 (Z) 和水平 (XY) 单位来计算视域分析所需的 z 因子。没有了垂直坐标系，也就没有了可用的 Z 单位信息，此时工具将假定 Z 单位与 XY 单位相同。结果导致分析中将使用内部 Z 因子 1.0，从而导致意外的结果。</para>
		/// <para>高程表面可为整型或浮点型。</para>
		/// </param>
		/// <param name="Inputobserverfeatures">
		/// <para>Observer Features</para>
		/// <para>计算视域时表示观察者位置的点要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public CreateViewshed(object Inputelevationsurface, object Inputobserverfeatures, object Outputname)
		{
			this.Inputelevationsurface = Inputelevationsurface;
			this.Inputobserverfeatures = Inputobserverfeatures;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建视域</para>
		/// </summary>
		public override string DisplayName() => "创建视域";

		/// <summary>
		/// <para>Tool Name : CreateViewshed</para>
		/// </summary>
		public override string ToolName() => "CreateViewshed";

		/// <summary>
		/// <para>Tool Excute Name : ra.CreateViewshed</para>
		/// </summary>
		public override string ExcuteName() => "ra.CreateViewshed";

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
		public override object[] Parameters() => new object[] { Inputelevationsurface, Inputobserverfeatures, Outputname, Optimizefor, Maximumviewingdistancetype, Maximumviewingdistance, Maximumviewingdistancefield, Minimumviewingdistancetype, Minimumviewingdistance, Minimumviewingdistancefield, Viewingdistanceis3d, Observerselevationtype, Observerselevation, Observerselevationfield, Observersheighttype, Observersheight, Observersheightfield, Targetheighttype, Targetheight, Targetheightfield, Abovegroundleveloutputname, Outputraster, Outputabovegroundlevelraster };

		/// <summary>
		/// <para>Input Elevation Surface</para>
		/// <para>用于计算视域的高程表面。</para>
		/// <para>如果输入表面的垂直单位与水平单位存在差异（例如，高程值用英尺表示，但坐标系用米表示），则该表面必须具有确定的垂直坐标系。其原因在于，工具将使用垂直 (Z) 和水平 (XY) 单位来计算视域分析所需的 z 因子。没有了垂直坐标系，也就没有了可用的 Z 单位信息，此时工具将假定 Z 单位与 XY 单位相同。结果导致分析中将使用内部 Z 因子 1.0，从而导致意外的结果。</para>
		/// <para>高程表面可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputelevationsurface { get; set; }

		/// <summary>
		/// <para>Observer Features</para>
		/// <para>计算视域时表示观察者位置的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline")]
		[FeatureType("Simple")]
		public object Inputobserverfeatures { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Optimize For</para>
		/// <para>用于计算视域的优化方法。</para>
		/// <para>速度—此方法可优化处理速度，牺牲一些精度以获得更高的性能。这是默认设置。</para>
		/// <para>精度—此方法可用来优化结果的精度，代价是需要更长的处理时间。</para>
		/// <para><see cref="OptimizeforEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Optimizefor { get; set; } = "SPEED";

		/// <summary>
		/// <para>Maximum Viewing Distance Type</para>
		/// <para>选择用于确定最大可视距离的方法。</para>
		/// <para>距离—最大距离由指定值定义。这是默认方法。</para>
		/// <para>字段— 各观察点位置的最大距离由指定字段中的值来决定。</para>
		/// <para>如果将类型由“距离”更改为“字段”，则最大可视距离参数将更改为最大可视距离字段。</para>
		/// <para><see cref="MaximumviewingdistancetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Maximumviewingdistancetype { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Maximum Viewing Distance</para>
		/// <para>这就是停止计算可见区域的中断距离。超出此距离，就无法确定观察点和其他对象互相能否看见。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位为英里。</para>
		/// <para><see cref="MaximumviewingdistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Maximumviewingdistance { get; set; } = "9 Miles";

		/// <summary>
		/// <para>Maximum Viewing Distance Field</para>
		/// <para>您可以用此字段指定每个观察点的最大可视距离。字段中包含的值的单位必须与输入高程表面的 XY 单位相同。</para>
		/// <para>最大可视距离是停止计算可见区域的中断距离。超出此距离，就无法确定观察点和其他对象互相能否看见。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Maximumviewingdistancefield { get; set; }

		/// <summary>
		/// <para>Minimum Viewing Distance Type</para>
		/// <para>选择用于确定最小可视距离的方法。</para>
		/// <para>距离—最小距离由您指定的值定义。这是默认方法。</para>
		/// <para>字段— 各观察点位置的最小距离由指定字段中的值来决定。</para>
		/// <para>如果将类型由“距离”更改为“字段”，则最小可视距离参数将更改为最小可视距离字段。</para>
		/// <para><see cref="MinimumviewingdistancetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Minimumviewingdistancetype { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Minimum Viewing Distance</para>
		/// <para>这就是开始计算可见区域的距离。表面上小于此距离的像元在输出中不可见，但仍会妨碍最小可视距离和最大可视距离之间像元的可见性。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位是米。</para>
		/// <para><see cref="MinimumviewingdistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Minimumviewingdistance { get; set; }

		/// <summary>
		/// <para>Minimum Viewing Distance Field</para>
		/// <para>您可以用此字段指定每个观察点的最小可视距离。字段中包含的值的单位必须与输入高程表面的 XY 单位相同。</para>
		/// <para>最小可视距离定义计算可见区域的起始点。表面上小于此距离的像元在输出中不可见，但仍会妨碍最小可视距离和最大可视距离之间像元的可见性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Minimumviewingdistancefield { get; set; }

		/// <summary>
		/// <para>Viewing Distance is 3D</para>
		/// <para>指定最小可视距离和最大可视距离参数是采用三维方式还是更简单的二维方式进行测量。2D 距离是观察者和目标之间最简单的线性距离，通过两者在海平面上的投影位置测得。3D 距离可将两者的相关高度纳入考量范围，从而能够得出更为真实的值。</para>
		/// <para>选中 - 可视距离在 3D 距离中测得。</para>
		/// <para>未选中 - 可视距离在 2D 距离中测得。这是默认设置。</para>
		/// <para><see cref="Viewingdistanceis3dEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Viewingdistanceis3d { get; set; } = "false";

		/// <summary>
		/// <para>Observers Elevation Type</para>
		/// <para>选择用于确定观察点高程的方法。</para>
		/// <para>高程—观察点高程由指定的值定义。这是默认方法。</para>
		/// <para>字段—每个观察点位置的高程由指定字段中的值来确定。</para>
		/// <para>如果将类型由“高程”更改为“字段”，则观察点高程参数将更改为观察点高程字段。</para>
		/// <para><see cref="ObserverselevationtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Observerselevationtype { get; set; } = "ELEVATION";

		/// <summary>
		/// <para>Observers Elevation</para>
		/// <para>这是观察点位置的高程。</para>
		/// <para>如果未指定此参数，则会使用双线性插值法从表面栅格中获取观察点高程。如果为此参数设置了一个值，则该值将应用到所有观察点。要为每个观察点指定不同的值，请将此参数设置为输入观察点要素中的某个字段。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位是米。</para>
		/// <para><see cref="ObserverselevationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Observerselevation { get; set; }

		/// <summary>
		/// <para>Observers Elevation Field</para>
		/// <para>您可以用此字段指定观察点高程。字段中包含的值的单位必须与输入高程表面的 Z 单位相同。</para>
		/// <para>如果未指定此参数，则会使用双线性插值法从表面栅格中获取观察点高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Observerselevationfield { get; set; }

		/// <summary>
		/// <para>Observers Height Type</para>
		/// <para>选择用于确定观察点高度的方法。</para>
		/// <para>高度—观察点高度通过指定的值获得。这是默认方法。</para>
		/// <para>字段— 每个观察点位置的高度由指定字段中的值来确定。</para>
		/// <para>如果将类型由“高度”更改为“字段”，则观察点高度参数将更改为观察点高度字段。</para>
		/// <para><see cref="ObserversheighttypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Observersheighttype { get; set; } = "HEIGHT";

		/// <summary>
		/// <para>Observers Height</para>
		/// <para>这是用于观察点位置的高度。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位是米。</para>
		/// <para><see cref="ObserversheightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Observersheight { get; set; } = "6 Feet";

		/// <summary>
		/// <para>Observers Height Field</para>
		/// <para>您可以用此字段指定观察点高度。字段中包含的值的单位必须与输入高程表面的 Z 单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Observersheightfield { get; set; }

		/// <summary>
		/// <para>Target Height Type</para>
		/// <para>选择用于确定目标高度的方法。</para>
		/// <para>高度—目标高度通过指定的值获得。这是默认方法。</para>
		/// <para>字段— 每个目标的高度由指定字段中的值来确定。</para>
		/// <para>如果将类型由“高度”更改为“字段”，则目标高度参数将更改为目标高度字段。</para>
		/// <para><see cref="TargetheighttypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Targetheighttype { get; set; } = "HEIGHT";

		/// <summary>
		/// <para>Target Height</para>
		/// <para>这是地面上建筑物或人的高度，用于确立可见性。结果视域为观察点可看到这些其他对象的区域。反之亦然，其他对象也可以看到观察点。</para>
		/// <para>单位可以是千米、米、英里、码或英尺。</para>
		/// <para>默认单位是米。</para>
		/// <para><see cref="TargetheightEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Targetheight { get; set; }

		/// <summary>
		/// <para>Target Height Field</para>
		/// <para>您可以用此字段指定目标高度。字段中包含的值的单位必须与输入高程表面的 Z 单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "OID")]
		public object Targetheightfield { get; set; }

		/// <summary>
		/// <para>Above Ground Level Output Name</para>
		/// <para>地平面以上 (AGL) 栅格输出结果的名称。AGL 结果是一个栅格，其中每个像元值都记录了为保证像元至少对一个观察点可见而需要向该像元添加的最小高度（若不添加此高度，像元不可见）。在此输出栅格中为已可见的像元分配 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Abovegroundleveloutputname { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Output Above Ground Level Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputabovegroundlevelraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateViewshed SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Optimize For</para>
		/// </summary>
		public enum OptimizeforEnum 
		{
			/// <summary>
			/// <para>速度—此方法可优化处理速度，牺牲一些精度以获得更高的性能。这是默认设置。</para>
			/// </summary>
			[GPValue("SPEED")]
			[Description("速度")]
			Speed,

			/// <summary>
			/// <para>精度—此方法可用来优化结果的精度，代价是需要更长的处理时间。</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("精度")]
			Accuracy,

		}

		/// <summary>
		/// <para>Maximum Viewing Distance Type</para>
		/// </summary>
		public enum MaximumviewingdistancetypeEnum 
		{
			/// <summary>
			/// <para>距离—最大距离由指定值定义。这是默认方法。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离")]
			Distance,

			/// <summary>
			/// <para>字段— 各观察点位置的最大距离由指定字段中的值来决定。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

		}

		/// <summary>
		/// <para>Maximum Viewing Distance</para>
		/// </summary>
		public enum MaximumviewingdistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Minimum Viewing Distance Type</para>
		/// </summary>
		public enum MinimumviewingdistancetypeEnum 
		{
			/// <summary>
			/// <para>距离—最小距离由您指定的值定义。这是默认方法。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离")]
			Distance,

			/// <summary>
			/// <para>字段— 各观察点位置的最小距离由指定字段中的值来决定。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

		}

		/// <summary>
		/// <para>Minimum Viewing Distance</para>
		/// </summary>
		public enum MinimumviewingdistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Viewing Distance is 3D</para>
		/// </summary>
		public enum Viewingdistanceis3dEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("3D")]
			_3D,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("2D")]
			_2D,

		}

		/// <summary>
		/// <para>Observers Elevation Type</para>
		/// </summary>
		public enum ObserverselevationtypeEnum 
		{
			/// <summary>
			/// <para>高程—观察点高程由指定的值定义。这是默认方法。</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("高程")]
			Elevation,

			/// <summary>
			/// <para>字段—每个观察点位置的高程由指定字段中的值来确定。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

		}

		/// <summary>
		/// <para>Observers Elevation</para>
		/// </summary>
		public enum ObserverselevationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Observers Height Type</para>
		/// </summary>
		public enum ObserversheighttypeEnum 
		{
			/// <summary>
			/// <para>高度—观察点高度通过指定的值获得。这是默认方法。</para>
			/// </summary>
			[GPValue("HEIGHT")]
			[Description("高度")]
			Height,

			/// <summary>
			/// <para>字段— 每个观察点位置的高度由指定字段中的值来确定。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

		}

		/// <summary>
		/// <para>Observers Height</para>
		/// </summary>
		public enum ObserversheightEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Target Height Type</para>
		/// </summary>
		public enum TargetheighttypeEnum 
		{
			/// <summary>
			/// <para>高度—目标高度通过指定的值获得。这是默认方法。</para>
			/// </summary>
			[GPValue("HEIGHT")]
			[Description("高度")]
			Height,

			/// <summary>
			/// <para>字段— 每个目标的高度由指定字段中的值来确定。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

		}

		/// <summary>
		/// <para>Target Height</para>
		/// </summary>
		public enum TargetheightEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

#endregion
	}
}
