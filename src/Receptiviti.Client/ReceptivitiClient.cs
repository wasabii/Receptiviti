using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Receptiviti.Client.Model;
using Receptiviti.Client.Util;

namespace Receptiviti.Client
{

    /// <summary>
    /// Provides access to the Receptiviti API.
    /// </summary>
    public class ReceptivitiClient
    {

        /// <summary>
        /// Default public URI of the Receptiviti service.
        /// </summary>
        public const string DEFAULT_URI = "https://api.receptiviti.com/api";

        readonly HttpClient http;
        Uri uri;
        string apiKey;
        string apiSecretKey;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        ReceptivitiClient()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="uri"></param>
        /// <param name="apiKey"></param>
        /// <param name="apiSecretKey"></param>
        public ReceptivitiClient(HttpClient http, Uri uri, string apiKey, string apiSecretKey)
            : this()
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(uri != null);
            Contract.Requires<ArgumentNullException>(apiKey != null);
            Contract.Requires<ArgumentNullException>(apiSecretKey != null);

            this.http = http;
            Uri = uri;
            ApiKey = apiKey;
            ApiSecretKey = apiSecretKey;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="apiKey"></param>
        /// <param name="apiSecretKey"></param>
        public ReceptivitiClient(Uri uri, string apiKey, string apiSecretKey)
            : this(new HttpClient(), uri, apiKey, apiSecretKey)
        {
            Contract.Requires<ArgumentNullException>(uri != null);
            Contract.Requires<ArgumentNullException>(apiKey != null);
            Contract.Requires<ArgumentNullException>(apiSecretKey != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="http"></param>
        /// <param name="apiKey"></param>
        /// <param name="apiSecretKey"></param>
        public ReceptivitiClient(HttpClient http, string apiKey, string apiSecretKey)
            : this(http, new Uri(DEFAULT_URI), apiKey, apiSecretKey)
        {
            Contract.Requires<ArgumentNullException>(http != null);
            Contract.Requires<ArgumentNullException>(apiKey != null);
            Contract.Requires<ArgumentNullException>(apiSecretKey != null);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="apiSecretKey"></param>
        public ReceptivitiClient(string apiKey, string apiSecretKey)
            : this(new Uri(DEFAULT_URI), apiKey, apiSecretKey)
        {
            Contract.Requires<ArgumentNullException>(apiKey != null);
            Contract.Requires<ArgumentNullException>(apiSecretKey != null);
        }

        /// <summary>
        /// Gets the URI prefix of the Receptiviti API.
        /// </summary>
        public Uri Uri
        {
            get { return uri; }
            set { Contract.Requires<ArgumentNullException>(value != null); uri = value; }
        }

        /// <summary>
        /// Gets the configured authentication key.
        /// </summary>
        public string ApiKey
        {
            get { return apiKey; }
            set { Contract.Requires<ArgumentNullException>(value != null); apiKey = value; }
        }

        /// <summary>
        /// Gets the configured authentication secret key.
        /// </summary>
        public string ApiSecretKey
        {
            get { return apiSecretKey; }
            set { Contract.Requires<ArgumentNullException>(value != null); apiSecretKey = value; }
        }

        /// <summary>
        /// Creates a new <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        HttpRequestMessage CreateMessage(HttpMethod method, Uri requestUri)
        {
            Contract.Requires<ArgumentNullException>(requestUri != null);

            var message = new HttpRequestMessage(method, requestUri);
            message.Headers.Add("X-API-KEY", ApiKey);
            message.Headers.Add("X-API-SECRET-KEY", ApiSecretKey);
            message.Headers.Accept.Clear();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return message;
        }

        /// <summary>
        /// Creates a new <see cref="HttpRequestMessage"/>.
        /// </summary>
        /// <typeparam name="TContent"></typeparam>
        /// <param name="method"></param>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        HttpRequestMessage CreateMessage<TContent>(HttpMethod method, Uri requestUri, TContent content)
        {
            Contract.Requires<ArgumentNullException>(requestUri != null);

            var message = CreateMessage(method, requestUri);
            message.Content = new StringContent(JObject.FromObject(content).ToString(), Encoding.UTF8, "application/json");
            return message;
        }

        /// <summary>
        /// Parses the given response body into the given object type.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        async Task<TResult> ParseResponseBody<TResult>(HttpResponseMessage response)
        {
            Contract.Requires<ArgumentNullException>(response != null);

            var s = await response.Content.ReadAsStringAsync();
            var j = JToken.Parse(s);
            var o = j.ToObject<TResult>();

            return o;
        }

        /// <summary>
        /// Handles the response message, extracting the proper result and throwing exceptions where required.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        async Task<TResult> HandleResponse<TResult>(HttpResponseMessage response)
        {
            Contract.Requires<ArgumentNullException>(response != null);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    // check for matching content type
                    if (response.Content.Headers.ContentType.MediaType != "application/hal+json")
                        throw new ReceptivitiException(
                            response.StatusCode,
                            "Response Content-Type not 'application/hal+json'");

                    // parse final response body
                    return await ParseResponseBody<TResult>(response);
                }
                else
                    throw new ReceptivitiException(
                        response.StatusCode,
                        await ParseResponseBody<ReceptivitiError>(response));
            }
            catch (HttpRequestException e)
            {
                if (response.Content != null ||
                    response.Content.Headers.ContentType.MediaType == "application/hal+json")
                    throw new ReceptivitiException(
                        response.StatusCode,
                        await ParseResponseBody<ReceptivitiError>(response),
                        e);
                else
                    throw new ReceptivitiException(e);
            }
        }

        /// <summary>
        /// Sends the <paramref name="request"/> and handles the result.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        async Task<TResult> SendAsync<TResult>(HttpRequestMessage request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

            using (var response = await http.SendAsync(request))
                return await HandleResponse<TResult>(response);
        }

