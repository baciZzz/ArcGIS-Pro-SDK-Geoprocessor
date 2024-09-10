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
	/// <para>Unsplit Line</para>
	/// <para>Merges lines that have coincident endpoints and, optionally, common attribute values.</para>
	/// </summary>
	public class UnsplitLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The line features to be aggregated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class to be created that will contain the aggregated features.</para>
		/// </param>
		public UnsplitLine(object InFeatures, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Unsplit Line</para>
		/// </summary>
		public override string DisplayName() => "Unsplit Line";

		/// <summary>
		/// <para>Tool Name : UnsplitLine</para>
		/// </summary>
		public override string ToolName() => "UnsplitLine";

		/// <summary>
		/// <para>Tool Excute Name : management.UnsplitLine</para>
		/// </summary>
		public override string ExcuteName() => "management.UnsplitLine";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, DissolveField, StatisticsFields };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The line features to be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class to be created that will contain the aggregated features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>The field or fields on which to aggregate features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID")]
		public object DissolveField { get; set; }

		/// <summary>
		/// <para>Statistics Field(s)</para>
		/// <para>Specifies the numeric field or fields containing the attribute values that will be used to calculate the specified statistic. Multiple statistic and field combinations can be specified. Null values are excluded from all statistical calculations.</para>
		/// <para>Text attribute fields can be summarized using first and last statistics. Numeric attribute fields can be summarized using any statistic.</para>
		/// <para>Available statistics types are as follows:</para>
		/// <para>Sum—The values for the specified field will be added together.</para>
		/// <para>Mean—The average for the specified field will be calculated.</para>
		/// <para>Minimum—The smallest value for all records of the specified field will be found.</para>
		/// <para>Maximum—The largest value for all records of the specified field will be found.</para>
		/// <para>Range—The range of values (maximum minus minimum) for the specified field will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of values in the specified field will be calculated.</para>
		/// <para>Count—The number of values included in the statistical calculations will be found. Each value will be counted except null values. To determine the number of null values in a field, create a count on the field in question, create a count on a different field that does not contain null values (for example, the OID if present), and subtract the two values.</para>
		/// <para>First—The specified field value of the first record in the input will be used.</para>
		/// <para>Last—The specified field value of the last record in the input will be used.</para>
		/// <para>Median—The median for all records of the specified field will be calculated.</para>
		/// <para>Variance—The variance for all records of the specified field will be calculated.</para>
		/// <para>Unique—The number of unique values of the specified field will be counted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object StatisticsFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UnsplitLine SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
