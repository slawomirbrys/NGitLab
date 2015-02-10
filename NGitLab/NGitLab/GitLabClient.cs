using NGitLab.Impl;

namespace NGitLab
{
    public class GitLabClient
    {
        private GitLabClient(string hostUrl, string apiToken)
        {
            Api = new API(hostUrl, apiToken);
            Users = new UserClient(Api);
            Projects = new ProjectClient(Api);
            Issues = new IssueClient(Api);
            Groups = new NamespaceClient(Api);
        }

        public static GitLabClient Connect(string hostUrl, string apiToken)
        {
            return new GitLabClient(hostUrl, apiToken);
        }

        public static API Api;

        public readonly IUserClient Users;
        public readonly IProjectClient Projects;
        public readonly IIssueClient Issues;
        public readonly INamespaceClient Groups;

        public IRepositoryClient GetRepository(int projectId)
        {
            return new RepositoryClient(Api, projectId);
        }

        public IMergeRequestClient GetMergeRequest(int projectId)
        {
            return new MergeRequestClient(Api, projectId);
        }
    }
}