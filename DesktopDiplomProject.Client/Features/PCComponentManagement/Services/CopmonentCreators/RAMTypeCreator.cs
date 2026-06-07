using DesktopDiplomProject.Client.Features.PCComponentManagement.Models.Components;
using DesktopDiplomProject.Client.Features.PCComponentManagement.ViewModels.Components;
using DiplomDataLibrary.PCComponents.DTO.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopDiplomProject.Client.Features.PCComponentManagement.Services.CopmonentCreators
{
    public class RAMTypeCreator : IRAMTypeCreator
    {
        public RAMTypeCreator() { }

        public RAMTypeDTO CreateDTO(RAMTypeModel model)
        {
            return new RAMTypeDTO(model.Name, model.ScoreOne, model.ScoreTwo
                , model.ScoreThree, model.ScoreFour, model.ScoreFive);
        }

        public RAMTypeModel CreateEmptyModel()
        {
            return new RAMTypeModel();
        }

        public RAMTypeViewModel CreateEmptyViewModel()
        {
            return new RAMTypeViewModel();
        }

        public RAMTypeModel CreateModel(RAMTypeDTO dto)
        {
            return new RAMTypeModel()
            {
                Name = dto.Name,
                ScoreOne = dto.ScoreOne,
                ScoreTwo = dto.ScoreTwo,
                ScoreThree = dto.ScoreThree,
                ScoreFour = dto.ScoreFour,
                ScoreFive = dto.ScoreFive
            };
        }

        public RAMTypeModel CreateModel(RAMTypeViewModel viewModel)
        {
            return new RAMTypeModel()
            {
                Name = viewModel.Name,
                ScoreOne = viewModel.ScoreOne,
                ScoreTwo = viewModel.ScoreTwo,
                ScoreThree = viewModel.ScoreThree,
                ScoreFour = viewModel.ScoreFour,
                ScoreFive = viewModel.ScoreFive
            };
        }

        public RAMTypeViewModel CreateViewModel(RAMTypeModel model)
        {
            return new RAMTypeViewModel()
            {
                Name = model.Name,
                ScoreOne = model.ScoreOne,
                ScoreTwo = model.ScoreTwo,
                ScoreThree = model.ScoreThree,
                ScoreFour = model.ScoreFour,
                ScoreFive = model.ScoreFive
            };
        }
    }
}
