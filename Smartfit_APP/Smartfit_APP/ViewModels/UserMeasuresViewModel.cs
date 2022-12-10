using Smartfit_APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Smartfit_APP.ViewModels;
using System.Threading.Tasks;
using MvvmHelpers;
using Smartfit_APP.Models.DTOs;


namespace Smartfit_APP.ViewModels

{
    public class UserMeasuresViewModel : BaseViewModel
    {

        public Measure MyMeasure { get; set; }

        public MeasureDTO MyMeasureDTO { get; set; }
        public UserMeasuresViewModel()
        {


            MyMeasure = new Measure();
            MyMeasureDTO = new MeasureDTO();
        }


        public async Task<MeasureDTO> GetMeasures()
        {

            try
            {


                MeasureDTO measure = new MeasureDTO();

                measure = await MyMeasureDTO.GetMeasureData(GlobalObjects.GlobalUser.IdUsuario);

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




        public async Task<bool> GetMeasuresInfo()
        {

            try
            {


                MeasureDTO measure = new MeasureDTO();

                measure = await MyMeasureDTO.GetMeasureData(GlobalObjects.GlobalUser.IdUsuario);

                if (measure == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }





        public async Task<bool> AddNewMeasure(
        
         decimal pAltura,
         decimal pPeso,
         decimal pBodyFat,
         decimal pSkeletalMuscle )

        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {

                MyMeasure.IdUsuario =  GlobalObjects.GlobalUser.IdUsuario;
                MyMeasure.Altura = pAltura;
                MyMeasure.Peso = pPeso;
                MyMeasure.BodyFat = pBodyFat;
                MyMeasure.SkeletalMuscle = pSkeletalMuscle;
             

                bool R = await MyMeasure.AddMeasures();
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
         int pmeasureID,
         decimal pAltura,
         decimal pPeso,
         decimal pBodyFat,
         decimal pSkeletalMuscle)

        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {
                MyMeasure.IdMeasure = pmeasureID;
                MyMeasure.IdUsuario = GlobalObjects.GlobalUser.IdUsuario;
                MyMeasure.Altura = pAltura;
                MyMeasure.Peso = pPeso;
                MyMeasure.BodyFat = pBodyFat;
                MyMeasure.SkeletalMuscle = pSkeletalMuscle;


                bool R = await MyMeasure.UpdateMeasure(pmeasureID);
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










    }
}
