using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryProduct.Application.Contracts
{
    public abstract class MapperBase<TModel, TViewModel>
    {
        public List<TModel> MapFromViewModelToModel(List<TViewModel> viewModelList)
        {
            List<TModel> sourceList = new List<TModel>();

            if (viewModelList?.Any() == true)
            {
                foreach (TViewModel viewModel in viewModelList)
                {
                    sourceList.Add(MapFromViewModelToModel(viewModel));
                }
            }

            return sourceList;
        }

        public List<TViewModel> MapFromModelToViewModel(List<TModel> modelList)
        {
            List<TViewModel> destinationList = new List<TViewModel>();

            if (modelList?.Any() == true)
            {
                foreach (TModel model in modelList)
                {
                    destinationList.Add(MapFromModelToViewModel(model));
                }
            }

            return destinationList;
        }

        public abstract TModel MapFromViewModelToModel(TViewModel viewModel);

        public abstract TViewModel MapFromModelToViewModel(TModel model);
    }
}
