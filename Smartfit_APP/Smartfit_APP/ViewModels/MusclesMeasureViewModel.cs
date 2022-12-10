using MvvmHelpers;
using Smartfit_APP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Smartfit_APP.Models.DTOs;
namespace Smartfit_APP.ViewModels
{
    public class MusclesMeasureViewModel : BaseViewModel
    {



        public MusclesMeasure MyMusclesMeasure { get; set; }

        public MuscleMeasuresDTO MyMusclesMeasureDTO { get; set; }
        public MusclesMeasureViewModel()
        {
            MyMusclesMeasure = new MusclesMeasure();
            MyMusclesMeasureDTO = new MuscleMeasuresDTO();
        }



        public async Task<ObservableCollection<MuscleMeasuresDTO>> GetFullInventoryList()
        {
            if (IsBusy)
            {

                return null;
            }
            else
            {
                IsBusy = true;
                try
                {
                    ObservableCollection<MuscleMeasuresDTO> List = new ObservableCollection<MuscleMeasuresDTO>();

                    List = await MyMusclesMeasureDTO.GetMusclesListFull(GlobalObjects.GlobalUser.IdUsuario);

                    if (List == null)
                    {
                        return null;

                    }
                    return List;

                }
                catch (Exception)
                {
                    return null;

                }
                finally { IsBusy = false; }
            }

        }







    }
}
