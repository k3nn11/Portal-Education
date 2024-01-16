using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services.SkillService
{
    public interface ISkillService
    {
        Task Create(Skill skills);

        Task Delete(int id);

        Task Update(Skill skill);

        Task<List<Skill>> GetSkillList();

        Task<Skill> GetSkillById(int? id);


    }
}
