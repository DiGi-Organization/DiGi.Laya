#### [DiGi\.Laya](DiGi.Laya.Overview.md 'DiGi\.Laya\.Overview')

## DiGi\.Laya\.Classes Namespace
### Classes

<a name='DiGi.Laya.Classes.LayaAnswer'></a>

## LayaAnswer Class

Represents the Laya decision model's answer to one named question\.

The derived type matches the question type: [LayaChoiceAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer 'DiGi\.Laya\.Classes\.LayaChoiceAnswer'), [LayaScoreAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreAnswer 'DiGi\.Laya\.Classes\.LayaScoreAnswer') or [LayaNoulAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulAnswer 'DiGi\.Laya\.Classes\.LayaNoulAnswer'). A list of answers round-trips polymorphically through the type discriminator of the DiGi serializer.

The DiGi serializer keys members by name across the hierarchy and lets the derived one win, so a derived type must not reuse [Name](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer.Name 'DiGi\.Laya\.Classes\.LayaAnswer\.Name'), [Confidence](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer.Confidence 'DiGi\.Laya\.Classes\.LayaAnswer\.Confidence') or [AnswerConfidence](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer.AnswerConfidence 'DiGi\.Laya\.Classes\.LayaAnswer\.AnswerConfidence').

```csharp
public abstract class LayaAnswer : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaAnswer

Derived  
↳ [LayaChoiceAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer 'DiGi\.Laya\.Classes\.LayaChoiceAnswer')  
↳ [LayaNoulAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulAnswer 'DiGi\.Laya\.Classes\.LayaNoulAnswer')  
↳ [LayaScoreAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreAnswer 'DiGi\.Laya\.Classes\.LayaScoreAnswer')

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(DiGi.Laya.Classes.LayaAnswer)'></a>

## LayaAnswer\(LayaAnswer\) Constructor

Initializes a new instance of the [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer') class by copying an existing answer\.

```csharp
protected LayaAnswer(DiGi.Laya.Classes.LayaAnswer? layaAnswer);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(DiGi.Laya.Classes.LayaAnswer).layaAnswer'></a>

