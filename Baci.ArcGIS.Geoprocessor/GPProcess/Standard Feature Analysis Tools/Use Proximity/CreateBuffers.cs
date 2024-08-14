using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Create Buffers</para>
	/// <para>Creates polygons that cover a given distance from a point, line, or polygon feature.</para>
	/// </summary>
	public class CreateBuffers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features to be buffered.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public CreateBuffers(object Inputlayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Buffers</para>
		/// </summary>
		public override string DisplayName => "Create Buffers";

		/// <summary>
		/// <para>Tool Name : CreateBuffers</para>
		/// </summary>
		public override string ToolName => "CreateBuffers";

		/// <summary>
		/// <para>Tool Excute Name : sfa.CreateBuffers</para>
		/// </summary>
		public override string ExcuteName => "sfa.CreateBuffers";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputlayer, Outputname, Distances!, Field!, Units!, Dissolvetype!, Ringtype!, Sidetype!, Endtype!, Output! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features to be buffered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>A list of distance values to buffer the input features. You must supply values for either the distances or a distance field. You can enter a single distance value or multiple values. The units of the distance values is supplied by the distance units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Distances { get; set; }

		/// <summary>
		/// <para>Distance Field</para>
		/// <para>A field from the input layer containing one buffer distance per feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? Field { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The units of the buffer distance. You must provide a value if cell size has been set.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Nautical miles—Nautical miles</para>
		/// <para>Yards—Yards</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Units { get; set; } = "METERS";

		/// <summary>
		/// <para>Dissolve Type</para>
		/// <para>Determines how overlapping buffers are processed.</para>
		/// <para>No dissolve— Overlapping areas are kept. This is the default.</para>
		/// <para>Dissolve overlapping areas— Overlapping areas are combined.</para>
		/// <para><see cref="DissolvetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Dissolvetype { get; set; } = "NONE";

		/// <summary>
		/// <para>Buffer Ring Type</para>
		/// <para>Determines how multiple-distance buffers are processed.</para>
		/// <para>Concentric overlapping disks— Buffers are concentric and will overlap. For example, if your distances are 10 and 14, the result will be two buffers, one from 0 to 10 and one from 0 to 14. This is the default.</para>
		/// <para>Nonoverlapping rings— Buffers will not overlap. For example, if your distances are 10 and 14, the result will be two buffers, one from 0 to 10 and one from 10 to 14.</para>
		/// <para><see cref="RingtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Ringtype { get; set; } = "DISKS";

		/// <summary>
		/// <para>Side Type</para>
		/// <para>When buffering line features, you can choose which side of the line to buffer. Typically, you choose both sides (Full, which is the default). Left and right are determined as if you were walking from the first x,y coordinate of the line (the start coordinate) to the last x,y coordinate of the line (the end coordinate). Choosing left or right usually means you know that your line features were created and stored in a particular direction (for example, upstream or downstream in a river network).</para>
		/// <para>When buffering polygon features, you can choose whether the buffer includes or excludes the polygon being buffered.</para>
		/// <para>If a side type is not supplied, the polygon being buffered is included in the result buffer. This is the default for polygon features.</para>
		/// <para>Full— Both sides of the line will be buffered. This is the default for line features.</para>
		/// <para>Right— Only the right side of the line will be buffered.</para>
		/// <para>Left— Only the right side of the line will be buffered.</para>
		/// <para>Outside— When buffering a polygon, the polygon being buffered is excluded in the result buffer.</para>
		/// <para><see cref="SidetypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Sidetype { get; set; }

		/// <summary>
		/// <para>End Type</para>
		/// <para>The shape of the buffer at the end-of-line input features. This parameter is not valid for polygon input features. At the ends of lines, the buffer can be rounded (round) or be straight across (flat).</para>
		/// <para>Round ends— Buffers will be rounded at the ends of lines. This is the default.</para>
		/// <para>Flat ends— Buffers will be flat or straight across at the ends of lines.</para>
		/// <para><see cref="EndtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? Endtype { get; set; } = "ROUND";

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateBuffers SetEnviroment(object? extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum UnitsEnum 
		{
			/// <summary>
			/// <para>Meters—Meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—Kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Feet—Feet</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Miles—Miles</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical miles—Nautical miles</para>
			/// </summary>
			[GPValue("NAUTICALMILES")]
			[Description("Nautical miles")]
			Nautical_miles,

			/// <summary>
			/// <para>Yards—Yards</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

		}

		/// <summary>
		/// <para>Dissolve Type</para>
		/// </summary>
		public enum DissolvetypeEnum 
		{
			/// <summary>
			/// <para>No dissolve— Overlapping areas are kept. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No dissolve")]
			No_dissolve,

			/// <summary>
			/// <para>Dissolve overlapping areas— Overlapping areas are combined.</para>
			/// </summary>
			[GPValue("DISSOLVE")]
			[Description("Dissolve overlapping areas")]
			Dissolve_overlapping_areas,

		}

		/// <summary>
		/// <para>Buffer Ring Type</para>
		/// </summary>
		public enum RingtypeEnum 
		{
			/// <summary>
			/// <para>Concentric overlapping disks— Buffers are concentric and will overlap. For example, if your distances are 10 and 14, the result will be two buffers, one from 0 to 10 and one from 0 to 14. This is the default.</para>
			/// </summary>
			[GPValue("DISKS")]
			[Description("Concentric overlapping disks")]
			Concentric_overlapping_disks,

			/// <summary>
			/// <para>Nonoverlapping rings— Buffers will not overlap. For example, if your distances are 10 and 14, the result will be two buffers, one from 0 to 10 and one from 10 to 14.</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("Nonoverlapping rings")]
			Nonoverlapping_rings,

		}

		/// <summary>
		/// <para>Side Type</para>
		/// </summary>
		public enum SidetypeEnum 
		{
			/// <summary>
			/// <para>Full— Both sides of the line will be buffered. This is the default for line features.</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("Full")]
			Full,

			/// <summary>
			/// <para>Right— Only the right side of the line will be buffered.</para>
			/// </summary>
			[GPValue("RIGHT")]
			[Description("Right")]
			Right,

			/// <summary>
			/// <para>Left— Only the right side of the line will be buffered.</para>
			/// </summary>
			[GPValue("LEFT")]
			[Description("Left")]
			Left,

			/// <summary>
			/// <para>Outside— When buffering a polygon, the polygon being buffered is excluded in the result buffer.</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("Outside")]
			Outside,

		}

		/// <summary>
		/// <para>End Type</para>
		/// </summary>
		public enum EndtypeEnum 
		{
			/// <summary>
			/// <para>Round ends— Buffers will be rounded at the ends of lines. This is the default.</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("Round ends")]
			Round_ends,

			/// <summary>
			/// <para>Flat ends— Buffers will be flat or straight across at the ends of lines.</para>
			/// </summary>
			[GPValue("FLAT")]
			[Description("Flat ends")]
			Flat_ends,

		}

#endregion
	}
}
