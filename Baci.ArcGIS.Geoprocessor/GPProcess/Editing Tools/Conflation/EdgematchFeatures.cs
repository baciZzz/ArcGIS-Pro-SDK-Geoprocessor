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
	/// <para>Edgematch Features</para>
	/// <para>Edgematch Features</para>
	/// <para>Modifies input line features by spatially adjusting their shapes, guided by the specified edgematch links, so they become connected with the lines in the adjacent dataset.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class EdgematchFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>Input line features to be adjusted.</para>
		/// </param>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>Input line features representing edgematch links.</para>
		/// </param>
		public EdgematchFeatures(object InFeatures, object InLinkFeatures)
		{
			this.InFeatures = InFeatures;
			this.InLinkFeatures = InLinkFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Edgematch Features</para>
		/// </summary>
		public override string DisplayName() => "Edgematch Features";

		/// <summary>
		/// <para>Tool Name : EdgematchFeatures</para>
		/// </summary>
		public override string ToolName() => "EdgematchFeatures";

		/// <summary>
		/// <para>Tool Excute Name : edit.EdgematchFeatures</para>
		/// </summary>
		public override string ExcuteName() => "edit.EdgematchFeatures";

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
		public override object[] Parameters() => new object[] { InFeatures, InLinkFeatures, Method, AdjacentFeatures, BorderFeatures, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>Input line features to be adjusted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>Input line features representing edgematch links.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Edgematch method to be used to adjust either input features only or both input features and adjacent features to new connecting locations.</para>
		/// <para>Move endpoint—Moves the endpoint of a line to the new connecting location. This is the default.</para>
		/// <para>Add segment—Adds a straight segment at the end of a line so it ends at the new connecting location.</para>
		/// <para>Adjust vertices—Adjusts the endpoint of a line to the new connecting location. The remaining vertices are also adjusted so its positional changes are gradually reduced toward the opposite end of the line.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "MOVE_ENDPOINT";

		/// <summary>
		/// <para>Adjacent Features</para>
		/// <para>Line features that are adjacent to input features. If specified, both the input and adjacent features are adjusted to meet at new connecting locations, either the midpoints of the edgematch links or locations nearest to the midpoints of the links on the border features (if specified).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge")]
		public object AdjacentFeatures { get; set; }

		/// <summary>
		/// <para>Border Features</para>
		/// <para>Line or polygon features representing borders between the input and adjacent features. When you specify border features, both input and adjacent features are adjusted to meet at new connecting locations nearest to the midpoints of the links on the border features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object BorderFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EdgematchFeatures SetEnviroment(object extent = null, object workspace = null)
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
			/// <para>Move endpoint—Moves the endpoint of a line to the new connecting location. This is the default.</para>
			/// </summary>
			[GPValue("MOVE_ENDPOINT")]
			[Description("Move endpoint")]
			Move_endpoint,

			/// <summary>
			/// <para>Add segment—Adds a straight segment at the end of a line so it ends at the new connecting location.</para>
			/// </summary>
			[GPValue("ADD_SEGMENT")]
			[Description("Add segment")]
			Add_segment,

			/// <summary>
			/// <para>Adjust vertices—Adjusts the endpoint of a line to the new connecting location. The remaining vertices are also adjusted so its positional changes are gradually reduced toward the opposite end of the line.</para>
			/// </summary>
			[GPValue("ADJUST_VERTICES")]
			[Description("Adjust vertices")]
			Adjust_vertices,

		}

#endregion
	}
}
