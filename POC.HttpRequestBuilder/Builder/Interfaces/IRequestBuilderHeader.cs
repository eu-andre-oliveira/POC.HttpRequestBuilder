using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.HttpRequestBuilder.Builder.Interfaces
{
    public interface IRequestBuilderHeader
    {
        IRequestBuilderHeader AddHeader(string headerName, string value);
        IRequestBuilderParameter AddParameter(string parameter, string value);
        Task<T> SendRequestAsync<T>();
    }
}
