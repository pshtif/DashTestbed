# NODES

Nodes are basic building blocks of Dash graphs. All logic happens inside nodes the graph and Dash just execute connections between them. 

## Model

Each node contains its own model which represents the properties of that particular node (model is present even if there are no properties). State of the model doesn't change between different executions of the node, each execution just gets value from the model and executes upon it.

## Node

As stated each node has its model that holdes the parameters while the node itself executes upon them. Nodes are stateless and execution with the same parameters will always execute the same way.

## Node Type Categories

There are currently six different node type categories that groups nodes with similar functionality.

### Animation Nodes

Animation nodes animate properties or a state of a target in some way either using tweens or Unity animation. Each animation node inherits AnimationNodeBase as well as AnimationNodeModelBase so they have a common animation functionality as well as common retargeting functionality. 

Animation common properties are *__time__*, *__delay__*, and *__easing__*.

Retargeting common properties are *__retarget__*, *__isChild__*, *__useReference__*, *__target/targetReference__* which enables you to change current target in the NodeDataFlow specifically for this animation node without it being actually changed in the flow. If *__retarget__* is not checked the node will execute on the target in the NodeFlowData.

#### *AnimateAnchoredPosition*

This nodes animates anchored position of a RectTransform component on a target. 

```
useFrom - boolean check if you want to specify from position as well
fromPosition - specifies the position value where the anchored position should animate from (applicable only when useFrom is checked)
isFromRelative - specifies if fromPosition is relative value (applicable only when useFrom is checked)

toPosition - specifies the position value where the anchored position should animate to
isToRelative - specifies if the toPosition is relate value
```

#### *AnimateColor*

This node animates color or alpha of either *TextMeshPro, Image* or *CanvasGroup*

```
targetType - specifies what target type we are animating, some of them have full color capabilities some only alpha
toAlpha - specifies the alpha value to which we are going to animate (applicable only when targetType is CanvasGroup)
isToRelatibe - specifies if toAlpha is relative value (applicable only when targetType is CanvasGroup)

toColor - specifies the color value to which we are going to animate (applicable only when targetType is not CanvasGroup)
```

#### *AnimateRotation*

This node animates rotation of a Transform/RectTransform component on a target.

```
useFrom - boolean check if you want to specify from rotation as well
fromRotation - specifies the rotation value where the rotation should animate from (applicable only when useFrom is checked)
isFromRelative - specifies if fromRotation is relative value (applicable only when useFrom is checked)

toRotation - specifies the rotation value where the rotation should animate to
isToRelative - specifies if the toRotation is relate value
```

#### *AnimateScale*

This node animates scale of a Transform/RectTransform component on a target.

```
useFrom - boolean check if you want to specify from scale as well
fromScale - specifies the scale value where the scale should animate from (applicable only when useFrom is checked)
isFromRelative - specifies if fromScale is relative value (applicable only when useFrom is checked)

toScale - specifies the scale value where the scale should animate to
isToRelative - specifies if the toScale is relate value
```

#### *AnimateSizeDelta*

This node animates sizeDelta of a RectTransform component on a target. It basically animates with and height of a RectTransform bsaed on their anchor type.

```
useFrom - boolean check if you want to specify from sizeDelta as well
fromSizeDelta - specifies the sizeDelta value where the sizeDelta should animate from (applicable only when useFrom is checked)
isFromRelative - specifies if fromSizeDelta is relative value (applicable only when useFrom is checked)

toSizeDelta - specifies the sizeDelta value where the sizeDelta should animate to
isToRelative - specifies if the toSizeDelta is relate value
```

#### *AnimateTextNode* *__[EXPERIMENTAL]__*

This node animates text of TextMeshPro component on target. It animates text per character basis, there will be multiple types of per character animations available currently only supports scaling in experimental stage.

*__WARNING Experimental nodes may have different properties later and you may run into serialization issues of existing graphs in new version of Dash.__*
```
characterDelay - delay in time between animation of two characters
```

#### *AnimateSizeDelta*

This node animates sizeDelta of a RectTransform component on a target. It basically animates with and height of a RectTransform bsaed on their anchor type.

