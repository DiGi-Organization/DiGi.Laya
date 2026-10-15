#### [DiGi\.Laya](DiGi.Laya.Overview.md 'DiGi\.Laya\.Overview')

## DiGi\.Laya Namespace
### Classes

<a name='DiGi.Laya.Convert'></a>

## Convert Class

```csharp
public static class Convert
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Convert
### Methods

<a name='DiGi.Laya.Convert.ToDiGi_LayaResponse(thisSystem.Text.Json.Nodes.JsonObject)'></a>

## Convert\.ToDiGi\_LayaResponse\(this JsonObject\) Method

Converts one line predict\.py writes to responses\.jsonl into a [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')\.

The line is the result of Laya's `predict`/`predict_batch` plus the request id: `{"id": …, "answers": {name: answer}, "usage": {"input_tokens": …, "truncated": …}}`. Each answer is read by its `type` (laya 0.4.7): a `choice` answer's label from `choice` and its probabilities from `probabilities` in document order (Laya writes them in criteria order); a `score` answer's expected level from `score` and its distribution from `probabilities` keyed by level index; a `noul` answer's probability from `noul`; every answer's `confidence` and `answer_confidence`. Answers keep their document order.

Numbers are read from their JSON text with [System\.Globalization\.CultureInfo\.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System\.Globalization\.CultureInfo\.InvariantCulture'), so a node built in memory and the same node parsed from a file give the same values and the current culture plays no part. An answer of an unknown type, or one that is not an object, is skipped rather than failing the response: a missing answer is reported by the caller, which knows the questions it asked.

```csharp
public static DiGi.Laya.Classes.LayaResponse? ToDiGi_LayaResponse(this System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Laya.Convert.ToDiGi_LayaResponse(thisSystem.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The response line to convert\.

#### Returns
[LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')  
The response, or `null` when [jsonObject](DiGi.Laya.md#DiGi.Laya.Convert.ToDiGi_LayaResponse(thisSystem.Text.Json.Nodes.JsonObject).jsonObject 'DiGi\.Laya\.Convert\.ToDiGi\_LayaResponse\(this System\.Text\.Json\.Nodes\.JsonObject\)\.jsonObject') is `null`\.

<a name='DiGi.Laya.Convert.ToLaya_JsonNode(thisstring,bool)'></a>

## Convert\.ToLaya\_JsonNode\(this string, bool\) Method

Converts a state held as text into the JSON node Laya reads as its state\.

Laya encodes a JSON object or array state differently from a plain string, so a state flagged as JSON is parsed back into an object or array, and any other state becomes a JSON string.

```csharp
public static System.Text.Json.Nodes.JsonNode? ToLaya_JsonNode(this string? state, bool stateIsJson);
```
#### Parameters

<a name='DiGi.Laya.Convert.ToLaya_JsonNode(thisstring,bool).state'></a>

`state` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The state as text\.

<a name='DiGi.Laya.Convert.ToLaya_JsonNode(thisstring,bool).stateIsJson'></a>

`stateIsJson` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether [state](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonNode(thisstring,bool).state 'DiGi\.Laya\.Convert\.ToLaya\_JsonNode\(this string, bool\)\.state') is a JSON object or array rather than plain text\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonNode](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode 'System\.Text\.Json\.Nodes\.JsonNode')  
The state node, or `null` when the state is `null`, blank, or flagged as JSON but not a well\-formed JSON object or array\.

<a name='DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaQuestion)'></a>

## Convert\.ToLaya\_JsonObject\(this LayaQuestion\) Method

Converts a question into the definition Laya reads under its name in a request's `questions` object\.

A choice question becomes `{"type": "choice", "instructions": …, "criteria": {label: description}}` with the criteria in their order (a `null` description stays `null`, which Laya accepts); a score question becomes `{"type": "score", "instructions": …, "criteria": [level, …]}`, lowest first; a noul question becomes `{"type": "noul", "instructions": statement}`. The name is not part of the definition - it is the key the definition is filed under.

Mirrors the checks Laya's `Agent._check_question` applies, so a question Laya would refuse is refused here instead of failing a whole batch in the CPython process.

```csharp
public static System.Text.Json.Nodes.JsonObject? ToLaya_JsonObject(this DiGi.Laya.Classes.LayaQuestion? layaQuestion);
```
#### Parameters

<a name='DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaQuestion).layaQuestion'></a>

`layaQuestion` [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')

The question to convert\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The question definition, or `null` when the question is `null`, has a blank name or blank instructions, is a choice question without criteria or with a `null` or repeated label, or is a score question without levels or with a `null` level\.

<a name='DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaRequest)'></a>

## Convert\.ToLaya\_JsonObject\(this LayaRequest\) Method

Converts a request into the line predict\.py reads from requests\.jsonl\.

The line is Laya's request shape plus the fields predict.py needs to batch and match it: `{"id": …, "state": …, "questions": {name: definition}, "max_len": …, "head_max_len": …}`. `questions` is an object keyed by [Name](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion.Name 'DiGi\.Laya\.Classes\.LayaQuestion\.Name') in question order, each definition from [ToLaya\_JsonObject\(this LayaQuestion\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaQuestion) 'DiGi\.Laya\.Convert\.ToLaya\_JsonObject\(this DiGi\.Laya\.Classes\.LayaQuestion\)'); the state comes from [ToLaya\_JsonNode\(this string, bool\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonNode(thisstring,bool) 'DiGi\.Laya\.Convert\.ToLaya\_JsonNode\(this string, bool\)'); `max_len` and `head_max_len` are written only when set, so predict.py falls back to the checkpoint's own budgets.

This method and [ToDiGi\_LayaResponse\(this JsonObject\)](DiGi.Laya.md#DiGi.Laya.Convert.ToDiGi_LayaResponse(thisSystem.Text.Json.Nodes.JsonObject) 'DiGi\.Laya\.Convert\.ToDiGi\_LayaResponse\(this System\.Text\.Json\.Nodes\.JsonObject\)') are, with [ToLaya\_TrainingLine\(this LayaTrainingSample\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_TrainingLine(thisDiGi.Laya.Classes.LayaTrainingSample) 'DiGi\.Laya\.Convert\.ToLaya\_TrainingLine\(this DiGi\.Laya\.Classes\.LayaTrainingSample\)'), the only code that knows Laya's JSON.

```csharp
public static System.Text.Json.Nodes.JsonObject? ToLaya_JsonObject(this DiGi.Laya.Classes.LayaRequest? layaRequest);
```
#### Parameters

<a name='DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaRequest).layaRequest'></a>

`layaRequest` [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')

The request to convert\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The request line, or `null` when the request is `null`, has no usable state or no questions, holds a question [ToLaya\_JsonObject\(this LayaQuestion\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaQuestion) 'DiGi\.Laya\.Convert\.ToLaya\_JsonObject\(this DiGi\.Laya\.Classes\.LayaQuestion\)') refuses, or names two questions alike\.

<a name='DiGi.Laya.Convert.ToLaya_TrainConfiguration(thisDiGi.Laya.Classes.LayaTrainingOptions)'></a>

## Convert\.ToLaya\_TrainConfiguration\(this LayaTrainingOptions\) Method

Converts training options into the JSON object of laya\.train\.TrainConfig fields train\.py reads with \-\-config\.

Only the settings that are set are written, under laya 0.4.7's field names, so every other field keeps laya's default: epochs, micro_batch, grad_accum, encoder_lr, head_lr, loss ("rlcd" or "soft-ce"), shuffle_options (["choice"]), option_layout ("sequential" or "parallel"), freeze_encoder (only when true), label_smoothing, calib_max, calib_frac, calib_seed, seed, max_len, head_max_len, target_error and eval_data (the evaluation file as a full path). Numbers are written by [System\.Text\.Json\.Nodes\.JsonValue](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonvalue 'System\.Text\.Json\.Nodes\.JsonValue'), so the current culture plays no part. The paths of the base checkpoint, the data and the output are command-line arguments of train.py, not TrainConfig fields.

```csharp
public static System.Text.Json.Nodes.JsonObject? ToLaya_TrainConfiguration(this DiGi.Laya.Classes.LayaTrainingOptions? layaTrainingOptions);
```
#### Parameters

<a name='DiGi.Laya.Convert.ToLaya_TrainConfiguration(thisDiGi.Laya.Classes.LayaTrainingOptions).layaTrainingOptions'></a>

`layaTrainingOptions` [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions')

The options to convert\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The TrainConfig fields, or `null` when the options are `null`\.

<a name='DiGi.Laya.Convert.ToLaya_TrainingLine(thisDiGi.Laya.Classes.LayaTrainingSample)'></a>

## Convert\.ToLaya\_TrainingLine\(this LayaTrainingSample\) Method

Converts a training sample into one line of the JSONL file `laya.train.finetune` reads\.

The line is the request shape plus the target Laya's `items_from_rows` reads: `{"id": …, "state": …, "questions": {name: definition}, "expected": {name: answer}}`, or `"gold": {name: {"probabilities": {"false": 1 - p, "true": p}}}` for a noul soft target. The expected answer is the label of a choice question, the zero-based level of a score question (a fractional level is written as is and split by Laya between its neighbours), and `true`/`false` for a noul question. Laya ignores `id`; it is written for tracing a line back to its sample.

Numbers are written by [System\.Text\.Json\.Nodes\.JsonValue](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonvalue 'System\.Text\.Json\.Nodes\.JsonValue'), never through [System\.Object\.ToString](https://learn.microsoft.com/en-us/dotnet/api/system.object.tostring 'System\.Object\.ToString'), so the line does not depend on the current culture. Non-ASCII text is escaped, which JSON readers decode.

```csharp
public static string? ToLaya_TrainingLine(this DiGi.Laya.Classes.LayaTrainingSample? layaTrainingSample);
```
#### Parameters

<a name='DiGi.Laya.Convert.ToLaya_TrainingLine(thisDiGi.Laya.Classes.LayaTrainingSample).layaTrainingSample'></a>

`layaTrainingSample` [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample')

The sample to convert\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The JSONL line without a line terminator, or `null` when the sample is `null`, its state or question is refused by [ToLaya\_JsonNode\(this string, bool\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonNode(thisstring,bool) 'DiGi\.Laya\.Convert\.ToLaya\_JsonNode\(this string, bool\)') or [ToLaya\_JsonObject\(this LayaQuestion\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaQuestion) 'DiGi\.Laya\.Convert\.ToLaya\_JsonObject\(this DiGi\.Laya\.Classes\.LayaQuestion\)'), or its target does not fit the question: a choice label that is not one of the criteria, a score level outside the levels or not finite, a noul question with neither a truth nor a probability between 0 and 1, or a probability on a question that is not a noul question\.

<a name='DiGi.Laya.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice)'></a>

## Create\.LayaPredictionOptions\(string, string, string, LayaDevice\) Method

Creates the settings of a Laya prediction run with the interpreter and the checkpoint directory resolved\.

The interpreter is resolved by [LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)') (a `null` path searches PATH) and the checkpoint by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)'), the same way the preflight and the run resolve them, so options made here name the files those will use. The constructors of [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions') do neither.

```csharp
public static DiGi.Laya.Classes.LayaPredictionOptions? LayaPredictionOptions(string? pythonPath, string? modelPath, string? workingDirectory=null, DiGi.Laya.Enums.LayaDevice layaDevice=DiGi.Laya.Enums.LayaDevice.Auto);
```
#### Parameters

<a name='DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CPython interpreter, the name of one on PATH, or `null` to search PATH\.

<a name='DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The checkpoint directory\.

<a name='DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The working directory of the run, or `null` for a temporary one\.

<a name='DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice).layaDevice'></a>

`layaDevice` [LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

The device the model runs on\.

#### Returns
[LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')  
The settings, or `null` when no interpreter is found or [modelPath](DiGi.Laya.md#DiGi.Laya.Create.LayaPredictionOptions(string,string,string,DiGi.Laya.Enums.LayaDevice).modelPath 'DiGi\.Laya\.Create\.LayaPredictionOptions\(string, string, string, DiGi\.Laya\.Enums\.LayaDevice\)\.modelPath') is not a checkpoint directory\.

<a name='DiGi.Laya.Create.LayaQuestions(DiGi.Laya.Classes.LayaLabelSet)'></a>

## Create\.LayaQuestions\(LayaLabelSet\) Method

Creates the questions the classification workflow asks about one label set\.

A single-choice set becomes one choice question named after the set, with the set's instructions and one option per label (the label id as the answer key, the label text as its description). Each label of a multi-label set becomes one noul question named "<set id>:<label id>" ([LayaQuestionName\(string, string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaQuestionName(string,string) 'DiGi\.Laya\.Query\.LayaQuestionName\(string, string\)')) whose statement is the label's instructions, or else the set's, with every "{label}" replaced by the label text (the id when it has none).

Inference ([LayaRequests\(IEnumerable&lt;LayaItem&gt;, IEnumerable&lt;LayaLabelSet&gt;\)](DiGi.Laya.md#DiGi.Laya.Create.LayaRequests(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_) 'DiGi\.Laya\.Create\.LayaRequests\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>\)')) and training ([LayaTrainingSamples\(IEnumerable&lt;LayaItem&gt;, IEnumerable&lt;LayaLabelSet&gt;, IEnumerable&lt;LayaLabelAssignment&gt;, int\)](DiGi.Laya.md#DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int) 'DiGi\.Laya\.Create\.LayaTrainingSamples\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelAssignment\>, int\)')) both build their questions here, so a checkpoint is fine-tuned on exactly the questions it is later asked. Nothing is validated; `null` labels are skipped.

```csharp
public static System.Collections.Generic.List<DiGi.Laya.Classes.LayaQuestion> LayaQuestions(DiGi.Laya.Classes.LayaLabelSet? layaLabelSet);
```
#### Parameters

<a name='DiGi.Laya.Create.LayaQuestions(DiGi.Laya.Classes.LayaLabelSet).layaLabelSet'></a>

`layaLabelSet` [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')

The label set\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The questions in label order; empty when the set is `null` or has no labels\.

<a name='DiGi.Laya.Create.LayaRequests(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_)'></a>

## Create\.LayaRequests\(IEnumerable\<LayaItem\>, IEnumerable\<LayaLabelSet\>\) Method

Creates one Laya request per item that asks every label set about the item's state\.

The questions of each set come from [LayaQuestions\(LayaLabelSet\)](DiGi.Laya.md#DiGi.Laya.Create.LayaQuestions(DiGi.Laya.Classes.LayaLabelSet) 'DiGi\.Laya\.Create\.LayaQuestions\(DiGi\.Laya\.Classes\.LayaLabelSet\)'): a single-choice set is one choice question named after the set, each label of a multi-label set one noul question named "<set id>:<label id>". Every request carries the same questions in set order, so predict.py answers all items in one group.

Pure and permissive: `null` items, sets and labels and sets without labels are skipped, and nothing is validated - a request the converter would refuse is reported by [PredictAsync\(this IEnumerable&lt;LayaRequest&gt;, LayaPredictionOptions, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken) 'DiGi\.Laya\.Modify\.PredictAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaRequest\>, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Threading\.CancellationToken\)'), and [ClassifyAsync\(this IEnumerable&lt;LayaItem&gt;, IEnumerable&lt;LayaLabelSet&gt;, LayaClassificationOptions, LayaPredictionOptions, IEnumerable&lt;LayaLabelConstraint&gt;, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken) 'DiGi\.Laya\.Modify\.ClassifyAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>, DiGi\.Laya\.Classes\.LayaClassificationOptions, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelConstraint\>, System\.Threading\.CancellationToken\)') checks the label sets before it calls this. The token budgets are left to the prediction options.

```csharp
public static System.Collections.Generic.List<DiGi.Laya.Classes.LayaRequest> LayaRequests(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaItem>? layaItems, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelSet>? layaLabelSets);
```
#### Parameters

<a name='DiGi.Laya.Create.LayaRequests(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_).layaItems'></a>

`layaItems` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The items to classify\.

<a name='DiGi.Laya.Create.LayaRequests(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_).layaLabelSets'></a>

`layaLabelSets` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The label sets to ask about each item\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The requests, one per item in item order; empty when either argument is `null`\.

<a name='DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int)'></a>

## Create\.LayaTrainingSamples\(IEnumerable\<LayaItem\>, IEnumerable\<LayaLabelSet\>, IEnumerable\<LayaLabelAssignment\>, int\) Method

Creates the training samples that teach Laya the known labels of items, asked exactly as the classification workflow asks them\.

The questions come from [LayaQuestions\(LayaLabelSet\)](DiGi.Laya.md#DiGi.Laya.Create.LayaQuestions(DiGi.Laya.Classes.LayaLabelSet) 'DiGi\.Laya\.Create\.LayaQuestions\(DiGi\.Laya\.Classes\.LayaLabelSet\)'). A single-choice set gives one choice sample per item with a true assignment in the set (the first in assignment order whose label is in the set), labelled with that label. A multi-label set gives one noul sample per assignment of one of its labels, labelled with the assignment's truth; only assigned labels are trained, so explicit negatives have to be assigned ([Truth](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment.Truth 'DiGi\.Laya\.Classes\.LayaLabelAssignment\.Truth')`false`), typically with a weight below 1.

Laya has no per-sample weight (DiGi-Organization/DiGi.Laya#1, D1). A noul assignment with a weight w below 1 becomes the soft target P(true) = 0.5 + 0.5 w for a true one and 0.5 - 0.5 w for a false one in [Probability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample.Probability 'DiGi\.Laya\.Classes\.LayaTrainingSample\.Probability'); a weight of 1 or more is a hard label. A single-choice sample has no soft form here and takes its label whatever the weight. An assignment with a weight of 0 or less carries no information and gives no sample. Assignments of unknown items, sets or labels are skipped.

Each sample is id'd "<item id>|<question name>", carries its assignment's group, and the list is shuffled with [System\.Random](https://learn.microsoft.com/en-us/dotnet/api/system.random 'System\.Random') seeded with [seed](DiGi.Laya.md#DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int).seed 'DiGi\.Laya\.Create\.LayaTrainingSamples\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelAssignment\>, int\)\.seed') after being built in item, set and label order, so the same inputs and seed always give the same file.

```csharp
public static System.Collections.Generic.List<DiGi.Laya.Classes.LayaTrainingSample> LayaTrainingSamples(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaItem>? layaItems, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelSet>? layaLabelSets, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelAssignment>? layaLabelAssignments, int seed);
```
#### Parameters

<a name='DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int).layaItems'></a>

`layaItems` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The items whose states the samples carry\.

<a name='DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int).layaLabelSets'></a>

`layaLabelSets` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The label sets asked\.

<a name='DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int).layaLabelAssignments'></a>

`layaLabelAssignments` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The known labels\.

<a name='DiGi.Laya.Create.LayaTrainingSamples(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int).seed'></a>

`seed` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The seed of the shuffle\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The samples; empty when any argument is `null`\.

<a name='DiGi.Laya.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.Laya.Modify.ApplyConstraints(thisDiGi.Laya.Classes.LayaClassificationResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_)'></a>

## Modify\.ApplyConstraints\(this LayaClassificationResult, IEnumerable\<LayaLabelConstraint\>\) Method

Applies the constraints of an item to its classification result\.

A [Forbid](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaConstraintEffect.Forbid 'DiGi\.Laya\.Enums\.LayaConstraintEffect\.Forbid') constraint whose item, label set and label match a score replaces that score with one that is forbidden, not suggested, carries the constraint's reason and keeps its probability, so the model's view stays visible beside the rule that overrode it. The first constraint on a label wins; a label already forbidden keeps its reason. Constraints of other items, and those naming a label the result has no score for, are ignored.

Forbidding a suggested label of a single-choice set does not promote the next label: the set then has one suggestion fewer, which is the honest answer when the most probable label is ruled out from outside the model.

```csharp
public static bool ApplyConstraints(this DiGi.Laya.Classes.LayaClassificationResult? layaClassificationResult, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelConstraint>? layaLabelConstraints);
```
#### Parameters

<a name='DiGi.Laya.Modify.ApplyConstraints(thisDiGi.Laya.Classes.LayaClassificationResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_).layaClassificationResult'></a>

`layaClassificationResult` [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')

The result to change\.

<a name='DiGi.Laya.Modify.ApplyConstraints(thisDiGi.Laya.Classes.LayaClassificationResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_).layaLabelConstraints'></a>

`layaLabelConstraints` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The constraints to apply; any item's may be passed\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when at least one score was forbidden; otherwise `false`\.

<a name='DiGi.Laya.Modify.CalibrateAsync(thisDiGi.Laya.Classes.LayaCalibrationOptions,System.Threading.CancellationToken)'></a>

## Modify\.CalibrateAsync\(this LayaCalibrationOptions, CancellationToken\) Method

Fits calibration temperatures for an existing Laya checkpoint in one CPython run of calibrate\.py and writes them to a calibration file outside the checkpoint\.

Refused before a process starts, with the reason in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult.Messages 'DiGi\.Laya\.Classes\.LayaCalibrationResult\.Messages'): an interpreter or checkpoint that does not resolve ([LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)'), [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)')), a labelled file that does not exist, no calibration path, or one inside the checkpoint directory - writing there would change the checkpoint's SHA-256, which is its identity (DiGi-Organization/DiGi.Laya#1, D3).

A file already at the calibration path is deleted before the run, so a failed run can never leave an older calibration that looks like this one's. calibrate.py runs once, offline, with the options' limits; laya fits one temperature per question type (clamped to [0.5, 5.0]) and, only for buckets of about 2500 records or more, scores the expected calibration error on a held-out fifth. Its report is read from between [CalibrateJsonBegin](DiGi.Laya.Constants.md#DiGi.Laya.Constants.Marker.CalibrateJsonBegin 'DiGi\.Laya\.Constants\.Marker\.CalibrateJsonBegin') and [CalibrateJsonEnd](DiGi.Laya.Constants.md#DiGi.Laya.Constants.Marker.CalibrateJsonEnd 'DiGi\.Laya\.Constants\.Marker\.CalibrateJsonEnd'). The calibration file is hashed into [CalibrationSHA256](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult.CalibrationSHA256 'DiGi\.Laya\.Classes\.LayaCalibrationResult\.CalibrationSHA256') when the run exited with 0 and wrote it.

```csharp
public static System.Threading.Tasks.Task<DiGi.Laya.Classes.LayaCalibrationResult?> CalibrateAsync(this DiGi.Laya.Classes.LayaCalibrationOptions? layaCalibrationOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Laya.Modify.CalibrateAsync(thisDiGi.Laya.Classes.LayaCalibrationOptions,System.Threading.CancellationToken).layaCalibrationOptions'></a>

`layaCalibrationOptions` [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions')

The settings of the run\.

<a name='DiGi.Laya.Modify.CalibrateAsync(thisDiGi.Laya.Classes.LayaCalibrationOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the run, or `null` when the options are `null`\.

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken)'></a>

## Modify\.ClassifyAsync\(this IEnumerable\<LayaItem\>, IEnumerable\<LayaLabelSet\>, LayaClassificationOptions, LayaPredictionOptions, IEnumerable\<LayaLabelConstraint\>, CancellationToken\) Method

Classifies items against closed label sets with a local Laya checkpoint: requests, one prediction run, scores and suggestions, then constraints\.

The label sets are checked first, and a set Laya cannot be asked refuses the whole run before a process starts: a blank, repeated or colon-holding set id; a set without labels; a blank or repeated label id; a multi-label label without a statement (its own instructions or the set's); a single-choice set with more than 100 labels, which Laya refuses. Every item then gets a result with no scores and the reasons. A single-choice set with more than 20 labels is run, with a warning on every result, because Laya's accuracy drops sharply past that.

Otherwise the requests of [LayaRequests\(IEnumerable&lt;LayaItem&gt;, IEnumerable&lt;LayaLabelSet&gt;\)](DiGi.Laya.md#DiGi.Laya.Create.LayaRequests(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_) 'DiGi\.Laya\.Create\.LayaRequests\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>\)') are answered by one [PredictAsync\(this IEnumerable&lt;LayaRequest&gt;, LayaPredictionOptions, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken) 'DiGi\.Laya\.Modify\.PredictAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaRequest\>, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Threading\.CancellationToken\)'), scored by [LayaClassificationResults\(LayaPredictionResult, IEnumerable&lt;LayaLabelSet&gt;, LayaClassificationOptions\)](DiGi.Laya.md#DiGi.Laya.Query.LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions) 'DiGi\.Laya\.Query\.LayaClassificationResults\(DiGi\.Laya\.Classes\.LayaPredictionResult, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>, DiGi\.Laya\.Classes\.LayaClassificationOptions\)'), and constrained by [ApplyConstraints\(this LayaClassificationResult, IEnumerable&lt;LayaLabelConstraint&gt;\)](DiGi.Laya.md#DiGi.Laya.Modify.ApplyConstraints(thisDiGi.Laya.Classes.LayaClassificationResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_) 'DiGi\.Laya\.Modify\.ApplyConstraints\(this DiGi\.Laya\.Classes\.LayaClassificationResult, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelConstraint\>\)'). An item without a response still gets a result, with no scores and the prediction run's reasons: the run's messages that name the item (PredictAsync quotes a request id as its first quoted text) and those that name no item of the run. When the run was refused before a process started, every message concerns every item.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<DiGi.Laya.Classes.LayaClassificationResult>?> ClassifyAsync(this System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaItem>? layaItems, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelSet>? layaLabelSets, DiGi.Laya.Classes.LayaClassificationOptions? layaClassificationOptions, DiGi.Laya.Classes.LayaPredictionOptions? layaPredictionOptions, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelConstraint>? layaLabelConstraints=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken).layaItems'></a>

`layaItems` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The items to classify\.

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken).layaLabelSets'></a>

`layaLabelSets` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The label sets to decide for each item\.

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken).layaClassificationOptions'></a>

`layaClassificationOptions` [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions')

The decision rules, or `null` for the defaults\.

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken).layaPredictionOptions'></a>

`layaPredictionOptions` [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')

The interpreter, checkpoint, device, working directory and limits of the run\.

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken).layaLabelConstraints'></a>

`layaLabelConstraints` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The constraints to apply to the results, or `null` for none\.

<a name='DiGi.Laya.Modify.ClassifyAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions,DiGi.Laya.Classes.LayaPredictionOptions,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
One result per item in item order, or `null` when the items, the label sets or the prediction options are `null`\.

<a name='DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken)'></a>

## Modify\.PredictAsync\(this IEnumerable\<LayaRequest\>, LayaPredictionOptions, CancellationToken\) Method

Answers Laya requests with a local checkpoint in one CPython run of predict\.py and reads the responses back\.

Each request is written as one line of requests.jsonl by [ToLaya\_JsonObject\(this LayaRequest\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_JsonObject(thisDiGi.Laya.Classes.LayaRequest) 'DiGi\.Laya\.Convert\.ToLaya\_JsonObject\(this DiGi\.Laya\.Classes\.LayaRequest\)'), with the options' token budgets filled in where the request sets none. The scripts are rewritten into the working directory on every run, a responses.jsonl left by an earlier run is deleted before the process starts so it can never be read as this run's answer, and predict.py runs once, offline, through [PythonProcessResult\(string, string, string, Nullable&lt;TimeSpan&gt;, Nullable&lt;TimeSpan&gt;, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken) 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)') with the options' inactivity and overall limits. Responses are read with [ToDiGi\_LayaResponse\(this JsonObject\)](DiGi.Laya.md#DiGi.Laya.Convert.ToDiGi_LayaResponse(thisSystem.Text.Json.Nodes.JsonObject) 'DiGi\.Laya\.Convert\.ToDiGi\_LayaResponse\(this System\.Text\.Json\.Nodes\.JsonObject\)') and matched to the requests by [Id](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest.Id 'DiGi\.Laya\.Classes\.LayaRequest\.Id').

Nothing is reported by an exception. A request that cannot be written (no id, no usable state, no questions, a question Laya would refuse) is left out and named in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Messages 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Messages'), and the others still run; a request laya refuses, gets no response, misses an answer or was truncated to fit the token budget is named there too. Ids used twice, an interpreter or checkpoint that does not resolve ([LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)'); a model name or Hub id is refused, never downloaded) or a calibration file that does not exist refuse the whole run before a process starts. No requests at all is answered with an empty result without starting one.

The process runs on a worker thread, so awaiting this does not block the caller. Cancelling, the overall limit and the inactivity limit each end the interpreter together with every process it started, and are told apart by [Cancelled](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Cancelled 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Cancelled'), [TimedOut](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.TimedOut 'DiGi\.Laya\.Classes\.LayaPredictionResult\.TimedOut') and [Stalled](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult.Stalled 'DiGi\.Laya\.Classes\.LayaPredictionResult\.Stalled'). Without a working directory a temporary one is used and removed afterwards.

```csharp
public static System.Threading.Tasks.Task<DiGi.Laya.Classes.LayaPredictionResult?> PredictAsync(this System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaRequest>? layaRequests, DiGi.Laya.Classes.LayaPredictionOptions? layaPredictionOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).layaRequests'></a>

`layaRequests` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The requests to answer\.

<a name='DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).layaPredictionOptions'></a>

`layaPredictionOptions` [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')

The interpreter, checkpoint, device, working directory and limits of the run\.

<a name='DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the run, or `null` when [layaRequests](DiGi.Laya.md#DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).layaRequests 'DiGi\.Laya\.Modify\.PredictAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaRequest\>, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Threading\.CancellationToken\)\.layaRequests') or [layaPredictionOptions](DiGi.Laya.md#DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).layaPredictionOptions 'DiGi\.Laya\.Modify\.PredictAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaRequest\>, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Threading\.CancellationToken\)\.layaPredictionOptions') is `null`\.

<a name='DiGi.Laya.Modify.TrainAsync(thisDiGi.Laya.Classes.LayaTrainingOptions,System.Threading.CancellationToken)'></a>

## Modify\.TrainAsync\(this LayaTrainingOptions, CancellationToken\) Method

Fine\-tunes a local Laya checkpoint on a training JSONL in one CPython run of train\.py \(laya\.train\.finetune\) and reports the new checkpoint\.

Refused before a process starts, with the reason in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult.Messages 'DiGi\.Laya\.Classes\.LayaTrainingResult\.Messages'): an interpreter that does not resolve ([LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)')); a base that is not a checkpoint directory ([LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)'); a model name or Hub id is never downloaded); a training or evaluation file that does not exist; no output directory, or one that is inside a Laya\models or DiGi.Laya\models folder ([IsInsideModelsDirectory\(string\)](DiGi.Laya.md#DiGi.Laya.Query.IsInsideModelsDirectory(string) 'DiGi\.Laya\.Query\.IsInsideModelsDirectory\(string\)') - training never writes where deployed checkpoints live), not empty, or the base checkpoint or inside it.

The scripts and train_config.json ([ToLaya\_TrainConfiguration\(this LayaTrainingOptions\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_TrainConfiguration(thisDiGi.Laya.Classes.LayaTrainingOptions) 'DiGi\.Laya\.Convert\.ToLaya\_TrainConfiguration\(this DiGi\.Laya\.Classes\.LayaTrainingOptions\)')) are written to the working directory, the base checkpoint is hashed, and train.py runs once, offline, with the options' limits ([PythonProcessResult\(string, string, string, Nullable&lt;TimeSpan&gt;, Nullable&lt;TimeSpan&gt;, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken) 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)')). finetune holds out the calibration slice and writes the fitted temperatures into the new checkpoint; train.py removes the checkpoint_latest copy and prints its report between [TrainJsonBegin](DiGi.Laya.Constants.md#DiGi.Laya.Constants.Marker.TrainJsonBegin 'DiGi\.Laya\.Constants\.Marker\.TrainJsonBegin') and [TrainJsonEnd](DiGi.Laya.Constants.md#DiGi.Laya.Constants.Marker.TrainJsonEnd 'DiGi\.Laya\.Constants\.Marker\.TrainJsonEnd').

The new checkpoint is trusted - and only then hashed into [ModelSHA256](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult.ModelSHA256 'DiGi\.Laya\.Classes\.LayaTrainingResult\.ModelSHA256') - when train.py exited with 0, its report was read, and the output directory holds rl_agent_config.json and model.safetensors (DiGi-Organization/DiGi.Laya#1, D5). The run is on a worker thread; cancelling, the overall limit and the inactivity limit end it and are told apart in the result. Without a working directory a temporary one is used and removed afterwards; the output directory is never removed.

```csharp
public static System.Threading.Tasks.Task<DiGi.Laya.Classes.LayaTrainingResult?> TrainAsync(this DiGi.Laya.Classes.LayaTrainingOptions? layaTrainingOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Laya.Modify.TrainAsync(thisDiGi.Laya.Classes.LayaTrainingOptions,System.Threading.CancellationToken).layaTrainingOptions'></a>

`layaTrainingOptions` [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions')

The settings of the run\.

<a name='DiGi.Laya.Modify.TrainAsync(thisDiGi.Laya.Classes.LayaTrainingOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the run, or `null` when the options are `null`\.

<a name='DiGi.Laya.Modify.WriteScripts(string)'></a>

## Modify\.WriteScripts\(string\) Method

Writes every Laya script and requirements\.txt into a directory, so that any one of them can be run from there\.

Taken from the Laya folder beside the DiGi.Laya assembly when it is there - a script edited in a build output is then tried without rebuilding - and otherwise from the resources embedded in the assembly, so it works in a host that never copied the folder. Every file is rewritten on every call: a working directory outlives builds, and a script of an older build handed an argument it does not know would fail.

All files are written together because each script imports utils.py, which Python resolves against the script's own directory, and check.py reads the laya pin from requirements.txt beside it.

```csharp
public static bool WriteScripts(string? directory);
```
#### Parameters

<a name='DiGi.Laya.Modify.WriteScripts(string).directory'></a>

`directory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory to write the files into, created when missing\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when every file was written; otherwise `false`\.

<a name='DiGi.Laya.Modify.WriteTrainingFile(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTrainingSample_,string)'></a>

## Modify\.WriteTrainingFile\(this IEnumerable\<LayaTrainingSample\>, string\) Method

Writes training samples to the JSONL file laya\.train\.finetune reads, one [ToLaya\_TrainingLine\(this LayaTrainingSample\)](DiGi.Laya.md#DiGi.Laya.Convert.ToLaya_TrainingLine(thisDiGi.Laya.Classes.LayaTrainingSample) 'DiGi\.Laya\.Convert\.ToLaya\_TrainingLine\(this DiGi\.Laya\.Classes\.LayaTrainingSample\)') line per sample\.

The file is UTF-8 without a byte order mark, with "\n" line ends, written through a temporary file beside it so a failed write never leaves a partial file at [path](DiGi.Laya.md#DiGi.Laya.Modify.WriteTrainingFile(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTrainingSample_,string).path 'DiGi\.Laya\.Modify\.WriteTrainingFile\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaTrainingSample\>, string\)\.path'). A sample the converter refuses - a target that does not fit its question, no state, no question - is left out; compare the count returned with the number of samples to notice it. Training data belongs in a training directory outside the workspace, never in user files, which ships with every build.

```csharp
public static System.Nullable<int> WriteTrainingFile(this System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaTrainingSample>? layaTrainingSamples, string? path);
```
#### Parameters

<a name='DiGi.Laya.Modify.WriteTrainingFile(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTrainingSample_,string).layaTrainingSamples'></a>

`layaTrainingSamples` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The samples to write\.

<a name='DiGi.Laya.Modify.WriteTrainingFile(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaTrainingSample_,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the JSONL file, created or replaced; its directory is created when missing\.

#### Returns
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')  
The number of lines written, or `null` when the samples or the path are `null` or the file could not be written\.

<a name='DiGi.Laya.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int)'></a>

## Query\.CalibrateArguments\(string, string, string, string, LayaDevice, int\) Method

Builds the command line calibrate\.py is run with: `"<script>" --model "<dir>" --data "<file>" --output "<file>" --device <device> --seed <n>`\.

Every path is quoted by [QuotedArgument\(string\)](DiGi.Laya.md#DiGi.Laya.Query.QuotedArgument(string) 'DiGi\.Laya\.Query\.QuotedArgument\(string\)'); the seed is written with [System\.Globalization\.CultureInfo\.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System\.Globalization\.CultureInfo\.InvariantCulture'); the device is written lower-case as the scripts expect.

```csharp
public static string? CalibrateArguments(string? scriptPath, string? modelPath, string? calibrationFilePath, string? calibrationPath, DiGi.Laya.Enums.LayaDevice layaDevice, int seed);
```
#### Parameters

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int).scriptPath'></a>

`scriptPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of calibrate\.py\.

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The checkpoint directory, already resolved by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)')\.

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int).calibrationFilePath'></a>

`calibrationFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The labelled JSONL the temperatures are fitted on\.

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int).calibrationPath'></a>

`calibrationPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The calibration JSON to write\.

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int).layaDevice'></a>

`layaDevice` [LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

The device to run on\.

<a name='DiGi.Laya.Query.CalibrateArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int).seed'></a>

`seed` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The seed of laya's held\-out split\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The command line, or `null` when a path is blank\.

<a name='DiGi.Laya.Query.IsInsideModelsDirectory(string)'></a>

## Query\.IsInsideModelsDirectory\(string\) Method

Checks whether a path is a Laya\\models or DiGi\.Laya\\models folder, or lies anywhere inside one \- where deployed checkpoints live, which no training run may write into\.

The path is made absolute first and compared with a trailing separator, case-insensitively, so "...\Laya\models" itself and "...\laya\MODELS\run" both count while a sibling such as "...\Laya\models_old" does not. Both folder names are guarded: Laya\models ([Laya](DiGi.Laya.Constants.md#DiGi.Laya.Constants.DirectoryName.Laya 'DiGi\.Laya\.Constants\.DirectoryName\.Laya')) and DiGi.Laya\models ([DiGiLaya](DiGi.Laya.Constants.md#DiGi.Laya.Constants.DirectoryName.DiGiLaya 'DiGi\.Laya\.Constants\.DirectoryName\.DiGiLaya')), the software destination DiGi.Maintenance's DeployLaya.ps1 deploys checkpoints to - a match on the Laya segment alone misses the latter, whose "Laya" follows a dot rather than a separator. The same guard as DiGi.YOLO's for YOLO\models: a training output written where a deploy reads ships an untested checkpoint.

A relative path is resolved against the current directory of the calling process. A null, blank or unformable path returns `false`: it names no folder, and every caller refuses such a path for its own reason.

```csharp
public static bool IsInsideModelsDirectory(string? path);
```
#### Parameters

<a name='DiGi.Laya.Query.IsInsideModelsDirectory(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory path to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` when the path is, or lies inside, a Laya\\models or DiGi\.Laya\\models folder; otherwise `false`\.

<a name='DiGi.Laya.Query.LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions)'></a>

## Query\.LayaClassificationResults\(LayaPredictionResult, IEnumerable\<LayaLabelSet\>, LayaClassificationOptions\) Method

Turns the responses of a prediction run into one classification result per response: a score per label and which labels are suggested\.

Pure C#. The answers are found by [LayaQuestionName\(string, string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaQuestionName(string,string) 'DiGi\.Laya\.Query\.LayaQuestionName\(string, string\)'). A single-choice set scores every label with its option probability and suggests the [TopCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.TopCount 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.TopCount') most probable (1 by default; ties go to the earlier label). A multi-label set scores every label with the probability its noul statement is true and suggests each label at or above [Threshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold.Threshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold\.Threshold') (0.5 by default). An answer whose [Confidence](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer.Confidence 'DiGi\.Laya\.Classes\.LayaAnswer\.Confidence') is below [MinimumConfidence](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions.MinimumConfidence 'DiGi\.Laya\.Classes\.LayaClassificationOptions\.MinimumConfidence'), or that reports none while a floor is set, suggests nothing but keeps its scores.

A label set or label without an answer, a label missing from a choice answer, and a request Laya truncated are named in [Messages](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult.Messages 'DiGi\.Laya\.Classes\.LayaClassificationResult\.Messages'); the scores that could be read are kept. No constraint is applied here - see [ApplyConstraints\(this LayaClassificationResult, IEnumerable&lt;LayaLabelConstraint&gt;\)](DiGi.Laya.md#DiGi.Laya.Modify.ApplyConstraints(thisDiGi.Laya.Classes.LayaClassificationResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelConstraint_) 'DiGi\.Laya\.Modify\.ApplyConstraints\(this DiGi\.Laya\.Classes\.LayaClassificationResult, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelConstraint\>\)').

```csharp
public static System.Collections.Generic.List<DiGi.Laya.Classes.LayaClassificationResult> LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult? layaPredictionResult, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelSet>? layaLabelSets, DiGi.Laya.Classes.LayaClassificationOptions? layaClassificationOptions);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions).layaPredictionResult'></a>

`layaPredictionResult` [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult')

The prediction run whose responses are read\.

<a name='DiGi.Laya.Query.LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions).layaLabelSets'></a>

`layaLabelSets` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The label sets the requests asked\.

<a name='DiGi.Laya.Query.LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions).layaClassificationOptions'></a>

`layaClassificationOptions` [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions')

The decision rules, or `null` for the defaults\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One result per response, in response order; empty when the prediction result or the label sets are `null`\.

<a name='DiGi.Laya.Query.LayaEnvironmentResult(DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken)'></a>

## Query\.LayaEnvironmentResult\(LayaPredictionOptions, CancellationToken\) Method

Checks whether a machine can run the Laya scripts with the interpreter and checkpoint of a set of prediction options, without ever throwing\.

The interpreter is resolved by [LayaPythonPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaPythonPath(string) 'DiGi\.Laya\.Query\.LayaPythonPath\(string\)') and the checkpoint by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)') - exactly as [PredictAsync\(this IEnumerable&lt;LayaRequest&gt;, LayaPredictionOptions, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Modify.PredictAsync(thisSystem.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaRequest_,DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken) 'DiGi\.Laya\.Modify\.PredictAsync\(this System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaRequest\>, DiGi\.Laya\.Classes\.LayaPredictionOptions, System\.Threading\.CancellationToken\)') resolves them - so the preflight never calls a checkpoint absent that the run would find, or the reverse. The scripts are written into the working directory and check.py is run offline ([PythonProcessResult\(string, string, string, Nullable&lt;TimeSpan&gt;, Nullable&lt;TimeSpan&gt;, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken) 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)')) with the options' device and limits; its payload is read from between [CheckJsonBegin](DiGi.Laya.Constants.md#DiGi.Laya.Constants.Marker.CheckJsonBegin 'DiGi\.Laya\.Constants\.Marker\.CheckJsonBegin') and [CheckJsonEnd](DiGi.Laya.Constants.md#DiGi.Laya.Constants.Marker.CheckJsonEnd 'DiGi\.Laya\.Constants\.Marker\.CheckJsonEnd').

The result is not runnable, with the reason in [DiGi\.Python\.Classes\.PythonEnvironmentResult\.Messages](https://learn.microsoft.com/en-us/dotnet/api/digi.python.classes.pythonenvironmentresult.messages 'DiGi\.Python\.Classes\.PythonEnvironmentResult\.Messages'), when: no interpreter is found; torch or laya does not import; laya is not the version requirements.txt pins; the checkpoint uses the parallel option layout under transformers older than 5; or a model path was given that is not a checkpoint directory or does not load. With no model path the interpreter alone is checked. The checkpoint directory is hashed whenever it resolved, so [ModelSHA256](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult.ModelSHA256 'DiGi\.Laya\.Classes\.LayaEnvironmentResult\.ModelSHA256') names the weights the check saw.

```csharp
public static DiGi.Laya.Classes.LayaEnvironmentResult LayaEnvironmentResult(DiGi.Laya.Classes.LayaPredictionOptions? layaPredictionOptions, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Laya.Query.LayaEnvironmentResult(DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).layaPredictionOptions'></a>

`layaPredictionOptions` [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')

The options naming the interpreter, the checkpoint, the device, the working directory and the limits; [WorkingDirectory](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions.WorkingDirectory 'DiGi\.Laya\.Classes\.LayaPredictionOptions\.WorkingDirectory')`null` uses DiGi\_Laya\_Preflight in the temporary folder\.

<a name='DiGi.Laya.Query.LayaEnvironmentResult(DiGi.Laya.Classes.LayaPredictionOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the check\.

#### Returns
[LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult')  
The preflight result\.

<a name='DiGi.Laya.Query.LayaEvaluationResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_)'></a>

## Query\.LayaEvaluationResult\(IEnumerable\<LayaLabelAssignment\>, IEnumerable\<LayaClassificationResult\>, IEnumerable\<LayaLabelSet\>\) Method

Measures how well classification results match known label assignments, label set by label set\.

A single-choice set evaluates every item that has a true assignment in the set (the first in assignment order is its label) and scores for the set. Labels are ranked by probability, the earlier label first on a tie: [Top1Accuracy](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation.Top1Accuracy 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation\.Top1Accuracy') and [Top3Accuracy](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation.Top3Accuracy 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation\.Top3Accuracy') count the true label at rank 1 and within ranks 1 to 3, and the per-label counts and the confusion rows take rank 1 as the prediction - the model's ranking, before constraints or thresholds. The expected calibration error bins the probability of rank 1 against whether it was right; the Brier score is the multi-class sum over the set's labels of (probability - truth) squared, a missing score counting as 0, averaged over items.

A multi-label set evaluates every item with at least one assignment in the set and scores for it, closed-world per item: a label without an assignment does not apply. The prediction is [IsSuggested](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore.IsSuggested 'DiGi\.Laya\.Classes\.LayaLabelScore\.IsSuggested') - the decision after the threshold and any constraint. The expected calibration error and the Brier score treat each label of each item as one binary forecast of its truth.

Both kinds: the calibration error uses 10 equal-width bins on [0, 1] and is the sum over bins of (bin size / count) times |mean outcome - mean probability|; [MacroF1](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation.MacroF1 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation\.MacroF1') is the mean F1 of the labels with a support above 0; [MicroF1](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation.MicroF1 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation\.MicroF1') is computed for multi-label sets only. Assignment weights play no part. An item's first result is used when it has several.

```csharp
public static DiGi.Laya.Classes.LayaEvaluationResult? LayaEvaluationResult(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelAssignment>? layaLabelAssignments, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaClassificationResult>? layaClassificationResults, System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelSet>? layaLabelSets);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaEvaluationResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_).layaLabelAssignments'></a>

`layaLabelAssignments` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The known labels\.

<a name='DiGi.Laya.Query.LayaEvaluationResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_).layaClassificationResults'></a>

`layaClassificationResults` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The classification results to measure\.

<a name='DiGi.Laya.Query.LayaEvaluationResult(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaClassificationResult_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_).layaLabelSets'></a>

`layaLabelSets` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The label sets to evaluate, in the order they are reported\.

#### Returns
[LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult')  
The evaluation, or `null` when any argument is `null`\.

<a name='DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int)'></a>

## Query\.LayaFolds\(IEnumerable\<LayaLabelAssignment\>, int, string, int\) Method

Splits the items of a set of label assignments into folds for cross\-validation: stratified by one label set, never splitting a group, and the same for the same seed\.

Items are gathered into units: the items sharing a [Group](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment.Group 'DiGi\.Laya\.Classes\.LayaLabelAssignment\.Group') (an item's first assignment that names one) form one unit, and every other item is a unit of its own, so a group always lands in one fold. A unit's stratum is the most frequent true label of its items in [stratifyLabelSetId](DiGi.Laya.md#DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).stratifyLabelSetId 'DiGi\.Laya\.Query\.LayaFolds\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelAssignment\>, int, string, int\)\.stratifyLabelSetId') (an item's first true assignment there; ties go to the ordinally first label), or no label. Units are sorted by key, the units of each stratum - strata in ordinal order - are shuffled with [System\.Random](https://learn.microsoft.com/en-us/dotnet/api/system.random 'System\.Random') seeded with [seed](DiGi.Laya.md#DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).seed 'DiGi\.Laya\.Query\.LayaFolds\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelAssignment\>, int, string, int\)\.seed'), and each unit goes to the fold with the fewest units of its stratum so far, then the fewest items, then the lowest index. The seeded [System\.Random](https://learn.microsoft.com/en-us/dotnet/api/system.random 'System\.Random') keeps its sequence across .NET versions, so the folds depend only on the assignments, their order and the seed.

```csharp
public static System.Collections.Generic.List<System.Collections.Generic.List<string>> LayaFolds(System.Collections.Generic.IEnumerable<DiGi.Laya.Classes.LayaLabelAssignment>? layaLabelAssignments, int foldCount, string? stratifyLabelSetId, int seed);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).layaLabelAssignments'></a>

`layaLabelAssignments` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The assignments whose items are split; an item is any [ItemId](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment.ItemId 'DiGi\.Laya\.Classes\.LayaLabelAssignment\.ItemId') they name\.

<a name='DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).foldCount'></a>

`foldCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of folds\.

<a name='DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).stratifyLabelSetId'></a>

`stratifyLabelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The label set whose true labels the folds are balanced on, or `null` for no stratification\.

<a name='DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).seed'></a>

`seed` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The seed of the shuffle\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The item ids of each fold, ordinally sorted within a fold; empty when there are no assignments or [foldCount](DiGi.Laya.md#DiGi.Laya.Query.LayaFolds(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelAssignment_,int,string,int).foldCount 'DiGi\.Laya\.Query\.LayaFolds\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelAssignment\>, int, string, int\)\.foldCount') is below 1\.

<a name='DiGi.Laya.Query.LayaModelPath(string)'></a>

## Query\.LayaModelPath\(string\) Method

Resolves a configured Laya checkpoint directory to the absolute directory the scripts are given, the way the preflight and every run resolve it\.

The value is tried as given (a relative path against the current directory), then against the application base directory, then - for a value starting with "user files" - with that segment stripped, against the base directory and the current directory, since CopyUserFiles flattens user files into bin; any other relative value is also tried under "user files" of the current directory. The first candidate that is a directory holding rl_agent_config.json wins.

No other value is accepted, deliberately: laya.load and laya.train.finetune treat a value that is not a checkpoint directory on disk as a model name or Hugging Face Hub id and download it, which a production run must never do (DiGi-Organization/DiGi.Laya#1, D4).

```csharp
public static string? LayaModelPath(string? modelPath);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaModelPath(string).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The configured checkpoint directory\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The absolute checkpoint directory without a trailing separator, or `null` when no candidate is a directory holding rl\_agent\_config\.json\.

<a name='DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool)'></a>

## Query\.LayaProcessMessages\(PythonProcessResult, string, Nullable\<TimeSpan\>, Nullable\<TimeSpan\>, bool\) Method

Describes how a script run through [PythonProcessResult\(string, string, string, Nullable&lt;TimeSpan&gt;, Nullable&lt;TimeSpan&gt;, CancellationToken\)](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken) 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)') ended, when it did not end well\.

One line for the first that applies - cancelled by the caller, ended by the overall time limit, ended for inactivity, a non-zero exit code - followed, for any non-zero exit code, by the last ten lines of standard error, where a Python traceback ends. A run that exited with 0 gives no messages.

```csharp
public static System.Collections.Generic.List<string> LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult? pythonProcessResult, string? scriptName, System.Nullable<System.TimeSpan> inactivityTimeout, System.Nullable<System.TimeSpan> timeout, bool cancelledByCaller);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool).pythonProcessResult'></a>

`pythonProcessResult` [DiGi\.Python\.Classes\.PythonProcessResult](https://learn.microsoft.com/en-us/dotnet/api/digi.python.classes.pythonprocessresult 'DiGi\.Python\.Classes\.PythonProcessResult')

The result of the run\.

<a name='DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool).scriptName'></a>

`scriptName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The script that was run, named in the exit code message\.

<a name='DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool).inactivityTimeout'></a>

`inactivityTimeout` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The inactivity limit of the run, named in its message\.

<a name='DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool).timeout'></a>

`timeout` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The overall limit of the run, named in its message\.

<a name='DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool).cancelledByCaller'></a>

`cancelledByCaller` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

A value indicating whether the caller's token was cancelled, which tells a cancellation from a timeout\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The messages; empty when the run exited with 0 or [pythonProcessResult](DiGi.Laya.md#DiGi.Laya.Query.LayaProcessMessages(DiGi.Python.Classes.PythonProcessResult,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,bool).pythonProcessResult 'DiGi\.Laya\.Query\.LayaProcessMessages\(DiGi\.Python\.Classes\.PythonProcessResult, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, bool\)\.pythonProcessResult') is `null`\.

<a name='DiGi.Laya.Query.LayaPythonPath(string)'></a>

## Query\.LayaPythonPath\(string\) Method

Resolves the configured CPython interpreter the Laya scripts run with, accepting only the interpreter that was configured\.

A blank value searches PATH for "python", then "python3", through DiGi.Python's `Query.PythonPath`. A path (rooted, or holding a directory separator) must name an existing file. A bare name is searched for on PATH and accepted only when the match carries that name.

DiGi.Python's `Query.PythonPath` falls back to any "python" on PATH when the given value is not found, which for a configured interpreter means a mistyped path silently runs a different Python - one that usually lacks laya, so the run fails on an import nothing on the command line explains. Laya options name a specific environment, so a value that does not resolve as given is refused instead.

```csharp
public static string? LayaPythonPath(string? pythonPath);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaPythonPath(string).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The configured interpreter: a path, a name on PATH, or `null` to search PATH\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The full path of the interpreter, or `null` when it was not found as configured\.

<a name='DiGi.Laya.Query.LayaQuestionName(string,string)'></a>

## Query\.LayaQuestionName\(string, string\) Method

Gets the name the classification workflow asks a label set, or one label of it, under\.

A single-choice set is one choice question named after the set; each label of a multi-label set is a noul question named "<set id>:<label id>". [LayaRequests\(IEnumerable&lt;LayaItem&gt;, IEnumerable&lt;LayaLabelSet&gt;\)](DiGi.Laya.md#DiGi.Laya.Create.LayaRequests(System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaItem_,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_) 'DiGi\.Laya\.Create\.LayaRequests\(System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaItem\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>\)') writes the questions under these names and [LayaClassificationResults\(LayaPredictionResult, IEnumerable&lt;LayaLabelSet&gt;, LayaClassificationOptions\)](DiGi.Laya.md#DiGi.Laya.Query.LayaClassificationResults(DiGi.Laya.Classes.LayaPredictionResult,System.Collections.Generic.IEnumerable_DiGi.Laya.Classes.LayaLabelSet_,DiGi.Laya.Classes.LayaClassificationOptions) 'DiGi\.Laya\.Query\.LayaClassificationResults\(DiGi\.Laya\.Classes\.LayaPredictionResult, System\.Collections\.Generic\.IEnumerable\<DiGi\.Laya\.Classes\.LayaLabelSet\>, DiGi\.Laya\.Classes\.LayaClassificationOptions\)') reads the answers back by them, so both sides share this one rule. A set id must not contain the colon, or two questions could share a name.

```csharp
public static string? LayaQuestionName(string? labelSetId, string? labelId);
```
#### Parameters

<a name='DiGi.Laya.Query.LayaQuestionName(string,string).labelSetId'></a>

`labelSetId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label set\.

<a name='DiGi.Laya.Query.LayaQuestionName(string,string).labelId'></a>

`labelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier of the label of a multi\-label set, or `null` for a single\-choice set\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The question name, or `null` when [labelSetId](DiGi.Laya.md#DiGi.Laya.Query.LayaQuestionName(string,string).labelSetId 'DiGi\.Laya\.Query\.LayaQuestionName\(string, string\)\.labelSetId') is `null`\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string)'></a>

## Query\.PredictArguments\(string, string, string, string, LayaDevice, int, string\) Method

Builds the command line predict\.py is run with: `"<script>" --model "<dir>" --input "<file>" --output "<file>" --device <device> --batch-size <n>`, followed by `--calibration "<file>"` when a calibration file is given\.

Every path is quoted by [QuotedArgument\(string\)](DiGi.Laya.md#DiGi.Laya.Query.QuotedArgument(string) 'DiGi\.Laya\.Query\.QuotedArgument\(string\)'); numbers are written with [System\.Globalization\.CultureInfo\.InvariantCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture 'System\.Globalization\.CultureInfo\.InvariantCulture'); the device is written lower-case as the scripts expect.

```csharp
public static string? PredictArguments(string? scriptPath, string? modelPath, string? inputPath, string? outputPath, DiGi.Laya.Enums.LayaDevice layaDevice, int batchSize, string? calibrationPath);
```
#### Parameters

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).scriptPath'></a>

`scriptPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of predict\.py\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).modelPath'></a>

`modelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The checkpoint directory, already resolved by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)')\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).inputPath'></a>

`inputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The requests JSONL file\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).outputPath'></a>

`outputPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The responses JSONL file to write\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).layaDevice'></a>

`layaDevice` [LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

The device to run on\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of states per forward pass\.

<a name='DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).calibrationPath'></a>

`calibrationPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The calibration JSON written by calibrate\.py, or `null` for the checkpoint's own temperatures\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The command line, or `null` when a path is blank or [batchSize](DiGi.Laya.md#DiGi.Laya.Query.PredictArguments(string,string,string,string,DiGi.Laya.Enums.LayaDevice,int,string).batchSize 'DiGi\.Laya\.Query\.PredictArguments\(string, string, string, string, DiGi\.Laya\.Enums\.LayaDevice, int, string\)\.batchSize') is not positive\.

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken)'></a>

## Query\.PythonProcessResult\(string, string, string, Nullable\<TimeSpan\>, Nullable\<TimeSpan\>, CancellationToken\) Method

Runs one Laya script in a CPython process, offline, with an optional inactivity limit and an optional overall time limit\.

The process gets HF_HUB_OFFLINE=1 and TRANSFORMERS_OFFLINE=1, so laya, transformers and huggingface_hub never download (DiGi-Organization/DiGi.Laya#1, D4); PYTHONIOENCODING=utf-8, matching the UTF-8 the output streams are decoded with; PYTHONUNBUFFERED=1, so progress lines reach the inactivity limit as they are printed rather than when a buffer fills; and PYTHONDONTWRITEBYTECODE=1, so no __pycache__ is left in the working directory.

DiGi.Python's `ExecuteProcess` has an inactivity limit and cancellation but no overall limit, so [timeout](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).timeout 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)\.timeout') is a token linked to [cancellationToken](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).cancellationToken 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)\.cancellationToken') that cancels after it. Either way the result has `Cancelled` set; the run timed out exactly when `Cancelled` is set and [cancellationToken](DiGi.Laya.md#DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).cancellationToken 'DiGi\.Laya\.Query\.PythonProcessResult\(string, string, string, System\.Nullable\<System\.TimeSpan\>, System\.Nullable\<System\.TimeSpan\>, System\.Threading\.CancellationToken\)\.cancellationToken') was not cancelled. Ending a run kills the interpreter together with every process it started.

```csharp
public static DiGi.Python.Classes.PythonProcessResult PythonProcessResult(string pythonPath, string arguments, string workingDirectory, System.Nullable<System.TimeSpan> inactivityTimeout, System.Nullable<System.TimeSpan> timeout, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).pythonPath'></a>

`pythonPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The full path of the interpreter\.

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).arguments'></a>

`arguments` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The command line: the quoted script path followed by its arguments\.

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).workingDirectory'></a>

`workingDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the process runs in\.

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).inactivityTimeout'></a>

`inactivityTimeout` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The span without output after which the process is ended, or `null` for no limit\.

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).timeout'></a>

`timeout` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The span after which the process is ended whatever it is doing, or `null` for no limit\. A value that is not positive is no limit either\.

<a name='DiGi.Laya.Query.PythonProcessResult(string,string,string,System.Nullable_System.TimeSpan_,System.Nullable_System.TimeSpan_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token that cancels the run\.

#### Returns
[DiGi\.Python\.Classes\.PythonProcessResult](https://learn.microsoft.com/en-us/dotnet/api/digi.python.classes.pythonprocessresult 'DiGi\.Python\.Classes\.PythonProcessResult')  
The exit code \(\-1 when the process was ended or failed to start\), the trailing lines of both output streams, and whether it was ended for inactivity or cancelled\.

<a name='DiGi.Laya.Query.QuotedArgument(string)'></a>

## Query\.QuotedArgument\(string\) Method

Quotes one command\-line argument for a script, so that a path with spaces stays one argument\.

A trailing backslash is doubled, since a backslash before the closing quote would escape it - a drive root such as D:\ would otherwise swallow the rest of the command line. Windows paths cannot contain a quote, so nothing else is escaped.

```csharp
public static string QuotedArgument(string? value);
```
#### Parameters

<a name='DiGi.Laya.Query.QuotedArgument(string).value'></a>

`value` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The argument\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The quoted argument; `""` for `null`\.

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice)'></a>

## Query\.TrainArguments\(string, string, string, string, string, LayaDevice\) Method

Builds the command line train\.py is run with: `"<script>" --base "<dir>" --data "<file>" --output "<dir>" --config "<file>" --device <device>`\.

Every path is quoted by [QuotedArgument\(string\)](DiGi.Laya.md#DiGi.Laya.Query.QuotedArgument(string) 'DiGi\.Laya\.Query\.QuotedArgument\(string\)'); the device is written lower-case as the scripts expect.

```csharp
public static string? TrainArguments(string? scriptPath, string? baseModelPath, string? trainingFilePath, string? outputDirectory, string? configurationPath, DiGi.Laya.Enums.LayaDevice layaDevice);
```
#### Parameters

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice).scriptPath'></a>

`scriptPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of train\.py\.

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice).baseModelPath'></a>

`baseModelPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The base checkpoint directory, already resolved by [LayaModelPath\(string\)](DiGi.Laya.md#DiGi.Laya.Query.LayaModelPath(string) 'DiGi\.Laya\.Query\.LayaModelPath\(string\)')\.

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice).trainingFilePath'></a>

`trainingFilePath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The training JSONL\.

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice).outputDirectory'></a>

`outputDirectory` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The directory the new checkpoint is written to\.

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice).configurationPath'></a>

`configurationPath` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The train\_config\.json of TrainConfig fields\.

<a name='DiGi.Laya.Query.TrainArguments(string,string,string,string,string,DiGi.Laya.Enums.LayaDevice).layaDevice'></a>

`layaDevice` [LayaDevice](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaDevice 'DiGi\.Laya\.Enums\.LayaDevice')

The device to train on\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The command line, or `null` when a path is blank\.