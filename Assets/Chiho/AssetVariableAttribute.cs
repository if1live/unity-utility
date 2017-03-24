using System.Reflection;

namespace Assets.Chiho {
    public class AssetVariableAttribute : AbstractAssetAttribute {
        readonly string ext;

        public AssetVariableAttribute() : this("") { }
        public AssetVariableAttribute(string ext) {
            this.ext = ext;
        }

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void ConnectMemberAssets(object obj) {
            ConnectMemberAssets<AssetVariableAttribute>(obj);
        }

        internal override void TryAssign(FieldInfo field, object obj) {
            var varName = field.Name;
            var filename = CreateFileName(varName, ext);

            var asset = FindAsset(field.FieldType, filename);
            field.SetValue(obj, asset);
        }

        static string CreateFileName(string varName, string ext) {
            if(ext == null || ext == "") {
                return varName;
            } else if (ext.StartsWith(".")) {
                return varName + ext;
            } else {
                return varName + "." + ext;
            }
        }
    }
}
