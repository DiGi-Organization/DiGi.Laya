#### [DiGi\.Laya](DiGi.Laya.Overview.md 'DiGi\.Laya\.Overview')

## DiGi\.Laya\.Constants Namespace
### Classes

<a name='DiGi.Laya.Constants.Count'></a>

## Count Class

Provides Laya's limits on the options of one choice question\.

```csharp
public static class Count
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Count
### Fields

<a name='DiGi.Laya.Constants.Count.ChoiceOptionMaximum'></a>

## Count\.ChoiceOptionMaximum Field

The most options Laya accepts in one choice question; a single\-choice label set above it is refused\.

```csharp
public const int ChoiceOptionMaximum = 100;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Constants.Count.ChoiceOptionWarning'></a>

## Count\.ChoiceOptionWarning Field

The option count past which Laya's accuracy drops sharply in one choice question; a single\-choice label set above it is classified with a warning\.

```csharp
public const int ChoiceOptionWarning = 20;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Constants.DirectoryName'></a>

## DirectoryName Class

Provides the names of the folders DiGi\.Laya ships its scripts in and looks for\.

```csharp
public static class DirectoryName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DirectoryName
### Fields

<a name='DiGi.Laya.Constants.DirectoryName.DiGiLaya'></a>

## DirectoryName\.DiGiLaya Field

The software destination DiGi\.Maintenance's DeployLaya\.ps1 deploys the Laya runtime package and released checkpoints to: \<SOFTWARE\_DIRECTORY\>\\DiGi\.Laya\\models\\\<name\>\.

```csharp
public const string DiGiLaya = "DiGi.Laya";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.DirectoryName.Laya'></a>

## DirectoryName\.Laya Field

The folder the scripts are shipped in: files/Laya in the repository, Laya beside the built assembly, and the infix of their embedded resource names\.

```csharp
public const string Laya = "Laya";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.DirectoryName.Models'></a>

## DirectoryName\.Models Field

The folder under Laya that deployed checkpoints live in; [IsInsideModelsDirectory\(string\)](DiGi.Laya.md#DiGi.Laya.Query.IsInsideModelsDirectory(string) 'DiGi\.Laya\.Query\.IsInsideModelsDirectory\(string\)') keeps training outputs out of it\.

```csharp
public const string Models = "models";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName'></a>

## FileName Class

Provides the names of the files the Laya scripts are shipped as, write and read, and the files that mark a Laya checkpoint directory\.

```csharp
public static class FileName
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FileName
### Fields

<a name='DiGi.Laya.Constants.FileName.Calibrate'></a>

## FileName\.Calibrate Field

The calibration script\.

```csharp
public const string Calibrate = "calibrate.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Check'></a>

## FileName\.Check Field

The preflight check script\.

```csharp
public const string Check = "check.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.CheckpointConfiguration'></a>

## FileName\.CheckpointConfiguration Field

The configuration file whose presence makes a directory a Laya checkpoint for laya\.load\.

```csharp
public const string CheckpointConfiguration = "rl_agent_config.json";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Model'></a>

## FileName\.Model Field

The weights file of a Laya checkpoint directory; a trained checkpoint without it is not trusted\.

```csharp
public const string Model = "model.safetensors";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Predict'></a>

## FileName\.Predict Field

The prediction script\.

```csharp
public const string Predict = "predict.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Requests'></a>

## FileName\.Requests Field

The JSONL file of requests predict\.py reads, written into the working directory\.

```csharp
public const string Requests = "requests.jsonl";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Requirements'></a>

## FileName\.Requirements Field

The requirements file pinning the laya version the scripts are written against; check\.py reads it\.

```csharp
public const string Requirements = "requirements.txt";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Responses'></a>

## FileName\.Responses Field

The JSONL file of responses predict\.py writes into the working directory\.

```csharp
public const string Responses = "responses.jsonl";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Train'></a>

## FileName\.Train Field

The fine\-tuning script\.

```csharp
public const string Train = "train.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.TrainConfiguration'></a>

## FileName\.TrainConfiguration Field

The JSON file of laya\.train\.TrainConfig fields train\.py reads with \-\-config, written into the working directory\.

```csharp
public const string TrainConfiguration = "train_config.json";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.FileName.Utils'></a>

## FileName\.Utils Field

The module of helpers every script imports; Python resolves it against the directory the script sits in\.

```csharp
public const string Utils = "utils.py";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker'></a>

## Marker Class

Provides the marker lines the scripts print their JSON payload between\.

The payload is read with DiGi.Python's `Query.MarkedJson`, which takes the last marker pair, so whatever laya, torch or transformers print before or after it is never parsed. The scripts print them through `print_marked_json` in files/Laya/utils.py.

```csharp
public static class Marker
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Marker
### Fields

<a name='DiGi.Laya.Constants.Marker.CalibrateJsonBegin'></a>

## Marker\.CalibrateJsonBegin Field

The line calibrate\.py prints before its report\.

```csharp
public const string CalibrateJsonBegin = "LAYA_CALIBRATE_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.CalibrateJsonEnd'></a>

## Marker\.CalibrateJsonEnd Field

The line calibrate\.py prints after its report\.

```csharp
public const string CalibrateJsonEnd = "LAYA_CALIBRATE_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.CheckJsonBegin'></a>

## Marker\.CheckJsonBegin Field

The line check\.py prints before its payload\.

```csharp
public const string CheckJsonBegin = "LAYA_CHECK_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.CheckJsonEnd'></a>

## Marker\.CheckJsonEnd Field

The line check\.py prints after its payload\.

```csharp
public const string CheckJsonEnd = "LAYA_CHECK_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.PredictJsonBegin'></a>

## Marker\.PredictJsonBegin Field

The line predict\.py prints before its run summary\.

```csharp
public const string PredictJsonBegin = "LAYA_PREDICT_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.PredictJsonEnd'></a>

## Marker\.PredictJsonEnd Field

The line predict\.py prints after its run summary\.

```csharp
public const string PredictJsonEnd = "LAYA_PREDICT_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.TrainJsonBegin'></a>

## Marker\.TrainJsonBegin Field

The line train\.py prints before its report\.

```csharp
public const string TrainJsonBegin = "LAYA_TRAIN_JSON_BEGIN";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.Marker.TrainJsonEnd'></a>

## Marker\.TrainJsonEnd Field

The line train\.py prints after its report\.

```csharp
public const string TrainJsonEnd = "LAYA_TRAIN_JSON_END";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Constants.ResourcePrefix'></a>

## ResourcePrefix Class

Provides the prefix of the embedded resource names the scripts are shipped under\.

```csharp
public static class ResourcePrefix
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ResourcePrefix
### Fields

<a name='DiGi.Laya.Constants.ResourcePrefix.Scripts'></a>

## ResourcePrefix\.Scripts Field

The prefix of every script's resource name: the root namespace and the scripts folder, as the csproj's LogicalName "$\(RootNamespace\)\.Laya\.%\(Filename\)%\(Extension\)" builds it\.

```csharp
public const string Scripts = "DiGi.Laya.Laya.";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')