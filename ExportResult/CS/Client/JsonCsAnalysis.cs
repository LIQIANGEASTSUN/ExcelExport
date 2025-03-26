using BettaSDK;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class JsonCsAnalysis {

    public const int TotalCount = 11;
    private Action OneLoadSuccess;

    public void SetLoadCallBack(Action oneLoadSuccess)
    {
        OneLoadSuccess = oneLoadSuccess;
    }

    public async void Analysis()
    {
        await LoadAllJson();
    }

    private async Task LoadAllJson()
    {
        await LoadJson<ArticleCfg>("ArticleCfg.json");
        await LoadJson<ArticleCfg>("ArticleCfg_1.json");
        await LoadJson<ArticleCfg>("ArticleCfg_2.json");
        await LoadJson<BehaviortreeCfg>("BehaviortreeCfg.json");
        await LoadJson<CharacterCfg>("CharacterCfg.json");
        await LoadJson<SpriteCfg>("SpriteCfg.json");
        await LoadJson<SpriteGraphicCfg>("SpriteGraphicCfg.json");
        await LoadJson<TextLocalizationCfg>("TextLocalizationCfg.json");
        await LoadJson<UiBubbleCfg>("UiBubbleCfg.json");
        await LoadJson<UiPanelCfg>("UiPanelCfg.json");
        await LoadJson<XassetCfg>("XassetCfg.json");
    }

	public async Task LoadJson<T>(string fileName) where T : class, IJsonConfigBase
    {
     	string path = FileUtils.CombinePath("Assets", "SubAssets", "JsonAssets", fileName);
        AssetHandle<TextAsset> assetHandle = await ResourcesManager.Instance.LoadAssetASync<TextAsset>(path);
        if (null != assetHandle.Asset)
        {
            DebugLoger.Log("LoadJson Complete:" + fileName);
            fileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            JsonConfigDatas.Instance.AddConfig<T>(fileName, assetHandle.Asset.text);
            OneLoadSuccess?.Invoke();
        }
        else
        {
             Debug.LogError("Load CSV fail: " + path);
        }
    }
}

