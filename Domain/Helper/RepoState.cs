using Domain.Enums;

namespace Domain.Helper
{
    public class RepoState
    {
        private string Error { get; set; }
        private RepoStateEnum State { get; set; }

        public void AddError(string error) 
        { 
            State = RepoStateEnum.Error;
            Error = error;
        }

        public bool HasError() => State == RepoStateEnum.Error;

        public string GetErrorMessage() => Error;
    }
}
