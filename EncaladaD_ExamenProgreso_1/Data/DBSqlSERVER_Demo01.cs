using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EncaladaD_ExamenProgreso_1.Models;

    public class DBSqlSERVER_Demo01 : DbContext
    {
        public DBSqlSERVER_Demo01 (DbContextOptions<DBSqlSERVER_Demo01> options)
            : base(options)
        {
        }

        public DbSet<EncaladaD_ExamenProgreso_1.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<EncaladaD_ExamenProgreso_1.Models.Reserva> Reserva { get; set; } = default!;

public DbSet<EncaladaD_ExamenProgreso_1.Models.Recompensas> PlanRecompensasCliente { get; set; } = default!;
    }
