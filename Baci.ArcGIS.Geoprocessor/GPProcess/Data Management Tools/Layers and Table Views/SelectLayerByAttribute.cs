using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Select Layer By Attribute</para>
	/// <para>按属性选择图层</para>
	/// <para>用于基于属性查询添加、更新或移除选择内容。</para>
	/// </summary>
	public class SelectLayerByAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Rows</para>
		/// <para>将应用所选内容的数据。</para>
		/// </param>
		public SelectLayerByAttribute(object InLayerOrView)
		{
			this.InLayerOrView = InLayerOrView;
		}

		/// <summary>
		/// <para>Tool Display Name : 按属性选择图层</para>
		/// </summary>
		public override string DisplayName() => "按属性选择图层";

		/// <summary>
		/// <para>Tool Name : SelectLayerByAttribute</para>
		/// </summary>
		public override string ToolName() => "SelectLayerByAttribute";

		/// <summary>
		/// <para>Tool Excute Name : management.SelectLayerByAttribute</para>
		/// </summary>
		public override string ExcuteName() => "management.SelectLayerByAttribute";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayerOrView, SelectionType, WhereClause, OutLayerOrView, InvertWhereClause, Count };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>将应用所选内容的数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Selection type</para>
		/// <para>指定如何应用所选内容以及如果已存在已选内容要执行的操作。</para>
		/// <para>新建选择内容—生成的选择内容将替换当前选择内容。这是默认设置。</para>
		/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。如果不存在选择内容，该选项不起作用。</para>
		/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。只有两者共同的记录才会被选取。</para>
		/// <para>切换当前选择内容—选择内容将被切换。将所选的所有记录从当前选择内容中移除，将未选取的所有记录添加到当前选择内容中。当指定该选项时，系统将忽略表达式参数（Python 中的 where_clause）。</para>
		/// <para>清除当前选择内容—选择将被清除或移除。当指定该选项时，系统将忽略表达式参数（Python 中的 where_clause）。</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Updated Layer Or Table View</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Invert Where Clause</para>
		/// <para>指定是按原样使用表达式，还是使用与表达式相反的表达式。</para>
		/// <para>未选中 - 将按原样使用查询。这是默认设置。</para>
		/// <para>选中 - 将反转查询。如果使用选择类型参数，则将先反转选择，然后再将其与现有选择组合。</para>
		/// <para><see cref="InvertWhereClauseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InvertWhereClause { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object Count { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Selection type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>新建选择内容—生成的选择内容将替换当前选择内容。这是默认设置。</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("新建选择内容")]
			New_selection,

			/// <summary>
			/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("添加到当前选择内容")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。如果不存在选择内容，该选项不起作用。</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("从当前选择内容中移除")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。只有两者共同的记录才会被选取。</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("选择当前选择内容的子集")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>切换当前选择内容—选择内容将被切换。将所选的所有记录从当前选择内容中移除，将未选取的所有记录添加到当前选择内容中。当指定该选项时，系统将忽略表达式参数（Python 中的 where_clause）。</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("切换当前选择内容")]
			Switch_the_current_selection,

			/// <summary>
			/// <para>清除当前选择内容—选择将被清除或移除。当指定该选项时，系统将忽略表达式参数（Python 中的 where_clause）。</para>
			/// </summary>
			[GPValue("CLEAR_SELECTION")]
			[Description("清除当前选择内容")]
			Clear_the_current_selection,

		}

		/// <summary>
		/// <para>Invert Where Clause</para>
		/// </summary>
		public enum InvertWhereClauseEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_INVERT")]
			NON_INVERT,

		}

#endregion
	}
}
