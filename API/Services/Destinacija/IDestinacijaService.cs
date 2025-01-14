namespace API.Services.Destinacija
{
    public interface IDestinacijaService
    {
          Task<IEnumerable<API.Entities.Destinacija>> GetAllAsync();
           Task<API.Entities.Destinacija> GetByIdAsync(int id);
            Task<API.Entities.Destinacija> CreateAsync(API.Entities.Destinacija destinacija);
            Task<bool> UpdateAsync(API.Entities.Destinacija destinacija);
            Task<bool> DeleteAsync(int id);

    }
}