using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Alura_MVC.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        [Key]
        public int Id { get; protected set; }
    }
}
