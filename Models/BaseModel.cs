using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Alura_MVC.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        [Key]
        [JsonProperty]
        public int Id { get; protected set; }
    }
}
