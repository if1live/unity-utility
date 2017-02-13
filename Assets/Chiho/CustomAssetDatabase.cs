#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Chiho {
    class CustomAssetDatabase {
        public static string GUIDToAssetPath(string guid) {
#if UNITY_EDITOR
            return AssetDatabase.GUIDToAssetPath(guid);
#else
            return null;
#endif

        }
        public static string[] FindAssets(string filter) {
#if UNITY_EDITOR
            return AssetDatabase.FindAssets(filter);
#else
            return null;
#endif
        }
    }
}
