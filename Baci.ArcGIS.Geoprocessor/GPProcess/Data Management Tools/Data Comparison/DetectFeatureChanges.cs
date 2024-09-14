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
	/// <para>Detect Feature Changes</para>
	/// <para>检测要素更改</para>
	/// <para>可以查找更新线要素在空间上与基线要素匹配的位置，检测空间更改、属性更改或同时检测这两种更改以及无更改的情况。 然后，它将创建一个输出要素类，其中包含匹配的更新要素以及有关其更改、不匹配的更新要素和不匹配的基本要素的信息。</para>
	/// </summary>
	public class DetectFeatureChanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="UpdateFeatures">
		/// <para>Update Features</para>
		/// <para>将线要素与基础要素进行比较。</para>
		/// </param>
		/// <param name="BaseFeatures">
		/// <para>Base Features</para>
		/// <para>将线要素与更新要素进行比较以检测更改。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含更改信息的输出线要素类。 输出包含所有参与的更新要素（匹配的和不匹配的）以及任何不匹配的基础要素。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public DetectFeatureChanges(object UpdateFeatures, object BaseFeatures, object OutFeatureClass, object SearchDistance)
		{
			this.UpdateFeatures = UpdateFeatures;
			this.BaseFeatures = BaseFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 检测要素更改</para>
		/// </summary>
		public override string DisplayName() => "检测要素更改";

		/// <summary>
		/// <para>Tool Name : DetectFeatureChanges</para>
		/// </summary>
		public override string ToolName() => "DetectFeatureChanges";

		/// <summary>
		/// <para>Tool Excute Name : management.DetectFeatureChanges</para>
		/// </summary>
		public override string ExcuteName() => "management.DetectFeatureChanges";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { UpdateFeatures, BaseFeatures, OutFeatureClass, SearchDistance, MatchFields, OutMatchTable, ChangeTolerance, CompareFields, CompareLineDirection };

		/// <summary>
		/// <para>Update Features</para>
		/// <para>将线要素与基础要素进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object UpdateFeatures { get; set; }

		/// <summary>
		/// <para>Base Features</para>
		/// <para>将线要素与更新要素进行比较以检测更改。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object BaseFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含更改信息的输出线要素类。 输出包含所有参与的更新要素（匹配的和不匹配的）以及任何不匹配的基础要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>来自更新要素和基础要素的匹配字段。 如果指定，将比较匹配候选项的每对字段，以帮助确定正确的匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object MatchFields { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>包含完整的要素匹配信息的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutMatchTable { get; set; }

		/// <summary>
		/// <para>Change Tolerance</para>
		/// <para>用于确定是否存在空间更改的距离。 将所有匹配的更新要素和基础要素与此容差进行比较。 如果更新要素或基础要素有任意部分落在匹配的要素区域之外，则将其视为空间更改。 要执行此过程，该值必须大于输入数据的 XY 容差，并且输出将包含 LEN_PCT 和 LEN_ABS 字段。 默认值为 0，表示不执行此过程。 0 到数据 XY 容差（包括 XY 容差）之间的任何值都将使过程无关紧要，并将被替换为 0。 可以选择单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ChangeTolerance { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Compare Fields</para>
		/// <para>将用于确定匹配更新要素与基础要素之间是否存在属性更改的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object CompareFields { get; set; }

		/// <summary>
		/// <para>Compare line direction</para>
		/// <para>指定是否比较匹配要素的线方向。</para>
		/// <para>未选中 - 不比较匹配要素的线方向。 这是默认设置。</para>
		/// <para>选中 - 比较匹配要素的线方向。</para>
		/// <para><see cref="CompareLineDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareLineDirection { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectFeatureChanges SetEnviroment(object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compare line direction</para>
		/// </summary>
		public enum CompareLineDirectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPARE_DIRECTION")]
			COMPARE_DIRECTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPARE_DIRECTION")]
			NO_COMPARE_DIRECTION,

		}

#endregion
	}
}
