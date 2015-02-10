using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class ProjectClient : IProjectClient
    {
        private readonly API _api;

        public ProjectClient(API api)
        {
            _api = api;
        }

        public IEnumerable<Project> Accessible
        {
            get
            {
                return _api.Get().GetAll<Project>(Project.Url);
            }
        }

        public IEnumerable<Project> Owned
        {
            get
            {
                return _api.Get().GetAll<Project>(Project.Url + "/owned");
            }
        }

        public IEnumerable<Project> All
        {
            get
            {
                return _api.Get().GetAll<Project>(Project.Url + "/all");
            }
        }

        public Project this[int id]
        {
            get
            {
                return _api.Get().To<Project>(Project.Url + "/" + id);
            }
        }

        public Project Create(ProjectCreate project)
        {
            return _api.Post().With(project).To<Project>(Project.Url);
        }
 
        public bool Delete(int id)
        {
            return _api.Delete().To<bool>(Project.Url + "/" + id);
        }

        public bool EnableGitlabCi(int id, string token, string projectUrl)
        {
            var gitlabCi = new ProjectServiceGitlabCI { Token = token, ProjectUrl = projectUrl };
            return _api.Put().With(gitlabCi).To<bool>(Project.Url + "/" + id + "/services/gitlab-ci");
        }

        public bool DisableGitlabCi(int id)
        {
            return _api.Delete().To<bool>(Project.Url + "/" + id + "/services/gitlab-ci");
        }

        public bool EnableHipChat(int id, string token, string room)
        {
            var hipchat = new ProjectServiceHipChat { Token = token, Room = room };
            return _api.Put().With(hipchat).To<bool>(Project.Url + "/" + id + "/services/hipchat");
        }

        public bool DisableHipChat(int id)
        {
            return _api.Delete().To<bool>(Project.Url + "/" + id + "/services/hipchat");
        }
    }
}