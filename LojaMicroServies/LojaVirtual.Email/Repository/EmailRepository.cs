using LojaVirtual.Email.Messages;
using LojaVirtual.Email.Model;
using LojaVirtual.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<MySQLContext> _context;

        public EmailRepository(DbContextOptions<MySQLContext> context)
        {
            _context = context;
        }


        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new ()
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"Pedido - {message.OrderId} criado com sucesso!"
            };

            await using var _db = new MySQLContext(_context);
            _db.Emails.Add(email);
            await _db.SaveChangesAsync();

        }

      
    }
}
