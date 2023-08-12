using JSONStorageAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JSONStorageAPI.Services.JSONFileService
{
    public class JSONFileService : IJSONFileService
    {
        private readonly JSONStorageAPIContext _context;

        public JSONFileService(JSONStorageAPIContext context)
        {
            _context = context;
        }

        public async Task<List<JSONFile>> AddJSONFile([FromBody] JSONFile file)
        {
            file.UpdateDate = DateTime.Now;
            _context.JSONFiles.Add(file);
            await _context.SaveChangesAsync();

            return await _context.JSONFiles.ToListAsync();
        }

        public async Task<List<JSONFile>?> DeleteJSONFileById(int id)
        {
            var file = await _context.JSONFiles.FindAsync(id);
            if (file is null)
                return null;

            _context.JSONFiles.Remove(file);
            await _context.SaveChangesAsync();

            return await _context.JSONFiles.ToListAsync();
        }

        public async Task<List<JSONFile>> GetAllJSONFiles()
        {
            var jsonFiles = await _context.JSONFiles.ToListAsync();
            return jsonFiles;
        }

        public async Task<JSONFile?> GetJSONFileById(int id)
        {
            var file = await _context.JSONFiles.FindAsync(id);
            if (file is null)
                return null;
            return file;
        }

        public async Task<List<JSONFile>?> UpdateJSONFile([FromBody] JSONFile reqFile)
        {
            var file = await _context.JSONFiles.FindAsync(reqFile.Id);
            if (file is null)
                return null;

            file.Text = reqFile.Text;
            file.Description = reqFile.Description;
            file.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return await _context.JSONFiles.ToListAsync();
        }
    }
}
