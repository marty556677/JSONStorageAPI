using System.ComponentModel.DataAnnotations;

namespace JSONStorageAPI.Models
{
    public class JSONFile
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }
        public string? Description { get; set; }
    }
}
