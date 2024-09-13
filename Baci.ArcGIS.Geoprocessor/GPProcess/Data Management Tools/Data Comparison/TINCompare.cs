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
	/// <para>TIN Compare</para>
	/// <para>TIN 比较</para>
	/// <para>比较两个 TIN 并返回比较结果。</para>
	/// </summary>
	public class TINCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseTin">
		/// <para>Input Base Tin</para>
		/// <para>“输入基础 TIN”与“输入测试 TIN”进行比较。“输入基础 TIN”是指已被您声明为有效的数据。该基础数据具有正确的几何、标记值（如果存在）和空间参考。</para>
		/// </param>
		/// <param name="InTestTin">
		/// <para>Input Test Tin</para>
		/// <para>“输入测试 TIN”与“输入基础 TIN”进行比较。</para>
		/// </param>
		public TINCompare(object InBaseTin, object InTestTin)
		{
			this.InBaseTin = InBaseTin;
			this.InTestTin = InTestTin;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN 比较</para>
		/// </summary>
		public override string DisplayName() => "TIN 比较";

		/// <summary>
		/// <para>Tool Name : TINCompare</para>
		/// </summary>
		public override string ToolName() => "TINCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.TINCompare</para>
		/// </summary>
		public override string ExcuteName() => "management.TINCompare";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBaseTin, InTestTin, CompareType, ContinueCompare, OutCompareFile, CompareStatus };

		/// <summary>
		/// <para>Input Base Tin</para>
		/// <para>“输入基础 TIN”与“输入测试 TIN”进行比较。“输入基础 TIN”是指已被您声明为有效的数据。该基础数据具有正确的几何、标记值（如果存在）和空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InBaseTin { get; set; }

		/// <summary>
		/// <para>Input Test Tin</para>
		/// <para>“输入测试 TIN”与“输入基础 TIN”进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTestTin { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>比较类型。</para>
		/// <para>所有—这是默认设置。</para>
		/// <para>仅限属性—如果存在几何和 TIN 标记值，则会被指定给结点和三角形。</para>
		/// <para>仅限空间参考—坐标系信息。</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompareType { get; set; } = "ALL";

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>指示在遇到第一个不匹配项后是否继续比较所有属性。</para>
		/// <para>未选中 - 在遇到第一个不匹配项后即停止比较。这是默认设置。</para>
		/// <para>选中 - 在遇到第一个不匹配项后继续比较其他属性。</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>包含比较结果的文本文件的名称和路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareStatus { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>所有—这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>仅限属性—如果存在几何和 TIN 标记值，则会被指定给结点和三角形。</para>
			/// </summary>
			[GPValue("PROPERTIES_ONLY")]
			[Description("仅限属性")]
			Properties_only,

			/// <summary>
			/// <para>仅限空间参考—坐标系信息。</para>
			/// </summary>
			[GPValue("SPATIAL_REFERENCE_ONLY")]
			[Description("仅限空间参考")]
			Spatial_Reference_only,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
