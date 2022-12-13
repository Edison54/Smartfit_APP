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
    public class ExercisesMachinesViewModel : BaseViewModel
    {


        public ExercisesMachine MyExercisesMachine { get; set; }

        public ExercisesMachinesDTO MyExercisesMachinesDTO { get; set; }
        public ExercisesMachinesViewModel()
        {
            MyExercisesMachine = new ExercisesMachine();

            MyExercisesMachinesDTO = new ExercisesMachinesDTO();





        }






        public async Task<ObservableCollection<ExercisesMachinesDTO>> GetFullExercisesMachinesList()
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
                    ObservableCollection<ExercisesMachinesDTO> List = new ObservableCollection<ExercisesMachinesDTO>();

                    List = await MyExercisesMachinesDTO.GetExercisesMachinesListFull(GlobalObjects.GlobalUser.IdUsuario);

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

       
        public async Task<bool> AddNewExerciseMachine(
       string pNameExercise,
       int pPeso,
       string pCantidadRepeticiones,
       string pTiempo
       )

        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {

                MyExercisesMachine.IdUsuario = GlobalObjects.GlobalUser.IdUsuario;
                MyExercisesMachine.NameExercise = pNameExercise;
                MyExercisesMachine.Peso = pPeso;
                MyExercisesMachine.CantidadRepeticiones = pCantidadRepeticiones;
                MyExercisesMachine.Tiempo = pTiempo;

  

        bool R = await MyExercisesMachine.AddExercisesMachine();
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


        public async Task<bool> UpdateExerciseMachine(
int pIdExercise,
   string pNameExercise,
       int pPeso,
       string pCantidadRepeticiones,
       string pTiempo)


        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {


                MyExercisesMachine.IdEjercicio = pIdExercise;
                MyExercisesMachine.IdUsuario = GlobalObjects.GlobalUser.IdUsuario;
                MyExercisesMachine.NameExercise = pNameExercise;
                MyExercisesMachine.Peso = pPeso;
                MyExercisesMachine.CantidadRepeticiones = pCantidadRepeticiones;
                MyExercisesMachine.Tiempo = pTiempo;


                bool R = await MyExercisesMachine.UpdateExerciseMachine(pIdExercise);
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

        public async Task<bool> Delete(int ExerciseID)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {


                bool R = await MyExercisesMachinesDTO.Delete(ExerciseID);

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
        public async Task<ExercisesMachinesDTO> GetUserExerciseData(int Muscleid)
        {

            try
            {
                ExercisesMachinesDTO exercises = new ExercisesMachinesDTO();


                exercises = await MyExercisesMachinesDTO.GetUserExercisesData(Muscleid);

                if (exercises == null)
                {
                    return null;
                }
                else
                {
                    return exercises;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }


    }
}
