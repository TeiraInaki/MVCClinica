using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MVCClinica.Models;
using System.Data.Entity;

namespace MVCClinica.Data
{
    public class MedicosInitializer : DropCreateDatabaseAlways<MedicoDbContext>
    {
        protected override void Seed(MedicoDbContext context)
        {
            var medicos = new List<Medico>
            {
                new Medico
                {
                    Nombre = "Jorge",
                    Apellido = "Petro",
                    NroMatricula = 123,
                    Especialidad = "Pediatria",
                    FechaNacimiento = "1988-07-10",
                    Ciudad = "Maracaibo"
                }
            };
            medicos.ForEach(m => context.Medicos.Add(m));
            context.SaveChanges();
        }
    }
}