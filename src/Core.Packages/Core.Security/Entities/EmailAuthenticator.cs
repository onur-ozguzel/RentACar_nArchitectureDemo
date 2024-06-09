using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class EmailAuthenticator : Entity<Guid>
    {
        public EmailAuthenticator()
        {
            ActivationKey = string.Empty;
        }

        public EmailAuthenticator(Guid userId, string activationKey, bool isVerified)
        {
            UserId = userId;
            ActivationKey = activationKey;
            IsVerified = isVerified;
        }

        public EmailAuthenticator(Guid id, Guid userId, string activationKey, bool isVerified) : base(id)
        {
            UserId = userId;
            ActivationKey = activationKey;
            IsVerified = isVerified;
        }

        public Guid UserId { get; set; }
        public string ActivationKey { get; set; }
        public bool IsVerified { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
