using BettaSDK;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class JsonCsAnalysis {
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
        await LoadJson<addressable>("addressable.json");
        await LoadJson<article>("article.json");
        await LoadJson<character>("character.json");
        await LoadJson<labyrinth1001>("labyrinth1001.json");
        await LoadJson<level>("level.json");
        await LoadJson<map_config>("map_config.json");
        await LoadJson<skill>("skill.json");
        await LoadJson<sprite>("sprite.json");
        await LoadJson<table_behaviortree>("table_behaviortree.json");
        await LoadJson<table_text_localization>("table_text_localization.json");
    }

	public async Task LoadJson<T>(string fileName) where T : class, IJsonConfigBase
    {
     	string path = FileUtils.CombinePath("Assets", "SubAssets", "JsonAssets", fileName);
        AssetHandle<TextAsset> assetHandle = await ResourcesManager.Instance.LoadAssetASync<TextAsset>(path);
        if (null != assetHandle.Asset)
        {
            DebugLoger.Log("LoadJson Complete:JsonCsAnalysis");
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

