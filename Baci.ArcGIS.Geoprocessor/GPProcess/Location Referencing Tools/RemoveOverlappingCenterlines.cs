using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Remove Overlapping Centerlines</para>
	/// <para>移除重叠中心线</para>
	/// <para>移除重叠中心线部分，以确保在中心线几何重叠的情况下存在一条公共中心线。</para>
	/// </summary>
	public class RemoveOverlappingCenterlines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCenterlineFeatures">
		/// <para>Input Centerline Features</para>
		/// <para>表示 LRS 中心线的输入图层或要素类。</para>
		/// </param>
		public RemoveOverlappingCenterlines(object InCenterlineFeatures)
		{
			this.InCenterlineFeatures = InCenterlineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 移除重叠中心线</para>
		/// </summary>
		public override string DisplayName() => "移除重叠中心线";

		/// <summary>
		/// <para>Tool Name : RemoveOverlappingCenterlines</para>
		/// </summary>
		public override string ToolName() => "RemoveOverlappingCenterlines";

		/// <summary>
		/// <para>Tool Excute Name : locref.RemoveOverlappingCenterlines</para>
		/// </summary>
		public override string ExcuteName() => "locref.RemoveOverlappingCenterlines";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCenterlineFeatures, UpdatedCenterlineFeatures!, OutDetailsFile! };

		/// <summary>
		/// <para>Input Centerline Features</para>
		/// <para>表示 LRS 中心线的输入图层或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InCenterlineFeatures { get; set; }

		/// <summary>
		/// <para>Updated Centerline features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedCenterlineFeatures { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object? OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveOverlappingCenterlines SetEnviroment(object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
