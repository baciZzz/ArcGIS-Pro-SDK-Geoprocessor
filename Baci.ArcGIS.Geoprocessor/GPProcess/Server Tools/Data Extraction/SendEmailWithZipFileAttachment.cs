using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Send Email With Zip File Attachment</para>
	/// <para>发送电子邮件（附 Zip 文件）</para>
	/// <para>使用 SMTP 电子邮件服务器将文件以电子邮件形式发送到某个电子邮件地址。</para>
	/// </summary>
	public class SendEmailWithZipFileAttachment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="To">
		/// <para>To</para>
		/// <para>收件人的电子邮件地址。</para>
		/// </param>
		/// <param name="From">
		/// <para>From</para>
		/// <para>发件人的电子邮件地址。</para>
		/// </param>
		/// <param name="Subject">
		/// <para>Subject</para>
		/// <para>电子邮件主题文字。</para>
		/// </param>
		/// <param name="Text">
		/// <para>Text</para>
		/// <para>电子邮件的正文文字。</para>
		/// </param>
		/// <param name="ZipFile">
		/// <para>Zip File</para>
		/// <para>电子邮件的附件。</para>
		/// </param>
		/// <param name="MaxFileSizeMB">
		/// <para>Max File Size (MB)</para>
		/// <para>附件大小的上限。</para>
		/// <para>如果不确定应将“文件最大大小”设置为什么值，请参考 SMTP 电子邮件服务器和收件人电子邮件提供方的附件大小限制。</para>
		/// </param>
		/// <param name="SMTPEmailServer">
		/// <para>SMTP Email Server</para>
		/// <para>传送电子邮件的 SMTP 电子邮件服务器。</para>
		/// </param>
		public SendEmailWithZipFileAttachment(object To, object From, object Subject, object Text, object ZipFile, object MaxFileSizeMB, object SMTPEmailServer)
		{
			this.To = To;
			this.From = From;
			this.Subject = Subject;
			this.Text = Text;
			this.ZipFile = ZipFile;
			this.MaxFileSizeMB = MaxFileSizeMB;
			this.SMTPEmailServer = SMTPEmailServer;
		}

		/// <summary>
		/// <para>Tool Display Name : 发送电子邮件（附 Zip 文件）</para>
		/// </summary>
		public override string DisplayName() => "发送电子邮件（附 Zip 文件）";

		/// <summary>
		/// <para>Tool Name : SendEmailWithZipFileAttachment</para>
		/// </summary>
		public override string ToolName() => "SendEmailWithZipFileAttachment";

		/// <summary>
		/// <para>Tool Excute Name : server.SendEmailWithZipFileAttachment</para>
		/// </summary>
		public override string ExcuteName() => "server.SendEmailWithZipFileAttachment";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { To, From, Subject, Text, ZipFile, MaxFileSizeMB, SMTPEmailServer, User!, Password!, Sent! };

		/// <summary>
		/// <para>To</para>
		/// <para>收件人的电子邮件地址。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object To { get; set; }

		/// <summary>
		/// <para>From</para>
		/// <para>发件人的电子邮件地址。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object From { get; set; }

		/// <summary>
		/// <para>Subject</para>
		/// <para>电子邮件主题文字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Subject { get; set; }

		/// <summary>
		/// <para>Text</para>
		/// <para>电子邮件的正文文字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Text { get; set; }

		/// <summary>
		/// <para>Zip File</para>
		/// <para>电子邮件的附件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object ZipFile { get; set; }

		/// <summary>
		/// <para>Max File Size (MB)</para>
		/// <para>附件大小的上限。</para>
		/// <para>如果不确定应将“文件最大大小”设置为什么值，请参考 SMTP 电子邮件服务器和收件人电子邮件提供方的附件大小限制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MaxFileSizeMB { get; set; }

		/// <summary>
		/// <para>SMTP Email Server</para>
		/// <para>传送电子邮件的 SMTP 电子邮件服务器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SMTPEmailServer { get; set; }

		/// <summary>
		/// <para>User</para>
		/// <para>将登录到 SMTP 电子邮件服务器的用户。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? User { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>连接到 SMTP 电子邮件服务器所使用的用户密码（如有必要）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Password { get; set; }

		/// <summary>
		/// <para>Send Email Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? Sent { get; set; }

	}
}
