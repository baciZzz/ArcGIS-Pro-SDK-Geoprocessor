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
	/// <para>Extend Line</para>
	/// <para>Extends line segments to the first intersecting feature within a specified distance. If no intersecting feature is within the specified distance, the line segment will not be extended. Tool use is intended for quality control tasks such as cleaning up topology errors in features that were digitized without having set proper snapping environments.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ExtendLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The line input features to be extended.</para>
		/// </param>
		public ExtendLine(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Extend Line</para>
		/// </summary>
		public override string DisplayName() => "Extend Line";

		/// <summary>
		/// <para>Tool Name : ExtendLine</para>
		/// </summary>
		public override string ToolName() => "ExtendLine";

		/// <summary>
		/// <para>Tool Excute Name : edit.ExtendLine</para>
		/// </summary>
		public override string ExcuteName() => "edit.ExtendLine";

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
		public override object[] Parameters() => new object[] { InFeatures, Length, ExtendTo, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line input features to be extended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Extend Length</para>
		/// <para>The maximum distance a line segment can be extended to an intersecting feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Length { get; set; }

		/// <summary>
		/// <para>Extend to Extensions</para>
		/// <para>Specifies whether line segments can be extended to other extended line segments within the specified extend length.</para>
		/// <para>Checked—Line segments can be extended to other extended line segments as well as existing line features. This is the default.</para>
		/// <para>Unchecked—Line segments can only be extended to existing line features.</para>
		/// <para><see cref="ExtendToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExtendTo { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtendLine SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Extend to Extensions</para>
		/// </summary>
		public enum ExtendToEnum 
		{
			/// <summary>
			/// <para>Checked—Line segments can be extended to other extended line segments as well as existing line features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTENSION")]
			EXTENSION,

			/// <summary>
			/// <para>Unchecked—Line segments can only be extended to existing line features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FEATURE")]
			FEATURE,

		}

#endregion
	}
}
