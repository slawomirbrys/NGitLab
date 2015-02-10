using System;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class Project
    {
        public const string Url = "/projects";

        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "default_branch")]
        public string DefaultBranch;

        [DataMember(Name = "owner")]
        public User Owner;

        [DataMember(Name = "public")]
        public bool Public;

        [DataMember(Name = "path")]
        public string Path;

        [DataMember(Name = "path_with_namespace")]
        public string PathWithNamespace;

        [DataMember(Name = "issues_enabled")]
        public bool IssuesEnabled;

        [DataMember(Name = "merge_requests_enabled")]
        public bool MergeRequestsEnabled;

        [DataMember(Name = "wall_enabled")]
        public bool WallEnabled;

        [DataMember(Name = "wiki_enabled")]
        public bool WikiEnabled;

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt;

        [DataMember(Name = "ssh_url_to_repo")]
        public string SshUrl;

        [DataMember(Name = "http_url_to_repo")]
        public string HttpUrl;

        [DataMember(Name = "namespace")]
        public Namespace Namespace;

        public bool EnableGitlabCi(string token, string projectUrl)
        {
            ProjectServiceGitlabCI GitlabCi = new ProjectServiceGitlabCI();
            GitlabCi.Token = token;
            GitlabCi.ProjectUrl = projectUrl;
            return GitLabClient.Api.Put().With(GitlabCi).To<bool>(Url + "/" + Id + "/services/gitlab-ci");
        }

        public bool DisableGitlabCi()
        {
            return GitLabClient.Api.Delete().To<bool>(Url + "/" + Id + "/services/gitlab-ci");
        }

        public bool EnableHipChat(string token, string room)
        {
            ProjectServiceHipChat hipchat = new ProjectServiceHipChat();
            hipchat.Token = token;
            hipchat.Room = room;
            return GitLabClient.Api.Put().With(hipchat).To<bool>(Url + "/" + Id + "/services/hipchat");
        }

        public bool DisableHipChat()
        {
            return GitLabClient.Api.Delete().To<bool>(Url + "/" + Id + "/services/hipchat");
        }
    }
}