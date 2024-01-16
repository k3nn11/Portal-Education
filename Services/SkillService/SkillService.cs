using Data.Generic_interface;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.SkillService
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;
        public SkillService(IRepository<Skill> repository) 
        {
            //repository = new Repository<Skill>();
            _skillRepository = repository;
        }
        public async Task Create(Skill skill)
        {
          if (skill != null)
            {
                await _skillRepository.Create(skill);
            }
        }

        public async Task Delete(int id)
        {
             await _skillRepository.Delete(id);
        }

        public async Task<Skill> GetSkillById(int? id)
        {
            return await _skillRepository.GetByID(id);
        }

        public Task<List<Skill>> GetSkillList()
        {
           return _skillRepository.GetAll();
        }

        public Task Update(Skill skill)
        {
            return _skillRepository.Update(skill);
        }
    }
}
