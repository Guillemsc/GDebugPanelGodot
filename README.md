[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Guillemsc/GDebugPanelGodot/blob/main/CONTRIBUTING.md)
[![Release](https://img.shields.io/github/release/Guillemsc/GDebugPanelGodot.svg)](#from-releases)
[![Twitter Follow](https://img.shields.io/badge/twitter-%406uillem-blue.svg?label=Follow)](https://twitter.com/6uillem)
<img src="https://img.shields.io/badge/Godot-v4.x-%23478cbf?logo=godot-engine&logoColor=cyian&color=green">

![LogoWide](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/a1b75c7b-9fcc-4131-ad5e-4034f4869270)

GDebugPanel-Godot is a lightweight and versatile ingame debug panel for Godot 4.x with C#. 
It can be incredible useful to be able to modify gameplay parameters while on the target device. 
This asset simplifies the process of creating debug panel with options in your Godot projects, allowing you to focus on what matters: gameplay.

A debug panel, is a user interface that provides developers with tools and information to aid in debugging and profiling during the development of a software application or game.

This asset provides a suit of premade elements (buttons, int selector, float selector, enum selection, etc), while allwing for the creation of new ones, with ease.

![OptionsArt](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/139736d6-ffb8-4f85-a962-14597b93723c)

## 🍰 Features
- **Simple API**: GDebugPanel-Godot provides an intuitive and easy-to-use API with C#.
    ```csharp
    GDebugPanel.Show(Control);
    GDebugPanel.Hide();

    IDebugActionsSection section = GDebugPanel.AddSection("Section name");
    section.AddButton("Button name", () => GD.Print("Button 2"));
    section.AddInt("Int selector name", val => _int = val, () => _int);
    ```

- **Adaptative**: The different widgets support and adapt to different screen aspect ratios, making it a good fit for both, desktop and mobile.

  ![AdaptativeArt](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/2e139eb8-d3a6-474d-bff2-a78ccec896bf)

- **Smart**: You can automatically generate a debug options section using a class. Using reflection, changes that occur on the debug panel will affect the class instance.

  ![AutomaticArt](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/08886a94-e062-4532-a907-81c6482b2696)

- **Organization**: Organize your options using collapsable sections.

  ![Gif2](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/a181cbeb-eb6a-4b8e-9de0-118f9b27d2bb)

- **Fuzzy search**: Quicly find the options you were looking for with the search bar!

  ![Gif](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/5f47d808-69ab-4e5d-8aa9-18f0be2c2f87)

- **Lightweight**: While your game is running, the panel does not exist at all until you want to show it.
When is hidden again, the panel is completely destroyed, so it does not affect to the preformance of your game.

## 📦 Installation

### From releases:
1. [Download the latest GDebugPanelGodot.zip release](https://github.com/Guillemsc/GDebugPanelGodot/releases/latest).
2. Unpack the `GDebugPanelGodot.zip` folder into the Godot's root folder. Make sure the GDebugPanelGodot is inside the `addons/` folder.

To quickly check if everything has been setup properly, you can go to GDebugPanelGodot/Examples/Scenes/ and open any of the example scenes. When you run any of those scenes, a simple functionality example should play.

> [!WARNING]
> It's very important that the asset is placed under the `addons/` folder. Not doing so will make the asset not work.

> [!NOTE]
> This asset is not setup as a plugin. Just adding it to your project will make it work.

## 📚 Getting started
### Showing / Hiding
- For **showing** the panel, you just need to call the `Show` method, providing as a parameter the Control where you want the panel to be placed at.
    ```csharp
    GDebugPanel.Show(Control);
    ```
- For **hiding** the panel, just call the `Hide` method.
    ```csharp
    GDebugPanel.Hide();
    ```

### Sections
Debug options are divided within different sections. These sections allow you to better organize your options.
You cannot create a debug option outside of a section.
- **Creating** a new section is very simple, you just need to call `AddSection` and provide a section name: 
    ```csharp
    IDebugActionsSection section = GDebugPanel.AddSection("Section name");
    ```
- **Removing** a section is equally as simple. Just call `RemoveSection`, and provide the section you want to remove.
    ```csharp
    GDebugPanel.RemoveSection(section);
    ```
    
Sections can be both, collapsable and non collapsable. You can decide which one you want by calling:
- `AddSection` for a collapsable one.
    ```csharp
    IDebugActionsSection section = GDebugPanel.AddSection("Section name");
    ```
- `AddNonCollapsableSection` for a non collapsable one.
    ```csharp
    IDebugActionsSection section = GDebugPanel.AddNonCollapsableSection("Section name");
    ```

### Automatic debug options
This asset has the ability of scanning for properties and methods in C# classes, to automatically create de adecuate widgets.

One of such classes may look like this:

```csharp
public sealed class ExampleOptionsObject
{
    public enum ExampleEnum
    {
        Enum1,
        Enum2,
        Enum3,
        SomeLongValueThat,
    }
    
    public void ButtonExample() => GD.Print("Button Option!");
    public bool ToggleExample { get; set; }
    public string DynamicInfoExample { get; set; } = "Dynamic Info";
    public string InfoExample => "Info";
    public int IntExample { get; set; }
    public float FloatExample { get; set; }
    public ExampleEnum EnumExample { get; set; }
}
```

Then we add the class like this:

```csharp
GDebugPanel.AddSection("Section name", new ExampleOptionsObject());
```

And we will get debug options like this:

![Reflection](https://github.com/Guillemsc/GDebugPanelGodot/assets/17142208/9b75af62-8de2-4295-ac66-ababfec26ed4)

 
### Manual debug options
This is the most part of this assets, the debug options (or widgets). Once you have a section instance, you have some debug options avaliable:

- Info: a static string that cannot be changed one submited.
    ```csharp
    section.AddInfo("Some info that never changes");
    ```
- Dynamic Info: a getter for a string that it's updated every frame.
    ```csharp
    section.AddInfoDynamic(() => "Some info that can change");
    ```
- Button: a simple button with a name.
    ```csharp
    section.AddButton("Button name", () => GD.Print("Pressed"));
    ```
- Toggle: a simple bool toggle with a name. Requests a setter and a getter for the value.
    ```csharp
    bool someBool = false;
    section.AddToggle("Toggle name", val => someBool = val, () => someBool);
    ```
- Int: an int selector with a name. Requests a setter and a getter for the value.
    ```csharp
    int someInt = 0;
    section.AddInt("Int name", val => someInt = val, () => someInt);
    ```
- Float: an float selector with a name. Requests a setter and a getter for the value.
    ```csharp
    float someFloat = 0f;
    section.AddFloat("Float name", val => someFloat = val, () => someFloat);
    ```
 - Enum: an enum selector with a name. Requests a setter and a getter for the value.
    ```csharp
    public enum ExampleEnum
    {
        Enum1,
        Enum2,
        Enum3,
    }
    ExampleEnum someEnum = default;
    section.AddEnum("Enum name" val => someEnum = val, () => someEnum);
    ```

### Creating more debug options
Some times, your game may have specific needs that cannot be properly met by the default provided widgets. That's why you can create your own.
We are going to use the Int widget as an example.

1. The first thing you need to do is create a new class and inherit from `IDebugAction`. This interface will force you to implement `DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)` method,
which is responsable for instantiating the widget on the Ui. We will not implement it for now.

    ```csharp
    public sealed class IntDebugAction : IDebugAction
    {    
        public IntDebugAction()
        {
        }
    
        public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
        {
            throw new NotImplementedException();
        }
    }
    ```

2. Next, we need a new `DebugActionWidget`, which will be the actual Node placed on the Ui. Since the widget is made of a label and a spin box, we will add references to it.
`LabelAutowrapSelectionByControlWidthController` is an utility class that helps wrap text when it cannot fit its designated width.

    ```csharp
    public partial class IntDebugActionWidget : DebugActionWidget
    {
        [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
        [Export] public Label? Label;
        [Export] public SpinBox? SpinBox;
    }
    ```

3. Going back to the `IntDebugAction` class, we need to implement `InstantiateWidget`, by instantiating the created `IntDebugActionWidget`. For this, you will need to create the
requiered Ui PackedScene, add the `IntDebugActionWidget` script to it, and reference this PackedScene on your `IntDebugAction` in any prefered way.
In the case of internal widgets, they are references on the main debug panel.

    ```csharp
    public sealed class IntDebugAction : IDebugAction
    {    
        public IntDebugAction()
        {
        }
    
        public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
        {
            // IntDebugActionWidget is a PackedScene
            IntDebugActionWidget widget = debugPanelView.IntDebugActionWidget!.Instantiate<IntDebugActionWidget>();
            return widget;
        }
    }
    ```
4. For being able to use this new action on a section, just add an extension method that does that:

    ```csharp
    public static IDebugAction AddInt(this IDebugActionsSection section)
    {
        IDebugAction debugAction = new IntDebugAction();
        section.Add(debugAction);
        return debugAction;
    }
    ```

5. Cool! If all went well, you should now be able to see your widget on the debug panel once you call your Add method. Now we just need to add functionality to it.
We first add all the necessary parameters to our action. In this case, the name of the option, and a getter and a setter that will be called by our widget.

   ```csharp
    public sealed class IntDebugAction : IDebugAction
    {
        public string Name { get; }
        public Action<int> SetAction { get; }
        public Func<int> GetAction { get; }
    
        public IntDebugAction(string name, Action<int> setAction, Func<int> getAction)
        {
            Name = name;
            SetAction = setAction;
            GetAction = getAction;
        }
    
        public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
        {
            IntDebugActionWidget widget = debugPanelView.IntDebugActionWidget!.Instantiate<IntDebugActionWidget>();
            widget.Init(debugPanelView.ContentControl!, Name, SetAction, GetAction);
            return widget;
        }
    }
    ```

    ```csharp
    public partial class IntDebugActionWidget : DebugActionWidget
    {
        [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
        [Export] public Label? Label;
        [Export] public SpinBox? SpinBox;
    
        Action<int>? _setAction;
        Func<int>? _getAction;
    
        public void Init(Control sizeControl, string name, Action<int> setAction, Func<int> getAction)
        {
            LabelAutowrapController!.SizeControl = sizeControl;
            _setAction = setAction;
            _getAction = getAction;
        
            Label!.Text = name;
            SpinBox.MinValue = int.MinValue;
            SpinBox.MaxValue = int.MaxValue;
            SpinBox.Value = getAction.Invoke();
            SpinBox.ConnectSpinBoxValueChanged(Changed);
        }
    
        public override bool Focus()
        {
            SpinBox!.GrabFocus();
            return true;
        }

        void Changed(float value)
        {
            int truncatedValue = (int)value;
            _setAction!.Invoke(truncatedValue);
            truncatedValue = _getAction!.Invoke();
            SpinBox!.SetValueNoSignal(truncatedValue);
        }
    }
    ```
 

