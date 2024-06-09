using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class OtpAuthenticator : Entity<Guid>
    {
        public OtpAuthenticator()
        {
            SecretKey = Array.Empty<byte>();
        }

        public OtpAuthenticator(Guid userId, byte[] secretKey, bool isVerified)
        {
            UserId = userId;
            SecretKey = secretKey;
            IsVerified = isVerified;
        }

        public OtpAuthenticator(Guid id, Guid userId, byte[] secretKey, bool isVerified) : base(id)
        {
            UserId = userId;
            SecretKey = secretKey;
            IsVerified = isVerified;
        }

        public Guid UserId { get; set; }
        public byte[] SecretKey { get; set; }
        public bool IsVerified { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
