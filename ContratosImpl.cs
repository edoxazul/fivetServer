using Fivet.Dao;
using Fivet.ZeroIce.model;
using Ice;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fivet.ZeroIce
{
    public class ContratosImpl : ContratosDisp_
    {
        
        private readonly ILogger<ContratosImpl> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ContratosImpl(ILogger<ContratosImpl> logger,IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _logger.LogDebug("Building the ContratosImpl ... ");
            _serviceScopeFactory = serviceScopeFactory;

            _logger.LogInformation("Creating the database ... ");
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>(); 
                fc.Database.EnsureCreated();
                fc.SaveChanges();
            }

            _logger.LogDebug("Done ...");


        }


        public override Ficha crearFicha(Ficha ficha, Current current = null)
        {
            throw new System.NotImplementedException();
        }
        public override Persona crearPersona(Persona persona, Current current = null)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                FivetContext fc = scope.ServiceProvider.GetService<FivetContext>();
                fc.Personas.Add(persona);
                fc.SaveChanges();
                return persona;
            }

        }
        public override Control crearControl(int numeroFicha, Control control, Current current= null)
        {
            throw new System.NotImplementedException();

        }
        public override Ficha obtenerFicha(int numero, Current current= null)
        {
            throw new System.NotImplementedException();

        }
        public override Persona obtenerPersona(string rut, Current current = null)
        {
            throw new System.NotImplementedException();

        }
    }
}