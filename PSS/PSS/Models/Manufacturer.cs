using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSS.Models
{
    [Table("Manufacturers")]
    [DisplayName("Fabricantes")]
    public class Manufacturer : LegalPerson
    {

    }
}