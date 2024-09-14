using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Modify Network Calibration Rules</para>
	/// <para>修改网络校准规则</para>
	/// <para>修改 LRS 网络的网络校准规则。</para>
	/// </summary>
	public class ModifyNetworkCalibrationRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>输入 LRS 网络要素类。</para>
		/// </param>
		public ModifyNetworkCalibrationRules(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 修改网络校准规则</para>
		/// </summary>
		public override string DisplayName() => "修改网络校准规则";

		/// <summary>
		/// <para>Tool Name : ModifyNetworkCalibrationRules</para>
		/// </summary>
		public override string ToolName() => "ModifyNetworkCalibrationRules";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyNetworkCalibrationRules</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyNetworkCalibrationRules";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, CalibrationRule!, CalibrationOffset!, OutFeatureClass!, UpdateMeasureCartorealign! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>输入 LRS 网络要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Calibration Rule</para>
		/// <para>指定将用于定义校准间距测量值的方法。</para>
		/// <para>保留原样—更改校准偏移值时将使用网络中现有定义的方法。</para>
		/// <para>添加欧氏距离—将沿编辑路径在每个物理间距处计算并添加欧氏距离或直线距离。</para>
		/// <para>步进增量—将定义一个值，用于在路径中的每个物理间距处进行调整或步进。 这是默认设置。</para>
		/// <para>添加增量—除了路径起点和终点测量值间的总长度之外，还可以定义该值并将其添加到每个物理间距处每个路径测量值。</para>
		/// <para><see cref="CalibrationRuleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CalibrationRule { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Calibration Offset</para>
		/// <para>校准规则参数中添加增量或步进增量方法的值。 增量值必须是数值并且可以包含小数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? CalibrationOffset { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Update route measures in cartographic realignment</para>
		/// <para>指定是否根据制图重新对齐中的长度变化重新校准路径测量值。</para>
		/// <para>保留原样—将使用网络中现有定义的方法。 这是默认设置。</para>
		/// <para>启用—启用根据制图重新对齐中的长度变化重新校准路径测量值。</para>
		/// <para>禁用—禁用根据制图重新对齐中的长度变化重新校准路径测量值。</para>
		/// <para><see cref="UpdateMeasureCartorealignEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? UpdateMeasureCartorealign { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyNetworkCalibrationRules SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Calibration Rule</para>
		/// </summary>
		public enum CalibrationRuleEnum 
		{
			/// <summary>
			/// <para>保留原样—更改校准偏移值时将使用网络中现有定义的方法。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_Is,

			/// <summary>
			/// <para>添加欧氏距离—将沿编辑路径在每个物理间距处计算并添加欧氏距离或直线距离。</para>
			/// </summary>
			[GPValue("ADDING_EUCLIDEAN_DISTANCE")]
			[Description("添加欧氏距离")]
			Adding_Euclidean_Distance,

			/// <summary>
			/// <para>步进增量—将定义一个值，用于在路径中的每个物理间距处进行调整或步进。 这是默认设置。</para>
			/// </summary>
			[GPValue("STEPPING_INCREMENT")]
			[Description("步进增量")]
			Stepping_Increment,

			/// <summary>
			/// <para>添加增量—除了路径起点和终点测量值间的总长度之外，还可以定义该值并将其添加到每个物理间距处每个路径测量值。</para>
			/// </summary>
			[GPValue("ADDING_INCREMENT")]
			[Description("添加增量")]
			Adding_Increment,

		}

		/// <summary>
		/// <para>Update route measures in cartographic realignment</para>
		/// </summary>
		public enum UpdateMeasureCartorealignEnum 
		{
			/// <summary>
			/// <para>保留原样—将使用网络中现有定义的方法。 这是默认设置。</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("保留原样")]
			As_is,

			/// <summary>
			/// <para>启用—启用根据制图重新对齐中的长度变化重新校准路径测量值。</para>
			/// </summary>
			[GPValue("ENABLE")]
			[Description("启用")]
			Enable,

			/// <summary>
			/// <para>禁用—禁用根据制图重新对齐中的长度变化重新校准路径测量值。</para>
			/// </summary>
			[GPValue("DISABLE")]
			[Description("禁用")]
			Disable,

		}

#endregion
	}
}