```
useFrom - boolean check if you want to specify from sizeDelta as well
fromSizeDelta - specifies the sizeDelta value where the sizeDelta should animate from (applicable only when useFrom is checked)
isFromRelative - specifies if fromSizeDelta is relative value (applicable only when useFrom is checked)

toSizeDelta - specifies the sizeDelta value where the sizeDelta should animate to
isToRelative - specifies if the toSizeDelta is relate value
```

#### *AnimateToRect*

This node animates RectTransform on target to specified RectTransform, you can also specify which part of transform should be take into account position/rotation/scale.

```
toTarget - specifies the target of the RectTransform to animate to

useToPosition - specifies if position should be used in this animation
useToRotation - specifies if rotation should be used in this animation
useToScale - specifies if scale should be used in this animation
```

#### *AnimateWithClip*

This node animates target using a specified Unity AnimationClip or special DashAnimation.

This node doesn't inherit AnimationNodeBase thats why properties like time, delay and easing are specified directly on this node.

```
useAnimationTime - specifies if we want to use time from the specified clip or override it with custom value
time - specifies the duration of the animation (applicable only when useAnimationTime is checked)
delay - specifies the delay to wait till animation starts
easing - specifies the easing for the animation

isReverse - specifies if the animation should play in reverse
isRelative - specifies if the animation should animate properties in relative manner (applicable only if useDashAnimation is checked)
useDashAnimation - specifies if we want to use DashAnimation or standard Unity AnimationClip

source - specifies the DashAnimation asset to use (applicable only when useDashAnimation is checked)
clip - specifies the Unity AnimationClip asset to use (applicable only when useDashAnimation is not checked)
```

#### *AnimateWithPreset*

This node animates target using a specified preset.

Presets are custom implementations for any type of programmatic animation. You can implement your own custom presets by implementing IAnimationPreset interface. This node will then automatically look for any implementation of this interface within the codebase.

```
preset - specifies the preset to use for the animation
```

### Creation Nodes

Creation nodes handle creation or destroyment of objects. 

#### *Destroy*

This node destroys target game object.

_This node imherits RetargetNodeBase so it can be locally retargeted without affecting the node data flow._

```
immediate - specifies if DestroyImmediate should be used
```

#### *SpawnImage*

This node spawns a game object with an Image component attached to it.

```
spawnedName - specifies the name that will be assigned as name of the spawned game object
sprite - specifies the sprite that should be assigned to the Image component
position - specifies the anchored position of the spawned game object

setTargetAsParent - specifies if the target should be set as a parent of the spawned game object
retargetToSpawned - specifies if the node flow data should be retargeted to the spawned game object

createSpawnedAttribute - specifies if an attribute should be created within node flow data with the spawned game object as value (applicable only when retargetToSpawned is not checked)
spawnedAttributeName - specifies the name of the attribute with spawned object (applicable only when createSpawnedAttribute is checked)
```

#### *SpawnUIPrefab*

This node spawns a custom RectTransform prefab.

```
prefab - specifies the RectTransform prefab to spawn
position - specifies the anchored position of the spawned prefab

setTargetAsParent - specifies if the target should be set as a parent of the spawned game object
retargetToSpawned - specifies if the node flow data should be retargeted to the spawned game object

createSpawnedAttribute - specifies if an attribute should be created within node flow data with the spawned game object as value (applicable only when retargetToSpawned is not checked)
spawnedAttributeName - specifies the name of the attribute with spawned object (applicable only when createSpawnedAttribute is checked)
```

### Event Nodes

Event nodes deal with either receiving events which are nodes without input and stand at the beginning of the execution or sending events which are nodes without output.

More documentation on sending and receiving events withint Dash is HERE.

_Event nodes inherit base node directly there is no additional parametrization._

#### *OnCustomEvent*

This node executes upon receiving an event specified by a custom name. 

```
eventName - specifies the name of the custom event to listen to
```

#### *OnButtonClick*

This node executes upon receiving a click event from a specified button.

```
useReference - specifies if we are going to look for the button by a reference

buttonReference - specifies the reference of the button (applicable only when useReference is checked)

isChild - specifies if the button we are looking for is child of current target (applicable only when useReference is unchecked)
useFind - specifies if we are going to use complex find instead of just name lookup (applicable only when useReference is unchecked)
findAll - specifies if we are looking for first button match or all matches (applicable only when useReference is unchecked and useFind is checked)
button - specifies the string we are going to use for lookup/find (applicable only when useReference is not checked)

retargetToButton - specifies if we want to change the target in node flow data to the button transform
```

