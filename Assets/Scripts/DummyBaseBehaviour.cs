using UnityEditor;
using UnityEngine;
using Vexe.Runtime.Types;

namespace Assets.Scripts {
    [DefineCategory("bar", Pattern = "^bar_")]
    [DefineCategory("foo", Pattern = "^foo_")]
    class DummyBaseBehaviour : BaseBehaviour {
        [Show]
        void PrintLog() {
            Debug.Log("method invoked - base behaviour");
        }

        [Show]
        void PrintDebugLog() {
            dLog("debug log");
            dLogFormat("{0} {1} {2}", "debug", "log", "+ format");
        }

        public int foo_int = 0;
        public float foo_float = 0;

        [iSlider(0, 10)]
        public int bar_int = 3;
        [fSlider(0, 1.0f)]
        public float bar_float = 0.5f;
    }
}
