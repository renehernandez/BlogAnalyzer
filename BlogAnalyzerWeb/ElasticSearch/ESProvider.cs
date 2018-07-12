using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Nest;
using BlogAnalyzerWeb.Models;

namespace BlogAnalyzerWeb.ElasticSearch
{
    public class ESProvider
    {

        public ElasticClient Client { get; private set; }
        
        public string DefaultIndex { get; private set; }
        
        public ESProvider(IOptionsSnapshot<ESOptions> options)
        {
            var settings = new ConnectionSettings(new Uri(options.Value.URL))
                .DefaultIndex(options.Value.DefaultIndex);

            this.Client = new ElasticClient(settings);
            this.DefaultIndex = options.Value.DefaultIndex;
            EnsureIndexWithMapping<Post>(this.DefaultIndex);
        }

        public void EnsureIndexWithMapping<T>(string indexName = null, Func<PutMappingDescriptor<T>, PutMappingDescriptor<T>> customMapping = null) where T: class
        {
            if (String.IsNullOrEmpty(indexName)) 
                indexName = this.DefaultIndex;

            // Map type T to that index
            this.Client.ConnectionSettings.DefaultIndices.Add(typeof(T), indexName);

            // Does the index exists?
            var indexExistsResponse = this.Client.IndexExists(new IndexExistsRequest(indexName));

            if (!indexExistsResponse.IsValid) 
                throw new InvalidOperationException(indexExistsResponse.DebugInformation);

            // If exists, return
            if (indexExistsResponse.Exists) 
                return;
            
            throw new InvalidOperationException(indexExistsResponse.DebugInformation);
        }

    }
}