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
	/// <para>Align Features</para>
	/// <para>对齐要素</para>
	/// <para>标识地理处理工具用于标识搜索距离中输入要素与目标要素的不一致部分并使其与目标要素一致。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlignFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要进行调整的输入线或面要素。</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>作为目标要素的输入线或面要素。</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </param>
		public AlignFeatures(object InFeatures, object TargetFeatures, object SearchDistance)
		{
			this.InFeatures = InFeatures;
			this.TargetFeatures = TargetFeatures;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : 对齐要素</para>
		/// </summary>
		public override string DisplayName() => "对齐要素";

		/// <summary>
		/// <para>Tool Name : AlignFeatures</para>
		/// </summary>
		public override string ToolName() => "AlignFeatures";

		/// <summary>
		/// <para>Tool Excute Name : edit.AlignFeatures</para>
		/// </summary>
		public override string ExcuteName() => "edit.AlignFeatures";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, TargetFeatures, SearchDistance, MatchFields, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行调整的输入线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexJunction", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>作为目标要素的输入线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexJunction", "ComplexEdge", "RasterCatalogItem")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>用于搜索匹配候选项的距离。必须指定一个距离，且此距离必须大于零。可以选择首选单位；默认为要素单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>来自输入要素与目标要素的字段。如果指定，将检查每对字段中的匹配候选项，以帮助确定正确的匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object MatchFields { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlignFeatures SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
