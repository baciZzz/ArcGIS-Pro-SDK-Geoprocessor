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
	/// <para>Match Photos To Rows By Time</para>
	/// <para>按时间将照片与行匹配</para>
	/// <para>根据照片与行时间戳将照片文件匹配至表或要素类的行。具有时间戳最接近于照片捕捉时间的行将与此照片相匹配。接下来将根据输入的行以及所匹配的照片的路径创建一个包含 ObjectIDs 的新表。也可以将匹配的照片文件作为地理数据库附件添加到输入表的行记录中。</para>
	/// </summary>
	public class MatchPhotosToRowsByTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFolder">
		/// <para>Input Folder</para>
		/// <para>照片文件所在的文件夹。此文件夹是递归扫描照片文件得到的；基础等级文件夹以及任何子文件夹中的所有照片都将被添加到输出中。</para>
		/// </param>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>表或要素类，其行将与照片文件相匹配。输入表通常是一个表示 GPS 记录的点要素类。</para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>输入表中的日期/时间字段，用于指示各行的捕获或创建时间。必须是日期字段；不能是字符串或数值型字段。</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>输出表，其中包含与照片相匹配的输入表的 OBJECTID 以及相匹配的照片路径。输出表中仅包含与照片匹配的输入表的 OBJECTID。</para>
		/// </param>
		public MatchPhotosToRowsByTime(object InputFolder, object InputTable, object TimeField, object OutputTable)
		{
			this.InputFolder = InputFolder;
			this.InputTable = InputTable;
			this.TimeField = TimeField;
			this.OutputTable = OutputTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 按时间将照片与行匹配</para>
		/// </summary>
		public override string DisplayName() => "按时间将照片与行匹配";

		/// <summary>
		/// <para>Tool Name : MatchPhotosToRowsByTime</para>
		/// </summary>
		public override string ToolName() => "MatchPhotosToRowsByTime";

		/// <summary>
		/// <para>Tool Excute Name : management.MatchPhotosToRowsByTime</para>
		/// </summary>
		public override string ExcuteName() => "management.MatchPhotosToRowsByTime";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFolder, InputTable, TimeField, OutputTable, UnmatchedPhotosTable, AddPhotosAsAttachments, TimeTolerance, ClockOffset };

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>照片文件所在的文件夹。此文件夹是递归扫描照片文件得到的；基础等级文件夹以及任何子文件夹中的所有照片都将被添加到输出中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InputFolder { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>表或要素类，其行将与照片文件相匹配。输入表通常是一个表示 GPS 记录的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>输入表中的日期/时间字段，用于指示各行的捕获或创建时间。必须是日期字段；不能是字符串或数值型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表，其中包含与照片相匹配的输入表的 OBJECTID 以及相匹配的照片路径。输出表中仅包含与照片匹配的输入表的 OBJECTID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Unmatched Photos Table</para>
		/// <para>可选输出表，其中将列出具有无效时间戳的输入文件夹中的任何照片文件，或因没有在时间容差范围内的输入行而无法匹配的任何照片。</para>
		/// <para>如果未指定路径，则不会创建此表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object UnmatchedPhotosTable { get; set; }

		/// <summary>
		/// <para>Add Photos As Attachments</para>
		/// <para>指定照片文件是否将作为地理数据库附件添加到输入表的行中。要将照片文件作为附件进行添加，输入表必须存储在 10 或更高版本的地理数据库中。</para>
		/// <para>选中 - 照片文件将作为地理数据库附件添加到输入表的行中。地理数据库附件被内部复制到地理数据库中。这是默认设置。</para>
		/// <para>未选中 - 照片文件将不作为地理数据库附件添加到输入表的行中。</para>
		/// <para><see cref="AddPhotosAsAttachmentsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddPhotosAsAttachments { get; set; } = "true";

		/// <summary>
		/// <para>Time Tolerance</para>
		/// <para>匹配的输入行和照片文件的日期/时间之间的最大差异（以秒为单位）。如果输入行和照片文件的时间戳差异超出该容差值，则不会发生匹配。要将照片文件与具有最接近时间戳的行匹配，无论日期/时间差异有多大，请将容差设置为 0。此值的符号（- 或 +）无关紧要；将使用指定数值的绝对值。</para>
		/// <para>不要使用此参数进行调整以实现 GPS 和数码相机记录的时间之间一致的转换或偏移。请使用时钟偏移参数或转换时区工具转换输入行的时间戳，来匹配照片的时间戳。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object TimeTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Clock Offset</para>
		/// <para>用来捕获照片的数码相机和 GPS 装置的内部时钟之间的差异（以秒为单位）。如果数码相机的时钟在 GPS 装置的时钟之后，请使用正值；如果数码相机的时钟在 GPS 装置的时钟之前，请使用负值。</para>
		/// <para>例如，如果具有时间戳 11:35:17 的照片应匹配至具有时间戳 11:35:32 的行，请使用时钟偏移 15。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ClockOffset { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MatchPhotosToRowsByTime SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

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
