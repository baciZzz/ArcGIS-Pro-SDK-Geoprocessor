using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>LAS Point Statistics By Area</para>
	/// <para>Evaluates the statistics of LAS points that overlay the area defined by polygon features.</para>
	/// </summary>
	public class LasPointStatsByArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Polygons</para>
		/// <para>The polygon that defines the area for which statistics will be reported.</para>
		/// </param>
		public LasPointStatsByArea(object InLasDataset, object InFeatures)
		{
			this.InLasDataset = InLasDataset;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Point Statistics By Area</para>
		/// </summary>
		public override string DisplayName => "LAS Point Statistics By Area";

		/// <summary>
		/// <para>Tool Name : LasPointStatsByArea</para>
		/// </summary>
		public override string ToolName => "LasPointStatsByArea";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasPointStatsByArea</para>
		/// </summary>
		public override string ExcuteName => "3d.LasPointStatsByArea";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, InFeatures, OutProperty, OutputPolygons };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>The polygon that defines the area for which statistics will be reported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Property</para>
		/// <para>The properties that will be calculated.</para>
		/// <para>Minimum Z—The lowest Z value of LAS points overlapping the feature.</para>
		/// <para>Maximum Z—The highest Z value of LAS points overlapping the feature.</para>
		/// <para>Average Z—The average Z value of LAS points overlapping the feature.</para>
		/// <para>LAS Point Count—The tally of LAS points that were evaluated.</para>
		/// <para>Standard Deviation—The standard deviation of Z values.</para>
		/// <para><see cref="OutPropertyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object OutProperty { get; set; }

		/// <summary>
		/// <para>Updated Input Polygons</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutputPolygons { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasPointStatsByArea SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Property</para>
		/// </summary>
		public enum OutPropertyEnum 
		{
			/// <summary>
			/// <para>Minimum Z—The lowest Z value of LAS points overlapping the feature.</para>
			/// </summary>
			[GPValue("Z_MIN")]
			[Description("Minimum Z")]
			Minimum_Z,

			/// <summary>
			/// <para>Maximum Z—The highest Z value of LAS points overlapping the feature.</para>
			/// </summary>
			[GPValue("Z_MAX")]
			[Description("Maximum Z")]
			Maximum_Z,

			/// <summary>
			/// <para>Average Z—The average Z value of LAS points overlapping the feature.</para>
			/// </summary>
			[GPValue("Z_MEAN")]
			[Description("Average Z")]
			Average_Z,

			/// <summary>
			/// <para>LAS Point Count—The tally of LAS points that were evaluated.</para>
			/// </summary>
			[GPValue("POINT_COUNT")]
			[Description("LAS Point Count")]
			LAS_Point_Count,

			/// <summary>
			/// <para>Standard Deviation—The standard deviation of Z values.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard Deviation")]
			Standard_Deviation,

		}

#endregion
	}
}
