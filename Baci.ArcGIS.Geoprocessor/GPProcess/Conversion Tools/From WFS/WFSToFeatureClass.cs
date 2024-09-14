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
	/// <para>WFS To Feature Class</para>
	/// <para>WFS To Feature Class</para>
	/// <para>Imports a feature type from a web feature service (WFS) to a feature class in a geodatabase.</para>
	/// </summary>
	public class WFSToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputWFSServer">
		/// <para>WFS Server</para>
		/// <para>The URL of the source WFS service (for example, http://sampleserver6.arcgisonline.com/arcgis/services/SampleWorldCities/MapServer/WFSServer?). If the input is a complex WFS service (Complex WFS service is checked), this can also be the path to the XML file.</para>
		/// </param>
		/// <param name="WFSFeatureType">
		/// <para>Select Feature Type to Extract</para>
		/// <para>The name of the WFS layer to extract from the input WFS service.</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>The location of the output feature class or geodatabase.</para>
		/// <para>If the input is a simple WFS service, the output location can be a geodatabase or a feature dataset in a geodatabase. If the output location is a feature dataset, the coordinates are converted from the source coordinate system to the coordinate system of the feature dataset.</para>
		/// <para>If the input is a complex WFS service, the output location must be a folder.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Name</para>
		/// <para>The name of the output feature class or geodatabase.</para>
		/// <para>If the input is a simple WFS service, the name is used to create a feature class in the output location. If the feature class name already exists in the geodatabase, the name will be automatically incremented. By default, the feature type name is used.</para>
		/// <para>If the input is a complex WFS service, the name is used to create a geodatabase in the output location.</para>
		/// </param>
		public WFSToFeatureClass(object InputWFSServer, object WFSFeatureType, object OutPath, object OutName)
		{
			this.InputWFSServer = InputWFSServer;
			this.WFSFeatureType = WFSFeatureType;
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : WFS To Feature Class</para>
		/// </summary>
		public override string DisplayName() => "WFS To Feature Class";

		/// <summary>
		/// <para>Tool Name : WFSToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "WFSToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : conversion.WFSToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "conversion.WFSToFeatureClass";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputWFSServer, WFSFeatureType, OutPath, OutName, OutFeatureClass, IsComplex, OutGdb, MaxFeatures, ExposeMetadata, SwapXy };

		/// <summary>
		/// <para>WFS Server</para>
		/// <para>The URL of the source WFS service (for example, http://sampleserver6.arcgisonline.com/arcgis/services/SampleWorldCities/MapServer/WFSServer?). If the input is a complex WFS service (Complex WFS service is checked), this can also be the path to the XML file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputWFSServer { get; set; }

		/// <summary>
		/// <para>Select Feature Type to Extract</para>
		/// <para>The name of the WFS layer to extract from the input WFS service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object WFSFeatureType { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The location of the output feature class or geodatabase.</para>
		/// <para>If the input is a simple WFS service, the output location can be a geodatabase or a feature dataset in a geodatabase. If the output location is a feature dataset, the coordinates are converted from the source coordinate system to the coordinate system of the feature dataset.</para>
		/// <para>If the input is a complex WFS service, the output location must be a folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>The name of the output feature class or geodatabase.</para>
		/// <para>If the input is a simple WFS service, the name is used to create a feature class in the output location. If the feature class name already exists in the geodatabase, the name will be automatically incremented. By default, the feature type name is used.</para>
		/// <para>If the input is a complex WFS service, the name is used to create a geodatabase in the output location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Complex WFS service</para>
		/// <para>Specifies whether the input WFS service is a complex WFS service.</para>
		/// <para>Checked—The WFS service is a complex WFS service.</para>
		/// <para>Not checked—The WFS service is not a complex service. This is the default.</para>
		/// <para><see cref="IsComplexEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsComplex { get; set; } = "false";

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutGdb { get; set; }

		/// <summary>
		/// <para>Max Features</para>
		/// <para>The maximum number of features that can be returned. The default is 1000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaxFeatures { get; set; } = "1000";

		/// <summary>
		/// <para>Expose Metadata</para>
		/// <para>Specifies whether tables with metadata will be created from the service. This is only applicable for complex WFS services.</para>
		/// <para>Checked—Metadata tables will be created in the output geodatabase.</para>
		/// <para>Not checked—Metadata tables will not be created in the output geodatabase. This is the default.</para>
		/// <para><see cref="ExposeMetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExposeMetadata { get; set; } = "false";

		/// <summary>
		/// <para>Swap XY Axis Order</para>
		/// <para>Specifies whether the x,y axis order of the output feature class will be swapped. Some WFS services may have the order of the x,y coordinates swapped on the server side, causing the feature class to display incorrectly.</para>
		/// <para>Checked—The x,y axis order will be swapped.</para>
		/// <para>Not checked—The x,y axis order will not be swapped. This is the default.</para>
		/// <para><see cref="SwapXyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SwapXy { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WFSToFeatureClass SetEnviroment(object configKeyword = null, object extent = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Complex WFS service</para>
		/// </summary>
		public enum IsComplexEnum 
		{
			/// <summary>
			/// <para>Checked—The WFS service is a complex WFS service.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPLEX")]
			COMPLEX,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_COMPLEX")]
			NOT_COMPLEX,

		}

		/// <summary>
		/// <para>Expose Metadata</para>
		/// </summary>
		public enum ExposeMetadataEnum 
		{
			/// <summary>
			/// <para>Checked—Metadata tables will be created in the output geodatabase.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPOSE_METADATA")]
			EXPOSE_METADATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EXPOSE")]
			DO_NOT_EXPOSE,

		}

		/// <summary>
		/// <para>Swap XY Axis Order</para>
		/// </summary>
		public enum SwapXyEnum 
		{
			/// <summary>
			/// <para>Checked—The x,y axis order will be swapped.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SWAP_XY")]
			SWAP_XY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SWAP_XY")]
			DO_NOT_SWAP_XY,

		}

#endregion
	}
}
