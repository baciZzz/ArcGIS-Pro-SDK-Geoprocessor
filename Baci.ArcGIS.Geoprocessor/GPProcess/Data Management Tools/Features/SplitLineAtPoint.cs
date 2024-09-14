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
	/// <para>Split Line at Point</para>
	/// <para>在点处分割线</para>
	/// <para>根据交叉点或与点要素的邻近性分割线要素。</para>
	/// </summary>
	public class SplitLineAtPoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要分割的输入线要素。</para>
		/// </param>
		/// <param name="PointFeatures">
		/// <para>Point Features</para>
		/// <para>包含分割输入线所用位置的输入点要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>要创建的包含分割线的新要素类。</para>
		/// </param>
		public SplitLineAtPoint(object InFeatures, object PointFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.PointFeatures = PointFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 在点处分割线</para>
		/// </summary>
		public override string DisplayName() => "在点处分割线";

		/// <summary>
		/// <para>Tool Name : SplitLineAtPoint</para>
		/// </summary>
		public override string ToolName() => "SplitLineAtPoint";

		/// <summary>
		/// <para>Tool Excute Name : management.SplitLineAtPoint</para>
		/// </summary>
		public override string ExcuteName() => "management.SplitLineAtPoint";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, PointFeatures, OutFeatureClass, SearchRadius };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要分割的输入线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Point Features</para>
		/// <para>包含分割输入线所用位置的输入点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint", "Point")]
		public object PointFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>要创建的包含分割线的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>用于根据与点要素的邻近性分割线。输入线搜索距离范围内的点将用于在线段上距点最近的位置处分割线。</para>
		/// <para>如果未指定此参数，将使用最近的一个点分割线要素。如果已指定了半径，将使用此半径内的所有点来分割线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchRadius { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SplitLineAtPoint SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, workspace: workspace);
			return this;
		}

	}
}
