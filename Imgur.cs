using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgurApi = Imgur.API;

namespace Gaku
{
    public static class Imgur
    {
        private static string ClientID { get; } = "";
        private static string ClientSecret { get; } = "";

        static ImgurClient _client = new ImgurClient(ClientID, ClientSecret);
        public static ImgurClient Client { get { return _client; } }

        static ImageEndpoint _endpoint;
        public static ImageEndpoint Endpoint {
            get {
                if (_endpoint == null)
                    _endpoint = new ImageEndpoint(_client);
                return _endpoint;
            }
        }
    }
}
