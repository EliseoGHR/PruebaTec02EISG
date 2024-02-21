using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTec02EISG.Models;

namespace PruebaTec02EISG.Controllers
{
    public class ProfesoresController : Controller
    {
        private readonly PruebaTec02EISGDbContext _context;

        public ProfesoresController(PruebaTec02EISGDbContext context)
        {
            _context = context;
        }

        // GET: Profesores
        public async Task<IActionResult> Index()
        {
            var pruebaTec02EISGDbContext = _context.Profesores.Include(p => p.Carrera);
            return View(await pruebaTec02EISGDbContext.ToListAsync());
        }

        // GET: Profesores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesores/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre");
            return View();
        }

        // POST: Profesores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesorId,Nombre,Apellido,CorreoElectronico,Telefono,CarreraId")] Profesor profesor, IFormFile imagen)
        {
            if (ModelState.IsValid)
            {
                if (imagen != null && imagen.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imagen.CopyToAsync(memoryStream);
                        profesor.Imagen = memoryStream.ToArray();
                    }
                }
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre", profesor.CarreraId);
            return View(profesor);
        }

        // GET: Profesores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre", profesor.CarreraId);
            return View(profesor);
        }

        // POST: Profesores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesorId,Nombre,Apellido,CorreoElectronico,Telefono,CarreraId")] Profesor profesor, IFormFile imagen)
        {
                if (id != profesor.ProfesorId)
                {
                    return NotFound();
                }

            
                 if (imagen != null && imagen.Length > 0)
                 {
                  using (var memoryStream = new MemoryStream())
                 {
                  await imagen.CopyToAsync(memoryStream);
                  profesor.Imagen = memoryStream.ToArray();
                 }
                    _context.Update(profesor);
                await _context.SaveChangesAsync();
                }
                else
                {
                    var profesorfind = await _context.Profesores.FirstOrDefaultAsync(s => s.ProfesorId == profesor.ProfesorId);
                    if (profesorfind?.Imagen?.Length > 0)
                        profesor.Imagen = profesorfind.Imagen;
                    profesorfind.Nombre = profesor.Nombre;
                    profesorfind.Apellido = profesor.Apellido;
                    profesorfind.CorreoElectronico = profesor.CorreoElectronico;
                    profesorfind.Telefono = profesor.Telefono;
                    profesorfind.CarreraId = profesor.CarreraId;
                    _context.Update(profesorfind);
                    await _context.SaveChangesAsync();

                }
                try
                {
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.ProfesorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            //ViewData["CarreraId"] = new SelectList(_context.Carreras, "CarreraId", "Nombre", profesor.CarreraId);
            //return View(profesor);
        }

        // GET: Profesores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesores == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesores
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.ProfesorId == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesores == null)
            {
                return Problem("Entity set 'PruebaTec02EISGDbContext.Profesores'  is null.");
            }
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteImagen(int? id)
        {
            var carrofind = await _context.Profesores.FirstOrDefaultAsync(s => s.ProfesorId == id);
            carrofind.Imagen = null;
            _context.Update(carrofind);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProfesorExists(int id)
        {
          return (_context.Profesores?.Any(e => e.ProfesorId == id)).GetValueOrDefault();
        }
    }
}
