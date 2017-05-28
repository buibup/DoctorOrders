using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DoctorOrder.Web.Models.PatientDrugModels;

namespace DoctorOrder.Web.Models
{
    public class PatientDrugGroupViewModel
    {
        public Patient Patient { get; set; }
        public List<DrugDate> DrugDateList { get; set; } = new List<DrugDate>();

        public static PatientDrugGroupViewModel patientDrugGroupViewModel { get; set; } = new PatientDrugGroupViewModel();



        public void ToPatientDrugGroupViewModel(PatientDrugViewModels patientDrugViewModels)
        {
            List<DrugDate> drgDteList = new List<DrugDate>();
            DrugDate drugDate;

            DrugTime drugTime;

            patientDrugGroupViewModel.Patient = patientDrugViewModels.Patient;

            string date = string.Empty;
            string time = string.Empty;

            //var disDates = patientDrugViewModels.DrugViewModel.Select(m => m.StartDate).Distinct();
            //var disTimes = patientDrugViewModels.DrugViewModel.Select(m => new { m.StartDate, m.StartTime }).Distinct();

            var disDates = patientDrugViewModels.DrugViewModel.Select(m => m.TimeLineDate).Distinct();
            var disTimes = patientDrugViewModels.DrugViewModel.Select(m => new { m.TimeLineDate, m.TimeLineDateTime }).Distinct();

            foreach (var disDate in disDates)
            {
                drugDate = new DrugDate();
                List<DrugTime> drgTmeList = new List<DrugTime>();
                OneDayOrders OneDayOrders = new OneDayOrders();
                ContinueOrders ContinueOrders = new ContinueOrders();

                //OneDayOrders
                List<Drug> OneDayOrdersV = new List<Drug>();
                List<Drug> OneDayOrdersE = new List<Drug>();

                //ContinueOrders
                List<Drug> ContinueOrdersV = new List<Drug>();
                List<Drug> ContinueOrdersE = new List<Drug>();
                List<Drug> ContinueOrdersD = new List<Drug>();
                List<Drug> ContinueOrdersC = new List<Drug>();

                drgDteList.Clear();
                drgTmeList.Clear();
                foreach (var disTime in disTimes)
                {
                    if (disDate == disTime.TimeLineDate)
                    {
                        drugTime = new DrugTime();
                        drugTime.StartTime = disTime.TimeLineDateTime;
                        drgTmeList.Add(drugTime);
                        
                        //clear list order
                        OneDayOrdersV.Clear();
                        OneDayOrdersE.Clear();

                        ContinueOrdersV.Clear();
                        ContinueOrdersE.Clear();
                        ContinueOrdersD.Clear();
                        ContinueOrdersC.Clear();

                        foreach (var item in patientDrugViewModels.DrugViewModel)
                        {
                            if (disDate == item.TimeLineDate & disTime.TimeLineDateTime == item.TimeLineDateTime)
                            {
                                Drug drug = new Drug();

                                if (item.Type.ToUpper() == "ONEDAY")
                                {
                                    if(item.OSTAT_Code.ToUpper() == "V")
                                    {
                                        drug.OEORI_Date = item.OEORI_Date;
                                        drug.Service = item.Service;
                                        drug.QuestionAnswerModel = item.QuestionAnswerModel;
                                        drug.Qty = item.Qty;
                                        drug.Dose = item.Dose;
                                        drug.StartDate = item.StartDate;
                                        drug.StartTime = item.StartTime;
                                        drug.OrderingClinician = item.OrderingClinician;
                                        drug.AuthorisingClinician = item.AuthorisingClinician;
                                        drug.DCUserCode = item.DCUserCode;
                                        drug.DCUserName = item.DCUserName;
                                        drug.DCDate = item.DCDate;
                                        drug.DCTime = item.DCTime;
                                        drug.AddUserCode = item.AddUserCode;
                                        drug.AddUserName = item.AddUserName;

                                        drug.OSTAT_Code = item.OSTAT_Code;
                                        drug.OSTAT_Desc = item.OSTAT_Desc;

                                        OneDayOrdersV.Add(drug);
                                    }
                                    if (item.OSTAT_Code.ToUpper() == "E")
                                    {
                                        drug.OEORI_Date = item.OEORI_Date;
                                        drug.Service = item.Service;
                                        drug.QuestionAnswerModel = item.QuestionAnswerModel;
                                        drug.Qty = item.Qty;
                                        drug.Dose = item.Dose;
                                        drug.StartDate = item.StartDate;
                                        drug.StartTime = item.StartTime;
                                        drug.OrderingClinician = item.OrderingClinician;
                                        drug.AuthorisingClinician = item.AuthorisingClinician;
                                        drug.DCUserCode = item.DCUserCode;
                                        drug.DCUserName = item.DCUserName;
                                        drug.DCDate = item.DCDate;
                                        drug.DCTime = item.DCTime;
                                        drug.AddUserCode = item.AddUserCode;
                                        drug.AddUserName = item.AddUserName;

                                        drug.OSTAT_Code = item.OSTAT_Code;
                                        drug.OSTAT_Desc = item.OSTAT_Desc;

                                        OneDayOrdersE.Add(drug);
                                    }

                                    
                                }
                                if (item.Type.ToUpper() == "CONTINUE")
                                {
                                    if (item.OSTAT_Code.ToUpper() == "V")
                                    {
                                        drug.OEORI_Date = item.OEORI_Date;
                                        drug.Service = item.Service;
                                        drug.QuestionAnswerModel = item.QuestionAnswerModel;
                                        drug.Qty = item.Qty;
                                        drug.Dose = item.Dose;
                                        drug.StartDate = item.StartDate;
                                        drug.StartTime = item.StartTime;
                                        drug.OrderingClinician = item.OrderingClinician;
                                        drug.AuthorisingClinician = item.AuthorisingClinician;
                                        drug.DCUserCode = item.DCUserCode;
                                        drug.DCUserName = item.DCUserName;
                                        drug.DCDate = item.DCDate;
                                        drug.DCTime = item.DCTime;
                                        drug.AddUserCode = item.AddUserCode;
                                        drug.AddUserName = item.AddUserName;

                                        drug.OSTAT_Code = item.OSTAT_Code;
                                        drug.OSTAT_Desc = item.OSTAT_Desc;

                                        ContinueOrdersV.Add(drug);
                                    }
                                    if (item.OSTAT_Code.ToUpper() == "E")
                                    {
                                        drug.OEORI_Date = item.OEORI_Date;
                                        drug.Service = item.Service;
                                        drug.QuestionAnswerModel = item.QuestionAnswerModel;
                                        drug.Qty = item.Qty;
                                        drug.Dose = item.Dose;
                                        drug.StartDate = item.StartDate;
                                        drug.StartTime = item.StartTime;
                                        drug.OrderingClinician = item.OrderingClinician;
                                        drug.AuthorisingClinician = item.AuthorisingClinician;
                                        drug.DCUserCode = item.DCUserCode;
                                        drug.DCUserName = item.DCUserName;
                                        drug.DCDate = item.DCDate;
                                        drug.DCTime = item.DCTime;
                                        drug.AddUserCode = item.AddUserCode;
                                        drug.AddUserName = item.AddUserName;

                                        drug.OSTAT_Code = item.OSTAT_Code;
                                        drug.OSTAT_Desc = item.OSTAT_Desc;

                                        ContinueOrdersE.Add(drug);
                                    }
                                    if (item.OSTAT_Code.ToUpper() == "D")
                                    {
                                        string[] oeoriDate = item.OEORI_Date.Split('/');
                                        int iOeoriDate = Convert.ToInt32(oeoriDate[2] + oeoriDate[1] + oeoriDate[0]);

                                        string[] dcDate = item.DCDate.Split('/');
                                        int iDcDate = Convert.ToInt32(dcDate[2] + dcDate[1] + dcDate[0]);

                                        if (iOeoriDate >= iDcDate)
                                        {
                                            drug.OEORI_Date = item.OEORI_Date;
                                            drug.Service = item.Service;
                                            drug.QuestionAnswerModel = item.QuestionAnswerModel;
                                            drug.Qty = item.Qty;
                                            drug.Dose = item.Dose;
                                            drug.StartDate = item.StartDate;
                                            drug.StartTime = item.StartTime;
                                            drug.OrderingClinician = item.OrderingClinician;
                                            drug.AuthorisingClinician = item.AuthorisingClinician;
                                            drug.DCUserCode = item.DCUserCode;
                                            drug.DCUserName = item.DCUserName;
                                            drug.DCDate = item.DCDate;
                                            drug.DCTime = item.DCTime;
                                            drug.AddUserCode = item.AddUserCode;
                                            drug.AddUserName = item.AddUserName;

                                            drug.OSTAT_Code = item.OSTAT_Code;
                                            drug.OSTAT_Desc = "Cancel";

                                            ContinueOrdersC.Add(drug);
                                        }
                                        else
                                        {
                                            drug.OEORI_Date = item.OEORI_Date;
                                            drug.Service = item.Service;
                                            drug.QuestionAnswerModel = item.QuestionAnswerModel;
                                            drug.Qty = item.Qty;
                                            drug.Dose = item.Dose;
                                            drug.StartDate = item.StartDate;
                                            drug.StartTime = item.StartTime;
                                            drug.OrderingClinician = item.OrderingClinician;
                                            drug.AuthorisingClinician = item.AuthorisingClinician;
                                            drug.DCUserCode = item.DCUserCode;
                                            drug.DCUserName = item.DCUserName;
                                            drug.DCDate = item.DCDate;
                                            drug.DCTime = item.DCTime;
                                            drug.AddUserCode = item.AddUserCode;
                                            drug.AddUserName = item.AddUserName;

                                            drug.OSTAT_Code = item.OSTAT_Code;
                                            drug.OSTAT_Desc = item.OSTAT_Desc;

                                            ContinueOrdersD.Add(drug);
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }

                OneDayOrders.Verified = OneDayOrdersV;
                OneDayOrders.Executed = OneDayOrdersE;

                ContinueOrders.Verified = ContinueOrdersV;
                ContinueOrders.Executed = ContinueOrdersE;
                ContinueOrders.Discontinued = ContinueOrdersD;
                ContinueOrders.Cancel = ContinueOrdersC;

                drugDate.DrugTime = drgTmeList;
                drugDate.StartDate = disDate;
                AddPatientDrugGroupViewModel(drugDate);
            }

        }

        public void AddPatientDrugGroupViewModel(DrugDate drgDate)
        {
            DrugDateList.Add(drgDate);
        }

        public PatientDrugGroupViewModel GetPatientDrugGroupViewModel()
        {
            patientDrugGroupViewModel.DrugDateList = DrugDateList;
            return patientDrugGroupViewModel;
        }

    }

    public class DrugDate
    {
        public string StartDate { get; set; }
        public List<DrugTime> DrugTime { get; set; }
    }

    public class DrugTime
    {
        public string StartTime { get; set; }
        public OneDayOrders OneDayOrders { get; set; }
        public ContinueOrders ContinueOrders { get; set; }
    }

    public class OneDayOrders
    {
        public List<Drug> Verified { get; set; }
        public List<Drug> Executed { get; set; }
    }
    
    public class ContinueOrders
    {
        public List<Drug> Verified { get; set; }
        public List<Drug> Executed { get; set; }
        public List<Drug> Discontinued { get; set; }
        public List<Drug> Cancel { get; set; }
    }
}