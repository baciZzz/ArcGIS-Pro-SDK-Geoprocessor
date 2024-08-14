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
	/// <para>Emails a file to an email address using an SMTP email server.</para>
	/// </summary>
	public class SendEmailWithZipFileAttachment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="To">
		/// <para>To</para>
		/// <para>The email address of the recipient.</para>
		/// </param>
		/// <param name="From">
		/// <para>From</para>
		/// <para>The email address of the sender.</para>
		/// </param>
		/// <param name="Subject">
		/// <para>Subject</para>
		/// <para>The text in the subject line of the email.</para>
		/// </param>
		/// <param name="Text">
		/// <para>Text</para>
		/// <para>The body text of the email.</para>
		/// </param>
		/// <param name="ZipFile">
		/// <para>Zip File</para>
		/// <para>The file to be attached to the email.</para>
		/// </param>
		/// <param name="MaxFileSizeMB">
		/// <para>Max File Size (MB)</para>
		/// <para>The maximum allowable size of an attachment.</para>
		/// <para>If you don&apos;t know what to use for Max File Size, check the attachment size limit of your SMTP mail server and the recipient email provider.</para>
		/// </param>
		/// <param name="SMTPEmailServer">
		/// <para>SMTP Email Server</para>
		/// <para>The SMTP email server that will deliver the email.</para>
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
		/// <para>Tool Display Name : Send Email With Zip File Attachment</para>
		/// </summary>
		public override string DisplayName => "Send Email With Zip File Attachment";

		/// <summary>
		/// <para>Tool Name : SendEmailWithZipFileAttachment</para>
		/// </summary>
		public override string ToolName => "SendEmailWithZipFileAttachment";

		/// <summary>
		/// <para>Tool Excute Name : server.SendEmailWithZipFileAttachment</para>
		/// </summary>
		public override string ExcuteName => "server.SendEmailWithZipFileAttachment";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { To, From, Subject, Text, ZipFile, MaxFileSizeMB, SMTPEmailServer, User!, Password!, Sent! };

		/// <summary>
		/// <para>To</para>
		/// <para>The email address of the recipient.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object To { get; set; }

		/// <summary>
		/// <para>From</para>
		/// <para>The email address of the sender.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object From { get; set; }

		/// <summary>
		/// <para>Subject</para>
		/// <para>The text in the subject line of the email.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Subject { get; set; }

		/// <summary>
		/// <para>Text</para>
		/// <para>The body text of the email.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Text { get; set; }

		/// <summary>
		/// <para>Zip File</para>
		/// <para>The file to be attached to the email.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object ZipFile { get; set; }

		/// <summary>
		/// <para>Max File Size (MB)</para>
		/// <para>The maximum allowable size of an attachment.</para>
		/// <para>If you don&apos;t know what to use for Max File Size, check the attachment size limit of your SMTP mail server and the recipient email provider.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MaxFileSizeMB { get; set; }

		/// <summary>
		/// <para>SMTP Email Server</para>
		/// <para>The SMTP email server that will deliver the email.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SMTPEmailServer { get; set; }

		/// <summary>
		/// <para>User</para>
		/// <para>The user which will log in to the SMTP email server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? User { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>The user password used to connect to the SMTP email server (if necessary).</para>
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
