using System.ComponentModel.DataAnnotations;

namespace patientApi_01.Models.ViewModels
{
    public class InsertModel
    {
        public InsertModel()
        {
            this.NCD_Ids = new List<int>();
            this.Allergy_Ids = new List<int>();
            this.Diseases = new List<Disease>();
            this.NCDs = new List<NCD>();  // Added this line
            this.Allergies = new List<Allergy>();  // Added this line
            this.SelectedNCDNames = new List<string>();
            this.SelectedAllergies = new List<int>();  // Modified this line
        }

        public int PatientID { get; set; }
        public string PatientName { get; set; } = null!;
        public Epilepsy Epilepsy { get; set; }
        public int DiseaseID { get; set; }

        // Additional properties for NCD_Ids and Allergy_Ids
        public List<int> SelectedNCDs { get; set; }
        public List<int> NCD_Ids { get; set; }
        public List<string> SelectedNCDNames { get; set; }
        public List<int> Allergy_Ids { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<NCD> NCDs { get; set; }  // Added this property
        public List<int> SelectedAllergies { get; set; }
        public List<Allergy> Allergies { get; set; }

    }
}
