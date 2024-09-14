using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Remove LRS Entity</para>
	/// <para>Remove LRS Entity</para>
	/// <para>Removes a linear referencing system (LRS) entity from an input geodatabase workspace.</para>
	/// </summary>
	public class RemoveLRSEntity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>LRS Workspace</para>
		/// <para>The input geodatabase workspace that contains the LRS entity that will be removed.</para>
		/// </param>
		/// <param name="LrsEntityType">
		/// <para>LRS Entity Type</para>
		/// <para>Specifies the type of LRS entity that will be removed from the input geodatabase workspace.</para>
		/// <para>LRS—An LRS and its dependent LRS Networks, as well as the LRS events, and LRS intersections registered to those LRS Networks, will be removed.</para>
		/// <para>Network—An LRS Network and the LRS events and LRS intersections registered to that LRS Network will be removed.</para>
		/// <para>Event—An LRS event will be removed.</para>
		/// <para>Intersection—An LRS intersection will be removed.</para>
		/// <para>Utility Network Feature Class—A utility network feature class will be removed.</para>
		/// <para><see cref="LrsEntityTypeEnum"/></para>
		/// </param>
		/// <param name="LrsEntityName">
		/// <para>LRS Entity Name</para>
		/// <para>The name of the LRS entity that will be removed from the input geodatabase workspace. The underlying feature classes and tables of the LRS entity will not be deleted.</para>
		/// </param>
		public RemoveLRSEntity(object InWorkspace, object LrsEntityType, object LrsEntityName)
		{
			this.InWorkspace = InWorkspace;
			this.LrsEntityType = LrsEntityType;
			this.LrsEntityName = LrsEntityName;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove LRS Entity</para>
		/// </summary>
		public override string DisplayName() => "Remove LRS Entity";

		/// <summary>
		/// <para>Tool Name : RemoveLRSEntity</para>
		/// </summary>
		public override string ToolName() => "RemoveLRSEntity";

		/// <summary>
		/// <para>Tool Excute Name : locref.RemoveLRSEntity</para>
		/// </summary>
		public override string ExcuteName() => "locref.RemoveLRSEntity";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, LrsEntityType, LrsEntityName, OutWorkspace };

		/// <summary>
		/// <para>LRS Workspace</para>
		/// <para>The input geodatabase workspace that contains the LRS entity that will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>LRS Entity Type</para>
		/// <para>Specifies the type of LRS entity that will be removed from the input geodatabase workspace.</para>
		/// <para>LRS—An LRS and its dependent LRS Networks, as well as the LRS events, and LRS intersections registered to those LRS Networks, will be removed.</para>
		/// <para>Network—An LRS Network and the LRS events and LRS intersections registered to that LRS Network will be removed.</para>
		/// <para>Event—An LRS event will be removed.</para>
		/// <para>Intersection—An LRS intersection will be removed.</para>
		/// <para>Utility Network Feature Class—A utility network feature class will be removed.</para>
		/// <para><see cref="LrsEntityTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsEntityType { get; set; }

		/// <summary>
		/// <para>LRS Entity Name</para>
		/// <para>The name of the LRS entity that will be removed from the input geodatabase workspace. The underlying feature classes and tables of the LRS entity will not be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsEntityName { get; set; }

		/// <summary>
		/// <para>Updated LRS Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>LRS Entity Type</para>
		/// </summary>
		public enum LrsEntityTypeEnum 
		{
			/// <summary>
			/// <para>LRS Entity Type</para>
			/// </summary>
			[GPValue("LRS")]
			[Description("LRS")]
			LRS,

			/// <summary>
			/// <para>Network—An LRS Network and the LRS events and LRS intersections registered to that LRS Network will be removed.</para>
			/// </summary>
			[GPValue("NETWORK")]
			[Description("Network")]
			Network,

			/// <summary>
			/// <para>Event—An LRS event will be removed.</para>
			/// </summary>
			[GPValue("EVENT")]
			[Description("Event")]
			Event,

			/// <summary>
			/// <para>Intersection—An LRS intersection will be removed.</para>
			/// </summary>
			[GPValue("INTERSECTION")]
			[Description("Intersection")]
			Intersection,

			/// <summary>
			/// <para>Utility Network Feature Class—A utility network feature class will be removed.</para>
			/// </summary>
			[GPValue("UN_FEATURE_CLASS")]
			[Description("Utility Network Feature Class")]
			Utility_Network_Feature_Class,

		}

#endregion
	}
}
