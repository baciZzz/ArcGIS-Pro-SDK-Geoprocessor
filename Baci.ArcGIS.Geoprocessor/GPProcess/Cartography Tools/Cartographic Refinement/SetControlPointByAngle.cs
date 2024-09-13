using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Set Control Point By Angle</para>
	/// <para>Set Control Point By Angle</para>
	/// <para>Places a control point at vertices along a line or polygon outline where the angle created by a change in line direction is less than or equal to a specified maximum angle.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetControlPointByAngle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature layer containing line or polygon features.</para>
		/// </param>
		/// <param name="MaximumAngle">
		/// <para>Maximum Angle (decimal degrees)</para>
		/// <para>The angle used to determine whether a vertex along a line or polygon outline will be set as a control point. The angle value must be greater than zero and less than 180 decimal degrees.</para>
		/// </param>
		public SetControlPointByAngle(object InFeatures, object MaximumAngle)
		{
			this.InFeatures = InFeatures;
			this.MaximumAngle = MaximumAngle;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Control Point By Angle</para>
		/// </summary>
		public override string DisplayName() => "Set Control Point By Angle";

		/// <summary>
		/// <para>Tool Name : SetControlPointByAngle</para>
		/// </summary>
		public override string ToolName() => "SetControlPointByAngle";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SetControlPointByAngle</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SetControlPointByAngle";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, MaximumAngle, OutRepresentations! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature layer containing line or polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Maximum Angle (decimal degrees)</para>
		/// <para>The angle used to determine whether a vertex along a line or polygon outline will be set as a control point. The angle value must be greater than zero and less than 180 decimal degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MaximumAngle { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object? OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetControlPointByAngle SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
