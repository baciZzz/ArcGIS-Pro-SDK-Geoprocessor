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
	/// <para>Collapse Dual Lines To Centerline</para>
	/// <para>Collapse Dual Lines To Centerline</para>
	/// <para>Determines the centerlines of features with dual lines.</para>
	/// </summary>
	[Obsolete()]
	public class CollapseDualLinesToCenterline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// </param>
		/// <param name="MaximumWidth">
		/// <para>Maximum Width</para>
		/// </param>
		public CollapseDualLinesToCenterline(object InFeatures, object OutFeatureClass, object MaximumWidth)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.MaximumWidth = MaximumWidth;
		}

		/// <summary>
		/// <para>Tool Display Name : Collapse Dual Lines To Centerline</para>
		/// </summary>
		public override string DisplayName() => "Collapse Dual Lines To Centerline";

		/// <summary>
		/// <para>Tool Name : CollapseDualLinesToCenterline</para>
		/// </summary>
		public override string ToolName() => "CollapseDualLinesToCenterline";

		/// <summary>
		/// <para>Tool Excute Name : management.CollapseDualLinesToCenterline</para>
		/// </summary>
		public override string ExcuteName() => "management.CollapseDualLinesToCenterline";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, MaximumWidth, MinimumWidth! };

		/// <summary>
		/// <para>Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Width</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MaximumWidth { get; set; }

		/// <summary>
		/// <para>Minimum Width</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MinimumWidth { get; set; }

	}
}
