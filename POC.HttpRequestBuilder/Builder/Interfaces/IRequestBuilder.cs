namespace POC.HttpRequestBuilder.Builder.Interfaces
{
    public interface IRequestBuilder
    {
        IRequestBuilderUri WithUri(string path);
        IRequestBuilderMethod WithHttpMethod(HttpMethod httpMethod);
        IRequestBuilderPayload AddPayload(string payload);
        IRequestBuilderParameter AddParameter(string parameter, string value);
        IRequestBuilderHeader AddHeader(string headerName, string value);    
    }
}
