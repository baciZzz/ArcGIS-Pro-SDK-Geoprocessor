using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Import Parcel Fabric Points</para>
	/// <para>导入宗地结构点</para>
	/// <para>将源点要素类中的点数据导入到宗地结构点要素类中。 匹配或处于源点的邻近容差范围内的宗地结构点将使用导入的点数据进行更新。 如果源点图层具有选定内容，则仅会导入选定的点信息。</para>
	/// </summary>
	public class ImportParcelFabricPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourcePoints">
		/// <para>Source Points</para>
		/// <para>此源点要素类将用于创建或更新目标宗地结构中的点。</para>
		/// </param>
		/// <param name="TargetParcelFabric">
		/// <para>Target Parcel Fabric</para>
		/// <para>将更新或创建其中的点的目标宗地结构。 目标宗地结构可来自文件地理数据库、连接到默认版本的企业级地理数据库、移动地理数据库或要素服务。</para>
		/// </param>
		/// <param name="MatchPointMethod">
		/// <para>Match Point Method</para>
		/// <para>指定将用于查找与源点匹配的现有宗地结构点的方法。</para>
		/// <para>邻近分析—处于源点的邻近容差范围内的宗地结构点将与源点匹配并更新。 这是默认设置。</para>
		/// <para>名称与邻近性—处于源点的邻近容差范围内且与源点名称相同的宗地结构点将与源点匹配并更新。</para>
		/// <para>全局 ID 与邻近性—处于源点的邻近容差范围内且与源点的全局 ID 相同的宗地结构点将与源点匹配并更新。 全局 ID 存储在宗地结构点要素类上的 Global ID 字段中，以及源要素类的指定 Global ID 字段中。</para>
		/// <para><see cref="MatchPointMethodEnum"/></para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>将用于搜索处于源点附近的宗地结构点的距离。</para>
		/// </param>
		/// <param name="UpdateType">
		/// <para>Update Type</para>
		/// <para>指定将应用于与源点匹配的宗地结构点的更新类型。</para>
		/// <para>全部—将更新宗地结构点的几何 (x,y,z) 和匹配属性字段。 如果更新了宗地结构点的几何，则重合宗地要素也会更新。 这是默认设置。</para>
		/// <para>几何 (x,y,z)—仅会更新宗地结构点的几何 (x,y,z)。 重合宗地要素也将更新。</para>
		/// <para>停用并替换—源点将作为新的宗地结构点进行导入。 任何匹配的宗地结构点都将作为历史宗地结构点停用。 每个匹配的宗地结构点的 Retired By Record 字段都将使用记录名称参数中指定的记录的 GlobalID 进行填充。</para>
		/// <para><see cref="UpdateTypeEnum"/></para>
		/// </param>
		public ImportParcelFabricPoints(object SourcePoints, object TargetParcelFabric, object MatchPointMethod, object SearchDistance, object UpdateType)
		{
			this.SourcePoints = SourcePoints;
			this.TargetParcelFabric = TargetParcelFabric;
			this.MatchPointMethod = MatchPointMethod;
			this.SearchDistance = SearchDistance;
			this.UpdateType = UpdateType;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入宗地结构点</para>
		/// </summary>
		public override string DisplayName() => "导入宗地结构点";

		/// <summary>
		/// <para>Tool Name : ImportParcelFabricPoints</para>
		/// </summary>
		public override string ToolName() => "ImportParcelFabricPoints";

		/// <summary>
		/// <para>Tool Excute Name : parcel.ImportParcelFabricPoints</para>
		/// </summary>
		public override string ExcuteName() => "parcel.ImportParcelFabricPoints";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourcePoints, TargetParcelFabric, MatchPointMethod, SearchDistance, UpdateType, UpdatedParcelFabric!, RecordName!, MatchField!, ConflictsTable!, UpdateCreateOption! };

		/// <summary>
		/// <para>Source Points</para>
		/// <para>此源点要素类将用于创建或更新目标宗地结构中的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object SourcePoints { get; set; }

		/// <summary>
		/// <para>Target Parcel Fabric</para>
		/// <para>将更新或创建其中的点的目标宗地结构。 目标宗地结构可来自文件地理数据库、连接到默认版本的企业级地理数据库、移动地理数据库或要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object TargetParcelFabric { get; set; }

		/// <summary>
		/// <para>Match Point Method</para>
		/// <para>指定将用于查找与源点匹配的现有宗地结构点的方法。</para>
		/// <para>邻近分析—处于源点的邻近容差范围内的宗地结构点将与源点匹配并更新。 这是默认设置。</para>
		/// <para>名称与邻近性—处于源点的邻近容差范围内且与源点名称相同的宗地结构点将与源点匹配并更新。</para>
		/// <para>全局 ID 与邻近性—处于源点的邻近容差范围内且与源点的全局 ID 相同的宗地结构点将与源点匹配并更新。 全局 ID 存储在宗地结构点要素类上的 Global ID 字段中，以及源要素类的指定 Global ID 字段中。</para>
		/// <para><see cref="MatchPointMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchPointMethod { get; set; } = "PROXIMITY";

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>将用于搜索处于源点附近的宗地结构点的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "0.1 Meters";

		/// <summary>
		/// <para>Update Type</para>
		/// <para>指定将应用于与源点匹配的宗地结构点的更新类型。</para>
		/// <para>全部—将更新宗地结构点的几何 (x,y,z) 和匹配属性字段。 如果更新了宗地结构点的几何，则重合宗地要素也会更新。 这是默认设置。</para>
		/// <para>几何 (x,y,z)—仅会更新宗地结构点的几何 (x,y,z)。 重合宗地要素也将更新。</para>
		/// <para>停用并替换—源点将作为新的宗地结构点进行导入。 任何匹配的宗地结构点都将作为历史宗地结构点停用。 每个匹配的宗地结构点的 Retired By Record 字段都将使用记录名称参数中指定的记录的 GlobalID 进行填充。</para>
		/// <para><see cref="UpdateTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateType { get; set; } = "ALL";

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPParcelLayer()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Record Name</para>
		/// <para>将与新的导入点关联的记录的名称。</para>
		/// <para>如果记录已存在于目标宗地结构中，则新点将与记录相关联。 如果记录不存在，则将创建一个记录。 如果用新点替换现有点，且将更新类型设置为停用并替换，则可将记录用于停止将点用作历史记录。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RecordName { get; set; }

		/// <summary>
		/// <para>Match Field</para>
		/// <para>将名称与邻近性或全局 ID 与邻近性用于匹配点方法参数时，用于将源点与宗地结构点相匹配的字段。 按名称进行搜索时，源点要素类中的字段应为“文本”类型。 按全局 ID 进行搜索时，源点要素类中的字段应为 GUID 类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "GlobalID", "GUID")]
		public object? MatchField { get; set; }

		/// <summary>
		/// <para>Conflicts Table</para>
		/// <para>将存储冲突的输出表的路径和名称。 如果源点的搜索容差范围内存在多个宗地结构点，则系统将在冲突表中报告源点和宗地结构点的对象 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? ConflictsTable { get; set; }

		/// <summary>
		/// <para>Update And Create Options</para>
		/// <para>指定是更新点、创建点还是两者皆有。</para>
		/// <para>更新匹配点或创建不匹配点—如果使用搜索条件未找到匹配点，则将创建点。 如果使用搜索条件找到了匹配点，则将更新这些点。 这是默认设置。</para>
		/// <para>仅创建不匹配点—仅当使用搜索条件未找到匹配时，才创建点。 如果使用搜索条件找到了匹配点，这些点将保留并且不会创建任何点。</para>
		/// <para>仅更新匹配点—如果使用搜索条件找到了匹配点，则将更新点。 如果未找到匹配点，将不会创建点。</para>
		/// <para><see cref="UpdateCreateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? UpdateCreateOption { get; set; } = "UPDATE_AND_CREATE";

		#region InnerClass

		/// <summary>
		/// <para>Match Point Method</para>
		/// </summary>
		public enum MatchPointMethodEnum 
		{
			/// <summary>
			/// <para>邻近分析—处于源点的邻近容差范围内的宗地结构点将与源点匹配并更新。 这是默认设置。</para>
			/// </summary>
			[GPValue("PROXIMITY")]
			[Description("邻近分析")]
			Proximity,

			/// <summary>
			/// <para>名称与邻近性—处于源点的邻近容差范围内且与源点名称相同的宗地结构点将与源点匹配并更新。</para>
			/// </summary>
			[GPValue("NAME_AND_PROXIMITY")]
			[Description("名称与邻近性")]
			Name_and_proximity,

			/// <summary>
			/// <para>全局 ID 与邻近性—处于源点的邻近容差范围内且与源点的全局 ID 相同的宗地结构点将与源点匹配并更新。 全局 ID 存储在宗地结构点要素类上的 Global ID 字段中，以及源要素类的指定 Global ID 字段中。</para>
			/// </summary>
			[GPValue("GLOBALID_AND_PROXIMITY")]
			[Description("全局 ID 与邻近性")]
			Global_ID_and_proximity,

		}

		/// <summary>
		/// <para>Update Type</para>
		/// </summary>
		public enum UpdateTypeEnum 
		{
			/// <summary>
			/// <para>全部—将更新宗地结构点的几何 (x,y,z) 和匹配属性字段。 如果更新了宗地结构点的几何，则重合宗地要素也会更新。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>几何 (x,y,z)—仅会更新宗地结构点的几何 (x,y,z)。 重合宗地要素也将更新。</para>
			/// </summary>
			[GPValue("GEOMETRY_XYZ")]
			[Description("几何 (x,y,z)")]
			GEOMETRY_XYZ,

			/// <summary>
			/// <para>停用并替换—源点将作为新的宗地结构点进行导入。 任何匹配的宗地结构点都将作为历史宗地结构点停用。 每个匹配的宗地结构点的 Retired By Record 字段都将使用记录名称参数中指定的记录的 GlobalID 进行填充。</para>
			/// </summary>
			[GPValue("RETIRE_AND_REPLACE")]
			[Description("停用并替换")]
			Retire_and_replace,

		}

		/// <summary>
		/// <para>Update And Create Options</para>
		/// </summary>
		public enum UpdateCreateOptionEnum 
		{
			/// <summary>
			/// <para>更新匹配点或创建不匹配点—如果使用搜索条件未找到匹配点，则将创建点。 如果使用搜索条件找到了匹配点，则将更新这些点。 这是默认设置。</para>
			/// </summary>
			[GPValue("UPDATE_AND_CREATE")]
			[Description("更新匹配点或创建不匹配点")]
			Update_matched_and_create_unmatched,

			/// <summary>
			/// <para>仅创建不匹配点—仅当使用搜索条件未找到匹配时，才创建点。 如果使用搜索条件找到了匹配点，这些点将保留并且不会创建任何点。</para>
			/// </summary>
			[GPValue("CREATE_ONLY")]
			[Description("仅创建不匹配点")]
			Only_create_unmatched,

			/// <summary>
			/// <para>仅更新匹配点—如果使用搜索条件找到了匹配点，则将更新点。 如果未找到匹配点，将不会创建点。</para>
			/// </summary>
			[GPValue("UPDATE_ONLY")]
			[Description("仅更新匹配点")]
			Only_update_matched,

		}

#endregion
	}
}
