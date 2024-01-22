
using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.UseCases;
using Godot;

namespace GDebugPanelGodot.Core
{
    public sealed class GDebugPanel
    {
        static GDebugPanel? _instance;
        static GDebugPanel Instance => _instance ??= new GDebugPanel();

        readonly CacheData _cacheData = new();
        readonly DebugPanelData _debugPanelData = new();
        readonly DebugActionsData _debugActionsData = new();
        readonly FocusData _focusData = new();
        
        /// <summary>
        /// Shows the debug actions UI with the specified parent node.
        /// </summary>
        /// <param name="parent">The parent node to attach the debug UI to.</param>
        /// <param name="grabFocus">If set to true, first item of the debug UI will grab focus.
        /// When the panel is closed, it will try to return the focus to the previous element.</param>
        public static void Show(Node parent, bool grabFocus = true) => Instance.ShowInternal(parent, grabFocus);
        
        /// <summary>
        /// Hides the debug actions UI.
        /// </summary>
        public static void Hide() => Instance.HideInternal();
        
        /// <summary>
        /// Checks if the debug actions UI is currently visible.
        /// </summary>
        /// <returns>True if the UI is visible, false otherwise.</returns>
        public static bool IsVisible() => Instance.IsVisibleInternal();

        /// <summary>
        /// Adds a collapsible section to the debug actions UI.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <param name="collapsed">Whether the section should be initially collapsed.</param>
        /// <param name="priority">The priority of the section.</param>
        /// <returns>The added section.</returns>
        public static IDebugActionsSection AddSection(string name, bool collapsed = false, int priority = 0) 
            => Instance.AddSectionInternal(name, collapsed, priority);
        
        /// <summary>
        /// Adds a collapsible section to the debug actions UI with a specified priority.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <param name="priority">The priority of the section.</param>
        /// <returns>The added section.</returns>
        public static IDebugActionsSection AddSection(string name, int priority) 
            => AddSection(name, false, priority);
        
        /// <summary>
        /// Adds a non-collapsible section to the debug actions UI.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <param name="priority">The priority of the section.</param>
        /// <returns>The added non-collapsible section.</returns>
        public static IDebugActionsSection AddNonCollapsableSection(string name, int priority = 0) 
            => Instance.AddNonCollapsableSectionInternal(name, priority);
        
        /// <summary>
        /// Adds a collapsible section to the debug actions UI with specified options object.
        /// Using reflection, debug actions are going to be created for the options object.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <param name="optionsObject">Options associated with the section.</param>
        /// <param name="collapsed">Whether the section should be initially collapsed.</param>
        /// <param name="priority">The priority of the section.</param>
        /// <returns>The added section.</returns>
        public static IDebugActionsSection AddSection(string name, object optionsObject, bool collapsed = false, int priority = 0) 
            => Instance.AddSectionInternal(name, optionsObject, collapsed, priority);
        
        /// <summary>
        /// Adds a collapsible section to the debug actions UI with specified options and priority.
        /// Using reflection, debug actions are going to be created for the options object.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <param name="optionsObject">Options associated with the section.</param>
        /// <param name="priority">The priority of the section.</param>
        /// <returns>The added section.</returns>
        public static IDebugActionsSection AddSection(string name, object optionsObject, int priority) 
            => AddSection(name, optionsObject, false, priority);
        
        /// <summary>
        /// Adds a non-collapsible section to the debug actions UI with specified options.
        /// Using reflection, debug actions are going to be created for the options object.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        /// <param name="optionsObject">Options associated with the section.</param>
        /// <param name="priority">The priority of the section.</param>
        /// <returns>The added non-collapsible section.</returns>
        public static IDebugActionsSection AddNonCollapsableSection(string name, object optionsObject, int priority = 0) 
            => Instance.AddNonCollapsableSectionInternal(name, optionsObject, priority);
        
        /// <summary>
        /// Removes a section from the debug actions UI.
        /// </summary>
        /// <param name="section">The section to be removed.</param>
        public static void RemoveSection(IDebugActionsSection section) 
            => Instance.RemoveSectionInternal(section);
        
        void ShowInternal(Node parent, bool grabFocus)
        {
            InstantiateDebugPanelViewUseCase.Execute(_cacheData, _debugPanelData, parent);
            ConnectSearchTextUseCase.Execute(_debugPanelData, _debugActionsData);
            ConnectClearSearchTextUseCase.Execute(_debugPanelData, _debugActionsData);
            InstantiateDebugActionsWidgetsUseCase.Execute(_debugPanelData, _debugActionsData);

            if (grabFocus)
            {
                StorePreviouslyFocusedControlUseCase.Execute(_debugPanelData, _focusData);
                TryGrabFocusOnFirstDebugActionWidgetUseCase.Execute(_debugActionsData);   
            }
        }
        
        void HideInternal()
        {
            ClearDebugActionsWidgetsUseCase.Execute(_debugActionsData);
            DestroyDebugPanelViewUseCase.Execute(_debugPanelData);
            TryReturnFocusToPreviouslyFocusedControlUseCase.Execute(_focusData);
        }
        
        bool IsVisibleInternal()
        {
            return HasDebugPanelViewInstanceUseCase.Execute(_debugPanelData);
        }

        IDebugActionsSection AddSectionInternal(string name, bool collapsed, int priority)
        {
            return AddDebugActionsSectionUseCase.Execute(
                _debugPanelData,
                _debugActionsData,
                name,
                true,
                collapsed,
                priority
            );
        }
        
        IDebugActionsSection AddNonCollapsableSectionInternal(string name, int priority)
        {
            return AddDebugActionsSectionUseCase.Execute(
                _debugPanelData,
                _debugActionsData,
                name,
                false,
                false,
                priority
            );
        }
        
        IDebugActionsSection AddSectionInternal(string name, object optionsObject, bool collapsed, int priority)
        {
            DebugActionsSection section = AddDebugActionsSectionUseCase.Execute(
                _debugPanelData,
                _debugActionsData,
                name,
                true,
                collapsed,
                priority
            );
            
            PopulateDebugActionsSectionFromOptionsObjectUseCase.Execute(section, optionsObject);
            
            return section;
        }
        
        IDebugActionsSection AddNonCollapsableSectionInternal(string name, object optionsObject, int priority)
        {
            DebugActionsSection section = AddDebugActionsSectionUseCase.Execute(
                _debugPanelData,
                _debugActionsData,
                name,
                false,
                false,
                priority
            );
            
            PopulateDebugActionsSectionFromOptionsObjectUseCase.Execute(section, optionsObject);
            
            return section;
        }
        
        void RemoveSectionInternal(IDebugActionsSection section)
        {
            RemoveDebugActionsSectionUseCase.Execute(_debugActionsData, section);
        }
    }   
}
