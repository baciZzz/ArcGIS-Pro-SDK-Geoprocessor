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
	/// <para>Surface Length</para>
	/// <para>Determines surface length for each line in a feature class based on an input surface.</para>
	/// </summary>
	[Obsolete()]
	public class SurfaceLength : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// </param>
		public SurfaceLength(object InSurface, object InFeatureClass)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Surface Length</para>
		/// </summary>
		public override string DisplayName() => "Surface Length";

		/// <summary>
		/// <para>Tool Name : SurfaceLength</para>
		/// </summary>
		public override string ToolName() => "SurfaceLength";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceLength</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceLength";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InFeatureClass, OutLengthField, SampleDistance, ZFactor, Method, PyramidLevelResolution, OutputFeatureClass };

		/// <summary>
		/// <para>Input Surface</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Surface Length Field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutLengthField { get; set; } = "SLength";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SampleDistance { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutputFeatureClass { get; set; }

	}
}
