using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using barcode.Models;
using barcode.Services;

namespace barcode.Controllers
{
    [Route("api/barcode")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly BarcodeContext _context;
        private readonly IBarcodeClassifier _barcodeClassifier;

        public BarcodeController(BarcodeContext context, IBarcodeClassifier barcodeClassifier)
        {
            _context = context;
            _barcodeClassifier = barcodeClassifier;
        }


        // PUT: api/Barcode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{code}")]
        public async Task<Barcode> PutBarcode(string code)
        {
            Console.WriteLine("saving: " + code);

            if (!BarcodeExists(code))
            {
                var barcode = new Barcode();
                barcode.Code = code;
                barcode.Courier = _barcodeClassifier.Classify(code);

                _context.Barcodes.Add(barcode);

                await _context.SaveChangesAsync();
            }

            return await _context.Barcodes.FindAsync(code);
        }


        // PUT: api/Barcode/batch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        [Route("batch")]
        public async Task<List<Barcode>> PutBarcodeBatch(string[] codes)
        {
            var result = new List<Barcode>();

            //TODO batch save this in a single transaction
            for (int i = 0; i < codes.Length; i++) // Do we have a map(()=> here?
            {
                var row = await PutBarcode(codes[i]);
                result.Add(row);
            }

            return result;
        }


        [HttpGet]
        [Route("count")]
        public async Task<int> GetCount()
        {
            return await _context.Barcodes.CountAsync();
        }

        [HttpGet]
        [Route("count-by-carrier")]
        public async Task<Dictionary<string, int>> GetCountByCarrier()
        {
            var result = _context.Barcodes
                .GroupBy(Bc => Bc.Courier)
                .Select(g => new {courier = g.Key, count = g.Count()})
                .ToDictionary(k => k.courier, i => i.count);

            return  result;
        }

        // GET: api/Barcode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barcode>>> GetBarcodes()
        {
            return await _context.Barcodes.ToListAsync();
        }

        // GET: api/Barcode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barcode>> GetBarcode(string code)
        {
            var barcode = await _context.Barcodes.FindAsync(code);

            if (barcode == null)
            {
                return NotFound();
            }

            return barcode;
        }


        // DELETE: api/Barcode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarcode(string id)
        {
            var barcode = await _context.Barcodes.FindAsync(id);
            if (barcode == null)
            {
                return NotFound();
            }

            _context.Barcodes.Remove(barcode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarcodeExists(string id)
        {
            return _context.Barcodes.Any(e => e.Code == id);
        }
    }
}