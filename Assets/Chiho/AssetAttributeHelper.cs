using System;
using System.IO;
using UnityEngine;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Chiho {
    public abstract class AbstractAssetAttribute : Attribute {
        protected abstract string CreateFileName(FieldInfo field);

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        internal static void ConnectMemberAssets<T>(object obj) where T : AbstractAssetAttribute {
            var t = obj.GetType();
            var fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var f in fields) {
                var attrs = f.GetCustomAttributes(typeof(T), false);
                if (attrs.Length == 0) {
                    continue;
                }

                var attr = attrs[0] as T;
                var prev = f.GetValue(obj);

                if (IsNullValue(prev)) {
                    var filename = attr.CreateFileName(f);
                    var asset = attr.FindAsset(f.FieldType, filename);
                    f.SetValue(obj, asset);
                }
            }
        }

        UnityEngine.Object FindAsset(Type t, string filename) {
#if UNITY_EDITOR
            var assetPath = FindAssetPath(filename);
            if (assetPath != null) {
                return AssetDatabase.LoadAssetAtPath(assetPath, t);
            } else {
                Debug.LogFormat("Cannot find {0}", filename);
                return null;
            }
#else
            return null;
#endif
        }

        string FindAssetPath(string name) {
#if UNITY_EDITOR
            // AssetDatabase 뒤질때는 확장자는 무시된다
            var filename = Path.GetFileNameWithoutExtension(name);
            var founds = AssetDatabase.FindAssets(filename);
            var assetPaths = new string[founds.Length];
            for(int i = 0; i < founds.Length; i++) {
                assetPaths[i] = AssetDatabase.GUIDToAssetPath(founds[i]);
            }

            // 확장자 포함 이름 일치하는것
            foreach(var assetPath in assetPaths) {
                var f = Path.GetFileName(assetPath);
                if (f == name) {
                    return assetPath;
                }
            }

            // 확장자 무시하고 이름 맞는거
            foreach (var assetPath in assetPaths) {
                var f = Path.GetFileNameWithoutExtension(assetPath);
                if (f == name) {
                    return assetPath;
                }
            }
#endif
            return null;
        }

        static bool IsNullValue(object o) {
            return (o == null || o.ToString() == "null");
        }
    }
}
