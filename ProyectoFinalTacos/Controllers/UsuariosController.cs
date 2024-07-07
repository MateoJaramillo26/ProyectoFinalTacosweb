using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalTacos.Data;
using ProyectoFinalTacos.Models;
using Microsoft.AspNetCore.Http;
using ProyectoFinalTacos.ViewModels;


namespace ProyectoFinalTacos.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ProyectoFinalTacosContext _context;

        public UsuariosController(ProyectoFinalTacosContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDUsuario,NombreUsuario,CedulaUsuario,NumeroUsuario,CorreoUsuario,ContraseñaUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDUsuario,NombreUsuario,CedulaUsuario,NumeroUsuario,CorreoUsuario,ContraseñaUsuario")] Usuario usuario)
        {
            if (id != usuario.IDUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IDUsuario))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IDUsuario == id);
        }

        // GET: Usuarios/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuario.FirstOrDefault(u => u.CorreoUsuario == model.CorreoUsuario && u.ContraseñaUsuario == model.ContraseñaUsuario);
                if (user != null)
                {
                    HttpContext.Session.SetString("UserEmail", user.CorreoUsuario);
                    HttpContext.Session.SetString("IsAdmin", "false");
                    return RedirectToAction("Index", "Home");
                }
                var admin = _context.Admin.FirstOrDefault(a => a.CorreoAdmin == model.CorreoUsuario && a.ContraseñaAdmin == model.ContraseñaUsuario);
                if (admin != null)
                {
                    HttpContext.Session.SetString("UserEmail", admin.CorreoAdmin);
                    HttpContext.Session.SetString("IsAdmin", "true");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // GET: Usuarios/Registro
        public IActionResult Registro()
        {
            return View();
        }

        // POST: Usuarios/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    NombreUsuario = model.NombreUsuario,
                    CedulaUsuario = model.CedulaUsuario,
                    NumeroUsuario = model.NumeroUsuario,
                    CorreoUsuario = model.CorreoUsuario,
                    ContraseñaUsuario = model.ContraseñaUsuario
                };
                try
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(HomeController.Index));
                } catch (Exception)
                {
                    ViewData["ErrorMessage"] = "El correo, cedula o numero de telefono ya estan registrados con otro usuario.";
                }
            }
            return View(model);
        }
    }
}
