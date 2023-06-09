using System;

namespace Library.UI.Service.SignIn
{
    public interface ILoggedAccount
    {
        public Guid AccountId { get; }

        public void TakeAccountId(Guid id);
    }
}
