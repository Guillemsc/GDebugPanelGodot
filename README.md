[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Guillemsc/GDebugPanelGodot/blob/main/CONTRIBUTING.md)
[![Release](https://img.shields.io/github/release/Guillemsc/GDebugPanelGodot.svg)](#from-releases)
[![Twitter Follow](https://img.shields.io/badge/twitter-%406uillem-blue.svg?label=Follow)](https://twitter.com/6uillem)
<img src="https://img.shields.io/badge/Godot-v4.x-%23478cbf?logo=godot-engine&logoColor=cyian&color=green">

![LogoWide](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/a1b75c7b-9fcc-4131-ad5e-4034f4869270)

GDebugPanel-Godot is a lightweight and versatile debug panel for Godot 4.x with C#. 
This asset simplifies the process of creating debug panel with options in your Godot projects, allowing you to focus on what matters: gameplay.

A debug panel, is a user interface that provides developers with tools and information to aid in debugging and profiling during the development of a software application or game.

This asset provides a suit of premade elements (buttons, int selector, float selector, enum selection, etc), while allwing for the creation of new ones, with ease.

![OptionsArt](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/139736d6-ffb8-4f85-a962-14597b93723c)

## 🍰 Features
- **Simple API**: GDebugPanel-Godot provides an intuitive and easy-to-use API with C#.
    ```csharp
    GDebugPanel.Show(this);
    GDebugPanel.Hide();

    IDebugActionsSection section = GDebugPanel.AddSection("Section name");
    section.AddButton("Button name", () => GD.Print("Button 2"));
    section.AddInt("Int selector name", val => _int = val, () => _int);
    ```

- **Adaptative**: The different widgets support and adapt to different screen aspect rations, making it a good fit for both, desktop and mobile.

  ![AdaptativeArt](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/2e139eb8-d3a6-474d-bff2-a78ccec896bf)

- **Versatile Easing Functions**: Choose from a variety of easing functions to achieve different animation effects, including linear, ease-in, ease-out, and custom curves.
    ```csharp
    public partial class EasingExample : Node
    {
        [Export] public Node2D Target1;
        [Export] public Node2D Target2;
	
        [Export] public Easing Easing1;
        [Export] public Curve Easing2;
		
        public override void _Ready()
        {
            GTween tween1 = Target1.TweenPositionX(100, 3);
            tween1.SetEasing(Easing1);
            tween1.Play();
	        
            GTween tween2 = Target2.TweenPositionX(100, 3);
            tween2.SetEasing(Easing2);
            tween2.Play();
        }
    }
    ```
  
- **Looping**: Create looping animations with a single line of code, and control loop count and behavior.
    ```csharp
    public partial class LoopingTweenExample : Node
    {
        [Export] public Node2D Target;
        [Export] public int Loops;
		
        public override void _Ready()
        {
             GTween tween = Target.TweenPositionX(150, 1);
             tween.SetLoops(Loops);
             tween.Play();
        }
    }
    ```
  
- **Delays**: Specify delays, allowing precise timing of your animations.
    ```csharp
    GTween tween = GTweenSequenceBuilder.New()
        .AppendTime(0.5f)
        .Build();
    ```

- **Callbacks**: Attach callbacks to tweens for event handling at various points in the animation timeline.
    ```csharp
    void Callback()
    {
    }

    GTween tween = GTweenSequenceBuilder.New()
        .AppendCallback(Callback)
        .Build();
    ```
- **Safety**: When a node that's being tweened becomes invalid or gets destroyed, the tween automatically handles that on a safe manner, and kills itself.

## 📦 Installation

### From releases:
1. [Download the latest GDebugPanelGodot.zip release](https://github.com/Guillemsc/GDebugPanelGodot/releases/latest).
2. Unpack the `GDebugPanelGodot.zip` folder into the Godot's project `addons/` folder. 

## 📚 Getting started
### Nomenclature
- Tween: a generic word that indicates some or multiple values being animated.
- Sequence: an combination of tweens that get animated as a group.

### Prefixes
Prefixes are important to use the most out of IntelliSense, so try to remember these:
- **Tween**: prefix for all tween shortcuts (operations that can be started directly from a known object, like a Node2D or a Control).
    ```csharp
    node2D.TweenPositionX(100f, 1f);
    control.TweenSizeY(200f, 2f);
    ```
- **Set**: prefix for all settings that can be chained to a tween.
    ```csharp
    myTween.SetLoops(4).SetEasing(Easing.InOutCubic);
    ```
- **On**: prefix for all callbacks that can be chained to a tween.
    ```csharp
    myTween.OnStart(myStartFunction).OnComplete(myCompleteFunction);
    ```
 
### Generic tweening
This is the most flexible way of tweening and allows you to tween almost any value.
```csharp
// For default C# values (int, float, etc)
GTweenExtensions.Tween(getter, setter, to, duration)

// For Godot specific values (Vector2, Vector3, etc)
GTweenGodotExtensions.Tween(getter, setter, to, duration)
```
- **Getter**: a delegate that returns the value of the property to tween. Can be written as a lambda like this: `() => myValue`
where `myValue` is the name of the property to tween.
- **Setter**: a delegate that sets the value of the property to tween. Can be written as a lambda like this: `x => myValue = x`
where `myValue` is the name of the property to tween.
- **To**: the end value to reach.
- **Duration**: the duration of the tween in seconds.
- **Validation** (optional): a delegate that every time the tween updates, checks if it should be running. Can be written as a lambda like this: `() => shouldKeepRunning`
where `shouldKeepRunning` is a boolean.
  
```csharp
// For default C# values
GTween tween = GTweenExtensions.Tween(
    () => Target.SomeFloat, // Getter
    x => Target.SomeFloat = x, // Setter
    100f, // To
    1 // Duration
);

// For Godot specific values
GTween tween = GTweenGodotExtensions.Tween(
    () => Target.Position, // Getter
    x => Target.Position = x, // Setter
    new Vector2(100f, 100f), // To
    1 // Duration
);
```

### Shortcut tweening
GTweem includes shortcuts for some known C# and Godot objects, like Node2D, Node3D, Control, etc. You can start a tween directly from a reference to these objects, like:
```csharp
node2D.TweenPositionX(100f, 1f);
node3D.TweenScale(new Vector3(2f, 2f, 2f), 1f);
﻿﻿﻿﻿﻿﻿﻿﻿control.TweenSizeY(200f, 2f);
```
See all [shortcuts you can use](#-shortcuts).

### Sequences
Sequences are a combination of tweens that get animated as a group. 
Sequences can be contained inside other sequences without any limit to the depth of the hierarchy.
To create sequences, you need to use the helper `GTweenSequenceBuilder`.
- First you call to start creating a new sequence `New()`.
- Next you `Append()` or `Join()` any tweens to the sequence.
	- **Append**: Adds the given tween to the end of the Sequence. This tween will play after all the previous tweens have finished.
	- **Join**: Inserts the given tween at the same time position of the last tween added to the Sequence. This tween will play at the same time as the previous tween.
- Finally you call `Build()` to get the generated sequence Tween.
```csharp
 GTween tween = GTweenSequenceBuilder.New()
    .Append(Target.TweenPositionX(100, 0.5f))
        .Join(Target.TweenScale(new Vector2(2, 2), 1))
    .Append(Target.TweenPositionY(100, 1))
    .AppendTime(0.5f)
    .Append(Target.TweenPositionX(0, 1))
    .AppendSequence(s => s
        .AppendTime(0.5f)
        .Append(Target.TweenPositionX(1, 1))
        )
    .AppendCallback(() => GD.Print("I'm finished!"))
    .Build();
        
tween.SetEasing(Easing.InOutCubic);
tween.Play();
```
As it can be seen on the example, you can Append/Join different things with the builder:
- Append/Join Callback: adds a callback that will be called when this part of the sequence is executed.
- Append/Join Time: adds a time delay (in seconds) to the sequence.
- Append/Join Sequence: creates a new `GTweenSequenceBuilder` and provides it through the action. Then it automatically builds it and adds the resulting tween to the sequence.

[Example of a complex sequence](https://github.com/Guillemsc/GTweensGodot/blob/main/Godot/Examples/Scripts/Cube3DExample.cs):

![ezgif com-gif-maker](https://github.com/Guillemsc/GTweensGodot/assets/17142208/92e01c51-a9e8-43c4-a5d8-280ea03d4ae9)


### Tween controls
- **Play**: plays the tween.
- **Kill**: kills the tween. This means that the tween will instantly stop playing, leaving it at its current state.
- **Complete**: instantly reaches the final state of the tween, and stops playing.
- **Reset**: sets the tween to its initial state, and stops playing.
- **SetLoops**: sets the amount of times the tween should loop.
- **SetEasing**: sets the easing used by the tween. If the tween is a sequence, the easing will be applied to all child tweens. Set to linear by default.
- **SetTimeScale**: sets the time scale that will be used to tick the tween. Set to 1 by default.

### Tasks
- **PlayAsync**: plays the tween and returns a Task that waits until the tween is killed or completed. If the parameter CancellationToken is cancelled, the tween will be killed.
- **AwaitCompleteOrKill**: returns a Task that waits until the tween is killed or completed.

## 📖 Shortcuts
These are the currently avaliable shortcuts for Godot nodes (the list grows with time).
- **Node2D**: GlobalPosition, Position, GlobalRotation, Rotation, GlobalRotationDegrees, RotationDegrees, GlobalScale, Scale, GlobalSkew, Skew.  
- **Node3D**: GlobalPosition, Position, GlobalRotation, Rotation, GlobalRotationDegrees, RotationDegrees, GlobalScale, Scale.
- **Control**: GlobalPosition, Position, Rotation, RotationDegrees, Scale, Size, PivotOffset.
- **Sprite2D**: Offset.
- **SpriteBase3D**: Modulate, Offset.
- **Light2D**: Color, Energy, ShadowColor.
- **Light3D**: LightColor, LightEnergy, LightIndirectEnergy, LightVolumetricFogEnergy, LightAngularDistance, ShadowBias, ShadowNormalBias, ShadowTransmittanceBias, ShadowOpacity, ShadowBlur.
- **Camera2D**: Offset, Zoom.
- **Camera3D**: HOffset, VOffset, Fov.
- **AudioStreamPlayer2D**: VolumeDb, PitchScale.
- **AudioStreamPlayer3D**: VolumeDb, PitchScale, AttenuationFilterDb, AttenuationFilterCutoffHz.
- **CanvasModulate**: Color.
- **CanvasItem**: Modulate, SelfModulate.
- **ShaderMaterial**: PropertyInt, PropertyFloat, PropertyVector2, PropertyVector2I, PropertyColor.
- **BaseMaterial3D**: AlbedoColor, Metallic, MetallicSpecular, Roughness.
  
 

