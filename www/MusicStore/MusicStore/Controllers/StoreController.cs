using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;
        public StoreController(StoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListGenres()
        {
            var genres = _context.Genres.OrderBy(m => m.Name);
            return View(await genres.ToListAsync());
        }
        public async Task<IActionResult> ListAlbums(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.Where(m => m.GenreID == id).OrderBy(m => m.Title).ToListAsync();
            if (album == null)
            {
                return NotFound();
            }
            var genre = await _context.Genres.FindAsync(id);
            ViewData["GenreID"] = genre.Name;
            return View(album);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.Include(m => m.Artist).Include(m => m.Genre).Where(m => m.AlbumID == id).SingleOrDefaultAsync();
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }
    }
}
