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
	/// <para>Generate Edgematch Links</para>
	/// <para>生成边匹配链接</para>
	/// <para>沿着源数据区域及其相邻数据区域的边缘查找匹配但是已断开的线要素，并生成从源线到相匹配相邻线的边匹配链接。</para>
	/// </summary>
	public class GenerateEdgematchLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceFeatures">
		/// <para>Source Features</para>
		/// <para>作为边匹配源要素的线要素。 所有边匹配链接均始于源要素。</para>
		/// </param>
		/// <param name="AdjacentFeatures">
		/// <para>Adjacent Features</para>
		/// <para>与源要素相邻的线要素。 所有边匹配链接均止于相匹配的相邻要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含线的输出要素类，该线表示边匹配链接。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public GenerateEdgematchLinks(object SourceFeatures, object AdjacentFeatures, object OutFeatureClass, object SearchDistance)
		{
			this.SourceFeatures = SourceFeatures;
			this.AdjacentFeatures = AdjacentFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成边匹配链接</para>
		/// </summary>
		public override string DisplayName() => "生成边匹配链接";

		/// <summary>
		/// <para>Tool Name : GenerateEdgematchLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateEdgematchLinks";

		/// <summary>
		/// <para>Tool Excute Name : edit.GenerateEdgematchLinks</para>
		/// </summary>
		public override string ExcuteName() => "edit.GenerateEdgematchLinks";

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
		public override object[] Parameters() => new object[] { SourceFeatures, AdjacentFeatures, OutFeatureClass, SearchDistance, MatchFields! };

		/// <summary>
		/// <para>Source Features</para>
		/// <para>作为边匹配源要素的线要素。 所有边匹配链接均始于源要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SourceFeatures { get; set; }

		/// <summary>
		/// <para>Adjacent Features</para>
		/// <para>与源要素相邻的线要素。 所有边匹配链接均止于相匹配的相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object AdjacentFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含线的输出要素类，该线表示边匹配链接。</para>
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
		/// <para>源要素和目标要素中的字段，其中目标字段来自相邻要素。 如果指定，将检查每对字段中的匹配候选项，以帮助确定正确的匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateEdgematchLinks SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
