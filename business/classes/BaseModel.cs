using System.ComponentModel.DataAnnotations;

namespace business.classes
{
    public class BaseModel
    {
        public BaseModel()
        {
        }
        [Key]
        public int Id { get; set; }       
        
    }
}