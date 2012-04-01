namespace MiniWeibo.Net.Common
{
    using Hammock;

    public partial class WeiboService
    {
        private readonly RestClient _searchStreamingClient;
        private readonly RestClient _userStreamingClient;

        public virtual void CancelStreaming()
        {
            if (_userStreamingClient != null)
            {
                _userStreamingClient.CancelStreaming();
            }

            if (_searchStreamingClient != null)
            {
                _searchStreamingClient.CancelStreaming();
            }
        }
    }
}
