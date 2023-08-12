using Microsoft.AspNetCore.Mvc;

namespace JSONStorageAPI.Services.JSONFileService
{
    public interface IJSONFileService
    {
        Task<List<JSONFile>> GetAllJSONFiles();
        Task<JSONFile?> GetJSONFileById(int id);
        Task<List<JSONFile>> AddJSONFile([FromBody] JSONFile file);
        Task<List<JSONFile>?> UpdateJSONFile([FromBody] JSONFile reqFile);
        Task<List<JSONFile>?> DeleteJSONFileById(int id);
    }
}
