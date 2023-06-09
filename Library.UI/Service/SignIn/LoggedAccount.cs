using System;

namespace Library.UI.Service.SignIn
{
    public class LoggedAccount : ILoggedAccount
    {
        public Guid AccountId { get; private set; }

        public void TakeAccountId(Guid id)
        {
            AccountId = id;
        }
    }
}
