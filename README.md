# ArcGIS Pro SDK Geoprocessor

#### Introduction
In the ArcGIS Pro SDK (3.0), it mimics the Geoprocessor and IGPProcess in ArcGIS Engine.

You'll better modify the Geoprocessor and IGPProcessExtension to suit your habits.

## Implementation
1. Generation of all tools under version 3.0, including obsolete tools (1924).
2. 'Annotations' of methods, parameters, and enumerations.
3. Provide the tools to set the environment variables that are 'supported by each'.
4. Parameter 'optional' feature, default value.
5. 'Parameter Construction' method for 'Required Parameters'.
6. Added a corresponding enumeration class for parameters with data type 'string' or 'boolean'.

## Example

```c#
using Baci.ArcGIS.ConversionTools;
using Baci.ArcGIS.Geoprocessor.DataManagementTools;

IGPResult result = (await new FeatureClassToFeatureClass(featureLayer,
    defaultGeodatabasePath,
    "OutputByFcToFcGPTool")
    . SetEnviroment(outputCoordinateSystem: 4490)
    . Run()).GPResult;

SelectLayerByAttribute tool = await new SelectLayerByAttribute(featureLayer)
{
    WhereClause = "objectid = 1",
    //codeValueTypeEnum
    SelectionType = SelectLayerByAttribute.SelectionTypeEnum.New_selection. Value()
}. Run();
result = tool.GPResult;
//Derived Parameter Reflow
Console.WriteLine(tool.Count);

```

