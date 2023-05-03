namespace GameStore.Client.HttpClientFolder
{
    public class PublicClient
    {
        public HttpClient client { get; set; }

        public PublicClient(HttpClient client)
        {
            this.client = client;
        }

    }
}