        /// <summary>
        /// Extracts the X-Total-Count header from a response.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        int GetTotalCount(HttpResponseMessage response)
        {
            Contract.Requires<ArgumentNullException>(response != null);

            return response.Headers.GetValues("X-Total-Count")
                .Where(i => i != null)
                .Select(i => Convert.ToInt32(i))
                .FirstOrDefault();
        }

        /// <summary>
        /// Sends the <paramref name="request"/> and returns many of the results.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        async Task<Many<TResult>> SendWithManyAsync<TResult>(HttpRequestMessage request)
        {
            Contract.Requires<ArgumentNullException>(request != null);

            using (var response = await http.SendAsync(request))
                return new Many<TResult>(await HandleResponse<TResult[]>(response), GetTotalCount(response));
        }

        /// <summary>
        /// Analyze LSM Score between 2 people.
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <param name="language"></param>
        /// <param name="tags"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public async Task<LsmScoreResult> GetLsmScore(string person1, string person2, Language? language = null, string[] tags = null, DateTime? fromDate = null, DateTime? toDate = null)
        {
            Contract.Requires<ArgumentNullException>(person1 != null);
            Contract.Requires<ArgumentNullException>(person2 != null);

            // build URI
            var urib = new UriBuilder(Uri.Combine("lsm_score"));
            urib.AppendQuery("person1", person1);
            urib.AppendQuery("person2", person2);
            urib.AppendQueryIfNotNull("language", language?.ToEnumString());
            urib.AppendQueryIfNotNull("tags", tags);
            urib.AppendQueryIfNotNull("from_date", fromDate);
            urib.AppendQueryIfNotNull("to_date", toDate);

            using (var request = CreateMessage(HttpMethod.Get, urib.Uri))
                return await SendAsync<LsmScoreResult>(request);
        }

        /// <summary>
        /// Get Person List
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tags"></param>
        /// <param name="gender"></param>
        /// <param name="clientReferenceId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<Many<Person>> GetPersons(string name = null, string[] tags = null, int? gender = null, string clientReferenceId = null, int? limit = null, int? offset = null)
        {
            var urib = new UriBuilder(Uri.Combine("person"));
            urib.AppendQueryIfNotNull("name", name);
            urib.AppendQueryIfNotNull("tags", tags);
            urib.AppendQueryIfNotNull("gender", gender);
            urib.AppendQueryIfNotNull("client_reference_id", clientReferenceId);
            urib.AppendQueryIfNotNull("limit", limit);
            urib.AppendQueryIfNotNull("offset", offset);

            using (var request = CreateMessage(HttpMethod.Get, urib.Uri))
                return await SendWithManyAsync<Person>(request);
        }

