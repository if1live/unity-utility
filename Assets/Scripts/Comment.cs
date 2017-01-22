using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class Comment : MonoBehaviour {
        [SerializeField]
        [TextArea(2, 5)]
        string comment = "";
    }
}