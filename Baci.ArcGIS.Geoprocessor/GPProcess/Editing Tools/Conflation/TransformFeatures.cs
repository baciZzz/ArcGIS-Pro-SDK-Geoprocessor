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
	/// <para>变换要素</para>
	/// <para>根据已知相应控制点之间的变换链接通过缩放、平移和旋转将输入要素的坐标从一个位置转换到另一个位置。</para>
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
		/// <para>其坐标要进行变换的输入要素。 可以为点、线、面或注记。</para>
		/// </param>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>链接要进行变换的已知控制点的输入链接要素。</para>
		/// </param>
		public TransformFeatures(object InFeatures, object InLinkFeatures)
		{
			this.InFeatures = InFeatures;
			this.InLinkFeatures = InLinkFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 变换要素</para>
		/// </summary>
		public override string DisplayName() => "变换要素";

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
		/// <para>其坐标要进行变换的输入要素。 可以为点、线、面或注记。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "Annotation", "CoverageAnnotation")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>链接要进行变换的已知控制点的输入链接要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定用于转换输入要素坐标的变换方法。</para>
		/// <para>仿射变换—仿射变换至少需要三个变换链接。 这是默认设置。</para>
		/// <para>投影变换—射影变换至少需要四个变换链接。</para>
		/// <para>相似变换—相似变换至少需要两个变换链接。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "AFFINE";

		/// <summary>
		/// <para>Output Link Table</para>
		/// <para>包含输入链接及其残差的输出表。</para>
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
			/// <para>仿射变换—仿射变换至少需要三个变换链接。 这是默认设置。</para>
			/// </summary>
			[GPValue("AFFINE")]
			[Description("仿射变换")]
			Affine_transformation,

			/// <summary>
			/// <para>投影变换—射影变换至少需要四个变换链接。</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("投影变换")]
			Projective_transformation,

			/// <summary>
			/// <para>相似变换—相似变换至少需要两个变换链接。</para>
			/// </summary>
			[GPValue("SIMILARITY")]
			[Description("相似变换")]
			Similarity_transformation,

		}

#endregion
	}
}
