using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Spatial Join</para>
	/// <para>空间连接</para>
	/// <para>根据空间关系将一个要素的属性连接到另一个要素。 目标要素和来自连接要素的被连接属性写入到输出要素类。</para>
	/// </summary>
	public class SpatialJoin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>目标要素的属性和已连接要素的属性将传递到输出要素类。 但是，可以在字段映射参数中定义属性的子集。</para>
		/// </param>
		/// <param name="JoinFeatures">
		/// <para>Join Features</para>
		/// <para>连接要素的属性将被连接到目标要素的属性中。 有关连接操作的类型对所连接属性聚合的影响的详细信息，请参阅连接操作参数的说明。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>此新要素类包含目标要素和连接要素的属性。 默认情况下，目标要素的所有属性和连接要素的属性将写入输出。 但是，可通过字段映射参数来控制要传递的属性集。</para>
		/// </param>
		public SpatialJoin(object TargetFeatures, object JoinFeatures, object OutFeatureClass)
		{
			this.TargetFeatures = TargetFeatures;
			this.JoinFeatures = JoinFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 空间连接</para>
		/// </summary>
		public override string DisplayName() => "空间连接";

		/// <summary>
		/// <para>Tool Name : SpatialJoin</para>
		/// </summary>
		public override string ToolName() => "SpatialJoin";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SpatialJoin</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SpatialJoin";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "configKeyword", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatures, JoinFeatures, OutFeatureClass, JoinOperation!, JoinType!, FieldMapping!, MatchOption!, SearchRadius!, DistanceFieldName! };

		/// <summary>
		/// <para>Target Features</para>
		/// <para>目标要素的属性和已连接要素的属性将传递到输出要素类。 但是，可以在字段映射参数中定义属性的子集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Join Features</para>
		/// <para>连接要素的属性将被连接到目标要素的属性中。 有关连接操作的类型对所连接属性聚合的影响的详细信息，请参阅连接操作参数的说明。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		public object JoinFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>此新要素类包含目标要素和连接要素的属性。 默认情况下，目标要素的所有属性和连接要素的属性将写入输出。 但是，可通过字段映射参数来控制要传递的属性集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Join Operation</para>
		/// <para>如果发现多个连接要素与单个目标要素具有相同的空间关系，此操作将在输出要素类中连接目标要素类和连接要素。</para>
		/// <para>一对一连接—如果发现多个连接要素与单一目标要素具有相同的空间关系，则将按照字段映射合并规则聚合来自多个连接要素的属性。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，将对这两个面的属性进行聚合，然后将其传递到输出点要素类。 如果一个面要素的属性值为 3，另一个面要素的属性值为 7，且指定了“总和”合并规则，则输出要素类中的聚合值将为 10。 这是默认设置。</para>
		/// <para>一对多连接—如果发现多个连接要素与单一目标要素具有相同的空间关系，则输出要素类将包含目标要素的多个副本（记录）。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，则输出要素类将包含目标要素的两个副本：分别包含两个面的属性记录。</para>
		/// <para><see cref="JoinOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? JoinOperation { get; set; } = "JOIN_ONE_TO_ONE";

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// <para>指定是在输出要素类中保留所有目标要素（称为外部连接），还是仅保留那些与连接要素有指定空间关系的目标要素（称为内部连接）。</para>
		/// <para>选中 - 在输出中保留所有目标要素（外部连接）。 这是默认设置。</para>
		/// <para>未选中 - 在输出要素类中仅保留那些与连接要素有指定空间关系的目标要素（内部连接）。 例如，如果将某个点要素类指定为目标要素，将某个面要素类指定为连接要素，并选择范围内作为匹配选项值，则输出要素类将仅包含那些位于面连接要素内部的目标要素。 不在连接要素内的所有目标要素将从输出中排除。</para>
		/// <para><see cref="JoinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? JoinType { get; set; } = "true";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>输出中将包括的具有相应字段属性和源字段的属性字段。 默认情况下，将包括输入的所有字段。</para>
		/// <para>可以添加、删除、重命名和重新排序字段，且可以更改其属性。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。 有多种合并规则可用于确定如何用值填充输出字段。</para>
		/// <para>First - 使用输入字段的第一个值。</para>
		/// <para>Last - 使用输入字段的最后一个值。</para>
		/// <para>Join - 串连（连接）输入字段的值。</para>
		/// <para>Sum - 计算输入字段值的总和。</para>
		/// <para>Mean - 计算输入字段值的平均值。</para>
		/// <para>Median - 计算输入字段值的中值。</para>
		/// <para>Mode - 使用具有最高频率的值。</para>
		/// <para>Min - 使用所有输入字段值中的最小值。</para>
		/// <para>Max - 使用所有输入字段值中的最大值。</para>
		/// <para>Standard deviation - 对所有输入字段值使用标准差分类方法。</para>
		/// <para>Count - 查找计算中所包含的记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		[Category("Fields")]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Match Option</para>
		/// <para>指定用于匹配行的条件。</para>
		/// <para>相交—如果连接要素与目标要素相交，将匹配连接要素中相交的要素。这是默认设置。在搜索半径参数中指定距离。</para>
		/// <para>3D 相交— 如果连接要素中的要素与三维空间（x、y 和 z）中的某一目标要素相交，则将匹配这些要素。在搜索半径参数中指定距离。</para>
		/// <para>在某一距离范围内—如果连接要素在目标要素的指定距离之内，将匹配处于该距离内的要素。在搜索半径参数中指定距离。</para>
		/// <para>在某一测地线距离范围内—与在某一距离范围内相同，不同之处在于采用测地线距离而非平面距离。如果您的数据涵盖较大地理范围或输入的坐标系不适合进行距离计算，请选择此项。</para>
		/// <para>在某一 3D 距离范围内—在三维空间内，如果连接要素中的要素与目标要素间的距离在指定范围内，则匹配这些要素。在搜索半径参数中指定距离。</para>
		/// <para>包含—如果目标要素中包含连接要素中的要素，将匹配连接要素中被包含的要素。目标要素必须是面或折线。对于此选项，目标要素不能为点，且仅当目标要素为面时连接要素才能为面。</para>
		/// <para>完全包含—如果目标要素完全包含连接要素中的要素，将匹配连接要素中被包含的要素。面可以完全包含任意要素。点不能完全包含任何要素，甚至不能包含点。折线只能完全包含折线和点。</para>
		/// <para>包含 (Clementini)—该空间关系产生的结果与完全包含相同，但有一种情况例外：如果连接要素完全位于目标要素的边界上（没有任何一部分完全位于内部或外部），则不会匹配要素。Clementini 将边界面定义为用来分隔内部和外部的线，将线的边界定义为其端点，点的边界始终为空。</para>
		/// <para>位于—如果目标要素位于连接要素内，将匹配连接要素中包含目标要素的要素。它与包含相反。对于此选项，只有当连接要素也为面时目标要素才可为面。只有当点为目标要素时连接要素才能为点。</para>
		/// <para>完全在其他要素范围内—如果目标要素完全在连接要素范围内，则匹配连接要素中完全包含目标要素的要素。这与完全包含相反。</para>
		/// <para>包含于 (Clementini)—结果与范围内相同，但下述情况例外：如果连接要素中的全部要素均位于目标要素的边界上，则不会匹配要素。Clementini 将边界面定义为用来分隔内部和外部的线，将线的边界定义为其端点，点的边界始终为空。</para>
		/// <para>与其他要素相同—如果连接要素与目标要素相同，将匹配连接要素中相同的要素。连接要素和目标要素必须具有相同的形状类型 - 点到点、线到线和面到面。</para>
		/// <para>边界接触—如果连接要素中具有边界与目标要素相接的要素，将匹配这些要素。如果目标和连接要素为线或面，则连接要素的边界只可接触目标要素的边界，且连接要素的任何部分均不可跨越目标要素的边界。</para>
		/// <para>与其他要素共线—如果连接要素中具有与目标要素共线的要素，将匹配这些要素。连接要素和目标要素必须是线或面。</para>
		/// <para>与轮廓交叉—如果连接要素中具有轮廓与目标要素交叉的要素，则将匹配这些要素。连接要素和目标要素必须是线或面。如果将面用于连接或目标要素，则会使用面的边界（线）。将匹配在某一点交叉的线，而不是共线的线。</para>
		/// <para>中心在要素范围内—如果目标要素的中心位于连接要素内，将匹配这些要素。要素中心的计算方式如下：对于面和多点，将使用几何的质心；对于线输入，则会使用几何的中点。在搜索半径参数中指定距离。</para>
		/// <para>最近—匹配连接要素中与目标要素最近的要素。有关详细信息，请参阅使用提示。在搜索半径参数中指定距离。</para>
		/// <para>最近测地线—与最近相同，不同之处在于采用测地线距离而非平面距离。如果您的数据涵盖较大地理范围或输入的坐标系不适合进行距离计算，请选择此项</para>
		/// <para>最大重叠—连接要素中的要素将与具有最大重叠的目标要素进行匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MatchOption { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>如果连接要素与目标要素的距离在此范围内，则有可能进行空间连接。 仅当指定空间关系时，搜索半径才有效（匹配选项参数设置为相交、在某一距离范围内、在某一测地线距离范围内、质心在以下图层中的要素内、最近或最近测地线）。 例如，当搜索半径设置为 100 米且使用在某一距离范围内空间关系时，将会连接距离目标要素 100 米以内的要素。 对于三种在某一距离范围内关系，如果未指定搜索半径的值，则距离将为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; }

		/// <summary>
		/// <para>Distance Field Name</para>
		/// <para>包含目标要素与最近连接要素间距的字段的名称。 此字段将添加至输出要素类。 仅当指定空间关系（匹配选项设置为最近或最近测地线）时，此参数才有效。 如果搜索半径中没有匹配的要素，则此字段的值为 -1。 如果未指定字段名称，将不会向输出要素类中添加该字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DistanceFieldName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialJoin SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? configKeyword = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Join Operation</para>
		/// </summary>
		public enum JoinOperationEnum 
		{
			/// <summary>
			/// <para>一对一连接—如果发现多个连接要素与单一目标要素具有相同的空间关系，则将按照字段映射合并规则聚合来自多个连接要素的属性。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，将对这两个面的属性进行聚合，然后将其传递到输出点要素类。 如果一个面要素的属性值为 3，另一个面要素的属性值为 7，且指定了“总和”合并规则，则输出要素类中的聚合值将为 10。 这是默认设置。</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_ONE")]
			[Description("一对一连接")]
			Join_one_to_one,

			/// <summary>
			/// <para>一对多连接—如果发现多个连接要素与单一目标要素具有相同的空间关系，则输出要素类将包含目标要素的多个副本（记录）。 例如，如果在两个独立的面连接要素中找到了同一个点目标要素，则输出要素类将包含目标要素的两个副本：分别包含两个面的属性记录。</para>
			/// </summary>
			[GPValue("JOIN_ONE_TO_MANY")]
			[Description("一对多连接")]
			Join_one_to_many,

		}

		/// <summary>
		/// <para>Keep All Target Features</para>
		/// </summary>
		public enum JoinTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_COMMON")]
			KEEP_COMMON,

		}

#endregion
	}
}
