using System.Reflection;
#if UNITY_EDITOR
#endif

namespace Assets.Chiho {
    public class AssetNameAttribute : AbstractAssetAttribute {
        readonly string v;

        public AssetNameAttribute(string name) {
            this.v = name;
        }

        public static void ConnectMemberAssets(object obj) {
            ConnectMemberAssets<AssetNameAttribute>(obj);
        }

        protected override string CreateFileName(FieldInfo field) {
            return v;
        }
    }
}