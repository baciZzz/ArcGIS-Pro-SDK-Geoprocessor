using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>JSON To Features</para>
	/// <para>JSON To Features</para>
	/// <para>Converts feature collections in an Esri JSON (.json) file or GeoJSON (.geojson) file to a feature class.</para>
	/// </summary>
	public class JSONToFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InJsonFile">
		/// <para>Input JSON or GeoJSON</para>
		/// <para>The input JSON or GeoJSON file to convert to a feature class.</para>
		/// <para>The input file extension determines the conversion routine used by the tool. Esri JSON formatted files must use the .json extension, and GeoJSON files must use the .geojson extension for proper conversion to occur.</para>
		/// </param>
		/// <param name="OutFeatures">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class created to contain the features converted from the input JSON or GeoJSON file.</para>
		/// </param>
		public JSONToFeatures(object InJsonFile, object OutFeatures)
		{
			this.InJsonFile = InJsonFile;
			this.OutFeatures = OutFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : JSON To Features</para>
		/// </summary>
		public override string DisplayName() => "JSON To Features";

		/// <summary>
		/// <para>Tool Name : JSONToFeatures</para>
		/// </summary>
		public override string ToolName() => "JSONToFeatures";

		/// <summary>
		/// <para>Tool Excute Name : conversion.JSONToFeatures</para>
		/// </summary>
		public override string ExcuteName() => "conversion.JSONToFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InJsonFile, OutFeatures, GeometryType };

		/// <summary>
		/// <para>Input JSON or GeoJSON</para>
		/// <para>The input JSON or GeoJSON file to convert to a feature class.</para>
		/// <para>The input file extension determines the conversion routine used by the tool. Esri JSON formatted files must use the .json extension, and GeoJSON files must use the .geojson extension for proper conversion to occur.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json", "geojson")]
		public object InJsonFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class created to contain the features converted from the input JSON or GeoJSON file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>The geometry type to convert from GeoJSON to features. This option is only used when the input is a GeoJSON file. If the GeoJSON file does not contain any of the selected geometry type, the output feature class will be empty.</para>
		/// <para>Point—Convert any points to features.</para>
		/// <para>Multipoint—Convert any multipoints to features.</para>
		/// <para>Polyline—Convert any polylines to features.</para>
		/// <para>Polygon—Convert any polygons to features.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GeometryType { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public JSONToFeatures SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point—Convert any points to features.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Multipoint—Convert any multipoints to features.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—Convert any polygons to features.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Polyline—Convert any polylines to features.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

		}

#endregion
	}
}
