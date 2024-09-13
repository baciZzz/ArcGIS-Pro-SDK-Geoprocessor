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
	/// <para>Generate Transects Along Lines</para>
	/// <para>沿线生成样带</para>
	/// <para>将沿线以固定间隔创建垂直样带线。</para>
	/// </summary>
	public class GenerateTransectsAlongLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将沿其生成垂直样带线的线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>沿输入要素生成的输出垂直样带线。</para>
		/// </param>
		/// <param name="Interval">
		/// <para>Distance Between Transects</para>
		/// <para>样带将放置于距离要素始点的间隔。</para>
		/// </param>
		/// <param name="TransectLength">
		/// <para>Transect Length</para>
		/// <para>样带线的长度或宽度。将沿输入线放置每条样带，放置方式为其一半长度落在线的一侧，另一半长度落在线的另一侧。</para>
		/// <para>这是每条样带线的总长度，而非样带从输入线延伸的距离。要指定样带线应从输入线延伸的距离（例如 100 米），请将此值乘以 2 以指定样带长度（200 米）。</para>
		/// </param>
		public GenerateTransectsAlongLines(object InFeatures, object OutFeatureClass, object Interval, object TransectLength)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Interval = Interval;
			this.TransectLength = TransectLength;
		}

		/// <summary>
		/// <para>Tool Display Name : 沿线生成样带</para>
		/// </summary>
		public override string DisplayName() => "沿线生成样带";

		/// <summary>
		/// <para>Tool Name : GenerateTransectsAlongLines</para>
		/// </summary>
		public override string ToolName() => "GenerateTransectsAlongLines";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateTransectsAlongLines</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateTransectsAlongLines";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Interval, TransectLength, IncludeEnds };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将沿其生成垂直样带线的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>沿输入要素生成的输出垂直样带线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Between Transects</para>
		/// <para>样带将放置于距离要素始点的间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Interval { get; set; }

		/// <summary>
		/// <para>Transect Length</para>
		/// <para>样带线的长度或宽度。将沿输入线放置每条样带，放置方式为其一半长度落在线的一侧，另一半长度落在线的另一侧。</para>
		/// <para>这是每条样带线的总长度，而非样带从输入线延伸的距离。要指定样带线应从输入线延伸的距离（例如 100 米），请将此值乘以 2 以指定样带长度（200 米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object TransectLength { get; set; }

		/// <summary>
		/// <para>Generate transects at line start and end</para>
		/// <para>指定是否在输入线的起点和终点生成样带。</para>
		/// <para>选中 - 将在输入线的起点和终点生成样带。</para>
		/// <para>未选中 - 将不会在输入线的起点和终点生成样带。这是默认设置。</para>
		/// <para><see cref="IncludeEndsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeEnds { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTransectsAlongLines SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate transects at line start and end</para>
		/// </summary>
		public enum IncludeEndsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("END_POINTS")]
			END_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_END_POINTS")]
			NO_END_POINTS,

		}

#endregion
	}
}
