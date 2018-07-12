using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogAnalyzerWeb.ElasticSearch;
using BlogAnalyzerWeb.Repositories;
using BlogAnalyzerWeb.Models;
// using BlogAnalyzerWeb.ViewModels;

namespace BlogAnalyzerWeb.Controllers
{
    public class PostsController : Controller 
    {
        private PostsRepository _repository;

        public PostsController(PostsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _repository.FindAll();

            return View();
        }
    }
}