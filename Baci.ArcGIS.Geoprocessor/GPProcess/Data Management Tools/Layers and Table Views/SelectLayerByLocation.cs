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
	/// <para>Select Layer By Location</para>
	/// <para>按位置选择图层</para>
	/// <para>根据与另一个数据集中的要素的空间关系来选择要素。</para>
	/// </summary>
	public class SelectLayerByLocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Features</para>
		/// <para>将根据选择要素参数值进行评估的要素。 选择将应用于这些要素。</para>
		/// </param>
		public SelectLayerByLocation(object InLayer)
		{
			this.InLayer = InLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 按位置选择图层</para>
		/// </summary>
		public override string DisplayName() => "按位置选择图层";

		/// <summary>
		/// <para>Tool Name : SelectLayerByLocation</para>
		/// </summary>
		public override string ToolName() => "SelectLayerByLocation";

		/// <summary>
		/// <para>Tool Excute Name : management.SelectLayerByLocation</para>
		/// </summary>
		public override string ExcuteName() => "management.SelectLayerByLocation";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLayer, OverlapType!, SelectFeatures!, SearchDistance!, SelectionType!, OutLayerOrView!, InvertSpatialRelationship!, OutLayersOrViews!, Count! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将根据选择要素参数值进行评估的要素。 选择将应用于这些要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>指定要评估的空间关系。</para>
		/// <para>相交—如果输入图层中的要素与某一选择要素相交，则会选择这些要素。 这是默认设置。</para>
		/// <para>3D 相交—如果输入图层中的要素在三维空间（x、y 和 z）中与某一选择要素相交，则会选择这些要素。</para>
		/// <para>相交 (DBMS)—如果输入图层中的要素与某一选择要素相交，则会选择这些要素。此选项仅适用于企业级地理数据库。 当满足所有要求时，选择将在企业级地理数据库 DBMS 中，而不是在客户端上进行处理（有关详细信息，请参阅使用说明）。与在客户端上执行选择相比，此选项可提供更好的性能。</para>
		/// <para>在某一距离范围内—如果输入图层中的要素在某一选择要素的指定距离内（使用欧氏距离），则将选择这些要素。 使用搜索距离参数指定距离。</para>
		/// <para>在某一 3D 距离范围内—如果输入图层中的要素在三维空间中的某一选择要素的指定距离内，则会选择这些要素。 使用搜索距离参数指定距离。</para>
		/// <para>在某一测地线距离范围内—如果输入图层中的要素在某一选择要素的指定距离内，则会选择这些要素。 将使用测地线公式计算要素间的距离，这种方法考虑到椭球体的曲率，并可以正确处理跨越日期变更线和两极及其附近的数据。 使用搜索距离参数指定距离。</para>
		/// <para>包含—如果输入图层中的要素包含选择要素，则会选择这些要素。</para>
		/// <para>完全包含—如果输入图层中的要素完全包含选择要素，则会选择这些要素。</para>
		/// <para>包含 (Clementini)—该空间关系产生的结果同包含，但有一种情况例外：如果选择要素完全位于输入要素的边界上（没有任何一部分完全位于里面或外面），则不会选择要素。Clementini 将边界面定义为用来分隔内部和外部的线，将线的边界定义为其端点，点的边界始终为空。</para>
		/// <para>位于—如果输入图层中的要素位于选择要素中，则会选择这些要素。</para>
		/// <para>完全在其他要素范围内—如果输入图层中的要素完全位于或包含在在选择要素之，则会选择这些要素。</para>
		/// <para>包含于 (Clementini)—结果同位于，但下述情况例外：如果输入图层中的要素完全位于选择图层中要素的边界上，则不会选择该要素。Clementini 将边界面定义为用来分隔内部和外部的线，将线的边界定义为其端点，点的边界始终为空。</para>
		/// <para>与其他要素相同—如果输入图层中的要素与选择要素相同（在几何形状上），则会选择这些要素。</para>
		/// <para>边界接触—如果输入图层中要素的边界与某一选择要素接触，则会选择这些要素。 如果输入要素为线或面，则输入要素的边界只能接触选择要素的边界，且输入要素的任何部分均不可跨越选择要素的边界。</para>
		/// <para>与其他要素共线—如果输入图层中的要素与某一选择要素共线，则会选择这些要素。 输入要素和选择要素必须是线或面。</para>
		/// <para>与轮廓交叉—如果输入图层中的要素与某一选择要素的轮廓交叉，则会选择这些要素。 输入和选择要素必须是线或面。 如果将面用于输入或选择图层，则会使用面的边界（线）。 将选择在某一点交叉的线，而不会选择共线的线。</para>
		/// <para>中心在要素范围内—如果输入图层中要素的中心落在某一选择要素内，则会选择这些要素。 要素中心的计算方式如下：对于面和多点，将使用几何的质心；对于线输入，则会使用几何的中点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Selecting Features</para>
		/// <para>输入要素参数中的要素将根据它们与此图层或要素类中要素的关系进行选择。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? SelectFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>将被搜索的距离。 仅当关系参数设置为在某一距离范围内、在某一测地线距离范围内、在某一 3D 距离范围内、相交、3D 相交、中心在要素范围内或者包含时，该参数才有效。</para>
		/// <para>如果选择在某一测地线距离范围内选项，请使用线性单位（如千米或英里）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>指定如何将选择内容应用于输入，以及如何同现有选择内容进行组合。 该工具不包含清除现有选择内容的选项；请使用按属性选择图层工具上的清除当前选择选项执行此操作。</para>
		/// <para>新建选择内容—生成的选择内容将替换任何现有选择内容。 这是默认设置。</para>
		/// <para>添加到当前选择内容—将生成的选择内容添加至现有选择内容。 如果不存在选择内容，该选项的作用同新建选择内容选项。</para>
		/// <para>从当前选择内容中移除—将生成的选择内容从现有选择内容中移除。 如果不存在选择内容，此操作将不起作用。</para>
		/// <para>选择当前选择内容的子集—将生成的选择内容与现有选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
		/// <para>切换当前选择内容—选择内容将被切换。 将所选的所有记录从选择内容中移除，将未选取的所有记录添加到当前选择内容中。如果选择该选项，则将忽略选择要素参数和关系参数。</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Layer With Selection</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutLayerOrView { get; set; }

		/// <summary>
		/// <para>Invert Spatial Relationship</para>
		/// <para>指定将使用空间关系评估结果，还是使用反转结果。 例如，可使用此参数获取不相交或与另一数据集中的要素不在指定距离范围内的要素的列表。</para>
		/// <para>未选中 - 将使用查询结果。 这是默认设置。</para>
		/// <para>选中 - 将使用反转查询结果。 如果使用选择类型参数，则将先反转选择，然后再将其与现有选择组合。</para>
		/// <para><see cref="InvertSpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InvertSpatialRelationship { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutLayersOrViews { get; set; }

		/// <summary>
		/// <para>Count</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? Count { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SelectLayerByLocation SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Selection Type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>新建选择内容—生成的选择内容将替换任何现有选择内容。 这是默认设置。</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("新建选择内容")]
			New_selection,

			/// <summary>
			/// <para>添加到当前选择内容—将生成的选择内容添加至现有选择内容。 如果不存在选择内容，该选项的作用同新建选择内容选项。</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("添加到当前选择内容")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>从当前选择内容中移除—将生成的选择内容从现有选择内容中移除。 如果不存在选择内容，此操作将不起作用。</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("从当前选择内容中移除")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>选择当前选择内容的子集—将生成的选择内容与现有选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("选择当前选择内容的子集")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>切换当前选择内容—选择内容将被切换。 将所选的所有记录从选择内容中移除，将未选取的所有记录添加到当前选择内容中。如果选择该选项，则将忽略选择要素参数和关系参数。</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("切换当前选择内容")]
			Switch_the_current_selection,

		}

		/// <summary>
		/// <para>Invert Spatial Relationship</para>
		/// </summary>
		public enum InvertSpatialRelationshipEnum 
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
			[Description("NOT_INVERT")]
			NOT_INVERT,

		}

#endregion
	}
}
