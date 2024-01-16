using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MaterialService
{
    public interface IArticleService
    {
        Task Create(Article articles);

        Task Update(Article article);

        Task Delete(int id);

        Task<List<Article>> GetArticleList();

        Task<Article> GetArticleById(int? id);
    }
}
