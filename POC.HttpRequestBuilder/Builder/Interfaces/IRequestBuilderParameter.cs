using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.HttpRequestBuilder.Builder.Interfaces
{
    public interface IRequestBuilderParameter
    {       
        IRequestBuilderParameter AddParameter(string parameter, string value);
        IRequestBuilderHeader AddHeader(string headerName, string value);
        Task<T> SendRequestAsync<T>();
    }
}
