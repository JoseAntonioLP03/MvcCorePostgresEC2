using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEC2.Data;
using MvcCorePostgresEC2.Models;

namespace MvcCorePostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private HospitalContext context;

        public RepositoryDepartamentos(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FinnDepartamentoAsync(int idDepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }

        public async Task CreateDepartamentoAsync(int id , string nombre , string localidad)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
