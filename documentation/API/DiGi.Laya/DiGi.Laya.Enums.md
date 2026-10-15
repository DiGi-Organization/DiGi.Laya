#### [DiGi\.Laya](DiGi.Laya.Overview.md 'DiGi\.Laya\.Overview')

## DiGi\.Laya\.Enums Namespace
### Enums

<a name='DiGi.Laya.Enums.LayaConstraintEffect'></a>

## LayaConstraintEffect Enum

Specifies what a [LayaLabelConstraint](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelConstraint 'DiGi\.Laya\.Classes\.LayaLabelConstraint') does to the score of the label it names\.

```csharp
public enum LayaConstraintEffect
```
### Fields

<a name='DiGi.Laya.Enums.LayaConstraintEffect.Forbid'></a>

`Forbid` 0

The label must not be suggested for the item: the score is marked forbidden with the constraint's reason, is no longer suggested, and keeps its probability\.

<a name='DiGi.Laya.Enums.LayaDevice'></a>

## LayaDevice Enum

Specifies the device the Laya scripts run the model on, passed to them as \-\-device\.

```csharp
public enum LayaDevice
```
### Fields

<a name='DiGi.Laya.Enums.LayaDevice.Auto'></a>

`Auto` 0

Laya chooses: CUDA, then Apple MPS, then Intel XPU, then the CPU\.

<a name='DiGi.Laya.Enums.LayaDevice.Cpu'></a>

`Cpu` 1

The CPU, whatever accelerator the machine has\.

<a name='DiGi.Laya.Enums.LayaDevice.Cuda'></a>

`Cuda` 2

CUDA device 0; the scripts refuse to run when torch reports no CUDA device\.

<a name='DiGi.Laya.Enums.LayaLabelSetKind'></a>

## LayaLabelSetKind Enum

Specifies how the labels of a [LayaLabelSet](DiGi.Laya.Classes.md#DiGi.Laya.Classes.LayaLabelSet 'DiGi\.Laya\.Classes\.LayaLabelSet') are asked of Laya and decided\.

```csharp
public enum LayaLabelSetKind
```
### Fields

<a name='DiGi.Laya.Enums.LayaLabelSetKind.SingleChoice'></a>

`SingleChoice` 0

Exactly one label applies: the set is one choice question named after the set, its labels the options; the labels with the highest probabilities are suggested\.

<a name='DiGi.Laya.Enums.LayaLabelSetKind.MultiLabel'></a>

`MultiLabel` 1

Any number of labels apply: each label is its own noul question named "\<set id\>:\<label id\>"; a label is suggested when its probability reaches the threshold\.

<a name='DiGi.Laya.Enums.LayaLoss'></a>

## LayaLoss Enum

Specifies the training objective of a fine\-tuning run, passed to laya\.train\.TrainConfig as loss\.

```csharp
public enum LayaLoss
```
### Fields

<a name='DiGi.Laya.Enums.LayaLoss.Default'></a>

`Default` 0

laya's default, currently [Rlcd](DiGi.Laya.Enums.md#DiGi.Laya.Enums.LayaLoss.Rlcd 'DiGi\.Laya\.Enums\.LayaLoss\.Rlcd')\.

<a name='DiGi.Laya.Enums.LayaLoss.Rlcd'></a>

`Rlcd` 1

The objective of the published fine\-tuning notebook \("rlcd"\)\.

<a name='DiGi.Laya.Enums.LayaLoss.SoftCrossEntropy'></a>

`SoftCrossEntropy` 2

The soft cross\-entropy alone \("soft\-ce"\); scored slightly higher than rlcd on laya's typed\-decisions benchmark\.

<a name='DiGi.Laya.Enums.LayaOptionLayout'></a>

## LayaOptionLayout Enum

Specifies how the options of a question are laid out for the model, passed to laya\.train\.TrainConfig as option\_layout\.

```csharp
public enum LayaOptionLayout
```
### Fields

<a name='DiGi.Laya.Enums.LayaOptionLayout.Default'></a>

`Default` 0

The base checkpoint's own layout, sequential for every published checkpoint\.

<a name='DiGi.Laya.Enums.LayaOptionLayout.Sequential'></a>

`Sequential` 1

The options one after another \("sequential"\)\.

<a name='DiGi.Laya.Enums.LayaOptionLayout.Parallel'></a>

`Parallel` 2

The options side by side \("parallel"\); needs transformers 5 or later, and the ONNX runtime refuses such a checkpoint\.

<a name='DiGi.Laya.Enums.LayaQuestionType'></a>

## LayaQuestionType Enum

Specifies the type of a question asked of the Laya decision model, which decides the shape of its answer\.

```csharp
public enum LayaQuestionType
```
### Fields

<a name='DiGi.Laya.Enums.LayaQuestionType.Choice'></a>

`Choice` 0

A closed choice between labelled options, answered with the selected label and a probability per option\.

<a name='DiGi.Laya.Enums.LayaQuestionType.Score'></a>

`Score` 1

An ordered scale of levels, answered with the expected level and a probability per level\.

<a name='DiGi.Laya.Enums.LayaQuestionType.Noul'></a>

`Noul` 2

A statement judged true or false, answered with the probability that it is true\.