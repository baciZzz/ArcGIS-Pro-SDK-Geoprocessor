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
	/// <para>Erase Point</para>
	/// <para>Deletes points from the input that are either inside or outside the Remove Features, depending on the Operation Type.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ErasePoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point features.</para>
		/// </param>
		/// <param name="RemoveFeatures">
		/// <para>Remove Features</para>
		/// <para>Input features inside or outside the Remove Features will be deleted, depending on the Operation Type parameter.</para>
		/// </param>
		public ErasePoint(object InFeatures, object RemoveFeatures)
		{
			this.InFeatures = InFeatures;
			this.RemoveFeatures = RemoveFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Erase Point</para>
		/// </summary>
		public override string DisplayName() => "Erase Point";

		/// <summary>
		/// <para>Tool Name : ErasePoint</para>
		/// </summary>
		public override string ToolName() => "ErasePoint";

		/// <summary>
		/// <para>Tool Excute Name : edit.ErasePoint</para>
		/// </summary>
		public override string ExcuteName() => "edit.ErasePoint";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, RemoveFeatures, OperationType, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Remove Features</para>
		/// <para>Input features inside or outside the Remove Features will be deleted, depending on the Operation Type parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object RemoveFeatures { get; set; }

		/// <summary>
		/// <para>Operation Type</para>
		/// <para>Determines if points inside or outside the remove features will be deleted.</para>
		/// <para>Inside—Input point features inside or on the boundary of the remove features will be deleted.</para>
		/// <para>Outside—Input point features outside the remove features will be deleted.</para>
		/// <para><see cref="OperationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OperationType { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ErasePoint SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Operation Type</para>
		/// </summary>
		public enum OperationTypeEnum 
		{
			/// <summary>
			/// <para>Inside—Input point features inside or on the boundary of the remove features will be deleted.</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("Inside")]
			Inside,

			/// <summary>
			/// <para>Outside—Input point features outside the remove features will be deleted.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

#endregion
	}
}
