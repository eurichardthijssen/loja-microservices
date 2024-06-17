using LojaVirtual.Email.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace LojaVirtual.Email.Model
{
    [Table("emails_logs")]
    public class EmailLog : BaseEntity
    {

        [Column("email")]
        public string Email { get; set; }

        [Column("log")]
        public string Log { get; set; }

        [Column("sent_date")]
        public DateTime SentDate { get; set; }

    }
}
