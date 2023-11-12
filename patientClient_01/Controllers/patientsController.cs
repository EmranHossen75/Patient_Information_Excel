using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using patientApi_01.Models;
using patientApi_01.Models.ViewModels;
using patientClient_01.Models.ViewModels;
using System.Text;

namespace patientClient_01.Controllers
{
    public class patientsController : Controller
    {
        private readonly HttpClient _httpClient;
        
        public patientsController()
        {
          
         
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5072/api/");
           
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Patients");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(json);

                // Ensure NCD and Allergy details are initialized to empty collections if null
                foreach (var patient in patients)
                {
                    patient.NCDDetails ??= new List<NCD_Details>();
                    patient.AllergiesDetails ??= new List<Allergies_Details>();

                    // Ensure NCD and Allergy names are initialized to empty strings if null
                    foreach (var ncdDetail in patient.NCDDetails)
                    {
                        ncdDetail.NCD ??= new NCD { NCDName = "N/A" };
                    }

                    foreach (var allergyDetail in patient.AllergiesDetails)
                    {
                        allergyDetail.Allergy ??= new Allergy { AllergyName = "N/A" };
                    }
                }

                return View(patients);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return View(new List<Patient>());
            }
        }

        //public async Task<IActionResult> Index()
        //{
        //    var response = await _httpClient.GetAsync("Patients");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadAsStringAsync();
        //        var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(json);

        //        // Ensure NCD and Allergy details are initialized to empty collections if null
        //        foreach (var patient in patients)
        //        {
        //            patient.NCDDetails ??= new List<NCD_Details>();
        //            patient.AllergiesDetails ??= new List<Allergies_Details>();
        //        }

        //        return View(patients);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error: " + response.StatusCode);
        //        return View(new List<Patient>());
        //    }
        //}       
        public async Task<IActionResult> Create()
        {
            try
            {
                var diseaseResponse = await _httpClient.GetAsync("http://localhost:5072/api/Diseases");
                var ncdResponse = await _httpClient.GetAsync("http://localhost:5072/api/NCDS");
                var allergyResponse = await _httpClient.GetAsync("http://localhost:5072/api/Allergies/GetAll");

                if (diseaseResponse.IsSuccessStatusCode && ncdResponse.IsSuccessStatusCode && allergyResponse.IsSuccessStatusCode)
                {
                    var diseases = await diseaseResponse.Content.ReadFromJsonAsync<IEnumerable<Disease>>();
                    var ncds = await ncdResponse.Content.ReadFromJsonAsync<IEnumerable<NCD>>();
                    var allergies = await allergyResponse.Content.ReadFromJsonAsync<IEnumerable<Allergy>>();

                    var model = new InsertModel
                    {
                        Diseases = diseases?.ToList() ?? new List<Disease>(),
                        NCDs = ncds?.ToList() ?? new List<NCD>(),
                        Allergies = allergies?.ToList() ?? new List<Allergy>()
                    };

                    return View(model);
                }
                else
                {
                    return View(new InsertModel());
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return View(new InsertModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertModel data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("insertPatient", data);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index"); // Redirect to the patient list or another action.
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error while saving the patient.");
                    // Refetch the data and update the model
                    var diseases = await _httpClient.GetAsync("http://localhost:5072/api/Diseases").Result.Content.ReadFromJsonAsync<IEnumerable<Disease>>();
                    var ncds = await _httpClient.GetAsync("http://localhost:5072/api/NCDS").Result.Content.ReadFromJsonAsync<IEnumerable<NCD>>();
                    var allergies = await _httpClient.GetAsync("http://localhost:5072/api/Allergies/GetAll").Result.Content.ReadFromJsonAsync<IEnumerable<Allergy>>();

                    data.Diseases = diseases?.ToList() ?? new List<Disease>();
                    data.NCDs = ncds?.ToList() ?? new List<NCD>();
                    data.Allergies = allergies?.ToList() ?? new List<Allergy>();

                    return View(data);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                // Refetch the data and update the model
                var diseases = await _httpClient.GetAsync("http://localhost:5072/api/Diseases").Result.Content.ReadFromJsonAsync<IEnumerable<Disease>>();
                var ncds = await _httpClient.GetAsync("http://localhost:5072/api/NCDS").Result.Content.ReadFromJsonAsync<IEnumerable<NCD>>();
                var allergies = await _httpClient.GetAsync("http://localhost:5072/api/Allergies/GetAll").Result.Content.ReadFromJsonAsync<IEnumerable<Allergy>>();

                data.Diseases = diseases?.ToList() ?? new List<Disease>();
                data.NCDs = ncds?.ToList() ?? new List<NCD>();
                data.Allergies = allergies?.ToList() ?? new List<Allergy>();

                return View(data);
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(InsertModel data)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PostAsJsonAsync("insertPatient", data);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index"); // Redirect to the patient list or another action.
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Error while saving the patient.");
        //            // Refetch the diseases and update the model
        //            var diseases = await _httpClient.GetAsync("api/Diseases")
        //                .Result.Content.ReadFromJsonAsync<IEnumerable<Disease>>();
        //            data.Diseases = diseases?.ToList() ?? new List<Disease>();
        //            return View(data);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
        //        // Refetch the diseases and update the model
        //        var diseases = await _httpClient.GetAsync("api/Diseases")
        //            .Result.Content.ReadFromJsonAsync<IEnumerable<Disease>>();
        //        data.Diseases = diseases?.ToList() ?? new List<Disease>();
        //        return View(data);
        //    }
        //}

    }
}
