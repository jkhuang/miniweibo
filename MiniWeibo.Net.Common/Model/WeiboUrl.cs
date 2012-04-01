namespace MiniWeibo.Net.Common
{
    public class WeiboUrl : WeiboEntity
    {
        public virtual string Value { get; set; }

        public WeiboUrl()
        {
            Initialize();
        }

        private void Initialize()
        {
            EntityType = WeiboEntityType.Url;
        }
    }
}
