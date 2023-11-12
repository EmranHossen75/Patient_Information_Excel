using Microsoft.AspNetCore.Mvc.Rendering;
using patientApi_01.Models;

namespace patientClient_01.Models.ViewModels
{
    public class CreatePatientViewModel
    {
        public string PatientName { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public int DiseaseID { get; set; } // Add this property for Disease selection
        public SelectList Diseases { get; set; }

        public SelectList PatientNameList { get; set; }
        public SelectList EpilepsyList { get; set; }
        public SelectList DiseaseList { get; set; }
    }
}
