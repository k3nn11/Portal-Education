using Data.DbInitializer;
using Data.Models;
using Services.MaterialService;
using Data.Generic_interface;

namespace Services.ArticleService
{
    public class ArticleService : IArticleService
    {
        //private readonly PortalContext _portalContext;
        private readonly IRepository<Article> _articleRepository;
        public ArticleService(IRepository<Article> repository) 
        {
            _articleRepository = repository;
        }


        public async Task Create(Article article)
        {
            if (article != null)
            {
                await _articleRepository.Create(article).ConfigureAwait(false);
            }       
        }

        public async  Task Delete(int id)
        {

            if (id == 0 && _articleRepository == null)
            {
                return;
            }
            await _articleRepository.Delete(id).ConfigureAwait(true);
        }

        public async Task<List<Article>> GetArticleList()
        {
            return await _articleRepository.GetAll().ConfigureAwait(true);
        }

        public async Task<Article> GetArticleById(int? id)
        {
            return await _articleRepository.GetByID(id);
        }

        public async Task Update(Article article)
        {
            await _articleRepository.Update( article);
        }
    }
}
