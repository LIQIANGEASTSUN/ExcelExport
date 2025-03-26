using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelExport
{
    public class WriteJsonCsAnalysis
    {
        private const string lb = "{";
        private const string rb = "}";
        private const string Assets = "\"Assets\"";
        private const string SubAssets = "\"SubAssets\"";
        private const string JsonAssets = "\"JsonAssets\"";

        private static List<KeyValuePair<string, string>> _list = new List<KeyValuePair<string, string>>();
        public static void Add(string fileName, string className)
        {
            Console.WriteLine("WriteJsonCsAnalysis Add:" + fileName + "   " + className);
            KeyValuePair<string, string> kv = new KeyValuePair<string, string>(fileName, className);
            _list.Add(kv);
        }

        public static void Write()
        {
            string fileName = "JsonCsAnalysis";
            string path = FileHandle.GetClientPath($"{fileName}.cs", FileType.CS);
            Console.WriteLine("WriteJsonCsAnalysis path:" + path);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using BettaSDK;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine($"public class JsonCsAnalysis {lb}");
            sb.AppendLine();
            sb.AppendLine($"    public const int TotalCount = {_list.Count};");
            sb.AppendLine($"    private Action OneLoadSuccess;");
            sb.AppendLine();
            sb.AppendLine($"    public void SetLoadCallBack(Action oneLoadSuccess)");
            sb.AppendLine($"    {lb}");
            sb.AppendLine($"        OneLoadSuccess = oneLoadSuccess;");
            sb.AppendLine($"    {rb}");
            sb.AppendLine();
            sb.AppendLine($"    public async void Analysis()");
            sb.AppendLine($"    {lb}");
            sb.AppendLine($"        await LoadAllJson();");
            sb.AppendLine($"    {rb}");
            sb.AppendLine();
            sb.AppendLine($"    private async Task LoadAllJson()");
            sb.AppendLine($"    {lb}");
                foreach (var kv in _list)
                {
                    sb.AppendLine($"        await LoadJson<{kv.Value}>(\"{kv.Key}\");");
                }
            sb.AppendLine($"    {rb}");
            sb.AppendLine();
            sb.AppendLine($"	public async Task LoadJson<T>(string fileName) where T : class, IJsonConfigBase");
            sb.AppendLine($"    {lb}");
            sb.AppendLine($"     	string path = FileUtils.CombinePath({Assets}, {SubAssets}, {JsonAssets}, fileName);");
            sb.AppendLine($"        AssetHandle<TextAsset> assetHandle = await ResourcesManager.Instance.LoadAssetASync<TextAsset>(path);");

            sb.AppendLine($"        if (null != assetHandle.Asset)");
            sb.AppendLine($"        {lb}");
            sb.AppendLine($"            DebugLoger.Log(\"LoadJson Complete:{ fileName}\");");
            sb.AppendLine($"            fileName = System.IO.Path.GetFileNameWithoutExtension(fileName);");
            sb.AppendLine($"            JsonConfigDatas.Instance.AddConfig<T>(fileName, assetHandle.Asset.text);");
            sb.AppendLine($"            OneLoadSuccess?.Invoke();");
            sb.AppendLine($"        {rb}");
            sb.AppendLine($"        else");
            sb.AppendLine($"        {lb}");
            sb.AppendLine($"             Debug.LogError(\"Load CSV fail: \" + path);");
            sb.AppendLine($"        {rb}");
            sb.AppendLine($"    {rb}");
            sb.AppendLine($"{rb}");

            FileWriteWithLine fileWriteWithLine = new FileWriteWithLine(path);
            fileWriteWithLine.AppendLine(sb.ToString());
            fileWriteWithLine.Close();
        }

    }
}
