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
	/// <para>Transform Features</para>
	/// <para>Transform Features</para>
	/// <para>Converts the coordinates of input features from one location to another through scaling,  </para>
	/// <para>shifting, and rotating based on the transformation links between known corresponding control points.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class TransformFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input features, the coordinates of which are to be transformed. They can be points, lines, polygons, or annotations.</para>
		/// </param>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>The input link features that link known control points for the transformation.</para>
		/// </param>
		public TransformFeatures(object InFeatures, object InLinkFeatures)
		{
			this.InFeatures = InFeatures;
			this.InLinkFeatures = InLinkFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Transform Features</para>
		/// </summary>
		public override string DisplayName() => "Transform Features";

		/// <summary>
		/// <para>Tool Name : TransformFeatures</para>
		/// </summary>
		public override string ToolName() => "TransformFeatures";

		/// <summary>
		/// <para>Tool Excute Name : edit.TransformFeatures</para>
		/// </summary>
		public override string ExcuteName() => "edit.TransformFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, InLinkFeatures, Method!, OutLinkTable!, OutRmse!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input features, the coordinates of which are to be transformed. They can be points, lines, polygons, or annotations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "Annotation", "CoverageAnnotation")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>The input link features that link known control points for the transformation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the transformation method to use to convert input feature coordinates.</para>
		/// <para>Affine transformation—Affine transformation requires a minimum of three transformation links. This is the default.</para>
		/// <para>Projective transformation—Projective transformation requires a minimum of four transformation links.</para>
		/// <para>Similarity transformation—Similarity transformation requires a minimum of two transformation links.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "AFFINE";

		/// <summary>
		/// <para>Output Link Table</para>
		/// <para>The output table containing input links and their residual errors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutLinkTable { get; set; }

		/// <summary>
		/// <para>RMSE</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? OutRmse { get; set; } = "0";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransformFeatures SetEnviroment(object? extent = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Affine transformation—Affine transformation requires a minimum of three transformation links. This is the default.</para>
			/// </summary>
			[GPValue("AFFINE")]
			[Description("Affine transformation")]
			Affine_transformation,

			/// <summary>
			/// <para>Projective transformation—Projective transformation requires a minimum of four transformation links.</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("Projective transformation")]
			Projective_transformation,

			/// <summary>
			/// <para>Similarity transformation—Similarity transformation requires a minimum of two transformation links.</para>
			/// </summary>
			[GPValue("SIMILARITY")]
			[Description("Similarity transformation")]
			Similarity_transformation,

		}

#endregion
	}
}