        /// <summary>
        /// Create Person.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<Person> PostPerson(CreatePersonRequest payload)
        {
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Post, Uri.Combine("person"), payload))
                return await SendAsync<Person>(request);
        }

        /// <summary>
        /// Get Person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> GetPerson(string id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            using (var request = CreateMessage(HttpMethod.Get, Uri.Combine("person").Combine(id)))
                return await SendAsync<Person>(request);
        }

        /// <summary>
        /// Update Person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<Person> PutPerson(string id, UpdatePersonRequest payload)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Put, Uri.Combine("person").Combine(id), payload))
                return await SendAsync<Person>(request);
        }

        /// <summary>
        /// Analyze writing sample for a Person.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="targetDate"></param>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        public async Task<PersonProfile> GetPersonProfile(string id, DateTime? targetDate = null, DateTime? fromDate = null)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            var urib = new UriBuilder(Uri.Combine("person").Combine(id).Combine("profile"));
            urib.AppendQueryIfNotNull("target_date", targetDate);
            urib.AppendQueryIfNotNull("from_date", fromDate);

            using (var request = CreateMessage(HttpMethod.Get, urib.Uri))
                return await SendAsync<PersonProfile>(request);
        }

        /// <summary>
        /// Append tags to a Person's tag list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<Person> DeletePersonTags(string id, UpdatePersonTagsRequest payload)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Delete, Uri.Combine("person").Combine(id).Combine("tags"), payload))
                return await SendAsync<Person>(request);
        }

        /// <summary>
        /// Append tags to a Person's tag list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<Person> PutPersonTags(string id, UpdatePersonTagsRequest payload)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Put, Uri.Combine("person").Combine(id).Combine("tags"), payload))
                return await SendAsync<Person>(request);
        }

        /// <summary>
        /// Get writing samples.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<Many<WritingSample>> GetPersonWritingSamples(string id, DateTime? fromDate = null, DateTime? toDate = null, string[] tags = null)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            var urib = new UriBuilder(Uri.Combine("person").Combine(id).Combine("profile"));
            urib.AppendQueryIfNotNull("from_date", fromDate);
            urib.AppendQueryIfNotNull("to_date", fromDate);
            urib.AppendQueryIfNotNull("tags", tags);

            using (var request = CreateMessage(HttpMethod.Get, urib.Uri))
                return await SendWithManyAsync<WritingSample>(request);
        }

        /// <summary>
        /// Post writing sample.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<WritingSample> PostPersonWritingSample(string id, WritingSampleRequest payload)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Post, Uri.Combine("person").Combine(id).Combine("writing_samples"), payload))
                return await SendAsync<WritingSample>(request);
        }

        /// <summary>
        /// Pings the service.
        /// </summary>
        /// <returns></returns>
        public async Task<Ping> GetPing()
        {
            using (var request = CreateMessage(HttpMethod.Get, Uri.Combine("ping")))
                return await SendAsync<Ping>(request);
        }

        /// <summary>
        /// Get writing sample.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WritingSample> GetWritingSample(string id)
        {
            Contract.Requires<ArgumentNullException>(id != null);

            using (var request = CreateMessage(HttpMethod.Get, Uri.Combine("writing_sample").Combine(id)))
                return await SendAsync<WritingSample>(request);
        }

        /// <summary>
        /// Delete tags from a Writing Sample's tag list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<WritingSample> DeleteWritingSampleTags(string id, UpdateWritingSampleTagsRequest payload)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Delete, Uri.Combine("writing_sample").Combine(id).Combine("tags"), payload))
                return await SendAsync<WritingSample>(request);
        }

        /// <summary>
        /// Append tags to a Writing Sample's tag list.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async Task<WritingSample> PutWritingSampleTags(string id, UpdateWritingSampleTagsRequest payload)
        {
            Contract.Requires<ArgumentNullException>(id != null);
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Put, Uri.Combine("writing_sample").Combine(id).Combine("tags"), payload))
                return await SendAsync<WritingSample>(request);
        }

        /// <summary>
        /// Creates a new writing sample.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [Obsolete]
        public async Task<WritingSample> PostWritingSample(WritingSampleRequest payload)
        {
            Contract.Requires<ArgumentNullException>(payload != null);

            using (var request = CreateMessage(HttpMethod.Post, Uri.Combine("writing_sample"), payload))
                return await SendAsync<WritingSample>(request);
        }

    }

}
