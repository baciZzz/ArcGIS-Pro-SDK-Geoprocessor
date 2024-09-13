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
	/// <para>Trim Line</para>
	/// <para>Trim Line</para>
	/// <para>Removes portions of a line that extend a specified distance past a line intersection (dangles). Any line that does not touch another line at both endpoints can be trimmed, but only the portion of the line that extends past the intersection by the specified distance will be removed.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class TrimLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The line input features to be trimmed.</para>
		/// </param>
		public TrimLine(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Trim Line</para>
		/// </summary>
		public override string DisplayName() => "Trim Line";

		/// <summary>
		/// <para>Tool Name : TrimLine</para>
		/// </summary>
		public override string ToolName() => "TrimLine";

		/// <summary>
		/// <para>Tool Excute Name : edit.TrimLine</para>
		/// </summary>
		public override string ExcuteName() => "edit.TrimLine";

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
		public override object[] Parameters() => new object[] { InFeatures, DangleLength!, DeleteShorts!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line input features to be trimmed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dangle Length</para>
		/// <para>Line segments that are shorter than the specified dangle length and do not touch another line at both endpoints (dangles) will be trimmed.</para>
		/// <para>If a dangle length is not specified, all dangling lines (line segments that do not touch another line at both endpoints), regardless of length, will be trimmed back to the point of intersection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? DangleLength { get; set; }

		/// <summary>
		/// <para>Delete Short Features</para>
		/// <para>Specifies whether line segments which are less than the dangle length and are free-standing will be deleted.</para>
		/// <para>Checked—Delete short free-standing features. This is the default.</para>
		/// <para>Unchecked—Do not delete short free-standing features.</para>
		/// <para><see cref="DeleteShortsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeleteShorts { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrimLine SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delete Short Features</para>
		/// </summary>
		public enum DeleteShortsEnum 
		{
			/// <summary>
			/// <para>Checked—Delete short free-standing features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_SHORT")]
			DELETE_SHORT,

			/// <summary>
			/// <para>Unchecked—Do not delete short free-standing features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_SHORT")]
			KEEP_SHORT,

		}

#endregion
	}
}
