using System.ComponentModel.DataAnnotations;

namespace HelloAspNet.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}