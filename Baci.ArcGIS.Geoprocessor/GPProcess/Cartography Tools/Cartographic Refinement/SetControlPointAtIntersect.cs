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
	/// <para>Set Control Point At Intersect</para>
	/// <para>Creates a control point at vertices that are shared by one or more line or polygon features. This tool is commonly used to synchronize boundary symbology on adjacent polygons.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SetControlPointAtIntersect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineOrPolygonFeatures">
		/// <para>Input Features</para>
		/// <para>The line or polygon feature layer.</para>
		/// </param>
		public SetControlPointAtIntersect(object InLineOrPolygonFeatures)
		{
			this.InLineOrPolygonFeatures = InLineOrPolygonFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Control Point At Intersect</para>
		/// </summary>
		public override string DisplayName => "Set Control Point At Intersect";

		/// <summary>
		/// <para>Tool Name : SetControlPointAtIntersect</para>
		/// </summary>
		public override string ToolName => "SetControlPointAtIntersect";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SetControlPointAtIntersect</para>
		/// </summary>
		public override string ExcuteName => "cartography.SetControlPointAtIntersect";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLineOrPolygonFeatures, InFeatures!, OutRepresentations! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line or polygon feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InLineOrPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Input Secondary Features</para>
		/// <para>The line or polygon feature layer with features coincident to the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? InFeatures { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetControlPointAtIntersect SetEnviroment(object? cartographicPartitions = null )
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions);
			return this;
		}

	}
}
