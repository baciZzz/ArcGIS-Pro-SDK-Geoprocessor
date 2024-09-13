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
	/// <para>Standardize Field</para>
	/// <para>标准化字段</para>
	/// <para>通过将字段中的值转换为遵循指定比例的值来标准化这些值。标准化方法包括 z 得分、最小值-最大值、最大绝对值和稳健标准化。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class StandardizeField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>表格，其中包含具有要标准化的值的字段。</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Field to Standardize</para>
		/// <para>包含要标准化的值的字段。对于每个字段，可以指定输出字段名称。如果未提供输出字段名称，则该工具将使用字段名称和所选方法来创建输出字段名称。</para>
		/// </param>
		public StandardizeField(object InTable, object Fields)
		{
			this.InTable = InTable;
			this.Fields = Fields;
		}

		/// <summary>
		/// <para>Tool Display Name : 标准化字段</para>
		/// </summary>
		public override string DisplayName() => "标准化字段";

		/// <summary>
		/// <para>Tool Name : StandardizeField</para>
		/// </summary>
		public override string ToolName() => "StandardizeField";

		/// <summary>
		/// <para>Tool Excute Name : management.StandardizeField</para>
		/// </summary>
		public override string ExcuteName() => "management.StandardizeField";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Fields, Method!, MinValue!, MaxValue!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>表格，其中包含具有要标准化的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field to Standardize</para>
		/// <para>包含要标准化的值的字段。对于每个字段，可以指定输出字段名称。如果未提供输出字段名称，则该工具将使用字段名称和所选方法来创建输出字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Standardization Method</para>
		/// <para>指定用于标准化指定字段中包含的值的方法。</para>
		/// <para>Z 得分—将使用标准得分，即高于或低于平均值的标准差的数量。计算为 Z 得分公式，该公式将计算某列中的值与平均值之间的差值，然后除以列中的值的标准差。这是默认设置。</para>
		/// <para>最小值 - 最大值—这些值将转换为用户指定的最小值和最大值之间的比例。</para>
		/// <para>绝对最大值—将该列中的每个值除以该列中的最大绝对值。</para>
		/// <para>稳健标准化— Z 得分公式的稳健变体可用于标准化指定字段中的值。此变量将使用中位数和四分位数范围来代替平均值和标准差。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "Z-SCORE";

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>标准化方法参数的最小值-最大值方法所使用的值，用于指定所提供输出值的比例中的最小值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinValue { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>标准化方法参数的最小值-最大值方法所使用的值，用于指定所提供输出值的比例中的最大值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxValue { get; set; } = "1";

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StandardizeField SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Standardization Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Z 得分—将使用标准得分，即高于或低于平均值的标准差的数量。计算为 Z 得分公式，该公式将计算某列中的值与平均值之间的差值，然后除以列中的值的标准差。这是默认设置。</para>
			/// </summary>
			[GPValue("Z-SCORE")]
			[Description("Z 得分")]
			Z_SCORE,

			/// <summary>
			/// <para>最小值 - 最大值—这些值将转换为用户指定的最小值和最大值之间的比例。</para>
			/// </summary>
			[GPValue("MIN-MAX")]
			[Description("最小值 - 最大值")]
			MIN_MAX,

			/// <summary>
			/// <para>绝对最大值—将该列中的每个值除以该列中的最大绝对值。</para>
			/// </summary>
			[GPValue("MAXABS")]
			[Description("绝对最大值")]
			Absolute_maximum,

			/// <summary>
			/// <para>稳健标准化— Z 得分公式的稳健变体可用于标准化指定字段中的值。此变量将使用中位数和四分位数范围来代替平均值和标准差。</para>
			/// </summary>
			[GPValue("ROBUST")]
			[Description("稳健标准化")]
			Robust_standardization,

		}

#endregion
	}
}
