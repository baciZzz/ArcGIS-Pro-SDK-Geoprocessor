using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Generate Unit Openings</para>
	/// <para>生成单元开口</para>
	/// <para>可将单元开口创建为线要素，从而对入口的位置和物理范围进行建模。</para>
	/// </summary>
	public class GenerateUnitOpenings : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUnitFeatures">
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示一个或多个设施点的单元覆盖区。 在 Indoors 模型中，此项将为 Units 图层。 该工具将仅处理包含所选要素的级别。</para>
		/// </param>
		/// <param name="InDetailFeatures">
		/// <para>Input Detail Features</para>
		/// <para>输入折线要素，表示建筑细节折线。</para>
		/// </param>
		/// <param name="DoorDetailExpression">
		/// <para>Door Detail Expression</para>
		/// <para>一个 SQL 表达式，用于标识表示门的细节折线。</para>
		/// </param>
		/// <param name="WallDetailExpression">
		/// <para>Wall Detail Expression</para>
		/// <para>一个 SQL 表达式，用于标识表示墙壁的细节折线。</para>
		/// </param>
		/// <param name="TargetOpenings">
		/// <para>Target Openings</para>
		/// <para>将写入生成的折线的现有要素类或要素图层。 在 Indoors 模型中，此项将为 Details 图层。</para>
		/// </param>
		public GenerateUnitOpenings(object InUnitFeatures, object InDetailFeatures, object DoorDetailExpression, object WallDetailExpression, object TargetOpenings)
		{
			this.InUnitFeatures = InUnitFeatures;
			this.InDetailFeatures = InDetailFeatures;
			this.DoorDetailExpression = DoorDetailExpression;
			this.WallDetailExpression = WallDetailExpression;
			this.TargetOpenings = TargetOpenings;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成单元开口</para>
		/// </summary>
		public override string DisplayName() => "生成单元开口";

		/// <summary>
		/// <para>Tool Name : GenerateUnitOpenings</para>
		/// </summary>
		public override string ToolName() => "GenerateUnitOpenings";

		/// <summary>
		/// <para>Tool Excute Name : indoors.GenerateUnitOpenings</para>
		/// </summary>
		public override string ExcuteName() => "indoors.GenerateUnitOpenings";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUnitFeatures, InDetailFeatures, DoorDetailExpression, WallDetailExpression, TargetOpenings, WallThicknessTolerance!, DeleteExistingOpenings!, UpdatedOpenings! };

		/// <summary>
		/// <para>Input Unit Features</para>
		/// <para>输入面要素，表示一个或多个设施点的单元覆盖区。 在 Indoors 模型中，此项将为 Units 图层。 该工具将仅处理包含所选要素的级别。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InUnitFeatures { get; set; }

		/// <summary>
		/// <para>Input Detail Features</para>
		/// <para>输入折线要素，表示建筑细节折线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InDetailFeatures { get; set; }

		/// <summary>
		/// <para>Door Detail Expression</para>
		/// <para>一个 SQL 表达式，用于标识表示门的细节折线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object DoorDetailExpression { get; set; }

		/// <summary>
		/// <para>Wall Detail Expression</para>
		/// <para>一个 SQL 表达式，用于标识表示墙壁的细节折线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object WallDetailExpression { get; set; }

		/// <summary>
		/// <para>Target Openings</para>
		/// <para>将写入生成的折线的现有要素类或要素图层。 在 Indoors 模型中，此项将为 Details 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object TargetOpenings { get; set; }

		/// <summary>
		/// <para>Wall Thickness Tolerance</para>
		/// <para>工具将从单元要素的边向内和向外搜索以找到门要素的距离。 默认的测量单位为英尺。 默认值为 2 英尺，但是范围为 0 到 6 英尺。</para>
		/// <para><see cref="WallThicknessToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object? WallThicknessTolerance { get; set; } = "2 Feet";

		/// <summary>
		/// <para>Delete Existing Openings</para>
		/// <para>指定在创建新的开口要素之前，是否将删除 USE_TYPE 字段值为 Opening 的现有开口要素。 如果删除，则该工具会将现有开口替换为新开口（如果其位于同一位置）。</para>
		/// <para>选中 - 将删除现有开口。</para>
		/// <para>未选中 - 将不删除现有开口。 这是默认设置。</para>
		/// <para><see cref="DeleteExistingOpeningsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteExistingOpenings { get; set; } = "false";

		/// <summary>
		/// <para>Updated Openings</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedOpenings { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateUnitOpenings SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Wall Thickness Tolerance</para>
		/// </summary>
		public enum WallThicknessToleranceEnum 
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
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Delete Existing Openings</para>
		/// </summary>
		public enum DeleteExistingOpeningsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_EXISTING")]
			KEEP_EXISTING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_EXISTING")]
			DELETE_EXISTING,

		}

#endregion
	}
}
