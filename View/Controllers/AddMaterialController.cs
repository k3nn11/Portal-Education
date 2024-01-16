using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.MaterialPopulation;
using Services.Validation;

namespace View.Controllers
{
    public static class AddMaterialController
    {
        public static async Task AddMaterial()
        {
            ValidationService validationService = new ValidationService();
            MaterialPopulationService materialPopulationService = new MaterialPopulationService();
            while (true)
            {
                MaterialAddOption();
                int choice = validationService.ValidationInterger();
                if (choice == 4)
                {
                    break;
                }

                switch (choice)
                {
                    case 1:
                        await materialPopulationService.PopulateArticle();
                        break;
                    case 2:
                        await materialPopulationService.PopulateBook();
                        break;
                    case 3:
                        await materialPopulationService.PopulateVideo();
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        continue;
                }
            }
        }

        private static void MaterialAddOption()
        {
            Console.WriteLine("Enter type of material you would like to add (Enter 4 to finish)");
            Console.WriteLine("1: Article material");
            Console.WriteLine("2: Book material");
            Console.WriteLine("3: Video material");
        }
    }
}
