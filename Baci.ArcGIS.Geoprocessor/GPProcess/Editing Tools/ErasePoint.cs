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
	/// <para>擦除点</para>
	/// <para>从输入中删除移除要素之内或之外的点，具体取决于操作类型。</para>
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
		/// <para>输入点要素。</para>
		/// </param>
		/// <param name="RemoveFeatures">
		/// <para>Remove Features</para>
		/// <para>将用于确定要从输入要素值中删除的要素的面要素。</para>
		/// </param>
		public ErasePoint(object InFeatures, object RemoveFeatures)
		{
			this.InFeatures = InFeatures;
			this.RemoveFeatures = RemoveFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 擦除点</para>
		/// </summary>
		public override string DisplayName() => "擦除点";

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
		public override object[] Parameters() => new object[] { InFeatures, RemoveFeatures, OperationType!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Remove Features</para>
		/// <para>将用于确定要从输入要素值中删除的要素的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object RemoveFeatures { get; set; }

		/// <summary>
		/// <para>Operation Type</para>
		/// <para>指定将删除移除要素内部还是外部的点。</para>
		/// <para>内部—将删除“移除要素”内部或边界上的输入点要素。</para>
		/// <para>外部—将删除“移除要素”之外的输入点要素。</para>
		/// <para><see cref="OperationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OperationType { get; set; } = "INSIDE";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ErasePoint SetEnviroment(object? workspace = null )
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
			/// <para>内部—将删除“移除要素”内部或边界上的输入点要素。</para>
			/// </summary>
			[GPValue("INSIDE")]
			[Description("内部")]
			Inside,

			/// <summary>
			/// <para>外部—将删除“移除要素”之外的输入点要素。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("外部")]
			Outside,

		}

#endregion
	}
}
