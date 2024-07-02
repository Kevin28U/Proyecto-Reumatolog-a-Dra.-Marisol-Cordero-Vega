using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Proyecto_Final_CentroMedico;

public partial class ClinicaReumatologiaContext : DbContext
{
    public ClinicaReumatologiaContext()
    {
    }

    public ClinicaReumatologiaContext(DbContextOptions<ClinicaReumatologiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Antecedente> Antecedentes { get; set; }

    public virtual DbSet<Bitacora> Bitacoras { get; set; }

    public virtual DbSet<Canton> Cantons { get; set; }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Ocupacion> Ocupacions { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer();
    }


    //#warning To protect potentially sensitive information in your connection string, you should
    //move it out of source code. You can avoid scaffolding the connection string by using the Name=
    //syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For
    //more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

    //=> optionsBuilder.UseSqlServer("Server=FABIAN\\SQLEXPRESS;Database=CLINICA_REUMATOLOGIA;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.HasKey(e => e.IdAntecedentes).HasName("PK__ANTECEDE__26F55BAFA24331C6");

            entity.ToTable("ANTECEDENTES");

            entity.Property(e => e.IdAntecedentes).HasColumnName("ID_ANTECEDENTES");
            entity.Property(e => e.Ago)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AGO");
            entity.Property(e => e.Ahf)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AHF");
            entity.Property(e => e.ApnoP)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("APnoP");
            entity.Property(e => e.App)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("APP");
            entity.Property(e => e.Aqtx)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("AQTx");
        });

        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__BITACORA__44E70BF3F9AFDB21");

            entity.ToTable("BITACORA");

            entity.Property(e => e.IdBitacora).HasColumnName("ID_BITACORA");
            entity.Property(e => e.ExamenFisico)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("EXAMEN_FISICO");
            entity.Property(e => e.IdExpediente).HasColumnName("ID_EXPEDIENTE");
            entity.Property(e => e.ImpresionDiagnostica)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("IMPRESION_DIAGNOSTICA");
            entity.Property(e => e.PadecimientoActual)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("PADECIMIENTO_ACTUAL");
            entity.Property(e => e.PlanTratamiento)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("PLAN_TRATAMIENTO");

            entity.HasOne(d => d.IdExpedienteNavigation).WithMany(p => p.Bitacoras)
                .HasForeignKey(d => d.IdExpediente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BITACORA_EXPEDIENTE");
        });

        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => e.IdCanton).HasName("PK__CANTON__69745474648D5B31");

            entity.ToTable("CANTON");

            entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROVINCIA");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Cantons)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK_CANTON_PROVINCIA");
        });

        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__CITA__6416F2F03D36C5D0");

            entity.ToTable("CITA");

            entity.Property(e => e.IdCita).HasColumnName("ID_CITA");
            entity.Property(e => e.CedulaPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.Fecha).HasColumnName("FECHA");
            entity.Property(e => e.Hora).HasColumnName("HORA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MOTIVO");

            entity.HasOne(d => d.CedulaPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.CedulaPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CITA_PACIENTE");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CITA_USUARIO");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__DIRECCIO__FC7E9E8ED7950E99");

            entity.ToTable("DIRECCION");

            entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");
            entity.Property(e => e.Direccion1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.IdCanton).HasColumnName("ID_CANTON");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");

            entity.HasOne(d => d.IdCantonNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCanton)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DIRECCION_CANTON");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DIRECCION_PROVINCIA");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.IdExpediente).HasName("PK__EXPEDIEN__A99BAD8E31B022A9");

            entity.ToTable("EXPEDIENTE");

            entity.Property(e => e.IdExpediente).HasColumnName("ID_EXPEDIENTE");
            entity.Property(e => e.CedulaPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.IdAntecedentes).HasColumnName("ID_ANTECEDENTES");

            entity.HasOne(d => d.CedulaPacienteNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.CedulaPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EXPEDIENTE_PACIENTE");

            entity.HasOne(d => d.IdAntecedentesNavigation).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdAntecedentes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EXPEDIENTE_ANTECEDENTES");
        });

        modelBuilder.Entity<Ocupacion>(entity =>
        {
            entity.HasKey(e => e.IdOcupacion).HasName("PK__OCUPACIO__0325EA4CED2AB08C");

            entity.ToTable("OCUPACION");

            entity.Property(e => e.IdOcupacion).HasColumnName("ID_OCUPACION");
            entity.Property(e => e.Ocupacion1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OCUPACION");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.CedulaPaciente).HasName("PK__PACIENTE__FD8C4C6D291D86F9");

            entity.ToTable("PACIENTE");

            entity.Property(e => e.CedulaPaciente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PACIENTE");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.IdDireccion).HasColumnName("ID_DIRECCION");
            entity.Property(e => e.IdOcupacion).HasColumnName("ID_OCUPACION");
            entity.Property(e => e.IdSexo).HasColumnName("ID_SEXO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PACIENTE_DIRECCION");

            entity.HasOne(d => d.IdOcupacionNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdOcupacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PACIENTE_OCUPACION");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdSexo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PACIENTE_SEXO");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__PAGO__B68D23DFC811C6BF");

            entity.ToTable("PAGO");

            entity.Property(e => e.IdPago).HasColumnName("ID_PAGO");
            entity.Property(e => e.Detalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DETALLE");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.TotalPagar).HasColumnName("TOTAL_PAGAR");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PAGO_USUARIO");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("PK__PROVINCI__4245DC5231996B1C");

            entity.ToTable("PROVINCIA");

            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROVINCIA");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__203B0F68518D8154");

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ROL");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.IdSexo).HasName("PK__SEXO__F5FF4DDCF328ECD6");

            entity.ToTable("SEXO");

            entity.Property(e => e.IdSexo).HasColumnName("ID_SEXO");
            entity.Property(e => e.Sexo1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SEXO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__91136B9001A473EB");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_USUARIO");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USUARIO_ROL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    public void crearExpediente(
        string cedulaPaciente,
        int idAntecedentes)
    {

        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_EXPEDIENTE {0},{1}",
            cedulaPaciente,
            idAntecedentes
        );

    }


    public void crearAntecedentes(
        string AGO,
        string APnoP,
        string APP,
        string AHF,
        string AQTx
        )
    {
        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_ANTECEDENTE {0}, {1}, {2}, {3}, {4}",
            AGO,
            APnoP,
            APP,
            AHF,
            AQTx
        );
    }


    public void crearPaciente(
      string cedulaPaciente,
      string nombre,
      string primerApellido,
      string segundoApellido,
      int edad,
      int idSexo,
      int idOcupacion,
      int idDireccion,
      DateOnly fechaNacimiento
    )
    {
        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_PACIENTE {0},{1},{2},{3},{4},{5},{6},{7},{8}",
            cedulaPaciente,
            nombre,
            primerApellido,
            segundoApellido,
            edad,
            idSexo,
            idOcupacion,
            idDireccion,
            fechaNacimiento
        );

    }


    public void crearDireccion(
        int idProvincia,
        int idCanton,
        string direccion
    )
    {
        Database.ExecuteSqlRaw(
            "exec SP_INSERTAR_DIRECCION {0},{1}, {2}",
            idProvincia,
            idCanton,
            direccion
        );


    }

    public List<Ocupacion> obtenerOcupaciones()
    {

        return Ocupacions.FromSqlRaw("exec SP_LISTAR_OCUPACION").ToList();
    }

    public List<Sexo> obtenerSexos()
    {

        return Sexos.FromSqlRaw("exec SP_LISTAR_SEXO").ToList();
    }

    public List<Provincium> obtenerProvincia()
    {

        return Provincia.FromSqlRaw("exec SP_LISTAR_PROVINCIA").ToList();
    }

    public List<Canton> obtenerCanton()
    {

        return Cantons.FromSqlRaw("exec SP_LISTAR_CANTON").ToList();
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
