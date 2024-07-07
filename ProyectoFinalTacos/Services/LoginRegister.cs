using ProyectoFinalTacos.Data;
using ProyectoFinalTacos.Models;
using System.Linq;
using System.Threading.Tasks;

public class UserManager
{
    private readonly ProyectoFinalTacosContext _context;

    public UserManager(ProyectoFinalTacosContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUser(Usuario user)
    {
        if (_context.Usuario.Any(u => u.CorreoUsuario == user.CorreoUsuario))
        {
            return false; // User already exists
        }

        _context.Usuario.Add(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public Usuario AuthenticateUser(string email, string password)
    {
        return _context.Usuario.FirstOrDefault(u => u.CorreoUsuario == email && u.ContraseñaUsuario == password);
    }
}
