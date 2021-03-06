﻿// BingSearchSample.cs
// DynamicRest provides REST service access using C# 4.0 dynamic programming.
// The latest information and code for the project can be found at
// https://github.com/NikhilK/dynamicrest
//
// This project is licensed under the BSD license. See the License.txt file for
// more information.
//

using System;
using DynamicRest;
using DynamicRest.HTTPInterfaces.WebWrappers;
using DynamicRest.Json;

namespace Application {

    internal static class BingSearchSample {

        public static void Run() {

            var templatedUriRequestBuilder = new TemplatedUriRequestBuilder(new RequestFactory());
            templatedUriRequestBuilder.Uri = Services.BingSearchUri;

            dynamic bingSearch = new RestClient(templatedUriRequestBuilder, new ResponseProcessor(new StandardResultBuilder(RestService.Json)));
            bingSearch.appID = Services.BingApiKey;

            Console.WriteLine("Searching Bing for 'seattle'...");

            dynamic searchOptions = new JsonObject();
            searchOptions.Query = "seattle";
            searchOptions.Sources = new string[] { "Web", "Image" };
            searchOptions.Web = new JsonObject("Count", 4);
            searchOptions.Image = new JsonObject("Count", 2);

            dynamic search = bingSearch.invoke(searchOptions);
            dynamic searchResponse = search.Result.SearchResponse;

            foreach (dynamic item in searchResponse.Web.Results) {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.DisplayUrl);
                Console.WriteLine();
            }
            foreach (dynamic item in searchResponse.Image.Results) {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.MediaUrl);
                Console.WriteLine();
            }
        }
    }
}
