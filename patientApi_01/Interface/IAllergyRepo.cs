using patientApi_01.Models;

namespace patientApi_01.Interface
{
    public interface IAllergyRepo
    {
        Task<IEnumerable<Allergy>> GetAll();
        Task<Allergy> GetById(int id);
        Task<Allergy> Insert(Allergy e);
        Task<Allergy> Update(Allergy e);
        Task Delete(int id);
        Task Save();
        Task<Allergy> GetByNameAsync(string AllergyName);
    }
}
