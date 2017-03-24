using Assets.Chiho;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts {
    public class AssetVariableConnectSample : MonoBehaviour {
        [AssetVariable("png")]
        public Texture2D twitter_dark;

        [AssetVariable(".png")]
        public Texture2D icons_set_black;

        [AssetVariable]
        public AudioClip Click_Mechanical_00;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AssetVariableConnectSample))]
    public class AssetVariableConnectSampleEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            var script = (AssetVariableConnectSample)target;
            if (GUILayout.Button("Connect")) {
                AssetVariableAttribute.ConnectMemberAssets(script);
            }
        }
    }
#endif
}
