using System.ComponentModel.DataAnnotations;

namespace SurveysManager.DataAccess.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
