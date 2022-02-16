Introduction
============

This package was ported to NET5 and 6.x version of the swagger from [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore).

Usage
=====

## Nuget package
```
Install-Package Plumsail.Swashbuckle.MicrosoftPowerAutomate
```

## Activate support

Add this extension call to `SwaggerGenOptions`.

```csharp
services.AddSwaggerGen(c =>
{
    c.GenerateMicrosoftExtensions();
});
```

It has optionals arguments:
* `FilePickerCapabilityModel filePicker` for activate [File picker capability](#file-picker-capability)
* `ConnectorMetadataModel connectorMetadata` for add `x-ms-connector-metadata` extension

## Metadata
Metadata attribute can be used for methods, parameters and properties
### Example definition
Code:
```csharp
public class MetdataAttributeClass
{
    [Metadata("Summary", "Description", VisibilityType.Advanced)]
    public string Name { get; }

    public MetdataAttributeClass(string name)
    {
        Name = name;
    }
}
```

Generated swagger:
```json
"MetdataAttributeClass": {
    "type": "object",
    "properties": {
        "name": {
            "type": "string",
            "readOnly": true,
            "x-ms-visibility": "advanced",
            "x-ms-summary": "Summary",
            "description": "Description"
        }
    }
}
```

### Example controller
Code:
```csharp
[Route("api/MetadataAttribute")]
    public class MetadataAttributeController : Controller
    {
        [HttpPost]
        [Metadata("FriendlyAction", "ActionDescription", VisibilityType.Important)]
        public MetadataAttributeClass Post([FromBody][Metadata("FriendlyParameter", "ParameterDescription")] string value)
        { ... }
}
```

Generated swagger:
```json
"/api/MetadataAttribute": {
    "post": {
        "x-ms-visibility": "important",
        "summary": "FriendlyAction",
        "description": "ActionDescription",
        "parameters": [...],
        ...
```

## Dynamic value lookup
Dynamic value lookup can be used for properties and parameters
### Example
Code:
```csharp
public class DynamicValueController : Controller
{
    [HttpGet]
    [Route("api/dynamic")]
    public void Get
    (
        [DynamicValueLookup("opId", "id", "name", parameters: "test=static&test2={dynamic}")]
        string dynamicValue
    ) { }
}
```
Swagger:
```json
"/api/dynamic": {
    "get": {
        "tags": [ "DynamicValue" ],
        "operationId": "ApiDynamicGet",
        "parameters": [
            {
                "name": "dynamicValue", "in": "query",
                "required": false,
                "type": "string",
                "x-ms-dynamic-values": {
                    "operationId": "opId",
                    "value-path": "id",
                    "value-title": "name",
                    "parameters": {
                        "test": "static",
                        "test2": {
                            "parameter": "dynamic"
                        }
                    }
                }
            }
        ],
        "responses": {
            "200": {
                "description": "Success"
            }
        }
    }
}
```

## Dynamic value lookup capability
Dynamic value lookup capability can be used for parameters
### Example
Code:
```csharp
public class DynamicValueCapabilityController : Controller
    {
        [HttpGet]
        [Route("api/capability")]
        public void Get 
        (
            [DynamicValueLookupCapability("capabilityName", "id", "name", parameters: "isFolder=true&test=static&test2={dynamic}")]
            string dynamicValue
        ){ }
    }
```
Swagger:
```json
"/api/capability": {
    "get": {
        "tags": [
            "DynamicValueCapability"
        ],
        "operationId": "ApiCapabilityGet",
        "parameters": [
            {
                "name": "dynamicValue",
                "in": "query",
                "required": false,
                "type": "string",
                "x-ms-dynamic-values": {
                    "capability": "capabilityName",
                    "value-path": "id",
                    "value-title": "name",
                    "parameters": {
                        "isFolder": true,
                        "test": "static",
                        "test2": {
                            "parameter": "dynamic"
                        }
                    }
                }
            }
        ],
        "responses": {
            "200": {
                "description": "Success",
                "schema": {
                    "$ref": "#/definitions/DynamicValueLookupCapabilityClass"
                }
            }
        }
    }
}
```

## Dynamic schema lookup
Dynamic schema lookup can be used for properties, parameters and classes
### Example
Code: 
```csharp
[DynamicSchemaLookup("DynamicSchemaOpId", "schema", "param1={test}&param2=test")]
public class DynamicSchemaLookupClass : Dictionary<string, object> { }
```
Swagger:
```json
"DynamicSchemaLookupClass": {
    "type": "object",
    "properties": { },
    "additionalProperties": {
        "type": "object"
    }
    "x-ms-dynamic-schema": {
        "operationId": "DynamicSchemaOpId",
        "value-path": "schema",
        "parameters": {
            "param1": {
                "parameter": "test"
            },
            "param2": "test"
        }
    }
}
```

## File picker capability
#### Note: file picker design is not final, might change in the future from Microsoft's side
File picker capability can be used in GenerateMicrosoftExtensions method
### Examples
Code:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();

    var filePicker = new FilePickerCapabilityModel
    (
        new FilePickerOperationModel("InitialOperation", null),
        new FilePickerOperationModel("BrowsingOperation", new Dictionary<string, string> {{"Id", "Id"}}),
        "Name",
        "IsFolder",
        "MediaType"
    );
    
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        c.GenerateMicrosoftExtensions(filePicker);
    });
}
```
Swagger:
```json
"x-ms-capabilities": {
    "open": {
        "operation-id": "InitialOperation"
    },
    "browse": {
        "operation-id": "BrowsingOperation",
        "parameters": {
            "Id": {
                "value-property": "Id"
            }
        }
    },
    "value-title": "Name",
    "value-folder-property": "IsFolder",
    "value-media-property": "MediaType"
}
```

## Parameters
Current solution for parameters is that they are given as a query string, dynamic parameters are passed in braces {}
### Examples
Code:
```
parameters: "staticParam=true"
```
Swagger:
```json
"parameters": {
    "staticParameter": true
}
```
Code:
```
parameters: "dynamicParam={previuoslyDefinedParam}"
```
Swagger:
```json
"parameters": {
    "dynamicParam": {
        "parameter": "previouslyDefinedParam"
    }
}
```
Code: 
```
parameters: "staticParam=true&dynamicParam={previouslyDefinedParam}&moreDynamic={example}"
```
Swagger:
```json
"parameters": {
    "staticParam": true,
    "dynamicParam": {
        "parameter": "previouslyDefinedParam"
    },
    "moreDynamic": {
        "parameter": "example"
    }
}
```


## Trigger
Trigger used for mark route as Trigger subscribe method for Power Automate
### Examples
Code:
```csharp
[Route("api/[controller]")]
[ApiController]
public class TriggerController : ControllerBase
{
    [HttpPost]
    [Trigger(TriggerType.Subscription, typeof(TriggerAnswerModel), "TriggerFriendlyName")]
    public IActionResult TriggerSubscription([FromBody] SubscriberCreateRequest subscriber)
    {
        // Register flow and generate SubscriberId and URL for unsubscribe
        return Created(unsubscribeUrl, subscriberId);
    }
}
```
Swagger:
```json
"/api/Trigger": {
    "post": {
        "x-ms-trigger": "signle"
    },
    "x-ms-notification-content": {
        "description": "TriggerFriendlyName",
        "schema": {
            "$ref": "#/definitions/TriggerAnswerModel"
        }
    }
}
```

## Connector metadata
Connector metadata can be used in GenerateMicrosoftExtensions method
### Examples
Code:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        c.GenerateMicrosoftExtensions(connectorMetadata: new ConnectorMetadataModel(
            "http://www.example.com", // Link to your site
            "http://www.example.com/privacy", // Link to your privacy policy
            new [] { "Category1", "Category2" } // Categories for connector
        ));
    });
}
```
Swagger:
```json
"x-ms-connector-metadata": [
    {
      "propertyName": "Website",
      "propertyValue": "http://www.example.com"
    },
    {
      "propertyName": "Privacy policy",
      "propertyValue": "http://www.example.com/privacy"
    },
    {
      "propertyName": "Categories",
      "propertyValue": "Category1;Category2"
    }
]
```