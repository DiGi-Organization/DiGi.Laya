#### [DiGi\.Laya](DiGi.Laya.Overview.md 'DiGi\.Laya\.Overview')

## DiGi\.Laya\.Interfaces Namespace
### Interfaces

<a name='DiGi.Laya.Interfaces.ILayaObject'></a>

## ILayaObject Interface

Marker interface implemented by every object belonging to the DiGi\.Laya domain\.

```csharp
public interface ILayaObject : DiGi.Core.Interfaces.IObject
```

Derived  
↳ [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer')  
↳ [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions')  
↳ [LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult')  
↳ [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions')  
↳ [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')  
↳ [LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow')  
↳ [LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion')  
↳ [LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult')  
↳ [LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult')  
↳ [LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem')  
↳ [LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel')  
↳ [LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment')  
↳ [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint')  
↳ [LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation')  
↳ [LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore')  
↳ [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')  
↳ [LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation')  
↳ [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold')  
↳ [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')  
↳ [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult')  
↳ [LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability')  
↳ [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')  
↳ [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')  
↳ [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')  
↳ [LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount')  
↳ [LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')  
↳ [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions')  
↳ [LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult')  
↳ [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample')  
↳ [ILayaSerializableObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaSerializableObject 'DiGi\.Laya\.Interfaces\.ILayaSerializableObject')

Implements [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.Laya.Interfaces.ILayaSerializableObject'></a>

## ILayaSerializableObject Interface

Marker interface implemented by every DiGi\.Laya object that can be serialized to and from JSON\.

```csharp
public interface ILayaSerializableObject : DiGi.Laya.Interfaces.ILayaObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [LayaAnswer](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaAnswer 'DiGi\.Laya\.Classes\.LayaAnswer')  
↳ [LayaCalibrationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationOptions 'DiGi\.Laya\.Classes\.LayaCalibrationOptions')  
↳ [LayaCalibrationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCalibrationResult 'DiGi\.Laya\.Classes\.LayaCalibrationResult')  
↳ [LayaClassificationOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationOptions 'DiGi\.Laya\.Classes\.LayaClassificationOptions')  
↳ [LayaClassificationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaClassificationResult 'DiGi\.Laya\.Classes\.LayaClassificationResult')  
↳ [LayaConfusionRow](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaConfusionRow 'DiGi\.Laya\.Classes\.LayaConfusionRow')  
↳ [LayaCriterion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaCriterion 'DiGi\.Laya\.Classes\.LayaCriterion')  
↳ [LayaEnvironmentResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEnvironmentResult 'DiGi\.Laya\.Classes\.LayaEnvironmentResult')  
↳ [LayaEvaluationResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaEvaluationResult 'DiGi\.Laya\.Classes\.LayaEvaluationResult')  
↳ [LayaItem](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaItem 'DiGi\.Laya\.Classes\.LayaItem')  
↳ [LayaLabel](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabel 'DiGi\.Laya\.Classes\.LayaLabel')  
↳ [LayaLabelAssignment](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelAssignment 'DiGi\.Laya\.Classes\.LayaLabelAssignment')  
↳ [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint')  
↳ [LayaLabelEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelEvaluation 'DiGi\.Laya\.Classes\.LayaLabelEvaluation')  
↳ [LayaLabelScore](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelScore 'DiGi\.Laya\.Classes\.LayaLabelScore')  
↳ [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet')  
↳ [LayaLabelSetEvaluation](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetEvaluation 'DiGi\.Laya\.Classes\.LayaLabelSetEvaluation')  
↳ [LayaLabelSetThreshold](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSetThreshold 'DiGi\.Laya\.Classes\.LayaLabelSetThreshold')  
↳ [LayaPredictionOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionOptions 'DiGi\.Laya\.Classes\.LayaPredictionOptions')  
↳ [LayaPredictionResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaPredictionResult 'DiGi\.Laya\.Classes\.LayaPredictionResult')  
↳ [LayaProbability](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaProbability 'DiGi\.Laya\.Classes\.LayaProbability')  
↳ [LayaQuestion](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaQuestion 'DiGi\.Laya\.Classes\.LayaQuestion')  
↳ [LayaRequest](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaRequest 'DiGi\.Laya\.Classes\.LayaRequest')  
↳ [LayaResponse](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaResponse 'DiGi\.Laya\.Classes\.LayaResponse')  
↳ [LayaSkippedCount](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaSkippedCount 'DiGi\.Laya\.Classes\.LayaSkippedCount')  
↳ [LayaTemperature](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTemperature 'DiGi\.Laya\.Classes\.LayaTemperature')  
↳ [LayaTrainingOptions](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingOptions 'DiGi\.Laya\.Classes\.LayaTrainingOptions')  
↳ [LayaTrainingResult](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingResult 'DiGi\.Laya\.Classes\.LayaTrainingResult')  
↳ [LayaTrainingSample](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaTrainingSample 'DiGi\.Laya\.Classes\.LayaTrainingSample')

Implements [ILayaObject](DiGi.Laya.Interfaces.md#DiGi.Laya.Interfaces.ILayaObject 'DiGi\.Laya\.Interfaces\.ILayaObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')