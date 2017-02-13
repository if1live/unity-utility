using UnityEngine;

namespace Assets.Scripts {
    public class Comment : MonoBehaviour {
        [SerializeField]
        [TextArea(2, 5)]
        string comment = "";
    }
}
