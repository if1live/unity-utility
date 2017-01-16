using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts {
    class DummyMonoBehaviour : MonoBehaviour {
        public void PrintLog() {
            Debug.Log("method invoked - mono behaviour");
        }

        [Header("foo")]
        public int foo_int = 0;
        public float foo_float = 0;

        [Header("bar")]
        public int bar_int = 0;
        public float bar_float = 0;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DummyMonoBehaviour))]
    class DummyMonoBehaviourEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            var script = (DummyMonoBehaviour)target;
            if(GUILayout.Button("InvokeMethod")) {
                script.PrintLog();
            }
        }
    }
#endif
}
