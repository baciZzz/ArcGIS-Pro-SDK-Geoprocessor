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
	/// <para>Remove Overlapping Centerlines</para>
	/// <para>Removes overlapping centerline sections to ensure that there is one common centerline in cases where centerline geometry overlaps.</para>
	/// </summary>
	public class RemoveOverlappingCenterlines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCenterlineFeatures">
		/// <para>Input Centerline Features</para>
		/// <para>An input layer or feature class representing an LRS centerline.</para>
		/// </param>
		public RemoveOverlappingCenterlines(object InCenterlineFeatures)
		{
			this.InCenterlineFeatures = InCenterlineFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Overlapping Centerlines</para>
		/// </summary>
		public override string DisplayName() => "Remove Overlapping Centerlines";

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
		public override object[] Parameters() => new object[] { InCenterlineFeatures, UpdatedCenterlineFeatures, OutDetailsFile };

		/// <summary>
		/// <para>Input Centerline Features</para>
		/// <para>An input layer or feature class representing an LRS centerline.</para>
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
		public object UpdatedCenterlineFeatures { get; set; }

		/// <summary>
		/// <para>Output Details File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveOverlappingCenterlines SetEnviroment(object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