`layaAnswer` [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer')

The source answer to copy from\.

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(string,System.Nullable_double_,System.Nullable_double_)'></a>

## LayaAnswer\(string, Nullable\<double\>, Nullable\<double\>\) Constructor

Initializes a new instance of the [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer') class\.

```csharp
protected LayaAnswer(string? name, System.Nullable<double> confidence, System.Nullable<double> answerConfidence);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(string,System.Nullable_double_,System.Nullable_double_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the question answered\.

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(string,System.Nullable_double_,System.Nullable_double_).confidence'></a>

`confidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya derives from the answer's probability distribution, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(string,System.Nullable_double_,System.Nullable_double_).answerConfidence'></a>

`answerConfidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya reports for the selected answer itself, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(System.Text.Json.Nodes.JsonObject)'></a>

## LayaAnswer\(JsonObject\) Constructor

Initializes a new instance of the [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer') class using a JSON object\.

```csharp
protected LayaAnswer(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaAnswer.LayaAnswer(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the answer data\.
### Properties

<a name='DiGi.Laya.Classes.LayaAnswer.AnswerConfidence'></a>

## LayaAnswer\.AnswerConfidence Property

Gets the confidence Laya reports for the selected answer itself \(its `answer_confidence`\), or `null` when not reported\.

```csharp
public System.Nullable<double> AnswerConfidence { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaAnswer.Confidence'></a>

## LayaAnswer\.Confidence Property

Gets the confidence Laya derives from the answer's probability distribution \(its `confidence`\), or `null` when not reported\.

The shipped checkpoints are uncalibrated and over-confident; read this only from a calibrated checkpoint.

```csharp
public System.Nullable<double> Confidence { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaAnswer.Name'></a>

## LayaAnswer\.Name Property

Gets the name of the question answered\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaAnswer.QuestionType'></a>

## LayaAnswer\.QuestionType Property

Gets the type of the question answered, fixed by the derived type\.

```csharp
public abstract DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions'></a>

## LayaCalibrationOptions Class

Provides the settings of one calibration run of calibrate\.py: the interpreter, the checkpoint, the labelled data, and where the calibration file goes\.

For a checkpoint fine-tuning did not calibrate - the shipped ones carry temperatures of 1 and are over-confident. The checkpoint is never changed: the temperatures go to a calibration file outside it, which [CalibrationPath](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions.CalibrationPath 'DiGi\.Laya\.Classes\.LayaPredictionOptions\.CalibrationPath') then names (DiGi-Organization/DiGi.Laya#1, D3).

```csharp
public class LayaCalibrationOptions : DiGi.Core.Classes.SerializableOptions, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → LayaCalibrationOptions

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.LayaCalibrationOptions()'></a>

## LayaCalibrationOptions\(\) Constructor

Initializes a new instance of the [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions') class with default values\.

```csharp
public LayaCalibrationOptions();
```

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.LayaCalibrationOptions(DiGi.Laya.Classes.LayaCalibrationOptions)'></a>

## LayaCalibrationOptions\(LayaCalibrationOptions\) Constructor

Initializes a new instance of the [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions') class by copying an existing options instance\.

```csharp
public LayaCalibrationOptions(DiGi.Laya.Classes.LayaCalibrationOptions? layaCalibrationOptions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.LayaCalibrationOptions(DiGi.Laya.Classes.LayaCalibrationOptions).layaCalibrationOptions'></a>

`layaCalibrationOptions` [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions')

The source options instance to copy from\.

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.LayaCalibrationOptions(System.Text.Json.Nodes.JsonObject)'></a>

## LayaCalibrationOptions\(JsonObject\) Constructor

Initializes a new instance of the [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions') class using a JSON object\.

```csharp
public LayaCalibrationOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.LayaCalibrationOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the settings\.
### Properties

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.CalibrationFilePath'></a>

## LayaCalibrationOptions\.CalibrationFilePath Property

Gets or sets the labelled JSONL the temperatures are fitted on, in the training\-line schema \(`Modify.WriteTrainingFile`\); keep it apart from the training data\.

```csharp
public string? CalibrationFilePath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.CalibrationPath'></a>

## LayaCalibrationOptions\.CalibrationPath Property

Gets or sets the calibration JSON to write, outside the checkpoint directory\. An existing file there is deleted before the run, so a failed run never leaves an older calibration looking like this one's\.

```csharp
public string? CalibrationPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.Device'></a>

## LayaCalibrationOptions\.Device Property

Gets or sets the device the model runs on, passed to calibrate\.py as \-\-device\.

```csharp
public DiGi.Laya.Enums.LayaDevice Device { get; set; }
```

#### Property Value
[LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.InactivityTimeout'></a>

## LayaCalibrationOptions\.InactivityTimeout Property

Gets or sets the span without output after which the run is ended as stalled, or `null` for no limit\. calibrate\.py prints nothing until it is done\.

```csharp
public System.Nullable<System.TimeSpan> InactivityTimeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.ModelPath'></a>

## LayaCalibrationOptions\.ModelPath Property

Gets or sets the checkpoint directory to calibrate, resolved by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)'); a model name or Hub id is refused\.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.PythonPath'></a>

## LayaCalibrationOptions\.PythonPath Property

Gets or sets the CPython interpreter carrying laya, resolved by [LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)'); `null` searches PATH\.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.Seed'></a>

## LayaCalibrationOptions\.Seed Property

Gets or sets the seed of laya's held\-out split, passed to calibrate\.py as \-\-seed\.

```csharp
public int Seed { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.Timeout'></a>

## LayaCalibrationOptions\.Timeout Property

Gets or sets the span after which the run is ended whatever it is doing, or `null` for no limit\.

```csharp
public System.Nullable<System.TimeSpan> Timeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationOptions.WorkingDirectory'></a>

## LayaCalibrationOptions\.WorkingDirectory Property

Gets or sets the directory the scripts are written to, or `null` for a fresh temporary directory removed after the run\.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationResult'></a>

## LayaCalibrationResult Class

Represents how a calibration run went: the calibration file it wrote, the temperatures in it, and every finding about the run\.

```csharp
public class LayaCalibrationResult : DiGi.Core.Classes.SerializableResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → LayaCalibrationResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(DiGi.Laya.Classes.LayaCalibrationResult)'></a>

## LayaCalibrationResult\(LayaCalibrationResult\) Constructor

Initializes a new instance of the [LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult') class by copying an existing instance\.

```csharp
public LayaCalibrationResult(DiGi.Laya.Classes.LayaCalibrationResult? layaCalibrationResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(DiGi.Laya.Classes.LayaCalibrationResult).layaCalibrationResult'></a>

`layaCalibrationResult` [LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_)'></a>

## LayaCalibrationResult\(string, string, string, Nullable\<int\>, Nullable\<int\>, IEnumerable\<LayaTemperature\>, Nullable\<double\>, Nullable\<double\>, Nullable\<int\>, Nullable\<TimeSpan\>, int, bool, bool, bool, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult') class\.

```csharp
public LayaCalibrationResult(string? calibrationPath, string? calibrationSHA256, string? modelSHA256, System.Nullable<int> recordCount, System.Nullable<int> skippedCount, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaTemperature>? temperatures, System.Nullable<double> expectedCalibrationErrorBefore, System.Nullable<double> expectedCalibrationErrorAfter, System.Nullable<int> evaluationRecordCount, System.Nullable<System.TimeSpan> duration, int exitCode, bool stalled, bool timedOut, bool cancelled, System.Collections.Generic.IEnumerable<string>? messages);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).calibrationPath'></a>

`calibrationPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The calibration file the run was to write\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).calibrationSHA256'></a>

`calibrationSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the calibration file, or `null` when the run did not write one\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the checkpoint directory the temperatures were fitted for; the checkpoint itself is never changed\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).recordCount'></a>

`recordCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of labelled questions the temperatures were fitted on, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).skippedCount'></a>

`skippedCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of labelled rows or questions that could not be read, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).temperatures'></a>

`temperatures` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The fitted temperatures, by question type\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).expectedCalibrationErrorBefore'></a>

`expectedCalibrationErrorBefore` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The expected calibration error before calibration on the held\-out records, or `null` when laya held none out \(fewer than about 2500 records per question type and option count\)\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).expectedCalibrationErrorAfter'></a>

`expectedCalibrationErrorAfter` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The expected calibration error after calibration on the held\-out records, or `null` when laya held none out\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).evaluationRecordCount'></a>

`evaluationRecordCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of held\-out records the expected calibration errors rest on, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).duration'></a>

`duration` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The wall\-clock time of the run, or `null` when no process was started\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The exit code of the script; \-1 when the process was ended, failed to start or was never started\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).stalled'></a>

`stalled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended for inactivity\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).timedOut'></a>

`timedOut` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended by the overall time limit\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).cancelled'></a>

`cancelled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the caller cancelled the run\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_double_,System.Nullable_double_,System.Nullable_int_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings about the run\.

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaCalibrationResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult') class using a JSON object\.

```csharp
public LayaCalibrationResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCalibrationResult.LayaCalibrationResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaCalibrationResult.CalibrationPath'></a>

## LayaCalibrationResult\.CalibrationPath Property

Gets the calibration file the run was to write\.

```csharp
public string? CalibrationPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.CalibrationSHA256'></a>

## LayaCalibrationResult\.CalibrationSHA256 Property

Gets the SHA\-256 of the calibration file, or `null` when the run did not write one\.

```csharp
public string? CalibrationSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.Cancelled'></a>

## LayaCalibrationResult\.Cancelled Property

Gets a value indicating whether the caller cancelled the run\.

```csharp
public bool Cancelled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.Duration'></a>

## LayaCalibrationResult\.Duration Property

Gets the wall\-clock time of the run, or `null` when no process was started\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.EvaluationRecordCount'></a>

## LayaCalibrationResult\.EvaluationRecordCount Property

Gets the number of held\-out records the expected calibration errors rest on, or `null` when not reported\.

```csharp
public System.Nullable<int> EvaluationRecordCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.ExitCode'></a>

## LayaCalibrationResult\.ExitCode Property

Gets the exit code of the script; \-1 when the process was ended, failed to start or was never started\.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.ExpectedCalibrationErrorAfter'></a>

## LayaCalibrationResult\.ExpectedCalibrationErrorAfter Property

Gets the expected calibration error after calibration on the held\-out records, or `null` when laya held none out\.

```csharp
public System.Nullable<double> ExpectedCalibrationErrorAfter { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.ExpectedCalibrationErrorBefore'></a>

## LayaCalibrationResult\.ExpectedCalibrationErrorBefore Property

Gets the expected calibration error before calibration on the held\-out records, or `null` when laya held none out \(fewer than about 2500 records per question type and option count\)\.

```csharp
public System.Nullable<double> ExpectedCalibrationErrorBefore { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.Messages'></a>

## LayaCalibrationResult\.Messages Property

Gets the findings about the run\.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.ModelSHA256'></a>

## LayaCalibrationResult\.ModelSHA256 Property

Gets the SHA\-256 of the checkpoint directory the temperatures were fitted for; the checkpoint itself is never changed\.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.RecordCount'></a>

## LayaCalibrationResult\.RecordCount Property

Gets the number of labelled questions the temperatures were fitted on, or `null` when not reported\.

```csharp
public System.Nullable<int> RecordCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.SkippedCount'></a>

## LayaCalibrationResult\.SkippedCount Property

Gets the number of labelled rows or questions that could not be read, or `null` when not reported\.

```csharp
public System.Nullable<int> SkippedCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.Stalled'></a>

## LayaCalibrationResult\.Stalled Property

Gets a value indicating whether the process was ended for inactivity\.

```csharp
public bool Stalled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.Temperatures'></a>

## LayaCalibrationResult\.Temperatures Property

Gets the fitted temperatures, by question type\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaTemperature>? Temperatures { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaCalibrationResult.TimedOut'></a>

## LayaCalibrationResult\.TimedOut Property

Gets a value indicating whether the process was ended by the overall time limit\.

```csharp
public bool TimedOut { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaChoiceAnswer'></a>

## LayaChoiceAnswer Class

Represents the answer to a [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion'): the selected label and the probability of every option\.

```csharp
public class LayaChoiceAnswer : DiGi.Laya.Classes.LayaAnswer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer') → LayaChoiceAnswer
### Constructors

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(DiGi.Laya.Classes.LayaChoiceAnswer)'></a>

## LayaChoiceAnswer\(LayaChoiceAnswer\) Constructor

Initializes a new instance of the [LayaChoiceAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer 'DiGi\.Laya\.Classes\.LayaChoiceAnswer') class by copying an existing answer\.

```csharp
public LayaChoiceAnswer(DiGi.Laya.Classes.LayaChoiceAnswer? layaChoiceAnswer);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(DiGi.Laya.Classes.LayaChoiceAnswer).layaChoiceAnswer'></a>

`layaChoiceAnswer` [LayaChoiceAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer 'DiGi\.Laya\.Classes\.LayaChoiceAnswer')

The source answer to copy from\.

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(string,System.Nullable_double_,System.Nullable_double_,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaProbability_)'></a>

## LayaChoiceAnswer\(string, Nullable\<double\>, Nullable\<double\>, string, IEnumerable\<LayaProbability\>\) Constructor

Initializes a new instance of the [LayaChoiceAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer 'DiGi\.Laya\.Classes\.LayaChoiceAnswer') class\.

```csharp
public LayaChoiceAnswer(string? name, System.Nullable<double> confidence, System.Nullable<double> answerConfidence, string? label, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaProbability>? probabilities);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(string,System.Nullable_double_,System.Nullable_double_,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaProbability_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the question answered\.

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(string,System.Nullable_double_,System.Nullable_double_,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaProbability_).confidence'></a>

`confidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya derives from the probability distribution, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(string,System.Nullable_double_,System.Nullable_double_,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaProbability_).answerConfidence'></a>

`answerConfidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya reports for the selected label itself, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(string,System.Nullable_double_,System.Nullable_double_,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaProbability_).label'></a>

`label` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The selected label, the option with the highest probability\.

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(string,System.Nullable_double_,System.Nullable_double_,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaProbability_).probabilities'></a>

`probabilities` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The probability of every option, in the order of the question's criteria\.

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(System.Text.Json.Nodes.JsonObject)'></a>

## LayaChoiceAnswer\(JsonObject\) Constructor

Initializes a new instance of the [LayaChoiceAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer 'DiGi\.Laya\.Classes\.LayaChoiceAnswer') class using a JSON object\.

```csharp
public LayaChoiceAnswer(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.LayaChoiceAnswer(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the answer data\.
### Properties

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.Label'></a>

## LayaChoiceAnswer\.Label Property

Gets the selected label, the option with the highest probability \(Laya's `choice`\)\.

```csharp
public string? Label { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.Probabilities'></a>

## LayaChoiceAnswer\.Probabilities Property

Gets the probability of every option, in the order of the question's criteria\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaProbability>? Probabilities { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaChoiceAnswer.QuestionType'></a>

## LayaChoiceAnswer\.QuestionType Property

Gets [Choice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType.Choice 'DiGi\.Laya\.Enums\.LayaQuestionType\.Choice')\.

```csharp
public override DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaChoiceQuestion'></a>

## LayaChoiceQuestion Class

Represents a question answered by choosing one of a closed set of labelled options\.

Laya's accuracy drops sharply past about 20 short options in one question and it refuses more than 100.

```csharp
public class LayaChoiceQuestion : DiGi.Laya.Classes.LayaQuestion
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion') → LayaChoiceQuestion
### Constructors

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(DiGi.Laya.Classes.LayaChoiceQuestion)'></a>

## LayaChoiceQuestion\(LayaChoiceQuestion\) Constructor

Initializes a new instance of the [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion') class by copying an existing question\.

```csharp
public LayaChoiceQuestion(DiGi.Laya.Classes.LayaChoiceQuestion? layaChoiceQuestion);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(DiGi.Laya.Classes.LayaChoiceQuestion).layaChoiceQuestion'></a>

`layaChoiceQuestion` [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion')

The source question to copy from\.

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(string,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaCriterion_)'></a>

## LayaChoiceQuestion\(string, string, IEnumerable\<LayaCriterion\>\) Constructor

Initializes a new instance of the [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion') class\.

```csharp
public LayaChoiceQuestion(string? name, string? instructions, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaCriterion>? criteria);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(string,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaCriterion_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name the question is asked and answered under, unique within one request\.

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(string,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaCriterion_).instructions'></a>

`instructions` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The instructions telling the model what to decide\.

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(string,string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaCriterion_).criteria'></a>

`criteria` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The options to choose from, in the order they are shown to the model\.

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(System.Text.Json.Nodes.JsonObject)'></a>

## LayaChoiceQuestion\(JsonObject\) Constructor

Initializes a new instance of the [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion') class using a JSON object\.

```csharp
public LayaChoiceQuestion(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.LayaChoiceQuestion(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the question data\.
### Properties

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.Criteria'></a>

## LayaChoiceQuestion\.Criteria Property

Gets the options to choose from, in the order they are shown to the model\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaCriterion>? Criteria { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaChoiceQuestion.QuestionType'></a>

## LayaChoiceQuestion\.QuestionType Property

Gets [Choice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType.Choice 'DiGi\.Laya\.Enums\.LayaQuestionType\.Choice')\.

```csharp
public override DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaClassificationOptions'></a>

## LayaClassificationOptions Class

Provides the decision rules that turn Laya's probabilities into suggested labels\.

A label set without a [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold') suggests the single most probable label of a single-choice set, and every label of a multi-label set with a probability of 0.5 or more.

A multi-label label takes the threshold of the rule naming it ([LabelId](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.LabelId 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.LabelId')), else of the rule of its set, else 0.5. A rule naming an unknown set or label is reported as a warning by [ClassifyAsync\(this IEnumerable&lt;LayaItem&gt;, IEnumerable&lt;LayaLabelSet&gt;, LayaClassificationOptions, LayaPredictionOptions, IEnumerable&lt;LayaLabelConstraint&gt;, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken) 'DiGi\.Laya\.Modify\.ClassifyAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>, DiGi\.Laya\.Classes\.LayaClassificationOptions, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelConstraint\>, System\.Threading\.CancellationToken\)').

```csharp
public class LayaClassificationOptions : DiGi.Core.Classes.SerializableOptions, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → LayaClassificationOptions

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaClassificationOptions.LayaClassificationOptions()'></a>

## LayaClassificationOptions\(\) Constructor

Initializes a new instance of the [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions') class with default values\.

```csharp
public LayaClassificationOptions();
```

<a name='DiGi.Laya.Classes.LayaClassificationOptions.LayaClassificationOptions(DiGi.Laya.Classes.LayaClassificationOptions)'></a>

## LayaClassificationOptions\(LayaClassificationOptions\) Constructor

Initializes a new instance of the [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions') class by copying an existing options instance\.

```csharp
public LayaClassificationOptions(DiGi.Laya.Classes.LayaClassificationOptions? layaClassificationOptions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationOptions.LayaClassificationOptions(DiGi.Laya.Classes.LayaClassificationOptions).layaClassificationOptions'></a>

`layaClassificationOptions` [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions')

The source options instance to copy from\.

<a name='DiGi.Laya.Classes.LayaClassificationOptions.LayaClassificationOptions(System.Text.Json.Nodes.JsonObject)'></a>

## LayaClassificationOptions\(JsonObject\) Constructor

Initializes a new instance of the [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions') class using a JSON object\.

```csharp
public LayaClassificationOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationOptions.LayaClassificationOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the settings\.
### Properties

<a name='DiGi.Laya.Classes.LayaClassificationOptions.MinimumConfidence'></a>

## LayaClassificationOptions\.MinimumConfidence Property

Gets or sets the confidence an answer must reach for any of its labels to be suggested, or `null` for no floor\.

The confidence is Laya's own ([Confidence](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer.Confidence 'DiGi\.Laya\.Classes\.LayaAnswer\.Confidence')): derived from the option distribution for a choice question, and the larger of the probabilities of true and false for a noul question. An answer below the floor suggests nothing, and its probabilities are still reported. Uncalibrated checkpoints are over-confident, so set a floor only with a calibrated one.

```csharp
public System.Nullable<double> MinimumConfidence { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaClassificationOptions.Thresholds'></a>

## LayaClassificationOptions\.Thresholds Property

Gets or sets the decision rule of each label set that does not use the defaults, or `null` for the defaults everywhere\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaLabelSetThreshold>? Thresholds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaClassificationResult'></a>

## LayaClassificationResult Class

Represents the classification of one item: a score per label of every label set, and what went wrong with it\.

```csharp
public class LayaClassificationResult : DiGi.Core.Classes.SerializableResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → LayaClassificationResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(DiGi.Laya.Classes.LayaClassificationResult)'></a>

## LayaClassificationResult\(LayaClassificationResult\) Constructor

Initializes a new instance of the [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult') class by copying an existing instance\.

```csharp
public LayaClassificationResult(DiGi.Laya.Classes.LayaClassificationResult? layaClassificationResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(DiGi.Laya.Classes.LayaClassificationResult).layaClassificationResult'></a>

`layaClassificationResult` [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelScore_,string,System.Nullable_System.DateTimeOffset_,System.Collections.Generic.IEnumerable_string_)'></a>

## LayaClassificationResult\(string, IEnumerable\<LayaLabelScore\>, string, Nullable\<DateTimeOffset\>, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult') class\.

```csharp
public LayaClassificationResult(string? itemId, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelScore>? scores, string? modelSHA256, System.Nullable<System.DateTimeOffset> createdAt, System.Collections.Generic.IEnumerable<string>? messages);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelScore_,string,System.Nullable_System.DateTimeOffset_,System.Collections.Generic.IEnumerable_string_).itemId'></a>

`itemId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the item\.

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelScore_,string,System.Nullable_System.DateTimeOffset_,System.Collections.Generic.IEnumerable_string_).scores'></a>

`scores` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The scores, label set by label set in set order, labels in label order\.

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelScore_,string,System.Nullable_System.DateTimeOffset_,System.Collections.Generic.IEnumerable_string_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the checkpoint directory that scored the item\.

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelScore_,string,System.Nullable_System.DateTimeOffset_,System.Collections.Generic.IEnumerable_string_).createdAt'></a>

`createdAt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the result was made\.

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelScore_,string,System.Nullable_System.DateTimeOffset_,System.Collections.Generic.IEnumerable_string_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings about this item only: no response, left out of the run, refused by laya, a missing answer, a truncated request\. Findings about the whole run are in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.Messages 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.Messages')\.

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaClassificationResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult') class using a JSON object\.

```csharp
public LayaClassificationResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationResult.LayaClassificationResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaClassificationResult.CreatedAt'></a>

## LayaClassificationResult\.CreatedAt Property

Gets the moment the result was made\.

```csharp
public System.Nullable<System.DateTimeOffset> CreatedAt { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaClassificationResult.ItemId'></a>

## LayaClassificationResult\.ItemId Property

Gets the identifier of the item\.

```csharp
public string? ItemId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaClassificationResult.Messages'></a>

## LayaClassificationResult\.Messages Property

Gets the findings about this item only: no response, left out of the run, refused by laya, a missing answer, a truncated request\.

Findings about the whole run - a refused or oversized label set, the process exit, a time limit - are in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.Messages 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.Messages') and are not repeated here.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaClassificationResult.ModelSHA256'></a>

## LayaClassificationResult\.ModelSHA256 Property

Gets the SHA\-256 of the checkpoint directory that scored the item\.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaClassificationResult.Scores'></a>

## LayaClassificationResult\.Scores Property

Gets the scores, label set by label set in set order, labels in label order\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaLabelScore>? Scores { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult'></a>

## LayaClassificationRunResult Class

Represents how a classification run went: one result per item, the status of the prediction run behind them and the findings about the run as a whole\.

The run status tells a run that answered apart from one that did not without reading message text: a run that was refused before a process started has no [Duration](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.Duration 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.Duration') and an [ExitCode](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.ExitCode 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.ExitCode') of -1, and a process that failed or was ended has a non-zero [ExitCode](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.ExitCode 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.ExitCode') or sets [Stalled](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.Stalled 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.Stalled'), [TimedOut](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.TimedOut 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.TimedOut') or [Cancelled](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.Cancelled 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.Cancelled'). A run that answered with no suggested label still has [ExitCode](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult.ExitCode 'DiGi\.Laya\.Classes\.LayaClassificationRunResult\.ExitCode') 0.

```csharp
public class LayaClassificationRunResult : DiGi.Core.Classes.SerializableResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → LayaClassificationRunResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(DiGi.Laya.Classes.LayaClassificationRunResult)'></a>

## LayaClassificationRunResult\(LayaClassificationRunResult\) Constructor

Initializes a new instance of the [LayaClassificationRunResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult 'DiGi\.Laya\.Classes\.LayaClassificationRunResult') class by copying an existing result\.

```csharp
public LayaClassificationRunResult(DiGi.Laya.Classes.LayaClassificationRunResult? layaClassificationRunResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(DiGi.Laya.Classes.LayaClassificationRunResult).layaClassificationRunResult'></a>

`layaClassificationRunResult` [LayaClassificationRunResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult 'DiGi\.Laya\.Classes\.LayaClassificationRunResult')

The source result to copy from\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_)'></a>

## LayaClassificationRunResult\(IEnumerable\<LayaClassificationResult\>, string, string, Nullable\<TimeSpan\>, int, bool, bool, bool, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [LayaClassificationRunResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult 'DiGi\.Laya\.Classes\.LayaClassificationRunResult') class\.

```csharp
public LayaClassificationRunResult(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaClassificationResult>? results, string? modelSHA256, string? calibrationSHA256, System.Nullable<System.TimeSpan> duration, int exitCode, bool stalled, bool timedOut, bool cancelled, System.Collections.Generic.IEnumerable<string>? messages);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).results'></a>

`results` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The classification results, one per item in item order\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the checkpoint directory the run used, or `null` when no process was started\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).calibrationSHA256'></a>

`calibrationSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the calibration file the run used, or `null` when it used none\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).duration'></a>

`duration` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The wall\-clock time of the prediction run, or `null` when no process was started\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The exit code of predict\.py; \-1 when the process was ended, failed to start or was never started\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).stalled'></a>

`stalled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended for inactivity\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).timedOut'></a>

`timedOut` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended by the overall time limit\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).cancelled'></a>

`cancelled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the caller cancelled the run\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings about the run as a whole: a refused label set, a label set warning, a refused prediction run, the process exit or a time limit\.

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaClassificationRunResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaClassificationRunResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationRunResult 'DiGi\.Laya\.Classes\.LayaClassificationRunResult') class using a JSON object\.

```csharp
public LayaClassificationRunResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.LayaClassificationRunResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.CalibrationSHA256'></a>

## LayaClassificationRunResult\.CalibrationSHA256 Property

Gets the SHA\-256 of the calibration file the run used, or `null` when it used none\.

```csharp
public string? CalibrationSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.Cancelled'></a>

## LayaClassificationRunResult\.Cancelled Property

Gets a value indicating whether the caller cancelled the run\.

```csharp
public bool Cancelled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.Duration'></a>

## LayaClassificationRunResult\.Duration Property

Gets the wall\-clock time of the prediction run, or `null` when no process was started\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.ExitCode'></a>

## LayaClassificationRunResult\.ExitCode Property

Gets the exit code of predict\.py; \-1 when the process was ended, failed to start or was never started\.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.Messages'></a>

## LayaClassificationRunResult\.Messages Property

Gets the findings about the run as a whole: a refused label set, a label set warning, a refused prediction run, the process exit or a time limit\.

A finding about one item is in that item's [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult.Messages 'DiGi\.Laya\.Classes\.LayaClassificationResult\.Messages') instead, and is not repeated here.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.ModelSHA256'></a>

## LayaClassificationRunResult\.ModelSHA256 Property

Gets the SHA\-256 of the checkpoint directory the run used \(DiGi\.Python's `Query.DirectorySHA256`\), or `null` when no process was started\.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.Results'></a>

## LayaClassificationRunResult\.Results Property

Gets the classification results, one per item in item order; empty when the label sets were refused\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaClassificationResult>? Results { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.Stalled'></a>

## LayaClassificationRunResult\.Stalled Property

Gets a value indicating whether the process was ended for inactivity\.

```csharp
public bool Stalled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaClassificationRunResult.TimedOut'></a>

## LayaClassificationRunResult\.TimedOut Property

Gets a value indicating whether the process was ended by the overall time limit\.

```csharp
public bool TimedOut { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaConfusionRow'></a>

## LayaConfusionRow Class

Represents one non\-empty cell of the confusion matrix of a single\-choice label set\.

```csharp
public class LayaConfusionRow : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaConfusionRow

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(DiGi.Laya.Classes.LayaConfusionRow)'></a>

## LayaConfusionRow\(LayaConfusionRow\) Constructor

Initializes a new instance of the [LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow') class by copying an existing instance\.

```csharp
public LayaConfusionRow(DiGi.Laya.Classes.LayaConfusionRow? layaConfusionRow);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(DiGi.Laya.Classes.LayaConfusionRow).layaConfusionRow'></a>

`layaConfusionRow` [LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(string,string,int)'></a>

## LayaConfusionRow\(string, string, int\) Constructor

Initializes a new instance of the [LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow') class\.

```csharp
public LayaConfusionRow(string? actualLabelId, string? predictedLabelId, int count);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(string,string,int).actualLabelId'></a>

`actualLabelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The true label\.

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(string,string,int).predictedLabelId'></a>

`predictedLabelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The label ranked first by probability\.

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(string,string,int).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items with that pair\.

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(System.Text.Json.Nodes.JsonObject)'></a>

## LayaConfusionRow\(JsonObject\) Constructor

Initializes a new instance of the [LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow') class using a JSON object\.

```csharp
public LayaConfusionRow(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaConfusionRow.LayaConfusionRow(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaConfusionRow.ActualLabelId'></a>

## LayaConfusionRow\.ActualLabelId Property

Gets the true label\.

```csharp
public string? ActualLabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaConfusionRow.Count'></a>

## LayaConfusionRow\.Count Property

Gets the number of items with that pair\.

```csharp
public int Count { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaConfusionRow.PredictedLabelId'></a>

## LayaConfusionRow\.PredictedLabelId Property

Gets the label ranked first by probability\.

```csharp
public string? PredictedLabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCriterion'></a>

## LayaCriterion Class

Represents one option of a [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion'): the label the model answers with and the description it reads\.

Held in a list by [Criteria](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion.Criteria 'DiGi\.Laya\.Classes\.LayaChoiceQuestion\.Criteria') rather than in a dictionary keyed by label, because the DiGi serializer rebuilds a dictionary with the default comparer of its type and loses the option order, which Laya reads as the order of the options.

```csharp
public class LayaCriterion : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaCriterion

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(DiGi.Laya.Classes.LayaCriterion)'></a>

## LayaCriterion\(LayaCriterion\) Constructor

Initializes a new instance of the [LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion') class by copying an existing criterion\.

```csharp
public LayaCriterion(DiGi.Laya.Classes.LayaCriterion? layaCriterion);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(DiGi.Laya.Classes.LayaCriterion).layaCriterion'></a>

`layaCriterion` [LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion')

The source criterion to copy from\.

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(string,string)'></a>

## LayaCriterion\(string, string\) Constructor

Initializes a new instance of the [LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion') class\.

```csharp
public LayaCriterion(string? label, string? description);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(string,string).label'></a>

`label` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The label the model answers with when it selects this option\.

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the option shown to the model\.

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(System.Text.Json.Nodes.JsonObject)'></a>

## LayaCriterion\(JsonObject\) Constructor

Initializes a new instance of the [LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion') class using a JSON object\.

```csharp
public LayaCriterion(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaCriterion.LayaCriterion(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the criterion data\.
### Properties

<a name='DiGi.Laya.Classes.LayaCriterion.Description'></a>

## LayaCriterion\.Description Property

Gets the description of the option shown to the model\.

```csharp
public string? Description { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaCriterion.Label'></a>

## LayaCriterion\.Label Property

Gets the label the model answers with when it selects this option\.

```csharp
public string? Label { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaEnvironmentResult'></a>

## LayaEnvironmentResult Class

Represents the preflight result of a CPython environment and a checkpoint for the Laya scripts\.

The installed versions of laya, torch, transformers and their companions are reported in [DiGi\.Python\.Classes\.PythonEnvironmentResult\.Packages](https://learn.microsoft.com/en-us/dotnet/api/digi.python.classes.pythonenvironmentresult.packages 'DiGi\.Python\.Classes\.PythonEnvironmentResult\.Packages') only, which is authoritative; this type adds what describes the checkpoint (DiGi-Organization/DiGi.Laya#1, D2). Its member names collide with none of the base type's, as the DiGi serializer requires.

```csharp
public class LayaEnvironmentResult : DiGi.Python.Classes.PythonEnvironmentResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → [DiGi\.Python\.Classes\.PythonEnvironmentResult](https://learn.microsoft.com/en-us/dotnet/api/digi.python.classes.pythonenvironmentresult 'DiGi\.Python\.Classes\.PythonEnvironmentResult') → LayaEnvironmentResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_)'></a>

## LayaEnvironmentResult\(bool, string, string, Nullable\<bool\>, IEnumerable\<PythonPackageVersion\>, IEnumerable\<string\>, IEnumerable\<string\>, Nullable\<DateTimeOffset\>, string, string, string, Nullable\<int\>, Nullable\<int\>\) Constructor

Initializes a new instance of the [LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult') class\.

```csharp
public LayaEnvironmentResult(bool runnable, string? pythonPath, string? pythonVersion, System.Nullable<bool> cudaAvailable, System.Collections.Generic.IEnumerable<DiGi.Python.Classes.PythonPackageVersion>? packages, System.Collections.Generic.IEnumerable<string>? messages, System.Collections.Generic.IEnumerable<string>? warnings, System.Nullable<System.DateTimeOffset> checkedTime, string? modelPath, string? modelSHA256, string? optionLayout, System.Nullable<int> maxLength, System.Nullable<int> headMaxLength);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).runnable'></a>

`runnable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the interpreter can run the Laya scripts with the checkpoint\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the interpreter that was probed\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).pythonVersion'></a>

`pythonVersion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The Python version reported by the interpreter\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).cudaAvailable'></a>

`cudaAvailable` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

A value indicating whether torch reports a CUDA device, or `null` when it was not determined\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).packages'></a>

`packages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Python\.Classes\.PythonPackageVersion](https://learn.microsoft.com/en-us/dotnet/api/digi.python.classes.pythonpackageversion 'DiGi\.Python\.Classes\.PythonPackageVersion')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The installed versions of laya and its dependencies\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings that stop a run\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).warnings'></a>

`warnings` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings that do not stop a run\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).checkedTime'></a>

`checkedTime` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the preflight completed\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The resolved checkpoint directory, or the configured value when it did not resolve\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the checkpoint directory, or `null` when it was not hashed\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).optionLayout'></a>

`optionLayout` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The option layout the checkpoint was trained with, "sequential" or "parallel"\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).maxLength'></a>

`maxLength` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The checkpoint's own token budget of the state\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(bool,string,string,System.Nullable_bool_,System.Collections.Generic.IEnumerable_DiGi.Python.Classes.PythonPackageVersion_,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Nullable_System.DateTimeOffset_,string,string,string,System.Nullable_int_,System.Nullable_int_).headMaxLength'></a>

`headMaxLength` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The checkpoint's own token budget of one question\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(DiGi.Laya.Classes.LayaEnvironmentResult)'></a>

## LayaEnvironmentResult\(LayaEnvironmentResult\) Constructor

Initializes a new instance of the [LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult') class by copying an existing result\.

```csharp
public LayaEnvironmentResult(DiGi.Laya.Classes.LayaEnvironmentResult? layaEnvironmentResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(DiGi.Laya.Classes.LayaEnvironmentResult).layaEnvironmentResult'></a>

`layaEnvironmentResult` [LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult')

The source result to copy from\.

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaEnvironmentResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult') class using a JSON object\.

```csharp
public LayaEnvironmentResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.LayaEnvironmentResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.HeadMaxLength'></a>

## LayaEnvironmentResult\.HeadMaxLength Property

Gets the checkpoint's own token budget of one question, from its rl\_agent\_config\.json\.

```csharp
public System.Nullable<int> HeadMaxLength { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.MaxLength'></a>

## LayaEnvironmentResult\.MaxLength Property

Gets the checkpoint's own token budget of the state, from its rl\_agent\_config\.json\.

```csharp
public System.Nullable<int> MaxLength { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.ModelPath'></a>

## LayaEnvironmentResult\.ModelPath Property

Gets the resolved checkpoint directory, or the configured value when it did not resolve\.

```csharp
public string? ModelPath { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.ModelSHA256'></a>

## LayaEnvironmentResult\.ModelSHA256 Property

Gets the SHA\-256 of the checkpoint directory \(DiGi\.Python's `Query.DirectorySHA256`\), or `null` when it was not hashed\.

A checkpoint directory can be replaced in place, so its name says nothing about which weights a run used; compare this instead.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaEnvironmentResult.OptionLayout'></a>

## LayaEnvironmentResult\.OptionLayout Property

Gets the option layout the checkpoint was trained with, "sequential" or "parallel"; a parallel checkpoint needs transformers 5 or later\.

```csharp
public string? OptionLayout { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaEvaluationResult'></a>

## LayaEvaluationResult Class

Represents how well classification results match known label assignments, label set by label set\.

```csharp
public class LayaEvaluationResult : DiGi.Core.Classes.SerializableResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → LayaEvaluationResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LayaEvaluationResult(DiGi.Laya.Classes.LayaEvaluationResult)'></a>

## LayaEvaluationResult\(LayaEvaluationResult\) Constructor

Initializes a new instance of the [LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult') class by copying an existing instance\.

```csharp
public LayaEvaluationResult(DiGi.Laya.Classes.LayaEvaluationResult? layaEvaluationResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LayaEvaluationResult(DiGi.Laya.Classes.LayaEvaluationResult).layaEvaluationResult'></a>

`layaEvaluationResult` [LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LayaEvaluationResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSetEvaluation_)'></a>

## LayaEvaluationResult\(IEnumerable\<LayaLabelSetEvaluation\>\) Constructor

Initializes a new instance of the [LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult') class\.

```csharp
public LayaEvaluationResult(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelSetEvaluation>? labelSetEvaluations);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LayaEvaluationResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSetEvaluation_).labelSetEvaluations'></a>

`labelSetEvaluations` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The evaluation of every label set, in set order\.

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LayaEvaluationResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaEvaluationResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult') class using a JSON object\.

```csharp
public LayaEvaluationResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LayaEvaluationResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaEvaluationResult.LabelSetEvaluations'></a>

## LayaEvaluationResult\.LabelSetEvaluations Property

Gets the evaluation of every label set, in set order\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaLabelSetEvaluation>? LabelSetEvaluations { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaItem'></a>

## LayaItem Class

Represents one item a classification workflow classifies: an identifier and the state Laya reads about it\.

Domain-neutral: what an item is - a recipe, a ticket, a document - is the caller's business; the workflow only asks Laya about its state.

```csharp
public class LayaItem : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaItem

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(DiGi.Laya.Classes.LayaItem)'></a>

## LayaItem\(LayaItem\) Constructor

Initializes a new instance of the [LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem') class by copying an existing instance\.

```csharp
public LayaItem(DiGi.Laya.Classes.LayaItem? layaItem);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(DiGi.Laya.Classes.LayaItem).layaItem'></a>

`layaItem` [LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(string,string,bool)'></a>

## LayaItem\(string, string, bool\) Constructor

Initializes a new instance of the [LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem') class\.

```csharp
public LayaItem(string? id, string? state, bool stateIsJson);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(string,string,bool).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the item, unique within one run; it becomes the request id\.

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(string,string,bool).state'></a>

`state` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The state Laya reads about the item, as text\.

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(string,string,bool).stateIsJson'></a>

`stateIsJson` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the state is a JSON object or array rather than plain text\.

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(System.Text.Json.Nodes.JsonObject)'></a>

## LayaItem\(JsonObject\) Constructor

Initializes a new instance of the [LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem') class using a JSON object\.

```csharp
public LayaItem(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaItem.LayaItem(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaItem.Id'></a>

## LayaItem\.Id Property

Gets the identifier of the item, unique within one run; it becomes the request id\.

```csharp
public string? Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaItem.State'></a>

## LayaItem\.State Property

Gets the state Laya reads about the item, as text\.

```csharp
public string? State { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaItem.StateIsJson'></a>

## LayaItem\.StateIsJson Property

Gets a value indicating whether the state is a JSON object or array rather than plain text\.

```csharp
public bool StateIsJson { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaLabel'></a>

## LayaLabel Class

Represents one label of a [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')\.

```csharp
public class LayaLabel : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabel

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(DiGi.Laya.Classes.LayaLabel)'></a>

## LayaLabel\(LayaLabel\) Constructor

Initializes a new instance of the [LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel') class by copying an existing instance\.

```csharp
public LayaLabel(DiGi.Laya.Classes.LayaLabel? layaLabel);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(DiGi.Laya.Classes.LayaLabel).layaLabel'></a>

`layaLabel` [LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(string,string,string)'></a>

## LayaLabel\(string, string, string\) Constructor

Initializes a new instance of the [LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel') class\.

```csharp
public LayaLabel(string? id, string? text, string? instructions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(string,string,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label, unique within its set; the answer key of a single\-choice set and the suffix of the noul question of a multi\-label set\.

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(string,string,string).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the label shown to the model: the option description of a single\-choice set, and what replaces \{label\} in the noul statement of a multi\-label set\.

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(string,string,string).instructions'></a>

`instructions` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The noul statement template of this label in a multi\-label set, with \{label\} replaced by the text, or `null` for the set's instructions\.

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabel\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel') class using a JSON object\.

```csharp
public LayaLabel(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabel.LayaLabel(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabel.Id'></a>

## LayaLabel\.Id Property

Gets the identifier of the label, unique within its set; the answer key of a single\-choice set and the suffix of the noul question of a multi\-label set\.

```csharp
public string? Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabel.Instructions'></a>

## LayaLabel\.Instructions Property

Gets the noul statement template of this label in a multi\-label set, with \{label\} replaced by the text, or `null` for the set's instructions\.

```csharp
public string? Instructions { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabel.Text'></a>

## LayaLabel\.Text Property

Gets the description of the label shown to the model: the option description of a single\-choice set, and what replaces \{label\} in the noul statement of a multi\-label set\.

```csharp
public string? Text { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelAssignment'></a>

## LayaLabelAssignment Class

Represents a known label of an item: ground truth for training, folds and evaluation\.

```csharp
public class LayaLabelAssignment : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelAssignment

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(DiGi.Laya.Classes.LayaLabelAssignment)'></a>

## LayaLabelAssignment\(LayaLabelAssignment\) Constructor

Initializes a new instance of the [LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment') class by copying an existing instance\.

```csharp
public LayaLabelAssignment(DiGi.Laya.Classes.LayaLabelAssignment? layaLabelAssignment);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(DiGi.Laya.Classes.LayaLabelAssignment).layaLabelAssignment'></a>

`layaLabelAssignment` [LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string)'></a>

## LayaLabelAssignment\(string, string, string, bool, double, string\) Constructor

Initializes a new instance of the [LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment') class\.

```csharp
public LayaLabelAssignment(string? itemId, string? labelSetId, string? labelId, bool truth, double weight, string? group);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string).itemId'></a>

`itemId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the item\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string).labelSetId'></a>

`labelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label set\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string).labelId'></a>

`labelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string).truth'></a>

`truth` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the label applies to the item \(`false` records an explicit negative\)\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string).weight'></a>

`weight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The confidence in the assignment, from 0 \(no information\) to 1 \(certain\); a weak label below 1 becomes a soft training target\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(string,string,string,bool,double,string).group'></a>

`group` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The group the item belongs to, which folds never split, or `null` when the item stands alone\.

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelAssignment\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment') class using a JSON object\.

```csharp
public LayaLabelAssignment(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LayaLabelAssignment(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelAssignment.Group'></a>

## LayaLabelAssignment\.Group Property

Gets the group the item belongs to, which folds never split, or `null` when the item stands alone\.

```csharp
public string? Group { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelAssignment.ItemId'></a>

## LayaLabelAssignment\.ItemId Property

Gets the identifier of the item\.

```csharp
public string? ItemId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LabelId'></a>

## LayaLabelAssignment\.LabelId Property

Gets the identifier of the label\.

```csharp
public string? LabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelAssignment.LabelSetId'></a>

## LayaLabelAssignment\.LabelSetId Property

Gets the identifier of the label set\.

```csharp
public string? LabelSetId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelAssignment.Truth'></a>

## LayaLabelAssignment\.Truth Property

Gets a value indicating whether the label applies to the item \(`false` records an explicit negative\)\.

```csharp
public bool Truth { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaLabelAssignment.Weight'></a>

## LayaLabelAssignment\.Weight Property

Gets the confidence in the assignment, from 0 \(no information\) to 1 \(certain\); a weak label below 1 becomes a soft training target\.

```csharp
public double Weight { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Laya.Classes.LayaLabelConstraint'></a>

## LayaLabelConstraint Class

Represents a rule from outside the model about one label of one item, applied to its classification result\.

```csharp
public class LayaLabelConstraint : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelConstraint

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(DiGi.Laya.Classes.LayaLabelConstraint)'></a>

## LayaLabelConstraint\(LayaLabelConstraint\) Constructor

Initializes a new instance of the [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint') class by copying an existing instance\.

```csharp
public LayaLabelConstraint(DiGi.Laya.Classes.LayaLabelConstraint? layaLabelConstraint);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(DiGi.Laya.Classes.LayaLabelConstraint).layaLabelConstraint'></a>

`layaLabelConstraint` [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(string,string,string,DiGi.Laya.Enums.LayaConstraintEffect,string)'></a>

## LayaLabelConstraint\(string, string, string, LayaConstraintEffect, string\) Constructor

Initializes a new instance of the [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint') class\.

```csharp
public LayaLabelConstraint(string? itemId, string? labelSetId, string? labelId, DiGi.Laya.Enums.LayaConstraintEffect effect, string? reason);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(string,string,string,DiGi.Laya.Enums.LayaConstraintEffect,string).itemId'></a>

`itemId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the item\.

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(string,string,string,DiGi.Laya.Enums.LayaConstraintEffect,string).labelSetId'></a>

`labelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label set\.

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(string,string,string,DiGi.Laya.Enums.LayaConstraintEffect,string).labelId'></a>

`labelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label\.

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(string,string,string,DiGi.Laya.Enums.LayaConstraintEffect,string).effect'></a>

`effect` [LayaConstraintEffect](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaConstraintEffect 'DiGi\.Laya\.Enums\.LayaConstraintEffect')

What the constraint does to the label's score\.

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(string,string,string,DiGi.Laya.Enums.LayaConstraintEffect,string).reason'></a>

`reason` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Why the constraint applies, stored on the score it affects\.

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelConstraint\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint') class using a JSON object\.

```csharp
public LayaLabelConstraint(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LayaLabelConstraint(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelConstraint.Effect'></a>

## LayaLabelConstraint\.Effect Property

Gets what the constraint does to the label's score\.

```csharp
public DiGi.Laya.Enums.LayaConstraintEffect Effect { get; }
```

#### Property Value
[LayaConstraintEffect](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaConstraintEffect 'DiGi\.Laya\.Enums\.LayaConstraintEffect')

<a name='DiGi.Laya.Classes.LayaLabelConstraint.ItemId'></a>

## LayaLabelConstraint\.ItemId Property

Gets the identifier of the item\.

```csharp
public string? ItemId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LabelId'></a>

## LayaLabelConstraint\.LabelId Property

Gets the identifier of the label\.

```csharp
public string? LabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelConstraint.LabelSetId'></a>

## LayaLabelConstraint\.LabelSetId Property

Gets the identifier of the label set\.

```csharp
public string? LabelSetId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelConstraint.Reason'></a>

## LayaLabelConstraint\.Reason Property

Gets why the constraint applies, stored on the score it affects\.

```csharp
public string? Reason { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation'></a>

## LayaLabelEvaluation Class

Represents the precision, recall and F1 of one label of a label set\.

```csharp
public class LayaLabelEvaluation : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelEvaluation

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(DiGi.Laya.Classes.LayaLabelEvaluation)'></a>

## LayaLabelEvaluation\(LayaLabelEvaluation\) Constructor

Initializes a new instance of the [LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation') class by copying an existing instance\.

```csharp
public LayaLabelEvaluation(DiGi.Laya.Classes.LayaLabelEvaluation? layaLabelEvaluation);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(DiGi.Laya.Classes.LayaLabelEvaluation).layaLabelEvaluation'></a>

`layaLabelEvaluation` [LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_)'></a>

## LayaLabelEvaluation\(string, int, int, int, int, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>\) Constructor

Initializes a new instance of the [LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation') class\.

```csharp
public LayaLabelEvaluation(string? labelId, int support, int truePositiveCount, int falsePositiveCount, int falseNegativeCount, System.Nullable<double> precision, System.Nullable<double> recall, System.Nullable<double> f1);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).labelId'></a>

`labelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).support'></a>

`support` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of evaluated items the label truly applies to\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).truePositiveCount'></a>

`truePositiveCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items the label was predicted for and applies to\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).falsePositiveCount'></a>

`falsePositiveCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items the label was predicted for and does not apply to\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).falseNegativeCount'></a>

`falseNegativeCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items the label applies to and was not predicted for\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).precision'></a>

`precision` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The true positives over all predictions of the label, or `null` when it was never predicted\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).recall'></a>

`recall` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The true positives over the support, or `null` when the support is 0\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(string,int,int,int,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).f1'></a>

`f1` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Two true positives over two true positives plus false positives plus false negatives, or `null` when all three are 0\.

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelEvaluation\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation') class using a JSON object\.

```csharp
public LayaLabelEvaluation(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LayaLabelEvaluation(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.F1'></a>

## LayaLabelEvaluation\.F1 Property

Gets two true positives over two true positives plus false positives plus false negatives, or `null` when all three are 0\.

```csharp
public System.Nullable<double> F1 { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.FalseNegativeCount'></a>

## LayaLabelEvaluation\.FalseNegativeCount Property

Gets the number of items the label applies to and was not predicted for\.

```csharp
public int FalseNegativeCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.FalsePositiveCount'></a>

## LayaLabelEvaluation\.FalsePositiveCount Property

Gets the number of items the label was predicted for and does not apply to\.

```csharp
public int FalsePositiveCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.LabelId'></a>

## LayaLabelEvaluation\.LabelId Property

Gets the identifier of the label\.

```csharp
public string? LabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.Precision'></a>

## LayaLabelEvaluation\.Precision Property

Gets the true positives over all predictions of the label, or `null` when it was never predicted\.

```csharp
public System.Nullable<double> Precision { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.Recall'></a>

## LayaLabelEvaluation\.Recall Property

Gets the true positives over the support, or `null` when the support is 0\.

```csharp
public System.Nullable<double> Recall { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.Support'></a>

## LayaLabelEvaluation\.Support Property

Gets the number of evaluated items the label truly applies to\.

```csharp
public int Support { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaLabelEvaluation.TruePositiveCount'></a>

## LayaLabelEvaluation\.TruePositiveCount Property

Gets the number of items the label was predicted for and applies to\.

```csharp
public int TruePositiveCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaLabelScore'></a>

## LayaLabelScore Class

Represents the score of one label of one label set for one item, and whether it is suggested\.

The constructors only assign; `Modify.ApplyConstraints` replaces a score rather than changing it.

```csharp
public class LayaLabelScore : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelScore

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(DiGi.Laya.Classes.LayaLabelScore)'></a>

## LayaLabelScore\(LayaLabelScore\) Constructor

Initializes a new instance of the [LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore') class by copying an existing instance\.

```csharp
public LayaLabelScore(DiGi.Laya.Classes.LayaLabelScore? layaLabelScore);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(DiGi.Laya.Classes.LayaLabelScore).layaLabelScore'></a>

`layaLabelScore` [LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string)'></a>

## LayaLabelScore\(string, string, double, bool, bool, string\) Constructor

Initializes a new instance of the [LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore') class\.

```csharp
public LayaLabelScore(string? labelSetId, string? labelId, double probability, bool isSuggested, bool isForbidden, string? reason);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string).labelSetId'></a>

`labelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label set\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string).labelId'></a>

`labelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string).probability'></a>

`probability` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The probability Laya gives the label: its option probability in a single\-choice set, or the probability its noul statement is true in a multi\-label set\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string).isSuggested'></a>

`isSuggested` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the label is suggested for the item\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string).isForbidden'></a>

`isForbidden` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether a constraint forbids the label for the item; a forbidden label is never suggested\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(string,string,double,bool,bool,string).reason'></a>

`reason` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The reason of the constraint that forbids the label, or `null`\.

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelScore\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore') class using a JSON object\.

```csharp
public LayaLabelScore(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelScore.LayaLabelScore(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelScore.IsForbidden'></a>

## LayaLabelScore\.IsForbidden Property

Gets a value indicating whether a constraint forbids the label for the item; a forbidden label is never suggested\.

```csharp
public bool IsForbidden { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaLabelScore.IsSuggested'></a>

## LayaLabelScore\.IsSuggested Property

Gets a value indicating whether the label is suggested for the item\.

```csharp
public bool IsSuggested { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaLabelScore.LabelId'></a>

## LayaLabelScore\.LabelId Property

Gets the identifier of the label\.

```csharp
public string? LabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelScore.LabelSetId'></a>

## LayaLabelScore\.LabelSetId Property

Gets the identifier of the label set\.

```csharp
public string? LabelSetId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelScore.Probability'></a>

## LayaLabelScore\.Probability Property

Gets the probability Laya gives the label: its option probability in a single\-choice set, or the probability its noul statement is true in a multi\-label set\.

```csharp
public double Probability { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Laya.Classes.LayaLabelScore.Reason'></a>

## LayaLabelScore\.Reason Property

Gets the reason of the constraint that forbids the label, or `null`\.

```csharp
public string? Reason { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelSet'></a>

## LayaLabelSet Class

Represents a closed set of labels one question decides for every item\.

Laya's accuracy drops sharply past about 20 options in one choice question and it refuses more than 100; `Modify.ClassifyAsync` warns above the first and refuses above the second for a single-choice set.

```csharp
public class LayaLabelSet : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelSet

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(DiGi.Laya.Classes.LayaLabelSet)'></a>

## LayaLabelSet\(LayaLabelSet\) Constructor

Initializes a new instance of the [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet') class by copying an existing instance\.

```csharp
public LayaLabelSet(DiGi.Laya.Classes.LayaLabelSet? layaLabelSet);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(DiGi.Laya.Classes.LayaLabelSet).layaLabelSet'></a>

`layaLabelSet` [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(string,string,DiGi.Laya.Enums.LayaLabelSetKind,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabel_)'></a>

## LayaLabelSet\(string, string, LayaLabelSetKind, IEnumerable\<LayaLabel\>\) Constructor

Initializes a new instance of the [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet') class\.

```csharp
public LayaLabelSet(string? id, string? instructions, DiGi.Laya.Enums.LayaLabelSetKind kind, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabel>? labels);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(string,string,DiGi.Laya.Enums.LayaLabelSetKind,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabel_).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the set, unique within one run; a single\-choice set's question is named after it\. It must not contain a colon, which separates set and label in a multi\-label question name\.

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(string,string,DiGi.Laya.Enums.LayaLabelSetKind,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabel_).instructions'></a>

`instructions` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The instructions of the set: the choice question of a single\-choice set, or the noul statement template \(with \{label\}\) of a multi\-label set's labels that carry none of their own\.

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(string,string,DiGi.Laya.Enums.LayaLabelSetKind,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabel_).kind'></a>

`kind` [LayaLabelSetKind](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaLabelSetKind 'DiGi\.Laya\.Enums\.LayaLabelSetKind')

How the labels are asked and decided\.

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(string,string,DiGi.Laya.Enums.LayaLabelSetKind,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabel_).labels'></a>

`labels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The labels, in the order they are shown to the model\.

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelSet\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet') class using a JSON object\.

```csharp
public LayaLabelSet(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSet.LayaLabelSet(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelSet.Id'></a>

## LayaLabelSet\.Id Property

Gets the identifier of the set, unique within one run; a single\-choice set's question is named after it\. It must not contain a colon, which separates set and label in a multi\-label question name\.

```csharp
public string? Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelSet.Instructions'></a>

## LayaLabelSet\.Instructions Property

Gets the instructions of the set: the choice question of a single\-choice set, or the noul statement template \(with \{label\}\) of a multi\-label set's labels that carry none of their own\.

```csharp
public string? Instructions { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelSet.Kind'></a>

## LayaLabelSet\.Kind Property

Gets how the labels are asked and decided\.

```csharp
public DiGi.Laya.Enums.LayaLabelSetKind Kind { get; }
```

#### Property Value
[LayaLabelSetKind](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaLabelSetKind 'DiGi\.Laya\.Enums\.LayaLabelSetKind')

<a name='DiGi.Laya.Classes.LayaLabelSet.Labels'></a>

## LayaLabelSet\.Labels Property

Gets the labels, in the order they are shown to the model\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaLabel>? Labels { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation'></a>

## LayaLabelSetEvaluation Class

Represents how well the classification results of one label set match the known assignments\.

```csharp
public class LayaLabelSetEvaluation : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelSetEvaluation

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(DiGi.Laya.Classes.LayaLabelSetEvaluation)'></a>

## LayaLabelSetEvaluation\(LayaLabelSetEvaluation\) Constructor

Initializes a new instance of the [LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation') class by copying an existing instance\.

```csharp
public LayaLabelSetEvaluation(DiGi.Laya.Classes.LayaLabelSetEvaluation? layaLabelSetEvaluation);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(DiGi.Laya.Classes.LayaLabelSetEvaluation).layaLabelSetEvaluation'></a>

`layaLabelSetEvaluation` [LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_)'></a>

## LayaLabelSetEvaluation\(string, LayaLabelSetKind, int, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, IEnumerable\<LayaLabelEvaluation\>, IEnumerable\<LayaConfusionRow\>\) Constructor

Initializes a new instance of the [LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation') class\.

```csharp
public LayaLabelSetEvaluation(string? labelSetId, DiGi.Laya.Enums.LayaLabelSetKind kind, int itemCount, System.Nullable<double> top1Accuracy, System.Nullable<double> top3Accuracy, System.Nullable<double> microF1, System.Nullable<double> macroF1, System.Nullable<double> expectedCalibrationError, System.Nullable<double> brierScore, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelEvaluation>? labelEvaluations, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaConfusionRow>? confusionRows);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).labelSetId'></a>

`labelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label set\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).kind'></a>

`kind` [LayaLabelSetKind](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaLabelSetKind 'DiGi\.Laya\.Enums\.LayaLabelSetKind')

How the set is decided, which decides which metrics apply\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).itemCount'></a>

`itemCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items evaluated: items with both a known label in the set and scores for it\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).top1Accuracy'></a>

`top1Accuracy` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The share of items whose true label is ranked first by probability; single\-choice sets only\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).top3Accuracy'></a>

`top3Accuracy` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The share of items whose true label is among the three most probable; single\-choice sets only\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).microF1'></a>

`microF1` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

F1 over the true positives, false positives and false negatives of all labels together; multi\-label sets only\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).macroF1'></a>

`macroF1` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The mean F1 of the labels with a support above 0, or `null` when there is none\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).expectedCalibrationError'></a>

`expectedCalibrationError` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The expected calibration error over 10 equal\-width probability bins, or `null` when nothing was evaluated\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).brierScore'></a>

`brierScore` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The mean squared difference between probability and truth, or `null` when nothing was evaluated\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).labelEvaluations'></a>

`labelEvaluations` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The evaluation of every label, in label order\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(string,DiGi.Laya.Enums.LayaLabelSetKind,int,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelEvaluation_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaConfusionRow_).confusionRows'></a>

`confusionRows` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The non\-empty cells of the confusion matrix, actual label then predicted label in label order; single\-choice sets only\.

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelSetEvaluation\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation') class using a JSON object\.

```csharp
public LayaLabelSetEvaluation(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LayaLabelSetEvaluation(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.BrierScore'></a>

## LayaLabelSetEvaluation\.BrierScore Property

Gets the mean squared difference between probability and truth, or `null` when nothing was evaluated\.

```csharp
public System.Nullable<double> BrierScore { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.ConfusionRows'></a>

## LayaLabelSetEvaluation\.ConfusionRows Property

Gets the non\-empty cells of the confusion matrix, actual label then predicted label in label order; single\-choice sets only\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaConfusionRow>? ConfusionRows { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.ExpectedCalibrationError'></a>

## LayaLabelSetEvaluation\.ExpectedCalibrationError Property

Gets the expected calibration error over 10 equal\-width probability bins, or `null` when nothing was evaluated\.

```csharp
public System.Nullable<double> ExpectedCalibrationError { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.ItemCount'></a>

## LayaLabelSetEvaluation\.ItemCount Property

Gets the number of items evaluated: items with both a known label in the set and scores for it\.

```csharp
public int ItemCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.Kind'></a>

## LayaLabelSetEvaluation\.Kind Property

Gets how the set is decided, which decides which metrics apply\.

```csharp
public DiGi.Laya.Enums.LayaLabelSetKind Kind { get; }
```

#### Property Value
[LayaLabelSetKind](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaLabelSetKind 'DiGi\.Laya\.Enums\.LayaLabelSetKind')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LabelEvaluations'></a>

## LayaLabelSetEvaluation\.LabelEvaluations Property

Gets the evaluation of every label, in label order\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaLabelEvaluation>? LabelEvaluations { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.LabelSetId'></a>

## LayaLabelSetEvaluation\.LabelSetId Property

Gets the identifier of the label set\.

```csharp
public string? LabelSetId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.MacroF1'></a>

## LayaLabelSetEvaluation\.MacroF1 Property

Gets the mean F1 of the labels with a support above 0, or `null` when there is none\.

```csharp
public System.Nullable<double> MacroF1 { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.MicroF1'></a>

## LayaLabelSetEvaluation\.MicroF1 Property

Gets f1 over the true positives, false positives and false negatives of all labels together; multi\-label sets only\.

```csharp
public System.Nullable<double> MicroF1 { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.Top1Accuracy'></a>

## LayaLabelSetEvaluation\.Top1Accuracy Property

Gets the share of items whose true label is ranked first by probability; single\-choice sets only\.

```csharp
public System.Nullable<double> Top1Accuracy { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetEvaluation.Top3Accuracy'></a>

## LayaLabelSetEvaluation\.Top3Accuracy Property

Gets the share of items whose true label is among the three most probable; single\-choice sets only\.

```csharp
public System.Nullable<double> Top3Accuracy { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold'></a>

## LayaLabelSetThreshold Class

Represents the decision rule of one label set, or of one label of a multi\-label set, in [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions')\.

A rule without a [LabelId](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.LabelId 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.LabelId') is the rule of the whole set. A rule with one is the rule of that label of a multi-label set and wins over the set's rule for it; only its [Threshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.Threshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.Threshold') is used - a label-level [TopCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.TopCount 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.TopCount') is ignored, because the number of labels suggested is a setting of the whole set.

```csharp
public class LayaLabelSetThreshold : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaLabelSetThreshold

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(DiGi.Laya.Classes.LayaLabelSetThreshold)'></a>

## LayaLabelSetThreshold\(LayaLabelSetThreshold\) Constructor

Initializes a new instance of the [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold') class by copying an existing instance\.

```csharp
public LayaLabelSetThreshold(DiGi.Laya.Classes.LayaLabelSetThreshold? layaLabelSetThreshold);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(DiGi.Laya.Classes.LayaLabelSetThreshold).layaLabelSetThreshold'></a>

`layaLabelSetThreshold` [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(string,string,System.Nullable_double_,System.Nullable_int_)'></a>

## LayaLabelSetThreshold\(string, string, Nullable\<double\>, Nullable\<int\>\) Constructor

Initializes a new instance of the [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold') class\.

```csharp
public LayaLabelSetThreshold(string? labelSetId, string? labelId, System.Nullable<double> threshold, System.Nullable<int> topCount);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(string,string,System.Nullable_double_,System.Nullable_int_).labelSetId'></a>

`labelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label set the rule applies to\.

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(string,string,System.Nullable_double_,System.Nullable_int_).labelId'></a>

`labelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label of a multi\-label set the rule applies to, or `null` for a rule of the whole set\.

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(string,string,System.Nullable_double_,System.Nullable_int_).threshold'></a>

`threshold` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The probability a label of a multi\-label set must reach to be suggested, or `null` for the set's rule, else 0\.5\.

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(string,string,System.Nullable_double_,System.Nullable_int_).topCount'></a>

`topCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of labels of a single\-choice set suggested, highest probability first, or `null` for 1\. Ignored when [labelId](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(string,string,System.Nullable_double_,System.Nullable_int_).labelId 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.LayaLabelSetThreshold\(string, string, System\.Nullable\<double\>, System\.Nullable\<int\>\)\.labelId') is set\.

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(System.Text.Json.Nodes.JsonObject)'></a>

## LayaLabelSetThreshold\(JsonObject\) Constructor

Initializes a new instance of the [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold') class using a JSON object\.

```csharp
public LayaLabelSetThreshold(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LayaLabelSetThreshold(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LabelId'></a>

## LayaLabelSetThreshold\.LabelId Property

Gets the identifier of the label of a multi\-label set the rule applies to, or `null` for a rule of the whole set\.

```csharp
public string? LabelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.LabelSetId'></a>

## LayaLabelSetThreshold\.LabelSetId Property

Gets the identifier of the label set the rule applies to\.

```csharp
public string? LabelSetId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.Threshold'></a>

## LayaLabelSetThreshold\.Threshold Property

Gets the probability a label of a multi\-label set must reach to be suggested, or `null` for the set's rule, else 0\.5\.

```csharp
public System.Nullable<double> Threshold { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaLabelSetThreshold.TopCount'></a>

## LayaLabelSetThreshold\.TopCount Property

Gets the number of labels of a single\-choice set suggested, highest probability first, or `null` for 1\. Ignored when [LabelId](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.LabelId 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.LabelId') is set\.

```csharp
public System.Nullable<int> TopCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaNoulAnswer'></a>

## LayaNoulAnswer Class

Represents the answer to a [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion'): the probability that the statement is true\.

```csharp
public class LayaNoulAnswer : DiGi.Laya.Classes.LayaAnswer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer') → LayaNoulAnswer
### Constructors

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(DiGi.Laya.Classes.LayaNoulAnswer)'></a>

## LayaNoulAnswer\(LayaNoulAnswer\) Constructor

Initializes a new instance of the [LayaNoulAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulAnswer 'DiGi\.Laya\.Classes\.LayaNoulAnswer') class by copying an existing answer\.

```csharp
public LayaNoulAnswer(DiGi.Laya.Classes.LayaNoulAnswer? layaNoulAnswer);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(DiGi.Laya.Classes.LayaNoulAnswer).layaNoulAnswer'></a>

`layaNoulAnswer` [LayaNoulAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulAnswer 'DiGi\.Laya\.Classes\.LayaNoulAnswer')

The source answer to copy from\.

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_)'></a>

## LayaNoulAnswer\(string, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>\) Constructor

Initializes a new instance of the [LayaNoulAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulAnswer 'DiGi\.Laya\.Classes\.LayaNoulAnswer') class\.

```csharp
public LayaNoulAnswer(string? name, System.Nullable<double> confidence, System.Nullable<double> answerConfidence, System.Nullable<double> probability);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the question answered\.

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).confidence'></a>

`confidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya reports, the larger of the probabilities of true and false, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).answerConfidence'></a>

`answerConfidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya reports for the answer itself, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).probability'></a>

`probability` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The probability that the statement is true, between 0 and 1\.

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(System.Text.Json.Nodes.JsonObject)'></a>

## LayaNoulAnswer\(JsonObject\) Constructor

Initializes a new instance of the [LayaNoulAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulAnswer 'DiGi\.Laya\.Classes\.LayaNoulAnswer') class using a JSON object\.

```csharp
public LayaNoulAnswer(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaNoulAnswer.LayaNoulAnswer(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the answer data\.
### Properties

<a name='DiGi.Laya.Classes.LayaNoulAnswer.Probability'></a>

## LayaNoulAnswer\.Probability Property

Gets the probability that the statement is true, between 0 and 1 \(Laya's `noul`\)\.

```csharp
public System.Nullable<double> Probability { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaNoulAnswer.QuestionType'></a>

## LayaNoulAnswer\.QuestionType Property

Gets [Noul](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType.Noul 'DiGi\.Laya\.Enums\.LayaQuestionType\.Noul')\.

```csharp
public override DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaNoulQuestion'></a>

## LayaNoulQuestion Class

Represents a statement the model judges true or false, answered with the probability that it is true\.

The statement is [Instructions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion.Instructions 'DiGi\.Laya\.Classes\.LayaQuestion\.Instructions'); the question carries nothing else.

```csharp
public class LayaNoulQuestion : DiGi.Laya.Classes.LayaQuestion
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion') → LayaNoulQuestion
### Constructors

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(DiGi.Laya.Classes.LayaNoulQuestion)'></a>

## LayaNoulQuestion\(LayaNoulQuestion\) Constructor

Initializes a new instance of the [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion') class by copying an existing question\.

```csharp
public LayaNoulQuestion(DiGi.Laya.Classes.LayaNoulQuestion? layaNoulQuestion);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(DiGi.Laya.Classes.LayaNoulQuestion).layaNoulQuestion'></a>

`layaNoulQuestion` [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion')

The source question to copy from\.

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(string,string)'></a>

## LayaNoulQuestion\(string, string\) Constructor

Initializes a new instance of the [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion') class\.

```csharp
public LayaNoulQuestion(string? name, string? instructions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name the question is asked and answered under, unique within one request\.

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(string,string).instructions'></a>

`instructions` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The statement the model judges true or false\.

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(System.Text.Json.Nodes.JsonObject)'></a>

## LayaNoulQuestion\(JsonObject\) Constructor

Initializes a new instance of the [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion') class using a JSON object\.

```csharp
public LayaNoulQuestion(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaNoulQuestion.LayaNoulQuestion(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the question data\.
### Properties

<a name='DiGi.Laya.Classes.LayaNoulQuestion.QuestionType'></a>

## LayaNoulQuestion\.QuestionType Property

Gets [Noul](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType.Noul 'DiGi\.Laya\.Enums\.LayaQuestionType\.Noul')\.

```csharp
public override DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaPredictionOptions'></a>

## LayaPredictionOptions Class

Provides the settings a Laya prediction run and its preflight need: the interpreter, the checkpoint, the device and the limits of the run\.

The constructors only assign. Use [LayaPredictionOptions\(string, string, string, LayaDevice\)](DiGi.Laya.md#DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice) 'DiGi\.Laya\.Create\.LayaPredictionOptions\(string, string, string, DiGi\.Laya\.Enums\.LayaDevice\)') to resolve the interpreter and the checkpoint directory and refuse a combination that cannot make a run.

```csharp
public class LayaPredictionOptions : DiGi.Core.Classes.SerializableOptions, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → LayaPredictionOptions

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaPredictionOptions.LayaPredictionOptions()'></a>

## LayaPredictionOptions\(\) Constructor

Initializes a new instance of the [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions') class with default values\.

```csharp
public LayaPredictionOptions();
```

<a name='DiGi.Laya.Classes.LayaPredictionOptions.LayaPredictionOptions(DiGi.Laya.Classes.LayaPredictionOptions)'></a>

## LayaPredictionOptions\(LayaPredictionOptions\) Constructor

Initializes a new instance of the [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions') class by copying an existing options instance\.

```csharp
public LayaPredictionOptions(DiGi.Laya.Classes.LayaPredictionOptions? layaPredictionOptions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaPredictionOptions.LayaPredictionOptions(DiGi.Laya.Classes.LayaPredictionOptions).layaPredictionOptions'></a>

`layaPredictionOptions` [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')

The source options instance to copy from\.

<a name='DiGi.Laya.Classes.LayaPredictionOptions.LayaPredictionOptions(System.Text.Json.Nodes.JsonObject)'></a>

## LayaPredictionOptions\(JsonObject\) Constructor

Initializes a new instance of the [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions') class using a JSON object\.

```csharp
public LayaPredictionOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaPredictionOptions.LayaPredictionOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the settings\.
### Properties

<a name='DiGi.Laya.Classes.LayaPredictionOptions.BatchSize'></a>

## LayaPredictionOptions\.BatchSize Property

Gets or sets the number of states per forward pass, passed to predict\.py as \-\-batch\-size\.

The default is 16. Lowering it reduces GPU memory; the answers do not depend on it.

```csharp
public int BatchSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.CalibrationPath'></a>

## LayaPredictionOptions\.CalibrationPath Property

Gets or sets the calibration JSON written by `Modify.CalibrateAsync`, passed to predict\.py as \-\-calibration, or `null` for the checkpoint's own temperatures\.

Kept outside the checkpoint directory, so that calibrating never changes the checkpoint's SHA-256.

```csharp
public string? CalibrationPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.Device'></a>

## LayaPredictionOptions\.Device Property

Gets or sets the device the model runs on, passed to the scripts as \-\-device\.

```csharp
public DiGi.Laya.Enums.LayaDevice Device { get; set; }
```

#### Property Value
[LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.HeadMaxLength'></a>

## LayaPredictionOptions\.HeadMaxLength Property

Gets or sets the token budget of one question for a request that sets none, or `null` for the checkpoint's own \(256 for laya\-multilingual\)\.

```csharp
public System.Nullable<int> HeadMaxLength { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.InactivityTimeout'></a>

## LayaPredictionOptions\.InactivityTimeout Property

Gets or sets the span without output after which the run is ended as stalled, or `null` for no limit\.

predict.py prints a progress line after every chunk of states, so the limit has to exceed the model load plus one chunk.

```csharp
public System.Nullable<System.TimeSpan> InactivityTimeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.MaxLength'></a>

## LayaPredictionOptions\.MaxLength Property

Gets or sets the token budget of the state for a request that sets none, or `null` for the checkpoint's own \(1024 for laya\-multilingual\)\.

```csharp
public System.Nullable<int> MaxLength { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.ModelPath'></a>

## LayaPredictionOptions\.ModelPath Property

Gets or sets the checkpoint directory, resolved by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)')\.

It must be a directory holding rl_agent_config.json; a model name or Hugging Face Hub id is refused rather than downloaded.

```csharp
public string? ModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.PythonPath'></a>

## LayaPredictionOptions\.PythonPath Property

Gets or sets the path of the CPython interpreter carrying laya, or the name of one on PATH; `null` searches PATH\. Resolved by [LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)'), which refuses a value that does not resolve as given rather than falling back to another Python\.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.Timeout'></a>

## LayaPredictionOptions\.Timeout Property

Gets or sets the span after which the run is ended whatever it is doing, or `null` for no limit\.

```csharp
public System.Nullable<System.TimeSpan> Timeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaPredictionOptions.WorkingDirectory'></a>

## LayaPredictionOptions\.WorkingDirectory Property

Gets or sets the directory the scripts, requests\.jsonl and responses\.jsonl are written to, or `null` for a fresh temporary directory removed after the run\.

Two runs must not share a working directory at the same time: each deletes and rewrites the other's files.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaPredictionResult'></a>

## LayaPredictionResult Class

Represents how a Laya prediction run went: the responses it produced and every finding about the run and the requests\.

A run is never reported by an exception. A request that could not be written, was refused by laya or got no response is named in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Messages'), and the responses of the others are kept. Every finding about one request is also kept, with that request's identifier, in [RequestMessages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.RequestMessages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.RequestMessages').

```csharp
public class LayaPredictionResult : DiGi.Core.Classes.SerializableResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → LayaPredictionResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(DiGi.Laya.Classes.LayaPredictionResult)'></a>

## LayaPredictionResult\(LayaPredictionResult\) Constructor

Initializes a new instance of the [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult') class by copying an existing result\.

```csharp
public LayaPredictionResult(DiGi.Laya.Classes.LayaPredictionResult? layaPredictionResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(DiGi.Laya.Classes.LayaPredictionResult).layaPredictionResult'></a>

`layaPredictionResult` [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult')

The source result to copy from\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_)'></a>

## LayaPredictionResult\(IEnumerable\<LayaResponse\>, string, string, Nullable\<TimeSpan\>, int, bool, bool, bool, IEnumerable\<string\>, IEnumerable\<LayaRequestMessage\>\) Constructor

Initializes a new instance of the [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult') class\.

```csharp
public LayaPredictionResult(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaResponse>? responses, string? modelSHA256, string? calibrationSHA256, System.Nullable<System.TimeSpan> duration, int exitCode, bool stalled, bool timedOut, bool cancelled, System.Collections.Generic.IEnumerable<string>? messages, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaRequestMessage>? requestMessages);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).responses'></a>

`responses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The responses read back, in request order\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the checkpoint directory the run used\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).calibrationSHA256'></a>

`calibrationSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the calibration file the run used, or `null` when it used none\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).duration'></a>

`duration` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The wall\-clock time of the run, or `null` when no process was started\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The exit code of predict\.py; \-1 when the process was ended, failed to start or was never started\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).stalled'></a>

`stalled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended for inactivity\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).timedOut'></a>

`timedOut` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended by the overall time limit\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).cancelled'></a>

`cancelled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the caller cancelled the run\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings about the run and the requests\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).requestMessages'></a>

`requestMessages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaRequestMessage](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequestMessage 'DiGi\.Laya\.Classes\.LayaRequestMessage')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings about one request each, with the identifier of that request; each is also one of [messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaResponse_,string,string,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequestMessage_).messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.LayaPredictionResult\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaResponse\>, string, string, System\.Nullable\<System\.TimeSpan\>, int, bool, bool, bool, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaRequestMessage\>\)\.messages')\.

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaPredictionResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult') class using a JSON object\.

```csharp
public LayaPredictionResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaPredictionResult.LayaPredictionResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\.
### Properties

<a name='DiGi.Laya.Classes.LayaPredictionResult.CalibrationSHA256'></a>

## LayaPredictionResult\.CalibrationSHA256 Property

Gets the SHA\-256 of the calibration file the run used, or `null` when it used none\.

```csharp
public string? CalibrationSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaPredictionResult.Cancelled'></a>

## LayaPredictionResult\.Cancelled Property

Gets a value indicating whether the caller cancelled the run\.

```csharp
public bool Cancelled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaPredictionResult.Duration'></a>

## LayaPredictionResult\.Duration Property

Gets the wall\-clock time of the run, or `null` when no process was started\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaPredictionResult.ExitCode'></a>

## LayaPredictionResult\.ExitCode Property

Gets the exit code of predict\.py; \-1 when the process was ended, failed to start or was never started\.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaPredictionResult.Messages'></a>

## LayaPredictionResult\.Messages Property

Gets the findings about the run and the requests\.

Every finding about one request is also in [RequestMessages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.RequestMessages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.RequestMessages'); the others concern the run as a whole.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaPredictionResult.ModelSHA256'></a>

## LayaPredictionResult\.ModelSHA256 Property

Gets the SHA\-256 of the checkpoint directory the run used \(DiGi\.Python's `Query.DirectorySHA256`\)\.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaPredictionResult.RequestMessages'></a>

## LayaPredictionResult\.RequestMessages Property

Gets the findings about one request each, with the identifier of that request: a request left out, refused by laya, without a response, missing an answer or truncated\.

Each is also one of [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Messages'), which is kept whole for compatibility. A finding that names no request of the run - a refused run, the process exit, a time limit, a response line answering no request - is only in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Messages').

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaRequestMessage>? RequestMessages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaRequestMessage](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequestMessage 'DiGi\.Laya\.Classes\.LayaRequestMessage')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaPredictionResult.Responses'></a>

## LayaPredictionResult\.Responses Property

Gets the responses read back, in request order\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaResponse>? Responses { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaPredictionResult.Stalled'></a>

## LayaPredictionResult\.Stalled Property

Gets a value indicating whether the process was ended for inactivity\.

```csharp
public bool Stalled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaPredictionResult.TimedOut'></a>

## LayaPredictionResult\.TimedOut Property

Gets a value indicating whether the process was ended by the overall time limit\.

```csharp
public bool TimedOut { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaProbability'></a>

## LayaProbability Class

Represents the probability the Laya decision model assigns to one option of a choice question\.

Held in a list by [Probabilities](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceAnswer.Probabilities 'DiGi\.Laya\.Classes\.LayaChoiceAnswer\.Probabilities') rather than in a dictionary keyed by label, because the DiGi serializer rebuilds a dictionary with the default comparer of its type and files every key as a JSON object name.

```csharp
public class LayaProbability : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaProbability

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(DiGi.Laya.Classes.LayaProbability)'></a>

## LayaProbability\(LayaProbability\) Constructor

Initializes a new instance of the [LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability') class by copying an existing probability\.

```csharp
public LayaProbability(DiGi.Laya.Classes.LayaProbability? layaProbability);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(DiGi.Laya.Classes.LayaProbability).layaProbability'></a>

`layaProbability` [LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability')

The source probability to copy from\.

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(string,double)'></a>

## LayaProbability\(string, double\) Constructor

Initializes a new instance of the [LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability') class\.

```csharp
public LayaProbability(string? label, double value);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(string,double).label'></a>

`label` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The label of the option\.

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(string,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The probability of the option, between 0 and 1\.

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(System.Text.Json.Nodes.JsonObject)'></a>

## LayaProbability\(JsonObject\) Constructor

Initializes a new instance of the [LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability') class using a JSON object\.

```csharp
public LayaProbability(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaProbability.LayaProbability(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the probability data\.
### Properties

<a name='DiGi.Laya.Classes.LayaProbability.Label'></a>

## LayaProbability\.Label Property

Gets the label of the option\.

```csharp
public string? Label { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaProbability.Value'></a>

## LayaProbability\.Value Property

Gets the probability of the option, between 0 and 1\.

```csharp
public double Value { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Laya.Classes.LayaQuestion'></a>

## LayaQuestion Class

Represents one named question asked of the Laya decision model about a state\.

The derived type decides the question type and what it carries: [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion'), [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion') or [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion'). A list of questions round-trips polymorphically through the type discriminator of the DiGi serializer.

The DiGi serializer keys members by name across the hierarchy and lets the derived one win, so a derived type must not reuse [Name](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion.Name 'DiGi\.Laya\.Classes\.LayaQuestion\.Name') or [Instructions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion.Instructions 'DiGi\.Laya\.Classes\.LayaQuestion\.Instructions').

```csharp
public abstract class LayaQuestion : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaQuestion

Derived  
↳ [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion')  
↳ [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion')  
↳ [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion')

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(DiGi.Laya.Classes.LayaQuestion)'></a>

## LayaQuestion\(LayaQuestion\) Constructor

Initializes a new instance of the [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion') class by copying an existing question\.

```csharp
protected LayaQuestion(DiGi.Laya.Classes.LayaQuestion? layaQuestion);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(DiGi.Laya.Classes.LayaQuestion).layaQuestion'></a>

`layaQuestion` [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')

The source question to copy from\.

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(string,string)'></a>

## LayaQuestion\(string, string\) Constructor

Initializes a new instance of the [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion') class\.

```csharp
protected LayaQuestion(string? name, string? instructions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name the question is asked and answered under, unique within one request\.

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(string,string).instructions'></a>

`instructions` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The instructions telling the model what to decide\.

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(System.Text.Json.Nodes.JsonObject)'></a>

## LayaQuestion\(JsonObject\) Constructor

Initializes a new instance of the [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion') class using a JSON object\.

```csharp
protected LayaQuestion(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaQuestion.LayaQuestion(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the question data\.
### Properties

<a name='DiGi.Laya.Classes.LayaQuestion.Instructions'></a>

## LayaQuestion\.Instructions Property

Gets the instructions telling the model what to decide\.

For a [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion') this is the statement judged true or false.

```csharp
public string? Instructions { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaQuestion.Name'></a>

## LayaQuestion\.Name Property

Gets the name the question is asked and answered under, unique within one request\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaQuestion.QuestionType'></a>

## LayaQuestion\.QuestionType Property

Gets the type of the question, fixed by the derived type\.

```csharp
public abstract DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaRequest'></a>

## LayaRequest Class

Represents one state and the named questions the Laya decision model answers about it in one forward pass\.

The state travels as text. Laya encodes a JSON object or array state differently from a plain string, so a state that is JSON sets [StateIsJson](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.StateIsJson 'DiGi\.Laya\.Classes\.LayaRequest\.StateIsJson') and is parsed back into JSON when the request is written for Laya.

```csharp
public class LayaRequest : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaRequest

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(DiGi.Laya.Classes.LayaRequest)'></a>

## LayaRequest\(LayaRequest\) Constructor

Initializes a new instance of the [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest') class by copying an existing request\.

```csharp
public LayaRequest(DiGi.Laya.Classes.LayaRequest? layaRequest);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(DiGi.Laya.Classes.LayaRequest).layaRequest'></a>

`layaRequest` [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')

The source request to copy from\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_)'></a>

## LayaRequest\(string, string, bool, IEnumerable\<LayaQuestion\>, Nullable\<int\>, Nullable\<int\>\) Constructor

Initializes a new instance of the [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest') class\.

```csharp
public LayaRequest(string? id, string? state, bool stateIsJson, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaQuestion>? questions, System.Nullable<int> maxLength, System.Nullable<int> headMaxLength);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier the response is matched back to the request by, unique within one run\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).state'></a>

`state` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The state the questions are asked about, as text\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).stateIsJson'></a>

`stateIsJson` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether [state](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).state 'DiGi\.Laya\.Classes\.LayaRequest\.LayaRequest\(string, string, bool, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaQuestion\>, System\.Nullable\<int\>, System\.Nullable\<int\>\)\.state') is a JSON object or array rather than plain text\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).questions'></a>

`questions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The questions to answer, each under a name unique within the request\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).maxLength'></a>

`maxLength` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The token budget of the state, or `null` for the checkpoint's own\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(string,string,bool,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaQuestion_,System.Nullable_int_,System.Nullable_int_).headMaxLength'></a>

`headMaxLength` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The token budget of one question, or `null` for the checkpoint's own\.

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(System.Text.Json.Nodes.JsonObject)'></a>

## LayaRequest\(JsonObject\) Constructor

Initializes a new instance of the [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest') class using a JSON object\.

```csharp
public LayaRequest(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaRequest.LayaRequest(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the request data\.
### Properties

<a name='DiGi.Laya.Classes.LayaRequest.HeadMaxLength'></a>

## LayaRequest\.HeadMaxLength Property

Gets the token budget of one question, or `null` for the checkpoint's own\.

```csharp
public System.Nullable<int> HeadMaxLength { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaRequest.Id'></a>

## LayaRequest\.Id Property

Gets the identifier the response is matched back to the request by, unique within one run\.

```csharp
public string? Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaRequest.MaxLength'></a>

## LayaRequest\.MaxLength Property

Gets the token budget of the state, or `null` for the checkpoint's own\.

```csharp
public System.Nullable<int> MaxLength { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaRequest.Questions'></a>

## LayaRequest\.Questions Property

Gets the questions to answer, each under a name unique within the request\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaQuestion>? Questions { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaRequest.State'></a>

## LayaRequest\.State Property

Gets the state the questions are asked about, as text\.

```csharp
public string? State { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaRequest.StateIsJson'></a>

## LayaRequest\.StateIsJson Property

Gets a value indicating whether [State](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.State 'DiGi\.Laya\.Classes\.LayaRequest\.State') is a JSON object or array rather than plain text\.

```csharp
public bool StateIsJson { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaRequestMessage'></a>

## LayaRequestMessage Class

Represents a finding of a Laya prediction run about one request, together with the identifier of that request\.

Held by [RequestMessages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.RequestMessages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.RequestMessages') so that a caller can find the findings of a request by its identifier rather than by reading the message text.

```csharp
public class LayaRequestMessage : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaRequestMessage

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(DiGi.Laya.Classes.LayaRequestMessage)'></a>

## LayaRequestMessage\(LayaRequestMessage\) Constructor

Initializes a new instance of the [LayaRequestMessage](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequestMessage 'DiGi\.Laya\.Classes\.LayaRequestMessage') class by copying an existing request message\.

```csharp
public LayaRequestMessage(DiGi.Laya.Classes.LayaRequestMessage? layaRequestMessage);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(DiGi.Laya.Classes.LayaRequestMessage).layaRequestMessage'></a>

`layaRequestMessage` [LayaRequestMessage](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequestMessage 'DiGi\.Laya\.Classes\.LayaRequestMessage')

The source request message to copy from\.

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(string,string)'></a>

## LayaRequestMessage\(string, string\) Constructor

Initializes a new instance of the [LayaRequestMessage](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequestMessage 'DiGi\.Laya\.Classes\.LayaRequestMessage') class\.

```csharp
public LayaRequestMessage(string? requestId, string? message);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(string,string).requestId'></a>

`requestId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the request the finding is about\.

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(string,string).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The finding, as it also appears in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Messages')\.

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(System.Text.Json.Nodes.JsonObject)'></a>

## LayaRequestMessage\(JsonObject\) Constructor

Initializes a new instance of the [LayaRequestMessage](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequestMessage 'DiGi\.Laya\.Classes\.LayaRequestMessage') class using a JSON object\.

```csharp
public LayaRequestMessage(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaRequestMessage.LayaRequestMessage(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the request message data\.
### Properties

<a name='DiGi.Laya.Classes.LayaRequestMessage.Message'></a>

## LayaRequestMessage\.Message Property

Gets the finding, as it also appears in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Messages')\.

```csharp
public string? Message { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaRequestMessage.RequestId'></a>

## LayaRequestMessage\.RequestId Property

Gets the identifier of the request the finding is about\.

```csharp
public string? RequestId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaResponse'></a>

## LayaResponse Class

Represents the Laya decision model's answers to the questions of one [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')\.

```csharp
public class LayaResponse : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaResponse

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(DiGi.Laya.Classes.LayaResponse)'></a>

## LayaResponse\(LayaResponse\) Constructor

Initializes a new instance of the [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse') class by copying an existing response\.

```csharp
public LayaResponse(DiGi.Laya.Classes.LayaResponse? layaResponse);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(DiGi.Laya.Classes.LayaResponse).layaResponse'></a>

`layaResponse` [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')

The source response to copy from\.

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaAnswer_,System.Nullable_int_,System.Nullable_bool_)'></a>

## LayaResponse\(string, IEnumerable\<LayaAnswer\>, Nullable\<int\>, Nullable\<bool\>\) Constructor

Initializes a new instance of the [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse') class\.

```csharp
public LayaResponse(string? requestId, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaAnswer>? answers, System.Nullable<int> inputTokenCount, System.Nullable<bool> truncated);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaAnswer_,System.Nullable_int_,System.Nullable_bool_).requestId'></a>

`requestId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The [Id](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.Id 'DiGi\.Laya\.Classes\.LayaRequest\.Id') of the request answered\.

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaAnswer_,System.Nullable_int_,System.Nullable_bool_).answers'></a>

`answers` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The answers, one per question of the request\.

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaAnswer_,System.Nullable_int_,System.Nullable_bool_).inputTokenCount'></a>

`inputTokenCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of input tokens Laya reports for the request, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(string,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaAnswer_,System.Nullable_int_,System.Nullable_bool_).truncated'></a>

`truncated` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

A value indicating whether Laya cut the state or a question to fit its token budget, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(System.Text.Json.Nodes.JsonObject)'></a>

## LayaResponse\(JsonObject\) Constructor

Initializes a new instance of the [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse') class using a JSON object\.

```csharp
public LayaResponse(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaResponse.LayaResponse(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the response data\.
### Properties

<a name='DiGi.Laya.Classes.LayaResponse.Answers'></a>

## LayaResponse\.Answers Property

Gets the answers, one per question of the request\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaAnswer>? Answers { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaResponse.InputTokenCount'></a>

## LayaResponse\.InputTokenCount Property

Gets the number of input tokens Laya reports for the request \(its `usage.input_tokens`\), or `null` when not reported\.

```csharp
public System.Nullable<int> InputTokenCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaResponse.RequestId'></a>

## LayaResponse\.RequestId Property

Gets the [Id](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.Id 'DiGi\.Laya\.Classes\.LayaRequest\.Id') of the request answered\.

```csharp
public string? RequestId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaResponse.Truncated'></a>

## LayaResponse\.Truncated Property

Gets a value indicating whether Laya cut the state or a question to fit its token budget \(its `usage.truncated`\), or `null` when not reported\.

A truncated request was answered from part of its input only; raise [MaxLength](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.MaxLength 'DiGi\.Laya\.Classes\.LayaRequest\.MaxLength') or [HeadMaxLength](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.HeadMaxLength 'DiGi\.Laya\.Classes\.LayaRequest\.HeadMaxLength'), or shorten the state.

```csharp
public System.Nullable<bool> Truncated { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaScoreAnswer'></a>

## LayaScoreAnswer Class

Represents the answer to a [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion'): the expected level and the probability of every level\.

```csharp
public class LayaScoreAnswer : DiGi.Laya.Classes.LayaAnswer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer') → LayaScoreAnswer
### Constructors

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(DiGi.Laya.Classes.LayaScoreAnswer)'></a>

## LayaScoreAnswer\(LayaScoreAnswer\) Constructor

Initializes a new instance of the [LayaScoreAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreAnswer 'DiGi\.Laya\.Classes\.LayaScoreAnswer') class by copying an existing answer\.

```csharp
public LayaScoreAnswer(DiGi.Laya.Classes.LayaScoreAnswer? layaScoreAnswer);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(DiGi.Laya.Classes.LayaScoreAnswer).layaScoreAnswer'></a>

`layaScoreAnswer` [LayaScoreAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreAnswer 'DiGi\.Laya\.Classes\.LayaScoreAnswer')

The source answer to copy from\.

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_double_)'></a>

## LayaScoreAnswer\(string, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, IEnumerable\<double\>\) Constructor

Initializes a new instance of the [LayaScoreAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreAnswer 'DiGi\.Laya\.Classes\.LayaScoreAnswer') class\.

```csharp
public LayaScoreAnswer(string? name, System.Nullable<double> confidence, System.Nullable<double> answerConfidence, System.Nullable<double> level, System.Collections.Generic.IEnumerable<double>? distribution);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_double_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the question answered\.

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_double_).confidence'></a>

`confidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya derives from the probability distribution, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_double_).answerConfidence'></a>

`answerConfidence` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The confidence Laya reports for the answer itself, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_double_).level'></a>

`level` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The expected level, the probability\-weighted mean of the zero\-based level indexes\.

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(string,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Collections.Generic.IEnumerable_double_).distribution'></a>

`distribution` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The probability of every level, indexed by zero\-based level\.

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(System.Text.Json.Nodes.JsonObject)'></a>

## LayaScoreAnswer\(JsonObject\) Constructor

Initializes a new instance of the [LayaScoreAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreAnswer 'DiGi\.Laya\.Classes\.LayaScoreAnswer') class using a JSON object\.

```csharp
public LayaScoreAnswer(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaScoreAnswer.LayaScoreAnswer(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the answer data\.
### Properties

<a name='DiGi.Laya.Classes.LayaScoreAnswer.Distribution'></a>

## LayaScoreAnswer\.Distribution Property

Gets the probability of every level, indexed by zero\-based level\.

```csharp
public System.Collections.Generic.List<double>? Distribution { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaScoreAnswer.Level'></a>

## LayaScoreAnswer\.Level Property

Gets the expected level, the probability\-weighted mean of the zero\-based level indexes \(Laya's `score`\)\.

```csharp
public System.Nullable<double> Level { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaScoreAnswer.QuestionType'></a>

## LayaScoreAnswer\.QuestionType Property

Gets [Score](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType.Score 'DiGi\.Laya\.Enums\.LayaQuestionType\.Score')\.

```csharp
public override DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaScoreQuestion'></a>

## LayaScoreQuestion Class

Represents a question answered on an ordered scale of levels, lowest first\.

```csharp
public class LayaScoreQuestion : DiGi.Laya.Classes.LayaQuestion
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion') → LayaScoreQuestion
### Constructors

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(DiGi.Laya.Classes.LayaScoreQuestion)'></a>

## LayaScoreQuestion\(LayaScoreQuestion\) Constructor

Initializes a new instance of the [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion') class by copying an existing question\.

```csharp
public LayaScoreQuestion(DiGi.Laya.Classes.LayaScoreQuestion? layaScoreQuestion);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(DiGi.Laya.Classes.LayaScoreQuestion).layaScoreQuestion'></a>

`layaScoreQuestion` [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion')

The source question to copy from\.

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(string,string,System.Collections.Generic.IEnumerable_string_)'></a>

## LayaScoreQuestion\(string, string, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion') class\.

```csharp
public LayaScoreQuestion(string? name, string? instructions, System.Collections.Generic.IEnumerable<string>? levels);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(string,string,System.Collections.Generic.IEnumerable_string_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name the question is asked and answered under, unique within one request\.

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(string,string,System.Collections.Generic.IEnumerable_string_).instructions'></a>

`instructions` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The instructions telling the model what to rate\.

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(string,string,System.Collections.Generic.IEnumerable_string_).levels'></a>

`levels` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The descriptions of the levels, lowest first; a level is answered by its zero\-based index\.

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(System.Text.Json.Nodes.JsonObject)'></a>

## LayaScoreQuestion\(JsonObject\) Constructor

Initializes a new instance of the [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion') class using a JSON object\.

```csharp
public LayaScoreQuestion(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaScoreQuestion.LayaScoreQuestion(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the question data\.
### Properties

<a name='DiGi.Laya.Classes.LayaScoreQuestion.Levels'></a>

## LayaScoreQuestion\.Levels Property

Gets the descriptions of the levels, lowest first; a level is answered by its zero\-based index\.

```csharp
public System.Collections.Generic.List<string>? Levels { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaScoreQuestion.QuestionType'></a>

## LayaScoreQuestion\.QuestionType Property

Gets [Score](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType.Score 'DiGi\.Laya\.Enums\.LayaQuestionType\.Score')\.

```csharp
public override DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaSkippedCount'></a>

## LayaSkippedCount Class

Represents how many labelled questions laya\.train\.finetune skipped for one reason\.

Held in a list by [SkippedCounts](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult.SkippedCounts 'DiGi\.Laya\.Classes\.LayaTrainingResult\.SkippedCounts') rather than in a dictionary keyed by reason, because the DiGi serializer rebuilds a dictionary with the default comparer of its type and files every key as a JSON object name.

```csharp
public class LayaSkippedCount : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaSkippedCount

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(DiGi.Laya.Classes.LayaSkippedCount)'></a>

## LayaSkippedCount\(LayaSkippedCount\) Constructor

Initializes a new instance of the [LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount') class by copying an existing instance\.

```csharp
public LayaSkippedCount(DiGi.Laya.Classes.LayaSkippedCount? layaSkippedCount);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(DiGi.Laya.Classes.LayaSkippedCount).layaSkippedCount'></a>

`layaSkippedCount` [LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(string,int)'></a>

## LayaSkippedCount\(string, int\) Constructor

Initializes a new instance of the [LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount') class\.

```csharp
public LayaSkippedCount(string? reason, int count);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(string,int).reason'></a>

`reason` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The reason laya gives: empty\_text, empty\_label, invalid\_question, invalid\_target, options\_collapsed or options\_beyond\_max\_len\.

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(string,int).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of questions skipped for that reason\.

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(System.Text.Json.Nodes.JsonObject)'></a>

## LayaSkippedCount\(JsonObject\) Constructor

Initializes a new instance of the [LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount') class using a JSON object\.

```csharp
public LayaSkippedCount(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaSkippedCount.LayaSkippedCount(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaSkippedCount.Count'></a>

## LayaSkippedCount\.Count Property

Gets the number of questions skipped for that reason\.

```csharp
public int Count { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaSkippedCount.Reason'></a>

## LayaSkippedCount\.Reason Property

Gets the reason laya gives: empty\_text, empty\_label, invalid\_question, invalid\_target, options\_collapsed or options\_beyond\_max\_len\.

```csharp
public string? Reason { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTemperature'></a>

## LayaTemperature Class

Represents the calibration temperature of one question type: the logits are divided by it before the softmax\.

A value at a bound usually means the data could not place it - too few records of that type - rather than that the model needs it.

```csharp
public class LayaTemperature : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaTemperature

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(DiGi.Laya.Classes.LayaTemperature)'></a>

## LayaTemperature\(LayaTemperature\) Constructor

Initializes a new instance of the [LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature') class by copying an existing instance\.

```csharp
public LayaTemperature(DiGi.Laya.Classes.LayaTemperature? layaTemperature);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(DiGi.Laya.Classes.LayaTemperature).layaTemperature'></a>

`layaTemperature` [LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(DiGi.Laya.Enums.LayaQuestionType,double)'></a>

## LayaTemperature\(LayaQuestionType, double\) Constructor

Initializes a new instance of the [LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature') class\.

```csharp
public LayaTemperature(DiGi.Laya.Enums.LayaQuestionType questionType, double value);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(DiGi.Laya.Enums.LayaQuestionType,double).questionType'></a>

`questionType` [LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

The question type the temperature applies to\.

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(DiGi.Laya.Enums.LayaQuestionType,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The temperature, clamped by laya to \[0\.5, 5\.0\]; 1 leaves the probabilities as the model gives them\.

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(System.Text.Json.Nodes.JsonObject)'></a>

## LayaTemperature\(JsonObject\) Constructor

Initializes a new instance of the [LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature') class using a JSON object\.

```csharp
public LayaTemperature(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTemperature.LayaTemperature(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaTemperature.QuestionType'></a>

## LayaTemperature\.QuestionType Property

Gets the question type the temperature applies to\.

```csharp
public DiGi.Laya.Enums.LayaQuestionType QuestionType { get; }
```

#### Property Value
[LayaQuestionType](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaQuestionType 'DiGi\.Laya\.Enums\.LayaQuestionType')

<a name='DiGi.Laya.Classes.LayaTemperature.Value'></a>

## LayaTemperature\.Value Property

Gets the temperature, clamped by laya to \[0\.5, 5\.0\]; 1 leaves the probabilities as the model gives them\.

```csharp
public double Value { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Laya.Classes.LayaTrainingOptions'></a>

## LayaTrainingOptions Class

Provides the settings of one fine\-tuning run of laya\.train\.finetune: the interpreter, the base checkpoint, the data, where the new checkpoint goes, and the training settings\.

A training setting left `null` (or `Default`) keeps laya's own default, which follows the published notebook: 4 epochs, a micro-batch of 8 with 8 accumulation steps, learning rates 2.5e-5 (encoder) and 1e-4 (head), the base checkpoint's token budgets, and a calibration slice of 400 items or a tenth of the data, whichever is smaller. The settings that are set are written for train.py by [ToLaya\_TrainConfiguration\(this LayaTrainingOptions\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_TrainConfiguration(thisDiGi.Laya.Classes.LayaTrainingOptions) 'DiGi\.Laya\.Convert\.ToLaya\_TrainConfiguration\(this DiGi\.Laya\.Classes\.LayaTrainingOptions\)').

Training data and outputs belong in a training directory outside the workspace; `Modify.TrainAsync` refuses an output directory inside a Laya\models folder, where deployed checkpoints live.

```csharp
public class LayaTrainingOptions : DiGi.Core.Classes.SerializableOptions, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → LayaTrainingOptions

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaTrainingOptions.LayaTrainingOptions()'></a>

## LayaTrainingOptions\(\) Constructor

Initializes a new instance of the [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions') class with default values\.

```csharp
public LayaTrainingOptions();
```

<a name='DiGi.Laya.Classes.LayaTrainingOptions.LayaTrainingOptions(DiGi.Laya.Classes.LayaTrainingOptions)'></a>

## LayaTrainingOptions\(LayaTrainingOptions\) Constructor

Initializes a new instance of the [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions') class by copying an existing options instance\.

```csharp
public LayaTrainingOptions(DiGi.Laya.Classes.LayaTrainingOptions? layaTrainingOptions);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingOptions.LayaTrainingOptions(DiGi.Laya.Classes.LayaTrainingOptions).layaTrainingOptions'></a>

`layaTrainingOptions` [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions')

The source options instance to copy from\.

<a name='DiGi.Laya.Classes.LayaTrainingOptions.LayaTrainingOptions(System.Text.Json.Nodes.JsonObject)'></a>

## LayaTrainingOptions\(JsonObject\) Constructor

Initializes a new instance of the [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions') class using a JSON object\.

```csharp
public LayaTrainingOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingOptions.LayaTrainingOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the settings\.
### Properties

<a name='DiGi.Laya.Classes.LayaTrainingOptions.BaseModelPath'></a>

## LayaTrainingOptions\.BaseModelPath Property

Gets or sets the checkpoint directory training starts from, resolved by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)'); a model name or Hub id is refused\.

```csharp
public string? BaseModelPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.CalibrationFraction'></a>

## LayaTrainingOptions\.CalibrationFraction Property

Gets or sets the largest share of the items held out to fit the calibration temperatures \(TrainConfig\.calib\_frac\), or `null` for laya's 0\.1\.

laya holds out min([CalibrationMaximum](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions.CalibrationMaximum 'DiGi\.Laya\.Classes\.LayaTrainingOptions\.CalibrationMaximum'), the item count times this, rounded down) items, so on a small dataset this, not the maximum, decides.

```csharp
public System.Nullable<double> CalibrationFraction { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.CalibrationMaximum'></a>

## LayaTrainingOptions\.CalibrationMaximum Property

Gets or sets the most items held out to fit the calibration temperatures \(TrainConfig\.calib\_max\), or `null` for laya's 400\.

```csharp
public System.Nullable<int> CalibrationMaximum { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.CalibrationSeed'></a>

## LayaTrainingOptions\.CalibrationSeed Property

Gets or sets the seed of the calibration hold\-out \(TrainConfig\.calib\_seed\), or `null` for laya's\.

```csharp
public System.Nullable<int> CalibrationSeed { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.Device'></a>

## LayaTrainingOptions\.Device Property

Gets or sets the device training runs on, passed to train\.py as \-\-device\.

```csharp
public DiGi.Laya.Enums.LayaDevice Device { get; set; }
```

#### Property Value
[LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.EncoderLearningRate'></a>

## LayaTrainingOptions\.EncoderLearningRate Property

Gets or sets the learning rate of the encoder \(TrainConfig\.encoder\_lr\), or `null` for laya's 2\.5e\-5\.

```csharp
public System.Nullable<double> EncoderLearningRate { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.Epochs'></a>

## LayaTrainingOptions\.Epochs Property

Gets or sets the number of epochs \(TrainConfig\.epochs\), or `null` for laya's 4\. A small dataset needs more epochs to reach a similar number of optimizer updates\.

```csharp
public System.Nullable<int> Epochs { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.EvaluationFilePath'></a>

## LayaTrainingOptions\.EvaluationFilePath Property

Gets or sets a second labelled JSONL answered before and after training \(TrainConfig\.eval\_data\), or `null` to report on the calibration slice\.

```csharp
public string? EvaluationFilePath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.FreezeEncoder'></a>

## LayaTrainingOptions\.FreezeEncoder Property

Gets or sets a value indicating whether only the decision head is trained \(TrainConfig\.freeze\_encoder\); fits a small GPU or a CPU, but gains much less\.

```csharp
public bool FreezeEncoder { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.GradientAccumulation'></a>

## LayaTrainingOptions\.GradientAccumulation Property

Gets or sets the number of micro\-batches per optimizer update \(TrainConfig\.grad\_accum\), or `null` for laya's 8\.

```csharp
public System.Nullable<int> GradientAccumulation { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.HeadLearningRate'></a>

## LayaTrainingOptions\.HeadLearningRate Property

Gets or sets the learning rate of the decision head \(TrainConfig\.head\_lr\), or `null` for laya's 1e\-4\.

```csharp
public System.Nullable<double> HeadLearningRate { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.HeadMaxLength'></a>

## LayaTrainingOptions\.HeadMaxLength Property

Gets or sets the token budget of one question \(TrainConfig\.head\_max\_len\), or `null` for the base checkpoint's; it is written into the new checkpoint\.

```csharp
public System.Nullable<int> HeadMaxLength { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.InactivityTimeout'></a>

## LayaTrainingOptions\.InactivityTimeout Property

Gets or sets the span without output after which the run is ended as stalled, or `null` for no limit\. laya logs every 100 steps, so allow for that\.

```csharp
public System.Nullable<System.TimeSpan> InactivityTimeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.LabelSmoothing'></a>

## LayaTrainingOptions\.LabelSmoothing Property

Gets or sets the share of each answer's weight moved to the other options \(TrainConfig\.label\_smoothing\), or `null` for none\.

```csharp
public System.Nullable<double> LabelSmoothing { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.Loss'></a>

## LayaTrainingOptions\.Loss Property

Gets or sets the training objective \(TrainConfig\.loss\)\.

```csharp
public DiGi.Laya.Enums.LayaLoss Loss { get; set; }
```

#### Property Value
[LayaLoss](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaLoss 'DiGi\.Laya\.Enums\.LayaLoss')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.MaxLength'></a>

## LayaTrainingOptions\.MaxLength Property

Gets or sets the token budget of the state \(TrainConfig\.max\_len\), or `null` for the base checkpoint's; it is written into the new checkpoint\.

```csharp
public System.Nullable<int> MaxLength { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.MicroBatch'></a>

## LayaTrainingOptions\.MicroBatch Property

Gets or sets the number of items per micro\-batch \(TrainConfig\.micro\_batch\), or `null` for laya's 8\. Lowering it reduces GPU memory\.

```csharp
public System.Nullable<int> MicroBatch { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.OptionLayout'></a>

## LayaTrainingOptions\.OptionLayout Property

Gets or sets the option layout \(TrainConfig\.option\_layout\); parallel needs transformers 5 or later\.

```csharp
public DiGi.Laya.Enums.LayaOptionLayout OptionLayout { get; set; }
```

#### Property Value
[LayaOptionLayout](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaOptionLayout 'DiGi\.Laya\.Enums\.LayaOptionLayout')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.OutputDirectory'></a>

## LayaTrainingOptions\.OutputDirectory Property

Gets or sets the directory the new checkpoint is written to; it must be absent or empty, outside the base checkpoint, and not inside a Laya\\models folder\.

```csharp
public string? OutputDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.PythonPath'></a>

## LayaTrainingOptions\.PythonPath Property

Gets or sets the CPython interpreter carrying laya, resolved by [LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)'); `null` searches PATH\.

```csharp
public string? PythonPath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.Seed'></a>

## LayaTrainingOptions\.Seed Property

Gets or sets the training seed \(TrainConfig\.seed\), or `null` for laya's 0\. Leaving the initial plateau is seed\-dependent, so repeat a run with other seeds before calling a task unlearnable\.

```csharp
public System.Nullable<int> Seed { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.ShuffleChoiceOptions'></a>

## LayaTrainingOptions\.ShuffleChoiceOptions Property

Gets or sets a value indicating whether choice questions are re\-encoded with a random option order every epoch \(TrainConfig\.shuffle\_options = \["choice"\]\); worth it for questions with many options\.

```csharp
public bool ShuffleChoiceOptions { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.TargetError'></a>

## LayaTrainingOptions\.TargetError Property

Gets or sets the error the abstention thresholds are fitted to keep among accepted answers \(TrainConfig\.target\_error\), or `null` for laya's 0\.10\.

```csharp
public System.Nullable<double> TargetError { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.Timeout'></a>

## LayaTrainingOptions\.Timeout Property

Gets or sets the span after which the run is ended whatever it is doing, or `null` for no limit\.

```csharp
public System.Nullable<System.TimeSpan> Timeout { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.TrainingFilePath'></a>

## LayaTrainingOptions\.TrainingFilePath Property

Gets or sets the training JSONL, written by `Modify.WriteTrainingFile`\.

```csharp
public string? TrainingFilePath { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingOptions.WorkingDirectory'></a>

## LayaTrainingOptions\.WorkingDirectory Property

Gets or sets the directory the scripts and train\_config\.json are written to, or `null` for a fresh temporary directory removed after the run\.

```csharp
public string? WorkingDirectory { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingResult'></a>

## LayaTrainingResult Class

Represents how a fine\-tuning run went: the checkpoint it produced, what laya reported about it, and every finding about the run\.

A checkpoint is trusted only when the run exited with 0, its report was read and the directory holds rl_agent_config.json and model.safetensors; only then is [ModelSHA256](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult.ModelSHA256 'DiGi\.Laya\.Classes\.LayaTrainingResult\.ModelSHA256') set (DiGi-Organization/DiGi.Laya#1, D5).

```csharp
public class LayaTrainingResult : DiGi.Core.Classes.SerializableResult, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → LayaTrainingResult

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(DiGi.Laya.Classes.LayaTrainingResult)'></a>

## LayaTrainingResult\(LayaTrainingResult\) Constructor

Initializes a new instance of the [LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult') class by copying an existing instance\.

```csharp
public LayaTrainingResult(DiGi.Laya.Classes.LayaTrainingResult? layaTrainingResult);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(DiGi.Laya.Classes.LayaTrainingResult).layaTrainingResult'></a>

`layaTrainingResult` [LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult')

The source instance to copy from\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_)'></a>

## LayaTrainingResult\(string, string, string, Nullable\<int\>, Nullable\<int\>, Nullable\<int\>, IEnumerable\<LayaSkippedCount\>, IEnumerable\<double\>, IEnumerable\<LayaTemperature\>, Nullable\<TimeSpan\>, int, bool, bool, bool, IEnumerable\<string\>\) Constructor

Initializes a new instance of the [LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult') class\.

```csharp
public LayaTrainingResult(string? checkpointDirectory, string? modelSHA256, string? baseModelSHA256, System.Nullable<int> trainItemCount, System.Nullable<int> calibrationItemCount, System.Nullable<int> evaluationItemCount, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaSkippedCount>? skippedCounts, System.Collections.Generic.IEnumerable<double>? epochLosses, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaTemperature>? temperatures, System.Nullable<System.TimeSpan> duration, int exitCode, bool stalled, bool timedOut, bool cancelled, System.Collections.Generic.IEnumerable<string>? messages);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).checkpointDirectory'></a>

`checkpointDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the new checkpoint was written to\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).modelSHA256'></a>

`modelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the new checkpoint directory, or `null` when the checkpoint is not trusted \(the run failed, reported nothing, or left no rl\_agent\_config\.json or model\.safetensors\)\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).baseModelSHA256'></a>

`baseModelSHA256` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SHA\-256 of the base checkpoint directory, taken before the run\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).trainItemCount'></a>

`trainItemCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of labelled questions trained on, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).calibrationItemCount'></a>

`calibrationItemCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of labelled questions held out to fit the calibration temperatures, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).evaluationItemCount'></a>

`evaluationItemCount` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of labelled questions answered before and after training, or `null` when not reported\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).skippedCounts'></a>

`skippedCounts` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The labelled questions laya skipped, by reason\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).epochLosses'></a>

`epochLosses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The mean training loss of every epoch, in epoch order\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).temperatures'></a>

`temperatures` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The calibration temperatures written into the new checkpoint, by question type\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).duration'></a>

`duration` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The wall\-clock time of the run, or `null` when no process was started\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).exitCode'></a>

`exitCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The exit code of the script; \-1 when the process was ended, failed to start or was never started\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).stalled'></a>

`stalled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended for inactivity\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).timedOut'></a>

`timedOut` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the process was ended by the overall time limit\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).cancelled'></a>

`cancelled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the caller cancelled the run\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(string,string,string,System.Nullable_int_,System.Nullable_int_,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaSkippedCount_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTemperature_,System.Nullable_System.TimeSpan_,int,bool,bool,bool,System.Collections.Generic.IEnumerable_string_).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The findings about the run\.

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(System.Text.Json.Nodes.JsonObject)'></a>

## LayaTrainingResult\(JsonObject\) Constructor

Initializes a new instance of the [LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult') class using a JSON object\.

```csharp
public LayaTrainingResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingResult.LayaTrainingResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\.
### Properties

<a name='DiGi.Laya.Classes.LayaTrainingResult.BaseModelSHA256'></a>

## LayaTrainingResult\.BaseModelSHA256 Property

Gets the SHA\-256 of the base checkpoint directory, taken before the run\.

```csharp
public string? BaseModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingResult.CalibrationItemCount'></a>

## LayaTrainingResult\.CalibrationItemCount Property

Gets the number of labelled questions held out to fit the calibration temperatures, or `null` when not reported\.

```csharp
public System.Nullable<int> CalibrationItemCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.Cancelled'></a>

## LayaTrainingResult\.Cancelled Property

Gets a value indicating whether the caller cancelled the run\.

```csharp
public bool Cancelled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaTrainingResult.CheckpointDirectory'></a>

## LayaTrainingResult\.CheckpointDirectory Property

Gets the directory the new checkpoint was written to\.

```csharp
public string? CheckpointDirectory { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingResult.Duration'></a>

## LayaTrainingResult\.Duration Property

Gets the wall\-clock time of the run, or `null` when no process was started\.

```csharp
public System.Nullable<System.TimeSpan> Duration { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.EpochLosses'></a>

## LayaTrainingResult\.EpochLosses Property

Gets the mean training loss of every epoch, in epoch order\.

```csharp
public System.Collections.Generic.List<double>? EpochLosses { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.EvaluationItemCount'></a>

## LayaTrainingResult\.EvaluationItemCount Property

Gets the number of labelled questions answered before and after training, or `null` when not reported\.

```csharp
public System.Nullable<int> EvaluationItemCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.ExitCode'></a>

## LayaTrainingResult\.ExitCode Property

Gets the exit code of the script; \-1 when the process was ended, failed to start or was never started\.

```csharp
public int ExitCode { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Laya.Classes.LayaTrainingResult.Messages'></a>

## LayaTrainingResult\.Messages Property

Gets the findings about the run\.

```csharp
public System.Collections.Generic.List<string>? Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.ModelSHA256'></a>

## LayaTrainingResult\.ModelSHA256 Property

Gets the SHA\-256 of the new checkpoint directory, or `null` when the checkpoint is not trusted \(the run failed, reported nothing, or left no rl\_agent\_config\.json or model\.safetensors\)\.

```csharp
public string? ModelSHA256 { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingResult.SkippedCounts'></a>

## LayaTrainingResult\.SkippedCounts Property

Gets the labelled questions laya skipped, by reason\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaSkippedCount>? SkippedCounts { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.Stalled'></a>

## LayaTrainingResult\.Stalled Property

Gets a value indicating whether the process was ended for inactivity\.

```csharp
public bool Stalled { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaTrainingResult.Temperatures'></a>

## LayaTrainingResult\.Temperatures Property

Gets the calibration temperatures written into the new checkpoint, by question type\.

```csharp
public System.Collections.Generic.List<DiGi.Laya.Classes.LayaTemperature>? Temperatures { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Laya.Classes.LayaTrainingResult.TimedOut'></a>

## LayaTrainingResult\.TimedOut Property

Gets a value indicating whether the process was ended by the overall time limit\.

```csharp
public bool TimedOut { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaTrainingResult.TrainItemCount'></a>

## LayaTrainingResult\.TrainItemCount Property

Gets the number of labelled questions trained on, or `null` when not reported\.

```csharp
public System.Nullable<int> TrainItemCount { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingSample'></a>

## LayaTrainingSample Class

Represents one labelled decision Laya is fine\-tuned on: a state, one question about it, and the answer the model should give\.

The target member matches the question type: [Label](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Label 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Label') for a [LayaChoiceQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaChoiceQuestion 'DiGi\.Laya\.Classes\.LayaChoiceQuestion'), [Level](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Level 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Level') for a [LayaScoreQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaScoreQuestion 'DiGi\.Laya\.Classes\.LayaScoreQuestion'), and [Truth](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Truth 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Truth') or [Probability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Probability 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Probability') for a [LayaNoulQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaNoulQuestion 'DiGi\.Laya\.Classes\.LayaNoulQuestion'). Laya has no per-sample weight, so a weak noul label is expressed as a soft target in [Probability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Probability 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Probability') instead.

The constructors only assign. [ToLaya\_TrainingLine\(this LayaTrainingSample\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_TrainingLine(thisDiGi.Laya.Classes.LayaTrainingSample) 'DiGi\.Laya\.Convert\.ToLaya\_TrainingLine\(this DiGi\.Laya\.Classes\.LayaTrainingSample\)') rejects a sample whose target does not fit its question.

```csharp
public class LayaTrainingSample : DiGi.Core.Classes.SerializableObject, DiGi.Laya.Interfaces.ILayaSerializableObject, DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → LayaTrainingSample

Implements [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject'), [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(DiGi.Laya.Classes.LayaTrainingSample)'></a>

## LayaTrainingSample\(LayaTrainingSample\) Constructor

Initializes a new instance of the [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample') class by copying an existing sample\.

```csharp
public LayaTrainingSample(DiGi.Laya.Classes.LayaTrainingSample? layaTrainingSample);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(DiGi.Laya.Classes.LayaTrainingSample).layaTrainingSample'></a>

`layaTrainingSample` [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample')

The source sample to copy from\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string)'></a>

## LayaTrainingSample\(string, string, bool, LayaQuestion, string, Nullable\<double\>, Nullable\<bool\>, Nullable\<double\>, string\) Constructor

Initializes a new instance of the [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample') class\.

```csharp
public LayaTrainingSample(string? id, string? state, bool stateIsJson, DiGi.Laya.Classes.LayaQuestion? question, string? label, System.Nullable<double> level, System.Nullable<bool> truth, System.Nullable<double> probability, string? group);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the sample, written to the training line for tracing\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).state'></a>

`state` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The state the question is asked about, as text\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).stateIsJson'></a>

`stateIsJson` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether [state](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).state 'DiGi\.Laya\.Classes\.LayaTrainingSample\.LayaTrainingSample\(string, string, bool, DiGi\.Laya\.Classes\.LayaQuestion, string, System\.Nullable\<double\>, System\.Nullable\<bool\>, System\.Nullable\<double\>, string\)\.state') is a JSON object or array rather than plain text\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).question'></a>

`question` [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')

The question the sample labels\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).label'></a>

`label` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The expected label of a choice question\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).level'></a>

`level` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The expected zero\-based level of a score question; a fractional level splits its weight between the two neighbouring levels\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).truth'></a>

`truth` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The expected answer of a noul question\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).probability'></a>

`probability` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The soft target of a noul question, the probability that the statement is true; takes precedence over [truth](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).truth 'DiGi\.Laya\.Classes\.LayaTrainingSample\.LayaTrainingSample\(string, string, bool, DiGi\.Laya\.Classes\.LayaQuestion, string, System\.Nullable\<double\>, System\.Nullable\<bool\>, System\.Nullable\<double\>, string\)\.truth')\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(string,string,bool,DiGi.Laya.Classes.LayaQuestion,string,System.Nullable_double_,System.Nullable_bool_,System.Nullable_double_,string).group'></a>

`group` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The group that has to stay within one fold, or `null` when the sample stands alone\.

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(System.Text.Json.Nodes.JsonObject)'></a>

## LayaTrainingSample\(JsonObject\) Constructor

Initializes a new instance of the [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample') class using a JSON object\.

```csharp
public LayaTrainingSample(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Classes.LayaTrainingSample.LayaTrainingSample(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the sample data\.
### Properties

<a name='DiGi.Laya.Classes.LayaTrainingSample.Group'></a>

## LayaTrainingSample\.Group Property

Gets the group that has to stay within one fold, or `null` when the sample stands alone\.

```csharp
public string? Group { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingSample.Id'></a>

## LayaTrainingSample\.Id Property

Gets the identifier of the sample, written to the training line for tracing\.

```csharp
public string? Id { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingSample.Label'></a>

## LayaTrainingSample\.Label Property

Gets the expected label of a choice question\.

```csharp
public string? Label { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingSample.Level'></a>

## LayaTrainingSample\.Level Property

Gets the expected zero\-based level of a score question; a fractional level splits its weight between the two neighbouring levels\.

```csharp
public System.Nullable<double> Level { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingSample.Probability'></a>

## LayaTrainingSample\.Probability Property

Gets the soft target of a noul question, the probability that the statement is true; takes precedence over [Truth](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Truth 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Truth')\.

```csharp
public System.Nullable<double> Probability { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Laya.Classes.LayaTrainingSample.Question'></a>

## LayaTrainingSample\.Question Property

Gets the question the sample labels\.

```csharp
public DiGi.Laya.Classes.LayaQuestion? Question { get; }
```

#### Property Value
[LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')

<a name='DiGi.Laya.Classes.LayaTrainingSample.State'></a>

## LayaTrainingSample\.State Property

Gets the state the question is asked about, as text\.

```csharp
public string? State { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Laya.Classes.LayaTrainingSample.StateIsJson'></a>

## LayaTrainingSample\.StateIsJson Property

Gets a value indicating whether [State](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.State 'DiGi\.Laya\.Classes\.LayaTrainingSample\.State') is a JSON object or array rather than plain text\.

```csharp
public bool StateIsJson { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Laya.Classes.LayaTrainingSample.Truth'></a>

## LayaTrainingSample\.Truth Property

Gets the expected answer of a noul question\.

```csharp
public System.Nullable<bool> Truth { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')