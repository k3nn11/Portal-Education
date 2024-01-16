using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.MaterialPopulation;
using Services.SkillPopulation;

namespace View.Controllers
{
    public static class AddSkillController
    {
        private static readonly ISkillPopulationService populationService;
        public static async Task AddSkill()
        {
            Console.WriteLine("Add Skills");
            await populationService.PopulateSkill();
        }
    }
}
