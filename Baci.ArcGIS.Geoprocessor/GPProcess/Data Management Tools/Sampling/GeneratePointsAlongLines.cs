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
	/// <para>Generate Points Along Lines</para>
	/// <para>沿线生成点</para>
	/// <para>沿线或面以固定间隔或要素长度百分比创建点要素。</para>
	/// </summary>
	public class GeneratePointsAlongLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>用于转换为点的线或面要素。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将基于输入要素创建的点要素类。</para>
		/// </param>
		/// <param name="PointPlacement">
		/// <para>Point Placement</para>
		/// <para>指定用于创建点的方法。</para>
		/// <para>按百分比—将使用百分比参数值按百分比沿要素放置点。</para>
		/// <para>按距离—将使用距离参数值将按固定距离沿要素放置点。 这是默认设置。</para>
		/// <para><see cref="PointPlacementEnum"/></para>
		/// </param>
		public GeneratePointsAlongLines(object InputFeatures, object OutputFeatureClass, object PointPlacement)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.PointPlacement = PointPlacement;
		}

		/// <summary>
		/// <para>Tool Display Name : 沿线生成点</para>
		/// </summary>
		public override string DisplayName() => "沿线生成点";

		/// <summary>
		/// <para>Tool Name : GeneratePointsAlongLines</para>
		/// </summary>
		public override string ToolName() => "GeneratePointsAlongLines";

		/// <summary>
		/// <para>Tool Excute Name : management.GeneratePointsAlongLines</para>
		/// </summary>
		public override string ExcuteName() => "management.GeneratePointsAlongLines";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "outputMFlag", "outputZFlag", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatureClass, PointPlacement, Distance!, Percentage!, IncludeEndPoints! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于转换为点的线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将基于输入要素创建的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Point Placement</para>
		/// <para>指定用于创建点的方法。</para>
		/// <para>按百分比—将使用百分比参数值按百分比沿要素放置点。</para>
		/// <para>按距离—将使用距离参数值将按固定距离沿要素放置点。 这是默认设置。</para>
		/// <para><see cref="PointPlacementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PointPlacement { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Distance</para>
		/// <para>点将放置于距离要素始点的间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? Distance { get; set; }

		/// <summary>
		/// <para>Percentage</para>
		/// <para>点将放置于距离要素始点的百分比。 例如，如果已使用 40%，则点将放置于要素距离的 40% 和 80% 位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? Percentage { get; set; }

		/// <summary>
		/// <para>Include End Points</para>
		/// <para>指定是否在要素的开始点和结束点包括其他点。</para>
		/// <para>选中 - 将在要素的开始点和结束点包括其他点。</para>
		/// <para>未选中 - 不在要素的开始点和结束点包括其他点。 这是默认设置。</para>
		/// <para><see cref="IncludeEndPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeEndPoints { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneratePointsAlongLines SetEnviroment(object? configKeyword = null , object? outputMFlag = null , object? outputZFlag = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, outputMFlag: outputMFlag, outputZFlag: outputZFlag, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Placement</para>
		/// </summary>
		public enum PointPlacementEnum 
		{
			/// <summary>
			/// <para>按百分比—将使用百分比参数值按百分比沿要素放置点。</para>
			/// </summary>
			[GPValue("PERCENTAGE")]
			[Description("按百分比")]
			By_percentage,

			/// <summary>
			/// <para>按距离—将使用距离参数值将按固定距离沿要素放置点。 这是默认设置。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("按距离")]
			By_distance,

		}

		/// <summary>
		/// <para>Include End Points</para>
		/// </summary>
		public enum IncludeEndPointsEnum 
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
