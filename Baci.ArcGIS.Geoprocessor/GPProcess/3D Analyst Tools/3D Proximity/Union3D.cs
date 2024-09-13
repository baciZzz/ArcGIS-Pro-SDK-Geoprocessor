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
	/// <para>Union 3D</para>
	/// <para>3D 联合</para>
	/// <para>基于输入要素类对闭合的重叠多面体要素进行合并。</para>
	/// </summary>
	public class Union3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Multipatch Features</para>
		/// <para>要联合的多面体要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将存储聚合要素的输出多面体要素类。</para>
		/// </param>
		public Union3D(object InFeatureClass, object OutFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 联合</para>
		/// </summary>
		public override string DisplayName() => "3D 联合";

		/// <summary>
		/// <para>Tool Name : Union3D</para>
		/// </summary>
		public override string ToolName() => "Union3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Union3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Union3D";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, OutFeatureClass, GroupField!, DisableOptimization!, OutputAll!, OutTable! };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>要联合的多面体要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将存储聚合要素的输出多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Grouping Field</para>
		/// <para>用于标识应归到一组的要素的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("OID", "Short", "Long", "Text")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Disable Optimization</para>
		/// <para>指定是否对输入数据执行优化。优化操作将会预处理输入数据，方法是对它们进行分组以提高性能并针对每个重叠要素集创建唯一输出。</para>
		/// <para>未选中 - 启用优化，但忽略分组字段。这是默认设置。</para>
		/// <para>选中 - 不对输入数据执行优化。要素会存储在单个输出要素中，或者根据其分组字段（如果提供）进行联合。</para>
		/// <para><see cref="DisableOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DisableOptimization { get; set; } = "false";

		/// <summary>
		/// <para>Output All Solids</para>
		/// <para>确定输出要素类是包含所有要素还是仅包含已联合的重叠要素。</para>
		/// <para>选中 - 将所有输入要素写到输出中。这是默认设置。</para>
		/// <para>未选中 - 仅将已联合的要素写到输出中。非重叠要素将被忽略。</para>
		/// <para><see cref="OutputAllEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? OutputAll { get; set; } = "true";

		/// <summary>
		/// <para>Output Table</para>
		/// <para>用于标识影响每个输出的输入要素的多对一表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Union3D SetEnviroment(object? XYDomain = null , object? ZDomain = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Disable Optimization</para>
		/// </summary>
		public enum DisableOptimizationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISABLE")]
			DISABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ENABLE")]
			ENABLE,

		}

		/// <summary>
		/// <para>Output All Solids</para>
		/// </summary>
		public enum OutputAllEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE")]
			ENABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE")]
			DISABLE,

		}

#endregion
	}
}
