using System;
using PromiseTree;

namespace MicroserviceArchitecture
{
    public class User
    {
    }

    public class WebApplication
    {
        private User user;
        private UIAPI api;

        public WebApplication(User user)
        {
            this.user = user;
            this.api = new UIAPI();
        }

        public Promise Interact()
        {
            return api.Request(user);
        }
    }

    public class UIAPI
    {
        public Promise Request(User user)
        {
            return Promise.Resolve();
        }
    }
}