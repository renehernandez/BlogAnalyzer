using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogAnalyzerWeb.Models;
using BlogAnalyzerWeb.ElasticSearch;
using Nest;

namespace BlogAnalyzerWeb.Repositories
{
    public class PostsRepository
    {
        private readonly ESProvider _esProvider;

        private static int MaxSize = 100_000;

        public PostsRepository(ESProvider eSProvider)
        {
            _esProvider = eSProvider;
        }

        public async Task<IEnumerable<Post>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}