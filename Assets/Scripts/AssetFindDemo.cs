using Assets.Chiho;
using UnityEngine;
using Vexe.Runtime.Types;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace Assets.Scripts {
    class AssetFindDemo : BaseBehaviour {
        [Show]
        void Find_CustomAssetDB() {
            var founds = CustomAssetDatabase.FindAssets("AssetFindDemo");
            foreach(var found in founds) {
                var x = CustomAssetDatabase.GUIDToAssetPath(found);
                Debug.LogFormat("found : {0}", x);
            }
        }

        [Show]
        void Find_AssetDB() {
#if UNITY_EDITOR
            var founds = AssetDatabase.FindAssets("AssetFindDemo");
            foreach (var found in founds) {
                var x = AssetDatabase.GUIDToAssetPath(found);
                Debug.LogFormat("found : {0}", x);
            }
#endif
        }
    }
}
