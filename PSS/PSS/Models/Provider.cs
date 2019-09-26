using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Providers")]
    [DisplayName("Fornecedores")]
    public class Provider : LegalPerson
    {

    }
}