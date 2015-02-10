using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class ProjectServiceHipChat
    {
        [Required]
        [DataMember(Name = "token")]
        public string Token;

        [Required]
        [DataMember(Name = "room")]
        public string Room;
    }
}