using Api.Gateway.Grupo1.Dto;
using Api.Gateway.Grupo1.Utilitarios;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace Api.Gateway.Grupo1.Aggregator
{
    public class UserPostAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            string NumeroLinea = "";
            try
            {
                 NumeroLinea = "1";
                if (responses.Any(x => x.Items.Errors().Count > 0))
                {
                    return new DownstreamResponse(null, System.Net.HttpStatusCode.BadRequest, (List<Header>)null, null);
                }
                NumeroLinea = "2";
                var USER = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
                var POST = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

                NumeroLinea = "3";
                var userObj = USerializeObjeto.deserializeJsom_ObjetoList<UserDto>(USER);
                NumeroLinea = "4";
                var postObj = USerializeObjeto.deserializeJsom_ObjetoList<PostDto>(POST);

                foreach (var itemUser in userObj)
                {


                    foreach (var itemPost in postObj)
                    {
                        if (itemUser.id == itemPost.userId)
                        {
                            itemUser.posts.Add(itemPost);
                        }

                    }
                }

                NumeroLinea = "5";
                var contentBody = JsonConvert.SerializeObject(userObj);

                var stringContent = new StringContent(contentBody)
                {
                    Headers = { ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") }
                };
                NumeroLinea = "6";
                return new DownstreamResponse(stringContent, System.Net.HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");


            }
            catch (Exception ex)
            {
                var stringContent = new StringContent(ex.Message + " -- " + NumeroLinea)
                {
                    Headers = { ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") }
                };
                return new DownstreamResponse(stringContent, System.Net.HttpStatusCode.InternalServerError,new List<KeyValuePair<string, IEnumerable<string>>>(), "ERROR");
            }
        }
    }
}
