using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Set Feature Class Split Model</para>
	/// <para>设置要素类分割模型</para>
	/// <para>用于定义要素类上分割操作的行为。</para>
	/// </summary>
	public class SetFeatureClassSplitModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将在其上设置分割模型的要素类。</para>
		/// </param>
		public SetFeatureClassSplitModel(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置要素类分割模型</para>
		/// </summary>
		public override string DisplayName() => "设置要素类分割模型";

		/// <summary>
		/// <para>Tool Name : SetFeatureClassSplitModel</para>
		/// </summary>
		public override string ToolName() => "SetFeatureClassSplitModel";

		/// <summary>
		/// <para>Tool Excute Name : management.SetFeatureClassSplitModel</para>
		/// </summary>
		public override string ExcuteName() => "management.SetFeatureClassSplitModel";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, SplitModel, OutFeatureClass };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将在其上设置分割模型的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Split Model</para>
		/// <para>指定要应用于输入要素类的分割模型。</para>
		/// <para>删除/插入/插入—将删除原始要素，并且将插入分割要素的两个部件作为新要素，并在表中新增两行。</para>
		/// <para>更新/插入—原始要素将进行更新，成为最大的要素，并且较小的要素将作为新行插入表中。这是默认设置。</para>
		/// <para><see cref="SplitModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SplitModel { get; set; } = "UPDATE_INSERT";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Split Model</para>
		/// </summary>
		public enum SplitModelEnum 
		{
			/// <summary>
			/// <para>删除/插入/插入—将删除原始要素，并且将插入分割要素的两个部件作为新要素，并在表中新增两行。</para>
			/// </summary>
			[GPValue("DELETE_INSERT_INSERT")]
			[Description("删除/插入/插入")]
			DELETE_INSERT_INSERT,

			/// <summary>
			/// <para>更新/插入—原始要素将进行更新，成为最大的要素，并且较小的要素将作为新行插入表中。这是默认设置。</para>
			/// </summary>
			[GPValue("UPDATE_INSERT")]
			[Description("更新/插入")]
			UPDATE_INSERT,

		}

#endregion
	}
}
