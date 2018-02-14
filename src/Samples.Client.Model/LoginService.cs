using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Samples.Client.Model.Contracts;
using Samples.Client.Model.Shared;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    class LoginService : ILoginService
    {        
        public async Task LoginAsync(string username, string password)
        {
            await ServiceRunner.RunAsync(() => LoginInternal(username, password));
        }

        private async Task LoginInternal(string username, string password)
        {
            await ServiceRunner.RunAsync(() =>
            {
                if (username.ToLower() == "admin" && password.ToLower() == "pass")
                {
                    UserContext.Current = new User(username);
                }
                else
                {
                    throw new Exception("Invalid credentials");
                }                
            });
        }
    }
}