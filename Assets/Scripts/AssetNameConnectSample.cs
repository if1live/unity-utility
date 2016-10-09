using Assets.Chiho;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts {
    public class AssetNameConnectSample : MonoBehaviour {
        [AssetName("Click_Heavy_00.mp3")]
        public AudioClip clickA;

        [AssetName("Click_Mechanical_00.mp3")]
        public AudioClip clickB;

        [AssetName("twitter_dark.png")]
        public Texture2D icon;

        [AssetName("icons_set_black.png")]
        public Texture2D iconSet;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AssetNameConnectSample))]
    public class AssetNameConnectorEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            var script = (AssetNameConnectSample)target;
            if(GUILayout.Button("Connect")) {
                AssetNameAttribute.ConnectMemberAssets(script);
            }
        }
    }
#endif
}