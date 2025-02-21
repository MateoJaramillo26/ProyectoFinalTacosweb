﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalTacos.Data;
using ProyectoFinalTacos.Models;

namespace ProyectoFinalTacos.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ProyectoFinalTacosContext _context;

        public FacturasController(ProyectoFinalTacosContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var proyectoFinalTacosContext = _context.Factura.Include(f => f.Producto).Include(f => f.Usuario);
            return View(await proyectoFinalTacosContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Producto)
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IDProducto"] = new SelectList(_context.Producto, "IDProducto", "DescripcionProducto");
            ViewData["IDUsuario"] = new SelectList(_context.Usuario, "IDUsuario", "CedulaUsuario");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFactura,IDUsuario,IDProducto,FechaEmision")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDProducto"] = new SelectList(_context.Producto, "IDProducto", "DescripcionProducto", factura.IDProducto);
            ViewData["IDUsuario"] = new SelectList(_context.Usuario, "IDUsuario", "CedulaUsuario", factura.IDUsuario);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IDProducto"] = new SelectList(_context.Producto, "IDProducto", "DescripcionProducto", factura.IDProducto);
            ViewData["IDUsuario"] = new SelectList(_context.Usuario, "IDUsuario", "CedulaUsuario", factura.IDUsuario);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFactura,IDUsuario,IDProducto,FechaEmision")] Factura factura)
        {
            if (id != factura.IDFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IDFactura))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDProducto"] = new SelectList(_context.Producto, "IDProducto", "DescripcionProducto", factura.IDProducto);
            ViewData["IDUsuario"] = new SelectList(_context.Usuario, "IDUsuario", "CedulaUsuario", factura.IDUsuario);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Producto)
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Factura.FindAsync(id);
            if (factura != null)
            {
                _context.Factura.Remove(factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Factura.Any(e => e.IDFactura == id);
        }
    }
}
