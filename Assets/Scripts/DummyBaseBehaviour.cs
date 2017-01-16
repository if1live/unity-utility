using UnityEngine;
using Vexe.Runtime.Types;

namespace Assets.Scripts {
    [DefineCategory("foo", Pattern = "^foo_")]
    [DefineCategory("bar", Pattern = "^bar_")]
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

        public int bar_int = 0;
        public float bar_float = 0;
    }
}
