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



        public async Task<bool> AddNewMuscleMeasure(

         string pMusculo,
         decimal pMedida,
         DateTime pFechaMedida)

        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
              
                MyMusclesMeasure.IdUsuario = GlobalObjects.GlobalUser.IdUsuario;
                MyMusclesMeasure.Musculo = pMusculo;
                MyMusclesMeasure.Medida = pMedida;
                MyMusclesMeasure.FechaMedida = pFechaMedida;


                bool R = await MyMusclesMeasure.AddMusclesMeasure();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }








        public async Task<bool> UpdateMeasure(
         int pIdMuscle,
         string pMusculo,
         decimal pMedida,
         DateTime pFechaMedida)

  
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyMusclesMeasure.IdMuscle = pIdMuscle;
                MyMusclesMeasure.IdUsuario = GlobalObjects.GlobalUser.IdUsuario;
                MyMusclesMeasure.Musculo = pMusculo;
                MyMusclesMeasure.Medida = pMedida;
                MyMusclesMeasure.FechaMedida = pFechaMedida;


                bool R = await MyMusclesMeasure.UpdateMuscleMeasure(pIdMuscle);
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<MuscleMeasuresDTO> GetUserMusclesData(int Muscleid)
        {

            try
            {
                MuscleMeasuresDTO  measure = new MuscleMeasuresDTO();


                measure = await MyMusclesMeasureDTO.GetUserMuscleData(Muscleid);

                if (measure == null)
                {
                    return null;
                }
                else
                {
                    return measure;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        

        public async Task<bool> Delete(int muscleID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {


                bool R = await MyMusclesMeasureDTO.Delete(muscleID);

                return R;

            }
            catch (Exception)
            {

                return false;
                throw;
            }
            finally
            { IsBusy = false; }


        }








        public async Task<ObservableCollection<MuscleMeasuresDTO>> GetFullMusclesList()
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
