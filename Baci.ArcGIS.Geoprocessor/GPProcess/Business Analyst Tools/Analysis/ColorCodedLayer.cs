using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Color Coded Layer</para>
	/// <para>Creates a multigeography-level, scale-dependent choropleth layer from a variable describing a business, demographic, consumer, or landscape characteristic.</para>
	/// </summary>
	public class ColorCodedLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ClassificationVariable">
		/// <para>Classification Variable</para>
		/// <para>A variable that will display as a color-coded map.</para>
		/// </param>
		/// <param name="OutLayerName">
		/// <para>Output Layer Name</para>
		/// <para>The name of the color-coded layer that will be added to the map.</para>
		/// </param>
		/// <param name="ClassificationMethod">
		/// <para>Classification Method</para>
		/// <para>Specifies the method that will be used to calculate the class breaks.</para>
		/// <para>Natural Breaks (Jenks)—Natural breaks classes are based on natural groupings inherent in the data. Class breaks that best group similar values and that maximize the differences between classes will be identified. This is the default.</para>
		/// <para>Quantile—Each class will contain an equal number of features. A quantile classification is well suited to linearly distributed data.</para>
		/// <para>Equal Interval—The range of attribute values will be divided into equal-sized subranges. This allows you to specify the number of intervals, and ArcGIS Pro will automatically determine the class breaks based on the value range.</para>
		/// <para>Geometric Interval—Class breaks will be created based on class intervals that have a geometric series. The geometric coefficient in this classifier can change once (to its inverse) to optimize the class ranges.</para>
		/// <para><see cref="ClassificationMethodEnum"/></para>
		/// </param>
		/// <param name="NumberOfClasses">
		/// <para>Number of Classes</para>
		/// <para>The number of data classification breaks that will appear on the map. The default value is 5.</para>
		/// </param>
		public ColorCodedLayer(object ClassificationVariable, object OutLayerName, object ClassificationMethod, object NumberOfClasses)
		{
			this.ClassificationVariable = ClassificationVariable;
			this.OutLayerName = OutLayerName;
			this.ClassificationMethod = ClassificationMethod;
			this.NumberOfClasses = NumberOfClasses;
		}

		/// <summary>
		/// <para>Tool Display Name : Color Coded Layer</para>
		/// </summary>
		public override string DisplayName => "Color Coded Layer";

		/// <summary>
		/// <para>Tool Name : ColorCodedLayer</para>
		/// </summary>
		public override string ToolName => "ColorCodedLayer";

		/// <summary>
		/// <para>Tool Excute Name : ba.ColorCodedLayer</para>
		/// </summary>
		public override string ExcuteName => "ba.ColorCodedLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { ClassificationVariable, OutLayerName, ClassificationMethod, NumberOfClasses, OutLayer };

		/// <summary>
		/// <para>Classification Variable</para>
		/// <para>A variable that will display as a color-coded map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ClassificationVariable { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>The name of the color-coded layer that will be added to the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutLayerName { get; set; }

		/// <summary>
		/// <para>Classification Method</para>
		/// <para>Specifies the method that will be used to calculate the class breaks.</para>
		/// <para>Natural Breaks (Jenks)—Natural breaks classes are based on natural groupings inherent in the data. Class breaks that best group similar values and that maximize the differences between classes will be identified. This is the default.</para>
		/// <para>Quantile—Each class will contain an equal number of features. A quantile classification is well suited to linearly distributed data.</para>
		/// <para>Equal Interval—The range of attribute values will be divided into equal-sized subranges. This allows you to specify the number of intervals, and ArcGIS Pro will automatically determine the class breaks based on the value range.</para>
		/// <para>Geometric Interval—Class breaks will be created based on class intervals that have a geometric series. The geometric coefficient in this classifier can change once (to its inverse) to optimize the class ranges.</para>
		/// <para><see cref="ClassificationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ClassificationMethod { get; set; } = "NATURAL_BREAKS";

		/// <summary>
		/// <para>Number of Classes</para>
		/// <para>The number of data classification breaks that will appear on the map. The default value is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NumberOfClasses { get; set; } = "5";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColorCodedLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Classification Method</para>
		/// </summary>
		public enum ClassificationMethodEnum 
		{
			/// <summary>
			/// <para>Natural Breaks (Jenks)—Natural breaks classes are based on natural groupings inherent in the data. Class breaks that best group similar values and that maximize the differences between classes will be identified. This is the default.</para>
			/// </summary>
			[GPValue("NATURAL_BREAKS")]
			[Description("Natural Breaks (Jenks)")]
			NATURAL_BREAKS,

			/// <summary>
			/// <para>Quantile—Each class will contain an equal number of features. A quantile classification is well suited to linearly distributed data.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para>Equal Interval—The range of attribute values will be divided into equal-sized subranges. This allows you to specify the number of intervals, and ArcGIS Pro will automatically determine the class breaks based on the value range.</para>
			/// </summary>
			[GPValue("EQUAL_INTERVAL")]
			[Description("Equal Interval")]
			Equal_Interval,

			/// <summary>
			/// <para>Geometric Interval—Class breaks will be created based on class intervals that have a geometric series. The geometric coefficient in this classifier can change once (to its inverse) to optimize the class ranges.</para>
			/// </summary>
			[GPValue("GEOMETRIC_INTERVAL")]
			[Description("Geometric Interval")]
			Geometric_Interval,

		}

#endregion
	}
}
