# ArcGIS Pro SDK Geoprocessor

#### 介绍
在ArcGIS Pro SDK(3.0)中仿 ArcGIS Engine 中的Geoprocessor、IGPProcess。

你最好把`Geoprocessor` `IGPProcessExtension`修改成你习惯的写法。

## 实现
1. 3.0版本下的所有工具的生成，包括已过时的工具(1924个).
2. 方法、参数、枚举的`注释`，翻译（机翻）。
3. 提供工具`各自支持`的环境变量设置。
4. 参数`是否可选`特性，默认值。
5. `必填参数`的`有参构造`方法。
6. 数据类型为`字符串`或`布尔类型`的参数新增了对应的枚举类。

## 示例

```c#
using Baci.ArcGIS.ConversionTools;
using Baci.ArcGIS.DataManagementTools;

IGPResult result = (await new FeatureClassToFeatureClass(featureLayer,
    defaultGeodatabasePath,
    "OutputByFcToFcGPTool")
    .SetEnviroment(outputCoordinateSystem: 4490)
    .Run()).GPResult();

SelectLayerByAttribute tool = await new SelectLayerByAttribute(featureLayer)
{
    WhereClause = "objectid = 1",
    //codeValueTypeEnum
    SelectionType = SelectLayerByAttribute.SelectionTypeEnum.New_selection. Value()
}.Run();
result = tool.GPResult();
//Derived Parameter 回写
Console.WriteLine(tool.Count);

```

