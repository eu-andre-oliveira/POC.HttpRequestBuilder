namespace POC.HttpRequestBuilder.Builder.Interfaces
{
    public interface IRequestBuilderPayload
    {
        IRequestBuilderHeader AddHeader(string headerName, string value);
        IRequestBuilderParameter AddParameter(string parameter, string value);
        Task<T> SendRequestAsync<T>();
    }
}
