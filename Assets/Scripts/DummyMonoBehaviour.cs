using UnityEngine;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts {
    interface IDummyContainer {}

    class DummyMonoBehaviour : MonoBehaviour, IDummyContainer {
        void Awake() {
            foo_interface = this;
        }

        public void PrintLog() {
            Debug.Log("method invoked - mono behaviour");
        }

        [Header("foo")]
        public IDummyContainer foo_interface = null;

        [Header("bar")]
        [Range(0, 10)]
        public int bar_int = 3;
        [Range(0, 1.0f)]
        public float bar_float = 0.5f;
    }

#if UNITY_EDITOR
    [CanEditMultipleObjects]
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
