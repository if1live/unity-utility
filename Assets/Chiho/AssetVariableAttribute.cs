using System.Reflection;

namespace Assets.Chiho {
    public class AssetVariableAttribute : AbstractAssetAttribute {
        readonly string ext;

        public AssetVariableAttribute() : this("") { }
        public AssetVariableAttribute(string ext) {
            this.ext = ext;
        }

        public static void ConnectMemberAssets(object obj) {
            ConnectMemberAssets<AssetVariableAttribute>(obj);
        }

        protected override string CreateFileName(FieldInfo field) {
            var varName = field.Name;
            if (ext == null || ext == "") {
                return varName;
            } else if (ext.StartsWith(".")) {
                return varName + ext;
            } else {
                return varName + "." + ext;
            }
        }
    }
}
