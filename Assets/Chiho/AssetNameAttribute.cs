using System.IO;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
using System.Reflection;
#endif

namespace Assets.Chiho {
    public class AssetNameAttribute : Attribute {
        string v;

        public AssetNameAttribute(string name) {
            this.v = name;
        }

#if UNITY_EDITOR
        public UnityEngine.Object FindAsset(Type t) {
            var assetPath = FindAssetPath(v);
            if (assetPath != null) {
                return AssetDatabase.LoadAssetAtPath(assetPath, t);
            } else {
                Debug.LogFormat("Cannot find {0}", v);
                return null;
            }
        }

        public static void ConnectMemberAssets(object obj) {
            var t = obj.GetType();
            var fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var f in fields) {
                var attrs = f.GetCustomAttributes(typeof(AssetNameAttribute), false);
                if (attrs.Length == 0) {
                    continue;
                }

                var attr = attrs[0] as AssetNameAttribute;
                var prev = f.GetValue(obj);
                var x = prev.GetType();
                if (prev == null || prev.ToString() == "null") {
                    var asset = attr.FindAsset(f.FieldType);
                    f.SetValue(obj, asset);
                }
            }
        }

        static string FindAssetPath(string name) {
            var filename = Path.GetFileNameWithoutExtension(name);
            var founds = AssetDatabase.FindAssets(filename);
            foreach (var guid in founds) {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                if (assetPath.EndsWith(name)) {
                    return assetPath;
                }
            }
            return null;
        }
    }
#endif
}