using System.IO;
using UnityEditor;
using UnityEngine;
using SpeedDrop.Data;

namespace SpeedDrop.Editor
{
    public static class SpeedDropAssetMenu
    {
        private const string BalancePath = "Assets/_Project/ScriptableObjects/Balance";
        private const string StagePath = "Assets/_Project/ScriptableObjects/Stage";

        [MenuItem("Speed Drop/Create Default Player Config")]
        public static void CreatePlayerConfig()
        {
            EnsureFolder(BalancePath);
            CreateAsset<PlayerConfig>($"{BalancePath}/PlayerConfig.asset");
        }

        [MenuItem("Speed Drop/Create Default Stage Config")]
        public static void CreateStageConfig()
        {
            EnsureFolder(StagePath);
            CreateAsset<StageConfig>($"{StagePath}/StageConfig.asset");
        }

        private static void CreateAsset<T>(string path) where T : ScriptableObject
        {
            if (File.Exists(path))
            {
                Selection.activeObject = AssetDatabase.LoadAssetAtPath<T>(path);
                return;
            }

            T asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            Selection.activeObject = asset;
        }

        private static void EnsureFolder(string path)
        {
            string[] parts = path.Split('/');
            string current = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                string next = $"{current}/{parts[i]}";
                if (!AssetDatabase.IsValidFolder(next))
                {
                    AssetDatabase.CreateFolder(current, parts[i]);
                }
                current = next;
            }
        }
    }
}
