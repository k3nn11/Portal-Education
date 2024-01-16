using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services.VideoService
{
    public interface IVideoService
    {
        Task Create(Video videos);

        Task Update(Video video);

        Task Delete(int id);

        Task<List<Video>> GetVideoList();

        Task<Video> GetVideoById(int? id);
    }
}
