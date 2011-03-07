﻿using System.Net;
using DynamicRest.HTTPInterfaces;
using DynamicRest.Json;

namespace DynamicRest
{
    public interface IBuildRequests
    {
        string Body { get; set; }
        ICredentials Credentials { set; }
        string ContentType { get; set; }
        string Uri { set; }
        ParametersStore ParametersStore { get; set; }
        string AcceptHeader { get; set; }

        void AddHeader(HttpRequestHeader headerType, string value);
        IHttpRequest CreateRequest(string operationName, JsonObject parameters);
    }
}