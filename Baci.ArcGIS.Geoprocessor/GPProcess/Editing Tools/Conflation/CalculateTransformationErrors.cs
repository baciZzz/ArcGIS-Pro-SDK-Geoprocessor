using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.EditingTools
{
	/// <summary>
	/// <para>Calculate Transformation Errors</para>
	/// <para>计算变换误差</para>
	/// <para>根据要用于空间数据变换的已知控制点之间的输入链接坐标来计算残差和均方根误差 (RMSE)。</para>
	/// </summary>
	public class CalculateTransformationErrors : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLinkFeatures">
		/// <para>Input Link Features</para>
		/// <para>空间变换的已知控制点的输入链接要素。</para>
		/// </param>
		/// <param name="OutLinkTable">
		/// <para>Output Link Table</para>
		/// <para>包含输入链接要素 ID 及其残差的输出表。输入链接残差将写入包含以下字段的指定输出表格：</para>
		/// <para>Orig_FID - 输入链接要素 ID</para>
		/// <para>X_Source - 链接的源或起始端位置的 x 坐标</para>
		/// <para>Y_Source - 链接的源或起始端位置的 y 坐标</para>
		/// <para>X_Destination - 链接的目标或结束端位置的 x 坐标</para>
		/// <para>Y_Destination - 链接的目标或结束端位置的 y 坐标</para>
		/// <para>Residual_Error - 变换后位置的残差</para>
		/// </param>
		public CalculateTransformationErrors(object InLinkFeatures, object OutLinkTable)
		{
			this.InLinkFeatures = InLinkFeatures;
			this.OutLinkTable = OutLinkTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算变换误差</para>
		/// </summary>
		public override string DisplayName() => "计算变换误差";

		/// <summary>
		/// <para>Tool Name : CalculateTransformationErrors</para>
		/// </summary>
		public override string ToolName() => "CalculateTransformationErrors";

		/// <summary>
		/// <para>Tool Excute Name : edit.CalculateTransformationErrors</para>
		/// </summary>
		public override string ExcuteName() => "edit.CalculateTransformationErrors";

		/// <summary>
		/// <para>Toolbox Display Name : Editing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Editing Tools";

		/// <summary>
		/// <para>Toolbox Alise : edit</para>
		/// </summary>
		public override string ToolboxAlise() => "edit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLinkFeatures, OutLinkTable, Method, OutRmse };

		/// <summary>
		/// <para>Input Link Features</para>
		/// <para>空间变换的已知控制点的输入链接要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLinkFeatures { get; set; }

		/// <summary>
		/// <para>Output Link Table</para>
		/// <para>包含输入链接要素 ID 及其残差的输出表。输入链接残差将写入包含以下字段的指定输出表格：</para>
		/// <para>Orig_FID - 输入链接要素 ID</para>
		/// <para>X_Source - 链接的源或起始端位置的 x 坐标</para>
		/// <para>Y_Source - 链接的源或起始端位置的 y 坐标</para>
		/// <para>X_Destination - 链接的目标或结束端位置的 x 坐标</para>
		/// <para>Y_Destination - 链接的目标或结束端位置的 y 坐标</para>
		/// <para>Residual_Error - 变换后位置的残差</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutLinkTable { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>用于转换输入要素坐标的变换方法。</para>
		/// <para>仿射变换—仿射变换至少需要三个变换链接。这是默认设置。</para>
		/// <para>射影变换—投影变换至少需要四个变换链接。</para>
		/// <para>相似变换—相似变换至少需要两个变换链接。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "AFFINE";

		/// <summary>
		/// <para>RMSE</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutRmse { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateTransformationErrors SetEnviroment(object extent = null , object workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>仿射变换—仿射变换至少需要三个变换链接。这是默认设置。</para>
			/// </summary>
			[GPValue("AFFINE")]
			[Description("仿射变换")]
			Affine_transformation,

			/// <summary>
			/// <para>射影变换—投影变换至少需要四个变换链接。</para>
			/// </summary>
			[GPValue("PROJECTIVE")]
			[Description("射影变换")]
			Projective_transformation,

			/// <summary>
			/// <para>相似变换—相似变换至少需要两个变换链接。</para>
			/// </summary>
			[GPValue("SIMILARITY")]
			[Description("相似变换")]
			Similarity_transformation,

		}

#endregion
	}
}
