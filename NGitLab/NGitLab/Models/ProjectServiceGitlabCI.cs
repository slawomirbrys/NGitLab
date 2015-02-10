using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class ProjectServiceGitlabCI
    {
        [Required]
        [DataMember(Name = "token")]
        public string Token;

        [Required]
        [DataMember(Name = "project_url")]
        public string ProjectUrl;
    }
}