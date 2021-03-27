using Microsoft.EntityFrameworkCore;

namespace barcode.Models
{

    public class BarcodeContext : DbContext
    {
        public BarcodeContext(DbContextOptions<BarcodeContext> options)
            : base(options)
        {
        }

        public DbSet<Barcode> Barcodes { get; set; }
    }


}