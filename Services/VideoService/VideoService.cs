using Data.Generic_interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.VideoService
{
    public class VideoService : IVideoService
    {
        private readonly IRepository<Video> _videoRepository;
        public VideoService(IRepository<Video> repository) 
        {
            //repository = new Repository<Video>();
            _videoRepository = repository;
        }
        public async Task Create(Video video)
        {
            if (video != null)
            {
                await _videoRepository.Create(video);
            }
        }

        public async Task Delete(int id)
        {
            await _videoRepository.Delete(id);
        }

        public async Task<Video> GetVideoById(int? id)
        {
            if (id == null || _videoRepository == null)
            {
                return null;
            }
          return await _videoRepository.GetByID(id);
        }

        public async Task<List<Video>> GetVideoList()
        {
            return await _videoRepository.GetAll();
        }

        public async Task Update(Video video)
        {
            await _videoRepository.Update(video);
        }
    }
}
