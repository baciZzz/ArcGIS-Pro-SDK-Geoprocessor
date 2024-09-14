using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Subset Space Time Cube</para>
	/// <para>子集时空立方体</para>
	/// <para>按空间或时间对时空立方体进行子集。</para>
	/// </summary>
	public class SubsetSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>要子集化的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </param>
		/// <param name="OutCube">
		/// <para>Output Space Time Cube</para>
		/// <para>输入时空立方体的子集，满足空间子集方法和时间子集方法参数指定的空间和时间标准。 存储在输入时空立方体中的分析变量将从输出时空立方体中排除。</para>
		/// </param>
		/// <param name="SpatialSubsetMethod">
		/// <para>Spatial Subset Method</para>
		/// <para>指定将用于对输入时空立方体进行空间子集化的方法。 输入时空立方体中满足此空间子集标准的任何位置都将包含在输出时空立方体中。</para>
		/// <para>要素—具有面、点或线的要素类将用于对输入时空立方体进行子集化。 空间关系参数指定要素图层如何对时空立方体进行子集化。</para>
		/// <para>范围—范围参数指定的范围将用于对输入时空立方体进行子集化。 输出时空立方体将包括输入时空立方体中与范围相交的所有位置。</para>
		/// <para>时空立方体—由输入空间子集立方体参数指定的时空立方体的位置将用于对时空立方体进行子集化。 空间关系参数指定此时空立方体如何将输入时空立方体子集化。</para>
		/// <para>无—空间子集不会应用于输入时空立方体。</para>
		/// <para><see cref="SpatialSubsetMethodEnum"/></para>
		/// </param>
		/// <param name="TemporalSubsetMethod">
		/// <para>Temporal Subset Method</para>
		/// <para>指定将用于对时空立方体进行时间子集化的方法。 输入时空立方体中满足此时间子集标准的任何时间步长都将包含在输出时空立方体中。</para>
		/// <para>用户定义—子集时间跨度参数中的开始时间或结束时间值指定的时间范围将用于对输入时空立方体进行时间子集化。</para>
		/// <para>时间步长数量—从起点开始和从终点开始的输入时空立方体的多个时间步长将用于在时间上对时空立方体进行子集化。 要移除的时间步数由要移除的时间步长数量参数中的从起点开始或从终点开始值指定。</para>
		/// <para>时空立方体—由输入时间子集立方体参数指定的时空立方体的时间范围，将用于对输入时空立方体进行时间子集化。</para>
		/// <para>无—时间子集不会应用于输入时空立方体。</para>
		/// <para><see cref="TemporalSubsetMethodEnum"/></para>
		/// </param>
		public SubsetSpaceTimeCube(object InCube, object OutCube, object SpatialSubsetMethod, object TemporalSubsetMethod)
		{
			this.InCube = InCube;
			this.OutCube = OutCube;
			this.SpatialSubsetMethod = SpatialSubsetMethod;
			this.TemporalSubsetMethod = TemporalSubsetMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 子集时空立方体</para>
		/// </summary>
		public override string DisplayName() => "子集时空立方体";

		/// <summary>
		/// <para>Tool Name : SubsetSpaceTimeCube</para>
		/// </summary>
		public override string ToolName() => "SubsetSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : stpm.SubsetSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName() => "stpm.SubsetSpaceTimeCube";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, OutCube, SpatialSubsetMethod, TemporalSubsetMethod, InSubsetFeatures!, SpatialRelationship!, SpatialExtent!, InSpatialCube!, TimeSpanSubset!, RemoveTimeSteps!, InTemporalCube! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>要子集化的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>输入时空立方体的子集，满足空间子集方法和时间子集方法参数指定的空间和时间标准。 存储在输入时空立方体中的分析变量将从输出时空立方体中排除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutCube { get; set; }

		/// <summary>
		/// <para>Spatial Subset Method</para>
		/// <para>指定将用于对输入时空立方体进行空间子集化的方法。 输入时空立方体中满足此空间子集标准的任何位置都将包含在输出时空立方体中。</para>
		/// <para>要素—具有面、点或线的要素类将用于对输入时空立方体进行子集化。 空间关系参数指定要素图层如何对时空立方体进行子集化。</para>
		/// <para>范围—范围参数指定的范围将用于对输入时空立方体进行子集化。 输出时空立方体将包括输入时空立方体中与范围相交的所有位置。</para>
		/// <para>时空立方体—由输入空间子集立方体参数指定的时空立方体的位置将用于对时空立方体进行子集化。 空间关系参数指定此时空立方体如何将输入时空立方体子集化。</para>
		/// <para>无—空间子集不会应用于输入时空立方体。</para>
		/// <para><see cref="SpatialSubsetMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialSubsetMethod { get; set; }

		/// <summary>
		/// <para>Temporal Subset Method</para>
		/// <para>指定将用于对时空立方体进行时间子集化的方法。 输入时空立方体中满足此时间子集标准的任何时间步长都将包含在输出时空立方体中。</para>
		/// <para>用户定义—子集时间跨度参数中的开始时间或结束时间值指定的时间范围将用于对输入时空立方体进行时间子集化。</para>
		/// <para>时间步长数量—从起点开始和从终点开始的输入时空立方体的多个时间步长将用于在时间上对时空立方体进行子集化。 要移除的时间步数由要移除的时间步长数量参数中的从起点开始或从终点开始值指定。</para>
		/// <para>时空立方体—由输入时间子集立方体参数指定的时空立方体的时间范围，将用于对输入时空立方体进行时间子集化。</para>
		/// <para>无—时间子集不会应用于输入时空立方体。</para>
		/// <para><see cref="TemporalSubsetMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TemporalSubsetMethod { get; set; }

		/// <summary>
		/// <para>Input Subset Features</para>
		/// <para>包含面、点或线以对时空立方体进行子集化的要素类。 输入子集要素与时空立方体之间的空间关系由空间关系参数指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InSubsetFeatures { get; set; }

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// <para>指定将在输入子集要素或输入空间子集立方体参数值和输入时空立方体之间应用的空间关系，以对时空立方体进行空间子集化。 可用的空间关系选项将取决于输入时空立方体的几何形状和输入子集要素或输入空间子集立方体。</para>
		/// <para>相交—输出时空立方体将包括输入时空立方体中与输入子集要素或输入空间子集立方体参数值相交的位置。 这是默认设置。</para>
		/// <para>包含—输出时空立方体将包括输入时空立方体中包含输入子集要素或输入空间子集立方体参数值的位置。</para>
		/// <para>位于—输出时空立方体将包括输入时空立方体中输入子集要素或输入空间子集立方体参数值内的位置。</para>
		/// <para>中心在要素范围内—输出时空立方体将包括输入时空立方体中以输入子集要素或输入空间子集立方体参数值为中心的位置。</para>
		/// <para><see cref="SpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialRelationship { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Extent</para>
		/// <para>将对输入时空立方体进行空间子集化的空间范围。 输出时空立方体将包括输入时空立方体中与范围相交的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? SpatialExtent { get; set; }

		/// <summary>
		/// <para>Input Spatial Subset Cube</para>
		/// <para>时空立方体将在空间上对输入时空立方体进行子集化。 输入空间子集立方体与时空立方体之间的空间关系由空间关系参数指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object? InSpatialCube { get; set; }

		/// <summary>
		/// <para>Time Span of Subset</para>
		/// <para>对输入时空立方体进行时间子集化的时间间隔。 在此时间间隔内或任何包含开始时间或结束时间列值的时间步长都将包含在输出时空立方体中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? TimeSpanSubset { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Remove</para>
		/// <para>从起点开始和从终点开始的输入时空立方体的时间步长数量，将从输出时空立方体中移除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? RemoveTimeSteps { get; set; }

		/// <summary>
		/// <para>Input Temporal Subset Cube</para>
		/// <para>时空立方体将在时间上对输入时空立方体进行子集化。 时间子集立方体的时间范围定义了输出时空立方体的时间范围。 任何时间步长，只要在输入时间子集立方体的时间范围内或包含有时间子集立方体的开始或结束时间，则都将包含在输出时空立方体中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object? InTemporalCube { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubsetSpaceTimeCube SetEnviroment(object? outputCoordinateSystem = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Subset Method</para>
		/// </summary>
		public enum SpatialSubsetMethodEnum 
		{
			/// <summary>
			/// <para>要素—具有面、点或线的要素类将用于对输入时空立方体进行子集化。 空间关系参数指定要素图层如何对时空立方体进行子集化。</para>
			/// </summary>
			[GPValue("FEATURES")]
			[Description("要素")]
			Features,

			/// <summary>
			/// <para>范围—范围参数指定的范围将用于对输入时空立方体进行子集化。 输出时空立方体将包括输入时空立方体中与范围相交的所有位置。</para>
			/// </summary>
			[GPValue("EXTENT")]
			[Description("范围")]
			Extent,

			/// <summary>
			/// <para>时空立方体—由输入空间子集立方体参数指定的时空立方体的位置将用于对时空立方体进行子集化。 空间关系参数指定此时空立方体如何将输入时空立方体子集化。</para>
			/// </summary>
			[GPValue("SPACE_TIME_CUBE")]
			[Description("时空立方体")]
			Space_Time_Cube,

			/// <summary>
			/// <para>无—空间子集不会应用于输入时空立方体。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Temporal Subset Method</para>
		/// </summary>
		public enum TemporalSubsetMethodEnum 
		{
			/// <summary>
			/// <para>用户定义—子集时间跨度参数中的开始时间或结束时间值指定的时间范围将用于对输入时空立方体进行时间子集化。</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("用户定义")]
			User_defined,

			/// <summary>
			/// <para>时间步长数量—从起点开始和从终点开始的输入时空立方体的多个时间步长将用于在时间上对时空立方体进行子集化。 要移除的时间步数由要移除的时间步长数量参数中的从起点开始或从终点开始值指定。</para>
			/// </summary>
			[GPValue("NUMBER_OF_TIME_STEPS")]
			[Description("时间步长数量")]
			Number_of_time_steps,

			/// <summary>
			/// <para>时空立方体—由输入时间子集立方体参数指定的时空立方体的时间范围，将用于对输入时空立方体进行时间子集化。</para>
			/// </summary>
			[GPValue("SPACE_TIME_CUBE")]
			[Description("时空立方体")]
			Space_time_cube,

			/// <summary>
			/// <para>无—时间子集不会应用于输入时空立方体。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Spatial Relationship</para>
		/// </summary>
		public enum SpatialRelationshipEnum 
		{
			/// <summary>
			/// <para>相交—输出时空立方体将包括输入时空立方体中与输入子集要素或输入空间子集立方体参数值相交的位置。 这是默认设置。</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("相交")]
			Intersect,

			/// <summary>
			/// <para>包含—输出时空立方体将包括输入时空立方体中包含输入子集要素或输入空间子集立方体参数值的位置。</para>
			/// </summary>
			[GPValue("CONTAINS")]
			[Description("包含")]
			Contains,

			/// <summary>
			/// <para>位于—输出时空立方体将包括输入时空立方体中输入子集要素或输入空间子集立方体参数值内的位置。</para>
			/// </summary>
			[GPValue("WITHIN")]
			[Description("位于")]
			Within,

			/// <summary>
			/// <para>中心在要素范围内—输出时空立方体将包括输入时空立方体中以输入子集要素或输入空间子集立方体参数值为中心的位置。</para>
			/// </summary>
			[GPValue("HAVE_THEIR_CENTER_IN")]
			[Description("中心在要素范围内")]
			Have_their_center_in,

		}

#endregion
	}
}
