using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Calculate Magnetic Components</para>
	/// <para>Calculate Magnetic Components</para>
	/// <para>Computes the magnetic field at point locations for given date and altitude.</para>
	/// </summary>
	public class CalculateMagneticComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point features for which magnetic field values will be calculated.</para>
		/// </param>
		/// <param name="Altitude">
		/// <para>Altitude</para>
		/// <para>The elevation of the Input Features value including the linear unit. Do not use decimal degrees or unknown units. The default is 0 meters.</para>
		/// </param>
		/// <param name="Date">
		/// <para>Date</para>
		/// <para>The date for which magnetic field values will be calculated. The date must be valid for the specified World Magnetic Model. The format must use two digits for the month, two digits for the day, and four digits for the year. The default is the system current date.</para>
		/// </param>
		/// <param name="MagneticComponent">
		/// <para>Magnetic Component</para>
		/// <para>The magnetic component to calculate and the field to which the values will be written.</para>
		/// <para>Component—The magnetic component to calculate.</para>
		/// <para>Declination—The angle between magnetic north and true north. This value varies by location on the globe.</para>
		/// <para>Annual Drift—The annual rate of change in magnetic declination. This value varies by location on the globe.</para>
		/// <para>Inclination—The angle between a compass needle and the plane of the horizon. Inclination is also known as magnetic dip or the dip of the compass needle. This value varies by latitude.</para>
		/// <para>Horizonatl—This value is calculated using north and east components. Horizontal is also known as Horizontal intensity, or H. This value varies by location on the globe.</para>
		/// <para>East component—The easterly intensity of the geomagnetic field. East component is also known as Y. This value varies by location on the globe.</para>
		/// <para>North component—The northerly intensity of the geomagnetic field. North component is also known as X. This value varies by location on the globe.</para>
		/// <para>Vertical intensity—The vertical intensity of the geomagnetic field. Vertical intensity is also known as Z. This value varies by location on the globe.</para>
		/// <para>Total intensity—This value is calculated using horizontal and vertical components. Total intensity is also known as F. This value varies by location on the globe.</para>
		/// <para>Grid variation—The angle between magnetic north and grid north. You must use the Lambert conformal conic projected coordinate system in the ArcMap data frame, in the geoprocessing environment, or in the input point data.</para>
		/// <para>Field—The field to which calculated results are written.</para>
		/// </param>
		public CalculateMagneticComponents(object InFeatures, object Altitude, object Date, object MagneticComponent)
		{
			this.InFeatures = InFeatures;
			this.Altitude = Altitude;
			this.Date = Date;
			this.MagneticComponent = MagneticComponent;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Magnetic Components</para>
		/// </summary>
		public override string DisplayName() => "Calculate Magnetic Components";

		/// <summary>
		/// <para>Tool Name : CalculateMagneticComponents</para>
		/// </summary>
		public override string ToolName() => "CalculateMagneticComponents";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CalculateMagneticComponents</para>
		/// </summary>
		public override string ExcuteName() => "topographic.CalculateMagneticComponents";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Altitude, Date, MagneticComponent, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point features for which magnetic field values will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Altitude</para>
		/// <para>The elevation of the Input Features value including the linear unit. Do not use decimal degrees or unknown units. The default is 0 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Altitude { get; set; }

		/// <summary>
		/// <para>Date</para>
		/// <para>The date for which magnetic field values will be calculated. The date must be valid for the specified World Magnetic Model. The format must use two digits for the month, two digits for the day, and four digits for the year. The default is the system current date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object Date { get; set; }

		/// <summary>
		/// <para>Magnetic Component</para>
		/// <para>The magnetic component to calculate and the field to which the values will be written.</para>
		/// <para>Component—The magnetic component to calculate.</para>
		/// <para>Declination—The angle between magnetic north and true north. This value varies by location on the globe.</para>
		/// <para>Annual Drift—The annual rate of change in magnetic declination. This value varies by location on the globe.</para>
		/// <para>Inclination—The angle between a compass needle and the plane of the horizon. Inclination is also known as magnetic dip or the dip of the compass needle. This value varies by latitude.</para>
		/// <para>Horizonatl—This value is calculated using north and east components. Horizontal is also known as Horizontal intensity, or H. This value varies by location on the globe.</para>
		/// <para>East component—The easterly intensity of the geomagnetic field. East component is also known as Y. This value varies by location on the globe.</para>
		/// <para>North component—The northerly intensity of the geomagnetic field. North component is also known as X. This value varies by location on the globe.</para>
		/// <para>Vertical intensity—The vertical intensity of the geomagnetic field. Vertical intensity is also known as Z. This value varies by location on the globe.</para>
		/// <para>Total intensity—This value is calculated using horizontal and vertical components. Total intensity is also known as F. This value varies by location on the globe.</para>
		/// <para>Grid variation—The angle between magnetic north and grid north. You must use the Lambert conformal conic projected coordinate system in the ArcMap data frame, in the geoprocessing environment, or in the input point data.</para>
		/// <para>Field—The field to which calculated results are written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object MagneticComponent { get; set; }

		/// <summary>
		/// <para>Updated Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateMagneticComponents SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
