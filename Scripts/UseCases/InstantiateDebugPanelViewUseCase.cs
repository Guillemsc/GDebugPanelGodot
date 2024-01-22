using System;
using GDebugPanelGodot.Constants;
using GDebugPanelGodot.Datas;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.UseCases;

public static class InstantiateDebugPanelViewUseCase
{
    public static void Execute(CacheData cacheData, DebugPanelData debugPanelData, Node parent)
    {
        if (debugPanelData.DebugPanelView != null)
        {
            return;
        }
        
        cacheData.DebugPanelViewScene ??= ResourceLoader.Load(DebugPanelViewConstants.DebugPanelViewPath) as PackedScene;

        if (cacheData.DebugPanelViewScene is null)
        {
            throw new Exception(
                $"Tried to instantiate {nameof(DebugPanelView)} but scene asset could not be found at {DebugPanelViewConstants.DebugPanelViewPath}"
            );
        }

        DebugPanelView debugPanelView = cacheData.DebugPanelViewScene.Instantiate<DebugPanelView>();
        debugPanelView.SetParent(parent);

        debugPanelData.DebugPanelView = debugPanelView;
    }
}