using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace barcode.Models
{
    [Index(nameof(Courier))]
    public class Barcode
    {
        [Key]
        public string Code { get; set; }
        

        public string Courier {get; set; }

    }
}