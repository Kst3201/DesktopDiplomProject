using DesktopDiplomProject.ServerASP.Features.Assessment.Models;

namespace DesktopDiplomProject.ServerASP.Features.ComponentManagement.Models
{
    public abstract class BaseComponentModel : IComponentModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public IScore TotalScore { get; set; }

        public BaseComponentModel()
        {
            Name = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            Price = 0;
            TotalScore = new Score();
        }

        public BaseComponentModel(BaseComponentModel copy)
        {
            Name = copy.Name;
            Manufacturer = copy.Manufacturer;
            Model = copy.Model;
            Price = copy.Price;
            TotalScore = new Score()
            {
                ScoreOne = copy.TotalScore.ScoreOne,
                ScoreTwo = copy.TotalScore.ScoreTwo,
                ScoreThree = copy.TotalScore.ScoreThree,
                ScoreFour = copy.TotalScore.ScoreFour,
                ScoreFive = copy.TotalScore.ScoreFive
            };
        }

        public abstract object Clone();
    }
}
