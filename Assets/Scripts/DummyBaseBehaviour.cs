using UnityEngine;
using Vexe.Runtime.Types;

namespace Assets.Scripts {
    [DefineCategory("bar", Pattern = "^bar_")]
    [DefineCategory("foo", Pattern = "^foo_")]
    class DummyBaseBehaviour : BaseBehaviour, IDummyContainer {
        void Awake() {
            foo_interface = this;
        }

        [Show]
        void PrintLog() {
            Debug.Log("method invoked - base behaviour");
        }

        [Show]
        void PrintDebugLog() {
            dLog("debug log");
            dLogFormat("{0} {1} {2}", "debug", "log", "+ format");
        }

        public IDummyContainer foo_interface = null;

        [iSlider(0, 10)]
        public int bar_int = 3;
        [fSlider(0, 1.0f)]
        public float bar_float = 0.5f;
    }
}
