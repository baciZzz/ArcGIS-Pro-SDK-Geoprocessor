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
	/// <para>Disperse Markers</para>
	/// <para>Finds point symbols that overlap or are too close to one another based on symbology at reference scale, and spreads them apart based on a minimum spacing and dispersal pattern.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DisperseMarkers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>The input point feature layer to be dispersed.</para>
		/// </param>
		/// <param name="MinimumSpacing">
		/// <para>Minimum Spacing</para>
		/// <para>The minimum separation distance between individual point symbols in page units. A distance must be specified and must be greater than or equal to zero. When a positive value is specified, markers will be separated by that value; when a value of zero is specified, point symbols will touch. The default page unit is Points.</para>
		/// </param>
		public DisperseMarkers(object InPointFeatures, object MinimumSpacing)
		{
			this.InPointFeatures = InPointFeatures;
			this.MinimumSpacing = MinimumSpacing;
		}

		/// <summary>
		/// <para>Tool Display Name : Disperse Markers</para>
		/// </summary>
		public override string DisplayName() => "Disperse Markers";

		/// <summary>
		/// <para>Tool Name : DisperseMarkers</para>
		/// </summary>
		public override string ToolName() => "DisperseMarkers";

		/// <summary>
		/// <para>Tool Excute Name : cartography.DisperseMarkers</para>
		/// </summary>
		public override string ExcuteName() => "cartography.DisperseMarkers";

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
		public override string[] ValidEnvironments() => new string[] { "cartographicCoordinateSystem", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointFeatures, MinimumSpacing, DispersalPattern, OutRepresentations };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The input point feature layer to be dispersed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Spacing</para>
		/// <para>The minimum separation distance between individual point symbols in page units. A distance must be specified and must be greater than or equal to zero. When a positive value is specified, markers will be separated by that value; when a value of zero is specified, point symbols will touch. The default page unit is Points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MinimumSpacing { get; set; }

		/// <summary>
		/// <para>Dispersal Pattern</para>
		/// <para>Specifies the pattern in which the dispersed point symbols are placed. A group of point symbols will have a center of mass derived from the locations of all points in the group. The center of mass is used as the anchor point around which the dispersal pattern operates.</para>
		/// <para>Expanded—The general pattern of the point symbols will be maintained as they are spread apart. Points that were exactly coincident are dispersed to a circle around their center of mass. This is the default.</para>
		/// <para>Random—Point symbols are placed around the center of mass in a random dispersal that respects the minimum spacing.</para>
		/// <para>Squares—Point symbols are placed in multiple square rings around the center of mass, ensuring that all points are placed as closely together as allowable by the minimum spacing parameter.</para>
		/// <para>Rings—Point symbols are placed in multiple circular rings around the center of mass, ensuring that all points are placed as closely together as allowable by the minimum spacing parameter.</para>
		/// <para>Square—Point symbols are placed evenly around the center of mass in a single square pattern.</para>
		/// <para>Ring—Point symbols are placed evenly around the center of mass in a single circular pattern.</para>
		/// <para>Cross—Point symbols are spaced evenly on horizontal and vertical axes originating from the center of mass.</para>
		/// <para>X-cross—Point symbols are spaced evenly on 45° axes originating from the center of mass.</para>
		/// <para><see cref="DispersalPatternEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DispersalPattern { get; set; } = "EXPANDED";

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DisperseMarkers SetEnviroment(object cartographicCoordinateSystem = null , object referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dispersal Pattern</para>
		/// </summary>
		public enum DispersalPatternEnum 
		{
			/// <summary>
			/// <para>Expanded—The general pattern of the point symbols will be maintained as they are spread apart. Points that were exactly coincident are dispersed to a circle around their center of mass. This is the default.</para>
			/// </summary>
			[GPValue("EXPANDED")]
			[Description("Expanded")]
			Expanded,

			/// <summary>
			/// <para>Random—Point symbols are placed around the center of mass in a random dispersal that respects the minimum spacing.</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("Random")]
			Random,

			/// <summary>
			/// <para>Squares—Point symbols are placed in multiple square rings around the center of mass, ensuring that all points are placed as closely together as allowable by the minimum spacing parameter.</para>
			/// </summary>
			[GPValue("SQUARES")]
			[Description("Squares")]
			Squares,

			/// <summary>
			/// <para>Rings—Point symbols are placed in multiple circular rings around the center of mass, ensuring that all points are placed as closely together as allowable by the minimum spacing parameter.</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("Rings")]
			Rings,

			/// <summary>
			/// <para>Squares—Point symbols are placed in multiple square rings around the center of mass, ensuring that all points are placed as closely together as allowable by the minimum spacing parameter.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Rings—Point symbols are placed in multiple circular rings around the center of mass, ensuring that all points are placed as closely together as allowable by the minimum spacing parameter.</para>
			/// </summary>
			[GPValue("RING")]
			[Description("Ring")]
			Ring,

			/// <summary>
			/// <para>Cross—Point symbols are spaced evenly on horizontal and vertical axes originating from the center of mass.</para>
			/// </summary>
			[GPValue("CROSS")]
			[Description("Cross")]
			Cross,

			/// <summary>
			/// <para>X-cross—Point symbols are spaced evenly on 45° axes originating from the center of mass.</para>
			/// </summary>
			[GPValue("X_CROSS")]
			[Description("X-cross")]
			X_CROSS,

		}

#endregion
	}
}