#### *OnMouseClick* *__EXPERIMENTAL__*

This node executes upon any mouse click event.

``` 
```

#### *SendCustomEvent*

This node sends a custom event specified by name.

```
eventName - specifies the name of the custom event to send
```

### Graph Nodes

Graph nodes are special category of nodes, that you will find in the root of the node creation context menu.

#### *Input*

This node creates a graph input with a specified name.

```
inputName - specifies the name of the input, this name needs to be unique as there cannot be two inputs with the same name, Dash will automatically detect and change it if it is not unique
```

#### *Output*

This node creates a graph output with a specified name.

```
outputName - specifies the name of the output, this name needs to be unique as there cannot be two outputs with the same name, Dash will automatically detect and change it if it is not unique
```

#### *SubGraph* *__EXPERIMENTAL__*

This node creates a sub graph node that wraps another Dash graph within this graph.

```
useAsset - specifies if we are going to use a Dash graph asset or contain the graph directly
graphAsset - specifies the asset of the graph we are using (applicable only if useAsset is checked)
```

### Logic Nodes

Delay nodes contain functionality for graph logic like loops, branches, debugging etc.

#### *Branch*

This node creates a branch logic based on parametric bool property.

```
expression - specifies the bool value or parametric expression to branch the flow
```

#### *Debug*

This node outputs a debug text message or state of current node flow data.

```
debugFlowData - specifies if the current NodeFlowData instance attributes should be outputted
text - specifies the text to output (applicable only when debugFlowData is not checked)
attribute - specifies the attribute to output from current NodeFlowData (applicavle only when debugFlowData is not checked)
```

#### *Delay*

This node creates a delay in graph execution.

```
time - specifies the time the node will wait till execution is resumed
```

#### *ForLoop*

This node creates a for loop execution per iteration and an additional final execution at the end.

```
onIterationDelay - specifies a delay between execution of two iterations
onFinishedDelay - specifies a delay between execution of last iteration and an additional final execution

firstIndex - specifies starting index for iteration
lastIndex - specifies ending index for iteration

addIndexAttribute - specifies if we want to create an index attribute with the index value in the node flow data
indexAttribute - specifies the name of the index attribute (applicable only when addIndexAttribute is checked)
```

#### *Null*

This is a null node without a functionality commonly used for graph connection management.

```
```

### Modifier Nodes

Modifier nodes are nodes that change attributes and properties. It may be an attribute inside a node flow data or a property on a object.

#### *AddAttribute*

This nodes add an attribute of supported type into a node flow data.

```
attributeName - specifies the name of the attribute to add
attributeType - specifies the type of the attribute to add
expression - specifies the expression that will be used for evaluation to get the attribute value
```

#### *IncrementText*

This node increments a number inside a TextMeshPro component text on a current target. (Used for value changes of things like gold or hp.)

```
useDotFormatting - specifies if we are using dot formatting for numbers text (1.000 instead of 1000)
increment - specifies the increment we will use to alter the number
```

#### *RetargetAdvanced*

This node changes the *target* attribute inside the node flow data and uses advanced find functionality for more specific target search. It can also look for multiple targets and execute per found instance.

```
isChild - specifies if the new target should be child of the current target
findAll - specifies if we want to find all matching targets, if so it will execute per found instance
target - specifies the name of the target we are looking for
delay - specifies the delay in execution after each target (applicable only when findAll is checked)
inReverse - specifies if we want to execute the found targets in reverse order (applicable only when findAll is checked)
```

#### *Retarget*

This node changes the *target* attribute inside the node flow data using the default functionality.

*This node inherits RetargetNodeBase so it contains basic retarget functionality on top of mentioned properties.*


```
```

#### *RetargetToChildren*

This node changes the *target* attribute inside the node flow data in an iterative way to each child of current target.

*This node inherits RetargetNodeBase so it contains basic retarget functionality on top of mentioned properties.*

```
onChildDelay - specifies the delay between execution for each child
onFinishDelay - specifies the delay between execution of last child and one additional final execution
inReverse - specifies if we want to execute the children in reverse order
```

#### *SetActive*

This node changes the active state of game object of current target.

*This node inherits RetargetNodeBase so it contains basic retarget functionality on top of mentioned properties.*

```
active - specifies if it should be set to active or inactive.
```