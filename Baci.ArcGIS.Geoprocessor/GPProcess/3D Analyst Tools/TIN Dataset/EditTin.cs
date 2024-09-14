using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Edit TIN</para>
	/// <para>Edit TIN</para>
	/// <para>Loads data from one or more input features  to modify the surface of an existing triangulated irregular network (TIN).</para>
	/// </summary>
	public class EditTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Feature Class</para>
		/// <para>The input features and their related properties that will contribute to the definition of the TIN.</para>
		/// <para>Input Features—The feature with the geometry that will be imported to the TIN.</para>
		/// <para>Height Field— The source of elevation for the input features. Any numeric field from the input feature&apos;s attribute table can be used, along with the Z or M values stored in the Shape field. Choosing the &lt;None&gt; keyword will result in the feature&apos;s elevation being interpolated from the surrounding surface.</para>
		/// <para>Tag Field—A numeric attribute will be assigned to the TIN&apos;s data elements using values obtained from an integer field in the input feature&apos;s attribute table.</para>
		/// <para>Type—The feature&apos;s role in shaping the TIN surface will be defined. See the tool&apos;s usage tips for more information about surface feature types.</para>
		/// <para>Use Z— Indicates whether Z or M values are used when the SHAPE field is indicated as the height source. Setting this option to True implies Z values will be used, whereas setting it to False results in M values being used.</para>
		/// </param>
		public EditTin(object InTin, object InFeatures)
		{
			this.InTin = InTin;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Edit TIN</para>
		/// </summary>
		public override string DisplayName() => "Edit TIN";

		/// <summary>
		/// <para>Tool Name : EditTin</para>
		/// </summary>
		public override string ToolName() => "EditTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EditTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.EditTin";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, InFeatures, ConstrainedDelaunay!, DerivedOutTin! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The input features and their related properties that will contribute to the definition of the TIN.</para>
		/// <para>Input Features—The feature with the geometry that will be imported to the TIN.</para>
		/// <para>Height Field— The source of elevation for the input features. Any numeric field from the input feature&apos;s attribute table can be used, along with the Z or M values stored in the Shape field. Choosing the &lt;None&gt; keyword will result in the feature&apos;s elevation being interpolated from the surrounding surface.</para>
		/// <para>Tag Field—A numeric attribute will be assigned to the TIN&apos;s data elements using values obtained from an integer field in the input feature&apos;s attribute table.</para>
		/// <para>Type—The feature&apos;s role in shaping the TIN surface will be defined. See the tool&apos;s usage tips for more information about surface feature types.</para>
		/// <para>Use Z— Indicates whether Z or M values are used when the SHAPE field is indicated as the height source. Setting this option to True implies Z values will be used, whereas setting it to False results in M values being used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Constrained Delaunay</para>
		/// <para>Specifies the triangulation technique that will be used along the breaklines of the TIN.</para>
		/// <para>Unchecked—The TIN will use Delaunay conforming triangulation, which may densify each segment of the breaklines to produce multiple triangle edges. This is the default.</para>
		/// <para>Checked—The TIN will use constrained Delaunay triangulation, which will add each segment as a single edge. Delaunay triangulation rules are honored everywhere except along breaklines, which will not be densified.</para>
		/// <para><see cref="ConstrainedDelaunayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ConstrainedDelaunay { get; set; } = "false";

		/// <summary>
		/// <para>Updated TIN</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTinLayer()]
		public object? DerivedOutTin { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EditTin SetEnviroment(object? extent = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Constrained Delaunay</para>
		/// </summary>
		public enum ConstrainedDelaunayEnum 
		{
			/// <summary>
			/// <para>Checked—The TIN will use constrained Delaunay triangulation, which will add each segment as a single edge. Delaunay triangulation rules are honored everywhere except along breaklines, which will not be densified.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONSTRAINED_DELAUNAY")]
			CONSTRAINED_DELAUNAY,

			/// <summary>
			/// <para>Unchecked—The TIN will use Delaunay conforming triangulation, which may densify each segment of the breaklines to produce multiple triangle edges. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DELAUNAY")]
			DELAUNAY,

		}

#endregion
	}
}
