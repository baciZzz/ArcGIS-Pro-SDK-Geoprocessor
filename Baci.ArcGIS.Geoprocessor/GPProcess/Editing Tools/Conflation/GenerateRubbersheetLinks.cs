using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Generate Rubbersheet Links</para>
	/// <para>生成橡皮页变换链接</para>
	/// <para>查找源线要素与目标线要素在空间上匹配的位置，并生成表示从源位置到相应目标位置的橡皮页变换链接的线。</para>
	/// </summary>
	public class GenerateRubbersheetLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceFeatures">
		/// <para>Source Features</para>
		/// <para>作为生成橡皮页变换链接的源要素的线要素。 所有链接均始于源要素。</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>作为生成橡皮页变换链接的目标要素的线要素。 所有链接均止于相匹配的目标要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含线的输出要素类，该线表示常规橡皮页变换链接。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public GenerateRubbersheetLinks(object SourceFeatures, object TargetFeatures, object OutFeatureClass, object SearchDistance)
		{
			this.SourceFeatures = SourceFeatures;
			this.TargetFeatures = TargetFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成橡皮页变换链接</para>
		/// </summary>
		public override string DisplayName() => "生成橡皮页变换链接";

		/// <summary>
		/// <para>Tool Name : GenerateRubbersheetLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateRubbersheetLinks";

		/// <summary>
		/// <para>Tool Excute Name : edit.GenerateRubbersheetLinks</para>
		/// </summary>
		public override string ExcuteName() => "edit.GenerateRubbersheetLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { SourceFeatures, TargetFeatures, OutFeatureClass, SearchDistance, MatchFields!, OutMatchTable!, OutPointFeatureClass! };

		/// <summary>
		/// <para>Source Features</para>
		/// <para>作为生成橡皮页变换链接的源要素的线要素。 所有链接均始于源要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SourceFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>作为生成橡皮页变换链接的目标要素的线要素。 所有链接均止于相匹配的目标要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含线的输出要素类，该线表示常规橡皮页变换链接。</para>
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
		/// <para>来自源要素与目标要素的字段的列表。如果指定，将检查每对字段中的匹配候选项，以帮助确定正确的匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Output Match Table</para>
		/// <para>包含完整的要素匹配信息的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutMatchTable { get; set; }

		/// <summary>
		/// <para>Identity Links</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRubbersheetLinks SetEnviroment(object? extent = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
