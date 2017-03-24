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

        internal override void TryAssign(FieldInfo field, object obj) {
            var asset = FindAsset(field.FieldType, v);
            field.SetValue(obj, asset);
        }
    }
}