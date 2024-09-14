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
	/// <para>Append Annotation Feature Classes</para>
	/// <para>追加注记要素类</para>
	/// <para>创建地理数据库注记要素类，或者通过合并多个输入地理数据库要素类中的注记将现有注记要素类追加到一个包含注记类的要素类中。</para>
	/// </summary>
	public class AppendAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input features</para>
		/// <para>将在输出要素类中形成注记类的输入注记要素。</para>
		/// </param>
		/// <param name="OutputFeatureclass">
		/// <para>Output feature class</para>
		/// <para>将包含各输入注记要素类的注记类的新注记要素类。</para>
		/// </param>
		/// <param name="ReferenceScale">
		/// <para>Reference scale</para>
		/// <para>在输出要素类中设置的参考比例。以不同参考比例创建的输入要素将进行变换以与此输出参考比例相匹配。</para>
		/// </param>
		public AppendAnnotation(object InputFeatures, object OutputFeatureclass, object ReferenceScale)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureclass = OutputFeatureclass;
			this.ReferenceScale = ReferenceScale;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加注记要素类</para>
		/// </summary>
		public override string DisplayName() => "追加注记要素类";

		/// <summary>
		/// <para>Tool Name : AppendAnnotation</para>
		/// </summary>
		public override string ToolName() => "AppendAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : management.AppendAnnotation</para>
		/// </summary>
		public override string ExcuteName() => "management.AppendAnnotation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatureclass, ReferenceScale, CreateSingleClass!, RequireSymbolFromTable!, CreateAnnotationWhenFeatureAdded!, UpdateAnnotationWhenFeatureModified! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>将在输出要素类中形成注记类的输入注记要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[FeatureType("Annotation")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>将包含各输入注记要素类的注记类的新注记要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureclass { get; set; }

		/// <summary>
		/// <para>Reference scale</para>
		/// <para>在输出要素类中设置的参考比例。以不同参考比例创建的输入要素将进行变换以与此输出参考比例相匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ReferenceScale { get; set; }

		/// <summary>
		/// <para>Create a single annotation class</para>
		/// <para>指定如何向输出要素类添加注记要素。</para>
		/// <para>选中 - 所有注记要素都将被聚合到输出要素类的一个注记类中。</para>
		/// <para>取消选中 - 将为输出要素类中的每个输入注记类创建单独的注记类，除非这些类的名称相同并且具有相同属性。在本例中，将对其进行合并。这是默认设置。</para>
		/// <para><see cref="CreateSingleClassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateSingleClass { get; set; } = "false";

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// <para>指定如何为新建的注记要素选择符号。</para>
		/// <para>选中 - 仅允许使用输出要素类的符号集中的符号列表来创建注记要素。</para>
		/// <para>取消选中 - 允许使用任何符号系统来创建注记要素。这是默认设置。</para>
		/// <para><see cref="RequireSymbolFromTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RequireSymbolFromTable { get; set; } = "false";

		/// <summary>
		/// <para>Create annotation when new features are added (Feature-linked only)</para>
		/// <para>仅当具有 ArcGIS Desktop Standard 和 ArcGIS Desktop Advanced 级别许可时，此参数才可用。</para>
		/// <para>指定在添加要素时是否创建关联要素的注记。</para>
		/// <para>选中 - 创建关联要素时，将使用标注引擎来创建关联要素的注记。这是默认设置。</para>
		/// <para>取消选中 - 创建要素时，将不会创建关联要素的注记。</para>
		/// <para><see cref="CreateAnnotationWhenFeatureAddedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CreateAnnotationWhenFeatureAdded { get; set; } = "true";

		/// <summary>
		/// <para>Update annotation when the shape of the linked feature is modified (Feature-linked only)</para>
		/// <para>仅当具有 ArcGIS Desktop Standard 和 ArcGIS Desktop Advanced 级别许可时，此参数才可用。</para>
		/// <para>指定在关联要素发生更改时是否更新关联要素的注记。</para>
		/// <para>选中 - 当关联要素发生更改时，将使用标注引擎来更新关联要素的注记。这是默认设置。</para>
		/// <para>取消选中 - 当关联要素发生更改时，将不会更新关联要素的注记。</para>
		/// <para><see cref="UpdateAnnotationWhenFeatureModifiedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateAnnotationWhenFeatureModified { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendAnnotation SetEnviroment(int? autoCommit = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Create a single annotation class</para>
		/// </summary>
		public enum CreateSingleClassEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONE_CLASS_ONLY")]
			ONE_CLASS_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CREATE_CLASSES")]
			CREATE_CLASSES,

		}

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// </summary>
		public enum RequireSymbolFromTableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRE_SYMBOL")]
			REQUIRE_SYMBOL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SYMBOL_REQUIRED")]
			NO_SYMBOL_REQUIRED,

		}

		/// <summary>
		/// <para>Create annotation when new features are added (Feature-linked only)</para>
		/// </summary>
		public enum CreateAnnotationWhenFeatureAddedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_CREATE")]
			AUTO_CREATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AUTO_CREATE")]
			NO_AUTO_CREATE,

		}

		/// <summary>
		/// <para>Update annotation when the shape of the linked feature is modified (Feature-linked only)</para>
		/// </summary>
		public enum UpdateAnnotationWhenFeatureModifiedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_UPDATE")]
			AUTO_UPDATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AUTO_UPDATE")]
			NO_AUTO_UPDATE,

		}

#endregion
	}
}
