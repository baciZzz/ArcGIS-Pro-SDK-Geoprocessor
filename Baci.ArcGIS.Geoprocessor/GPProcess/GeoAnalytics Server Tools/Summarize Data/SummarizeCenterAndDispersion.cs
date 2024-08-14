using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Summarize Center And Dispersion</para>
	/// <para>Finds central features and directional distributions and calculates mean and median locations from the input.</para>
	/// </summary>
	public class SummarizeCenterAndDispersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon layer to be summarized.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="GenerateTypes">
		/// <para>Generate Types</para>
		/// <para>Specifies the summary types to be generated. You can use one or more summary types. A unique layer will be created for each summary type selected.</para>
		/// <para>Central Feature—A layer will be created that contains a copy of the most central feature from the input layer.</para>
		/// <para>Mean Center—A point layer will be created that represents the mean center of the input layer.</para>
		/// <para>Median Center—A point layer will be created that represents the median center of the input layer.</para>
		/// <para>Ellipse—A polygon layer will be created that represents the directional ellipse of the input layer.</para>
		/// <para><see cref="GenerateTypesEnum"/></para>
		/// </param>
		public SummarizeCenterAndDispersion(object InputLayer, object OutputName, object GenerateTypes)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.GenerateTypes = GenerateTypes;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Center And Dispersion</para>
		/// </summary>
		public override string DisplayName => "Summarize Center And Dispersion";

		/// <summary>
		/// <para>Tool Name : SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ToolName => "SummarizeCenterAndDispersion";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.SummarizeCenterAndDispersion";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, OutputName, GenerateTypes, EllipseSize!, WeightField!, GroupByField!, OutCentralFeatureLayer!, OutMeanCenterLayer!, OutMedianCenterLayer!, OutEllipseLayer!, DataStore! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon layer to be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Generate Types</para>
		/// <para>Specifies the summary types to be generated. You can use one or more summary types. A unique layer will be created for each summary type selected.</para>
		/// <para>Central Feature—A layer will be created that contains a copy of the most central feature from the input layer.</para>
		/// <para>Mean Center—A point layer will be created that represents the mean center of the input layer.</para>
		/// <para>Median Center—A point layer will be created that represents the median center of the input layer.</para>
		/// <para>Ellipse—A polygon layer will be created that represents the directional ellipse of the input layer.</para>
		/// <para><see cref="GenerateTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object GenerateTypes { get; set; }

		/// <summary>
		/// <para>Ellipse Size</para>
		/// <para>Specifies the size of output ellipses in standard deviations.</para>
		/// <para>One standard deviation—Output ellipses will cover one standard deviation of the input features. This is the default.</para>
		/// <para>Two standard deviations—Output ellipses will cover two standard deviations of the input features.</para>
		/// <para>Three standard deviations—Output ellipses will cover three standard deviations of the input features.</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EllipseSize { get; set; } = "1_STANDARD_DEVIATION";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>A numeric field used to weight locations according to their relative importance. This applies to all summary types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>The field used to group similar features. This applies to all summary types. For example, if you choose a field named PlantType that contains values of tree, bush, and grass, all of the features with the value tree will be analyzed for their own center or dispersion. This example will result in three features, one for each group of tree, bush, and grass.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? GroupByField { get; set; }

		/// <summary>
		/// <para>Central Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutCentralFeatureLayer { get; set; }

		/// <summary>
		/// <para>Mean Center Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutMeanCenterLayer { get; set; }

		/// <summary>
		/// <para>Median Center Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutMedianCenterLayer { get; set; }

		/// <summary>
		/// <para>Ellipse Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutEllipseLayer { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeCenterAndDispersion SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate Types</para>
		/// </summary>
		public enum GenerateTypesEnum 
		{
			/// <summary>
			/// <para>Central Feature—A layer will be created that contains a copy of the most central feature from the input layer.</para>
			/// </summary>
			[GPValue("CENTRAL_FEATURE")]
			[Description("Central Feature")]
			Central_Feature,

			/// <summary>
			/// <para>Mean Center—A point layer will be created that represents the mean center of the input layer.</para>
			/// </summary>
			[GPValue("MEAN_CENTER")]
			[Description("Mean Center")]
			Mean_Center,

			/// <summary>
			/// <para>Median Center—A point layer will be created that represents the median center of the input layer.</para>
			/// </summary>
			[GPValue("MEDIAN_CENTER")]
			[Description("Median Center")]
			Median_Center,

			/// <summary>
			/// <para>Ellipse—A polygon layer will be created that represents the directional ellipse of the input layer.</para>
			/// </summary>
			[GPValue("ELLIPSE")]
			[Description("Ellipse")]
			Ellipse,

		}

		/// <summary>
		/// <para>Ellipse Size</para>
		/// </summary>
		public enum EllipseSizeEnum 
		{
			/// <summary>
			/// <para>One standard deviation—Output ellipses will cover one standard deviation of the input features. This is the default.</para>
			/// </summary>
			[GPValue("1_STANDARD_DEVIATION")]
			[Description("One standard deviation")]
			One_standard_deviation,

			/// <summary>
			/// <para>Two standard deviations—Output ellipses will cover two standard deviations of the input features.</para>
			/// </summary>
			[GPValue("2_STANDARD_DEVIATIONS")]
			[Description("Two standard deviations")]
			Two_standard_deviations,

			/// <summary>
			/// <para>Three standard deviations—Output ellipses will cover three standard deviations of the input features.</para>
			/// </summary>
			[GPValue("3_STANDARD_DEVIATIONS")]
			[Description("Three standard deviations")]
			Three_standard_deviations,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

#endregion
	}
}
