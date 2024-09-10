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
	/// <para>Adds, updates, or removes a selection based on an attribute query.</para>
	/// </summary>
	public class SelectLayerByAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayerOrView">
		/// <para>Input Rows</para>
		/// <para>The data to which the selection will be applied.</para>
		/// </param>
		public SelectLayerByAttribute(object InLayerOrView)
		{
			this.InLayerOrView = InLayerOrView;
		}

		/// <summary>
		/// <para>Tool Display Name : Select Layer By Attribute</para>
		/// </summary>
		public override string DisplayName() => "Select Layer By Attribute";

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
		/// <para>The data to which the selection will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InLayerOrView { get; set; }

		/// <summary>
		/// <para>Selection type</para>
		/// <para>Specifies how the selection will be applied and what to do if a selection already exists.</para>
		/// <para>New selection—The resulting selection replaces the current selection. This is the default.</para>
		/// <para>Add to the current selection—The resulting selection is added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
		/// <para>Remove from the current selection—The resulting selection is removed from the current selection. If no selection exists, this option has no effect.</para>
		/// <para>Select subset from the current selection—The resulting selection is combined with the current selection. Only records that are common to both remain selected.</para>
		/// <para>Switch the current selection—The selection is switched. All records that were selected are removed from the current selection, and all records that were not selected are added to the current selection. The Expression parameter (where_clause in Python) is ignored when this option is specified.</para>
		/// <para>Clear the current selection—The selection is cleared or removed. The Expression parameter (where_clause in Python) is ignored when this option is specified.</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records.</para>
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
		/// <para>Specifies whether the expression will be used as is, or the opposite of the expression will be used.</para>
		/// <para>Unchecked—The query will be used as is. This is the default.</para>
		/// <para>Checked—The opposite of the query will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
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
			/// <para>New selection—The resulting selection replaces the current selection. This is the default.</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("New selection")]
			New_selection,

			/// <summary>
			/// <para>Add to the current selection—The resulting selection is added to the current selection if one exists. If no selection exists, this is the same as the new selection option.</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("Add to the current selection")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>Remove from the current selection—The resulting selection is removed from the current selection. If no selection exists, this option has no effect.</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("Remove from the current selection")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>Select subset from the current selection—The resulting selection is combined with the current selection. Only records that are common to both remain selected.</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("Select subset from the current selection")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>Switch the current selection—The selection is switched. All records that were selected are removed from the current selection, and all records that were not selected are added to the current selection. The Expression parameter (where_clause in Python) is ignored when this option is specified.</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("Switch the current selection")]
			Switch_the_current_selection,

			/// <summary>
			/// <para>Clear the current selection—The selection is cleared or removed. The Expression parameter (where_clause in Python) is ignored when this option is specified.</para>
			/// </summary>
			[GPValue("CLEAR_SELECTION")]
			[Description("Clear the current selection")]
			Clear_the_current_selection,

		}

		/// <summary>
		/// <para>Invert Where Clause</para>
		/// </summary>
		public enum InvertWhereClauseEnum 
		{
			/// <summary>
			/// <para>Checked—The opposite of the query will be used. If the Selection Type parameter is used, the reversal of the selection occurs before it is combined with existing selections.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para>Unchecked—The query will be used as is. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_INVERT")]
			NON_INVERT,

		}

#endregion
	}
}
