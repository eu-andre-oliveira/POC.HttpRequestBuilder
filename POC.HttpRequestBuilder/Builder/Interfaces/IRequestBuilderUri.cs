using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.HttpRequestBuilder.Builder.Interfaces
{
    public interface IRequestBuilderUri
    {
        IRequestBuilderMethod WithHttpMethod(HttpMethod httpMethod);

    }
}
