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
	/// <para>Save Toolbox To Version</para>
	/// <para>将工具箱保存到版本</para>
	/// <para>分析和保存工具箱，以便与 ArcGIS 软件的特定版本配合使用。</para>
	/// </summary>
	public class SaveToolboxToVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InToolbox">
		/// <para>Input Toolbox</para>
		/// <para>将要分析并保存的输入工具箱（.tbx 或 .atbx）。 不会修改文件。</para>
		/// <para>不支持将 Python 工具箱 (.pyt) 格式作为输入。</para>
		/// </param>
		/// <param name="Version">
		/// <para>Target Version</para>
		/// <para>指定将用于工具箱兼容性问题分析的软件版本。</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.2—ArcGIS Pro 2.2 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.3—ArcGIS Pro 2.3 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.4—ArcGIS Pro 2.4 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.5—ArcGIS Pro 2.5 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.6—ArcGIS Pro 2.6 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.7—ArcGIS Pro 2.7 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.8—ArcGIS Pro 2.8 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.9—ArcGIS Pro 2.9 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// </param>
		/// <param name="OutToolbox">
		/// <para>Output Toolbox</para>
		/// <para>为了与指定的目标版本参数值对应的 ArcGIS 软件配合使用而创建的工具箱。</para>
		/// </param>
		public SaveToolboxToVersion(object InToolbox, object Version, object OutToolbox)
		{
			this.InToolbox = InToolbox;
			this.Version = Version;
			this.OutToolbox = OutToolbox;
		}

		/// <summary>
		/// <para>Tool Display Name : 将工具箱保存到版本</para>
		/// </summary>
		public override string DisplayName() => "将工具箱保存到版本";

		/// <summary>
		/// <para>Tool Name : SaveToolboxToVersion</para>
		/// </summary>
		public override string ToolName() => "SaveToolboxToVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.SaveToolboxToVersion</para>
		/// </summary>
		public override string ExcuteName() => "management.SaveToolboxToVersion";

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
		public override object[] Parameters() => new object[] { InToolbox, Version, OutToolbox, MissingTool!, MissingParam!, InvalidParamValue! };

		/// <summary>
		/// <para>Input Toolbox</para>
		/// <para>将要分析并保存的输入工具箱（.tbx 或 .atbx）。 不会修改文件。</para>
		/// <para>不支持将 Python 工具箱 (.pyt) 格式作为输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEToolbox()]
		public object InToolbox { get; set; }

		/// <summary>
		/// <para>Target Version</para>
		/// <para>指定将用于工具箱兼容性问题分析的软件版本。</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.2—ArcGIS Pro 2.2 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.3—ArcGIS Pro 2.3 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.4—ArcGIS Pro 2.4 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.5—ArcGIS Pro 2.5 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.6—ArcGIS Pro 2.6 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.7—ArcGIS Pro 2.7 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.8—ArcGIS Pro 2.8 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// <para>2.9—ArcGIS Pro 2.9 将用于工具箱兼容性问题分析。 输出工具箱将保存到此版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Output Toolbox</para>
		/// <para>为了与指定的目标版本参数值对应的 ArcGIS 软件配合使用而创建的工具箱。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEToolbox()]
		public object OutToolbox { get; set; }

		/// <summary>
		/// <para>Error on missing tool</para>
		/// <para>指定如果遇到目标版本中不存在的工具，操作是否生成错误。</para>
		/// <para>选中 - 如果遇到目标版本中不存在的工具，操作将生成错误并且不会创建输出工具箱。 这是默认设置。</para>
		/// <para>未选中 - 如果遇到目标版本中不存在的工具，操作将生成警告消息并创建输出工具箱。 对于模型工具，问题工具将从模型中移除，这需要手动编辑。</para>
		/// <para><see cref="MissingToolEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MissingTool { get; set; } = "true";

		/// <summary>
		/// <para>Error on missing required parameter</para>
		/// <para>指定如果遇到目标版本中不存在的参数并且该参数的值不是其默认值，操作是否生成错误。</para>
		/// <para>选中 - 如果遇到目标版本中不存在的参数并且该参数的值不是其默认值，操作将生成错误并且不会创建输出工具箱。 这是默认设置。</para>
		/// <para>未选中 - 如果遇到目标版本中不存在的参数并且该参数的值不是其默认值，操作将从模型中移除该参数并创建输出工具箱。</para>
		/// <para><see cref="MissingParamEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MissingParam { get; set; } = "true";

		/// <summary>
		/// <para>Error on invalid parameter value</para>
		/// <para>指定如果遇到目标版本的参数过滤器中不存在的参数值，操作是否生成错误。</para>
		/// <para>选中 - 如果遇到目标版本的参数过滤器中不存在的参数值，操作将生成错误并且不会创建输出工具箱。 这是默认设置。</para>
		/// <para>未选中 - 如果遇到目标版本的参数过滤器中不存在的参数值，操作将继续并发出警告，且将创建输出工具箱。 如果输出工具箱具有不在域范围内或无效的值，则会生成错误。</para>
		/// <para><see cref="InvalidParamValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InvalidParamValue { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Error on missing tool</para>
		/// </summary>
		public enum MissingToolEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_ON_MISSING_TOOL")]
			ERROR_ON_MISSING_TOOL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("WARN_ON_MISSING_TOOL")]
			WARN_ON_MISSING_TOOL,

		}

		/// <summary>
		/// <para>Error on missing required parameter</para>
		/// </summary>
		public enum MissingParamEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_ON_MISSING_REQUIRED_PARAM")]
			ERROR_ON_MISSING_REQUIRED_PARAM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("WARN_ON_MISSING_REQUIRED_PARAM")]
			WARN_ON_MISSING_REQUIRED_PARAM,

		}

		/// <summary>
		/// <para>Error on invalid parameter value</para>
		/// </summary>
		public enum InvalidParamValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ERROR_ON_INVALID_PARAM_VALUE")]
			ERROR_ON_INVALID_PARAM_VALUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("WARN_ON_INVALID_PARAM_VALUE")]
			WARN_ON_INVALID_PARAM_VALUE,

		}

#endregion
	}
}
