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
	/// <para>Polygon To Line</para>
	/// <para>面转线</para>
	/// <para>创建的要素类中将包含由面边界转换而来的线（无论是否考虑邻近面）。</para>
	/// </summary>
	public class PolygonToLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>几何必须为面的输入要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出线要素类。</para>
		/// </param>
		public PolygonToLine(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 面转线</para>
		/// </summary>
		public override string DisplayName() => "面转线";

		/// <summary>
		/// <para>Tool Name : PolygonToLine</para>
		/// </summary>
		public override string ToolName() => "PolygonToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.PolygonToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.PolygonToLine";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, NeighborOption };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>几何必须为面的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Identify and store polygon neighboring information</para>
		/// <para>指定是否识别并存储面邻域信息。</para>
		/// <para>选中 - 识别面邻域关系并将该关系存储在输出中。如果某个面的不同线段与不同的面共用边界，那么该边界将被分割成各个唯一公用的线段，这些线段的两个邻近面 FID 值将存储在输出中，如图中所示。这是默认设置。</para>
		/// <para>未选中 - 忽略面邻域关系；每个面边界均将变为线要素，并且边界原始面要素 ID 将存储在输出中。</para>
		/// <para><see cref="NeighborOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object NeighborOption { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolygonToLine SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Identify and store polygon neighboring information</para>
		/// </summary>
		public enum NeighborOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IDENTIFY_NEIGHBORS")]
			IDENTIFY_NEIGHBORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_NEIGHBORS")]
			IGNORE_NEIGHBORS,

		}

#endregion
	}
}
