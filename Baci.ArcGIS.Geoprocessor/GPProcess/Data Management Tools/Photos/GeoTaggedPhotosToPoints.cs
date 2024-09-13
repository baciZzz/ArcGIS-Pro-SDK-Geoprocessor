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
	/// <para>GeoTagged Photos To Points</para>
	/// <para>地理标记照片转点</para>
	/// <para>根据存储在地理标记照片中的 x、y 和 z 坐标创建点。或者，也可以将照片文件作为地理数据库附件添加到输出要素类的要素中。</para>
	/// </summary>
	public class GeoTaggedPhotosToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFolder">
		/// <para>Input Folder</para>
		/// <para>照片文件所在的文件夹。此文件夹是递归扫描照片文件得到的；基础等级文件夹以及任何子文件夹中的所有照片都将被添加到输出中。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出点要素类。</para>
		/// </param>
		public GeoTaggedPhotosToPoints(object InputFolder, object OutputFeatureClass)
		{
			this.InputFolder = InputFolder;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 地理标记照片转点</para>
		/// </summary>
		public override string DisplayName() => "地理标记照片转点";

		/// <summary>
		/// <para>Tool Name : GeoTaggedPhotosToPoints</para>
		/// </summary>
		public override string ToolName() => "GeoTaggedPhotosToPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.GeoTaggedPhotosToPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.GeoTaggedPhotosToPoints";

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
		public override string[] ValidEnvironments() => new string[] { "outputZFlag", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFolder, OutputFeatureClass, InvalidPhotosTable!, IncludeNonGeotaggedPhotos!, AddPhotosAsAttachments! };

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>照片文件所在的文件夹。此文件夹是递归扫描照片文件得到的；基础等级文件夹以及任何子文件夹中的所有照片都将被添加到输出中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InputFolder { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Invalid Photos Table</para>
		/// <para>可选的输出表，将列出输入文件夹中所有包含无效 Exif 元数据或者空或无效坐标的照片文件。</para>
		/// <para>如果未指定路径，则不会创建此表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? InvalidPhotosTable { get; set; }

		/// <summary>
		/// <para>Include Non-GeoTagged Photos</para>
		/// <para>指定是将所有照片文件都包含在输出要素类中，还是仅包含坐标有效的照片文件。</para>
		/// <para>选中 - 所有照片将作为记录添加到输出要素类中。如果某个照片文件不含坐标信息，则会将其作为几何为空的要素进行添加。这是默认设置。</para>
		/// <para>未选中 - 仅具有有效坐标信息的照片将包含在输出要素类中。</para>
		/// <para><see cref="IncludeNonGeotaggedPhotosEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeNonGeotaggedPhotos { get; set; } = "true";

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// <para>指定是否将输入照片作为地理数据库附件添加到输出中。</para>
		/// <para>添加附件时，需要 ArcGIS Desktop Standard 或更高版本的许可，并且输出要素类必须位于 10 或更高版本的地理数据库中。</para>
		/// <para>选中 - 照片将作为内部复制到地理数据库的地理数据库附件添加到输出要素中。这是默认设置。</para>
		/// <para>未选中 - 照片不会作为地理数据库附件添加到输出要素中。</para>
		/// <para><see cref="AddPhotosAsAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddPhotosAsAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeoTaggedPhotosToPoints SetEnviroment(object? outputZFlag = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(outputZFlag: outputZFlag, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Non-GeoTagged Photos</para>
		/// </summary>
		public enum IncludeNonGeotaggedPhotosEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_PHOTOS")]
			ALL_PHOTOS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_GEOTAGGED")]
			ONLY_GEOTAGGED,

		}

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// </summary>
		public enum AddPhotosAsAttachmentsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_ATTACHMENTS")]
			ADD_ATTACHMENTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTACHMENTS")]
			NO_ATTACHMENTS,

		}

#endregion
	}
}
