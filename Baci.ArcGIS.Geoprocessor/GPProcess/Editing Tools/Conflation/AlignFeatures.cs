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
	/// <para>Align Features</para>
	/// <para>Identifies inconsistent portions of the input features against target features within a search distance and aligns them with the target features.</para>
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
		/// <para>Input line or polygon features to be adjusted.</para>
		/// </param>
		/// <param name="TargetFeatures">
		/// <para>Target Features</para>
		/// <para>Input lines or polygons as target features.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </param>
		public AlignFeatures(object InFeatures, object TargetFeatures, object SearchDistance)
		{
			this.InFeatures = InFeatures;
			this.TargetFeatures = TargetFeatures;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Align Features</para>
		/// </summary>
		public override string DisplayName() => "Align Features";

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
		public override object[] Parameters() => new object[] { InFeatures, TargetFeatures, SearchDistance, MatchFields!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>Input line or polygon features to be adjusted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexJunction", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>Input lines or polygons as target features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexJunction", "ComplexEdge", "RasterCatalogItem")]
		public object TargetFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance used to search for match candidates. A distance must be specified and it must be greater than zero. You can choose a preferred unit; the default is the feature unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Match Fields</para>
		/// <para>Fields from input and target features. If specified, each pair of fields are checked for match candidates to help determine the right match.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "Blob", "Raster", "XML", "GUID", "OID")]
		[ExcludeField("SHAPE_Length", "SHAPE_Area")]
		public object? MatchFields { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlignFeatures SetEnviroment(object? extent = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

	}
}
